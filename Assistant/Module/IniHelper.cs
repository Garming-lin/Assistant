using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Module
{
    /// <summary>
    /// INI配置文件操作
    /// </summary>
    public class IniHelper
    {
        /// <summary>
        /// 当前操作的INI文件绝对路径
        /// </summary>
        public string IniFile { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sIniFile">当前操作的INI文件绝对路径，文件不存在则会自动生成</param>
        public IniHelper(string sIniFile)
        {
            this.IniFile = sIniFile;
        }

        /// <summary>
        /// INI文件的写操作函数
        /// </summary>
        /// <param name="section">配置节点</param>
        /// <param name="key">键名</param>
        /// <param name="val">键值</param>
        /// <param name="filePath">INI文件路径</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// INI文件的读操作函数
        /// </summary>
        /// <param name="section">配置节点</param>
        /// <param name="key">键名</param>
        /// <param name="def">无该key键名时返回的默认值</param>
        /// <param name="retVal">返回键值缓冲区</param>
        /// <param name="size">返回键值大小</param>
        /// <param name="filePath">INI文件路径</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="sSection">配置节点名称（存在则写入指定节点，不存在自动创建）</param>
        /// <param name="sKey">键名</param>
        /// <param name="sValue">键值</param>
        public void WriteValue(string sSection, string sKey, string sValue)
        {
            long a = WritePrivateProfileString(sSection, sKey, sValue, this.IniFile);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="sSection">配置节点名称</param>
        /// <param name="sKey">键名</param>
        /// <returns></returns>
        public string ReadValue(string sSection, string sKey)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(sSection, sKey, "", temp, 255, this.IniFile);
            return temp.ToString();
        }

        /// <summary>
        /// 删除指定节点下的键值配置
        /// </summary>
        /// <param name="sSection">需要删除的配置节点名称</param>
        /// <param name="sKey">需要删除的节点名称下的键名</param>
        public void RemoveKey(string sSection, string sKey)
        {
            WritePrivateProfileString(sSection, sKey, null, this.IniFile);
        }

        /// <summary>
        /// 删除指定节点下所有键值配置
        /// </summary>
        /// <param name="Section">需要删除的配置节点名称</param>
        public void RemoveSection(string sSection)
        {
            WritePrivateProfileString(sSection, null, null, this.IniFile);
        }
    }
}
