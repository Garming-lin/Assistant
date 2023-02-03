using Assistant.Module;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Assistant
{
    public partial class Frm_SerialPort : Form
    {
        public Frm_SerialPort()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 换行十六进制字符串
        /// </summary>
        string sNewLineHex = "";

        /// <summary>
        /// 最大显示接收字符
        /// </summary>
        private const int MaxRecieve = 1000000000;

        /// <summary>
        /// INI配置文件
        /// </summary>
        private IniHelper iniFile = new IniHelper(Global.sSerialPortSetting);

        /// <summary>
        /// 串口对象
        /// </summary>
        private SerialPort spPort = new SerialPort();
        /// <summary>
        /// 本地可用串口列表
        /// </summary>
        private List<string>lisPortName = new List<string>();
        /// <summary>
        /// 标志是否断开重连
        /// </summary>
        private bool bCanCover = false;

        /// <summary>
        /// 发送统计
        /// </summary>
        private UInt32 iSend = 0;
        /// <summary>
        /// 接收统计
        /// </summary>
        private UInt32 iReceive = 0;
        /// <summary>
        /// 单次接收字节数
        /// </summary>
        private UInt32 iRecieveByte = 0;

        /// <summary>
        /// 串口线程
        /// </summary>
        Thread thGetSerialPort = null;

        /// <summary>
        /// 加载本地设置
        /// </summary>
        private void InitSetting()
        {
            if(int.TryParse(iniFile.ReadValue("串口配置", "rate"),out int rate) && rate < cboxRate.Items.Count)
            {
                cboxRate.SelectedIndex = rate;
            }
            else
            {
                cboxRate.SelectedIndex = 9;
            }

            if (int.TryParse(iniFile.ReadValue("串口配置", "data"), out int data) && rate < cboxData.Items.Count)
            {
                cboxData.SelectedIndex = data;
            }
            else
            {
                cboxData.SelectedIndex = 2;
            }

            if (int.TryParse(iniFile.ReadValue("串口配置", "check"), out int check) && rate < cboxCheck.Items.Count)
            {
                cboxCheck.SelectedIndex = check;
            }
            else
            {
                cboxCheck.SelectedIndex = 0;
            }

            if (int.TryParse(iniFile.ReadValue("串口配置", "stop"), out int stop) && rate < cboxStop.Items.Count)
            {
                cboxStop.SelectedIndex = stop;
            }
            else
            {
                cboxStop.SelectedIndex = 0;
            }
            string recover = iniFile.ReadValue("串口配置", "recover").ToLower();
            if (recover == "true" || string.IsNullOrWhiteSpace(recover))
            {
                cboxRecover.Checked = true;
            }
            else
            {
                cboxRecover.Checked = false;
            }
            string showErr = iniFile.ReadValue("串口配置", "showErr").ToLower();
            if (showErr == "true" || string.IsNullOrWhiteSpace(showErr))
            {
                cboxShowErr.Checked = true;
            }
            else
            {
                cboxShowErr.Checked = false;
            }
            if (int.TryParse(iniFile.ReadValue("串口配置", "encoding"), out int encoding) && encoding < cboxEncoding.Items.Count)
            {
                cboxEncoding.SelectedIndex = encoding;
            }
            else
            {
                cboxEncoding.SelectedIndex = 0;
            }

            if (iniFile.ReadValue("辅助功能", "showHex").ToLower() == "true")
            {
                cboxShowHex.Checked = true;
            }
            if (iniFile.ReadValue("辅助功能", "autoShow").ToLower() == "true")
            {
                cboxServerAutoShow.Checked = true;
            }
            if (iniFile.ReadValue("辅助功能", "showSend").ToLower() == "true")
            {
                cboxShowSend.Checked = true;
            }
            if (iniFile.ReadValue("辅助功能", "newLine").ToLower() == "true")
            {
                cboxNewLine.Checked = true;
            }
            if (iniFile.ReadValue("发送功能", "sendHex").ToLower() == "true")
            {
                cboxSendHex.Checked = true;
            }
            if (iniFile.ReadValue("发送功能", "recieveSend").ToLower() == "true")
            {
                cboxRecieveSend.Checked = true;
            }
            string sSendTime = iniFile.ReadValue("发送功能", "sendTime");//定时发送时间
            if (int.TryParse(sSendTime, out int sendTime))
            {
                tboxTime.Text = sendTime.ToString();
            }
            string sCycleTime = iniFile.ReadValue("发送功能", "cycleTime");//循环发送时间
            if (int.TryParse(sCycleTime, out int cycleTime))
            {
                tboxCycleTime.Text = cycleTime.ToString();
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveSetting() 
        {
            iniFile.WriteValue("串口配置", "rate", cboxRate.SelectedIndex.ToString());
            iniFile.WriteValue("串口配置", "data", cboxData.SelectedIndex.ToString());
            iniFile.WriteValue("串口配置", "check", cboxCheck.SelectedIndex.ToString());
            iniFile.WriteValue("串口配置", "stop", cboxStop.SelectedIndex.ToString());
            iniFile.WriteValue("串口配置", "recover", cboxRecover.Checked.ToString().ToLower());
            iniFile.WriteValue("串口配置", "showErr", cboxShowErr.Checked.ToString().ToLower());
            iniFile.WriteValue("串口配置", "encoding", cboxEncoding.SelectedIndex.ToString());

            iniFile.WriteValue("辅助功能", "autoShow", cboxServerAutoShow.Checked.ToString().ToLower());
            iniFile.WriteValue("辅助功能", "showHex", cboxShowHex.Checked.ToString().ToLower());
            iniFile.WriteValue("辅助功能", "showSend", cboxShowSend.Checked.ToString().ToLower());
            iniFile.WriteValue("辅助功能", "newLine", cboxNewLine.Checked.ToString().ToLower());

            iniFile.WriteValue("发送功能", "sendHex", cboxSendHex.Checked.ToString().ToLower());
            iniFile.WriteValue("发送功能", "recieveSend", cboxRecieveSend.Checked.ToString().ToLower());
            iniFile.WriteValue("发送功能", "sendTime", tboxTime.Text);
            iniFile.WriteValue("发送功能", "cycleTime", tboxCycleTime.Text);//循环发送时间
        }

        /// <summary>
        /// 设置串口打开或关闭状态允许使用的控件功能
        /// </summary>
        /// <param name="bOpen"></param>
        private void SetOpenStus(bool bOpen)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (bOpen)//打开
                {
                    cboxPort.Enabled = false;
                    cboxRate.Enabled = false;
                    cboxData.Enabled = false;
                    cboxCheck.Enabled = false;
                    cboxStop.Enabled = false;
                    if(string.IsNullOrWhiteSpace(tboxSend.Text))
                    {
                        cboxRecieveSend.Enabled = false;
                        cboxTimeSend.Enabled = false;
                        btnSend.Enabled = false;
                    }
                    else
                    {
                        cboxRecieveSend.Enabled = true;
                        cboxTimeSend.Enabled = true;
                        btnSend.Enabled = !cboxTimeSend.Checked;
                    }
                    btnOpen.Text = "关闭";
                    cboxCrycle.Enabled = true;

                }
                else
                {
                    cboxPort.Enabled = true;
                    cboxRate.Enabled = true;
                    cboxData.Enabled = true;
                    cboxCheck.Enabled = true;
                    cboxStop.Enabled = true;
                    cboxRecieveSend.Enabled = false;
                    cboxTimeSend.Enabled = false;
                    btnSend.Enabled = false;
                    btnOpen.Text = "打开";
                    cboxCrycle.Enabled = false;
                }
                SetButton(bOpen);//设置多项发送的按钮禁用启用
                tboxSendFile_TextChanged(null, null);
            }));
        }

        /// <summary>
        /// 获取本地可用串口
        /// </summary>
        private void GetSerialPort()
        {
            try
            {
                RegistryKey keyCom = Registry.LocalMachine.OpenSubKey(@"Hardware\DeviceMap\SerialComm");
                if (keyCom != null)
                {
                    bool bClose = false;
                    string[] sSubKeys = keyCom.GetValueNames();
                    List<string> lisUse = new List<string>();//可用的串口
                    foreach (string sName in sSubKeys)
                    {
                        string sValue = (string)keyCom.GetValue(sName);
                        lisUse.Add(sValue);
                        if (!lisPortName.Contains(sValue))//不存在的串口需要添加
                        {
                            lisPortName.Add(sValue);
                            this.Invoke(new EventHandler(delegate
                            {
                                cboxPort.Items.Add(sValue);
                            }));
                        }
                    }
                    var lisRemove = lisPortName.Where(x=> !lisUse.Contains(x)).Select(x => x);//不可用的串口
                    List<string> lisDelete  = new List<string>();
                    foreach(string str in lisRemove)
                    {
                        lisDelete.Add($"{str}");
                    }
                    foreach(string str in lisDelete)
                    {
                        if(str == spPort.PortName)//连接已断开
                        {
                            bClose = true;
                            spPort.Close();
                            SetOpenStus(false);
                        }
                        lisPortName.Remove(str);
                        this.Invoke(new EventHandler(delegate
                        {
                            cboxPort.Items.Remove(str);
                        }));
                    }
                    if(bClose && !cboxShowErr.Checked)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            MessageBox.Show($"串口{spPort.PortName}已断开！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
                else
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        cboxPort.Items.Clear();
                        SetOpenStus(false);
                    }));
                }
            }
            catch { }
        }


        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_SerialPort_Load(object sender, EventArgs e)
        {
            var lishex = spPort.Encoding.GetBytes(spPort.NewLine).Select(x=>x.ToString("X2"));
            sNewLineHex = string.Join(" ", lishex);
            thGetSerialPort = new Thread(() =>
            {
                while(!this.IsDisposed)
                {
                    try
                    {
                        GetSerialPort();//实时获取可用串口
                    }
                    catch { }
                    //实现自动重连
                    try
                    {
                        if(cboxRecover.Checked && bCanCover && !spPort.IsOpen)
                        {
                            if (lisPortName.Contains(spPort.PortName))
                            {
                                this.Invoke(new EventHandler(delegate {
                                    cboxPort.SelectedItem = spPort.PortName;
                                }));
                                spPort.Open();
                                SetOpenStus(spPort.IsOpen);
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(300);
                }
            });
            thGetSerialPort.Start();
            InitSetting();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_SerialPort_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thGetSerialPort != null)
            {
                thGetSerialPort.Abort();
            }
            SaveSetting();
        }

        /// <summary>
        /// 打开/关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            string com = cboxPort.Text;//端口
            int rate = Convert.ToInt32(cboxRate.Text);//波特率
            Parity parity = Parity.None;//校验位
            switch(cboxCheck.SelectedIndex)
            {
                case 1:parity = Parity.Odd;break;
                case 2:parity = Parity.Even;break;
                default: parity = Parity.None;break;
            }
            int data = Convert.ToInt32(cboxData.Text);//数据位
            StopBits stop = StopBits.One;//停止位
            if(cboxStop.SelectedIndex == 1)
            {
                stop = StopBits.Two;
            }
            Encoding encoding = Encoding.Default;
            if (cboxEncoding.SelectedIndex > 0)
            {
                encoding = Encoding.GetEncoding(cboxEncoding.Text);
            }
            if (spPort != null)
            {
                spPort.DataReceived -= new SerialDataReceivedEventHandler(SerialPort_Recieve);
                spPort.Close();
                spPort.Dispose();
            }
            if (btnOpen.Text == "打开")
            {
                if (cboxPort.Items.Count == 0)
                {
                    MessageBox.Show("无可用设备串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboxPort.SelectedIndex <= -1)
                {
                    MessageBox.Show("请先选择需要打开的串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Action action = delegate
                {
                    try
                    {
                        spPort = new SerialPort(com, rate, parity, data, stop);
                        spPort.RtsEnable = true;
                        spPort.DtrEnable = true;
                        spPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_Recieve);
                        spPort.Encoding = encoding;//设置编码
                        spPort.Open();
                        isOpen = true;
                        bCanCover = true;
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            MessageBox.Show(ex.Message, "打开串口出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                };
                action.BeginInvoke(callbock, null);

                void callbock(IAsyncResult asyncResult)
                {
                    SetOpenStus(isOpen);
                }
            }
            else
            {
                bCanCover = false;
                SetOpenStus(isOpen);
            }
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="bSend"></param>
        /// <param name="sMsg"></param>
        private void ShowMsg(bool bSend, string sMsg)
        {
            lock(this)
            {
                if (tboxRecieve.Text.Length >= MaxRecieve)
                {
                    tboxRecieve.Text = string.Empty;
                }
                int start = tboxRecieve.SelectionStart;
                int lenth = tboxRecieve.SelectionLength;
                Color c = Color.Yellow;
                if (bSend)
                {
                    if(cboxShowSend.Checked)
                    {
                        c = Color.White;
                        tboxRecieve.SelectionColor = c;
                        tboxRecieve.AppendText(sMsg);
                    }
                }
                else
                {
                    tboxRecieve.SelectionColor = c;
                    tboxRecieve.AppendText(sMsg);
                }
                if (!cboxServerAutoShow.Checked)
                {
                    tboxRecieve.SelectionStart = start;
                    tboxRecieve.SelectionLength = lenth;
                }
                string msg = string.Format("接收区：共接收{0}字节，速度{1}字节/次    共发送{2}字节", iReceive, iRecieveByte, iSend);
                groupBox2.Text = msg;
                iRecieveByte = 0;
            }
        }

        /// <summary>
        /// 字节转对应十六进制字符串
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        private string ByteToString(byte[] buff)
        {
            if(buff == null || buff.Length == 0)
            {
                return "";
            }
            var lisHex = buff.Select(x => x.ToString("X2"));
            return string.Join(" ", lisHex);
        }

        /// <summary>
        /// 字符串转对应字节
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private byte[] StringToBytes(string str)
        {
            string[] strs = str.Trim().Replace("\r"," 0D ").Replace("\n"," " + sNewLineHex + " ").Split(' ');
            var strHex = strs.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToList();
            byte[] bytes = new byte[strHex.Count];
            for(int i=0;i< strHex.Count;i++)
            {
                try
                {
                    bytes[i] = Convert.ToByte(strHex[i].Trim(), 16);//字符串转字节
                }
                catch { }
            }
            return bytes;
        }

        /// <summary>
        /// 串口接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort_Recieve(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int size = spPort.BytesToRead;
                byte[] buff = new byte[size];
                iRecieveByte = (UInt32)spPort.Read(buff, 0, size);
                iReceive = iReceive + iRecieveByte;
                if (iRecieveByte > 0)
                {
                    bool bWriteFile = false;
                    string sFile = "";//保存到文件
                    bool showHex = false;//十六进制显示
                    string strMsg = "";
                    bool bRecieveSend = false;//接收回发
                    string strSend = "";
                    Action action = delegate
                    {
                        try
                        {
                            this.Invoke(new EventHandler(delegate
                            {
                                bWriteFile = cboxRecieveFile.Checked;
                                sFile = tboxRecieveFile.Text;
                                showHex = cboxShowHex.Checked;
                                bRecieveSend = cboxRecieveSend.Checked;
                                strSend = tboxSend.Text;
                            }));
                        }
                        catch { }
                    };
                    action.BeginInvoke(callback, null);
                    void callback(IAsyncResult async)
                    {
                        if(showHex)
                        {
                            strMsg = ByteToString(buff) + spPort.NewLine;//十六进制显示
                        }
                        else
                        {
                            strMsg = spPort.Encoding.GetString(buff);//字符显示
                        }
                        this.Invoke(new EventHandler(delegate
                        {
                            //string showMsg = strMsg.Replace(sNewLineHex, spPort.NewLine);
                            ShowMsg(false, strMsg);//显示接收的消息
                        }));
                        if(bRecieveSend && !string.IsNullOrWhiteSpace(strSend))
                        {
                            SendMsg(strSend, cboxSendHex.Checked);
                        }
                        if (bWriteFile && !string.IsNullOrWhiteSpace(sFile))//写入文件
                        {
                            using (StreamWriter sw = new StreamWriter(sFile, true))
                            {
                                sw.Write(strMsg);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 串口发送
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="bHex"></param>
        private void SendMsg(string strMsg, bool bHex)
        {
            try
            {
                if (spPort.IsOpen)
                {
                    //十六进制发送
                    if (bHex)
                    {
                        if (cboxNewLine.Checked)
                        {
                            strMsg = strMsg.Trim() + " " +  sNewLineHex;
                        }
                        byte[] buff = StringToBytes(strMsg);
                        spPort.Write(buff, 0, buff.Length);
                        iSend = (UInt32)(iSend + buff.Length);//统计发送
                        strMsg = ByteToString(buff) + spPort.NewLine;
                    }
                    //字符串发送
                    else
                    {
                        if (cboxNewLine.Checked)
                        {
                            strMsg += spPort.NewLine;
                        }
                        byte[] buff = spPort.Encoding.GetBytes(strMsg);
                        spPort.Write(buff, 0, buff.Length);
                        iSend = (UInt32)(iSend + buff.Length);//统计发送
                    }
                    this.Invoke(new EventHandler(delegate
                    {
                        ShowMsg(true, strMsg);
                    }));
                }
                else
                {
                    SetOpenStus(false);
                }
            }
            catch (Exception ex)
            {

            }
        }



        #region 单项发送

        /// <summary>
        /// 定时时间输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxTime_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar < 32 || Char.IsDigit(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 清空发送区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSend_Click(object sender, EventArgs e)
        {
            tboxSend.Text = string.Empty;
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string strMsg = tboxSend.Text;
            if (string.IsNullOrWhiteSpace(strMsg))
            {
                MessageBox.Show("发送内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(!spPort.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SendMsg(strMsg, cboxSendHex.Checked);
            if(cboxSendClear.Checked)
            {
                tboxSend.Text = string.Empty;
            }
        }

        /// <summary>
        /// 定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxTimeSend_CheckedChanged(object sender, EventArgs e)
        {
            cboxTimeSend.CheckedChanged -= new EventHandler(cboxTimeSend_CheckedChanged);
            if(int.TryParse(tboxTime.Text,out int time))
            {
                timer1.Interval = time;
                timer1.Enabled = cboxTimeSend.Checked;
                tboxTime.Enabled = !cboxTimeSend.Checked;
                if(!cboxRecieveSend.Checked)
                {
                    cboxSendClear.Enabled = !cboxTimeSend.Checked;
                }
                btnSend.Enabled = !cboxTimeSend.Checked;
                if (cboxTimeSend.Checked)
                {
                    cboxSendClear.Checked = false;
                }
            }
            else
            {
                btnSend.Enabled = true;
                MessageBox.Show("请输入有效的定时时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxTime.Focus();
                cboxTimeSend.Checked = false;
                timer1.Enabled = false;
            }
            cboxTimeSend.CheckedChanged += new EventHandler(cboxTimeSend_CheckedChanged);
        }

        /// <summary>
        /// 定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            string strMsg = tboxSend.Text;
            if (cboxTimeSend.Enabled)
            {
                SendMsg(strMsg, cboxSendHex.Checked);
            }
        }

        #endregion

        #region 多项发送

        /// <summary>
        /// 多项发送按钮功能禁用启用
        /// </summary>
        /// <param name="bOpen"></param>
        private void SetButton(bool bOpen)
        {
            if(bOpen)
            {
                if(!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    button3.Enabled = true;
                }
                else
                {
                    button3.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    button4.Enabled = true;
                }
                else
                {
                    button4.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    button5.Enabled = true;
                }
                else
                {
                    button5.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    button6.Enabled = true;
                }
                else
                {
                    button6.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    button7.Enabled = true;
                }
                else
                {
                    button7.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox8.Text))
                {
                    button8.Enabled = true;
                }
                else
                {
                    button8.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    button9.Enabled = true;
                }
                else
                {
                    button9.Enabled = false;
                }
                if (!string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    button10.Enabled = true;
                }
                else
                {
                    button10.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
            }
        }

        /// <summary>
        /// 多项发送十六进制发送勾选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxHex_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string name = check.Name;
            switch(name)
            {
                case "checkBox1": 
                    {
                        if (checkBox1.Checked)
                        {
                            tboxManySend_TextChanged(textBox1, e);
                            textBox1.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox1.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    }
                    break;
                case "checkBox2":
                    {
                        if (checkBox2.Checked)
                        {
                            tboxManySend_TextChanged(textBox2, e);
                            textBox2.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox2.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox3":
                    {
                        if (checkBox3.Checked)
                        {
                            tboxManySend_TextChanged(textBox3, e);
                            textBox3.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox3.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox4":
                    {
                        if (checkBox4.Checked)
                        {
                            tboxManySend_TextChanged(textBox4, e);
                            textBox4.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox4.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox5":
                    {
                        if (checkBox5.Checked)
                        {
                            tboxManySend_TextChanged(textBox5, e);
                            textBox5.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox5.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox6":
                    {
                        if (checkBox6.Checked)
                        {
                            tboxManySend_TextChanged(textBox6, e);
                            textBox6.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox6.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox7":
                    {
                        if (checkBox7.Checked)
                        {
                            tboxManySend_TextChanged(textBox7, e);
                            textBox7.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox7.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox8":
                    {
                        if (checkBox8.Checked)
                        {
                            tboxManySend_TextChanged(textBox8, e);
                            textBox8.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox8.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox9":
                    {
                        if (checkBox9.Checked)
                        {
                            tboxManySend_TextChanged(textBox9, e);
                            textBox9.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox9.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
                case "checkBox10":
                    {
                        if (checkBox10.Checked)
                        {
                            tboxManySend_TextChanged(textBox10, e);
                            textBox10.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                        else
                        {
                            textBox10.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
                        }
                    } break;
            }
        }

        /// <summary>
        /// 设置输入事件
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="check"></param>
        /// <param name="btn"></param>
        private void textChange(TextBox textBox, CheckBox check,Button btn)
        {
            if (spPort.IsOpen)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    btn.Enabled = false;
                }
                else
                {
                    btn.Enabled = true;
                }
            }
            else
            {
                btn.Enabled = false;
            }
            if (check.Checked && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                int index = textBox.SelectionStart;
                string strSpace = textBox.Text.Substring(textBox.Text.Length - 1, 1);
                string strHex = textBox.Text.Trim();
                Regex regex = new Regex(@"([^A-Fa-f0-9\s]+?)+");
                MatchCollection matchs = regex.Matches(strHex);
                foreach (var v in matchs)
                {
                    strHex = strHex.Replace(v.ToString(), " ");
                }
                var strs = strHex.Split(' ').Select(x => x.Trim());
                List<string> lisResult = new List<string>();
                foreach (string s in strs)
                {
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        continue;
                    }
                    if (s.Length > 2)
                    {
                        List<string> lis = new List<string>();
                        string val = s;
                        while (val != "")
                        {
                            string sHex = val.Substring(0, val.Length > 1 ? 2 : 1);
                            lis.Add(sHex);
                            if (val.Length > 2)
                            {
                                val = val.Substring(2, val.Length - 2);
                            }
                            else
                            {
                                val = "";
                            }
                        }
                        lisResult.Add(string.Join(" ", lis));
                    }
                    else
                    {
                        lisResult.Add(s);
                    }
                }
                textBox.Text = string.Join(" ", lisResult) + (strSpace == " " ? " " : "");
                if (index <= textBox.Text.Length)
                {
                    textBox.SelectionStart = index;
                }
                else
                {
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        /// <summary>
        /// 多项发送文本输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxManySend_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string name = textBox.Name;
            switch (name)
            {
                case "textBox1": textChange(textBox, checkBox1, button1); break;
                case "textBox2": textChange(textBox, checkBox2, button2); break;
                case "textBox3": textChange(textBox, checkBox3, button3); break;
                case "textBox4": textChange(textBox, checkBox4, button4); break;
                case "textBox5": textChange(textBox, checkBox5, button5); break;
                case "textBox6": textChange(textBox, checkBox6, button6); break;
                case "textBox7": textChange(textBox, checkBox7, button7); break;
                case "textBox8": textChange(textBox, checkBox8, button8); break;
                case "textBox9": textChange(textBox, checkBox9, button9); break;
                case "textBox10": textChange(textBox, checkBox10, button10); break;
            }
        }

        /// <summary>
        /// 多项发送按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            string strMsg = "";
            bool bHex = false;
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "button1": {
                        strMsg = textBox1.Text;
                        bHex = checkBox1.Checked;
                    } break;
                case "button2":
                    {
                        strMsg = textBox2.Text;
                        bHex = checkBox2.Checked;
                    } break;
                case "button3":
                    {
                        strMsg = textBox3.Text;
                        bHex = checkBox3.Checked;
                    } break;
                case "button4":
                    {
                        strMsg = textBox4.Text;
                        bHex = checkBox4.Checked;
                    } break;
                case "button5":
                    {
                        strMsg = textBox5.Text;
                        bHex = checkBox5.Checked;
                    } break;
                case "button6":
                    {
                        strMsg = textBox6.Text;
                        bHex = checkBox6.Checked;
                    } break;
                case "button7":
                    {
                        strMsg = textBox7.Text;
                        bHex = checkBox7.Checked;
                    } break;
                case "button8":
                    {
                        strMsg = textBox8.Text;
                        bHex = checkBox8.Checked;
                    } break;
                case "button9":
                    {
                        strMsg = textBox9.Text;
                        bHex = checkBox9.Checked;
                    } break;
                case "button10":
                    {
                        strMsg = textBox10.Text;
                        bHex = checkBox10.Checked;
                    } break;
            }
            if (string.IsNullOrWhiteSpace(strMsg))
            {
                MessageBox.Show("发送内容不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!spPort.IsOpen)
            {
                MessageBox.Show("请先打开串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SendMsg(strMsg, bHex);
        }

        #endregion

        #region 发送文件

        #endregion

        /// <summary>
        /// 清空接收区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearRecieve_Click(object sender, EventArgs e)
        {
            tboxRecieve.Text = string.Empty;
        }

        /// <summary>
        /// 清空统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCnt_Click(object sender, EventArgs e)
        {
            iSend = 0;
            iReceive= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSend_TextChanged(object sender, EventArgs e)
        {
            if(spPort.IsOpen)
            {
                if (string.IsNullOrWhiteSpace(tboxSend.Text))
                {
                    cboxTimeSend.Checked = false;
                    cboxTimeSend.Enabled = false;
                    cboxRecieveSend.Checked = false;
                    cboxRecieveSend.Enabled = false;
                    btnSend.Enabled = false;
                }
                else
                {
                    cboxTimeSend.Enabled = true;
                    cboxRecieveSend.Enabled = true;
                    btnSend.Enabled = !cboxTimeSend.Checked;
                }
            }
            else
            {
                cboxTimeSend.Checked = false;
                cboxTimeSend.Enabled = false;
                cboxRecieveSend.Checked = false;
                cboxRecieveSend.Enabled = false;
                btnSend.Enabled = false;
            }
            if(cboxSendHex.Checked && !string.IsNullOrWhiteSpace(tboxSend.Text))
            {
                int index = tboxSend.SelectionStart;
                string strSpace = tboxSend.Text.Substring(tboxSend.Text.Length - 1,1);
                string strHex = tboxSend.Text.Trim();
                Regex regex = new Regex(@"([^A-Fa-f0-9\s]+?)+");
                MatchCollection matchs = regex.Matches(strHex);
                foreach (var v in matchs)
                {
                    strHex = strHex.Replace(v.ToString()," ");
                }
                var strs = strHex.Split(' ').Select(x=>x.Trim());
                List<string> lisResult = new List<string>();
                foreach(string s in strs)
                {
                    if(string.IsNullOrWhiteSpace(s))
                    {
                        continue;
                    }
                    if(s.Length > 2)
                    {
                        List<string> lis = new List<string>();
                        string val = s;
                        while(val != "")
                        {
                            string sHex = val.Substring(0, val.Length > 1? 2 : 1);
                            lis.Add(sHex);
                            if(val.Length > 2)
                            {
                                val = val.Substring(2, val.Length - 2);
                            }
                            else
                            {
                                val = "";
                            }
                        }
                        lisResult.Add(string.Join(" ", lis));
                    }
                    else
                    {
                        lisResult.Add(s);
                    }
                }
                tboxSend.Text = string.Join(" ", lisResult) + (strSpace == " " ? " ":"");
                if(index <= tboxSend.Text.Length)
                {
                    tboxSend.SelectionStart = index;
                }
                else
                {
                    tboxSend.SelectionStart = tboxSend.Text.Length;
                }
            }
        }

        /// <summary>
        /// 接收到文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxRecieveFile_CheckedChanged(object sender, EventArgs e)
        {
            cboxRecieveFile.CheckedChanged -= new EventHandler(cboxRecieveFile_CheckedChanged);
            if (cboxRecieveFile.Checked && string.IsNullOrWhiteSpace(tboxRecieveFile.Text))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Multiselect = false;
                ofd.Filter = "文本文件|*.txt";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    tboxRecieveFile.Text = ofd.FileName;
                }
                else
                {
                    cboxRecieveFile.Checked = false;
                }
            }
            cboxRecieveFile.CheckedChanged += new EventHandler(cboxRecieveFile_CheckedChanged);
        }

        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxRecieveFile_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "文本文件|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tboxRecieveFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 编码选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Encoding encoding = Encoding.Default;
            if (cboxEncoding.SelectedIndex > 0)
            {
                encoding = Encoding.GetEncoding(cboxEncoding.Text);
            }
            spPort.Encoding = encoding;
            var lishex = spPort.Encoding.GetBytes(spPort.NewLine).Select(x => x.ToString("X2"));
            sNewLineHex = string.Join(" ", lishex);
        }
        /// <summary>
        /// 显示最新行消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerShowMsgNew(object sender, EventArgs e)
        {
            tboxRecieve.SelectionStart = tboxRecieve.Text.Length;
            tboxRecieve.ScrollToCaret();
        }

        /// <summary>
        /// 自动显示最新行消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxServerAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxServerAutoShow.Checked)
            {
                ServerShowMsgNew(sender, e);
                tboxRecieve.TextChanged += new EventHandler(ServerShowMsgNew);
            }
            else
            {
                tboxRecieve.TextChanged -= new EventHandler(ServerShowMsgNew);
            }
        }

        /// <summary>
        /// 接收回发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxRecieveSend_CheckedChanged(object sender, EventArgs e)
        {
            cboxRecieveSend.CheckedChanged -= new EventHandler(cboxRecieveSend_CheckedChanged);
            if (string.IsNullOrWhiteSpace(tboxSend.Text))
            {
                cboxRecieveSend.Checked = false;
            }
            if (!cboxTimeSend.Checked)
            {
                cboxSendClear.Enabled = !cboxRecieveSend.Checked;
            }
            if (cboxRecieveSend.Checked)
            {
                cboxSendClear.Checked = false;
            }
            cboxRecieveSend.CheckedChanged += new EventHandler(cboxRecieveSend_CheckedChanged);
        }

        /// <summary>
        /// 发送内容输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] input = new char[] { ' ','0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','A','B','C','D','E','F'};
            if (e.KeyChar < 32 || input.Contains(e.KeyChar))
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 十六进制发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxSendHex_CheckedChanged(object sender, EventArgs e)
        {
            if(cboxSendHex.Checked)
            {
                tboxSend_TextChanged(sender, e);
                tboxSend.KeyPress += new KeyPressEventHandler(tboxSend_KeyPress);
            }
            else
            {
                tboxSend.KeyPress -= new KeyPressEventHandler(tboxSend_KeyPress);
            }
        }

        /// <summary>
        /// 循环发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxCrycle_CheckedChanged(object sender, EventArgs e)
        {
            cboxCrycle.CheckedChanged -= new EventHandler(cboxCrycle_CheckedChanged);
            if (int.TryParse(tboxCycleTime.Text, out int time))
            {
                timer2.Interval = time;
                timer2.Enabled = cboxCrycle.Checked;
                tboxCycleTime.Enabled = !cboxCrycle.Checked;
            }
            else
            {
                MessageBox.Show("请输入有效的定时时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tboxCycleTime.Focus();
                cboxCrycle.Checked = false;
                timer2.Enabled = false;
            }
            cboxCrycle.CheckedChanged += new EventHandler(cboxCrycle_CheckedChanged);
        }

        /// <summary>
        /// 循环发送标志
        /// </summary>
        private int iIndex = 0;

        /// <summary>
        /// 循环
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            List<Button> btns = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
            while(true)
            {
                if (btns[iIndex].Enabled)
                {
                    btn_Click(btns[iIndex], e);
                    iIndex += 1;
                    if (iIndex >= btns.Count)
                    {
                        iIndex = 0;
                    }
                    break;
                }
                iIndex += 1;
                if(iIndex >= btns.Count)
                {
                    iIndex = 0;
                    break;
                }
            }
        }

        /// <summary>
        /// 双击选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSendFile_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "文本文件|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tboxSendFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 发送文件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string sFile = tboxSendFile.Text;
            if (!File.Exists(sFile))
            {
                MessageBox.Show(sFile + "\n文件不存在！", "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (StreamReader sr = new StreamReader(sFile))
            {
                string strMsg = sr.ReadToEnd();
                if (string.IsNullOrWhiteSpace(strMsg))
                {
                    MessageBox.Show("文件内容为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!spPort.IsOpen)
                {
                    MessageBox.Show("请先打开串口！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SendMsg(strMsg, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxSendFile_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tboxSendFile.Text))
            {
                btnOpenFile.Enabled = false;
                btnSendFile.Enabled = false;
            }
            else
            {
                btnOpenFile.Enabled = true;
                if(spPort.IsOpen)
                {
                    btnSendFile.Enabled = true;
                }
                else
                {
                    btnSendFile.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string sFile = tboxSendFile.Text;
            if (!File.Exists(sFile))
            {
                MessageBox.Show(sFile + "\n文件不存在！", "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                System.Diagnostics.Process.Start(sFile);
            }
            catch { }
        }
    }
}
