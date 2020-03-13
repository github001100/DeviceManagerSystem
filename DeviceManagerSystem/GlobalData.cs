using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DeviceManagerSystem
{
    class GlobalData
    {
        /// <summary>
        /// 系统语言（Chinese（中文），English（英文）。。。）
        /// </summary>
        public static string SystemLanguage = System.Configuration.ConfigurationManager.AppSettings["Language"];

        private static Language globalLanguage;
        public static Language GlobalLanguage
        {
            get
            {
                if (globalLanguage == null)
                {
                    globalLanguage = new Language();
                    return globalLanguage;
                }
                return globalLanguage;
            }
        }
    }
}
