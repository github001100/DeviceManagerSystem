using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using CMES.Data;
using CMES.Entity;
using CMES.Entity.SYS;

namespace CMES.Controller.SYS
{
    public class UserSynchronization
    {        
        //获取本地用户列表
        public List<S_UserInfo> GetUserByLocal(DatabaseSQLite sdq)
        {
            DataTable dt = new DataTable();
            string sql = "select id,name,workerCode,gender,dept,duty,workerType,loginPwd,role,faceCode,figureCode,enableMark,clientIP,loginType,opeTime from sys_user where enableMark = 0";
            //sdq.Open();
            dt = sdq.GetDataTable(sql, null);
            //sdq.Dispose();
            return ChangeModel(dt);
        }
        public List<string> GetUserIdByLocal(DatabaseSQLite sdq)
        {
            DataTable dt = new DataTable();
            string sql = "select id,name,workerCode from sys_user where enableMark = 0";
            //sdq.Open();
            dt = sdq.GetDataTable(sql, null);
            //sdq.Dispose();
            return ChangeString(dt);
        }
        private List<string> ChangeString(DataTable dt)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0].ToString());
            }
            return list;
        }
         private List<S_UserInfo> ChangeModel(DataTable dt)
        {
            List<S_UserInfo> listInfo = new List<S_UserInfo>();
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                S_UserInfo suInfo = new S_UserInfo
                {
                    UserID = Convert.ToInt32(dt.Rows[i][0].ToString()),
                    UserName = dt.Rows[i][1].ToString(),
                    WorkerCode = dt.Rows[i][2].ToString(),
                    Gender = dt.Rows[i][3].ToString(),                    
                    Duty = dt.Rows[i][5].ToString(),
                    WorkerType = dt.Rows[i][6].ToString(),
                    Pwd = dt.Rows[i][7].ToString(),
                    Role = dt.Rows[i][8].ToString(),
                    EnableMark = Convert.ToInt32(dt.Rows[i][11].ToString()),                    
                    LoginType = 0
                };
                listInfo.Add(suInfo);
            }
             
            return listInfo;        
        }
         public void InsertUser(S_UserInfo su, DatabaseSQLite sdq)
         {
             
             string role = "";
             string workerCode = "";
             string name = "";
             string gender = "";
             string dept = "";
             string duty = "";
             string workerType = "";
             string loginPwd ="";
             int enableMark = 0;
             string clientIP = "";
             string faceCode = "";
             string figureCode = "";
             string opeTime = "";
             
             if (su.Role!=null)
             {
                 role = su.Role;
             }
             if(su.WorkerCode!=null){
                 workerCode = su.WorkerCode;
             }
             if(su.UserName!=null){
                 name = su.UserName;
             }
             if(su.Gender!=null){
                 gender = su.Gender;
             }
             if(su.Dept!=null){
                 dept = su.Dept;
             }
             if(su.Duty!=null){
                 duty = su.Duty;
             }
             if(su.WorkerType!=null){
                 workerType = su.WorkerType;
             }
             if (su.ClientIP!=null)
             {
                 clientIP = su.ClientIP;
             }
             if (su.FaceCode!=null)
             {
                 faceCode = su.FaceCode;
              }
             if (su.FigureCode != null) {
                 figureCode = su.FigureCode;
             }
             if(su.Pwd!=null){
                loginPwd = su.Pwd;
             }
             if (su.OpeTime != null && su.OpeTime.ToString() != string.Empty)
             {
                 opeTime = su.OpeTime.ToString();
             }
             else {
                 opeTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
             }
             string sql = "INSERT INTO sys_user (workerCode,name,gender,dept,duty,workerType,loginPwd,role,faceCode,figureCode,enableMark,clientIP,opeTime)"
                 + " VALUES(@workerCode,@name,@gender,@dept,@duty,@workerType,@loginPwd,@role,@faceCode,@figureCode,@enableMark,@clientIP,@opeTime)";
             
                 SQLiteParameter[] spr = { 
                    //new SQLiteParameter("@id",id),//32位GUID中间不包含-后面加上时间戳
                    new SQLiteParameter("@workerCode",workerCode), 
                    new SQLiteParameter("@name",name),
                    new SQLiteParameter("@gender",gender),
                    new SQLiteParameter("@dept",dept),
                    new SQLiteParameter("@duty",duty),
                    new SQLiteParameter("@workerType",workerType),
                    new SQLiteParameter("@loginPwd",loginPwd),
                    new SQLiteParameter("@role",role),
                    new SQLiteParameter("@faceCode",faceCode),
                    new SQLiteParameter("@figureCode",figureCode),
                    new SQLiteParameter("@enableMark",enableMark),
                    new SQLiteParameter("@clientIP",clientIP),
                    new SQLiteParameter("@opeTime",opeTime)
                                       };
                 sdq.ExecuteNonQuery(sql, spr);
         }
         public void UpdateUser(S_UserInfo su, DatabaseSQLite sdq)
         {
             string role = "";
             string workerCode = "";
             string name = "";
             string gender = "";
             string dept = "";
             string duty = "";
             string workerType = "";
             string loginPwd = "";
             int enableMark = 0;
             string clientIP = "";
             string faceCode = "";
             string figureCode = "";
             string opeTime = "";
             if (su.Role != null)
             {
                 role = su.Role;
             }
             if (su.WorkerCode != null)
             {
                 workerCode = su.WorkerCode;
             }
             if (su.UserName != null)
             {
                 name = su.UserName;
             }
             if (su.Gender != null)
             {
                 gender = su.Gender;
             }
             if (su.Dept != null)
             {
                 dept = su.Dept;
             }
             if (su.Duty != null)
             {
                 duty = su.Duty;
             }
             if (su.WorkerType != null)
             {
                 workerType = su.WorkerType;
             }
             if (su.ClientIP != null)
             {
                 clientIP = su.ClientIP;
             }
             if (su.FaceCode != null)
             {
                 faceCode = su.FaceCode;
             }
             if (su.FigureCode != null)
             {
                 figureCode = su.FigureCode;
             }
             if (su.Pwd != null)
             {
                 loginPwd = su.Pwd;
             }
             if (su.OpeTime != null && su.OpeTime.ToString() != string.Empty)
             {
                 opeTime = su.OpeTime.ToString();
             }
             else {
                 opeTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
             }
             string sql = "Update sys_user set workerCode = @workerCode,name = @name,gender = @gender,dept = @dept,duty = @duty,workerType = @workerType,loginPwd = @loginPwd,"
                 + "role = @role,faceCode = @faceCode,figureCode = @figureCode,enableMark = @enableMark,clientIP = @clientIP,opeTime = @opeTime "
                 + " where id = @id ";
                 SQLiteParameter[] spr = { 
                    new SQLiteParameter("@workerCode",workerCode), 
                    new SQLiteParameter("@name",name),
                    new SQLiteParameter("@gender",gender),
                    new SQLiteParameter("@dept",dept),
                    new SQLiteParameter("@duty",duty),
                    new SQLiteParameter("@workerType",workerType),
                    new SQLiteParameter("@loginPwd",loginPwd),
                    new SQLiteParameter("@role",role),
                    new SQLiteParameter("@faceCode",faceCode),
                    new SQLiteParameter("@figureCode",figureCode),
                    new SQLiteParameter("@enableMark",enableMark),
                    new SQLiteParameter("@clientIP",clientIP),
                    new SQLiteParameter("@opeTime",opeTime),
                    new SQLiteParameter("@id",su.UserID)
                                       };                 
                 sdq.ExecuteNonQuery(sql, spr);
         }
         public void DelUser(string userId,string opeTime, DatabaseSQLite sdq)
         {
             if (opeTime == null ||opeTime.Trim().Equals(string.Empty))
             {
                 opeTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
             }
             string sql = "Update sys_user set enableMark = 1,opeTime = @opeTime "
                 + " where id = @id ";
             
                 SQLiteParameter[] spr = { 
                    new SQLiteParameter("@opeTime",opeTime),
                    new SQLiteParameter("@id",userId)
                                       };                
                 sdq.ExecuteNonQuery(sql, spr);
         }
         private string GetTimeStamp() {
             TimeSpan ts = DateTime.UtcNow - new DateTime(1970,1,1,0,0,0,0);
             return Convert.ToInt64(ts.TotalSeconds).ToString();
         }
         public string GetUserOpeTime(string userId, DatabaseSQLite sdq)
         {
             string sql = "select opeTime from sys_user where id = @id ";            
                 SQLiteParameter[] spr = { 
                    new SQLiteParameter("@id",userId)};
                 DataTable dt = sdq.GetDataTable(sql, spr);
                 if (dt != null && dt.Rows.Count > 0)
                 {
                     return dt.Rows[0][0].ToString();
                 }
                 else {
                     return null;
                 }
         }
    }
}
