using Assistant.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant.Web
{
    public partial class Frm_Web : Form
    {
        public Frm_Web()
        {
            InitializeComponent();
        }

        /// <summary>
        /// INI配置文件
        /// </summary>
        private IniHelper iniFile = new IniHelper(Global.sWebSetting);

        /// <summary>
        /// 加载配置
        /// </summary>
        private void InitSetting()
        {
            string sReq = iniFile.ReadValue("Web配置", "request");
            if (int.TryParse(sReq, out int request) && request < cboxReq.Items.Count)//请求
            {
                cboxReq.SelectedIndex = request;
            }
            else
            {
                cboxReq.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveSetting()
        {
            iniFile.WriteValue("Web配置", "request", cboxReq.SelectedIndex.ToString());//请求
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Web_Load(object sender, EventArgs e)
        {
            InitSetting();
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Web_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
        }

        /// <summary>
        /// 发送按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
