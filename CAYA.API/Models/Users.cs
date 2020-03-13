using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAYA.API.Models
{
    public class Users
    {
        //映射实体类 Users
        public string UserID { get; set; }
        public string Pwd { get; set; }
        public string UserName { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}