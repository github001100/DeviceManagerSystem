using CMES.Entity.SYS;
using CMES.NET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CMES.Controller.SYS
{
    public class PartsController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceName"></param>
        /// <returns></returns>
        public String GetPartsInfoToJson(string PartsName, string PartsNumber)
        {
            PartsEntity PartsEntity = new PartsEntity();
            List<PartsEntity> lists = new List<PartsEntity>();
            JObject jsonobj = null;
            ApiResult apiresult = new ApiResult();
            List<KeyValuePair<string, string>> listpair = new List<KeyValuePair<string, string>>() {
                 new KeyValuePair<string, string>("PartsName",PartsName),
                 new KeyValuePair<string, string>("PartsNumber",PartsNumber)
            };

            string mearResult = HttpHelper.DOPOST("Parts", "Parts/PostPartsInfoByName", listpair);//Api未开启，报异常
            if (mearResult != null && !mearResult.Equals(string.Empty))
            {
                apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);//ApiResult
                if (apiresult.Code == 0 && apiresult.Data != null)
                {
                    //jxjhztjk = JsonConvert.DeserializeObject<Table_JXJHZTJKEntity>(apiresult.Data.ToString());

                    JObject o = JObject.Parse(mearResult);

                    JArray json = (JArray)o["data"];
                    for (int j = 0; j < json.Count; j++)
                    {
                        jsonobj = (JObject)json[j];
                    }
                }
            }
            return mearResult;
        }
        public String UpdateZtjkInfoByProcedureNameToJson(string ProcedureName, string PartsName,
            string NewCount, string DepartCount, string TaskPlans, string OverhaulDate, string UpdateTime)
        {
            Table_JXJHZTJKEntity jxjhztjk = new Table_JXJHZTJKEntity();
            ApiResult apiresult = new ApiResult();
            List<KeyValuePair<string, string>> listpair = new List<KeyValuePair<string, string>>() {
                 new KeyValuePair<string, string>("ProcedureName",ProcedureName),
                 new KeyValuePair<string, string>("PartsName",PartsName),
                 new KeyValuePair<string, string>("NewCount",NewCount),
                 new KeyValuePair<string, string>("DepartCount",DepartCount),
                 new KeyValuePair<string, string>("OverhaulDate",OverhaulDate),
                 new KeyValuePair<string, string>("UpdateTime",UpdateTime),
                 new KeyValuePair<string, string>("TaskPlans",TaskPlans)
            };

            string mearResult = HttpHelper.DOPOST("ZTJK", "ZTJK/UpdateZTJKInfoByProcedureName", listpair);//Api未开启，报异常
            if (mearResult != null && !mearResult.Equals(string.Empty))
            {
                apiresult = JsonConvert.DeserializeObject<ApiResult>(mearResult);//ApiResult
                if (apiresult.Code == 0 && apiresult.Data != null)
                {
                    //jxjhztjk = JsonConvert.DeserializeObject<Table_JXJHZTJKEntity>(apiresult.Data.ToString());

                }
            }
            return mearResult;

        }
    }
}
