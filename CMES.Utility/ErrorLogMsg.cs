using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Configuration;

namespace CMES.Utility
{
   public static class ErrorLogMsg
    {
        #region 文本操作

        // 读文本
        public static string ReadTxt(string strPath)
        {
            if (File.Exists(strPath))
            {
                StringBuilder sb = new StringBuilder();

                FileStream fs = new FileStream(strPath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    sb.Append(sr.ReadLine()).Append("\n");
                }
                sr.Close();
                fs.Close();

                return sb.ToString();
            }

            return "";
        }

        // 写文本
        public static int WriteTxt(string strPath, string strVal)
        {
            Int32 flag = -1;
            //if (File.Exists(strPath))
            //{
            FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(strVal);

            sw.Flush();
            sw.Close();
            fs.Close();

            flag = 0;
            //}

            return flag;
        }

        // 拷贝文件
        public static void FileCopyAll(string Spath, string Opath)
        {
            if (File.Exists(Spath) && File.Exists(Opath) == false)
            {
                File.Copy(Spath, Opath, true);
            }
        }

        // 删除文件(指定修改天数之前的)
        public static void FileDeleteAll(string strPath, bool isForce = false)
        {
            if (!Directory.Exists(strPath))
            {
                return;
            }

            try
            {
                DirectoryInfo dir = new DirectoryInfo(strPath);

                foreach (FileInfo f in dir.GetFiles())
                {
                    if (f.CreationTime < DateTime.Now.AddDays(-3) || isForce)
                    {
                        f.Delete();
                    }
                }

                DirectoryInfo[] dis = dir.GetDirectories();
                if (dis.Length > 0)
                {
                    for (int i = 0; i < dis.Length; i++)
                    {
                        FileDeleteAll(dis[i].FullName, isForce);
                    }
                }
            }
            catch (Exception ex)
            {
                CreateErrLog("删除文件异常", "203", ex.ToString());
            }
        }


        //记录日志
        public static void CreateErrLog(string strFunctionName, string strErrorNum, string strErrorDescription)
        {
            string strMatter;
            string strPath;

            DateTime dt = DateTime.Now;

            try
            {
                strMatter = strFunctionName + " , " + strErrorNum + " , " + strErrorDescription;

                strPath = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog";
                if (strPath.Trim() == "")
                {
                    strPath = @"C:\\CAYA_MES\\ErrorLog";
                }

                if (Directory.Exists(strPath) == false)
                {
                    Directory.CreateDirectory(strPath);
                }
                strPath = strPath + "\\" + dt.ToString("yyyyMM");

                if (Directory.Exists(strPath) == false)
                {
                    Directory.CreateDirectory(strPath);
                }
                strPath = strPath + "\\" + dt.ToString("dd") + ".txt";

                StreamWriter FileWriter = new StreamWriter(strPath, true);
                FileWriter.WriteLine("Time: " + dt.ToString("HH:mm:ss") + "  Err: " + strMatter);
                FileWriter.Close();
            }
            catch (Exception ex)
            {
                //("写错误日志时出现问题，请与管理员联系！ 原错误:" + strMatter + "写日志错误:" + ex.Message.ToString());
                string str = ex.Message.ToString();
            }
        }

        #endregion


        #region 获取文件夹大小
        //调用windows API获取磁盘空闲空间
        //导入库
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern bool GetDiskFreeSpace([MarshalAs(UnmanagedType.LPTStr)]string rootPathName,
        ref int sectorsPerCluster, ref int bytesPerSector, ref int numberOfFreeClusters, ref int totalNumbeOfClusters);


        // 获取指定路径的大小
        public static long GetDirectoryLength(string dirPath)
        {
            long len = 0;
            //判断该路径是否存在（是否为文件夹）
            if (!Directory.Exists(dirPath))
            {
                //查询文件的大小
                len = FileSize(dirPath);
            }
            else
            {
                //定义一个DirectoryInfo对象
                DirectoryInfo di = new DirectoryInfo(dirPath);

                //通过GetFiles方法，获取di目录中的所有文件的大小
                foreach (FileInfo fi in di.GetFiles())
                {
                    len += fi.Length;
                }
                //获取di中所有的文件夹，并存到一个新的对象数组中，以进行递归
                DirectoryInfo[] dis = di.GetDirectories();
                if (dis.Length > 0)
                {
                    for (int i = 0; i < dis.Length; i++)
                    {
                        len += GetDirectoryLength(dis[i].FullName);
                    }
                }
            }
            return len;
        }

