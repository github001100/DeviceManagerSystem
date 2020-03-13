using DeviceManagerSystem.TPM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManagerSystem
{
    public partial class MainHome : Form
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
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

        public MainHome()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false

            asc.controllInitializeSize(this);
            //this.label1.Parent = this.pictureBox1;
            //this.label1.BackColor = Color.Transparent;
            label1.Left = (this.ClientRectangle.Width - label1.Width) / 2;
            label1.BringToFront();
            this.label2.Parent = this.pictureBox1;
            this.label2.BackColor = Color.Transparent;
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        label2.BeginInvoke(new MethodInvoker(() =>
                            label2.Text = "" + DateTime.Now.ToString() + "    " + GetWeek()));
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

        }
        UserMain ucfl = new UserMain();
        UserZCJC UserZCJC = new UserZCJC();
        UserZTJXJD UserZTJXJD = new UserZTJXJD();
        UserLBJJXJD UserLBJJXJD = new UserLBJJXJD();
        UserLDJC UserLDJC = new UserLDJC();
        UserLZZZ UserLZZZ = new UserLZZZ();
        UserJXJHJK UserJXJHJK = new UserJXJHJK();
        UserJXJHXD UserJXJHXD = new UserJXJHXD();
        UserJXJHXD_LBJ UserJXJHXD_LBJ = new UserJXJHXD_LBJ();
        UserAbout UserAbout = new UserAbout();

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
            this.panel1.Controls.Clear();
            AddUserControl(UserZCJC);
        }

        private void 其它ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 整体检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            AddUserControl(UserZTJXJD);
        }

        private void 零部件检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            this.panel1.Controls.Clear();
            AddUserControl(UserLDJC);
        }

        private void 轮轴组装检修进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            AddUserControl(UserLZZZ);
        }

        private void 设备可视化大屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.panel1.Controls.Clear();
            AddUserControl(ucfl);

        }

        private void 检修计划监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            AddUserControl(UserJXJHJK);
        }

        private void 检修计划修订ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            AddUserControl(UserJXJHXD);
        }

        private void 检修计划修订零部件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(Post("x", "http://localhost:8099/UserLogin/CheckUserLogin"),"CAYA");
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
        public void Lun() {

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

            }

            //当i=4时，i变为0，然后重新开始；

            if (i == 6)
            {

                i = 0;

            }
        }
        private void 开启自动切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (开启自动切换ToolStripMenuItem.Text == "开启自动切换")
            {
                timer1.Enabled = true;
                timer1.Interval = 5000;
                开启自动切换ToolStripMenuItem.Text = "关闭自动切换";
            }
            else
            {
                timer1.Enabled = false;
                开启自动切换ToolStripMenuItem.Text = "开启自动切换";

            }
        }
    }
}
