using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMES.Entity.SYS
{
    public class EmployeeApi
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Depart { get; set; }
        /// <summary>
        /// 登陆账户
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 工种
        /// </summary>
        public string WorkType { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        public string Roles { get; set; }
        /// <summary>
        /// 脸谱
        /// </summary>
        public string FaceCode { get; set; }
    }
}