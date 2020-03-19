using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using CMES.Data;
using CMES.Entity.SYS;
using CMES.NET;
using Newtonsoft.Json;
using CMES.Utility;

namespace CMES.Controller.SYS
{

    public class UserLogin
    {
        XMLReadUser xru = new XMLReadUser();
        #region 本地登陆
        public S_UserInfo CheckLoginByLocal(string userId, DatabaseSQLite sdq)
        {
            //sdq.Open();
            string sql = "select t.name,t.gender,t.dept,t.duty,t.workerType,t.loginPwd,t.role,t.id,t.workerCode from sys_user t where t.enableMark = 0 and t.name = @userName ";
            SQLiteParameter[] paramer = {
                new SQLiteParameter("@userName",userId)
            };
            DataTable dt = sdq.GetDataTable(sql, paramer);
            //sdq.Dispose();
            if (dt.Rows.Count > 0)
            {
                S_UserInfo s_u = new S_UserInfo()
                {
                    UserName = dt.Rows[0][0].ToString(),
                    Gender = dt.Rows[0][1].ToString(),
                    Dept = dt.Rows[0][2].ToString(),
                    Duty = dt.Rows[0][3].ToString(),
                    WorkerType = dt.Rows[0][4].ToString(),
                    Pwd = dt.Rows[0][5].ToString(),
                    Role = dt.Rows[0][6].ToString(),
                    UserID = Convert.ToInt32(dt.Rows[0][7].ToString()),
                    WorkerCode = dt.Rows[0][8].ToString()
                };
                s_u.LoginType = 0;
                return s_u;
            }
            else
            {
                return null;
            }

        }
        public S_UserInfo CheckLoginByIDByLocal(string userId, DatabaseSQLite sdq)
        {
            if (!string.Empty.Equals(userId))
            {
                //sdq.Open();
                string sql = "select t.name,t.gender,t.dept,t.duty,t.workerType,t.loginPwd,t.role,t.workerCode,t.faceCode,t.figureCode,t.id from sys_user t where t.enableMark = 0 and  t.workerCode = @workerCode ";
                SQLiteParameter[] paramer = {
                new SQLiteParameter("@workerCode",userId)
            };
                DataTable dt = sdq.GetDataTable(sql, paramer);
                //sdq.Dispose();
                if (dt.Rows.Count > 0)
                {
                    S_UserInfo s_u = new S_UserInfo()
                    {
                        UserName = dt.Rows[0][0].ToString(),
                        Gender = dt.Rows[0][1].ToString(),
                        Dept = dt.Rows[0][2].ToString(),
                        Duty = dt.Rows[0][3].ToString(),
                        WorkerType = dt.Rows[0][4].ToString(),
                        Pwd = dt.Rows[0][5].ToString(),
                        Role = dt.Rows[0][6].ToString(),
                        WorkerCode = dt.Rows[0][7].ToString(),
                        FaceCode = dt.Rows[0][8].ToString(),
                        FigureCode = dt.Rows[0][9].ToString(),
                        UserID = Convert.ToInt32(dt.Rows[0][10].ToString())
                    };
                    s_u.LoginType = 1;
                    return s_u;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        public S_UserInfo GetUserByFaceID(string faceID, DatabaseSQLite sdq)
        {
            //sdq.Open();
            string sql = "select t.name,t.gender,t.dept,t.duty,t.workerType,t.loginPwd,t.role,t.workerCode,t.faceCode,t.figureCode,t.id from sys_user t where t.enableMark = 0 and t.faceCode = @faceCode ";
            SQLiteParameter[] paramer = {
                new SQLiteParameter("@faceCode",faceID)
            };
            DataTable dt = sdq.GetDataTable(sql, paramer);
            //sdq.Dispose();
            if (dt.Rows.Count > 0)
            {
                S_UserInfo s_u = new S_UserInfo()
                {
                    UserName = dt.Rows[0][0].ToString(),
                    Gender = dt.Rows[0][1].ToString(),
                    Dept = dt.Rows[0][2].ToString(),
                    Duty = dt.Rows[0][3].ToString(),
                    WorkerType = dt.Rows[0][4].ToString(),
                    Pwd = dt.Rows[0][5].ToString(),
                    Role = dt.Rows[0][6].ToString(),
                    WorkerCode = dt.Rows[0][7].ToString(),
                    FaceCode = dt.Rows[0][8].ToString(),
                    FigureCode = dt.Rows[0][9].ToString(),
                    UserID = Convert.ToInt32(dt.Rows[0][10].ToString())
                };
                s_u.LoginType = 1;
                return s_u;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region 更新用户密码
        public int UpdateUserPwd(S_UserInfo su, DatabaseSQLite dbsqlite)
        {
            try
            {
                string sql = "Update sys_user set loginPwd = @loginPwd,opeTime = @opeTime where id = @id ";
                SQLiteParameter[] spr = {
                               new SQLiteParameter("@loginPwd",su.Pwd),
                               new SQLiteParameter("@opeTime",System.DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss")),
                               new SQLiteParameter("@id",su.UserID)
                                        };
                dbsqlite.ExecuteNonQuery(sql, spr);
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }


        }

        public int UpdateUserPwdApi(EmployeeApi employeeApi)
        {
            ApiResult apiresult = new ApiResult();
            int report = -1;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("AccountId",employeeApi.AccountId),
                new KeyValuePair<string, string>("LoginPwd",employeeApi.LoginPwd),
                new KeyValuePair<string,string>("SecretKey",employeeApi.SecretKey)
            };
            string mearResult = HttpHelper.DOPOST("AccountUrl", "Hr_Employee/UpdatePwd", list);
            if (mearResult != null && !mearResult.Equals(string.Empty))
            {
                try
                {
                    apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);
                    report = apiresult.Code;
                }
                catch
                {
                }
            }
            return report;
        }
        #endregion
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ComboboxEx> GetEmployeeCode()
        {
            List<ComboboxEx> list = new List<ComboboxEx>();
            ApiResult apiresult = new ApiResult();
            string mearResult = HttpHelper.DOGET("AccountUrl", "Hr_Employee");
            //判断响应结果
            if (mearResult != null && !mearResult.Equals(string.Empty))
            {
                try
                {
                    apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);
                    if (apiresult.Code == 0)
                    {
                        List<EmployeeApi> archInfoList = JsonConvert.DeserializeObject<List<EmployeeApi>>(apiresult.Data.ToJson());
                        if (archInfoList != null && archInfoList.Count > 0)
                        {
                            foreach (var item in archInfoList)
                            {
                                ComboboxEx cbx = new ComboboxEx()
                                {
                                    Id = item.AccountId,
                                    Text = item.UserName + "(" + item.AccountId + ")"
                                };
                                list.Add(cbx);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogMsg.CreateErrLog("Net异常", ex.Source, ex.Message);
                }

            }
            return list;
        }
        #region 登录信息保存至xml
        public void SetUserXML(EmployeeApi su)
        {
            //XElement xe =  XElement.Load(ConfigUser);
            //xe.SetElementValue("userID", su.AccountId);
            //xe.SetElementValue("userName", su.UserName);
            //xe.SetElementValue("duty", su.Job);
            //xe.SetElementValue("workerCode", su.AccountId);
            //xe.SetElementValue("workerType", su.WorkType);
            //xe.SetElementValue("dept", su.Depart);
            //xe.SetElementValue("role", su.Roles);
            //xe.Save(ConfigUser);
            xru.SetXML("userID", su.AccountId);
            xru.SetXML("userName", su.UserName);
            xru.SetXML("duty", su.Job);
            xru.SetXML("workerCode", su.AccountId);
            xru.SetXML("workerType", su.WorkType);
            xru.SetXML("dept", su.Depart);
            xru.SetXML("role", su.Roles);
        }
        //保存token
        public void SetToken(string Token)
        {
            //XElement xe = XElement.Load(ConfigUser);
            // xe.SetElementValue("Token", Token);
            //xe.Save(ConfigUser);
            xru.SetXML("Token", Token);
        }
        #endregion
        #region 从xml读取用户信息
        public EmployeeApi GetUserXLM()
        {
            //XElement xe = XElement.Load(ConfigUser);
            //    EmployeeApi su = new EmployeeApi
            //    {
            //        //UserID = Convert.ToInt32(GetElementValue(xe, "userID", "0")),
            //        UserName = GetElementValue(xe, "userName", "0"),
            //        AccountId = GetElementValue(xe, "workerCode", "0"),
            //        WorkType = GetElementValue(xe, "workerType", "0"),
            //        Job = GetElementValue(xe, "duty", "0"),
            //        Depart = GetElementValue(xe, "dept", "0"),
            //        Roles = GetElementValue(xe, "role", "0")
            //};
            EmployeeApi su = new EmployeeApi
            {
                //UserID = Convert.ToInt32(GetElementValue(xe, "userID", "0")),
                UserName = xru.LoadXML("userName", "0"),
                AccountId = xru.LoadXML("workerCode", "0"),
                WorkType = xru.LoadXML("workerType", "0"),
                Job = xru.LoadXML("duty", "0"),
                Depart = xru.LoadXML("dept", "0"),
                Roles = xru.LoadXML("role", "0")
            };
            return su;
        }

        public string GetFristForm()
        {
            return xru.LoadXML("fristForm", "1");
        }

        public string GetToken()
        {
            //XElement xe = XElement.Load(ConfigUser);
            //return GetElementValue(XElement.Load(ConfigUser), "Token", "");
            return xru.LoadXML("Token", "");
        }
        #endregion
        //public string GetValue(string elemName, string def) {
        //    XElement xe = XElement.Load(ConfigUser);
        //    return GetElementValue(xe, elemName, def);
        //}
        //static string GetElementValue(XElement xe, string elemName, string def)
        //{
        //    try
        //    {
        //        XElement xElem = xe.Element(elemName);
        //        if (null != xElem)
        //        {
        //            return xElem.Value;
        //        }
        //        return def;
        //    }
        //    catch
        //    {
        //        return def;
        //    }
        //}

        //static string configUser = string.Empty;
        //public static string ConfigUser
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(configUser))
        //        {
        //            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        //            //CAYA_MES\View\quality
        //            configUser = Path.Combine(path, @"XML\UserInfo.xml");
        //            //configFileName = Path.Combine(path, @"CAYA_MES\MSPCS.xml");
        //            configUser = configUser.Substring(6);
        //        }
        //        return configUser;
        //    }
        //}

        public IEnumerable<ComboboxEx> GetUserNameToCB(DatabaseSQLite dsql)
        {
            List<ComboboxEx> list = new List<ComboboxEx>();
            string sql = "select name as id,workerCode as uname from sys_user where enableMark !=1 and role = 'SPC操作员' or workerType in('检查员') order by workerCode asc";
            //SQLiteParameter[] paramer = new SQLiteParameter[] { };
            //dsql.Open();
            DataTable dt = dsql.GetDataTable(sql, null);
            //dsql.Dispose();
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
        /// <summary>
        /// 通过userID 找到用户信息
        /// 作者：FUSANJIE
        /// Date:2020.03.13.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public EmployeeApi GetUserByAccount(string userID)
        {
            EmployeeApi employee = new EmployeeApi();
            ApiResult apiresult = new ApiResult();
            List<KeyValuePair<string, string>> listpair = new List<KeyValuePair<string, string>>() {
                 new KeyValuePair<string, string>("AccountId",userID)
            };

            string mearResult = HttpHelper.DOPOST("AccountUrl", "Hr_Employee/PostUserInfo", listpair);
            if (mearResult != null && !mearResult.Equals(string.Empty))
            {
                apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);
                if (apiresult.Code == 0 && apiresult.Data != null)
                {
                    employee = JsonConvert.DeserializeObject<EmployeeApi>(apiresult.Data.ToString());

                }
            }
            return employee;
        }

    }
}
