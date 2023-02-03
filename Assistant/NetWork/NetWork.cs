using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace Assistant.NetWork
{
    /// <summary>
    /// 网络类
    /// </summary>
    public class NetWork
    {
        /// <summary>
        /// IP地址类型
        /// </summary>
        public enum AddressType
        {
            IPV4,
            IPV6
        }

        /// <summary>
        /// 服务器类型
        /// </summary>
        public enum NetType
        {
            TCP = 0,
            UDP = 1
        }

        /// <summary>
        /// 当前服务器的IP和端口信息
        /// </summary>
        public string ServerMsg { get; private set; }

        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        /// <param name="bIPV6">是否获取IPV6地址</param>
        /// <returns></returns>
        public static List<IPAddress> GetLocalIP(bool bIPV6 = false)
        {
            List<IPAddress> lisResult = new List<IPAddress> { };
            string sHostName = Dns.GetHostName();//获取用户名
            IPHostEntry ieHost = Dns.GetHostEntry(sHostName);//根据用户名获取IP
            foreach(IPAddress ip in ieHost.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)//IPV4地址
                {
                    lisResult.Add(ip);
                }
                else if(bIPV6 && ip.AddressFamily == AddressFamily.InterNetworkV6)//IPV6地址
                {
                    lisResult.Add(ip);
                }
            }
            return lisResult;
        }

        /// <summary>
        /// 服务器
        /// </summary>
        private Socket Server = null;

        /// <summary>
        /// 客户端连接事件
        /// </summary>
        /// <param name="client"></param>
        public delegate void _ClientConnect(string client);
        /// <summary>
        /// 客户端断开连接事件
        /// </summary>
        /// <param name="client"></param>
        public delegate void _ClientDisconnect(string client);
        /// <summary>
        /// 接收客户端消息事件
        /// </summary>
        /// <param name="client"></param>
        public delegate void _ClientSendMsg(string client, string msg);

        /// <summary>
        /// 当有客户端连接成功时触发事件
        /// </summary>
        public _ClientConnect ClientConnect;
        /// <summary>
        /// 当有客户端断开连接时触发事件
        /// </summary>
        public _ClientDisconnect ClientDisconnect;
        /// <summary>
        /// 服务器接收到客户端消息
        /// </summary>
        public _ClientSendMsg ClientSendMsg;

        /// <summary>
        /// TCP已连接的客户端
        /// </summary>
        public List<Socket> TcpClients = new List<Socket> { };
        /// <summary>
        /// UDP已连接的客户端
        /// </summary>
        public List<IPEndPoint> UdpClients = new List<IPEndPoint> { }; 

        /// <summary>
        /// 监听客户端连接线程
        /// </summary>
        private Thread thListen =  null;

        /// <summary>
        /// 创建服务器
        /// </summary>
        /// <param name="addressType">指定地址是IPV4还是IPV6</param>
        /// <param name="netType">指定TCP还是UDP</param>
        public NetWork(AddressType addressType, NetType netType)
        {
            AddressFamily addressFamily = AddressFamily.InterNetwork;
            ProtocolType protocol = ProtocolType.Tcp;
            SocketType socketType = SocketType.Stream;
            if (addressType !=  AddressType.IPV4)
            {
                addressFamily = AddressFamily.InterNetworkV6;
            }
            if (netType != NetType.TCP)
            {
                socketType = SocketType.Dgram;
                protocol = ProtocolType.Udp;
            }
            Server = new Socket(addressFamily, socketType, protocol);
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="ip">服务器绑定本地IP</param>
        /// <param name="port">服务器绑定的端口</param>
        /// <param name="maxnum">最大连接数：1-10</param>
        /// <exception cref="ArgumentException">最大连接数取值异常</exception>
        /// <exception cref="Exception">服务器绑定异常</exception>
        public void Listen(string ip, int port, int maxnum = 10)
        {
            if (maxnum > 10 || maxnum <= 0)
            {
                throw new ArgumentException("最大连接数的取值范围为1-10");
            }
            try
            {
                Server.Bind(new IPEndPoint(IPAddress.Parse(ip), port));//绑定
                if (Server.ProtocolType == ProtocolType.Tcp)
                {
                    Server.Listen(maxnum);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            if (thListen != null)
            {
                thListen.Abort();
            }
            
            if (Server.ProtocolType == ProtocolType.Tcp)//TCP服务器
            {
                thListen = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Socket client = Server.Accept();
                            TcpClients.Add(client);
                            if (ClientConnect != null)
                            {
                                IPEndPoint iPEndPoint = (IPEndPoint)client.RemoteEndPoint;
                                ClientConnect(iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString());
                            }
                            Thread th = new Thread(() => { 
                                while(true)
                                {
                                    try
                                    {
                                        byte[] buff = new byte[2048];
                                        int size =  client.Receive(buff);
                                        if (size > 0)
                                        {
                                            string msg = Encoding.UTF8.GetString(buff, 0, size);
                                            if (ClientSendMsg != null)
                                            {
                                                IPEndPoint iPEndPoint = (IPEndPoint)client.RemoteEndPoint;
                                                ClientSendMsg(iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString(), msg);
                                            }
                                        }
                                        else
                                        {
                                            if (ClientDisconnect != null)
                                            {
                                                IPEndPoint iPEndPoint = (IPEndPoint)client.RemoteEndPoint;
                                                ClientDisconnect(iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString());
                                            }
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        if (!client.Connected)
                                        {
                                            if (ClientDisconnect != null)
                                            {
                                                IPEndPoint iPEndPoint = (IPEndPoint)client.RemoteEndPoint;
                                                ClientDisconnect(iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString());
                                            }
                                            break;
                                        }
                                        break;
                                    }
                                }
                            });
                            th.Start();
                        }
                        catch (Exception e) { }
                    }
                });
                thListen.Start();
            }
            else//UDP服务器
            {
                thListen = new Thread(() =>
                {
                    while (true)
                    {
                        byte[] buff = new byte[2048];
                        try
                        {
                            int size = Server.Receive(buff);
                            if(size > 0)
                            {
                                string msg = Encoding.UTF8.GetString(buff, 0, size);
                                if(msg.StartsWith("发起连接："))
                                {
                                    if (ClientConnect != null)
                                    {
                                        ClientConnect(msg.Replace("发起连接：",""));
                                    }
                                }
                                else if(msg.StartsWith("断开连接："))
                                {
                                    if (ClientDisconnect != null)
                                    {
                                        ClientDisconnect(msg.Replace("断开连接：", ""));
                                    }
                                }
                                else
                                {
                                    if (ClientSendMsg != null)
                                    {
                                        string strClient = "";
                                        string strMsg = msg;
                                        string ser = msg.Split('：')[0];//根据中文发送的冒号分开客户端信息和消息内容
                                        List<string> lis = ser.Split(':').ToList();//再根据英文冒号分开IP地址和端口
                                        if (lis.Count >= 2)
                                        {
                                            string Spor = lis[lis.Count-1]; //提取端口
                                            lis.RemoveAt(lis.Count - 1);
                                            string Sip = string.Join(":", lis);//提取IP
                                            if (IPAddress.TryParse(Sip, out IPAddress add) && int.TryParse(Spor, out int por))
                                            {
                                                strClient = ser;
                                            }
                                        }
                                        ClientSendMsg(strClient, strMsg);
                                    }
                                }
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                });
                thListen.Start();
            }
            ServerMsg = ip + ":" + port;
        }

        /// <summary>
        /// 关闭服务器并停止监听
        /// </summary>
        public void Close()
        {
            if(TcpClients.Count > 0)
            {
                foreach(Socket cli in TcpClients)
                {
                    cli.Close();
                    cli.Dispose();
                }
            }
            Server.Close();
            Server.Dispose();
            if (thListen != null)
            {
                thListen.Abort();
                thListen = null;
            }
        }
    }
}
