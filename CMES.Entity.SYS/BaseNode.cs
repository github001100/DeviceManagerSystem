namespace CMES.Entity.SYS
{
    public class BaseNode
    {
        /// <summary>
        /// 节点系统编号
        /// </summary>
        public int Id { get; set; }
        public string NodeName { get; set; }
        public int NodeOrder { get; set; }
        public int NodeLv { get; set; }
        public int ParentId { get; set; }
        public int EnableMark { get; set; }
    }
}
