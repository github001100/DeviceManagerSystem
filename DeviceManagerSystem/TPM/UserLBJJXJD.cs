using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace DeviceManagerSystem.TPM
{
    /// <summary>
    /// 轮轴车间轮轴零部件检修进度监控
    /// </summary>
    public partial class UserLBJJXJD : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private DataTable dt = new DataTable();

        BindingSource bs = new BindingSource();
        public UserLBJJXJD()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        public void InitDataTable()
        {

            //不允许自动生成，若改为允许，界面会自动增加DataTable列，那么界面上既会包含DataGridView中定义的列，也会包含DataTable定义的列
            //this.dataGridView1.AutoGenerateColumns = false;

            //DataColumn col = new DataColumn("No", typeof(int));
            //dt.Columns.Add(col);
            //dt.Columns.Add(new DataColumn("Addr", typeof(string)));
            //dt.Columns.Add(new DataColumn("FuntionType", typeof(string)));
            //dt.Columns.Add(new DataColumn("Result", typeof(string)));

            //bs.DataSource = dt;
            //this.dataGridView1.DataSource = bs;

            ////将DataGridView中的列与DataTable中的列进行数据绑定，this.cloNum为列名

            //this.外观检查.DataPropertyName = "No";
            //this.外观检查.DataPropertyName = "Addr";
            //this.外观检查.DataPropertyName = "FuntionType";
            //this.外观检查.DataPropertyName = "Result";

            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "轴箱";
            this.dataGridView1.Rows[index].Cells[1].Value = "48";
            this.dataGridView1.Rows[index].Cells[2].Value = "40";
            this.dataGridView1.Rows[index].Cells[3].Value = "18";
            this.dataGridView1.Rows[index].Cells[4].Value = "2";
            this.dataGridView1.Rows[index].Cells[5].Value = "90.0%"; 
            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "防尘挡圈";//56,35,20,1,95.2%
            this.dataGridView1.Rows[index2].Cells[1].Value = "56";
            this.dataGridView1.Rows[index2].Cells[2].Value = "35";
            this.dataGridView1.Rows[index2].Cells[3].Value = "20";
            this.dataGridView1.Rows[index2].Cells[4].Value = "2";
            this.dataGridView1.Rows[index2].Cells[5].Value = "95.0%"; 
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "端盖";//52,28,24,0,100.0%
            this.dataGridView1.Rows[index3].Cells[1].Value = "52";
            this.dataGridView1.Rows[index3].Cells[2].Value = "28";
            this.dataGridView1.Rows[index3].Cells[3].Value = "24";
            this.dataGridView1.Rows[index3].Cells[4].Value = "0";
            this.dataGridView1.Rows[index3].Cells[5].Value = "100.0%";
            dataGridView1.Rows[0].Selected = false; 

            //2
            //列标题居中
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index4 = this.dataGridView2.Rows.Add();

            this.dataGridView2.Rows[index4].Cells[0].Value = "轴箱";
            this.dataGridView2.Rows[index4].Cells[1].Value = "48";
            this.dataGridView2.Rows[index4].Cells[2].Value = "40";
            this.dataGridView2.Rows[index4].Cells[3].Value = "18";
            this.dataGridView2.Rows[index4].Cells[4].Value = "2";
            this.dataGridView2.Rows[index4].Cells[5].Value = "90.0%";
            int index5 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index5].Cells[0].Value = "防尘挡圈";
            this.dataGridView2.Rows[index5].Cells[1].Value = "56";
            this.dataGridView2.Rows[index5].Cells[2].Value = "35";
            this.dataGridView2.Rows[index5].Cells[3].Value = "20";
            this.dataGridView2.Rows[index5].Cells[4].Value = "2";
            this.dataGridView2.Rows[index5].Cells[5].Value = "95.0%";
            int index6 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index6].Cells[0].Value = "端盖";
            this.dataGridView2.Rows[index6].Cells[1].Value = "52";
            this.dataGridView2.Rows[index6].Cells[2].Value = "28";
            this.dataGridView2.Rows[index6].Cells[3].Value = "24";
            this.dataGridView2.Rows[index6].Cells[4].Value = "0";
            this.dataGridView2.Rows[index6].Cells[5].Value = "100.0%";

            dataGridView2.Rows[0].Selected = false;
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
            dataGridView1.Rows[index3].DefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
            dataGridView2.Rows[index4].DefaultCellStyle.BackColor = Color.LawnGreen;
            dataGridView2.Rows[index6].DefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE); 

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
        private void UserLBJJXJD_Load(object sender, EventArgs e)
        {
            this.Font = new Font("微软雅黑", 16);

            InitDataTable();
            //添加的两组Test数据
            List<String> txData2 = new List<String>() { "除锈清洗", "二维码喷码", "外观检查", "尺寸测量", "管理入库" };
            List<int> tyData2 = new List<int>() { 87, 96, 87, 84, 95 };
            List<int> tyData3 = new List<int>() { 5, 7, 9, 3, 8 };

            chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false; //X轴上网格
            chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = false; //y轴上网格
            chart1.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart1.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].Axes[0].MajorTickMark.Enabled = false; // x轴上突出的小点
            chart1.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false; //
            chart1.ChartAreas[0].Axes[1].InterlacedColor = Color.LightGray; //显示交错带颜色

            chart1.ChartAreas[0].Axes[0].LabelStyle.Format = "# (套)"; //设置X轴显示样式
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Blue;
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 3;
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent; //设置区域内背景透明
            chart1.Series[0].Points.DataBindXY(txData2, tyData2); //添加数据
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 14);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 14);
            chart1.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            chart1.Series[0].Label = "#VAL"; //设置显示X Y的值
            chart1.Series[0].ToolTip = "#VALX(套)\r#VAL"; //鼠标移动到对应点显示数值
            //柱状图其他设置
            //chart1.Series[0]["DrawingStyle"] = "Emboss";   //设置柱状平面形状
            chart1.Series[0]["PointWidth"] = "1.0"; //设置柱状大小

            //chart1.Series.Add(new Series()); //添加一个图表序列
            chart1.Series[1].Points.DataBindXY(txData2, tyData3); //添加数据
            chart1.Series[1]["PointWidth"] = "1.0"; //设置柱状大小

            Thread thread = new Thread(new ThreadStart(new Action(delegate
            {
                while (true)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(1000);
                        circleProgramBar.Progress = i + 1;
                    }
                }
              
            })));
            thread.IsBackground = true;
            thread.Start();
        }

        private void UserLBJJXJD_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);

        }
    }
}
