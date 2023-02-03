namespace Assistant
{
    partial class Frm_NetWork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxServerTime = new System.Windows.Forms.TextBox();
            this.cboxServerTime = new System.Windows.Forms.CheckBox();
            this.btnServerSend = new System.Windows.Forms.Button();
            this.cboxConnectClient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxServerSend = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtBoxServerRecieve = new System.Windows.Forms.RichTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupbox4 = new System.Windows.Forms.GroupBox();
            this.cboxShowOnlyServer = new System.Windows.Forms.CheckBox();
            this.cboxServerAutoShow = new System.Windows.Forms.CheckBox();
            this.btnClearServerSend = new System.Windows.Forms.Button();
            this.btnClearServerRecieve = new System.Windows.Forms.Button();
            this.chboxServerSendClear = new System.Windows.Forms.CheckBox();
            this.chboxServerSendHex = new System.Windows.Forms.CheckBox();
            this.chboxServerRecieveHex = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbServerUDP = new System.Windows.Forms.RadioButton();
            this.rbServerTCP = new System.Windows.Forms.RadioButton();
            this.chboxIPV6 = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCreateServer = new System.Windows.Forms.Button();
            this.tboxServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxIp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxClientTime = new System.Windows.Forms.TextBox();
            this.cboxClientTime = new System.Windows.Forms.CheckBox();
            this.btnClientSend = new System.Windows.Forms.Button();
            this.tboxClientSend = new System.Windows.Forms.TextBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtBoxClientRecieve = new System.Windows.Forms.RichTextBox();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cboxShowOnlyClient = new System.Windows.Forms.CheckBox();
            this.cboxClientAutoShow = new System.Windows.Forms.CheckBox();
            this.cboxConectMsg = new System.Windows.Forms.CheckBox();
            this.btnClearClientSend = new System.Windows.Forms.Button();
            this.btnClearClientRecieve = new System.Windows.Forms.Button();
            this.chboxClientSendClear = new System.Windows.Forms.CheckBox();
            this.chboxClientSendHex = new System.Windows.Forms.CheckBox();
            this.chboxClientRecieveHex = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cboxClientIP = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbClientUDP = new System.Windows.Forms.RadioButton();
            this.rbClientTCP = new System.Windows.Forms.RadioButton();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tboxClientPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupbox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 546);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.splitter2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(955, 517);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "服务器";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tboxServerTime);
            this.groupBox3.Controls.Add(this.cboxServerTime);
            this.groupBox3.Controls.Add(this.btnServerSend);
            this.groupBox3.Controls.Add(this.cboxConnectClient);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tboxServerSend);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.Lime;
            this.groupBox3.Location = new System.Drawing.Point(212, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(740, 191);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(576, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "ms";
            // 
            // tboxServerTime
            // 
            this.tboxServerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxServerTime.Location = new System.Drawing.Point(479, 158);
            this.tboxServerTime.MaxLength = 8;
            this.tboxServerTime.Name = "tboxServerTime";
            this.tboxServerTime.ShortcutsEnabled = false;
            this.tboxServerTime.Size = new System.Drawing.Size(91, 24);
            this.tboxServerTime.TabIndex = 7;
            this.tboxServerTime.Text = "100";
            this.tboxServerTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxPort_KeyPress);
            // 
            // cboxServerTime
            // 
            this.cboxServerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxServerTime.AutoSize = true;
            this.cboxServerTime.Enabled = false;
            this.cboxServerTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxServerTime.Location = new System.Drawing.Point(387, 161);
            this.cboxServerTime.Name = "cboxServerTime";
            this.cboxServerTime.Size = new System.Drawing.Size(86, 19);
            this.cboxServerTime.TabIndex = 6;
            this.cboxServerTime.Text = "定时发送";
            this.cboxServerTime.UseVisualStyleBackColor = true;
            this.cboxServerTime.CheckedChanged += new System.EventHandler(this.cboxServerTime_CheckedChanged);
            // 
            // btnServerSend
            // 
            this.btnServerSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServerSend.Enabled = false;
            this.btnServerSend.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnServerSend.Location = new System.Drawing.Point(605, 152);
            this.btnServerSend.Name = "btnServerSend";
            this.btnServerSend.Size = new System.Drawing.Size(130, 36);
            this.btnServerSend.TabIndex = 5;
            this.btnServerSend.Text = "发送";
            this.btnServerSend.UseVisualStyleBackColor = true;
            this.btnServerSend.Click += new System.EventHandler(this.btnServerSend_Click);
            // 
            // cboxConnectClient
            // 
            this.cboxConnectClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxConnectClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxConnectClient.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxConnectClient.FormattingEnabled = true;
            this.cboxConnectClient.Items.AddRange(new object[] {
            "全部"});
            this.cboxConnectClient.Location = new System.Drawing.Point(118, 159);
            this.cboxConnectClient.Name = "cboxConnectClient";
            this.cboxConnectClient.Size = new System.Drawing.Size(196, 23);
            this.cboxConnectClient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(6, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "已连接客户端：";
            // 
            // tboxServerSend
            // 
            this.tboxServerSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxServerSend.Location = new System.Drawing.Point(6, 21);
            this.tboxServerSend.Multiline = true;
            this.tboxServerSend.Name = "tboxServerSend";
            this.tboxServerSend.Size = new System.Drawing.Size(728, 125);
            this.tboxServerSend.TabIndex = 0;
            this.tboxServerSend.TextChanged += new System.EventHandler(this.tboxServerSend_TextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(212, 318);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(740, 5);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtBoxServerRecieve);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(212, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 315);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收区";
            // 
            // rtBoxServerRecieve
            // 
            this.rtBoxServerRecieve.AcceptsTab = true;
            this.rtBoxServerRecieve.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtBoxServerRecieve.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtBoxServerRecieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtBoxServerRecieve.Location = new System.Drawing.Point(3, 20);
            this.rtBoxServerRecieve.Name = "rtBoxServerRecieve";
            this.rtBoxServerRecieve.ReadOnly = true;
            this.rtBoxServerRecieve.Size = new System.Drawing.Size(734, 292);
            this.rtBoxServerRecieve.TabIndex = 3;
            this.rtBoxServerRecieve.Text = "";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(207, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 511);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupbox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 511);
            this.panel1.TabIndex = 2;
            // 
            // groupbox4
            // 
            this.groupbox4.Controls.Add(this.cboxShowOnlyServer);
            this.groupbox4.Controls.Add(this.cboxServerAutoShow);
            this.groupbox4.Controls.Add(this.btnClearServerSend);
            this.groupbox4.Controls.Add(this.btnClearServerRecieve);
            this.groupbox4.Controls.Add(this.chboxServerSendClear);
            this.groupbox4.Controls.Add(this.chboxServerSendHex);
            this.groupbox4.Controls.Add(this.chboxServerRecieveHex);
            this.groupbox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupbox4.Location = new System.Drawing.Point(0, 217);
            this.groupbox4.Name = "groupbox4";
            this.groupbox4.Size = new System.Drawing.Size(204, 294);
            this.groupbox4.TabIndex = 9;
            this.groupbox4.TabStop = false;
            this.groupbox4.Text = "辅助功能";
            // 
            // cboxShowOnlyServer
            // 
            this.cboxShowOnlyServer.AutoSize = true;
            this.cboxShowOnlyServer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxShowOnlyServer.Location = new System.Drawing.Point(9, 146);
            this.cboxShowOnlyServer.Name = "cboxShowOnlyServer";
            this.cboxShowOnlyServer.Size = new System.Drawing.Size(131, 19);
            this.cboxShowOnlyServer.TabIndex = 19;
            this.cboxShowOnlyServer.Text = "仅显示接收信息";
            this.cboxShowOnlyServer.UseVisualStyleBackColor = true;
            // 
            // cboxServerAutoShow
            // 
            this.cboxServerAutoShow.AutoSize = true;
            this.cboxServerAutoShow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxServerAutoShow.Location = new System.Drawing.Point(9, 116);
            this.cboxServerAutoShow.Name = "cboxServerAutoShow";
            this.cboxServerAutoShow.Size = new System.Drawing.Size(146, 19);
            this.cboxServerAutoShow.TabIndex = 16;
            this.cboxServerAutoShow.Text = "自动显示最新消息";
            this.cboxServerAutoShow.UseVisualStyleBackColor = true;
            this.cboxServerAutoShow.CheckedChanged += new System.EventHandler(this.cboxAutoShow_CheckedChanged);
            // 
            // btnClearServerSend
            // 
            this.btnClearServerSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearServerSend.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClearServerSend.Location = new System.Drawing.Point(9, 224);
            this.btnClearServerSend.Name = "btnClearServerSend";
            this.btnClearServerSend.Size = new System.Drawing.Size(189, 39);
            this.btnClearServerSend.TabIndex = 15;
            this.btnClearServerSend.Text = "清空发送区";
            this.btnClearServerSend.UseVisualStyleBackColor = true;
            this.btnClearServerSend.Click += new System.EventHandler(this.btnClearServerSend_Click);
            // 
            // btnClearServerRecieve
            // 
            this.btnClearServerRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearServerRecieve.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClearServerRecieve.Location = new System.Drawing.Point(9, 179);
            this.btnClearServerRecieve.Name = "btnClearServerRecieve";
            this.btnClearServerRecieve.Size = new System.Drawing.Size(189, 39);
            this.btnClearServerRecieve.TabIndex = 14;
            this.btnClearServerRecieve.Text = "清空接收区";
            this.btnClearServerRecieve.UseVisualStyleBackColor = true;
            this.btnClearServerRecieve.Click += new System.EventHandler(this.btnClearServerRecieve_Click);
            // 
            // chboxServerSendClear
            // 
            this.chboxServerSendClear.AutoSize = true;
            this.chboxServerSendClear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxServerSendClear.Location = new System.Drawing.Point(9, 86);
            this.chboxServerSendClear.Name = "chboxServerSendClear";
            this.chboxServerSendClear.Size = new System.Drawing.Size(131, 19);
            this.chboxServerSendClear.TabIndex = 13;
            this.chboxServerSendClear.Text = "发送后自动清空";
            this.chboxServerSendClear.UseVisualStyleBackColor = true;
            // 
            // chboxServerSendHex
            // 
            this.chboxServerSendHex.AutoSize = true;
            this.chboxServerSendHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxServerSendHex.Location = new System.Drawing.Point(9, 56);
            this.chboxServerSendHex.Name = "chboxServerSendHex";
            this.chboxServerSendHex.Size = new System.Drawing.Size(116, 19);
            this.chboxServerSendHex.TabIndex = 12;
            this.chboxServerSendHex.Text = "十六进制发送";
            this.chboxServerSendHex.UseVisualStyleBackColor = true;
            this.chboxServerSendHex.CheckedChanged += new System.EventHandler(this.chboxServerSendHex_CheckedChanged);
            // 
            // chboxServerRecieveHex
            // 
            this.chboxServerRecieveHex.AutoSize = true;
            this.chboxServerRecieveHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxServerRecieveHex.Location = new System.Drawing.Point(9, 26);
            this.chboxServerRecieveHex.Name = "chboxServerRecieveHex";
            this.chboxServerRecieveHex.Size = new System.Drawing.Size(116, 19);
            this.chboxServerRecieveHex.TabIndex = 11;
            this.chboxServerRecieveHex.Text = "十六进制显示";
            this.chboxServerRecieveHex.UseVisualStyleBackColor = true;
            this.chboxServerRecieveHex.CheckedChanged += new System.EventHandler(this.chboxServerRecieveHex_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbServerUDP);
            this.groupBox1.Controls.Add(this.rbServerTCP);
            this.groupBox1.Controls.Add(this.chboxIPV6);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnCreateServer);
            this.groupBox1.Controls.Add(this.tboxServerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxIp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 217);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器配置";
            // 
            // rbServerUDP
            // 
            this.rbServerUDP.AutoSize = true;
            this.rbServerUDP.Location = new System.Drawing.Point(69, 88);
            this.rbServerUDP.Name = "rbServerUDP";
            this.rbServerUDP.Size = new System.Drawing.Size(46, 18);
            this.rbServerUDP.TabIndex = 10;
            this.rbServerUDP.Text = "UDP";
            this.rbServerUDP.UseVisualStyleBackColor = true;
            // 
            // rbServerTCP
            // 
            this.rbServerTCP.AutoSize = true;
            this.rbServerTCP.Checked = true;
            this.rbServerTCP.Location = new System.Drawing.Point(9, 88);
            this.rbServerTCP.Name = "rbServerTCP";
            this.rbServerTCP.Size = new System.Drawing.Size(46, 18);
            this.rbServerTCP.TabIndex = 9;
            this.rbServerTCP.TabStop = true;
            this.rbServerTCP.Text = "TCP";
            this.rbServerTCP.UseVisualStyleBackColor = true;
            // 
            // chboxIPV6
            // 
            this.chboxIPV6.AutoSize = true;
            this.chboxIPV6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxIPV6.Location = new System.Drawing.Point(129, 88);
            this.chboxIPV6.Name = "chboxIPV6";
            this.chboxIPV6.Size = new System.Drawing.Size(54, 18);
            this.chboxIPV6.TabIndex = 5;
            this.chboxIPV6.Text = "IPV6";
            this.chboxIPV6.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnRefresh.Location = new System.Drawing.Point(9, 117);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(189, 39);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新本地IP";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCreateServer
            // 
            this.btnCreateServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateServer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCreateServer.Location = new System.Drawing.Point(9, 162);
            this.btnCreateServer.Name = "btnCreateServer";
            this.btnCreateServer.Size = new System.Drawing.Size(189, 39);
            this.btnCreateServer.TabIndex = 0;
            this.btnCreateServer.Text = "创建服务器";
            this.btnCreateServer.UseVisualStyleBackColor = true;
            this.btnCreateServer.Click += new System.EventHandler(this.btnCreateServer_Click);
            // 
            // tboxServerPort
            // 
            this.tboxServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxServerPort.Location = new System.Drawing.Point(66, 53);
            this.tboxServerPort.MaxLength = 5;
            this.tboxServerPort.Name = "tboxServerPort";
            this.tboxServerPort.ShortcutsEnabled = false;
            this.tboxServerPort.Size = new System.Drawing.Size(132, 23);
            this.tboxServerPort.TabIndex = 4;
            this.tboxServerPort.Text = "8080";
            this.tboxServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxPort_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // cboxIp
            // 
            this.cboxIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxIp.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxIp.FormattingEnabled = true;
            this.cboxIp.Location = new System.Drawing.Point(66, 22);
            this.cboxIp.Name = "cboxIp";
            this.cboxIp.Size = new System.Drawing.Size(132, 23);
            this.cboxIp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "本地IP：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.splitter3);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.splitter4);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(955, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "客户端";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tboxClientTime);
            this.groupBox5.Controls.Add(this.cboxClientTime);
            this.groupBox5.Controls.Add(this.btnClientSend);
            this.groupBox5.Controls.Add(this.tboxClientSend);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.ForeColor = System.Drawing.Color.Lime;
            this.groupBox5.Location = new System.Drawing.Point(212, 323);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(740, 191);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送区";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(576, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "ms";
            // 
            // tboxClientTime
            // 
            this.tboxClientTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxClientTime.Location = new System.Drawing.Point(479, 158);
            this.tboxClientTime.MaxLength = 8;
            this.tboxClientTime.Name = "tboxClientTime";
            this.tboxClientTime.ShortcutsEnabled = false;
            this.tboxClientTime.Size = new System.Drawing.Size(91, 24);
            this.tboxClientTime.TabIndex = 7;
            this.tboxClientTime.Text = "100";
            this.tboxClientTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxPort_KeyPress);
            // 
            // cboxClientTime
            // 
            this.cboxClientTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxClientTime.AutoSize = true;
            this.cboxClientTime.Enabled = false;
            this.cboxClientTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxClientTime.Location = new System.Drawing.Point(387, 161);
            this.cboxClientTime.Name = "cboxClientTime";
            this.cboxClientTime.Size = new System.Drawing.Size(86, 19);
            this.cboxClientTime.TabIndex = 6;
            this.cboxClientTime.Text = "定时发送";
            this.cboxClientTime.UseVisualStyleBackColor = true;
            this.cboxClientTime.CheckedChanged += new System.EventHandler(this.cboxClientTime_CheckedChanged);
            // 
            // btnClientSend
            // 
            this.btnClientSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientSend.Enabled = false;
            this.btnClientSend.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClientSend.Location = new System.Drawing.Point(605, 152);
            this.btnClientSend.Name = "btnClientSend";
            this.btnClientSend.Size = new System.Drawing.Size(130, 36);
            this.btnClientSend.TabIndex = 5;
            this.btnClientSend.Text = "发送";
            this.btnClientSend.UseVisualStyleBackColor = true;
            this.btnClientSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // tboxClientSend
            // 
            this.tboxClientSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxClientSend.Location = new System.Drawing.Point(6, 21);
            this.tboxClientSend.Multiline = true;
            this.tboxClientSend.Name = "tboxClientSend";
            this.tboxClientSend.Size = new System.Drawing.Size(728, 125);
            this.tboxClientSend.TabIndex = 0;
            this.tboxClientSend.TextChanged += new System.EventHandler(this.tboxClientSend_TextChanged);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(212, 318);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(740, 5);
            this.splitter3.TabIndex = 15;
            this.splitter3.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtBoxClientRecieve);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.ForeColor = System.Drawing.Color.Red;
            this.groupBox6.Location = new System.Drawing.Point(212, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(740, 315);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "接收区";
            // 
            // rtBoxClientRecieve
            // 
            this.rtBoxClientRecieve.AcceptsTab = true;
            this.rtBoxClientRecieve.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtBoxClientRecieve.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtBoxClientRecieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtBoxClientRecieve.Location = new System.Drawing.Point(3, 20);
            this.rtBoxClientRecieve.Name = "rtBoxClientRecieve";
            this.rtBoxClientRecieve.ReadOnly = true;
            this.rtBoxClientRecieve.Size = new System.Drawing.Size(734, 292);
            this.rtBoxClientRecieve.TabIndex = 3;
            this.rtBoxClientRecieve.Text = "";
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(207, 3);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(5, 511);
            this.splitter4.TabIndex = 13;
            this.splitter4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 511);
            this.panel2.TabIndex = 12;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cboxShowOnlyClient);
            this.groupBox7.Controls.Add(this.cboxClientAutoShow);
            this.groupBox7.Controls.Add(this.cboxConectMsg);
            this.groupBox7.Controls.Add(this.btnClearClientSend);
            this.groupBox7.Controls.Add(this.btnClearClientRecieve);
            this.groupBox7.Controls.Add(this.chboxClientSendClear);
            this.groupBox7.Controls.Add(this.chboxClientSendHex);
            this.groupBox7.Controls.Add(this.chboxClientRecieveHex);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 165);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(204, 346);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "辅助功能";
            // 
            // cboxShowOnlyClient
            // 
            this.cboxShowOnlyClient.AutoSize = true;
            this.cboxShowOnlyClient.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxShowOnlyClient.Location = new System.Drawing.Point(9, 176);
            this.cboxShowOnlyClient.Name = "cboxShowOnlyClient";
            this.cboxShowOnlyClient.Size = new System.Drawing.Size(131, 19);
            this.cboxShowOnlyClient.TabIndex = 18;
            this.cboxShowOnlyClient.Text = "仅显示接收信息";
            this.cboxShowOnlyClient.UseVisualStyleBackColor = true;
            // 
            // cboxClientAutoShow
            // 
            this.cboxClientAutoShow.AutoSize = true;
            this.cboxClientAutoShow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxClientAutoShow.Location = new System.Drawing.Point(9, 146);
            this.cboxClientAutoShow.Name = "cboxClientAutoShow";
            this.cboxClientAutoShow.Size = new System.Drawing.Size(146, 19);
            this.cboxClientAutoShow.TabIndex = 17;
            this.cboxClientAutoShow.Text = "自动显示最新消息";
            this.cboxClientAutoShow.UseVisualStyleBackColor = true;
            this.cboxClientAutoShow.CheckedChanged += new System.EventHandler(this.cboxClientAutoShow_CheckedChanged);
            // 
            // cboxConectMsg
            // 
            this.cboxConectMsg.AutoSize = true;
            this.cboxConectMsg.Checked = true;
            this.cboxConectMsg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxConectMsg.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboxConectMsg.Location = new System.Drawing.Point(9, 116);
            this.cboxConectMsg.Name = "cboxConectMsg";
            this.cboxConectMsg.Size = new System.Drawing.Size(170, 19);
            this.cboxConectMsg.TabIndex = 15;
            this.cboxConectMsg.Text = "UDP发送连接提示消息";
            this.cboxConectMsg.UseVisualStyleBackColor = true;
            // 
            // btnClearClientSend
            // 
            this.btnClearClientSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearClientSend.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClearClientSend.Location = new System.Drawing.Point(9, 256);
            this.btnClearClientSend.Name = "btnClearClientSend";
            this.btnClearClientSend.Size = new System.Drawing.Size(189, 39);
            this.btnClearClientSend.TabIndex = 15;
            this.btnClearClientSend.Text = "清空发送区";
            this.btnClearClientSend.UseVisualStyleBackColor = true;
            this.btnClearClientSend.Click += new System.EventHandler(this.btnClearClientSend_Click);
            // 
            // btnClearClientRecieve
            // 
            this.btnClearClientRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearClientRecieve.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClearClientRecieve.Location = new System.Drawing.Point(9, 211);
            this.btnClearClientRecieve.Name = "btnClearClientRecieve";
            this.btnClearClientRecieve.Size = new System.Drawing.Size(189, 39);
            this.btnClearClientRecieve.TabIndex = 14;
            this.btnClearClientRecieve.Text = "清空接收区";
            this.btnClearClientRecieve.UseVisualStyleBackColor = true;
            this.btnClearClientRecieve.Click += new System.EventHandler(this.btnClearClientRecieve_Click);
            // 
            // chboxClientSendClear
            // 
            this.chboxClientSendClear.AutoSize = true;
            this.chboxClientSendClear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxClientSendClear.Location = new System.Drawing.Point(9, 86);
            this.chboxClientSendClear.Name = "chboxClientSendClear";
            this.chboxClientSendClear.Size = new System.Drawing.Size(131, 19);
            this.chboxClientSendClear.TabIndex = 13;
            this.chboxClientSendClear.Text = "发送后自动清空";
            this.chboxClientSendClear.UseVisualStyleBackColor = true;
            // 
            // chboxClientSendHex
            // 
            this.chboxClientSendHex.AutoSize = true;
            this.chboxClientSendHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxClientSendHex.Location = new System.Drawing.Point(9, 56);
            this.chboxClientSendHex.Name = "chboxClientSendHex";
            this.chboxClientSendHex.Size = new System.Drawing.Size(116, 19);
            this.chboxClientSendHex.TabIndex = 12;
            this.chboxClientSendHex.Text = "十六进制发送";
            this.chboxClientSendHex.UseVisualStyleBackColor = true;
            this.chboxClientSendHex.CheckedChanged += new System.EventHandler(this.chboxClientSendHex_CheckedChanged);
            // 
            // chboxClientRecieveHex
            // 
            this.chboxClientRecieveHex.AutoSize = true;
            this.chboxClientRecieveHex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chboxClientRecieveHex.Location = new System.Drawing.Point(9, 26);
            this.chboxClientRecieveHex.Name = "chboxClientRecieveHex";
            this.chboxClientRecieveHex.Size = new System.Drawing.Size(116, 19);
            this.chboxClientRecieveHex.TabIndex = 11;
            this.chboxClientRecieveHex.Text = "十六进制显示";
            this.chboxClientRecieveHex.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.cboxClientIP);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.rbClientUDP);
            this.groupBox8.Controls.Add(this.rbClientTCP);
            this.groupBox8.Controls.Add(this.btnConnect);
            this.groupBox8.Controls.Add(this.tboxClientPort);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(204, 165);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "客户端配置";
            // 
            // cboxClientIP
            // 
            this.cboxClientIP.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxClientIP.FormattingEnabled = true;
            this.cboxClientIP.Location = new System.Drawing.Point(66, 22);
            this.cboxClientIP.Name = "cboxClientIP";
            this.cboxClientIP.Size = new System.Drawing.Size(132, 23);
            this.cboxClientIP.TabIndex = 9;
            this.cboxClientIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboxClientIP_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "服务器：";
            // 
            // rbClientUDP
            // 
            this.rbClientUDP.AutoSize = true;
            this.rbClientUDP.Location = new System.Drawing.Point(69, 88);
            this.rbClientUDP.Name = "rbClientUDP";
            this.rbClientUDP.Size = new System.Drawing.Size(46, 18);
            this.rbClientUDP.TabIndex = 12;
            this.rbClientUDP.TabStop = true;
            this.rbClientUDP.Text = "UDP";
            this.rbClientUDP.UseVisualStyleBackColor = true;
            // 
            // rbClientTCP
            // 
            this.rbClientTCP.AutoSize = true;
            this.rbClientTCP.Checked = true;
            this.rbClientTCP.Location = new System.Drawing.Point(9, 88);
            this.rbClientTCP.Name = "rbClientTCP";
            this.rbClientTCP.Size = new System.Drawing.Size(46, 18);
            this.rbClientTCP.TabIndex = 11;
            this.rbClientTCP.TabStop = true;
            this.rbClientTCP.Text = "TCP";
            this.rbClientTCP.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnConnect.Location = new System.Drawing.Point(9, 117);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(189, 39);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tboxClientPort
            // 
            this.tboxClientPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxClientPort.Location = new System.Drawing.Point(66, 53);
            this.tboxClientPort.MaxLength = 5;
            this.tboxClientPort.Name = "tboxClientPort";
            this.tboxClientPort.ShortcutsEnabled = false;
            this.tboxClientPort.Size = new System.Drawing.Size(132, 23);
            this.tboxClientPort.TabIndex = 4;
            this.tboxClientPort.Text = "8080";
            this.tboxClientPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxPort_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(20, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "端口：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Frm_NetWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 546);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_NetWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_NetWork_FormClosing);
            this.Load += new System.EventHandler(this.Frm_NetWork_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupbox4.ResumeLayout(false);
            this.groupbox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tboxServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCreateServer;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chboxIPV6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtBoxServerRecieve;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ComboBox cboxConnectClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnServerSend;
        private System.Windows.Forms.TextBox tboxServerSend;
        private System.Windows.Forms.CheckBox cboxServerTime;
        private System.Windows.Forms.TextBox tboxServerTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupbox4;
        private System.Windows.Forms.Button btnClearServerSend;
        private System.Windows.Forms.Button btnClearServerRecieve;
        private System.Windows.Forms.CheckBox chboxServerSendClear;
        private System.Windows.Forms.CheckBox chboxServerSendHex;
        private System.Windows.Forms.CheckBox chboxServerRecieveHex;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxClientTime;
        private System.Windows.Forms.CheckBox cboxClientTime;
        private System.Windows.Forms.Button btnClientSend;
        private System.Windows.Forms.TextBox tboxClientSend;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtBoxClientRecieve;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnClearClientSend;
        private System.Windows.Forms.Button btnClearClientRecieve;
        private System.Windows.Forms.CheckBox chboxClientSendClear;
        private System.Windows.Forms.CheckBox chboxClientSendHex;
        private System.Windows.Forms.CheckBox chboxClientRecieveHex;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tboxClientPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbServerUDP;
        private System.Windows.Forms.RadioButton rbServerTCP;
        private System.Windows.Forms.RadioButton rbClientUDP;
        private System.Windows.Forms.RadioButton rbClientTCP;
        private System.Windows.Forms.ComboBox cboxClientIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cboxConectMsg;
        private System.Windows.Forms.CheckBox cboxServerAutoShow;
        private System.Windows.Forms.CheckBox cboxClientAutoShow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox cboxShowOnlyClient;
        private System.Windows.Forms.CheckBox cboxShowOnlyServer;
    }
}