using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.Dynamic;

namespace CMES.NET
{
   public class RestChaspHelper
    {
        private static RestClient GetRestClient()
        {
            string serverPath = XMLUtil.GetXML();
            var restClient = new RestClient(serverPath);
            //restClient.AddDefaultHeader("Content-Type", @"application/json");
            restClient.UseJson();
            return restClient;
        }


        /// <summary>
        /// 获取单个结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource">资源名</param>
        /// <returns></returns>
        public static async Task<Result<T>> GetAsync<T>(string resource)
            where T : class
        {
            var client = GetRestClient();
            var request = new RestRequest(resource, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddJsonBody(new WebApiQueryBody());

            var res = await client.ExecuteTaskAsync<Result<T>>(request);

            return res?.Data;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="resource">资源名</param>
        /// <param name="data">要添加的数据</param>
        /// <returns></returns>
        public static async Task<bool> PostAsync(string resource, IEnumerable<ExpandoObject> data)
        {
            var client = GetRestClient();
            var request = new RestRequest(resource, Method.POST);
            request.AddHeader("Content-Type", @"application/json");
            request.AddJsonBody(data);

            var response = await client.ExecuteTaskAsync(request);

            var ret = (response.StatusCode == System.Net.HttpStatusCode.OK);
            if (!ret)
            {
                //Log.Error(response.ErrorMessage);
            }
            return ret;
        }

        #region Get
        public static async Task<string> GetDataMeasureAsync() => JsonConvert.SerializeObject(await GetAsync<ExpandoObject>(DefaultSet.RES_MeasureResult));
        private static async Task<string> GetDataAsync(string resource)
            => JsonConvert.SerializeObject(await GetAsync<ExpandoObject>(resource));
        #endregion

        #region MeasureResult
        public static async Task<bool> MeasureResultPostDemoAsync(List<ExpandoObject> lo)
            => await PostAsync(DefaultSet.RES_MeasureResult, lo);
        private static async Task MeasureResultGetDemoAsync()
        => await GetDataAsync(DefaultSet.RES_MeasureResult);

        #endregion

        #region EquipmentInfo
        public static async Task<bool> EquipmentStatusPostDemoAsync(List<ExpandoObject> lo)
            => await PostAsync(DefaultSet.RES_EquipmentStatus, lo);
        private static async Task EquipmentStatusGetDemoAsync()
            => await GetDataAsync(DefaultSet.RES_EquipmentStatus);
        public static async Task<string> GetDataEquipmentAsync()
        => JsonConvert.SerializeObject(await GetAsync<ExpandoObject>(DefaultSet.RES_EquipmentStatus));
        #endregion
    }
}
