using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using CMES.Data;
using CMES.Entity.SYS;

namespace CMES.Controller.SYS
{
    public class UserRoleServer
    {
        //获取权限列表
        public IEnumerable<ComboboxEx> GetRole(DatabaseSQLite dsql)
        {
            List<ComboboxEx> list = new List<ComboboxEx>();
           // combobox cb = new combobox() { id = "",text = "-请选择-"};
            //list.Add(cb);
            string sql = "select distinct roleName as id,1 as uname from sys_role where EnabledMark != 1";
            DataTable dt = dsql.GetDataTable(sql, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new ComboboxEx()
                    {
                        Id = row["id"].ToString(),
                        Text = row["id"].ToString()
                    });
                }
            }
            return list;
        }
        public string GetRolePower(string roleName,DatabaseSQLite dsql)
        {
            string sql = "select markRoleLv from sys_role where EnabledMark != 1 and roleName = @roleName ";
            SQLiteParameter[] spr = { 
                   new SQLiteParameter("@roleName",roleName)
                                  };
            DataTable dt = dsql.GetDataTable(sql,spr);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else {
                return "";
            }
            
        }
        //获取职位列表
        public IEnumerable<ComboboxEx> GetDuty(DatabaseSQLite dsql)
        {
            List<ComboboxEx> list = new List<ComboboxEx>();
            //combobox cb = new combobox() { id = "", text = "-请选择-" };
            //list.Add(cb);
            string sql = "select distinct name as id,1 as uname from sys_duty where 1 = 1";
            DataTable dt = dsql.GetDataTable(sql, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new ComboboxEx()
                    {
                        Id = row["id"].ToString(),
                        Text = row["id"].ToString()
                    });
                }
            }
            return list;
        }
        //获取工种列表
        public IEnumerable<ComboboxEx> GetWorkType(DatabaseSQLite dsql)
        {
            List<ComboboxEx> list = new List<ComboboxEx>();
            ComboboxEx cb = new ComboboxEx() { Id = "", Text = "-请选择-" };
            list.Add(cb);
            string sql = "select distinct name as id,1 as uname from sys_workType where 1 = 1";
            DataTable dt = dsql.GetDataTable(sql, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new ComboboxEx()
                    {
                        Id = row["id"].ToString(),
                        Text = row["id"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
