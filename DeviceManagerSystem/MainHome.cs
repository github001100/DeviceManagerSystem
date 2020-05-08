using CMES.Controller.SYS;
using CMES.Data;
using DeviceManagerSystem.TPM;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DeviceManagerSystem
{
    /// <summary>
    /// MainHome    主窗体 
    /// @洛阳开远
    /// @2020.03.14
    /// @FSJ
    /// </summary>
    public partial class MainHome : Form
    {
        LdkpController ldkp = new LdkpController();
        ZtjkController ztjk = new ZtjkController();
        DeviceController device = new DeviceController();
        LDJXController ldjx = new LDJXController();
        ZZGXController zzgx = new ZZGXController();

        private static MainHome frm = null;
        AutoSizeFormClass asc = new AutoSizeFormClass();
        int interval = 5;
        //------------------------------------------------------  控件大小随窗体大小变化
        private float X;
        private float Y;

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        public static MainHome CreateInstrance(DatabaseSQLite dbsqlite)
        {
            if (frm == null)
            {
                frm = new MainHome(dbsqlite);
            }
            return frm;
        }
        private void setControls(float newx, float newy, Control cons)
        {
            try
            {
                foreach (Control con in cons.Controls)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                    float a = Convert.ToSingle(mytag[0]) * newx;
                    con.Width = (int)a;
                    a = Convert.ToSingle(mytag[1]) * newy;
                    con.Height = (int)(a);
                    a = Convert.ToSingle(mytag[2]) * newx;
                    con.Left = (int)(a);
                    a = Convert.ToSingle(mytag[3]) * newy;
                    con.Top = (int)(a);
                    Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }

        }

        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }
        //--------------------------------------------------------------------------   控件大小随窗体大小变化结束
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112)
            {
                switch ((int)m.WParam)
                {
                    //禁止双击标题栏关闭窗体
                    case 0xF063:
                    case 0xF093:
                        m.WParam = IntPtr.Zero;
                        break;
                    //禁止拖拽标题栏还原窗体
                    case 0xF012:
                    case 0xF010:
                        //m.WParam = IntPtr.Zero;
                        break;
                    //禁止双击标题栏
                    case 0xf122:
                        m.WParam = IntPtr.Zero;
                        break;
                    //禁止关闭按钮
                    case 0xF060:
                        //m.WParam = IntPtr.Zero;
                        break;
                    //禁止最大化按钮
                    case 0xf020:
                        //m.WParam = IntPtr.Zero;
                        break;
                    //禁止最小化按钮
                    case 0xf030:
                        //m.WParam = IntPtr.Zero;
                        break;
                    //禁止还原按钮
                    case 0xf120:
                        //m.WParam = IntPtr.Zero;
                        break;
                }
            }
            base.WndProc(ref m);
        }

        public MainHome(CMES.Data.DatabaseSQLite dbsqlite)
        {
            InitializeComponent();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
            #region 窗体缩放
            GetAllInitInfo(this.Controls[0]);
            #endregion
            //asc.controllInitializeSize(this);
            //this.label1.Parent = this.pictureBox1;
            //this.label1.BackColor = Color.Transparent;
            label1.Left = (this.ClientRectangle.Width - label1.Width) / 2;
            label1.BringToFront();
            //this.label2.Parent = this.pictureBox1;
            //this.label2.BackColor = Color.Transparent;
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        if (label2.IsHandleCreated)
                            label2.BeginInvoke(new MethodInvoker(() =>
                                label2.Text = "" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "    " + GetWeek()));//24h
                    }
                    catch { }
                    Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }
        private void SetLanguage()
        {
            this.Text = GlobalData.GlobalLanguage.Title;
            this.label1.Text = GlobalData.GlobalLanguage.Title;

        }
        private string GetWeek()
        {
            string week = string.Empty;
            switch ((int)DateTime.Now.DayOfWeek)
            {
                case 0:
                    week = "星期日";
                    break;
                case 1:
                    week = "星期一";
                    break;
                case 2:
                    week = "星期二";
                    break;
                case 3:
                    week = "星期三";
                    break;
                case 4:
                    week = "星期四";
                    break;
                case 5:
                    week = "星期五";
                    break;
                default:
                    week = "星期六";
                    break;
            }
            return week;
        }
        System.Reflection.FieldInfo[] _List;
        private void MainHome_Load(object sender, EventArgs e)
        {
            _List = this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            interval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Interval"]) * 1000;
            timer1.Interval = Convert.ToInt32(interval);
            SetLanguage();
            AddUserControl(UserAbout);//UserAbout  ucfl
            try
            {
                //--------------------------------控件大小随窗体大小变化
                this.Resize += new EventHandler(Form1_Resize);

                X = this.Width;
                Y = this.Height;

                setTag(this);
                Form1_Resize(new object(), new EventArgs());
                //---------------------------------控件大小随窗体大小变化
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void MainHome_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
            if (ControlsInfo.Count > 0)//如果字典中有数据，即窗体改变
            {
                ControlsChaneInit(this.Controls[0]);//表示pannel控件
                ControlsChange(this.Controls[0]);

            }
        }
        #region 自定义窗体显示界面
        UserAbout UserAbout = new UserAbout();
        #endregion
        delegate void addDelegate();
        addDelegate d;
        private void AddUserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;//填充panel
            this.panel1.Controls.Clear();
            if (this.panel1.InvokeRequired)
            {
                this.panel1.Invoke(d);//d为在主线程中创建的代理引用
                                      //d所代理的方法应该是添加控件的内容
            }
            else
            {
                this.panel1.Controls.Add(user);//向panel添加用户控件
            }
        }

        private void 轴承检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserZCJC UserZCJC = UserZCJC.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserZCJC);
        }

        private void 其它ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 整体检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserZTJXJD UserZTJXJD = UserZTJXJD.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserZTJXJD);
        }

        private void 零部件检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLBJJXJD UserLBJJXJD = UserLBJJXJD.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserLBJJXJD);
        }

        private void MainHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "系统提示"
             , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                System.Environment.Exit(0);

            }

        }

        private void 轮对检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLDJC UserLDJC = UserLDJC.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserLDJC);
        }

        private void 轮轴组装检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLZZZ UserLZZZ = UserLZZZ.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserLZZZ);
        }

        private void 设备可视化大屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMain ucfl = UserMain.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(ucfl);

        }

        private void 检修计划监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserJXJHJK UserJXJHJK = UserJXJHJK.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserJXJHJK);
        }

        private void 检修计划修订ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserJXJHXD UserJXJHXD = UserJXJHXD.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserJXJHXD);
        }

        private void 检修计划修订零部件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserJXJHXD_LBJ UserJXJHXD_LBJ = UserJXJHXD_LBJ.CreateInstrance();

            this.panel1.Controls.Clear();
            AddUserControl(UserJXJHXD_LBJ);
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process vProcess = Process.Start("notepad.exe");

        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process vProcess = Process.Start("calc.exe");

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            AddUserControl(UserAbout);
        }
        /// <summary>
        /// Post http://localhost:8009/UserLogin/GetUserInfo
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Post(string str, string apiUrl)
        {
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer();
            string result = "";
            HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(apiUrl);//设备状态接口
            req.Method = "POST";
            req.ContentType = "application/json";
            //req.ContentType = "application/x-www-form-urlencoded";

            byte[] data = Encoding.UTF8.GetBytes(str);//把字符串转换为字节

            req.ContentLength = data.Length; //请求长度
            try
            {
                using (Stream reqStream = req.GetRequestStream()) //获取
                {
                    reqStream.Write(data, 0, data.Length);//向当前流中写入字节

                    reqStream.Close(); //关闭当前流
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); //响应结果
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("连接失败");

                //throw;
            }

            return result;
        }
        /// <summary>
        /// Post http://localhost:53097/api/Ldkp/PostLdkpInfo
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string PostTest(string str, string api)
        {
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer();
            string result = "";
            HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://localhost:8077/api/Ldkp/PostLdkpInfo");//设备状态接口
            req.Method = "POST";
            //req.Headers.Add("id", "272");

            req.ContentType = "application/json";
            //req.ContentType = "application/x-www-form-urlencoded";

            byte[] data = Encoding.UTF8.GetBytes(str);//把字符串转换为字节

            req.ContentLength = data.Length; //请求长度
            try
            {
                using (Stream reqStream = req.GetRequestStream()) //获取
                {
                    reqStream.Write(data, 0, data.Length);//向当前流中写入字节

                    reqStream.Close(); //关闭当前流
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); //响应结果
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                MessageBox.Show(result);

            }
            catch (Exception ex)
            {
                MessageBox.Show("服务未响应" + ex.Message);
            }
            finally
            {

            }

            return result;
        }
        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ldkpApi ldkpApi = new ldkpApi();

            //1轮对
            //JObject jsonobj = null;
            //string  jsonStr = ldkp.GetLdkpInfoToJson("272");
            //JObject o = JObject.Parse(jsonStr);

            //JArray json = (JArray)o["data"];
            //for (int j = 0; j < json.Count; j++)
            //{
            //    jsonobj = (JObject)json[j];
            //    Console.WriteLine(jsonobj["id"].ToString() + "|" + jsonobj["lz_QRcode"].ToString());
            //    MessageBox.Show(jsonobj["id"].ToString() + "|" + jsonobj["lz_QRcode"].ToString(), json.Count+"共");

            //}
            //2整体检修
            JObject jsonobj2 = null;
            //string jsonStr2 = ztjk.GetZtjkInfoByProcedureNameToJson("ALL", "ALL");//轮对检修
            //string jsonStr22 = device.GetDeviceInfoToJson("DeviceName", "DeviceNumber");
            string jsonStr22 = zzgx.GetZZGXInfoToJson("ALL", "DeviceNumber");
            JObject o2 = JObject.Parse(jsonStr22);

            JArray json2 = (JArray)o2["data"];
            for (int j = 0; j < json2.Count; j++)
            {
                jsonobj2 = (JObject)json2[j];

                //Console.WriteLine(jsonobj2["DeviceStatus"].ToString(), json2.Count + "共");

            }
            //PostTest("", "");//请求方式二 Http  Post To Json
            //MessageBox.Show(Post("x", "http://localhost:8099/UserLogin/CheckUserLogin"), "CAYA");
        }
        private void OnFind(ToolStripItem tsi)
        {
            //textBox1.Text += tsi.Text + "\r\n";
        }
        string[] item = { "整体检修进度ToolStripMenuItem", "轴承检修进度ToolStripMenuItem", "零部件检修进度ToolStripMenuItem", "轮轴组装检修进度ToolStripMenuItem", "轮轴组装检修进度ToolStripMenuItem", "检修计划监控ToolStripMenuItem" };
        private void EnumChildMenu(ToolStripItem tsi)
        {
            //OnFind(tsi);
            if (tsi is ToolStripMenuItem)
            {
                ToolStripMenuItem tsmi = tsi as ToolStripMenuItem;
                foreach (ToolStripItem item in tsmi.DropDownItems)
                {
                    switch ((item as ToolStripMenuItem).Name)
                    {
                        case "整体检修进度ToolStripMenuItem":
                            //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                            //MessageBox.Show(_Menu.Name);
                            整体检修进度ToolStripMenuItem_Click(this, null);

                            break;
                        case "轴承检修进度ToolStripMenuItem":
                            //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                            //MessageBox.Show(_Menu.Name);
                            轴承检修进度ToolStripMenuItem_Click(this, null);

                            break;
                        case "零部件检修进度ToolStripMenuItem":
                            //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                            //MessageBox.Show(_Menu.Name);
                            零部件检修进度ToolStripMenuItem_Click(this, null);

                            break;
                        case "轮轴组装检修进度ToolStripMenuItem":
                            //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                            //MessageBox.Show(_Menu.Name);
                            轮轴组装检修进度ToolStripMenuItem_Click(this, null);

                            break;
                        case "检修计划监控ToolStripMenuItem":
                            //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                            //MessageBox.Show(_Menu.Name);
                            检修计划监控ToolStripMenuItem_Click(this, null);

                            break;

                    }
                    EnumChildMenu(item);
                }
            }
        }
        public void Lun()
        {

            EnumChildMenu(this.可视化管理ToolStripMenuItem);
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Lun();

            i++;

            switch (i)
            {
                case 5:
                    //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                    //MessageBox.Show(_Menu.Name);
                    整体检修进度ToolStripMenuItem_Click(this, null);
                    break;
                case 1:
                    //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                    //MessageBox.Show(_Menu.Name);
                    轴承检修进度ToolStripMenuItem_Click(this, null);
                    break;
                case 2:
                    //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                    //MessageBox.Show(_Menu.Name);
                    零部件检修进度ToolStripMenuItem_Click(this, null);
                    break;
                case 3:
                    //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                    //MessageBox.Show(_Menu.Name);
                    轮轴组装检修进度ToolStripMenuItem_Click(this, null);
                    break;
                case 4:
                    //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                    //MessageBox.Show(_Menu.Name);
                    检修计划监控ToolStripMenuItem_Click(this, null);
                    break;
                case 6:
                    //MenuItem _Menu = (MenuItem)_List[i].GetValue(this);
                    //MessageBox.Show(_Menu.Name);
                    设备可视化大屏ToolStripMenuItem_Click(this, null);
                    break;
                default:
                    轮轴组装检修进度ToolStripMenuItem_Click(this, null);
                    break;
            }

            //当i=4时，i变为0，然后重新开始；

            if (i == 7)
            {
                i = 0;
            }
        }
        private void 开启自动切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (开启自动切换ToolStripMenuItem.Text == "开启自动切换")
            {
                timer1.Enabled = true;
                timer1.Interval = interval;
                开启自动切换ToolStripMenuItem.Text = "关闭自动切换";
                开启自动切换ToolStripMenuItem1.Text = "关闭自动切换";
            }
            else
            {
                timer1.Enabled = false;
                开启自动切换ToolStripMenuItem.Text = "开启自动切换";
                开启自动切换ToolStripMenuItem1.Text = "开启自动切换";

            }
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
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 系统信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process vProcess = Process.Start("msinfo32.exe");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //menuStrip1.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //menuStrip1.Visible = false;

        }
        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);

        }

        private void 显示菜单栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //menuStrip1.Visible = true;
            if (显示菜单栏ToolStripMenuItem.Text == "显示菜单栏")
            {
                label1.Top = 79;
                label2.Top = 79;
                显示菜单栏ToolStripMenuItem.Text = "隐藏菜单栏";
                menuStrip1.Visible = true;
                //this.FormBorderStyle = FormBorderStyle.Sizable;

                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                label1.Top = 79 - 显示菜单栏ToolStripMenuItem.Height - 24;
                label2.Top = 79 - 显示菜单栏ToolStripMenuItem.Height - 24;

                显示菜单栏ToolStripMenuItem.Text = "显示菜单栏";
                menuStrip1.Visible = false;
                //this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

            }
        }

        private void 开启自动切换ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (开启自动切换ToolStripMenuItem1.Text == "开启自动切换")
            {
                timer1.Enabled = true;
                timer1.Interval = interval;
                开启自动切换ToolStripMenuItem1.Text = "关闭自动切换";
                开启自动切换ToolStripMenuItem.Text = "关闭自动切换";
            }
            else
            {
                timer1.Enabled = false;
                开启自动切换ToolStripMenuItem1.Text = "开启自动切换";
                开启自动切换ToolStripMenuItem.Text = "开启自动切换";

            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Normal;
            //label1.Top = 79 ;
            //label2.Top = 79 ;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
