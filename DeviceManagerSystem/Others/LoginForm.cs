using CMES.Controller.SYS;
using CMES.Data;
using CMES.Entity.SYS;
using CMES.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
        public delegate void PDelegate_Close();
        // 界面文本提示委托
        public delegate void PDelegate(string infoTxt);
        //界面信息禁用提示
        public delegate void PDelegate_Form(bool isOK);
        DatabaseSQLite Dbsqlite { get; set; }
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
        public LoginForm(DatabaseSQLite dbsqliteIn)
        {
            InitializeComponent();
            //asc.controllInitializeSize(this);

            this.label1.Parent = this.pictureBox1;
            this.label1.BackColor = Color.Transparent;
            this.label2.Parent = this.pictureBox1;
            this.label2.BackColor = Color.Transparent;
            this.label3.Parent = this.pictureBox1;

            this.label3.BackColor = Color.Transparent;
            this.label4.BackColor = Color.Transparent;
            this.label4.ForeColor = Color.Red;
            this.label4.Parent = this.panel1;

            Dbsqlite = dbsqliteIn;
            #region 窗体缩放
            GetAllInitInfo(this.Controls[0]);
            #endregion
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
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
        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
            if (ControlsInfo.Count > 0)//如果字典中有数据，即窗体改变
            {
                ControlsChaneInit(this.Controls[0]);//表示pannel控件
                ControlsChange(this.Controls[0]);

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
            MainHome fm = new MainHome(dbsqlite)
            {
                Tag = opeUse
            };
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
            //this.button1.Enabled = !isOK;
            //loginPWD.Text = "";
            label4.Enabled = isOK;
            loginPWD.Focus();
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
                            catch (Exception ee)
                            {
                                ErrorLogMsg.CreateErrLog("登录异常", "201", ee.ToString());
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
                Thread.Sleep(3000);

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
            AnimateWindow(this.Handle, 300, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);

        }
        #region 控件缩放
        double formWidth;//窗体原始宽度
        double formHeight;//窗体原始高度
        double scaleX;//水平缩放比例
        double scaleY;//垂直缩放比例
        Dictionary<string, string> ControlsInfo = new Dictionary<string, string>();//控件中心Left,Top,控件Width,控件Height,控件字体Size

        #endregion
        protected void GetAllInitInfo(Control ctrlContainer)
        {
            if (ctrlContainer.Parent == this)//获取窗体的高度和宽度
            {
                formWidth = Convert.ToDouble(ctrlContainer.Width);
                formHeight = Convert.ToDouble(ctrlContainer.Height);
            }
            foreach (Control item in ctrlContainer.Controls)
            {
                if (item.Name.Trim() != "")
                {
                    //添加信息：键值：控件名，内容：据左边距离，距顶部距离，控件宽度，控件高度，控件字体。
                    ControlsInfo.Add(item.Name, (item.Left + item.Width / 2) + "," + (item.Top + item.Height / 2) + "," + item.Width + "," + item.Height + "," + item.Font.Size);
                }
                if ((item as UserControl) == null && item.Controls.Count > 0)
                {
                    GetAllInitInfo(item);
                }
            }

        }
        private void ControlsChaneInit(Control ctrlContainer)
        {
            scaleX = (Convert.ToDouble(ctrlContainer.Width) / formWidth);
            scaleY = (Convert.ToDouble(ctrlContainer.Height) / formHeight);
        }
        /// <summary>
        /// 改变控件大小
        /// </summary>
        /// <param name="ctrlContainer"></param>
        private void ControlsChange(Control ctrlContainer)
        {
            double[] pos = new double[5];//pos数组保存当前控件中心Left,Top,控件Width,控件Height,控件字体Size
            foreach (Control item in ctrlContainer.Controls)//遍历控件
            {
                if (item.Name.Trim() != "")//如果控件名不是空，则执行
                {
                    if ((item as UserControl) == null && item.Controls.Count > 0)//如果不是自定义控件
                    {
                        ControlsChange(item);//循环执行
                    }
                    string[] strs = ControlsInfo[item.Name].Split(',');//从字典中查出的数据，以‘，’分割成字符串组

                    for (int i = 0; i < 5; i++)
                    {
                        pos[i] = Convert.ToDouble(strs[i]);//添加到临时数组
                    }
                    double itemWidth = pos[2] * scaleX;     //计算控件宽度，double类型
                    double itemHeight = pos[3] * scaleY;    //计算控件高度
                    item.Left = Convert.ToInt32(pos[0] * scaleX - itemWidth / 2);//计算控件距离左边距离
                    item.Top = Convert.ToInt32(pos[1] * scaleY - itemHeight / 2);//计算控件距离顶部距离
                    item.Width = Convert.ToInt32(itemWidth);//控件宽度，int类型
                    item.Height = Convert.ToInt32(itemHeight);//控件高度
                    item.Font = new Font(item.Font.Name, float.Parse((pos[4] * Math.Min(scaleX, scaleY)).ToString()));//字体

                }
            }

        }
    }

}

