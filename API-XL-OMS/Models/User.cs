using System;
using System.Collections.Generic;

namespace API_XL_OMS.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Cname { get; set; }
        public string Ename { get; set; }
        public string Crole { get; set; }
        public string Erole { get; set; }
        public string Lock { get; set; }
        public string Workgw { get; set; }
        public string Workdz { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Qtxx { get; set; }
        public string Pwd { get; set; }
    }
}
