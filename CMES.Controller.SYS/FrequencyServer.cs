using System.Data.SQLite;
using System.Data;
using CMES.Data;

namespace CMES.Controller.SYS
{
    public class FrequencyServer
    {
        public string GetFrequencyName(string times,DatabaseSQLite sdq) {
            string sql = "select frequencyName,startTime,endTime " +
                "FROM sys_frequency where datetime(startTime) <= datetime(@times) and datetime(endTime) >= datetime(@times)";
            SQLiteParameter[] sp = { 
                 new SQLiteParameter("@times",times)    
                  };
            DataTable dt = sdq.GetDataTable(sql, sp);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                //如果没有 可能是跨天的中班
                string sql1 = "select frequencyName,startTime,endTime " +
                "FROM sys_frequency where datetime(startTime) <= datetime(@times) and datetime(endTime) <= datetime(@times) and datetime(startTime) > datetime(endTime)";                
                DataTable dt1 = sdq.GetDataTable(sql1, sp);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    return dt1.Rows[0][0].ToString();
                }
                else
                {
                    return "";
                }
            }
           
        }
    }
}
