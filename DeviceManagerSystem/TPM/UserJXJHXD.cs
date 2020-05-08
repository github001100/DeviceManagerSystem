using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace DeviceManagerSystem.TPM
{
    public partial class UserJXJHXD : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        /// <summary>
        /// 轮轴车间检修作业计划修订
        /// </summary>
        public UserJXJHXD()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }
        private static UserJXJHXD frm = null;

        public static UserJXJHXD CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new UserJXJHXD();
            }
            return frm;
        }
        public int Press { get; set; }

        //进度条图片属性
        public Image PressImg
        {
            get
            {
                Bitmap bmp = new Bitmap(104, 30); //这里给104是为了左边和右边空出2个像素，剩余的100就是百分比的值
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.Blue); //背景填白色
                //g.FillRectangle(Brushes.Red, 2, 2, this.Press, 26);  //普通效果
                //填充渐变效果
                g.FillRectangle(new LinearGradientBrush(new Point(30, 2), new Point(30, 30), Color.Black, Color.Gray), 2, 2, this.Press, 26);
                return bmp;
            }
        }
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        public void InitDataTable()
        {
            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "1";
            this.dataGridView1.Rows[index].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index].Cells[2].Value = "YZ25T35226";
            this.dataGridView1.Rows[index].Cells[3].Value = "西辆(573)";
            this.dataGridView1.Rows[index].Cells[4].Value = "A2";
            this.dataGridView1.Rows[index].Cells[5].Value = "待检...";
            this.dataGridView1.Rows[index].Cells[6].Value = PressImg;
            this.dataGridView1.Rows[index].Cells[7].Value = 33;//PressImg

            int index1 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index1].Cells[0].Value = "2";
            this.dataGridView1.Rows[index1].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index1].Cells[2].Value = "YW25G30561";
            this.dataGridView1.Rows[index1].Cells[3].Value = "西辆(573)";
            this.dataGridView1.Rows[index1].Cells[4].Value = "解体车";
            this.dataGridView1.Rows[index1].Cells[5].Value = "待检...";
            this.dataGridView1.Rows[index1].Cells[6].Value = PressImg;
            this.dataGridView1.Rows[index1].Cells[7].Value = 58;

            dataGridView1.Rows[0].Selected = false;
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LawnGreen;

            //列标题居中
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            foreach (DataGridViewColumn item in this.dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index2 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index2].Cells[0].Value = "1";
            this.dataGridView2.Rows[index2].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index2].Cells[2].Value = "YZ25T35226";
            this.dataGridView2.Rows[index2].Cells[3].Value = "西辆(573)";
            this.dataGridView2.Rows[index2].Cells[4].Value = "A2";
            this.dataGridView2.Rows[index2].Cells[5].Value = "组装中...";
            this.dataGridView2.Rows[index2].Cells[6].Value = 8;

            int index3 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index3].Cells[0].Value = "2";
            this.dataGridView2.Rows[index3].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index3].Cells[2].Value = "YW25G30561";
            this.dataGridView2.Rows[index3].Cells[3].Value = "西辆(573)";
            this.dataGridView2.Rows[index3].Cells[4].Value = "A3";
            this.dataGridView2.Rows[index3].Cells[5].Value = "组装中...";
            this.dataGridView2.Rows[index3].Cells[6].Value = 58;
            int index4 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index4].Cells[0].Value = "3";
            this.dataGridView2.Rows[index4].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index4].Cells[2].Value = "RW25K23118";
            this.dataGridView2.Rows[index4].Cells[3].Value = "西辆(573)";
            this.dataGridView2.Rows[index4].Cells[4].Value = "A3";
            this.dataGridView2.Rows[index4].Cells[5].Value = "组装中...";
            this.dataGridView2.Rows[index4].Cells[6].Value = 38;
            int index5 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index5].Cells[0].Value = "4";
            this.dataGridView2.Rows[index5].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index5].Cells[2].Value = "YZ25B22656";
            this.dataGridView2.Rows[index5].Cells[3].Value = "西辆(573)";
            this.dataGridView2.Rows[index5].Cells[4].Value = "A3";
            this.dataGridView2.Rows[index5].Cells[5].Value = "组装中...";
            this.dataGridView2.Rows[index5].Cells[6].Value = 48;
            int index6 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index6].Cells[0].Value = "5";
            this.dataGridView2.Rows[index6].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index6].Cells[2].Value = "CA25K21078";
            this.dataGridView2.Rows[index6].Cells[3].Value = "西辆(573)";
            this.dataGridView2.Rows[index6].Cells[4].Value = "A3";
            this.dataGridView2.Rows[index6].Cells[5].Value = "组装中...";
            this.dataGridView2.Rows[index6].Cells[6].Value = 58;

            dataGridView2.Rows[0].Selected = false;
            dataGridView2.Rows[index3].DefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
        }
        private void UserJXJHXD_Load(object sender, EventArgs e)
        {
            this.Font = new Font("微软雅黑", 10);

            InitDataTable();
            Thread thread = new Thread(new ThreadStart(new Action(delegate
            {
                while (true)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(1000);
                        //1
                        if ((int)dataGridView1.Rows[0].Cells[7].Value > 100)
                            this.dataGridView1.Rows[0].Cells[7].Value = 38;
                        else
                            this.dataGridView1.Rows[0].Cells[7].Value = i + 1;

                        if ((int)dataGridView1.Rows[1].Cells[7].Value > 100)
                            this.dataGridView1.Rows[1].Cells[7].Value = 58;
                        else
                            this.dataGridView1.Rows[1].Cells[7].Value = i + 1;
                        //2
                        if ((int)dataGridView2.Rows[0].Cells[6].Value > 100)
                            this.dataGridView2.Rows[0].Cells[6].Value = 38;
                        else
                            this.dataGridView2.Rows[0].Cells[6].Value = i + 1;

                        if ((int)dataGridView2.Rows[1].Cells[6].Value > 100)
                            this.dataGridView2.Rows[1].Cells[6].Value = 58;
                        else
                            this.dataGridView2.Rows[1].Cells[6].Value = i + 1;
                    }
                }

            })));
            thread.IsBackground = true;
            //thread.Start();
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                foreach (Control var in base.Controls)
                {
                    SetControlFont(var, value);
                }

                base.Font = value;
            }
        }
        private void SetControlFont(Control c, Font f)
        {
            c.Font = f;
            if (c.Controls.Count > 0)
            {
                foreach (Control var in c.Controls)
                {
                    SetControlFont(var, f);

                }
            }
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) return;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (dataGridView2.Rows[e.RowIndex].IsNewRow) return;

        }

        private void UserJXJHXD_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);

        }
    }
}
