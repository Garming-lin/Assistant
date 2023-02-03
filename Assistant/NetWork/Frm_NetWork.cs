using Assistant.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant
{
    public partial class Frm_NetWork : Form
    {
        public Frm_NetWork()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 最大显示接收字符
        /// </summary>
        private const int MaxRecieve = 1000000000;

        /// <summary>
        /// 服务器创建成功
        /// </summary>
        private bool ServerCreate { get; set; } = false;
        /// <summary>
        /// 客户端连接成功
        /// </summary>
        private bool ClientConnect { get; set; } = false;

        /// <summary>
        /// INI配置文件
        /// </summary>
        private IniHelper iniFile = new IniHelper(Global.sNetWorkSetting);

        /// <summary>
        /// 服务器对象
        /// </summary>
        private NetWork.NetWork Server = null;

        /// <summary>
        /// 客户端对象
        /// </summary>
        private Socket Client = null;
        /// <summary>
        /// 客户端连接的服务器端信息
        /// </summary>
        private string ConnectServer = "";
        /// <summary>
        /// 客户端信息
        /// </summary>
        private string ClientMsg = "";

        /// <summary>
        /// 加载本地设置
        /// </summary>
        private void InitSetting()
        {
            #region 服务器配置

            string sServerport = iniFile.ReadValue("服务器配置", "serverport");
            if (int.TryParse(sServerport, out int serverport))//服务器端口的配置
            {
                tboxServerPort.Text = serverport.ToString();
            }
            string sServertcp = iniFile.ReadValue("服务器配置", "servertcp");//服务器tcp/udp选项
            if (sServertcp.ToLower().Equals("true"))
            {
                rbServerTCP.Checked = true;
                rbServerUDP.Checked = false;
            }
            else
            {
                rbServerTCP.Checked = false;
                rbServerUDP.Checked = true;
            }
            chboxIPV6.Checked = iniFile.ReadValue("服务器配置", "ipv6").ToLower().Equals("true");//ipv6勾选项
            string sServertime = iniFile.ReadValue("服务器配置", "servertime");//服务器定时发送时间
            if (int.TryParse(sServertime, out int servertime))
            {
                tboxServerTime.Text = servertime.ToString();
            }
            cboxServerAutoShow.Checked = iniFile.ReadValue("服务器配置", "autoshow").ToLower().Equals("true");//自动显示最新行勾选项

            cboxShowOnlyServer.Checked = iniFile.ReadValue("服务器配置", "showonly").ToLower().Equals("true");//仅显示接收信息勾选项

            #endregion

            #region 客户端配置


            string sClientport = iniFile.ReadValue("客户端配置", "clientport");
            if (int.TryParse(sClientport, out int clientport))//客户端端口的配置
            {
                tboxClientPort.Text = clientport.ToString();
            }
            string sClienttcp = iniFile.ReadValue("客户端配置", "clienttcp");//客户端tcp/udp选项
            if (sClienttcp.ToLower().Equals("true"))
            {
                rbClientTCP.Checked = true;
                rbClientUDP.Checked = false;
            }
            else
            {
                rbClientTCP.Checked = false;
                rbClientUDP.Checked = true;
            }
            string sClienttime = iniFile.ReadValue("客户端配置", "clienttime");//客户端定时发送时间
            if (int.TryParse(sClienttime, out int clienttime))
            {
                tboxClientTime.Text = clienttime.ToString();
            }

            cboxConectMsg.Checked = iniFile.ReadValue("客户端配置", "sendconnect").ToLower().Equals("true");//UDP下连接成功和断开连接发送提示

            cboxClientAutoShow.Checked = iniFile.ReadValue("客户端配置", "autoshow").ToLower().Equals("true");//自动显示最新行勾选项

            cboxShowOnlyClient.Checked = iniFile.ReadValue("客户端配置", "showonly").ToLower().Equals("true");//仅显示接收信息勾选项

            #endregion
        }

        /// <summary>
        /// 保存本地配置
        /// </summary>
        private void SaveSetting()
        {
            #region 服务器配置

            iniFile.WriteValue("服务器配置", "serverport", tboxServerPort.Text.Trim());//端口
            iniFile.WriteValue("服务器配置", "servertcp", rbServerTCP.Checked.ToString().ToLower());//tcp或udp
            iniFile.WriteValue("服务器配置", "ipv6", chboxIPV6.Checked.ToString().ToLower());
            iniFile.WriteValue("服务器配置", "servertime", tboxServerTime.Text);
            iniFile.WriteValue("服务器配置", "autoshow", cboxServerAutoShow.Checked.ToString().ToLower());//自动显示最新行勾选项
            iniFile.WriteValue("服务器配置", "showonly", cboxShowOnlyServer.Checked.ToString().ToLower());//仅显示接收信息勾选项

            #endregion

            #region 客户端配置

            iniFile.WriteValue("客户端配置", "clientport", tboxClientPort.Text.Trim());//端口
            iniFile.WriteValue("客户端配置", "clienttcp", rbClientTCP.Checked.ToString().ToLower());//tcp或udp
            iniFile.WriteValue("客户端配置", "clienttime", tboxClientTime.Text);//客户端定时发送时间
            iniFile.WriteValue("客户端配置", "sendconnect", cboxConectMsg.Checked.ToString().ToLower());//UDP下连接成功和断开连接发送提示
            iniFile.WriteValue("客户端配置", "autoshow", cboxClientAutoShow.Checked.ToString().ToLower());//自动显示最新行勾选项
            iniFile.WriteValue("客户端配置", "showonly", cboxShowOnlyClient.Checked.ToString().ToLower());//仅显示接收信息勾选项

            #endregion
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_NetWork_Load(object sender, EventArgs e)
        {
            InitSetting();//加载本地设置
            btnRefresh_Click(sender, e);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_NetWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Server != null)
            {
                Server.ClientConnect -= new NetWork.NetWork._ClientConnect(ClientConnectEvent);
                Server.ClientDisconnect -= new NetWork.NetWork._ClientDisconnect(ClientDisconnectEvent);
                Server.ClientSendMsg -= new NetWork.NetWork._ClientSendMsg(ClientSendMsgEvent);
                Server.Close();
            }
            if(Client != null)
            {
                Client.Close();
                Client.Dispose();
            }
            SaveSetting();
        }


        /// <summary>
        /// 十六进制输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] hex = new char[] { ' ','0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','A','B','C','D','E','F' };
            if(e.KeyChar < 32 || hex.Contains(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        #region 服务器操作

        /// <summary>
        /// 服务器接收客户端连接
        /// </summary>
        /// <param name="bServer"></param>
        /// <param name="type">0客户端连接，1客户端断开，2服务器发送，3接收客户端</param>
        /// <param name="client"></param>
        /// <param name="msg"></param>
        private void ShowServerMsg(string sServer,int iType, string sClient, string sMsg)
        {
            if(rtBoxServerRecieve.Text.Length >= MaxRecieve)
            {
                rtBoxServerRecieve.Text = string.Empty;
            }
            Color c = Color.Green;
            switch(iType)
            {
                case 0:c = Color.Green; break;//服务器收到客户端连接字体背景色
                case 1:c = Color.Red; break;//服务器收到客户端断开字体背景色
                case 2: c = Color.GreenYellow; break;//服务器发送消息字体背景色
                default:c = Color.Yellow;break;//接收客户端消息字体背景色
            }
            if(iType == 2 || iType == 3)
            {
                string ser = "服务器";
                string cli = $"客户端[{sClient}]";
                string sHeader = string.Format("{0}=>{1}    {2}", iType == 2 ? ser : cli, iType == 2 ? cli : ser, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                rtBoxServerRecieve.SelectionColor = c;
                rtBoxServerRecieve.AppendText("\r\n" + sHeader);
                rtBoxServerRecieve.SelectionColor = c;
                rtBoxServerRecieve.AppendText("\r\n" + sMsg);
            }
            else
            {
                string sHeader = string.Format("{0}[{1}]=>    {2}", "服务器", sServer, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                rtBoxServerRecieve.SelectionColor = c;
                rtBoxServerRecieve.AppendText("\r\n" + sHeader);
                rtBoxServerRecieve.SelectionColor = c;
                rtBoxServerRecieve.AppendText("\r\n" + sMsg);
            }
        }

        /// <summary>
        /// 刷新本地IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboxIp.Items.Clear();
            List<IPAddress> lisAddr = NetWork.NetWork.GetLocalIP(chboxIPV6.Checked);
            foreach (IPAddress ip in lisAddr)
            {
                cboxIp.Items.Add(ip.ToString());
                if (cboxClientIP.Enabled)
                {
                    cboxClientIP.Items.Remove(ip.ToString());
                    cboxClientIP.Items.Add(ip.ToString());
                }
            }
            if(cboxIp.Items.Count > 0)
            {
                cboxIp.SelectedIndex = 0;
                if (cboxClientIP.Enabled)
                {
                    cboxClientIP.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 端口输入限制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar < 32 || Char.IsDigit(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 创建服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateServer_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tboxServerPort.Text))
            {
                MessageBox.Show("请输入服务器端口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxServerPort.Focus();
                return;
            }
            bool bCreate = false;
            string exMsg = string.Empty;
            string serverIP = cboxIp.Text;
            Action action = new Action(delegate 
            {
                if (btnCreateServer.Text == "创建服务器")
                {
                    try
                    {
                        IPAddress address = IPAddress.Parse(serverIP);
                        NetWork.NetWork.AddressType addressType = NetWork.NetWork.AddressType.IPV4;
                        NetWork.NetWork.NetType netType = NetWork.NetWork.NetType.TCP;
                        if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            addressType = NetWork.NetWork.AddressType.IPV6;
                        }
                        if (!rbServerTCP.Checked)
                        {
                            netType = NetWork.NetWork.NetType.UDP;
                        }
                        Server = new NetWork.NetWork(addressType, netType);
                        Server.ClientConnect += new NetWork.NetWork._ClientConnect(ClientConnectEvent);
                        Server.ClientDisconnect += new NetWork.NetWork._ClientDisconnect(ClientDisconnectEvent);
                        Server.ClientSendMsg += new NetWork.NetWork._ClientSendMsg(ClientSendMsgEvent);
                        Server.Listen(serverIP, int.Parse(tboxServerPort.Text));
                        bCreate = true;
                        //cboxIp.Enabled = false;
                        //tboxServerPort.Enabled = false;
                        //rbServerTCP.Enabled = false;
                        //rbServerUDP.Enabled = false;
                        //chboxIPV6.Enabled = false;
                        //btnRefresh.Enabled = false;
                        //btnServerSend.Enabled = true;
                        //cboxServerTime.Enabled = true;
                        //btnCreateServer.Text = "关闭";
                        //rtBoxServerRecieve.SelectionColor = Color.Green;
                        //rtBoxServerRecieve.AppendText("创建服务器成功...\r\n");
                    }
                    catch (Exception ex)
                    {
                        exMsg = ex.Message;
                    }
                }
                else
                {
                    if (Server != null)
                    {
                        Server.ClientConnect -= new NetWork.NetWork._ClientConnect(ClientConnectEvent);
                        Server.ClientDisconnect -= new NetWork.NetWork._ClientDisconnect(ClientDisconnectEvent);
                        Server.ClientSendMsg -= new NetWork.NetWork._ClientSendMsg(ClientSendMsgEvent);
                        Server.Close();
                    }

                    //cboxIp.Enabled = true;
                    //tboxServerPort.Enabled = true;
                    //rbServerTCP.Enabled = true;
                    //rbServerUDP.Enabled = true;
                    //chboxIPV6.Enabled = true;
                    //btnRefresh.Enabled = true;
                    //btnServerSend.Enabled = false;
                    //cboxServerTime.Checked = false;
                    //cboxServerTime.Enabled = false;
                    //btnCreateServer.Text = "创建服务器";
                    //rtBoxServerRecieve.SelectionColor = Color.Red;
                    //rtBoxServerRecieve.AppendText("关闭服务器...\r\n");
                }
            });
            void callback(IAsyncResult async)
            {
                this.Invoke(new EventHandler(delegate 
                {
                    if(!string.IsNullOrEmpty(exMsg))
                    {
                        MessageBox.Show(exMsg, "创建服务器失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if(bCreate)
                    {
                        cboxIp.Enabled = false;
                        tboxServerPort.Enabled = false;
                        rbServerTCP.Enabled = false;
                        rbServerUDP.Enabled = false;
                        chboxIPV6.Enabled = false;
                        btnRefresh.Enabled = false;
                        //btnServerSend.Enabled = true;
                        //cboxServerTime.Enabled = true;
                        btnCreateServer.Text = "关闭";
                        if (string.IsNullOrEmpty(exMsg))
                        {
                            rtBoxServerRecieve.SelectionColor = Color.Green;
                            rtBoxServerRecieve.AppendText("\r\n创建服务器成功...");
                        }
                        ServerCreate = true;
                        tboxServerSend_TextChanged(sender, e);
                    }
                    else
                    {
                        cboxIp.Enabled = true;
                        tboxServerPort.Enabled = true;
                        rbServerTCP.Enabled = true;
                        rbServerUDP.Enabled = true;
                        chboxIPV6.Enabled = true;
                        btnRefresh.Enabled = true;
                        btnServerSend.Enabled = false;
                        cboxServerTime.Checked = false;
                        cboxServerTime.Enabled = false;
                        btnCreateServer.Text = "创建服务器";
                        if (string.IsNullOrEmpty(exMsg))
                        {
                            rtBoxServerRecieve.SelectionColor = Color.Red;
                            rtBoxServerRecieve.AppendText("\r\n关闭服务器...");
                        }
                        ServerCreate = false;
                    }
                }));
            }
            action.BeginInvoke(callback, null);
        }

        /// <summary>
        /// 客户端连接事件
        /// </summary>
        /// <param name="client"></param>
        private void ClientConnectEvent(string client)
        {
            this.Invoke(new EventHandler(delegate
            {
                cboxConnectClient.Items.Remove(client);
                cboxConnectClient.Items.Add(client);
                ShowServerMsg(Server.ServerMsg, 0, "", string.Format("客户端[{0}]  连接成功", client));
            }));
        }

        /// <summary>
        /// 客户端断开连接事件
        /// </summary>
        /// <param name="client"></param>
        private void ClientDisconnectEvent(string client)
        {
            this.Invoke(new EventHandler(delegate
            {
                cboxConnectClient.Items.Remove(client);
                ShowServerMsg(Server.ServerMsg, 1, "", string.Format("客户端[{0}]  断开", client));
            }));
        }

        /// <summary>
        /// 服务器接收客户端消息
        /// </summary>
        /// <param name="client"></param>
        private void ClientSendMsgEvent(string client,string msg)
        {
            this.Invoke(new EventHandler(delegate 
            {
                ShowServerMsg(Server.ServerMsg, 3, client, msg);
            }));
        }

        /// <summary>
        /// 清空服务器接收区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearServerRecieve_Click(object sender, EventArgs e)
        {
            rtBoxServerRecieve.Text = string.Empty;
        }

        /// <summary>
        /// 清空服务器发送区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearServerSend_Click(object sender, EventArgs e)
        {
            tboxServerSend.Text = string.Empty;
        }


        /// <summary>
        /// 服务器定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxServerTime_CheckedChanged(object sender, EventArgs e)
        {
            cboxServerTime.CheckedChanged -= new EventHandler(cboxServerTime_CheckedChanged);
            bool bEnable = true;
            if (string.IsNullOrEmpty(tboxServerSend.Text))
            {
                MessageBox.Show("发送内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxServerSend.Focus();
                cboxServerTime.Checked = false; 
                bEnable = false;
            }
            int.TryParse(tboxServerTime.Text, out int time);
            if (time <= 0)
            {
                MessageBox.Show("请输入有效的定时发送时间（毫秒）！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxServerTime.Focus();
                cboxServerTime.Checked = false;
                bEnable = false;
            }
            if(bEnable)
            {
                if (cboxServerTime.Checked)
                {
                    btnClearServerSend.Enabled = false;
                    chboxServerSendClear.Checked = false;//定时发送不能自动清空
                    chboxServerSendClear.Enabled = false;
                    tboxServerTime.Enabled = false;//不允许修改定时时间
                }
                else
                {
                    btnClearServerSend.Enabled = true;
                    chboxServerSendClear.Enabled = true;
                    tboxServerTime.Enabled = true;//允许修改定时时间
                }
            }
            cboxServerTime.CheckedChanged += new EventHandler(cboxServerTime_CheckedChanged);
        }

        /// <summary>
        /// 显示最新行消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerShowMsgNew(object sender, EventArgs e)
        {
            rtBoxServerRecieve.SelectionStart = rtBoxServerRecieve.Text.Length;
            rtBoxServerRecieve.ScrollToCaret();
        }

        /// <summary>
        /// 自动显示最新消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxServerAutoShow.Checked)
            {
                ServerShowMsgNew(sender, e);
                rtBoxServerRecieve.TextChanged += new EventHandler(ServerShowMsgNew);
            }
            else
            {
                rtBoxServerRecieve.TextChanged -= new EventHandler(ServerShowMsgNew);
            }
        }

        /// <summary>
        /// 服务器定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxServerSend_TextChanged(object sender, EventArgs e)
        {
            string sendMsg = tboxServerSend.Text;
            if (ServerCreate)
            {
                if (string.IsNullOrEmpty(sendMsg))
                {
                    cboxServerTime.Enabled = false;
                    cboxServerTime.Checked = false;
                    btnServerSend.Enabled = false;
                }
                else
                {
                    cboxServerTime.Enabled = true;
                    btnServerSend.Enabled = true;
                }
            }
            if(chboxServerRecieveHex.Checked && !string.IsNullOrEmpty(sendMsg))//十六进制发送
            {

            }
        }

        /// <summary>
        /// 服务器发送信息
        /// </summary>
        private void ServerSend()
        {
            byte[] buff = new byte[2048];
            if(chboxServerSendHex.Checked)//十六进制发送
            {

            }
            else
            {
                buff = Encoding.UTF8.GetBytes(tboxServerSend.Text);
            }
            if(cboxConnectClient.Text.Equals("全部"))
            {

            }
            else
            {
                string[] clientMsg = cboxConnectClient.Text.Split(':');
                //TCP发送
                if(rbServerTCP.Checked)
                {
                    Socket client = Server.TcpClients.FirstOrDefault(x => ((IPEndPoint)x.RemoteEndPoint).Address.ToString().Equals(clientMsg[0]) && ((IPEndPoint)x.RemoteEndPoint).Port.ToString().Equals(clientMsg[1]));
                    if (client != null)
                    {
                        client.Send(buff);
                    }
                }
                //UDP发送
                else
                {

                }
            }
        }

        /// <summary>
        /// 服务器发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServerSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tboxServerSend.Text))
            {
                MessageBox.Show("发送内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxServerSend.Focus();
                return;
            }
            ServerSend();
            if (chboxServerSendClear.Checked)
            {
                tboxServerSend.Text = string.Empty;
            }
        }

        /// <summary>
        /// 服务器十六进制发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chboxServerSendHex_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxServerSendHex.Checked)
            {
                tboxServerSend.KeyPress += new KeyPressEventHandler(Hex_KeyPress);
            }
            else
            {
                tboxServerSend.KeyPress -= new KeyPressEventHandler(Hex_KeyPress);
            }
        }

        #endregion

        #region 客户端操作

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bServer"></param>
        /// <param name="sServer"></param>
        /// <param name="sClient"></param>
        /// <param name="sMsg"></param>
        private void ShowClientMsg(bool bServer, string sServer, string sClient, string sMsg)
        {
            if (rtBoxClientRecieve.Text.Length >= 2000000000)
            {
                rtBoxClientRecieve.Text = string.Empty;
            }
            Color c = bServer ? Color.Red : Color.Yellow;
            string ser = "服务器[" + sServer + "]";
            string cli = "客户端[" + sClient + "]";
            string sHeader = string.Format("{0}=>{1}    {2}", bServer ? ser : cli, bServer ? cli : ser, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            rtBoxClientRecieve.SelectionColor = c;
            rtBoxClientRecieve.AppendText("\r\n" + sHeader);
            rtBoxClientRecieve.SelectionColor = c;
            rtBoxClientRecieve.AppendText("\r\n" + sMsg);
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tboxClientPort.Text))
            {
                MessageBox.Show("请输入服务器端口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxClientPort.Focus();
                return;
            }
            bool bConnect = false;
            string serverIp = cboxClientIP.Text;
            string exMSg = string.Empty;
            Action action = delegate 
            {
                if (btnConnect.Text == "连接")
                {
                    try
                    {
                        IPAddress iPAddress = IPAddress.Parse(serverIp);
                        SocketType socketType = rbClientTCP.Checked ? SocketType.Stream : SocketType.Dgram;
                        ProtocolType protocolType = rbClientTCP.Checked ? ProtocolType.Tcp : ProtocolType.Udp;
                        Client = new Socket(iPAddress.AddressFamily, socketType, protocolType);
                        Client.Connect(iPAddress, int.Parse(tboxClientPort.Text));

                        IPEndPoint iPEndPoint = (IPEndPoint)Client.LocalEndPoint;
                        ClientMsg = iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString();
                        ConnectServer = iPAddress.ToString() + ":" + tboxClientPort.Text;
                        if (cboxConectMsg.Checked && rbClientUDP.Checked)
                        {
                            Client.Send(Encoding.UTF8.GetBytes("发起连接：" + ClientMsg));
                        }
                        bConnect = true;
                        //cboxClientIP.Enabled = false;
                        //tboxClientPort.Enabled = false;
                        //rbClientTCP.Enabled = false;
                        //rbClientUDP.Enabled = false;
                        //btnClientSend.Enabled = true;
                        //cboxClientTime.Enabled = true;
                        //if (!cboxClientIP.Items.Contains(cboxClientIP.Text))
                        //{
                        //    cboxClientIP.Items.Add(cboxClientIP.Text);
                        //}
                        //btnConnect.Text = "断开";

                        Thread th = new Thread(() => {
                            Thread.Sleep(100);
                            while(Client.Connected)
                            {
                                try
                                {
                                    byte[] buff = new byte[2048];
                                    int size = Client.Receive(buff);
                                    if (size > 0)
                                    {
                                        if (chboxClientRecieveHex.Checked)//十六进制显示
                                        {
                                            StringBuilder builder = new StringBuilder();
                                            for (int i = 0; i < size; i++)
                                            {
                                                builder.Append(string.Format("{0:X2} ", buff[i]));
                                            }
                                            string strResult = builder.ToString().Trim();
                                            this.Invoke(new EventHandler(delegate {
                                                ShowClientMsg(true, ConnectServer, ClientMsg, strResult);
                                            }));
                                        }
                                        else//文本显示
                                        {
                                            string msg = Encoding.UTF8.GetString(buff);
                                            this.Invoke(new EventHandler(delegate {
                                                ShowClientMsg(true, ConnectServer, ClientMsg, msg);
                                            }));
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                catch(Exception ex)
                                {
                                    if (ex.Message.Contains("远程主机强迫关闭了一个现有的连接"))
                                    {
                                        this.Invoke(new EventHandler(delegate
                                        {
                                            MessageBox.Show(ex.Message, "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }));
                                    }
                                    break;
                                }
                            }
                            try
                            {
                                Client.Close();
                                Client.Dispose();
                                this.Invoke(new EventHandler(delegate
                                {
                                    cboxClientIP.Enabled = true;
                                    tboxClientPort.Enabled = true;
                                    rbClientTCP.Enabled = true;
                                    rbClientUDP.Enabled = true;
                                    btnClientSend.Enabled = false;
                                    cboxClientTime.Checked = false;
                                    cboxClientTime.Enabled = false;
                                    btnConnect.Text = "连接";
                                    ClientConnect = false;
                                }));
                            }
                            catch { }
                        });
                        th.Start();
                    }
                    catch (Exception ex)
                    {
                        exMSg = ex.Message;
                    }
                }
                else
                {
                    if (Client != null)
                    {
                        if (cboxConectMsg.Checked && rbClientUDP.Checked)
                        {
                            IPEndPoint iPEndPoint = (IPEndPoint)Client.LocalEndPoint;
                            Client.Send(Encoding.UTF8.GetBytes("断开连接：" + iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString()));
                        }
                        Client.Close();
                    }

                    //cboxClientIP.Enabled = true;
                    //tboxClientPort.Enabled = true;
                    //rbClientTCP.Enabled = true;
                    //rbClientUDP.Enabled = true;
                    //btnClientSend.Enabled = false;
                    //cboxClientTime.Checked = false;
                    //cboxClientTime.Enabled = false;
                    //btnConnect.Text = "连接";
                }
            };
            void callback(IAsyncResult async)
            {
                this.Invoke(new EventHandler(delegate
                {
                    if(!string.IsNullOrEmpty(exMSg))
                    {
                        MessageBox.Show(exMSg, "连接出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (bConnect)
                    {
                        ClientConnect = true;
                        cboxClientIP.Enabled = false;
                        tboxClientPort.Enabled = false;
                        rbClientTCP.Enabled = false;
                        rbClientUDP.Enabled = false;
                        //btnClientSend.Enabled = true;
                        //cboxClientTime.Enabled = true;
                        tboxClientSend_TextChanged(sender, e);
                        if (!cboxClientIP.Items.Contains(cboxClientIP.Text))
                        {
                            cboxClientIP.Items.Add(cboxClientIP.Text);
                        }
                        btnConnect.Text = "断开";
                    }
                    else
                    {
                        cboxClientIP.Enabled = true;
                        tboxClientPort.Enabled = true;
                        rbClientTCP.Enabled = true;
                        rbClientUDP.Enabled = true;
                        btnClientSend.Enabled = false;
                        cboxClientTime.Checked = false;
                        cboxClientTime.Enabled = false;
                        btnConnect.Text = "连接";
                        ClientConnect = false;
                    }
                }));
            }
            action.BeginInvoke(callback,null);
        }

        /// <summary>
        /// 客户端发送消息
        /// </summary>
        private void ClientSend()
        {
            IPEndPoint iPEndPoint = (IPEndPoint)Client.LocalEndPoint;
            string climsg = tboxClientSend.Text;
            //十六进制发送
            if (chboxClientSendHex.Checked)
            {
                Regex regex = new Regex(@"([^A-Fa-f0-9]+?)+");
                MatchCollection matchs = regex.Matches(climsg);
                if(matchs.Count > 0)
                {
                    List<string> list = new List<string>();
                    foreach(var v in matchs)
                    {
                        list.Add(v.ToString());
                    }
                    MessageBox.Show(string.Format("包含非法字符:\n{0}\n请重新输入！",string.Join("\n", list)),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                //climsg.PadLeft(2, '0');
            }
            //文本发送
            else
            {
                if (cboxConectMsg.Checked && rbClientUDP.Checked)//UDP下，发送客户端信息
                {
                    climsg = iPEndPoint.Address.ToString() + ":" + iPEndPoint.Port.ToString() + "：" + climsg;
                }
                Client.Send(Encoding.UTF8.GetBytes(climsg));
            }
            if(!cboxShowOnlyClient.Checked)
            {
                ShowClientMsg(false, ConnectServer, ClientMsg, climsg);
            }
        }

        /// <summary>
        /// 客户端发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClientSend_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tboxClientSend.Text))
            {
                MessageBox.Show("发送内容不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                tboxClientSend.Focus();
                return;
            }
            ClientSend();
            if (chboxClientSendClear.Checked)
            {
                tboxClientSend.Text = string.Empty;
            }
        }

        /// <summary>
        /// 客户端IP输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxClientIP_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        /// <summary>
        /// 客户端定时发送勾选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxClientTime_CheckedChanged(object sender, EventArgs e)
        {
            cboxClientTime.CheckedChanged -= new EventHandler(cboxClientTime_CheckedChanged);
            bool bEnable = true;
            if (string.IsNullOrEmpty(tboxClientSend.Text))
            {
                MessageBox.Show("发送内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxClientSend.Focus();
                cboxClientTime.Checked = false; 
                bEnable = false;
            }
            int.TryParse(tboxClientTime.Text, out int time);
            if (time <= 0)
            {
                MessageBox.Show("请输入有效的定时发送时间（毫秒）！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tboxClientTime.Focus();
                cboxClientTime.Checked = false;
                bEnable = false;
            }
            if(bEnable)
            {
                if (cboxClientTime.Checked)
                {
                    chboxClientSendClear.Enabled = false;
                    btnClearClientSend.Enabled = false;
                    chboxClientSendClear.Checked = false;//定时发送不能清空
                    tboxClientTime.Enabled = false;//不允许修改定时时间
                    timer2.Interval = time;
                    timer2.Enabled = true;
                }
                else
                {
                    btnClearClientSend.Enabled = true;
                    chboxClientSendClear.Enabled = true;
                    tboxClientTime.Enabled = true;//允许修改定时时间
                    timer2.Enabled = false;
                }
            }
            cboxClientTime.CheckedChanged += new EventHandler(cboxClientTime_CheckedChanged);
        }

        /// <summary>
        /// 显示最新行消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientShowMsgNew(object sender, EventArgs e)
        {
            rtBoxClientRecieve.SelectionStart = rtBoxClientRecieve.Text.Length;
            rtBoxClientRecieve.ScrollToCaret();
        }

        /// <summary>
        /// 自动显示最新消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxClientAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxClientAutoShow.Checked)
            {
                ClientShowMsgNew(sender, e);
                rtBoxClientRecieve.TextChanged += new EventHandler(ClientShowMsgNew);
            }
            else
            {
                rtBoxClientRecieve.TextChanged -= new EventHandler(ClientShowMsgNew);
            }
        }

        /// <summary>
        /// 清空客户端接收区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearClientRecieve_Click(object sender, EventArgs e)
        {
            rtBoxClientRecieve.Text = string.Empty;
        }

        /// <summary>
        /// 清空客户端发送区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearClientSend_Click(object sender, EventArgs e)
        {
            tboxClientSend.Text = string.Empty;
        }

        /// <summary>
        /// 客户端定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            ClientSend();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxClientSend_TextChanged(object sender, EventArgs e)
        {
            if (ClientConnect)
            {
                if (string.IsNullOrEmpty(tboxClientSend.Text))
                {
                    cboxClientTime.Enabled = false;
                    cboxClientTime.Checked = false;
                    btnClientSend.Enabled = false;
                }
                else
                {
                    cboxClientTime.Enabled = true;
                    btnClientSend.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 十六进制发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chboxClientSendHex_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxClientSendHex.Checked)
            {
                tboxClientSend.KeyPress += new KeyPressEventHandler(Hex_KeyPress);
            }
            else
            {
                tboxClientSend.KeyPress -= new KeyPressEventHandler(Hex_KeyPress);
            }
        }




        #endregion

        private void chboxServerRecieveHex_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
