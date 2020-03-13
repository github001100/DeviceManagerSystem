﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using DeviceManagerSystem.Others;
namespace DeviceManagerSystem
{
    public class AppContainer : WindowsFormsApplicationBase
    {
        public AppContainer()
        {
            IsSingleInstance = true;
            EnableVisualStyles = true;
            ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

        protected override void OnCreateMainForm()
        {
            MainForm = new LoginForm();//MainHome
        }
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainHome());

            AppContainer app = new AppContainer();
            app.Run(Environment.GetCommandLineArgs());
        }
    }
}