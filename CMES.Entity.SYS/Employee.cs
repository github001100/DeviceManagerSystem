using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMES.Entity.SYS
{
    public class Employee
    {
        #region 实体成员
        /// <summary>
        /// 编号
        /// </summary>
        /// <returns></returns>
        public System.Int32? Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        /// <returns></returns>
        public string BirthDay { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        /// <returns></returns>
        public string Depart { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        /// <returns></returns>
        public string Job { get; set; }
        /// <summary>
        /// 账户编号
        /// </summary>
        /// <returns></returns>
        public string AccountId { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        /// <returns></returns>
        public string RoleSet { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        public string Founder { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? ModificationTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        /// <returns></returns>
        public string Modifier { get; set; }
        #endregion
    }
}
