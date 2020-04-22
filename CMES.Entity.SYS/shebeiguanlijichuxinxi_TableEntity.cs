using System;
namespace CMES.Entity.SYS
{
    /// <summary>
    /// 版 本2.0 
    /// Copyright (c) 2018 开远精机
    /// 创 建：
    /// 日 期：2020-04-21
    /// 描 述：
    /// </summary>
    public class shebeiguanlijichuxinxi_TableEntity
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public System.Int32? id { get; set; }
        /// <summary>
        /// RootNode
        /// </summary>
        /// <returns></returns>
        public string RootNode { get; set; }
        /// <summary>
        /// FirstLevelNodes
        /// </summary>
        /// <returns></returns>
        public string FirstLevelNodes { get; set; }
        /// <summary>
        /// TwoLevelNode
        /// </summary>
        /// <returns></returns>
        public string TwoLevelNode { get; set; }
        /// <summary>
        /// ThreeLevelNode
        /// </summary>
        /// <returns></returns>
        public string ThreeLevelNode { get; set; }
        /// <summary>
        /// DeviceName
        /// </summary>
        /// <returns></returns>
        public string DeviceName { get; set; }
        /// <summary>
        /// DeviceType
        /// </summary>
        /// <returns></returns>
        public string DeviceType { get; set; }
        /// <summary>
        /// DeviceNumber
        /// </summary>
        /// <returns></returns>
        public string DeviceNumber { get; set; }
        /// <summary>
        /// Manufacturer
        /// </summary>
        /// <returns></returns>
        public string Manufacturer { get; set; }
        /// <summary>
        /// ManufacturingDate
        /// </summary>
        /// <returns></returns>
        public string ManufacturingDate { get; set; }
        /// <summary>
        /// ProcedureName
        /// </summary>
        /// <returns></returns>
        public string ProcedureName { get; set; }
        /// <summary>
        /// PostalAddress
        /// </summary>
        /// <returns></returns>
        public string PostalAddress { get; set; }
        /// <summary>
        /// DeviceStatus
        /// </summary>
        /// <returns></returns>
        public string DeviceStatus { get; set; }
        /// <summary>
        /// Operator
        /// </summary>
        /// <returns></returns>
        public string Operator { get; set; }
        /// <summary>
        /// Post
        /// </summary>
        /// <returns></returns>
        public string Post { get; set; }
        /// <summary>
        /// JobNumber
        /// </summary>
        /// <returns></returns>
        public string JobNumber { get; set; }
        /// <summary>
        /// CumulativeTotal
        /// </summary>
        /// <returns></returns>
        public string CumulativeTotal { get; set; }
        /// <summary>
        /// TotalQualifiedProducts
        /// </summary>
        /// <returns></returns>
        public string TotalQualifiedProducts { get; set; }
        /// <summary>
        /// AccumulatedScrap
        /// </summary>
        /// <returns></returns>
        public string AccumulatedScrap { get; set; }
        /// <summary>
        /// NumberOfRepaired
        /// </summary>
        /// <returns></returns>
        public string NumberOfRepaired { get; set; }
        /// <summary>
        /// NumberOfProcessesOnDuty
        /// </summary>
        /// <returns></returns>
        public string NumberOfProcessesOnDuty { get; set; }
        /// <summary>
        /// NumberOfQualifiedProductsOnDuty
        /// </summary>
        /// <returns></returns>
        public string NumberOfQualifiedProductsOnDuty { get; set; }
        /// <summary>
        /// NumberOfWasteProductsOnDuty
        /// </summary>
        /// <returns></returns>
        public string NumberOfWasteProductsOnDuty { get; set; }
        /// <summary>
        /// NumberOfReworkedProductsOnDuty
        /// </summary>
        /// <returns></returns>
        public string NumberOfReworkedProductsOnDuty { get; set; }
        /// <summary>
        /// Shifts
        /// </summary>
        /// <returns></returns>
        public string Shifts { get; set; }
        /// <summary>
        /// OEE
        /// </summary>
        /// <returns></returns>
        public string OEE { get; set; }
        /// <summary>
        /// MTBF
        /// </summary>
        /// <returns></returns>
        public string MTBF { get; set; }
        /// <summary>
        /// MTTR
        /// </summary>
        /// <returns></returns>
        public string MTTR { get; set; }
        /// <summary>
        /// MTTF
        /// </summary>
        /// <returns></returns>
        public string MTTF { get; set; }
        /// <summary>
        /// EFR
        /// </summary>
        /// <returns></returns>
        public string EFR { get; set; }
        /// <summary>
        /// TotalRunningTime
        /// </summary>
        /// <returns></returns>
        public string TotalRunningTime { get; set; }
        /// <summary>
        /// NormalOperationTime
        /// </summary>
        /// <returns></returns>
        public string NormalOperationTime { get; set; }
        /// <summary>
        /// TotalFailureTime
        /// </summary>
        /// <returns></returns>
        public string TotalFailureTime { get; set; }
        /// <summary>
        /// TotalMaintenanceTime
        /// </summary>
        /// <returns></returns>
        public string TotalMaintenanceTime { get; set; }
        /// <summary>
        /// PlannedStartupTime
        /// </summary>
        /// <returns></returns>
        public string PlannedStartupTime { get; set; }
        /// <summary>
        /// PlannedWarmUpTime
        /// </summary>
        /// <returns></returns>
        public string PlannedWarmUpTime { get; set; }
        /// <summary>
        /// FailureTimes
        /// </summary>
        /// <returns></returns>
        public string FailureTimes { get; set; }
        /// <summary>
        /// EquipmentStatusChangeTime
        /// </summary>
        /// <returns></returns>
        public string EquipmentStatusChangeTime { get; set; }
        /// <summary>
        /// ShiftsStartTime
        /// </summary>
        /// <returns></returns>
        public string ShiftsStartTime { get; set; }
        /// <summary>
        /// StartTime
        /// </summary>
        /// <returns></returns>
        public string StartTime { get; set; }
        /// <summary>
        /// TurnOnTime
        /// </summary>
        /// <returns></returns>
        public string TurnOnTime { get; set; }
        /// <summary>
        /// StopTime
        /// </summary>
        /// <returns></returns>
        public string StopTime { get; set; }
        /// <summary>
        /// DataUpdateFlag
        /// </summary>
        /// <returns></returns>
        public string DataUpdateFlag { get; set; }
        /// <summary>
        /// DataSynchronizationFlag
        /// </summary>
        /// <returns></returns>
        public string DataSynchronizationFlag { get; set; }
        /// <summary>
        /// RecordCreationTime
        /// </summary>
        /// <returns></returns>
        public string RecordCreationTime { get; set; }
        /// <summary>
        /// MyCircle
        /// </summary>
        /// <returns></returns>
        public string MyCircle { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        //public override void Modify(int keyValue)
        //{
        //    this.id = keyValue;
        //}
        #endregion
    }
}