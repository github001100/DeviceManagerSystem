using CMES.Controller.SYS;
using CMES.Data;
using CMES.Entity.SYS;
using CMES.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManagerSystem.Others
{
    public partial class UserLoginForm : Form
    {
        DatabaseSQLite Dbsqlite { get; set; }
        string getloginName = "";
        string getloginPWD = "";
        UserLogin ulogin = new UserLogin();
        //数据获取结束标记 True 获取结束，False 未完全获取
        bool flagGetDataOver = false;
        private Thread tmyThrdGetdata;
        public delegate void PDelegate_Close();
        // 界面文本提示委托
        public delegate void PDelegate(string infoTxt);
        //界面信息禁用提示
        public delegate void PDelegate_Form(bool isOK);
        public delegate void OKsign(EmployeeApi opeUse, DatabaseSQLite dbsqlite);

        /// <summary>
        /// 窗体动画函数
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        public UserLoginForm(DatabaseSQLite dbsqliteIn)
        {
            InitializeComponent();
            Dbsqlite = dbsqliteIn;

        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 300, AW_SLIDE | AW_ACTIVE | AW_VER_POSITIVE);
            this.toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
            loginName.Focus();
            loginPWD.Focus();
            //时间显示
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        statusStrip1.BeginInvoke(new MethodInvoker(() =>
                            toolStripStatusLabel2.Text = "" + DateTime.Now.ToString()));
                    }
                    catch { }
                    Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }
        /// <summary>
        /// 数据加载异步显示  
        /// </summary>
        private void IniGetData()
        {
            ////窗口按钮不可用
            //this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { false });
            string messg = string.Empty;
            bool issingle = false;
            string memo = string.Empty;
            EmployeeApi opeUser = new EmployeeApi();
            try
            {
                //System.Threading.Thread.Sleep(6000);
                string userID = getloginName;
                string userPwd = getloginPWD;
                if (userID.Equals(string.Empty))
                {
                    //演示模式
                    issingle = true;
                }
                else
                {
                    //系统模式
                    opeUser = ulogin.GetUserByAccount(userID);
                    //登录
                    if (opeUser != null && opeUser.LoginPwd != null && !opeUser.LoginPwd.Equals(string.Empty))
                    {
                        //DESEncrypt.Encrypt(userPwd, opeUser.SecretKey)
                        if (!opeUser.LoginPwd.Equals(userPwd))
                        {
                            this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "状态提示：登录失败," + "账号或密码错误！" });
                            flagGetDataOver = false;
                            //flagCancel = true;
                            this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { true });
                        }
                        else
                        {
                            #region 登录日志
                            try
                            {
                                flagGetDataOver = true;
                                this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "添加系统日志" });
                            }
                            catch (Exception e)
                            {
                                ErrorLogMsg.CreateErrLog("登录异常", "201", e.ToString());
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "状态提示：登录失败," + "账号或密码错误！" });
                        flagGetDataOver = false;
                        //flagCancel = true;
                        this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { true });

                    }
                }
            }
            catch (Exception eee)
            {
                messg = "网络延时 请重试:" + eee.Message + " Inf0:" + eee.StackTrace;
                this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "状态提示：" + "网络延时,请重试------请检查网络连接并启动服务!" });
                //isOK = false;
                ErrorLogMsg.CreateErrLog("网络延时", "201", messg);
                issingle = true;
            }
            if (flagGetDataOver)
            {
                //Thread.Sleep(100);

                ////窗口按钮可用
                this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { false });

                //Thread.Sleep(100);
                ////QueryStop();
                this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "状态提示：正在登录系统......" });
                Thread.Sleep(100);

                this.BeginInvoke(new OKsign(FormOpen), new object[] { opeUser, Dbsqlite });

            }
            else if (issingle)
            {
                //Thread.Sleep(100);

                ////窗口按钮可用
                this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { false });

                this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "状态提示：当前为单机运行模式" });
                Thread.Sleep(3000);
                ////QueryStop();
                this.BeginInvoke(new OKsign(FormOpen), new object[] { opeUser, Dbsqlite });

            }
        }
        private void GoLogin()
        {
            //SysVar.OpenCloseKey();
            #region 登陆

            flagGetDataOver = false;
            //获取用户输入的信息           
            getloginName = this.loginName.Text;
            getloginPWD = this.loginPWD.Text;
            try
            {
                tmyThrdGetdata = new Thread(new ThreadStart(IniGetData));
                tmyThrdGetdata.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "：数据查询失败");
                this.Close();
                return;
            }
            #endregion
        }
        private void FormClose()
        {
            if (tmyThrdGetdata != null)
            {
                tmyThrdGetdata.Abort();
            }
            this.Hide();
        }
        /// <summary>
        /// 新窗口打开
        /// </summary>
        private void FormOpen(EmployeeApi opeUse, DatabaseSQLite dbsqlite)
        {
            //MainHome fm = new MainHome(dbsqlite)
            //{
            //    Tag = opeUse
            //};
            MainHome fm = MainHome.CreateInstrance(dbsqlite);//创建单例窗体2020.3.24
            Tag = opeUse;
            ulogin.SetUserXML(opeUse);
            //Thread.Sleep(100);
            fm.Show();
            this.BeginInvoke(new PDelegate_Close(FormClose));
        }
        /// <summary>
        ///  进程查询提示
        /// </summary>
        private void ShowInfoTxt(string txt)
        {
            this.statusStrip1.Items[0].Text = txt;
            toolStripStatusLabel1.ForeColor = Color.Red;
        }
        /// <summary>
        /// 窗口禁用
        /// </summary>
        private void FormEnable(bool isOK)
        {
            this.loginName.Enabled = isOK;
            this.loginPWD.Enabled = isOK;
            this.btn_login.Enabled = isOK;
            this.button2.Enabled = isOK;
            //loginPWD.Text = "";
            loginPWD.Focus();
        }
        public string CheckLogin(string userName, string Pwd)
        {
            if (userName.Trim() == "" || Pwd.Trim() == "")
            {
                return "False";
            }
            else
            {
                return "True";
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string userName = loginName.Text.Trim();
            string Pwd = loginPWD.Text;
            if (CheckLogin(userName, Pwd) == "True")
            {
                GoLogin();

            }
            else
            {
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void loginPWD_KeyDown(object sender, KeyEventArgs e)
        {
            //在输入完成密码后按下enter键进入系统
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.btn_login_Click(sender, e);//触发button事件
            }
        }
    }
}
