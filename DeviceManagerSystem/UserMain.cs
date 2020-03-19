using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
        public static Color Opc ;
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
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
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
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
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
            foreach (var item in (this.groupBox1.Controls))
            {
                if (item is Panel)
                {
                    (item as Panel).BackColor = Color.CornflowerBlue;
                    switch ((item as Panel).Name)
                    {
                        case "panel11":
                            foreach (var item1 in (this.panel11.Controls))
                            {
                                if (item1 is MyCircle)
                                {
                                    (item1 as MyCircle).ButtonCenterColorStart = Color.Red;
                                    (item1 as MyCircle).ButtonCenterColorEnd = Color.Red;
                                    (item1 as MyCircle).BorderColor = Color.Red;

                                }
                            }
                            break;
                        case "panel12":
                            foreach (var item1 in (this.panel12.Controls))
                            {
                                if (item1 is MyCircle)
                                {
                                    (item1 as MyCircle).ButtonCenterColorStart = Color.Red;
                                    (item1 as MyCircle).ButtonCenterColorEnd = Color.Red;
                                    (item1 as MyCircle).BorderColor = Color.Red;

                                }
                            }
                            break;
                        case "panel13":
                            foreach (var item1 in (this.panel13.Controls))
                            {
                                if (item1 is MyCircle)
                                {
                                    (item1 as MyCircle).ButtonCenterColorStart = Color.Red;
                                    (item1 as MyCircle).ButtonCenterColorEnd = Color.Red;
                                    (item1 as MyCircle).BorderColor = Color.Red;

                                }
                            }
                            break;
                        case "panel14":
                            foreach (var item1 in (this.panel14.Controls))
                            {
                                if (item1 is MyCircle)
                                {
                                    (item1 as MyCircle).ButtonCenterColorStart = Color.Red;
                                    (item1 as MyCircle).ButtonCenterColorEnd = Color.Red;
                                    (item1 as MyCircle).BorderColor = Color.Red;

                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            foreach (var item in (this.panel1.Controls))
            {
                if (item is Panel)
                    (item as Panel).BackColor = Color.BlueViolet;
            }

            //foreach (var item in (this.panel11.Controls))
            //{
            //    if (item is MyCircle)
            //    {
            //        (item as MyCircle).ButtonCenterColorStart = Color.Red;
            //        (item as MyCircle).ButtonCenterColorEnd = Color.Red;

            //    }
            //}
            //myCircle26.ButtonCenterColorStart = Color.Red;
            //myCircle26.ButtonCenterColorEnd = Color.Red;

            //myCircle27.ButtonCenterColorStart = Color.Red;
            //myCircle27.ButtonCenterColorEnd = Color.Red;

            //myCircle28.ButtonCenterColorStart = Color.Red;
            //myCircle28.ButtonCenterColorEnd = Color.Red;

            //myCircle29.ButtonCenterColorStart = Color.Red;
            //myCircle29.ButtonCenterColorEnd = Color.Red;
        }

        private void UserMain_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);

        }
        //声明为全局变量
        List<MyCircle> MyCircles = new List<MyCircle>();
        //递归查找
        void FindChks(Control c)
        {
            if (c.HasChildren)
                foreach (Control cc in c.Controls)
                    FindChks(cc);
            else if (c is MyCircle)
                MyCircles.Add(c as MyCircle);
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
            //调用示例
            //FindChks(this);
            //foreach (MyCircle myCircle in MyCircles)
            //{
            //    myCircle.BorderColor = Color.Red;
            //    myCircle.ButtonCenterColorStart = Color.Red;
            //    myCircle.ButtonCenterColorEnd = Color.Red;
            //    myCircle.FocusBorderColor = Color.Red;

            //}
            Opc = Color.Red;

        }

        private void label50_DoubleClick(object sender, EventArgs e)
        {
            //调用示例
            //FindChks(this);
            //foreach (MyCircle myCircle in MyCircles)
            //{

            //    myCircle.BorderColor = Color.Gray;
            //    myCircle.ButtonCenterColorStart = Color.Gray;
            //    myCircle.ButtonCenterColorEnd = Color.Gray;
            //    myCircle.FocusBorderColor = Color.Gray;

            //}
            Opc = Color.Gray;

        }

    }
}
