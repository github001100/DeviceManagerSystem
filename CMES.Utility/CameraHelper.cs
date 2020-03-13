using System;
using System.Linq;
using System.Drawing;
using System.IO;
//using AForge.Video.DirectShow;
namespace CMES.Utility
{
   public class CameraHelper
    {
        /// <summary>
        /// 是否有摄像头
        /// </summary>
        public bool HasVideoDevice { get; set; }
        /// <summary>
        /// 视频源
        /// </summary>
        //public VideoCaptureDevice VideoSource { get; set; }
        /// <summary>
        /// 视频宽度
        /// </summary>
        public int FrameWidth { get; set; }
        /// <summary>
        /// 视频高度
        /// </summary>
        public int FrameHeight { get; set; }
        /// <summary>
        /// 视频图片的字节数
        /// </summary>
        public int ByteCount { get; set; }
        public CameraHelper() {
            //var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            ////检测是否存在摄像头
            //if (videoDevices.Count == 0)
            //{
            //    HasVideoDevice = false;
            //    return;
            //}
            ////连接第一个摄像头
            //VideoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            ////获取摄像头最低的分辨率
            //var videoResolution = VideoSource.VideoCapabilities.First(ii => ii.FrameSize.Width == VideoSource.VideoCapabilities.Min(jj => jj.FrameSize.Width));
            //FrameWidth = videoResolution.FrameSize.Width;
            //FrameHeight = videoResolution.FrameSize.Height;
            //ByteCount = videoResolution.BitCount / 8;
            //VideoSource.VideoResolution = videoResolution;
            //HasVideoDevice = true;
            //closeVideo();
        }
        public void closeVideo() { 
            //if(HasVideoDevice&&VideoSource.IsRunning){
            //    VideoSource.SignalToStop();
            //    VideoSource.WaitForStop();
            //    VideoSource.Stop();
            //}
        }
        /// <summary>
        /// 将路径下图片转换为base64字符串
        /// </summary>
        /// <param name="picUrl">图片路径</param>
        /// <returns></returns>
        public static string PicUrltoBase64(string picUrl)
        {
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
    }

}
