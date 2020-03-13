using System;

namespace CMES.Entity.SYS
{
    /// <summary>
    /// S_UserInfo实体字段
    /// </summary>
    public class S_UserInfo
    {
        /// <summary>
        /// 当前内容
        /// </summary>
        public override string ToString()
        {
            return "当前内容:" + UserID + "," + UserName + "," + Pwd + "," + WorkerCode + "," + FaceCode + "," + FigureCode ;
        }
        /// <summary>
        /// 管理员标记 0=普通用户 1= 管理用户
        /// </summary>
        public string Role { set; get; }

       
        /// <summary>
        /// 登录人IP
        /// </summary>
        public string ClientIP { set; get; }
        /// <summary>
        /// userID 
        /// </summary>
        public int UserID { set; get; }

        /// <summary>
        /// userName 
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// pwd 
        /// </summary>
        public string Pwd { set; get; }
        /// <summary>
        /// 职务（总经理、车间主任、部长、工长、员工等)
        /// </summary>
        public string Duty { set; get; }

        /// <summary>
        /// cDepCode 
        /// </summary>
        public string Dept { set; get; }

        /// <summary>
        /// cDepName 
        /// </summary>
        public string Gender { set; get; }
        /// <summary>
        /// workerType 
        /// </summary>
        public string WorkerType { set; get; }
        /// <summary>
        /// isUse 
        /// </summary>
        public int EnableMark { set; get; }

        /// <summary>
        /// 卡 
        /// </summary>
        public string WorkerCode { set; get; }

        /// <summary>
        /// 脸
        /// </summary>
        public string FaceCode { set; get; }
        /// <summary>
        /// 指纹 
        /// </summary>
        public string FigureCode { set; get; }

        /// <summary>
        /// 登录方式 0=账户密码登录 1= 刷卡/刷脸/指纹登录
        /// </summary>
        public int LoginType { set; get; }
       
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime OpeTime { set; get; }

    }


}
