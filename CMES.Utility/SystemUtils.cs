using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace CMES.Utility
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMiliseconds;
    }

    public static class SystemUtils
    {
        [DllImport("coredll.dll")]
        private static extern bool SetLocalTime(ref SystemTime lpSystemTime);

        [DllImport("coredll.dll")]
        private static extern bool GetLocalTime(ref SystemTime lpSystemTime);


        /// <summary>
        /// 设置系统时间
        /// </summary>
        /// <param name="dt"></param>
        public static bool SetSystemTime(DateTime dt)
        {
            SystemTime sysTime = new SystemTime();
            sysTime.wYear = Convert.ToUInt16(dt.Year);
            sysTime.wMonth = Convert.ToUInt16(dt.Month);
            sysTime.wDay = Convert.ToUInt16(dt.Day);
            sysTime.wHour = Convert.ToUInt16(dt.Hour);
            sysTime.wMinute = Convert.ToUInt16(dt.Minute);
            sysTime.wSecond = Convert.ToUInt16(dt.Second);
            try
            {
                return SetLocalTime(ref sysTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("SetSystemDateTime函数执行异常" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetSysTime()
        {
            SystemTime lpTime = new SystemTime();
            GetLocalTime(ref lpTime);

            int Year = lpTime.wYear;
            int Month = lpTime.wMonth;
            int Day = lpTime.wDay;
            int Hour = lpTime.wHour;
            int Minute = lpTime.wMinute;
            int Second = lpTime.wSecond;

            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }



        const uint Sipe_ON = 0x0001;
        const uint Sipe_OFF = 0x0000;

        [DllImport("coredll.dll")]
        public static extern int SipShowIM(uint KType);

        /// <summary>
        /// 打开软键盘
        /// </summary>
        public static void ShowKeyBoard()
        {
            SipShowIM(Sipe_ON);
        }

        /// <summary>
        /// 关闭软键盘
        /// </summary>
        public static void HideKeyBoard()
        {
            SipShowIM(Sipe_OFF);
        }

        /// <summary>
        /// 打开和关闭键盘
        /// </summary>
        public static void OpenCloseKey()
        {
            Process[] app = Process.GetProcessesByName("osk");
            if (app.Length <= 0)
            {
                Process kbpr = System.Diagnostics.Process.Start("osk.exe"); // 打开系统键盘 

            }
            else
            {
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("osk"))
                {

                    p.Kill();
                }
            }
        }
        /// <summary>
        /// 打开键盘
        /// </summary>
        public static void OpenKey()
        {
            Process[] app = Process.GetProcessesByName("osk");
            if (app.Length <= 0)
            {
                Process kbpr = System.Diagnostics.Process.Start("osk.exe"); // 打开系统键盘 
            }
        }
        /// <summary>
        /// 关闭键盘
        /// </summary>
        public static void CloseKey()
        {
            Process[] app = Process.GetProcessesByName("osk");
            if (app.Length > 0)
            {
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("osk"))
                {

                    p.Kill();
                }
            }
        }
    }
}
