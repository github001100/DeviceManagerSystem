using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace CMES.Utility
{
   public class XMLReadUser
    {
        static string configFileName = string.Empty;
        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(configFileName))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    //CAYA_MES\View\quality
                    configFileName = Path.Combine(path, @"XML\UserInfo.xml");
                    configFileName = configFileName.Substring(6);
                }
                return configFileName;
            }
        }

        public void SetXML(string dName, string HeatValue)
        {
            XElement xe = XElement.Load(ConfigFileName);
            xe.SetElementValue(dName, HeatValue);
            xe.Save(ConfigFileName);
        }
        public string LoadXML(string dName,string defVal)
        {
            XElement xe = XElement.Load(ConfigFileName);            
            return GetElementValue(xe, dName, defVal);
        }
        static string GetElementValue(XElement xe, string elemName, string def)
        {
            try
            {
                XElement xElem = xe.Element(elemName);
                if (null != xElem)
                {
                    return !xElem.Value.Equals(string.Empty)? xElem.Value: def;
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
