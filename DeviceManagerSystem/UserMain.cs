using CMES.Controller.SYS;
using CMES.Entity.SYS;
using CMES.NET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManagerSystem
{
    /// <summary>
    /// 设备监控主界面UserMain
    /// @洛阳开远
    /// @2020.03.14
    /// @FSJ
    /// </summary>
    public partial class UserMain : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        ZtjkController ztjk = new ZtjkController();//整体检修 业务逻辑2.0

        public static Color Opc;
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
        private static UserMain frm = null;

        public static UserMain CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new UserMain();
            }
            return frm;
        }
        public UserMain()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }
        Int32[] num = { 0, 0, 0, 0 };
        int s_T_num_1 = 0;//停机数
        int s_T_num_2 = 0;//故障
        int s_T_num_3 = 0;//维修
        int s_T_num_4 = 0;//维修
        int s_T_num_5 = 0;//维修

        public void CountMyCircle(Panel[] panels, int row)
        {

            for (int i = 0; i < panels.Length; i++)
            {
                foreach (var item in (panels[i].Controls))
                {
                    if (item is CMES.Controls.MyCircle)
                    {
                        //for (int j = 0; j < num.Length; j++)
                        {
                            if ((item as CMES.Controls.MyCircle).ButtonCenterColorEnd == Color.Gray)
                            {
                                s_T_num_1 = s_T_num_1 + 1;

                            }
                            else if ((item as CMES.Controls.MyCircle).ButtonCenterColorEnd == Color.Red)
                            {
                                s_T_num_2 = s_T_num_2 + 1;

                            }
                            else if (((item as CMES.Controls.MyCircle).ButtonCenterColorEnd == Color.Yellow))
                            {
                                s_T_num_3 = s_T_num_3 + 1;

                            }
                            else if ((item as CMES.Controls.MyCircle).ButtonCenterColorEnd == Color.Aqua)
                            {
                                s_T_num_4 = s_T_num_4 + 1;

                            }
                            else if ((item as CMES.Controls.MyCircle).ButtonCenterColorEnd == Color.Lime)
                            {
                                s_T_num_5 = s_T_num_5 + 1;

                            }

                        }
                        //(item as CMES.Controls.MyCircle).ButtonCenterColorStart = color;

                    }
                }

            }
            this.dataGridView1.Rows[row].Cells[2].Value = s_T_num_5;//ps
            this.dataGridView1.Rows[row].Cells[3].Value = s_T_num_1;//ps
            this.dataGridView1.Rows[row].Cells[4].Value = s_T_num_2;//ps
            this.dataGridView1.Rows[row].Cells[5].Value = s_T_num_3;//ps
            this.dataGridView1.Rows[row].Cells[6].Value = s_T_num_4;//ps
            this.dataGridView1.Rows[0].Cells[2].Value = Convert.ToInt32(this.dataGridView1.Rows[1].Cells[2].Value) + Convert.ToInt32(this.dataGridView1.Rows[2].Cells[2].Value) + Convert.ToInt32(this.dataGridView1.Rows[3].Cells[2].Value);
            this.dataGridView1.Rows[0].Cells[3].Value = Convert.ToInt32(this.dataGridView1.Rows[1].Cells[3].Value) + Convert.ToInt32(this.dataGridView1.Rows[2].Cells[3].Value) + Convert.ToInt32(this.dataGridView1.Rows[3].Cells[3].Value);
            this.dataGridView1.Rows[0].Cells[4].Value = Convert.ToInt32(this.dataGridView1.Rows[1].Cells[4].Value) + Convert.ToInt32(this.dataGridView1.Rows[2].Cells[4].Value) + Convert.ToInt32(this.dataGridView1.Rows[3].Cells[4].Value);
            this.dataGridView1.Rows[0].Cells[5].Value = Convert.ToInt32(this.dataGridView1.Rows[1].Cells[5].Value) + Convert.ToInt32(this.dataGridView1.Rows[2].Cells[5].Value) + Convert.ToInt32(this.dataGridView1.Rows[3].Cells[5].Value);
            this.dataGridView1.Rows[0].Cells[6].Value = Convert.ToInt32(this.dataGridView1.Rows[1].Cells[6].Value) + Convert.ToInt32(this.dataGridView1.Rows[2].Cells[6].Value) + Convert.ToInt32(this.dataGridView1.Rows[3].Cells[6].Value);
            s_T_num_1 = 0;
            s_T_num_2 = 0;
            s_T_num_3 = 0;
            s_T_num_4 = 0;
            s_T_num_5 = 0;

            //MessageBox.Show(num[0].ToString());
        }
        Panel[] ps, ps2, ps3;
        public void InitDataTable()
        {
            ps = new Panel[] { panel31, panel34, panel26, panel29, panel32, panel35, panel38, panel60, panel45, panel41, panel44, panel47, panel39, panel42, panel50, panel53, panel51, panel52 };

            ps2 = new Panel[]{ panel23,panel24,panel36, panel48 , panel59 , panel54,
                panel55, panel56,panel21,panel22 };

            ps3 = new Panel[]{ panel11,panel2, panel3, panel4 , panel5 , panel6,
                panel7, panel8, panel9, panel10, panel13,panel14, panel16,panel20,panel15,panel18,panel30 ,
                panel57, panel58, panel33,panel46,panel43, panel61, panel62, panel63,panel12,panel17,panel27,panel19,panel40,
                panel37, panel25, panel28,panel64 };
            foreach (var item in (ps))
            {
                if (item is Panel)
                {
                    (item as Panel).BackColor = Color.Thistle;

                }
            }
            foreach (var item in (ps2))
            {
                if (item is Panel)
                    (item as Panel).BackColor = Color.Magenta;//BlueViolet
            }
            foreach (var item in (ps3))
            {
                if (item is Panel)
                    (item as Panel).BackColor = Color.CornflowerBlue;//BlueViolet
            }

            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
            dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }

            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "轮轴车间";
            this.dataGridView1.Rows[index].Cells[1].Value = (ps.Count() + ps2.Count() + ps3.Count());
            this.dataGridView1.Rows[index].Cells[2].Value = "58";
            this.dataGridView1.Rows[index].Cells[3].Value = "4";
            this.dataGridView1.Rows[index].Cells[4].Value = "0";
            this.dataGridView1.Rows[index].Cells[5].Value = "0";
            this.dataGridView1.Rows[index].Cells[6].Value = "0";
            this.dataGridView1.Rows[index].Cells[7].Value = "01:33:29";
            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "轮对工班";//ps3
            this.dataGridView1.Rows[index2].Cells[1].Value = ps3.Count();
            this.dataGridView1.Rows[index2].Cells[2].Value = "30";
            this.dataGridView1.Rows[index2].Cells[3].Value = "4";
            this.dataGridView1.Rows[index2].Cells[4].Value = "0";
            this.dataGridView1.Rows[index2].Cells[5].Value = "0";
            this.dataGridView1.Rows[index2].Cells[6].Value = "0";
            this.dataGridView1.Rows[index2].Cells[7].Value = "01:18:36";
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "轴承工班";
            this.dataGridView1.Rows[index3].Cells[1].Value = ps.Count();
            this.dataGridView1.Rows[index3].Cells[2].Value = "17";
            this.dataGridView1.Rows[index3].Cells[3].Value = "1";//ps
            this.dataGridView1.Rows[index3].Cells[4].Value = "0";
            this.dataGridView1.Rows[index3].Cells[5].Value = "0";
            this.dataGridView1.Rows[index3].Cells[6].Value = "0";
            this.dataGridView1.Rows[index3].Cells[7].Value = "01:08:10";
            int index4 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index4].Cells[0].Value = "组装工班";//ps2
            this.dataGridView1.Rows[index4].Cells[1].Value = ps2.Count();
            this.dataGridView1.Rows[index4].Cells[2].Value = "8";
            this.dataGridView1.Rows[index4].Cells[3].Value = "2";
            this.dataGridView1.Rows[index4].Cells[4].Value = "0";
            this.dataGridView1.Rows[index4].Cells[5].Value = "0";
            this.dataGridView1.Rows[index4].Cells[6].Value = "0";
            this.dataGridView1.Rows[index4].Cells[7].Value = "00:28:36";
            dataGridView1.Rows[0].Selected = false;

            //2表
            //列标题居中
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
            dataGridView2.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index5 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index5].Cells[0].Value = "轮轴";
            this.dataGridView2.Rows[index5].Cells[1].Value = "24";
            this.dataGridView2.Rows[index5].Cells[2].Value = "16";
            this.dataGridView2.Rows[index5].Cells[3].Value = "8";
            int index6 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index6].Cells[0].Value = "轮对";
            this.dataGridView2.Rows[index6].Cells[1].Value = "28";
            this.dataGridView2.Rows[index6].Cells[2].Value = "13";
            this.dataGridView2.Rows[index6].Cells[3].Value = "25";
            int index7 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index7].Cells[0].Value = "轴承";
            this.dataGridView2.Rows[index7].Cells[1].Value = "96";
            this.dataGridView2.Rows[index7].Cells[2].Value = "36";
            this.dataGridView2.Rows[index7].Cells[3].Value = "60";
            int index8 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index8].Cells[0].Value = "组装";
            this.dataGridView2.Rows[index8].Cells[1].Value = "24";
            this.dataGridView2.Rows[index8].Cells[2].Value = "8";
            this.dataGridView2.Rows[index8].Cells[3].Value = "14";

            dataGridView2.Rows[0].Selected = false;

        }
        string jsonStr2 = "";

        public void SetTable()
        {
            try
            {
                //整体检修进度表
                //JObject jsonobj2 = null;
                jsonStr2 = ztjk.GetZtjkInfoByProcedureNameToJson("ALL", "ALL");//获取所以信息
                JObject o2 = JObject.Parse(jsonStr2);
                JArray json2 = (JArray)o2["data"];
                //ds = JsonToDataSet("date:{"+ json2 + "}");
                //dynamic model = JsonConvert.DeserializeObject(jsonStr2);
                //this.dataGridView1.DataSource = model.data;
                DataTable dt = Json.ToTable(json2.ToString());
                //轮轴拆
                this.dataGridView2.Rows[0].Cells[1].Value = dt.Rows[0]["TaskPlans"].ToString();
                this.dataGridView2.Rows[0].Cells[2].Value = dt.Rows[0]["OverhaulQuantity"].ToString();
                this.dataGridView2.Rows[0].Cells[3].Value = Convert.ToInt32(dt.Rows[0]["QualifiedQuantity"].ToString()) + Convert.ToInt32(dt.Rows[0]["UnqualifiedQuantity"].ToString());
                //轴承
                this.dataGridView2.Rows[1].Cells[1].Value = dt.Rows[1]["TaskPlans"].ToString();
                this.dataGridView2.Rows[1].Cells[2].Value = dt.Rows[1]["OverhaulQuantity"].ToString();
                this.dataGridView2.Rows[1].Cells[3].Value = Convert.ToInt32(dt.Rows[1]["QualifiedQuantity"].ToString()) + Convert.ToInt32(dt.Rows[1]["UnqualifiedQuantity"].ToString());
                //轮对
                this.dataGridView2.Rows[2].Cells[1].Value = dt.Rows[2]["TaskPlans"].ToString();
                this.dataGridView2.Rows[2].Cells[2].Value = dt.Rows[2]["OverhaulQuantity"].ToString();
                this.dataGridView2.Rows[2].Cells[3].Value = Convert.ToInt32(dt.Rows[2]["QualifiedQuantity"].ToString())+ Convert.ToInt32(dt.Rows[2]["UnqualifiedQuantity"].ToString());
                //组装
                this.dataGridView2.Rows[3].Cells[1].Value = dt.Rows[3]["TaskPlans"].ToString();
                this.dataGridView2.Rows[3].Cells[2].Value = dt.Rows[3]["OverhaulQuantity"].ToString();
                this.dataGridView2.Rows[3].Cells[3].Value = Convert.ToInt32(dt.Rows[3]["QualifiedQuantity"].ToString()) + Convert.ToInt32(dt.Rows[3]["UnqualifiedQuantity"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                timer1.Enabled = false;
                //throw;
            }

        }
        private void UserMain_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
            InitDataTable();

            Task.Factory.StartNew(() =>
            {
                while (!cancelltokenSource.IsCancellationRequested)
                {

                    Task.Delay(3000).Wait();
                    RefreshState();
                    Refresh();
                    SetTable();
                }
            }, cancelltokenSource.Token);
        }

        private void UserMain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        //声明为全局变量
        List<MyCircle> MyCircles = new List<MyCircle>();
        List<CMES.Controls.MyCircle> MyCircles2 = new List<CMES.Controls.MyCircle>();
        //递归查找
        void FindChks(Control c)
        {
            if (c.HasChildren)
                foreach (Control cc in c.Controls)
                    FindChks(cc);
            else if (c is CMES.Controls.MyCircle)
                MyCircles2.Add(c as CMES.Controls.MyCircle);
        }
        void FindChks(Control c, Panel[] panels)
        {
            if (c.HasChildren)
                foreach (Control cc in (panels))
                    FindChks(cc, panels);
            else if (c is CMES.Controls.MyCircle)
                MyCircles2.Add(c as CMES.Controls.MyCircle);
        }
        private void myCircle1_Click(object sender, EventArgs e)
        {
            //if (myCircle1.BorderColor == Color.YellowGreen)
            //{
            //    myCircle1.BorderColor = Color.Red;
            //    myCircle1.ButtonCenterColorStart = Color.Red;
            //    myCircle1.ButtonCenterColorEnd = Color.Red;
            //    myCircle1.FocusBorderColor = Color.Red;
            //}
            //else
            //{
            //    myCircle1.BorderColor = Color.YellowGreen;
            //    myCircle1.ButtonCenterColorStart = Color.YellowGreen;
            //    myCircle1.ButtonCenterColorEnd = Color.YellowGreen;
            //    myCircle1.FocusBorderColor = Color.YellowGreen;
            //}

            //调用示例
            //FindChks(this);
            //foreach (MyCircle myCircle in MyCircles)
            //{
            //    if (myCircle.BorderColor == Color.YellowGreen)
            //    {
            //        myCircle.BorderColor = Color.Red;
            //        myCircle.ButtonCenterColorStart = Color.Red;
            //        myCircle.ButtonCenterColorEnd = Color.Red;
            //        myCircle.FocusBorderColor = Color.Red;
            //    }
            //    else
            //    {
            //        myCircle.BorderColor = Color.YellowGreen;
            //        myCircle.ButtonCenterColorStart = Color.YellowGreen;
            //        myCircle.ButtonCenterColorEnd = Color.YellowGreen;
            //        myCircle.FocusBorderColor = Color.YellowGreen;
            //    }
            //}

        }

        private void myCircle1_Load(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label51_DoubleClick(object sender, EventArgs e)
        {
            //调用示例
            //FindChks(this);
            //foreach (MyCircle myCircle in MyCircles)
            //{
            //    myCircle.BorderColor = Color.YellowGreen;
            //    myCircle.ButtonCenterColorStart = Color.YellowGreen;
            //    myCircle.ButtonCenterColorEnd = Color.YellowGreen;
            //    myCircle.FocusBorderColor = Color.YellowGreen;

            //}
            Opc = Color.YellowGreen;
        }

        private void label56_DoubleClick(object sender, EventArgs e)
        {

            Opc = Color.Red;
        }

        private void label50_DoubleClick(object sender, EventArgs e)
        {

            Opc = Color.Gray;
        }
        public void setLight(CMES.Controls.MyCircle myCircle, int Colo)
        {

            //myCircle.BorderColor = Color;
            //myCircle.ButtonCenterColorStart = Color;
            //myCircle.ButtonCenterColorEnd = Color;
            //myCircle.FocusBorderColor = Color;
            switch (Colo)
            {
                case 1:
                    myCircle.BorderColor = Color.Gray;
                    myCircle.ButtonCenterColorStart = Color.Gray;
                    myCircle.ButtonCenterColorEnd = Color.Gray;
                    myCircle.FocusBorderColor = Color.Gray;
                    break;
                case 2:
                    myCircle.BorderColor = Color.Lime;
                    myCircle.ButtonCenterColorStart = Color.Lime;
                    myCircle.ButtonCenterColorEnd = Color.Lime;
                    myCircle.FocusBorderColor = Color.Lime;
                    break;
                case 3:
                    myCircle.BorderColor = Color.RoyalBlue;
                    myCircle.ButtonCenterColorStart = Color.RoyalBlue;
                    myCircle.ButtonCenterColorEnd = Color.RoyalBlue;
                    myCircle.FocusBorderColor = Color.RoyalBlue;
                    break;
                case 4:
                    myCircle.BorderColor = Color.LightGray;
                    myCircle.ButtonCenterColorStart = Color.LightGray;
                    myCircle.ButtonCenterColorEnd = Color.LightGray;
                    myCircle.FocusBorderColor = Color.LightGray;
                    break;
                case 5:
                    myCircle.BorderColor = Color.Yellow;
                    myCircle.ButtonCenterColorStart = Color.Yellow;
                    myCircle.ButtonCenterColorEnd = Color.Yellow;
                    myCircle.FocusBorderColor = Color.Yellow;
                    break;
                case 6:
                    myCircle.BorderColor = Color.Aqua;
                    myCircle.ButtonCenterColorStart = Color.Aqua;
                    myCircle.ButtonCenterColorEnd = Color.Aqua;
                    myCircle.FocusBorderColor = Color.Aqua;
                    break;
                case 7:
                    myCircle.BorderColor = Color.Red;
                    myCircle.ButtonCenterColorStart = Color.Red;
                    myCircle.ButtonCenterColorEnd = Color.Red;
                    myCircle.FocusBorderColor = Color.Red;
                    break;
                case 8:
                    myCircle.BorderColor = Color.Turquoise;
                    myCircle.ButtonCenterColorStart = Color.Turquoise;
                    myCircle.ButtonCenterColorEnd = Color.Turquoise;
                    myCircle.FocusBorderColor = Color.Turquoise;
                    break;
                default:
                    myCircle.BorderColor = Color.Gray;
                    myCircle.ButtonCenterColorStart = Color.Gray;
                    myCircle.ButtonCenterColorEnd = Color.Gray;
                    myCircle.FocusBorderColor = Color.Gray;
                    break;
            }
            myCircle.Refresh();
        }
        CancellationTokenSource cancelltokenSource = new CancellationTokenSource();

        private void myCircle46_Load(object sender, EventArgs e)
        {
            //FindChks(this);
            //foreach (CMES.Controls.MyCircle myCircle in MyCircles2)
            //{
            //    myCircle.BorderColor = Color.Gray;
            //    myCircle.ButtonCenterColorStart = Color.Gray;
            //    myCircle.ButtonCenterColorEnd = Color.Gray;
            //    myCircle.FocusBorderColor = Color.Gray;
            //}
        }
        //private int m_iSt = 1;
        //private int m_iSt2 = 1;
        //private int m_iSt3 = 1;
        //private int m_iSt4 = 1;
        //private int m_iSt5 = 1;
        //private int m_iSt6 = 1;
        //private int m_iSt7 = 1;
        //private int m_iSt8 = 1;
        //private int m_iSt9 = 1;

        public int Re(string myCircle, int iSt)//Re(CMES.Controls.MyCircle myCircle, int iSt)
        {
            //int iRet = 1;
            switch (myCircle)
            {
                case "myCircle46":
                    setLight(myCircle46, iSt);
                    //iRet = 2;
                    break;
                case "myCircle47":
                    setLight(myCircle47, iSt);
                    //iRet = 3;
                    break;
                case "myCircle48":
                    setLight(myCircle48, iSt);
                    //iRet = 1;
                    break;
                case "myCircle49":
                    setLight(myCircle49, iSt);
                    //iRet = 1;
                    break;
                case "myCircle50":
                    setLight(myCircle50, iSt);
                    //iRet = 1;
                    break;
                case "myCircle51":
                    setLight(myCircle51, iSt);
                    break;
                case "myCircle52":
                    setLight(myCircle52, iSt);
                    break;
                case "myCircle53":
                    setLight(myCircle53, iSt);
                    break;
                case "myCircle54":
                    setLight(myCircle54, iSt);
                    break;
                case "myCircle55":
                    setLight(myCircle55, iSt);
                    break;
                case "myCircle56":
                    setLight(myCircle56, iSt);
                    break;
                case "myCircle57":
                    setLight(myCircle57, iSt);
                    break;
                case "myCircle58":
                    setLight(myCircle58, iSt);
                    break;
                case "myCircle59":
                    setLight(myCircle59, iSt);
                    break;
                case "myCircle60":
                    setLight(myCircle60, iSt);
                    break;
                case "myCircle61":
                    setLight(myCircle61, iSt);
                    break;
                case "myCircle62":
                    setLight(myCircle62, iSt);
                    break;
                case "myCircle63":
                    setLight(myCircle10, iSt);
                    break;
                case "myCircle26":
                    setLight(myCircle26, iSt);
                    break;
                case "myCircle27":
                    setLight(myCircle27, iSt);
                    break;
                case "myCircle28":
                    setLight(myCircle28, iSt);
                    break;
                case "myCircle29":
                    setLight(myCircle29, iSt);
                    break;
                case "myCircle30":
                    setLight(myCircle30, iSt);
                    break;
                case "myCircle31":
                    setLight(myCircle31, iSt);
                    break;
                case "myCircle32":
                    setLight(myCircle32, iSt);
                    break;
                case "myCircle33":
                    setLight(myCircle33, iSt);
                    break;
                case "myCircle34":
                    setLight(myCircle34, iSt);
                    break;
                case "myCircle35":
                    setLight(myCircle35, iSt);
                    break;
                case "myCircle36":
                    setLight(myCircle36, iSt);
                    break;
                case "myCircle37":
                    setLight(myCircle37, iSt);
                    break;
                case "myCircle38":
                    setLight(myCircle38, iSt);
                    break;
                case "myCircle39":
                    setLight(myCircle39, iSt);
                    break;
                case "myCircle40":
                    setLight(myCircle40, iSt);
                    break;
                case "myCircle41":
                    setLight(myCircle41, iSt);
                    break;
                case "myCircle42":
                    setLight(myCircle42, iSt);
                    break;
                case "myCircle43":
                    setLight(myCircle43, iSt);
                    break;
                case "myCircle44":
                    setLight(myCircle44, iSt);
                    break;
                case "myCircle45":
                    setLight(myCircle45, iSt);
                    break;
                case "myCircle25":
                    setLight(myCircle25, iSt);
                    break;
                case "myCircle24":
                    setLight(myCircle24, iSt);
                    break;
                case "myCircle23":
                    setLight(myCircle23, iSt);
                    break;
                case "myCircle22":
                    setLight(myCircle22, iSt);
                    break;
                case "myCircle21":
                    setLight(myCircle21, iSt);
                    break;
                case "myCircle20":
                    setLight(myCircle20, iSt);
                    break;
                case "myCircle19":
                    setLight(myCircle19, iSt);
                    break;
                case "myCircle18":
                    setLight(myCircle18, iSt);
                    break;
                case "myCircle17":
                    setLight(myCircle17, iSt);
                    break;
                case "myCircle16":
                    setLight(myCircle16, iSt);
                    break;
                case "myCircle15":
                    setLight(myCircle15, iSt);
                    break;
                case "myCircle14":
                    setLight(myCircle14, iSt);
                    break;
                case "myCircle13":
                    setLight(myCircle13, iSt);
                    break;
                case "myCircle12":
                    setLight(myCircle12, iSt);
                    break;
                case "myCircle11":
                    setLight(myCircle11, iSt);
                    break;
                case "myCircle10":
                    setLight(myCircle10, iSt);
                    break;
                case "myCircle9":
                    setLight(myCircle9, iSt);
                    break;
                case "myCircle8":
                    setLight(myCircle8, iSt);
                    break;
                case "myCircle7":
                    setLight(myCircle7, iSt);
                    break;
                case "myCircle6":
                    setLight(myCircle6, iSt);
                    break;
                case "myCircle5":
                    setLight(myCircle5, iSt);
                    break;
                case "myCircle4":
                    setLight(myCircle4, iSt);
                    break;
                case "myCircle3":
                    setLight(myCircle3, iSt);
                    break;
                case "myCircle2":
                    setLight(myCircle2, iSt);
                    break;
                case "myCircle1":
                    setLight(myCircle1, iSt);
                    break;
                default:
                    setLight(myCircle1, iSt);
                    break;
            }

            return 0;
        }
        DeviceController device = new DeviceController();

        private void myCircle46_Paint(object sender, PaintEventArgs e)
        {

        }
        public void RefreshState()
        {
            //m_iSt = Re(myCircle46, m_iSt);
            //m_iSt2 = Re(myCircle48, m_iSt2);
            //m_iSt3 = Re(myCircle38, m_iSt3);
            //m_iSt4 = Re(myCircle57, m_iSt4);
            //m_iSt5 = Re(myCircle52, m_iSt5);
            //m_iSt6 = Re(myCircle39, m_iSt6);
            //m_iSt7 = Re(myCircle32, m_iSt7);
            //m_iSt8 = Re(myCircle34, m_iSt8);
            //m_iSt9 = Re(myCircle28, m_iSt9);
        }
        List<shebeiguanlijichuxinxi_TableEntity> personList = new List<shebeiguanlijichuxinxi_TableEntity>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshState();
            //if (m_iSt == 0)
            //{ m_iSt = 1; }
            JObject jsonobj2 = null;

            string jsonStr22 = device.GetDeviceInfoToJson("DeviceName", "DeviceNumber");
            JObject o2 = JObject.Parse(jsonStr22);

            JArray json2 = (JArray)o2["data"];
            //var belongAct = json2["data"]
            //    .Where(a => (a["DeviceStatus"].Select(c => c["DeviceStatus"].ToString().Contains("1")).First()))
            //    .FirstOrDefault();

            for (int j = 0; j < json2.Count; j++)
            {
                jsonobj2 = (JObject)json2[j];
                //MessageBox.Show(jsonobj2["MyCircle"].ToString() + "|" + jsonobj2["DeviceState"].ToString(), json2.Count + "共");
                Re(jsonobj2["MyCircle"].ToString(), Convert.ToInt32(jsonobj2["DeviceStatus"]));
            }
            var groupList = personList.GroupBy(m => new { m.DeviceStatus, m.DeviceNumber }).
                      Select(a => new
                      {
                          DeviceStatus = a.Key.DeviceStatus,
                          Salary = a.Sum(c => c.id)
                      }).ToList();
            foreach (var item in groupList)
            {
                Console.WriteLine("Name:{0}--Salary:{1}", item.DeviceStatus, item.Salary);
            }
            CountMyCircle(ps, 2);
            CountMyCircle(ps2, 3);
            CountMyCircle(ps3, 1);
        }
    }
}
