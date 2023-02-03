using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant.Module
{
    /// <summary>
    /// 公共全局类
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// 本地网络助手配置文件
        /// </summary>
        public static string sNetWorkSetting { get; } = Application.StartupPath + "\\Setting\\NetWorkSetting.ini";
        /// <summary>
        /// 本地串口助手配置文件
        /// </summary>
        public static string sSerialPortSetting { get; } = Application.StartupPath + "\\Setting\\SerialPortSetting.ini";

        /// <summary>
        /// WEB助手配置文件
        /// </summary>
        public static string sWebSetting { get; } = Application.StartupPath + "\\Setting\\WebSetting.ini";
    }
}
