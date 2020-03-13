using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace CMES.Utility
{
   public class XMLReadBC
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
                    configFileName = Path.Combine(path, @"XML\ChannelHeat.xml");
                    configFileName = configFileName.Substring(6);
                }
                return configFileName;
            }
        }
        public void SetXML(int number, float HeatValue)
        {
            XElement xe = XElement.Load(ConfigFileName);
            switch (number)
            {
                case 1:
                    xe.SetElementValue("Channel1", HeatValue);
                    break;
                case 2:
                    xe.SetElementValue("Channel2", HeatValue);
                    break;
                case 3:
                    xe.SetElementValue("Channel3", HeatValue);
                    break;
                case 4:
                    xe.SetElementValue("Channel4", HeatValue);
                    break;
                case 5:
                    xe.SetElementValue("Channel5", HeatValue);
                    break;
                case 6:
                    xe.SetElementValue("Channel6", HeatValue);
                    break;
                case 7:
                    xe.SetElementValue("Channel7", HeatValue);
                    break;
                case 8:
                    xe.SetElementValue("Channel8", HeatValue);
                    break;
                default:
                    break;
            }
            xe.Save(ConfigFileName);
        }
        public string LoadXML(int number)
        {
            XElement xe = XElement.Load(ConfigFileName);
            string cheanelName = "";
            switch (number)
            {
                case 1:
                    cheanelName = "Channel1";
                    break;
                case 2:
                    cheanelName = "Channel2";
                    break;
                case 3:
                    cheanelName = "Channel3";
                    break;
                case 4:
                    cheanelName = "Channel4";
                    break;
                case 5:
                    cheanelName = "Channel5";
                    break;
                case 6:
                    cheanelName = "Channel6";
                    break;
                case 7:
                    cheanelName = "Channel7";
                    break;
                case 8:
                    cheanelName = "Channel8";
                    break;
                default:
                    cheanelName = "Channel0";
                    break;
            }

            return GetElementValue(xe, cheanelName, "0");
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
