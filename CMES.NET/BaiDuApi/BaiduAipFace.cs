using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;
using System.Net.Http;
namespace CMES.NET
{
    public static class BaiduAipFace
    {
        /// <summary>
        /// 应用名
        /// </summary>
        public static string AppName = "LYKY";
        /// <summary>
        /// 应用编号
        /// </summary>
        public static string AppID = "11731581";
        /// <summary>
        /// 应用编号
        /// </summary>
        public static string ApiKey = "M8wXrMyudBdotVRKlZb2inTg";
        /// <summary>
        /// 密钥
        /// </summary>
        public static string SecretKey = "zQMewzKGzV7Cd5KPLVtTSsMQaX1LQ452";
        #region 秦乐森
        /// <summary>
        /// 应用编号
        /// </summary>
        //public static string AppID = "14219271";
        /// <summary>
        /// 应用编号
        /// </summary>
        //public static string ApiKey = "v4SydZuOu0yQugDxGjEZuQIV";
        /// <summary>
        /// 密钥
        /// </summary>
        //public static string SecretKey = "e0zUhVuSpUBB4XjG3pko3RL0Pizdxd6S";
        #endregion
        /// <summary>
        /// h5语音验证码
        /// 50次/天免费
        /// </summary>
        public static string speechtest = "https://aip.baidubce.com/rest/2.0/face/v1/faceliveness/sessioncode";
        /// <summary>
        /// h5活体视频分析
        /// 50次/天免费
        /// </summary>
        public static string verify = "https://aip.baidubce.com/rest/2.0/face/v1/faceliveness/verify";
        /// <summary>
        /// 人脸检测
        /// </summary>
        public static string faceDetect = "https://aip.baidubce.com/rest/2.0/face/v3/detect";
        /// <summary>
        /// 人脸对比
        /// </summary>
        public static string faceMatch = "https://aip.baidubce.com/rest/2.0/face/v3/match";
        /// <summary>
        /// 人脸搜索
        /// </summary>
        public static string faceSearch = "https://aip.baidubce.com/rest/2.0/face/v3/search";
        /// <summary>
        /// 人脸库管理-人脸注册
        /// </summary>
        public static string faceAdd = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/add";
        /// <summary>
        /// 人脸库管理-人脸更新
        /// </summary>
        public static string faceUpdate = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/update";
        /// <summary>
        /// 人脸库管理-删除用户
        /// </summary>
        public static string faceUserDelete = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/delete";
        /// <summary>
        /// 人脸库管理-用户信息查询
        /// </summary>
        public static string faceGet = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/get";
        /// <summary>
        /// 人脸库管理-获取组列表
        /// </summary>
        public static string faceGetGrouplist = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/group/getlist";
        /// <summary>
        /// 人脸库管理-获取用户列表
        /// </summary>
        public static string faceGetusers = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/group/getusers";
        /// <summary>
        /// 人脸库管理-复制用户
        /// </summary>
        public static string faceCopy = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/user/copy";
        /// <summary>
        /// 人脸库管理-获取用户人脸列表
        /// </summary>
        public static string faceGetlist = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/face/getlist";
        /// <summary>
        /// 人脸库管理-创建用户组
        /// </summary>
        public static string faceGroupadd = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/group/add";
        /// <summary>
        /// 人脸库管理-删除用户组
        /// </summary>
        public static string faceGroupdelete = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/group/delete";
        /// <summary>
        /// 人脸库管理-删除人脸
        /// </summary>
        public static string faceDelete = "https://aip.baidubce.com/rest/2.0/face/v3/faceset/face/delete";
        /// <summary>
        /// 在线活体检测
        /// </summary>
        public static string faceverify = "https://aip.baidubce.com/rest/2.0/face/v3/faceverify";
        /// <summary>
        /// 获取Tocken
        /// </summary>
        /// <returns></returns>
        public static String getAccessToken()
        {
            try
            {
                String authHost = "https://aip.baidubce.com/oauth/2.0/token";
                HttpClient client = new HttpClient();
                List<KeyValuePair<String, String>> paraList = new List<KeyValuePair<string, string>>();
                paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                paraList.Add(new KeyValuePair<string, string>("client_id", ApiKey));
                paraList.Add(new KeyValuePair<string, string>("client_secret", SecretKey));

                HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
                return result;
            }
            catch (Exception)
            {
                return "";
            }
            
        }
        /// <summary>
        /// 人脸检测和分析
        /// </summary>
        /// <param name="PictureBase64">图片base64字符串</param>
        /// <returns>Json</returns>
        public static string DetectFace(String PictureBase64, string token)
        {
            try
            {
                string host = faceDetect + "?access_token=" + token;
                Encoding encoding = Encoding.Default;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.KeepAlive = true;
                String str = "{\"image\":\"" + PictureBase64 + "\",\"image_type\":\"BASE64\",\"face_field\":\"age,beauty,expression,face_shape,gender,glasses,race,quality,face_type\"}";
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string result = reader.ReadToEnd();
                //Console.WriteLine("人脸检测与属性分析:");
                //Console.WriteLine(result);
                return result;
            }
            catch (Exception)
            {                
                return "";
            }
            
        }
        /// <summary>
        /// 将路径下图片转换为base64字符串
        /// </summary>
        /// <param name="picUrl">图片路径</param>
        /// <returns></returns>
        public static string PicUrltoBase64(string picUrl) {
            try
            {
                //将图片转换成BASE64编码
                Bitmap bmp = new Bitmap(picUrl);               
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                ms.Dispose();
                String strbaser64 = Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception)
            {
                return "";
            }
            
        }
        public static string PicStemToBase64(Bitmap bmp)
        {
            try
            {
                //将图片转换成BASE64编码                
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                ms.Dispose();
                String strbaser64 = Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception)
            {
                return "";
            }
        }
        /// <summary>
        /// 两张人脸图片相似度对比
        /// </summary>
        /// <param name="PictureBase64A"></param>
        /// <param name="PictureBase64B"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string MatchFace(String PictureBase64A, String PictureBase64B, string token)
        {
            string host = faceMatch + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "[{\"image\":\"" + PictureBase64A + "\",\"image_type\":\"BASE64\",\"face_type\":\"LIVE\",\"quality_control\":\"LOW\",\"liveness_control\":\"LOW\"}," +
                "{\"image\":\"" + PictureBase64B + "\",\"image_type\":\"BASE64\",\"face_type\":\"LIVE\",\"quality_control\":\"LOW\",\"liveness_control\":\"LOW\"}]";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="PictureBase64"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string SearchFace(String PictureBase64,string userGroup,string token)
        {
            string host = faceSearch + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"image\":\"" + PictureBase64 + "\",\"image_type\":\"BASE64\",\"group_id_list\":\"" + userGroup + "\",\"quality_control\":\"LOW\",\"liveness_control\":\"LOW\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="PictureBase64">相片</param>
        /// <param name="userGroup">用户组编号</param>
        /// <param name="userID">用户编号</param>
        /// <param name="user_info">用户描述</param>
        /// <param name="token">请求token</param>
        /// <returns></returns>
        public static string FaceAdd(String PictureBase64, string userGroup, string userID, string user_info, string token)
        {
            string host = faceAdd + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"image\":\"" + PictureBase64 + "\",\"image_type\":\"BASE64\",\"group_id\":\"" + userGroup + "\",\"user_id\":\"" + userID + "\",\"user_info\":\"" + user_info + "\",\"quality_control\":\"LOW\",\"liveness_control\":\"LOW\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 用户信息更新
        /// 说明：针对一个user_id执行更新操作，新上传的人脸图像将覆盖此user_id原有所有图像。
        /// </summary>
        /// <param name="PictureBase64">用户相片</param>
        /// <param name="userGroup">用户组</param>
        /// <param name="userID">用户编号</param>
        /// <param name="user_info">用户信息</param>
        /// <param name="token">请求Token</param>
        /// <returns></returns>
        public static string FaceUpdate(String PictureBase64, string userGroup, string userID, string user_info, string token)
        {
            string host = faceUpdate + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"image\":\"" + PictureBase64 + "\",\"image_type\":\"BASE64\",\"group_id\":\"" + userGroup + "\",\"user_id\":\"" + userID + "\",\"user_info\":\"" + user_info + "\",\"quality_control\":\"LOW\",\"liveness_control\":\"LOW\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 删除用户
        /// 当用户下只有一个相片时删除用户
        /// </summary>
        /// <param name="userGroup">用户组</param>
        /// <param name="userID">用户编号</param>
        /// <param name="face_token">删除相片编号</param>
        /// <param name="token">请求token</param>
        /// <returns></returns>
        public static string FaceDel(string userGroup, string userID, string face_token, string token){
        string host = faceUserDelete + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"user_id\":\"" + userID + "\",\"group_id\":\"" + userGroup + "\",\"face_token\":\"" + face_token + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userGroup"></param>
        /// <param name="userID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string userGet(string userGroup, string userID,string token)
        {
            string host = faceGet + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"user_id\":\"" + userID + "\",\"group_id\":\"" + userGroup + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <param name="userGroup">用户组</param>
        /// <param name="userID">用户编号</param>
        /// <param name="token">访问Token</param>
        /// <returns></returns>
        public static string getUserlist(string userGroup, string userID, string token)
        {
            string host = faceGetGrouplist + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"user_id\":\"" + userID + "\",\"group_id\":\"" + userGroup + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 用于查询指定用户组中的用户列表。
        /// </summary>
        /// <param name="userGroup">用户组</param>
        /// <param name="token">请求token</param>
        /// <returns></returns>
        public static string GetGroupUsers(string userGroup, string token) {
            string host = faceGetusers + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"group_id\":\"" + userGroup + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userGroup"></param>
        /// <param name="userID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string UserDel(string userGroup, string userID,  string token)
        {
            string host = faceUserDelete + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"user_id\":\"" + userID + "\",\"group_id\":\"" + userGroup + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 获取用户组列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetGroupList(string token)
        {
            string host = faceGetGrouplist + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"start\":0,\"length\":100}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }

        /// <summary>
        /// 创建用户组
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string FaceGroupAdd(string groupId,string token) {
            string host = faceGroupadd + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"group_id\":\"" + groupId + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string FaceGroupDel(string groupId, string token)
        {
            string host = faceGroupdelete + "?access_token=" + token;
            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;
            String str = "{\"group_id\":\"" + groupId + "\"}";
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string result = reader.ReadToEnd();
            return result;
        }
    }
}
