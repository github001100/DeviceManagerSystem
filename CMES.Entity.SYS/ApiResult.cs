namespace CMES.Entity.SYS
{
    public class ApiResult
    {
        public ApiResult()
        {
            Code = 0;
            Message = "";
            Data = null;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class ReturnStruct
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Usercode { get; set; }
    }
}