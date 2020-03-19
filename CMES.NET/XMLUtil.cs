using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace CMES.NET
{
    /// <summary>
    /// 常用的文件操作辅助类FileUtil
    /// </summary>
    public class XMLUtil
    {

        #region XML文件操作

        /// <summary>
        /// 获取XML文件中指定列的值
        /// </summary>
        /// <param name="xe">XML文件</param>
        /// <param name="elemName">列名</param>
        /// <param name="def">默认值</param>
        /// <returns></returns>
        public static string GetElementValue(XElement xe, string elemName, string def)
        {
            try
            {
                XElement xElem = xe.Element(elemName);
                if (null != xElem)
                {
                    return xElem.Value;
                }
                return def;
            }
            catch
            {
                return def;
            }
        }
        public static void SetXML(string HeatValue)
        {
            XElement xe = XElement.Load(ConfigFileName);
            xe.SetElementValue("LoadUrl", HeatValue);
            xe.Save(ConfigFileName);
        }
        public static string GetXML()
        {
            XElement xe = XElement.Load(ConfigFileName);
            return GetElementValue(xe, "LoadUrl", "http://localhost:8000/api/");
        }
        static string configFileName = string.Empty;
        static string configFileNameDataBase = string.Empty;
        static string configFileNameUserInfo = string.Empty;
        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(configFileName))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    configFileName = Path.Combine(path, @"XML\serverconfig.xml").Replace("file:\\", "");
                }
                return configFileName;
            }
        }
        public static string ConfigFileNameDataBase
        {
            get
            {
                if (string.IsNullOrEmpty(configFileNameDataBase))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    configFileNameDataBase = Path.Combine(path, @"XML\DataBaseInfo.xml").Replace("file:\\", "");
                }
                return configFileNameDataBase;
            }
        }
        public static string ConfigFileNameUserInfo
        {
            get
            {
                if (string.IsNullOrEmpty(configFileNameUserInfo))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    configFileNameUserInfo = Path.Combine(path, @"XML\UserInfo.xml").Replace("file:\\", "");
                }
                return configFileNameUserInfo;
            }
        }
        #endregion

    }
}
