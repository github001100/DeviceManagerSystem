using System;
using System.Collections.Generic;

namespace API_XL_OMS.Models
{
    public partial class Plan
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? OverhaulDate { get; set; }
        public string OverhaulCompany { get; set; }
        public string ProcedureName { get; set; }
        public string PartsName { get; set; }
        public string TaskPlans { get; set; }
        public string OverhaulQuantity { get; set; }
        public string QualifiedQuantity { get; set; }
        public string UnqualifiedQuantity { get; set; }
        public DateTime? StartTime { get; set; }
        public string PassRate { get; set; }
        public string SpeedOfProgress { get; set; }
        public string Others { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string WorkGroup { get; set; }
        public string NewCount { get; set; }
        public string DepartCount { get; set; }
    }
}