        // 获取指定路径的占用空间
        public static long GetDirectorySpace(string dirPath)
        {
            //返回值
            long len = 0;
            //判断该路径是否存在（是否为文件夹）
            if (!Directory.Exists(dirPath))
            {
                //如果是文件，则调用
                len = FileSpace(dirPath);
            }
            else
            {
                //定义一个DirectoryInfo对象
                DirectoryInfo di = new DirectoryInfo(dirPath);
                //本机的簇值
                long clusterSize = GetClusterSize(di);
                //遍历目录下的文件，获取总占用空间
                foreach (FileInfo fi in di.GetFiles())
                {
                    //文件大小除以簇，余若不为0
                    if (fi.Length % clusterSize != 0)
                    {
                        decimal res = fi.Length / clusterSize;
                        //文件大小除以簇，取整数加1。为该文件占用簇的值
                        int clu = Convert.ToInt32(Math.Ceiling(res)) + 1;
                        long result = clusterSize * clu;
                        len += result;
                    }
                    else
                    {
                        //余若为0，则占用空间等于文件大小
                        len += fi.Length;
                    }
                }
                //获取di中所有的文件夹，并存到一个新的对象数组中，以进行递归
                DirectoryInfo[] dis = di.GetDirectories();
                if (dis.Length > 0)
                {
                    for (int i = 0; i < dis.Length; i++)
                    {
                        len += GetDirectorySpace(dis[i].FullName);
                    }
                }
            }
            return len;
        }

        //所给路径中所对应的文件大小
        public static long FileSize(string filePath)
        {
            //定义一个FileInfo对象，是指与filePath所指向的文件相关联，以获取其大小
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.Length;
        }

        //所给路径中所对应的文件占用空间
        public static long FileSpace(string filePath)
        {
            long temp = 0;
            //定义一个FileInfo对象，是指与filePath所指向的文件相关联，以获取其大小
            FileInfo fileInfo = new FileInfo(filePath);
            long clusterSize = GetClusterSize(fileInfo);
            if (fileInfo.Length % clusterSize != 0)
            {
                decimal res = fileInfo.Length / clusterSize;
                int clu = Convert.ToInt32(Math.Ceiling(res)) + 1;
                temp = clusterSize * clu;
            }
            else
            {
                return fileInfo.Length;
            }
            return temp;
        }

        public static DiskInfo GetDiskInfo(string rootPathName)
        {
            DiskInfo diskInfo = new DiskInfo();
            int sectorsPerCluster = 0, bytesPerSector = 0, numberOfFreeClusters = 0, totalNumberOfClusters = 0;
            GetDiskFreeSpace(rootPathName, ref sectorsPerCluster, ref bytesPerSector, ref numberOfFreeClusters, ref totalNumberOfClusters);

            //每簇的扇区数
            diskInfo.SectorsPerCluster = sectorsPerCluster;
            //每扇区字节
            diskInfo.BytesPerSector = bytesPerSector;

            return diskInfo;
        }

        // 结构。硬盘信息
        public struct DiskInfo
        {
            public string RootPathName;
            //每簇的扇区数
            public int SectorsPerCluster;
            //每扇区字节
            public int BytesPerSector;
            public int NumberOfFreeClusters;
            public int TotalNumberOfClusters;
        }

        // 获取每簇的字节
        public static long GetClusterSize(FileInfo file)
        {
            long clusterSize = 0;
            DiskInfo diskInfo = new DiskInfo();
            diskInfo = GetDiskInfo(file.Directory.Root.FullName);
            clusterSize = (diskInfo.BytesPerSector * diskInfo.SectorsPerCluster);
            return clusterSize;
        }

        // 获取每簇的字节
        public static long GetClusterSize(DirectoryInfo dir)
        {
            long clusterSize = 0;
            DiskInfo diskInfo = new DiskInfo();
            diskInfo = GetDiskInfo(dir.Root.FullName);
            clusterSize = (diskInfo.BytesPerSector * diskInfo.SectorsPerCluster);
            return clusterSize;
        }

        #endregion
        /// <summary>
        /// 返回＊.exe.config文件中appSettings配置节的value项
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }


        /// <summary>
        /// 在＊.exe.config文件中appSettings配置节增加一对键、值对
        /// </summary>
        /// <param name="newKey"></param>
        /// <param name="newValue"></param>
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }

            // Open App.Config of executable
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            // Add an Application Setting.
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
