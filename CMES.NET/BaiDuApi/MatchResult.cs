using System.Collections.Generic;

namespace CMES.NET
{
    public class MatchResult
    {
        public string score { get; set; }
        public IList<Face_Token> face_list { get; set; }
    }
    public class Face_Token {
        public string face_token { get; set; }
    }
    public class MatchRootObject
    {
        public string error_code { get; set; }
        public string error_msg { get; set; }
        public string log_id { get; set; }
        public string timestamp { get; set; }
        public string cached { get; set; }
        public MatchResult result { get; set; }
    }
}
