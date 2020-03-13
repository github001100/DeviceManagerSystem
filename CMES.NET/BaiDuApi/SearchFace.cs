using System.Collections.Generic;

namespace CMES.NET
{
    /// <summary>
    /// 查询用户
    /// </summary>
    public class UserFace
    {
       /// <summary>
       /// 组编号
       /// </summary>
       public string group_id { get; set; }
       /// <summary>
       /// 用户编号
       /// </summary>
       public string user_id { get; set; }
       /// <summary>
       /// 用户信息
       /// </summary>
       public string user_info { get; set; }
       /// <summary>
       /// 得分
       /// </summary>
       public string score { get; set; }
    }

   public class SearchResult {
       /// <summary>
       /// 编号
       /// </summary>
       public string face_token { get; set; }
       public IList<UserFace> user_list { get; set; }
   }
   public class SearchRootObject
   {
       public string error_code { get; set; }
       public string error_msg { get; set; }
       public string log_id { get; set; }
       public string timestamp { get; set; }
       public string cached { get; set; }
       public SearchResult result { get; set; }
   }
}
