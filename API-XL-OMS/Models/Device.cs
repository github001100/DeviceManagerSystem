using System;
using System.Collections.Generic;

namespace API_XL_OMS.Models
{
    public partial class Device
    {
        public int Id { get; set; }
        public string RootNode { get; set; }
        public string FirstLevelNodes { get; set; }
        public string TwoLevelNode { get; set; }
        public string ThreeLevelNode { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DeviceNumber { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturingDate { get; set; }
        public string ProcedureName { get; set; }
        public string PostalAddress { get; set; }
        public string DeviceStatus { get; set; }
        public string Operator { get; set; }
        public string Post { get; set; }
        public string JobNumber { get; set; }
        public string CumulativeTotal { get; set; }
        public string TotalQualifiedProducts { get; set; }
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
