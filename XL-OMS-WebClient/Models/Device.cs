using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace XL_OMS_WebClient.Models
{
    public partial class Device
    {
        [DisplayName("序号")]
        public int Id { get; set; }
        [DisplayName("工厂")]
        public string RootNode { get; set; }
        [DisplayName("车间")]
        public string FirstLevelNodes { get; set; }
        [DisplayName("产线")]
        public string TwoLevelNode { get; set; }
        [DisplayName("设备-编号")]
        public string ThreeLevelNode { get; set; }
        [DisplayName("设备")]
        public string DeviceName { get; set; }
        [DisplayName("型号")]
        public string DeviceType { get; set; }
        [DisplayName("编号")]
        public string DeviceNumber { get; set; }
        [DisplayName("厂家")]
        public string Manufacturer { get; set; }
        [DisplayName("制造日期")]
        public string ManufacturingDate { get; set; }
        [DisplayName("工序名称")]
        public string ProcedureName { get; set; }
        [DisplayName("通讯地址")]
        public string PostalAddress { get; set; }
        [DisplayName("状态")]
        public string DeviceStatus { get; set; }
        [DisplayName("操作者")]
        public string Operator { get; set; }
        [DisplayName("岗位")]
        public string Post { get; set; }
        [DisplayName("工号")]
        public string JobNumber { get; set; }
        [DisplayName("总数")]
        public string CumulativeTotal { get; set; }
        [DisplayName("合格品数")]
        public string TotalQualifiedProducts { get; set; }
        [DisplayName("废品数")]
        public string AccumulatedScrap { get; set; }
        public string NumberOfRepaired { get; set; }
        public string NumberOfProcessesOnDuty { get; set; }
        public string NumberOfQualifiedProductsOnDuty { get; set; }
        public string NumberOfWasteProductsOnDuty { get; set; }
        public string NumberOfReworkedProductsOnDuty { get; set; }
        public string Shifts { get; set; }
        public string Oee { get; set; }
        public string Mtbf { get; set; }
        public string Mttr { get; set; }
        public string Mttf { get; set; }
        public string Efr { get; set; }
        public string TotalRunningTime { get; set; }
        public string NormalOperationTime { get; set; }
        public string TotalFailureTime { get; set; }
        public string TotalMaintenanceTime { get; set; }
        public string PlannedStartupTime { get; set; }
        public string PlannedWarmUpTime { get; set; }
        public string FailureTimes { get; set; }
        public string EquipmentStatusChangeTime { get; set; }
        public string ShiftsStartTime { get; set; }
        public string StartTime { get; set; }
        public string TurnOnTime { get; set; }
        public string StopTime { get; set; }
        public string DataUpdateFlag { get; set; }
        public string DataSynchronizationFlag { get; set; }
        public string RecordCreationTime { get; set; }
    }
}
