using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using CMES.Utility;
namespace CMES.NET
{
    public class HttpHelper
    {
        public static HttpClient client = new HttpClient();
        public static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        public static string mearResult = "";

        public static string GetTest(string localUrl, bool isCreate)
        {
            string urls = GetUrl(localUrl) + "Values/";
            //HttpClient client = new HttpClient();
            //client.Timeout.Add(new TimeSpan(500));           
            try
            {
                watch.Start();  //开始监视代码运行时间
                var response = client.GetAsync(urls).Result;
                //需要测试的代码
                watch.Stop();  //停止监视
                TimeSpan timespan = watch.Elapsed;  //获取当前实例测量得出的总时间
                ErrorLogMsg.CreateErrLog("连接响应时间", "0XX0", timespan.TotalMilliseconds.ToString());
                return response.StatusCode.ToString();
            }
            catch (Exception e)
            {
                if (isCreate)
                {
                    ErrorLogMsg.CreateErrLog("连接失败", e.Source, e.Message);
                }
                return null;
            }

        }
        /// <summary>
        /// 获取Tocken
        /// </summary>
        /// <returns></returns>
        public static string GetToken(string localUrl, string username, string password)
        {
            try
            {
                string authHost = GetUrl(localUrl) + "login/";

                List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                };
                HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(result);                
                return result;
            }
            catch (Exception)
            {
                return "";
            }

        }
        /// <summary>
        /// 获取Tocken
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceToken(string localUrl, string devicecpu, string devicedisk)
        {
            try
            {
                string authHost = GetUrl(localUrl) + "login/";

                List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("devicecpu", devicecpu),
                    new KeyValuePair<string, string>("devicedisk", devicedisk)
                };

                HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(result);                
                return result;
            }
            catch (Exception)
            {
                return "";
            }

        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageCode">列表名/</param>
        /// <param name="token">验证token</param>
        /// <returns></returns>
        public static string ToGet(string localUrl, string pageCode, string token)
        {
            try
            {
                string requstUrl = GetUrl(localUrl) + pageCode;
                //HttpClient client = new HttpClient();      
                if (token != null && !token.Equals(string.Empty))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
                }
                HttpResponseMessage response = client.GetAsync(requstUrl).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception e)
            {
                ErrorLogMsg.CreateErrLog("获取连接异常", "0H01", e.Message);
                return "";
            }
        }
        /// <summary>
        /// 根据路径获取列表
        /// </summary>
        /// <param name="pageCode"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string ToGetByUrl(string url, string token)
        {
            try
            {
                //string requstUrl = getUrl() + pageCode;
                //HttpClient client = new HttpClient();      
                if (token != null && !token.Equals(string.Empty))
                {
                    client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
                }
                HttpResponseMessage response = client.GetAsync(url).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception e)
            {
                ErrorLogMsg.CreateErrLog("获取连接异常", "0H02", e.Message);
                return "";
            }
        }
        /// <summary>
        /// post访问
        /// </summary>
        /// <param name="pageCode">列表名</param>
        /// <param name="token">验证token</param>
        /// <param name="paraList">参数列表</param>
        /// <returns></returns>
        public static string ToPost(string localUrl, string pageCode, string token, List<KeyValuePair<String, String>> paraList)
        {
            try
            {
                string requstUrl = GetUrl(localUrl) + pageCode + "?token=" + token;
                //HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(requstUrl, new FormUrlEncodedContent(paraList)).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string GetUrl(string LoclUrl)
        {
            XElement xe = XElement.Load(XMLUtil.ConfigFileName);
            if (LoclUrl.Equals(string.Empty))
            {
                LoclUrl = "LoadUrl";
            }
            return XMLUtil.GetElementValue(xe, LoclUrl, "http://localhost:8000/api/");
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageCode"></param>
        /// <returns></returns>
        public static string DOGET(string localUrl, string pageCode)
        {
            try
            {
                string requstUrl = GetUrl(localUrl) + pageCode;
                //HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(requstUrl).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
        /// <summary>
        /// 根据ID获取单个实体
        /// </summary>
        /// <param name="pageCode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string DOGET(string localUrl, string pageCode, string id)
        {
            try
            {
                string requstUrl = GetUrl(localUrl) + pageCode + "/" + id;
                //HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(requstUrl).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// POST方法
        /// </summary>
        /// <param name="pageCode"></param>
        /// <param name="paraList"></param>
        /// <returns></returns>
        public static string DOPOST(string localUrl, string pageCode, List<KeyValuePair<String, String>> paraList)
        {
            try
            {
                string requstUrl = GetUrl(localUrl) + pageCode;
                //HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PostAsync(requstUrl, new FormUrlEncodedContent(paraList)).Result;

                string result = response.Content.ReadAsStringAsync().Result;
                return result;

                //FormUrlEncodedContent content = new FormUrlEncodedContent(paraList);
                //var respMsg = client.PostAsync(requstUrl, content);
                ////HttpResponseMessage mess = respMsg.Result;
                //HttpResponseMessage mess = respMsg.Result;
                //string msgBody = mess.Content.ToJson();               
                //return msgBody;

            }
            catch (Exception ex)
            {
                return "" + ex.Message;
            }
        }
        /// <summary>
        /// 异步请求改造 2019 4.19 by Fu
        /// </summary>
        /// <param name="pageCode"></param>
        /// <param name="paraList"></param>
        public static async void DooPost(string localUrl, string pageCode, List<KeyValuePair<String, String>> paraList)
        {
            //IList<SendCarCost_KM> rideCostInfo = ModelConvertHelper<SendCarCost_KM>.ConvertToModel(_rideCostRepository.GetSendCarCost());

            for (int i = 0; i < paraList.Count; i++)
            {
                string url = GetUrl(localUrl) + pageCode;
                //设置HttpClientHandler的AutomaticDecompression  
                var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
                //创建HttpClient（注意传入HttpClientHandler）  
                using (var http = new HttpClient(handler))
                {

                    try
                    {
                        //使用FormUrlEncodedContent做HttpContent  
                        var content = new FormUrlEncodedContent(paraList);
                        //await异步等待回应  

                        var response = await http.PostAsync(url, content);
                        //确保HTTP成功状态值  
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）  
                        mearResult = await response.Content.ReadAsStringAsync();//测量结果响应
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("服务错误：" + ex.Message);
                    }
                    finally
                    {

                    }

                }
            }
        }
        public static string DOPUT(string localUrl, string pageCode, string id, List<KeyValuePair<String, String>> paraList)
        {
            try
            {
                string requstUrl = GetUrl(localUrl) + pageCode + "/" + id;
                //HttpClient client = new HttpClient();
                HttpResponseMessage response = client.PutAsync(requstUrl, new FormUrlEncodedContent(paraList)).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
