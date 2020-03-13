using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DeviceManagerSystem
{
    class Language
    {
        #region 界面
        public string Login_UserName = "";
        public string Login_UserPwd = "";

        public string Title = "";
        public string Menu = "";
        public string SystemSetting = "";
        public string LanguageSwitching = "";
        public string FileInput = "";
        public string LanguageChinese = "";
        public string LanguageEnglish = "";
        public string LanguageKorean = "";

        public string Data_query = "";
        public string Historical_record = "";
        public string Exit = "";
        public string About = "";
        public string Contact_Service = "";
        public string Updating = "";
        public string VersionDesc = "";

        public string ToolBox = "";
        public string Notepad = "";
        public string Calculator = "";

        public string Title2 = "";
        public string DeviceInfo = "";
        public string ProductID = "";
        public string ProductCount = "";
        public string ProductOk = "";
        public string ProductNG = "";
        public string RunningState = "";
        public string Beat = "";//节拍
        public string NormalOperation = "";
        public string EmptyOperation = "";
        public string CleaningStation = "";
        public string Standby = "";
        public string Adjustment = "";
        public string Fault = "";

        public string Button1 = "";
        public string Button2 = "";
        public string Button3 = "";
        public string Button4 = "";
        //数据查询界面变量
        public string DateStart = "";
        public string DateEnd = "";
        public string DeviceID = "";
        public string ProductNumber = "";
        public string QueryButton = "";
        public string AnalysisButton = "";
        public string TotalRow = "";
        public string RowsNum = "";
        public string WJ1 = "";
        public string WJ2 = "";
        //SPC报告分析界面国际化
        public string SPCTitle = "";
        public string AnlysisImage = "";
        public string ControlImage = "";
        public string RadioAnlysisButton = "";
        public string RadioControlButton = "";
        public string NormalDistribution = "";
        public string PartitionLine = "";
        public string SavePictureNutton = "";
        public string GoBackButton = "";
        public string SPCName = "";
        public string USL = "";
        public string LSL = "";
        public string Device = "";
        public string Procedure = "";
        public string GroupSize = "";
        public string Date_ = "";
        public string ModelNem = "";
        public string CheckHistory = "";
        public string SUM_ = "";
        public string Avgerage_ = "";
        public string Range_ = "";

        #endregion

        protected Dictionary<string, string> DicLanguage = new Dictionary<string, string>();
        public Language()
        {
            //try
            {
                XmlLoad(GlobalData.SystemLanguage);
                BindLanguageText();
            }
            //catch (Exception)
            {

              // return;
            }
           
        }

        /// <summary>
        /// 读取XML放到内存
        /// </summary>
        /// <param name="language"></param>
        protected void XmlLoad(string language)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                string address = AppDomain.CurrentDomain.BaseDirectory + "Languages\\" + language + ".xml";
                doc.Load(address);
                XmlElement root = doc.DocumentElement;

                XmlNodeList nodeLst1 = root.ChildNodes;
                foreach (XmlNode item in nodeLst1)
                {
                    DicLanguage.Add(item.Name, item.InnerText);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindLanguageText()
        {
            #region   主界面国际化
            Login_UserName = DicLanguage["Login_UserName"];
            Login_UserPwd = DicLanguage["Login_UserPwd"];

            Title = DicLanguage["Form_Title"];
            Menu = DicLanguage["Form_Memu"];
            SystemSetting = DicLanguage["Form_Setting"];
            FileInput = DicLanguage["FileInput"];
            LanguageSwitching = DicLanguage["LanguageSwitching"];
            LanguageChinese = DicLanguage["LanguageChinese"];
            LanguageEnglish = DicLanguage["LanguageEnglish"];
            LanguageKorean = DicLanguage["LanguageKorean"];

            Data_query = DicLanguage["Form_Query"];
            Historical_record = DicLanguage["Historical_record"];
            Exit = DicLanguage["Form_Exit"];
            About = DicLanguage["Form_About"];
            Contact_Service = DicLanguage["Contact_Service"];
            Updating = DicLanguage["Updating"];
            VersionDesc = DicLanguage["Version_Desc"];
            ToolBox = DicLanguage["Form_Tools"];
            Notepad = DicLanguage["Notepad"];
            Calculator = DicLanguage["Calculator"];
            Title2 = DicLanguage["Form_Title2"];

            DeviceInfo = DicLanguage["DeviceInfo"];
            ProductID = DicLanguage["ProductID"];
            ProductCount = DicLanguage["ProductCount"];
            ProductOk = DicLanguage["ProductOk"];
            ProductNG = DicLanguage["ProductNG"];
            Beat = DicLanguage["Beat"];//节拍 2019.12.16
            RunningState = DicLanguage["RunningState"];
            NormalOperation = DicLanguage["NormalOperation"];
            EmptyOperation = DicLanguage["EmptyOperation"];
            CleaningStation = DicLanguage["CleaningStation"];
            Standby = DicLanguage["Standby"];
            Adjustment = DicLanguage["Adjustment"];
            Fault = DicLanguage["Fault"];

            Button1 = DicLanguage["button1"];
            Button2 = DicLanguage["button2"];
            Button3 = DicLanguage["button3"];
            Button4 = DicLanguage["button4"];

            //数据查询界面
            DateStart = DicLanguage["DateStart"];
            DateEnd = DicLanguage["DateEnd"];
            DeviceID = DicLanguage["DeviceID"];
            ProductNumber = DicLanguage["ProductNumber"];
            QueryButton = DicLanguage["QueryButton"];
            AnalysisButton = DicLanguage["AnalysisButton"];
            TotalRow = DicLanguage["TotalRow"];
            RowsNum = DicLanguage["RowsNum"];
            WJ1 = DicLanguage["WJ1"];
            WJ2 = DicLanguage["WJ2"];
            //SPC报告分析界面国际化
            SPCTitle = DicLanguage["SPCTitle"];
            AnlysisImage = DicLanguage["AnlysisImage"];
            ControlImage = DicLanguage["ControlImage"];
            RadioAnlysisButton = DicLanguage["RadioAnlysisButton"];
            RadioControlButton = DicLanguage["RadioControlButton"];
            NormalDistribution = DicLanguage["NormalDistribution"];
            PartitionLine = DicLanguage["PartitionLine"];
            SavePictureNutton = DicLanguage["SavePictureNutton"];
            GoBackButton = DicLanguage["GoBackButton"];
            SPCName = DicLanguage["SPCName"];
            USL = DicLanguage["USL"];
            LSL = DicLanguage["LSL"];
            Device = DicLanguage["Device"];
            Procedure = DicLanguage["Procedure"];
            GroupSize = DicLanguage["GroupSize"];
            Date_ = DicLanguage["Date"];
            ModelNem = DicLanguage["ModelNem"];
            CheckHistory = DicLanguage["CheckHistory"];
            SUM_ = DicLanguage["SUM"];
            Avgerage_ = DicLanguage["Avgerage"];
            Range_ = DicLanguage["Range"];
            #endregion



        }
    }
}
