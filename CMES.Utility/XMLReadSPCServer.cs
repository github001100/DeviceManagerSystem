using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace CMES.Utility
{
   public class XMLReadSPCServer
    {
        static string configFileName = string.Empty;
        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(configFileName))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);                    
                    configFileName = Path.Combine(path, @"XML\SPCService.xml");
                    configFileName = configFileName.Substring(6);
                }
                return configFileName;
            }
        }
        public void SetXML(string name,string svalue)
        {
            XElement xe = XElement.Load(ConfigFileName);            
            xe.SetElementValue(name, svalue);          
            xe.Save(ConfigFileName);
        }
        public string LoadXML(string name,string defaultvalue)
        {
            XElement xe = XElement.Load(ConfigFileName);            
            return GetElementValue(xe, name, defaultvalue);
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
