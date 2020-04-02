using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMES.Entity.SYS
{
    class JXJHZTJKEntity
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public Int32 id { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 检修日期
        /// </summary>
        /// <returns></returns>
        public string OverhaulDate { get; set; }
        /// <summary>
        /// OverhaulCompany
        /// </summary>
        /// <returns></returns>
        public string OverhaulCompany { get; set; }
        /// <summary>
        /// ProcedureName
        /// </summary>
        /// <returns></returns>
        public string ProcedureName { get; set; }
        /// <summary>
        /// PartsName
        /// </summary>
        /// <returns></returns>
        public string PartsName { get; set; }
        /// <summary>
        /// TaskPlans
        /// </summary>
        /// <returns></returns>
        public string TaskPlans { get; set; }
        /// <summary>
        /// OverhaulQuantity
        /// </summary>
        /// <returns></returns>
        public string OverhaulQuantity { get; set; }
        /// <summary>
        /// QualifiedQuantity
        /// </summary>
        /// <returns></returns>
        public string QualifiedQuantity { get; set; }
        /// <summary>
        /// UnqualifiedQuantity
        /// </summary>
        /// <returns></returns>
        public string UnqualifiedQuantity { get; set; }
        /// <summary>
        /// StartTime
        /// </summary>
        /// <returns></returns>
        public string StartTime { get; set; }
        /// <summary>
        /// PassRate
        /// </summary>
        /// <returns></returns>
        public string PassRate { get; set; }
        /// <summary>
        /// SpeedOfProgress
        /// </summary>
        /// <returns></returns>
        public string SpeedOfProgress { get; set; }
        /// <summary>
        /// Others
        /// </summary>
        /// <returns></returns>
        public string Others { get; set; }
        /// <summary>
        /// UpdateTime
        /// </summary>
        /// <returns></returns>
        public string UpdateTime { get; set; }
        #endregion

    }
}
