namespace CMES.Entity.SYS
{
    /// <summary>
    /// �� ��2.0 
    /// Copyright (c) 2018 ��Զ����
    /// �� ����
    /// �� �ڣ�2020-04-24
    /// �� ����
    /// </summary>
    public class PartsEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public System.Int32? ID { get; set; }
        /// <summary>
        /// PartsName
        /// </summary>
        /// <returns></returns>
        public string PartsName { get; set; }
        /// <summary>
        /// CXQX
        /// </summary>
        /// <returns></returns>
        public string CXQX { get; set; }
        /// <summary>
        /// QrCode
        /// </summary>
        /// <returns></returns>
        public string QrCode { get; set; }
        /// <summary>
        /// WGJC
        /// </summary>
        /// <returns></returns>
        public string WGJC { get; set; }
        /// <summary>
        /// CCCL
        /// </summary>
        /// <returns></returns>
        public string CCCL { get; set; }
        /// <summary>
        /// RK
        /// </summary>
        /// <returns></returns>
        public string RK { get; set; }
        /// <summary>
        /// Other1
        /// </summary>
        /// <returns></returns>
        public string Other1 { get; set; }
        /// <summary>
        /// Other2
        /// </summary>
        /// <returns></returns>
        public string Other2 { get; set; }
        /// <summary>
        /// Other3
        /// </summary>
        /// <returns></returns>
        public string Other3 { get; set; }
        #endregion

        //#region ��չ����
        ///// <summary>
        ///// �༭����
        ///// </summary>
        ///// <param name="keyValue"></param>
        //public override void Modify(int keyValue)
        //{
        //    this.ID = keyValue;
        //}
        //#endregion
    }
}