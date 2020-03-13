using CMES.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
namespace CMES.Data
{
    /// <summary>
    /// 数据库类。操作数据库SQLite
    /// </summary>
    public class DatabaseSQLite : IDisposable
    {
        /// <summary>
        /// 数据连接
        /// </summary>
        private SQLiteConnection Connection = null;
        #region  本地数据库连接
        // 1 定位数据文件
        static readonly string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLiteDB"].ConnectionString.ToString();       
        static string dbFile = Path.Combine(path, connectionString);
        readonly string SQLitePath = string.Format("Data Source={0}", dbFile.Substring(6));
        public bool Open()
        {
            try
            {
                Connection = new SQLiteConnection(SQLitePath);
                Connection.Open();

                //ConstructFastCommand();
                return true;
            }
            catch (Exception e)
            {
                ErrorLogMsg.CreateErrLog("打开数据库链接错误！", "0D00", e.Message);
                throw new Exception("打开数据库链接错误！" + e.Message);
            }
        }

        public bool Close()
        {
            if (null == Connection || Connection.State != System.Data.ConnectionState.Open)
                return true;

            try
            {
                //DestoryFastCommand();
                Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                ErrorLogMsg.CreateErrLog("关闭数据库错误！", "0D10", e.Message);
                throw new Exception("关闭数据库错误！");
            }
        }

        public void Dispose()
        {
            Close();
        }

        #endregion
        #region 通用方法
        SQLiteCommand NewCommand()
        {
            return new SQLiteCommand(Connection);
        }


        SQLiteCommand NewCommand(string commandText)
        {
            return new SQLiteCommand(commandText, Connection);
        }

        /// <summary>
        /// 根据查询语句，获取表中记录的条数
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetTableRecordCount(string tableName)
        {
            string queryString = string.Format("SELECT count(*)  FROM {0}", tableName);
            using (SQLiteCommand cmd = NewCommand(queryString))
            {
                try
                {
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        return dr.GetInt32(0);
                    }
                    dr.Close();
                    return 0;
                }
                catch (System.Data.SQLite.SQLiteException e)
                {
                    string s = e.Message;
                    ErrorLogMsg.CreateErrLog("数据库读取异常", "0D04", s);
                    return 0;
                }
            }
        }
        /// <summary>
        /// 得到新插入项的Id
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        int GetNewId(SQLiteCommand cmd)
        {
            int i = -1;
            try
            {
                cmd.CommandText = "select last_insert_rowid()";
                SQLiteDataReader sr = cmd.ExecuteReader();
                if (sr.Read())
                {
                    i = Convert.ToInt32(sr[0]);
                }
                sr.Close();
            }
            catch (SQLiteException e)
            {
                string error = e.Message;
                i = -1;
            }

            return i;
        }
        #endregion
        #region 得到所有的名称
        /// <summary>
        ///
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="names"></param>
        /// <returns></returns>
        string[] GetPropertyValues(string tableName, string propertyName)
        {
            int count = GetTableRecordCount(tableName);
            if (0 == count)
            {
                return null;
            }

            List<string> names = new List<string>();

            string queryString = string.Format("SELECT [{0}]  FROM [{1}]  order by [{2}]", propertyName, tableName, propertyName);

            using (SQLiteCommand cmd = NewCommand(queryString))
            {
                try
                {
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string name = dr[propertyName].ToString();
                        if (string.IsNullOrEmpty(name))
                            continue;

                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                    }

                    return names.ToArray();
                }
                catch (SQLiteException e)
                {
                    string errorMsg = e.Message;
                    ErrorLogMsg.CreateErrLog("数据库读取异常","0D03",errorMsg);
                    return null;
                }
            }
        }
        #endregion
        #region 增删改查
        public DataTable GetDataTable(string sql, params SQLiteParameter[] ps)
        {
            // 1 先构造 DataTable
            DataTable dt = new DataTable(); // DataUtils.ConctructQueryTable();

            using (SQLiteCommand cmd = NewCommand(sql))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    SQLiteDataReader sr = cmd.ExecuteReader();
                    dt.Load(sr);
                    sr.Close();
                    return dt;
                }
                catch (Exception e)
                {
                    //throw e;
                    ErrorLogMsg.CreateErrLog("数据读取异常", "0D01", e.ToString());
                    return null;
                }
            }
        }
        public DataTable GetDataTableByPage(string sql, string orderColumn = "id", string pageSize = "20", string firstIndex = "0")
        {
            DataTable dt = new DataTable();
            string sqlx = "";
            try
            {
                sqlx = sql + "order by {{orderColumn}}  LIMIT {{firstIndex}} OFFSET {{pageSize}}";
                sqlx = sqlx.Replace("{{orderColumn}}", orderColumn);
                sqlx = sqlx.Replace("{{firstIndex}}", pageSize);
                sqlx = sqlx.Replace("{{pageSize}}", (Convert.ToInt32(firstIndex) * Convert.ToInt32(pageSize)).ToString());
                dt = GetDataTable(sqlx);
            }
            catch (Exception ex)
            {
                ErrorLogMsg.CreateErrLog("数据读取异常", "0D02", ex.ToString());
                return dt;
            }
            return dt;

        }
        //执行命令的方法：insert,update,delete
        //params：可变参数，目的是省略了手动构造数组的过程，直接指定对象，编译器会帮助我们构造数组，并将对象加入数组中，传递过来
        public void ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteCommand cmd = NewCommand(sql))
            {
                if (ps != null)
                {
                    //添加参数
                    cmd.Parameters.AddRange(ps);
                }
                //执行命令，并返回受影响的行数
                cmd.Transaction = Connection.BeginTransaction();
                cmd.ExecuteNonQuery();
                cmd.CommandTimeout = 600;
                cmd.Transaction.Commit();
                //return cmd.ExecuteNonQuery();
            }
        }

        //获取首行首列值的方法
        public object ExecuteScalar(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteCommand cmd = NewCommand(sql))
            {
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                //执行命令，获取查询结果中的首行首列的值，返回
                return cmd.ExecuteScalar();
            }
        }
        #endregion
        public SQLiteDataReader GetSQLiteDataReader(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteCommand command = NewCommand(sql))
            {
                try
                {
                    if (ps != null)
                    {
                        command.Parameters.AddRange(ps);
                    }
                    SQLiteDataReader reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return reader;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
