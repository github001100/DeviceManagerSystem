using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace XL_OMS_WebClient.Models
{
    [DisplayName("计划")]
    public partial class Plan
    {
        public Plan()
        {
            SerialNumber = "序号";
        }
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [DisplayName("序号")]
        public string SerialNumber { get; set; }
        [DisplayName("检修日期")]
        public DateTime? OverhaulDate { get; set; }
        [DisplayName("检修单位")]
        public string OverhaulCompany { get; set; }
        [DisplayName("工序名称")]
        public string ProcedureName { get; set; }
        [DisplayName("部件名称")]
        public string PartsName { get; set; }
        [DisplayName("任务计划")]
        public string TaskPlans { get; set; }
        [DisplayName("待检数")]
        public string OverhaulQuantity { get; set; }
        [DisplayName("合格品数")]
        public string QualifiedQuantity { get; set; }
        [DisplayName("不合格数")]
        public string UnqualifiedQuantity { get; set; }
        [DisplayName("开始时间")]
        public DateTime? StartTime { get; set; }
        [DisplayName("合格率")]
        public string PassRate { get; set; }
        [DisplayName("工作进度")]
        public string SpeedOfProgress { get; set; }
        [DisplayName("其他")]
        public string Others { get; set; }
        [DisplayName("更新日期")]
        public DateTime? UpdateTime { get; set; }
        [DisplayName("工作组")]
        public string WorkGroup { get; set; }
        [DisplayName("新增数量")]
        public string NewCount { get; set; }
        [DisplayName("拆分数量")]
        public string DepartCount { get; set; }
    }
}
