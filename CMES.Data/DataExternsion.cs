using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;
using CMES.Utility;

namespace CMES.Data
{
   
    public static class DataExternsion
    {
        public static object GetValue(this SQLiteDataReader reader, string name, object def)
        {
            object oV = reader[name];
            object pV = oV;
            if (oV == null)
            {
                pV = def;
            }

            if (oV is double)
            {
                pV = Convert.ToSingle(oV);
            }

            return pV;
        }

        public static bool GetBool(this SQLiteDataReader reader, string name)
        {
            try
            {
                return Convert.ToBoolean(reader[name]);
            }
            catch
            {
                return false;
            }
        }


        public static string GetString(this SQLiteDataReader reader, string name)
        {
            try
            {
                return Convert.ToString(reader[name]);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static float GetFloat(this SQLiteDataReader reader, string name)
        {
            try
            {
                return Convert.ToSingle(reader[name]);
            }
            catch
            {
                return 0;
            }
        }
        public static int GetInt(this SQLiteDataReader reader, string name)
        {
            try
            {
                return Convert.ToInt32(reader[name]);
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime GetTime(this SQLiteDataReader reader, string name)
        {
            try
            {
                return Convert.ToDateTime(reader[name]);
            }
            catch
            {
                return DateTime.Now;
            }
        }


        public static string GetString(this DataRow reader, string name)
        {
            try
            {
                return Convert.ToString(reader[name]);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static float GetFloat(this DataRow reader, string name)
        {
            try
            {
                return Convert.ToSingle(reader[name]);
            }
            catch
            {
                return 0;
            }
        }
        public static int GetInt(this DataRow reader, string name)
        {
            try
            {
                return Convert.ToInt32(reader[name]);
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime GetTime(this DataRow reader, string name)
        {
            try
            {
                return Convert.ToDateTime(reader[name]);
            }
            catch
            {
                return DateTime.Now;
            }
        }
        #region datatable
        
        /// <summary>
        /// 导出为CSV文件
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="csvFileName"></param>
        public static bool ExportToCSV(this DataTable dt, List<DataRow> rows, string csvFileName)
        {
            //先打印标头
            StringBuilder strColu = new StringBuilder();
            StringBuilder strValue = new StringBuilder();
            int i = 0;
            try
            {
                StreamWriter sw = new StreamWriter(new FileStream(csvFileName, FileMode.OpenOrCreate), Encoding.GetEncoding("GB2312"));
                for (i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    strColu.Append(dt.Columns[i].ColumnName);
                    strColu.Append(",");
                }
                strColu.Remove(strColu.Length - 1, 1);//移出掉最后一个,字符
                sw.WriteLine(strColu);

                foreach (DataRow dr in rows)
                {
                    strValue.Remove(0, strValue.Length);//移出 
                    for (i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        strValue.Append(dr[i].ToString());
                        strValue.Append(",");
                    }

                    strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符
                    sw.WriteLine(strValue);
                }
                sw.Close();
                return true;

                //System.Diagnostics.Process.Start(csvFileName,"");
            }
            catch (Exception ex)
            {
                // throw ex;
                ErrorLogMsg.CreateErrLog("导出CSV错误",ex.Source,ex.Message);
                return false;

            }
        }

        #endregion
    }

}
