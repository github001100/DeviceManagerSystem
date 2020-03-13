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

namespace DeviceManagerSystem.TPM
{
    public partial class UserLDJC : UserControl
    {
        public UserLDJC()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        public void InitDataTable()
        {
            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x00, 0xCC, 0x99);            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "1";
            this.dataGridView1.Rows[index].Cells[1].Value = "043-25736";
            this.dataGridView1.Rows[index].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index].Cells[3].Value = "√";
            this.dataGridView1.Rows[index].Cells[4].Value = "√";
            this.dataGridView1.Rows[index].Cells[5].Value = "√";
            this.dataGridView1.Rows[index].Cells[6].Value = "√";
            this.dataGridView1.Rows[index].Cells[7].Value = "√";
            this.dataGridView1.Rows[index].Cells[8].Value = "√";
            this.dataGridView1.Rows[index].Cells[9].Value = "√";
            this.dataGridView1.Rows[index].Cells[10].Value = "√";
            this.dataGridView1.Rows[index].Cells[11].Value = "√";
            this.dataGridView1.Rows[index].Cells[12].Value = "√";
            int index1 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index1].Cells[0].Value = "2";
            this.dataGridView1.Rows[index1].Cells[1].Value = "043-11061";
            this.dataGridView1.Rows[index1].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index1].Cells[3].Value = "√";
            this.dataGridView1.Rows[index1].Cells[4].Value = "√";
            this.dataGridView1.Rows[index1].Cells[5].Value = "√";
            this.dataGridView1.Rows[index1].Cells[6].Value = "√";
            this.dataGridView1.Rows[index1].Cells[7].Value = "√";
            this.dataGridView1.Rows[index1].Cells[8].Value = "√";
            this.dataGridView1.Rows[index1].Cells[9].Value = "√";
            this.dataGridView1.Rows[index1].Cells[10].Value = "√";
            this.dataGridView1.Rows[index1].Cells[11].Value = "√";
            this.dataGridView1.Rows[index1].Cells[12].Value = "√";
            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "3";
            this.dataGridView1.Rows[index2].Cells[1].Value = "114-13020";
            this.dataGridView1.Rows[index2].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index2].Cells[3].Value = "√";
            this.dataGridView1.Rows[index2].Cells[4].Value = "√";
            this.dataGridView1.Rows[index2].Cells[5].Value = "√";
            this.dataGridView1.Rows[index2].Cells[6].Value = "√";
            this.dataGridView1.Rows[index2].Cells[7].Value = "√";
            this.dataGridView1.Rows[index2].Cells[8].Value = "√";
            this.dataGridView1.Rows[index2].Cells[9].Value = "√";
            this.dataGridView1.Rows[index2].Cells[10].Value = "√";
            this.dataGridView1.Rows[index2].Cells[11].Value = "√";
            this.dataGridView1.Rows[index2].Cells[12].Value = "√";
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "4";
            this.dataGridView1.Rows[index3].Cells[1].Value = "105-03150";
            this.dataGridView1.Rows[index3].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index3].Cells[3].Value = "√";
            this.dataGridView1.Rows[index3].Cells[4].Value = "√";
            this.dataGridView1.Rows[index3].Cells[5].Value = "√";
            this.dataGridView1.Rows[index3].Cells[6].Value = "√";
            this.dataGridView1.Rows[index3].Cells[7].Value = "√";
            this.dataGridView1.Rows[index3].Cells[8].Value = "√";
            this.dataGridView1.Rows[index3].Cells[9].Value = "√";
            this.dataGridView1.Rows[index3].Cells[10].Value = "√";
            this.dataGridView1.Rows[index3].Cells[11].Value = "√";
            this.dataGridView1.Rows[index3].Cells[12].Value = "√";
            int index4 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index4].Cells[0].Value = "5";
            this.dataGridView1.Rows[index4].Cells[1].Value = "105-04053";
            this.dataGridView1.Rows[index4].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index4].Cells[3].Value = "√";
            this.dataGridView1.Rows[index4].Cells[4].Value = "√";
            this.dataGridView1.Rows[index4].Cells[5].Value = "√";
            this.dataGridView1.Rows[index4].Cells[6].Value = "√";
            this.dataGridView1.Rows[index4].Cells[7].Value = "√";
            this.dataGridView1.Rows[index4].Cells[8].Value = "√";
            this.dataGridView1.Rows[index4].Cells[9].Value = "√";
            this.dataGridView1.Rows[index4].Cells[10].Value = "√";
            this.dataGridView1.Rows[index4].Cells[11].Value = "√";
            this.dataGridView1.Rows[index4].Cells[12].Value = "√";
            int index5 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index5].Cells[0].Value = "6";
            this.dataGridView1.Rows[index5].Cells[1].Value = "063-15065";
            this.dataGridView1.Rows[index5].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index5].Cells[3].Value = "√";
            this.dataGridView1.Rows[index5].Cells[4].Value = "√";
            this.dataGridView1.Rows[index5].Cells[5].Value = "√";
            this.dataGridView1.Rows[index5].Cells[6].Value = "√";
            this.dataGridView1.Rows[index5].Cells[7].Value = "√";
            this.dataGridView1.Rows[index5].Cells[8].Value = "√";
            this.dataGridView1.Rows[index5].Cells[9].Value = "√";
            this.dataGridView1.Rows[index5].Cells[10].Value = "√";
            this.dataGridView1.Rows[index5].Cells[11].Value = "√";
            this.dataGridView1.Rows[index5].Cells[12].Value = "√";
            int index6 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index6].Cells[0].Value = "7";
            this.dataGridView1.Rows[index6].Cells[1].Value = "043-29051";
            this.dataGridView1.Rows[index6].Cells[2].Value = "RD3A1";
            this.dataGridView1.Rows[index6].Cells[3].Value = "√";
            this.dataGridView1.Rows[index6].Cells[4].Value = "√";
            this.dataGridView1.Rows[index6].Cells[5].Value = "√";
            this.dataGridView1.Rows[index6].Cells[6].Value = "√";
            this.dataGridView1.Rows[index6].Cells[7].Value = "√";
            this.dataGridView1.Rows[index6].Cells[8].Value = "√";
            this.dataGridView1.Rows[index6].Cells[9].Value = "√";
            this.dataGridView1.Rows[index6].Cells[10].Value = "√";
            this.dataGridView1.Rows[index6].Cells[11].Value = "√";
            this.dataGridView1.Rows[index6].Cells[12].Value = "√";
            dataGridView1.Rows[0].Selected = false;

        }
        private void UserLDJC_Load(object sender, EventArgs e)
        {
            InitDataTable();
            //添加的两组Test数据
            List<String> txData2 = new List<String>() { "收入","磁粉探伤","微机探","轮轴超探","镟修","轮辋超探","动平衡检测","支出测量","入库","支出"  };
            List<int> tyData2 = new List<int>() { 87, 96, 87, 84, 95, 74, 89, 87, 58, 78 };
            List<int> txData3 = new List<int>() { 2012 };
            List<int> tyData3 = new List<int>() { 7 };
            //chart1.ChartAreas.Add(new ChartArea() { Name = "ca1" }); //背景框
            chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false; //X轴上网格
            chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = false; //y轴上网格
            chart1.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart1.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].Axes[0].MajorTickMark.Enabled = false; // x轴上突出的小点
            chart1.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false; //
            chart1.ChartAreas[0].Axes[1].InterlacedColor = Color.LightGray; //显示交错带颜色
            chart1.ChartAreas[0].Axes[1].IsInterlaced = true; //显示交错带
            chart1.ChartAreas[0].Axes[0].LabelStyle.Format = "# (套)"; //设置X轴显示样式
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Blue;
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 3;
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent; //设置区域内背景透明

            chart1.ChartAreas[0].AxisY.Minimum = 0;//设定y轴的最小值
            //chart1.ChartAreas[0].AxisY.Maximum = 1000;//设定y轴的最大值
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;   //设置是否交错显示,比如数据多的时间分成两行来显示 
            //chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.Series.Add(new Series()); //添加一个图表序列
            chart1.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            chart1.Series[0].Label = "#VAL"; //设置显示X Y的值
            chart1.Series[0].ToolTip = "#VALX(套)\r#VAL"; //鼠标移动到对应点显示数值
            //chart1.Series[0].LegendText = "#PERCENT";
            chart1.Series[0].ChartArea = chart1.ChartAreas[0].Name; //设置图表背景框ChartArea 
            chart1.Series[0].ChartType = SeriesChartType.Column; //图类型(折线)
            chart1.Series[0].Points.DataBindXY(txData2, tyData2); //添加数据

            //柱状图其他设置
            //chart1.Series[0]["DrawingStyle"] = "Emboss";   //设置柱状平面形状
            chart1.Series[0]["PointWidth"] = "0.5"; //设置柱状大小

            //chart1.Series[0].IsXValueIndexed = true;
            //2、读取数据库，得到数据列表，绑定列表得到折线图：
            //List<DateTime> x = 读取数据库得到时间列表;
            //List<double> y = 读取数据库得到温度列表;
            //this.chart1.Series[0].ChartType=SeriesChartType.Line; 
            //this.chart1.Series[0].Points.DataBindXY(x,y);
          
        }
    }
}
