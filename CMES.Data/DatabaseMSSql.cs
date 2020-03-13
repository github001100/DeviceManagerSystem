using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using CMES.Utility;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CMES.Data
{
    /// <summary>
    /// 数据库类。操作数据库SqlServer
    /// </summary>
    public class DatabaseMSSql : IDisposable
    {
        /// <summary>
        /// 连接状态
        /// </summary>
        public int ConnectState { get; set; }
        #region xml 文件存取
        static string configFileName = string.Empty;
        public static string ConfigFileName
        {
            get
            {
                if (string.IsNullOrEmpty(configFileName))
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    //CAYA_MES\View\quality
                    configFileName = Path.Combine(path, @"XML\DataBaseInfo.xml");
                    //configFileName = Path.Combine(path, @"CAYA_MES\MSPCS.xml");
                    configFileName = configFileName.Substring(6);
                }
                return configFileName;
            }
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

        static int GetElementValue(XElement xe, string elemName, int def)
        {
            try
            {
                XElement xElem = xe.Element(elemName);
                if (null != xElem)
                {
                    return xElem.Value.ToInt(def);
                }
                return def;
            }
            catch
            {
                return def;
            }
        }

        static void SetElementValue(XElement xe, string elemName, int v)
        {
            try
            {
                xe.SetElementValue(elemName, v);
            }
            catch
            {

            }
        }

        static float GetElementValue(XElement xe, string elemName, float def)
        {
            try
            {
                XElement xElem = xe.Element(elemName);
                if (null != xElem)
                {
                    return xElem.Value.ToFloat(def);
                }

                return def;
            }
            catch
            {
                return def;
            }
        }

        static void SetElementValue(XElement xe, string elemName, float v)
        {
            try
            {
                xe.SetElementValue(elemName, v);
            }
            catch
            {

            }
        }
        static DateTime GetElementValue(XElement xe, string elemName, DateTime def)
        {
            try
            {

                XElement xElem = xe.Element(elemName);
                if (null != xElem)
                {
                    return DateTime.Parse(xElem.Value);
                }

                return def;
            }
            catch
            {
                return def;
            }
        }

        static void SetElementValue(XElement xe, string elemName, DateTime dt)
        {
            try
            {
                xe.SetElementValue(elemName, dt.ToString("F"));
            }
            catch
            {

            }
        }
        #endregion
        /// <summary>
        /// 创建一个服务器连接的数据库对象配置文件
        /// </summary>       
        string strConn = GetElementValue(XElement.Load(ConfigFileName), "ConnectionString", @"Data Source=.;Initial Catalog=CMES;User ID=sa;Password=s.123456");
        private SqlConnection conn = null;

        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetDataset(string sql, string tableName)
        {
            DataSet ds = null;
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter(sql, strConn);
                adp.SelectCommand.CommandTimeout = 600;
                ds = new DataSet();
                adp.Fill(ds, tableName);
            }
            catch
            {
                return null;
            }
            return ds;
        }

        #region SqlServer 基础连接

        public int OpenDB()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }

                conn = new SqlConnection(strConn);
                conn.Open();
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("数据库连接失败", ex.Source, ex.Message);
                return -1;
            }
            return 0;
        }

        public int CloseDB()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("数据库关闭失败", ex.Source, ex.Message);
                return -1;
            }
            return 0;
        }
        public void Dispose()
        {
            CloseDB();
        }
        /// <summary>
        /// 获取单列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int GetScalar(string sql)
        {
            int result = -1;
            try
            {
                if (strConn.Trim() == "")
                {
                    return result;
                }

                using (SqlConnection connection = conn)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("获取单列数据失败", ex.Source, ex.Message);
                result = -1;
            }
            return result;
        }

        public int GetScalar(ref object obj, string sql)
        {
            int result = -1;
            try
            {
                if (strConn.Trim() == "")
                {
                    return result;
                }
                using (SqlConnection sConn = conn)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, sConn))
                    {
                        obj = cmd.ExecuteScalar();
                        result = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
                ErrorLogMsg.CreateErrLog("获取单列数据失败", ex.Source, ex.Message);
            }
            return result;
        }
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tbx"></param>
        /// <returns></returns>
        public DataSet GetDataset_SQL(string sql, string tbx)
        {
            DataSet ds = null;
            try
            {
                if (strConn.Trim() == "")
                {
                    return null;
                }

                SqlDataAdapter sda = new SqlDataAdapter(sql, strConn);
                sda.SelectCommand.CommandTimeout = 600;
                ds = new DataSet();
                sda.Fill(ds, tbx);
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("获取DataSet失败", ex.Source, ex.Message);
                return null;
            }
            return ds;
        }
        public DataSet GetDataset_SQL(string sql, SqlParameter[] paramer, string tbx)
        {
            DataSet ds = null;
            try
            {
                if (strConn.Trim() == "")
                {
                    return null;
                }

                SqlDataAdapter sda = new SqlDataAdapter(sql, strConn);
                if (paramer != null)
                {
                    sda.SelectCommand.Parameters.AddRange(paramer);
                }
                sda.SelectCommand.CommandTimeout = 600;
                ds = new DataSet();
                sda.Fill(ds, tbx);
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("获取DataSet失败", ex.Source, ex.Message);
                return null;
            }
            return ds;
        }
        /// <summary>
        /// 获取分页DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="tbx"></param>
        /// <param name="orderColumn"></param>
        /// <param name="pageSize"></param>
        /// <param name="firstIndex"></param>
        /// <returns></returns>
        public DataSet GetDatasetByPage(string sql, string tbx, string orderColumn = "id", string pageSize = "20", string firstIndex = "0")
        {
            DataSet ds = null;
            string sqlx = "";

            try
            {
                // 分页: {{pageSize}},每页条数; {{firstIndex}},第多少条开始; {{orderColumn}},表中排序字段; {{SQL}},查询数据的SQL语句
                // select top {{pageSize}} o.* 
                //   from (select row_number() over(order by {{orderColumn}}) as rownumber,* from ({{SQL}}) as o 
                //  where rownumber>{{firstIndex}}

                sqlx = " select top {{pageSize}} o.* " +
                       " from (select row_number() over(order by {{orderColumn}} desc) as rownumber,* from ({{SQL}}) as tb) as o " +
                       " where rownumber>{{firstIndex}} ";
                sqlx = sqlx.Replace("{{SQL}}", sql);
                sqlx = sqlx.Replace("{{orderColumn}}", orderColumn);
                sqlx = sqlx.Replace("{{pageSize}}", pageSize);
                sqlx = sqlx.Replace("{{firstIndex}}", firstIndex);

                ds = GetDataset_SQL(sqlx, tbx);
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("获取分页数据失败", ex.Source, ex.Message);
                return null;
            }

            return ds;
        }
        /// <summary>
        /// SqlDataReader
        /// </summary>
        /// <param name="strConn"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        //public SqlDataReader GetDataReader(string strConn, string sql)
        //{
        //    SqlConnection sConn = null;
        //    SqlDataReader sdr = null;
        //    try
        //    {
        //        if (strConn.Trim() == "")
        //        {
        //            return null;
        //        }

        //        sConn = new SqlConnection(strConn);
        //        sConn.Open();

        //        SqlCommand cmd = new SqlCommand(sql, sConn);
        //        sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogMsg.CreateErrLog("获取SqlDataReader失败", ex.Source, ex.Message);
        //        return null;
        //    }
        //    return sdr;
        //}
        public SqlDataReader GetDataReader(string sql, SqlParameter[] ps)
        {
            SqlDataReader sdr = null;
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = sql;
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        }
                        catch (Exception ex)
                        {
                            ErrorLogMsg.CreateErrLog("获取SqlDataReader失败", ex.Source, ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("执行ExcuteSql失败", ex.Source, ex.Message);
            }
            return sdr;
        }
        public int ExcuteSql(string sql)
        {
            Int32 flag = -1;
            try
            {
                if (strConn.Trim() == "")
                {
                    return flag;
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = sql;
                            cmd.Transaction = conn.BeginTransaction();
                            flag = cmd.ExecuteNonQuery();
                            cmd.CommandTimeout = 600;
                            cmd.Transaction.Commit();
                        }
                        catch
                        {
                            cmd.Transaction.Rollback();
                            flag = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                flag = -1;
                ErrorLogMsg.CreateErrLog("获取SqlDataReader失败", ex.Source, ex.Message);
            }

            return flag;
        }

        public DataTable GetDataTable(string sql, SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = sql;
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            cmd.Transaction = conn.BeginTransaction();
                            SqlDataReader sr = cmd.ExecuteReader();
                            dt.Load(sr);
                            sr.Close();
                            cmd.CommandTimeout = 600;
                            cmd.Transaction.Commit();
                        }
                        catch
                        {
                            cmd.Transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("执行ExcuteSql失败", ex.Source, ex.Message);
            }
            return dt;
        }
        public int ExcuteSql(string sql, SqlParameter[] ps)
        {
            Int32 flag = -1;
            try
            {
                if (strConn.Trim() == "")
                {
                    return flag;
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = sql;
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            cmd.Transaction = conn.BeginTransaction();
                            flag = cmd.ExecuteNonQuery();
                            cmd.CommandTimeout = 600;
                            cmd.Transaction.Commit();
                            cmd.Dispose();
                        }
                        catch (Exception ex)
                        {
                            cmd.Transaction.Rollback();
                            cmd.Dispose();
                            flag = -1;
                            ErrorLogMsg.CreateErrLog("SQL执行异常", ex.Source, ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                flag = -1;
                ErrorLogMsg.CreateErrLog("执行ExcuteSql失败", ex.Source, ex.Message);
            }

            return flag;
        }
        //获取首行首列值的方法
        public object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        //cmd.Transaction = conn.BeginTransaction();
                        if (ps != null)
                        {
                            cmd.Parameters.AddRange(ps);
                        }
                        // cmd.CommandTimeout = 600;
                        //cmd.Transaction.Commit();
                        //执行命令，获取查询结果中的首行首列的值，返回
                        return cmd.ExecuteScalar();
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("执行ExecuteScalar失败", ex.Source, ex.Message);
                return -1;
            }

        }

        public bool DbRestoreX(string cnnStr, string fromFile, string dbName = "MyDataBase")
        {
            //杀死原来所有的数据库连接进程
            SqlConnection cnn = new SqlConnection
            {
                ConnectionString = cnnStr
            };
            cnn.Open();

            string sql = "SELECT spid FROM sysprocesses,sysdatabases WHERE sysprocesses.dbid=sysdatabases.dbid AND sysdatabases.Name='" + dbName + "' ";
            SqlCommand cmdt = new SqlCommand(sql, cnn);
            SqlCommand cmdx;
            SqlDataReader dr;

            ArrayList list = new ArrayList();
            try
            {
                dr = cmdt.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.GetInt16(0) != 51)
                    {
                        //list.Add(dr.GetInt16(0));

                        cmdx = new SqlCommand(string.Format("KILL {0}", dr.GetInt16(0)), cnn);
                        cmdx.ExecuteNonQuery();
                    }
                }

                dr.Close();
            }
            catch (SqlException ex)
            {
                ErrorLogMsg.CreateErrLog("获取DbRestoreX失败", ex.Source, ex.Message);
                return false;
            }
            finally
            {
                cnn.Close();
            }

            //这里一定要是master数据库，而不能是要还原的数据库，因为这样便变成了有其它进程,占用了数据库。
            string cnnStrT = @"Data Source=.;Initial Catalog=master;User ID=sa;pwd =";
            string BACKUP = String.Format("RESTORE DATABASE {0} FROM DISK = N'{1}' WITH NORECOVERY,REPLACE", dbName, fromFile);

            SqlConnection conn = new SqlConnection(cnnStrT);
            SqlCommand cmd = new SqlCommand(BACKUP, conn);
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
                //Application.Exit();
            }
            catch (SqlException ex)
            {
                ErrorLogMsg.CreateErrLog("执行ExcuteSql失败", ex.Source, ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }


        public bool IsDataGet(string tb, string wv)
        {
            string sql = "";
            object obj = null;

            sql = string.Format("select count(*) from [{0}] where {1} ", tb, wv);
            if (GetScalar(ref obj, sql) < 0)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(obj);
            }
        }

        public string GetDataValue(string tb, string fb, string wv)
        {
            string sql = "";
            object obj = null;
            int intRes = -1;

            sql = string.Format("select {0} from [{1}] where {2} ", fb, tb, wv);
            intRes = GetScalar(ref obj, sql);

            if (intRes == -1)
            {
                return "";
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        #endregion
        #region combobox和数据库中数据表字段关联
        public int SetComboValue(ComboBox oCob, string tb, string fb, string ov)
        {
            string sql = "";
            int intRes = -1;

            sql = string.Format("select distinct {0} from [{1}] {2} ", fb, tb, ov);
            DataSet ds = GetDataset(sql, "cobItems");

            if (ds != null)
            {
                oCob.DataSource = null;
                oCob.DataSource = ds.Tables["cobItems"];
                oCob.DisplayMember = fb;
                oCob.ValueMember = fb;
                //ds.Dispose();
                ds = null;
                intRes = 0;
            }

            return intRes;
        }
        #endregion combobox和数据库中数据表字段关联
        /// <summary>
        /// 根据查询语句，获取表中记录的条数
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetTableRecordCount(string tableName)
        {
            string queryString = string.Format("SELECT count(*)  FROM {0}", tableName);

            try
            {
                if (strConn.Trim() == "")
                {
                    return -1;
                }

                using (SqlConnection connection = conn)
                {
                    using (SqlCommand cmd = new SqlCommand(queryString, connection))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception e)
            {
                string s = e.Message;
                ErrorLogMsg.CreateErrLog("数据库读取异常", "0D04", s);
                return 0;
            }

        }
    }
}
