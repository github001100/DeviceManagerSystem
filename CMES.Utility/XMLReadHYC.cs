using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace CMES.Utility
{
   public class XMLReadHYC
    {
        static string configFileName = string.Empty;
        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(configFileName))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);                    
                    configFileName = Path.Combine(path, @"XML\HYC.xml");
                    configFileName = configFileName.Substring(6);
                }
                return configFileName;
            }
        }
        public void SetXML(string msg)
        {
            XElement xe = XElement.Load(ConfigFileName);            
            xe.SetElementValue("ShowMsg", msg);                 
            xe.Save(ConfigFileName);
        }
        public string LoadXML()
        {
            XElement xe = XElement.Load(ConfigFileName);            
            return GetElementValue(xe,"ShowMsg", "开远智能欢迎您的到来！");
        }
        static string GetElementValue(XElement xe, string elemName, string def)
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
    }
}
