using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (frm == null||frm.IsDisposed)
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
        public void InitDataTable()
        {
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
            this.dataGridView1.Rows[index].Cells[1].Value = "62";
            this.dataGridView1.Rows[index].Cells[2].Value = "58";
            this.dataGridView1.Rows[index].Cells[3].Value = "4";
            this.dataGridView1.Rows[index].Cells[4].Value = "0";
            this.dataGridView1.Rows[index].Cells[5].Value = "0";
            this.dataGridView1.Rows[index].Cells[6].Value = "0";
            this.dataGridView1.Rows[index].Cells[7].Value = "01:33:29";
            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "轮对工班";
            this.dataGridView1.Rows[index2].Cells[1].Value = "33";
            this.dataGridView1.Rows[index2].Cells[2].Value = "4";
            this.dataGridView1.Rows[index2].Cells[3].Value = "29";
            this.dataGridView1.Rows[index2].Cells[4].Value = "0";
            this.dataGridView1.Rows[index2].Cells[5].Value = "0";
            this.dataGridView1.Rows[index2].Cells[6].Value = "0";
            this.dataGridView1.Rows[index2].Cells[7].Value = "01:18:36";
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "轴承工班";
            this.dataGridView1.Rows[index3].Cells[1].Value = "19";
            this.dataGridView1.Rows[index3].Cells[2].Value = "17";
            this.dataGridView1.Rows[index3].Cells[3].Value = "2";
            this.dataGridView1.Rows[index3].Cells[4].Value = "0";
            this.dataGridView1.Rows[index3].Cells[5].Value = "0";
            this.dataGridView1.Rows[index3].Cells[6].Value = "0";
            this.dataGridView1.Rows[index3].Cells[7].Value = "01:08:10";
            int index4 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index4].Cells[0].Value = "组装工班";
            this.dataGridView1.Rows[index4].Cells[1].Value = "10";
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
        private void UserMain_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);

            InitDataTable();
            Panel[] ps = { panel31,panel34, panel26, panel29 , panel32 , panel35,panel38,panel60,panel45,
                panel41, panel44, panel47, panel39, panel42,panel50, panel53,panel50,panel51,panel52,panel49 };
            Panel[] ps2 = { panel23,panel24,panel36, panel48 , panel59 , panel54,
                panel55, panel56,panel21,panel22 };
            Panel[] ps3 = { panel11,panel2, panel3, panel4 , panel5 , panel6,
                panel7, panel8, panel9, panel10, panel13,panel14, panel16,panel20,panel15,panel18,panel30 ,
                panel57, panel58, panel33,panel46,panel43, panel61, panel62, panel63,panel12,panel17,panel27,panel19,panel40,
                panel37, panel25, panel28,panel64 };

            foreach (var item in (ps))
            {
                if (item is Panel)
                {
                    (item as Panel).BackColor = Color.Aqua;

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
            //foreach (var item in (this.panel11.Controls))
            //{
            //    if (item is MyCircle)
            //    {
            //        (item as MyCircle).ButtonCenterColorStart = Color.Red;
            //        (item as MyCircle).ButtonCenterColorEnd = Color.Red;

            //    }
            //}

            Task.Factory.StartNew(() =>
            {
                while (!cancelltokenSource.IsCancellationRequested)
                {

                    Task.Delay(1000).Wait();
                    RefreshState();
                    Refresh();

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
        public void setLight(CMES.Controls.MyCircle myCircle, Color Color)
        {

            myCircle.BorderColor = Color;
            myCircle.ButtonCenterColorStart = Color;
            myCircle.ButtonCenterColorEnd = Color;
            myCircle.FocusBorderColor = Color;
            myCircle.Refresh();
        }
        CancellationTokenSource cancelltokenSource = new CancellationTokenSource();

        private void myCircle46_Load(object sender, EventArgs e)
        {
            FindChks(this);
            foreach (CMES.Controls.MyCircle myCircle in MyCircles2)
            {
                myCircle.BorderColor = Color.Gray;
                myCircle.ButtonCenterColorStart = Color.Gray;
                myCircle.ButtonCenterColorEnd = Color.Gray;
                myCircle.FocusBorderColor = Color.Gray;
            }
        }
        private int m_iSt = 1;
        private int m_iSt2 = 3;
        private int m_iSt3 = 1;
        private int m_iSt4 = 3;
        private int m_iSt5 = 1;
        private int m_iSt6 = 3;
        private int m_iSt7 = 1;
        private int m_iSt8 = 3;
        private int m_iSt9 = 1;

        public int Re(CMES.Controls.MyCircle myCircle, int iSt = 0)
        {
            int iRet = 1;
            switch (iSt)
            {
                case 1:
                    setLight(myCircle, Color.Red);
                    iRet = 2;
                    break;
                case 2:
                    setLight(myCircle, Color.Yellow);
                    iRet = 3;
                    break;
                case 3:
                    setLight(myCircle, Color.YellowGreen);
                    iRet = 1;
                    break;
                default:
                    setLight(myCircle, Color.Blue);
                    break;
            }

            return iRet;
        }

        private void myCircle46_Paint(object sender, PaintEventArgs e)
        {

        }
        public void RefreshState()
        {
            m_iSt = Re(myCircle46, m_iSt);
            m_iSt2 = Re(myCircle48, m_iSt2);
            m_iSt3 = Re(myCircle38, m_iSt3);
            m_iSt4 = Re(myCircle57, m_iSt4);
            m_iSt5 = Re(myCircle52, m_iSt5);
            m_iSt6 = Re(myCircle39, m_iSt6);
            m_iSt7 = Re(myCircle32, m_iSt7);
            m_iSt8 = Re(myCircle34, m_iSt8);
            m_iSt9 = Re(myCircle28, m_iSt9);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshState();
            //if (m_iSt == 0)
            //{ m_iSt = 1; }
        }
    }
}
