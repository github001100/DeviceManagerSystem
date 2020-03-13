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
using CMES.Controller.SYS;
using CMES.Entity.SYS;
using CMES.Util;
using CMES.Utility;

namespace DeviceManagerSystem.Others
{
    public partial class LoginForm : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        string getloginName = "";
        string getloginPWD = "";
        UserLogin ulogin = new UserLogin();
        //数据获取结束标记 True 获取结束，False 未完全获取
        bool flagGetDataOver = false;
        private Thread tmyThrdGetdata;
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
        public LoginForm()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

            this.label1.Parent = this.pictureBox1;
            this.label1.BackColor = Color.Transparent;
            this.label2.Parent = this.pictureBox1;
            this.label2.BackColor = Color.Transparent;
            this.label3.Parent = this.pictureBox1;

            this.label3.BackColor = Color.Transparent;
            //this.label4.Parent = this.pictureBox1;

            //this.label4.BackColor = Color.Transparent;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        public string CheckLogin(string userName, string Pwd)
        {
            if (userName == "kyjj" && Pwd == "kyjj")
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }
        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);

        }
        private void GoLogin()
        {
            //SysVar.OpenCloseKey();
            #region 登陆

            flagGetDataOver = false;
            //获取用户输入的信息           
            string name = this.loginName.Text;
            string pwd = this.loginPWD.Text;
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

                string userID = getloginName;//this.loginName.Text.Trim();
                string userPwd = getloginPWD;//this.loginPWD.Text.Trim();

                if (userID.Equals(string.Empty))
                {
                    //演示模式
                    issingle = true;
                }
                else
                {
                    //系统模式
                    opeUser = ulogin.GetUserByAccount(userID);
                    //框登录
                    if (opeUser != null && opeUser.LoginPwd != null && !opeUser.LoginPwd.Equals(string.Empty))
                    {

                        if (!opeUser.LoginPwd.Equals(DESEncrypt.Encrypt(userPwd, opeUser.SecretKey)))
                        {
                            //this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "登录失败:" + "密码不正确！" });
                            //flagGetDataOver = false;
                            //flagCancel = true;
                            //this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { true });
                        }
                        else
                        {
                            #region 登录日志
                            try
                            {
                                flagGetDataOver = true;
                                //this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "添加系统日志" });
                            }
                            catch (Exception ee)
                            {
                                ErrorLogMsg.CreateErrLog("登录异常", "201", ee.ToString());
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        //this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "登录失败:" + "用户不存在！" });
                        //flagGetDataOver = false;
                        //flagCancel = true;
                        //this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { true });
                    }
                }
            }
            catch (Exception eee)
            {
                messg = "网络延时 请重试:" + eee.Message + " Inof:" + eee.StackTrace;
                //this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "网络延时 请重试:" + messg });
                // isOK = false;
            }
            if (flagGetDataOver)
            {
                //Thread.Sleep(100);

                ////窗口按钮可用
                //this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { true });

                //this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "开始登录......" });
                //Thread.Sleep(100);
                ////QueryStop();
                //this.BeginInvoke(new OKsign(FormOpen), new object[] { opeUser, Dbsqlite });

            }
            else if (issingle)
            {
                //Thread.Sleep(100);

                ////窗口按钮可用
                //this.BeginInvoke(new PDelegate_Form(FormEnable), new object[] { true });

                //this.BeginInvoke(new PDelegate(ShowInfoTxt), new object[] { "开始登录......" });
                //Thread.Sleep(100);
                ////QueryStop();
                //this.BeginInvoke(new OKsign(FormOpenView), new object[] { opeUser, Dbsqlite });
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            string userName = loginName.Text.Trim();
            string Pwd = loginPWD.Text;

            if (CheckLogin(userName, Pwd) == "True")
            {
                //GoLogin();
                MainHome M = new MainHome();
                M.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //在输入完成密码后按下enter键进入系统
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                this.btn_login_Click(sender, e);//触发button事件
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            //int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            //this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 500, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);

        }
    }

}

