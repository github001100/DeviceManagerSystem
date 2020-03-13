using CMES.Data;
using CMES.Entity.SYS;
using CMES.NET;
using CMES.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Windows.Forms;

namespace CMES.Controller.SYS
{
    public class BaseNodeController
    {
        /// <summary>
        /// 获取树的节点
        /// </summary>
        /// <param name="PId"></param>
        /// <param name="DbMssql"></param>
        /// <returns></returns>
        public List<TreeNode> GetList(int PId, DatabaseSQLite database)
        {
           // List<TreeNode> list = new List<TreeNode>();
            List<TreeNode> list = new List<TreeNode>();
            DataTable dt = new DataTable();
            string sql = "select Id,NodeName from CX_Parameters where EnableMark!= 1 and ParentId = " + PId + " Order by NodeOrder";
            dt = database.GetDataTable(sql, null);
            if (dt.Rows.Count > 0)
            {

                ChangeList(dt, list);
            }
            //ApiResult apiresult = new ApiResult();
            //string mearResult = HttpHelper.DOGET("SpcUrl", "CXParameters");
            ////判断响应结果
            //if (mearResult != null && !mearResult.Equals(string.Empty))
            //{
            //    try
            //    {
            //        apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);
            //        //如更新正常则更新本地状态值
            //        if (apiresult.Code.Equals(0))
            //        {
            //            List<CX_Parameters> listp = new List<CX_Parameters>();
            //            if (apiresult.Data != null)
            //            {
            //                 listp = JsonConvert.DeserializeObject<List<CX_Parameters>>(apiresult.Data.ToString());

            //            }
            //            if (listp!=null&& listp.Count>0) {
            //                for (int i = 0; i < listp.Count; i++)
            //                {
            //                    TreeNode treeNode = new TreeNode() {
            //                          Tag = listp[i].Id,
            //                          Text = listp[i].NodeName
            //                    };
            //                    list.Add(treeNode);
            //                }
            //            }
            //        }
            //    }
            //    catch
            //    {

            //    }                
            //}
            return list;
        }
        

        private List<TreeNode> ChangeList(DataTable dt, List<TreeNode> list)
        {            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tnode = new TreeNode
                {
                    Tag = Convert.ToInt32(dt.Rows[i][0].ToString()),
                    Text = dt.Rows[i][1].ToString()
                };
                list.Add(tnode);
            }
            return list;
        }
        /// <summary>
        /// 获取符合条件的三级节点ID列表
        /// </summary>
        /// <param name="DbMssql"></param>
        /// <returns></returns>
        public List<int> GetNodeIds(DatabaseSQLite database) {
            List<int> list = new List<int>();
            string sql = "select Id from CX_Parameters where EnableMark!= 1 and NodeLv > 3 ";
            DataTable dt = database.GetDataTable(sql,null);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToInt32(dt.Rows[i][0].ToString()));
                }              
            }
            return list;
        }
        /// <summary>
        /// 根据ID获取节点
        /// </summary>
        /// <param name="NodeId"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public BaseNode GetNodeById(int NodeId,DatabaseSQLite database) {
            BaseNode baseNode = new BaseNode();
            string sql = "select * from CX_Parameters where EnableMark!=1 and Id =@Id ";
            SQLiteParameter[] sp = {
                 new SQLiteParameter("@Id",NodeId)
                  };
            DataTable dt = database.GetDataTable(sql, sp);
            if (dt.Rows.Count>0) {
                baseNode = FromDataRow(dt.Rows[0]);
            }
            return baseNode;
        }
        /// <summary>
        /// 转码
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static BaseNode FromDataRow(DataRow reader)
        {
            BaseNode thisObj = new BaseNode();
            if (null == reader)
                return thisObj;
            string errorName = string.Empty;
            try
            {
                Type thisType = typeof(BaseNode);
                PropertyInfo[] ps = thisType.GetProperties();
                foreach (PropertyInfo pi in ps)
                {
                    string propertyName = pi.Name;
                    errorName = propertyName;

                    //string colName = MappingTable.GetClumnHeader(propertyName);

                    //object oV = reader[colName];
                    object oV = reader[propertyName];
                    object pV = oV;
                    if (oV == null)
                    {
                        if (typeof(string) == pi.GetType())
                        {
                            pV = "";
                        }
                        else
                        {
                            pV = 0;
                        }
                    }
                    else if (oV is double)
                    {
                        pV = Convert.ToSingle(pV);
                    }
                    else if (oV is long) {
                        pV = Convert.ToInt32(pV);
                    }

                    pi.SetValue(thisObj, pV, null);
                }
                return thisObj;
            }
            catch (Exception e)
            {
                ErrorLogMsg.CreateErrLog("节点内容转换失败",e.Source,e.Message);
                return new BaseNode();
            }
        }
        /// <summary>
        /// 获取指定基本的所有节点
        /// </summary>
        /// <param name="LvId"></param>
        /// <param name="database"></param>
        /// <returns></returns>
        public List<ComboboxEx> GetCombobxsByLv(int LvId, DatabaseSQLite database) {
            List<ComboboxEx> list = new List<ComboboxEx>();
            string sql = "select id,NodeName from CX_Parameters where EnableMark!=1 and NodeLv = @NodeLv";
            SQLiteParameter[] sp = {
                 new SQLiteParameter("@NodeLv",LvId)
                  };
            DataTable dt = database.GetDataTable(sql, sp);
            if (dt.Rows.Count>0) {
                for(int i=0;i< dt.Rows.Count;i++)
                {
                    ComboboxEx cbe = new ComboboxEx
                    {
                        Id = dt.Rows[i][0].ToString(),
                        Text = dt.Rows[i][1].ToString()
                    };
                    list.Add(cbe);
                }
            }
            return list;
        }
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="NodeId"></param>
        /// <param name="database"></param>
        public string DelNode(int NodeId, DatabaseSQLite database) {
            string msg = "";
            try
            {
                if (CheckPv(NodeId, database))
                {
                    string sql = "update CX_Parameters set EnableMark = 1 where Id =@Id ";
                    SQLiteParameter[] sp = {
                    new SQLiteParameter("@Id",NodeId)
                        };
                    database.ExecuteNonQuery(sql, sp);
                    msg = "删除成功。";
                }
                else
                {
                    msg = "先删除字节的，后才可删除当前节点。";
                }
            }
            catch (Exception exx)
            {
                ErrorLogMsg.CreateErrLog("删除节点异常",exx.Source,exx.Message);
                msg = "数据异常。";
            }
            
            return msg;
        }

        private bool CheckPv(int NodeId, DatabaseSQLite database) {
            string sql = "select count(Id) from CX_Parameters where  EnableMark != 1 and ParentId = @ParentId ";
            SQLiteParameter[] sp = {
                    new SQLiteParameter("@ParentId",NodeId)
                        };
           int count =Convert.ToInt32(database.ExecuteScalar(sql,sp));
            return count>0?false:true;
        }
    }
}
