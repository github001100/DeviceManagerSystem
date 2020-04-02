using CMES.Entity.SYS;
using CMES.NET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CMES.Controller.SYS
{
    public class LdkpController
    {
        public String GetLdkpInfoToJson(string ldkp)//ldkpApi
        {
            ldkpApi ldkpApi = new ldkpApi();
            List<ldkpApi> lists = new List<ldkpApi>();
            JObject jsonobj = null;
            ApiResult apiresult = new ApiResult();
            List<KeyValuePair<string, string>> listpair = new List<KeyValuePair<string, string>>() {
                 new KeyValuePair<string, string>("id",ldkp)
            };

            string mearResult = HttpHelper.DOPOST("ldkp", "Ldkp/PostLdkpInfo", listpair);//Api未开启，报异常
            if (mearResult != null && !mearResult.Equals(string.Empty))
            {
                apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);
                if (apiresult.Code == 0 && apiresult.Data != null)
                {
                    //ldkpApi = JsonConvert.DeserializeObject<ldkpApi>(apiresult.Data.ToString());
                  
                    JObject o = JObject.Parse(mearResult);

                    JArray json = (JArray)o["data"];
                    for (int j = 0; j < json.Count; j++)
                    {
                        jsonobj = (JObject)json[j];
                        //Console.WriteLine(jsonobj["id"].ToString() + "|" + jsonobj["lz_QRcode"].ToString());
                    }
                }
            }
            return mearResult;
        }
    }
}
