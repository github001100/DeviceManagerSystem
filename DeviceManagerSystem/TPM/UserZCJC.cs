using CMES.Controller.SYS;
using CMES.NET;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DeviceManagerSystem.TPM
{
    /// <summary>
    /// 轮轴车间轴承检修进度监控
    /// </summary>
    public partial class UserZCJC : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private static UserZCJC frm = null;
        List<int> tyData2 = new List<int>() { 87, 96, 87, 84, 95, 74, 89, 87, 58, 78, 4 };
        List<String> txData2 = new List<String>() { "轴承打码", "轴承除锈", "外观检查", "滚子探伤", "内圈探伤", "外圈探伤", "轴承清洗", "尺寸测量1", "尺寸测量2", "轴承入库", "轴承报废" };

        public static UserZCJC CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new UserZCJC();
            }
            return frm;
        }
        public UserZCJC()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

            //chart1.Titles.Add("柱状图数据分析");
            //chart1.ChartAreas[0].AxisX.Title = "时间(月)";
            //chart1.ChartAreas[0].AxisY.Title = "单位(元)";
            ////chart1
            //Series series = chart1.Series["Series1"];
            //series.LegendText = "销售分析";
            //chart1.DataSource = "list";
            //series.XValueMember = "time";
            //series.YValueMembers = "value";
        }

        class LirunModel
        {
            private double _value;

            public double Value
            {
                get { return _value; }
                set { _value = value; }
            }
            private string _time;

            public string Time
            {
                get { return _time; }
                set { _time = value; }
            }
        }
        ZtjkController ztjk = new ZtjkController();

        public void Test()
        {

            JObject jsonobj2 = null;
            string jsonStr2 = ztjk.GetZtjkInfoByProcedureNameToJson("'轴承检修'", "'轴承'");
            JObject o2 = JObject.Parse(jsonStr2);

            JArray json2 = (JArray)o2["data"];
            for (int j = 0; j < json2.Count; j++)
            {
                jsonobj2 = (JObject)json2[j];
                //MessageBox.Show(jsonobj2["id"].ToString() + "|" + jsonobj2["ProcedureName"].ToString(), json2.Count + "共");
                textBox1.Text = jsonobj2["TaskPlans"].ToString();
                textBox2.Text = Convert.ToInt32(jsonobj2["TaskPlans"]) - (Convert.ToInt32(jsonobj2["QualifiedQuantity"]) + Convert.ToInt32(jsonobj2["UnqualifiedQuantity"])) + "";//待检数
                textBox3.Text = jsonobj2["QualifiedQuantity"].ToString();
                textBox4.Text = jsonobj2["UnqualifiedQuantity"].ToString();
                textBox5.Text = Convert.ToDouble(jsonobj2["PassRate"]) / 10 + "%";
            }

        }
        DataTable dt; DataSet ds;
        public void flashTableDataGridView()
        {
            try
            {
                string jsonStr22 = ztjk.GetZtjkInfoToJson("ALL", "ALL");
                JObject o2 = JObject.Parse(jsonStr22);
                //JObject jsonobj2 = null;

                JArray json2 = (JArray)o2["data"];
                //ToDataTableTwo(json2.ToString());
                dt = Json.ToTable(json2.ToString());
                //ds = Json.ToDataSet(json2.ToString());
                //dt = ds.Tables["Temp"];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    //jsonobj2 = (JObject)json2[j];
                    //MessageBox.Show(jsonobj2[0]["id"].ToString() + "|" + jsonobj2["ProcedureName"].ToString(), json2.Count + "共");
                    this.dataGridView1.Rows[j].Cells[0].Value = dt.Rows[j]["id"].ToString();
                    this.dataGridView1.Rows[j].Cells[1].Value = dt.Rows[j]["bh"].ToString();
                    this.dataGridView1.Rows[j].Cells[2].Value = dt.Rows[j]["xjzc"].ToString();
                    this.dataGridView1.Rows[j].Cells[3].Value = dt.Rows[j]["zccj"].ToString();
                    this.dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j]["zcdm"].ToString();
                    this.dataGridView1.Rows[j].Cells[5].Value = dt.Rows[j]["zccx"].ToString();
                    this.dataGridView1.Rows[j].Cells[6].Value = dt.Rows[j]["wgWaiquan"].ToString();
                    this.dataGridView1.Rows[j].Cells[7].Value = dt.Rows[j]["tsGunzi"].ToString();
                    this.dataGridView1.Rows[j].Cells[8].Value = dt.Rows[j]["tsNeiquan"].ToString();
                    this.dataGridView1.Rows[j].Cells[9].Value = dt.Rows[j]["tsWaiquan"].ToString();
                    this.dataGridView1.Rows[j].Cells[10].Value = dt.Rows[j]["tsGunziShengci"].ToString();//实际为轴承清洗

                    this.dataGridView1.Rows[j].Cells[11].Value = dt.Rows[j]["Measurement1ScrapMark"].ToString();
                    this.dataGridView1.Rows[j].Cells[12].Value = dt.Rows[j]["Measurement2ScrapMark"].ToString();
                    this.dataGridView1.Rows[j].Cells[13].Value = dt.Rows[j]["s_inTime"] != null ? "√" : "";//Convert.ToDateTime(dt.Rows[j]["s_inTime"]).ToString("yyyy-MM-dd")
                    this.dataGridView1.Rows[j].Cells[14].Value = dt.Rows[j]["s_outTime"] != null ? "√" : "";//Convert.ToDateTime(dt.Rows[j]["s_outTime"]).ToString("yyyy-MM-dd")

                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int O = 0; O < dataGridView1.Rows[i].Cells.Count; O++)
                    {
                        if (this.dataGridView1.Rows[i].Cells[O].Value != null)
                        {
                            if (this.dataGridView1.Rows[i].Cells[O].Value.ToString() == "×")
                            {
                                this.dataGridView1.Rows[i].Cells[O].Style.BackColor = Color.Red;
                            }
                            if (this.dataGridView1.Rows[i].Cells[O].Value.ToString() == "√")
                            {
                                this.dataGridView1.Rows[i].Cells[O].Style.BackColor = Color.White;

                            }
                        }

                    }
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Num_[0] += int.Parse(dr["累加字段"].ToString());
                    //}

                }
                RefreshList();
                object test = dt.Compute("Count(zcdm)", "zcdm='√'");
                Console.WriteLine("测试====================================" + test);
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void ComputeBySalesSalesID(DataSet dataSet)
        {
            // Presumes a DataTable named "Orders" that has a column named "Total."
            DataTable table;
            table = dataSet.Tables["temp"];

            // Declare an object variable.
            object sumObject;
            sumObject = table.Compute("Count(zcdm)", "cItem = '√'");
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
            dataGridView1.Columns[1].Width = 180;

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "1";
            this.dataGridView1.Rows[index].Cells[1].Value = "573-1708109";
            this.dataGridView1.Rows[index].Cells[2].Value = "旧";
            this.dataGridView1.Rows[index].Cells[3].Value = "LYC";
            this.dataGridView1.Rows[index].Cells[4].Value = "√";
            this.dataGridView1.Rows[index].Cells[5].Value = "√";
            this.dataGridView1.Rows[index].Cells[6].Value = "√";
            this.dataGridView1.Rows[index].Cells[5].Value = "√";
            this.dataGridView1.Rows[index].Cells[7].Value = "√";
            this.dataGridView1.Rows[index].Cells[8].Value = "√";
            this.dataGridView1.Rows[index].Cells[9].Value = "√";
            this.dataGridView1.Rows[index].Cells[10].Value = "√";
            this.dataGridView1.Rows[index].Cells[11].Value = "√";
            this.dataGridView1.Rows[index].Cells[12].Value = "√";
            this.dataGridView1.Rows[index].Cells[13].Value = "√";
            this.dataGridView1.Rows[index].Cells[14].Value = "-";

            int index1 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index1].Cells[0].Value = "2";
            this.dataGridView1.Rows[index1].Cells[1].Value = "573-1708110";
            this.dataGridView1.Rows[index1].Cells[2].Value = "旧";
            this.dataGridView1.Rows[index1].Cells[3].Value = "LYC";
            this.dataGridView1.Rows[index1].Cells[4].Value = "√";
            this.dataGridView1.Rows[index1].Cells[5].Value = "√";
            this.dataGridView1.Rows[index1].Cells[6].Value = "× ";
            this.dataGridView1.Rows[index1].Cells[5].Value = "";
            this.dataGridView1.Rows[index1].Cells[7].Value = "";
            this.dataGridView1.Rows[index1].Cells[8].Value = "";
            this.dataGridView1.Rows[index1].Cells[9].Value = "";
            this.dataGridView1.Rows[index1].Cells[10].Value = "";
            this.dataGridView1.Rows[index1].Cells[11].Value = "";
            this.dataGridView1.Rows[index1].Cells[12].Value = "";
            this.dataGridView1.Rows[index1].Cells[13].Value = "";
            this.dataGridView1.Rows[index1].Cells[14].Value = "-";

            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "3";
            this.dataGridView1.Rows[index2].Cells[1].Value = "175-1512223";
            this.dataGridView1.Rows[index2].Cells[2].Value = "旧";
            this.dataGridView1.Rows[index2].Cells[3].Value = "HRB";
            this.dataGridView1.Rows[index2].Cells[4].Value = "√";
            this.dataGridView1.Rows[index2].Cells[5].Value = "√";
            this.dataGridView1.Rows[index2].Cells[6].Value = "√";
            this.dataGridView1.Rows[index2].Cells[5].Value = "√";
            this.dataGridView1.Rows[index2].Cells[7].Value = "√";
            this.dataGridView1.Rows[index2].Cells[8].Value = "√";
            this.dataGridView1.Rows[index2].Cells[9].Value = "√";
            this.dataGridView1.Rows[index2].Cells[10].Value = "√";
            this.dataGridView1.Rows[index2].Cells[11].Value = "√";
            this.dataGridView1.Rows[index2].Cells[12].Value = "√";
            this.dataGridView1.Rows[index2].Cells[13].Value = "-";
            this.dataGridView1.Rows[index2].Cells[14].Value = "-";

            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "4";
            this.dataGridView1.Rows[index3].Cells[1].Value = "175-1512224";
            this.dataGridView1.Rows[index3].Cells[2].Value = "旧";
            this.dataGridView1.Rows[index3].Cells[3].Value = "HRB";
            this.dataGridView1.Rows[index3].Cells[4].Value = "√";
            this.dataGridView1.Rows[index3].Cells[5].Value = "√";
            this.dataGridView1.Rows[index3].Cells[6].Value = "√";
            this.dataGridView1.Rows[index3].Cells[5].Value = "√";
            this.dataGridView1.Rows[index3].Cells[7].Value = "√";
            this.dataGridView1.Rows[index3].Cells[8].Value = "√";
            this.dataGridView1.Rows[index3].Cells[9].Value = "√";
            this.dataGridView1.Rows[index3].Cells[10].Value = "√";
            this.dataGridView1.Rows[index3].Cells[11].Value = "√";
            this.dataGridView1.Rows[index3].Cells[12].Value = "-";
            this.dataGridView1.Rows[index3].Cells[13].Value = "-";
            this.dataGridView1.Rows[index3].Cells[14].Value = "-";

            int index4 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index4].Cells[0].Value = "5";
            this.dataGridView1.Rows[index4].Cells[1].Value = "573-2002007";
            this.dataGridView1.Rows[index4].Cells[2].Value = "新";
            this.dataGridView1.Rows[index4].Cells[3].Value = "SKF";
            this.dataGridView1.Rows[index4].Cells[4].Value = "√";
            this.dataGridView1.Rows[index4].Cells[5].Value = "√";
            this.dataGridView1.Rows[index4].Cells[6].Value = "√";
            this.dataGridView1.Rows[index4].Cells[5].Value = "√";
            this.dataGridView1.Rows[index4].Cells[7].Value = "√";
            this.dataGridView1.Rows[index4].Cells[8].Value = "√";
            this.dataGridView1.Rows[index4].Cells[9].Value = "-";
            this.dataGridView1.Rows[index4].Cells[10].Value = "-";
            this.dataGridView1.Rows[index4].Cells[11].Value = "-";
            this.dataGridView1.Rows[index4].Cells[12].Value = "-";
            this.dataGridView1.Rows[index4].Cells[13].Value = "-";
            this.dataGridView1.Rows[index4].Cells[14].Value = "-";

            int index5 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index5].Cells[0].Value = "6";
            this.dataGridView1.Rows[index5].Cells[1].Value = "573-2002008";
            this.dataGridView1.Rows[index5].Cells[2].Value = "新";
            this.dataGridView1.Rows[index5].Cells[3].Value = "SKF";
            this.dataGridView1.Rows[index5].Cells[4].Value = "√";
            this.dataGridView1.Rows[index5].Cells[5].Value = "√";
            this.dataGridView1.Rows[index5].Cells[6].Value = "√";
            this.dataGridView1.Rows[index5].Cells[5].Value = "√";
            this.dataGridView1.Rows[index5].Cells[7].Value = "√";
            this.dataGridView1.Rows[index5].Cells[8].Value = "√";
            this.dataGridView1.Rows[index5].Cells[9].Value = "-";
            this.dataGridView1.Rows[index5].Cells[10].Value = "-";
            this.dataGridView1.Rows[index5].Cells[11].Value = "-";
            this.dataGridView1.Rows[index5].Cells[12].Value = "-";
            this.dataGridView1.Rows[index5].Cells[13].Value = "-";
            this.dataGridView1.Rows[index5].Cells[14].Value = "-";

            dataGridView1.Rows[0].Selected = false;
        }
        public void RefreshList()
        {
            int zcbfCount = 0;

            if (this.dataGridView1.Rows.Count > 0)
            {
                zcbfCount = Convert.ToInt32(dt.Compute("Count(zcdm)", "zcdm='×'")) + Convert.ToInt32(dt.Compute("Count(zccx)", "zccx='×'"))
               + Convert.ToInt32(dt.Compute("Count(wgWaiquan)", "wgWaiquan='×'")) + Convert.ToInt32(dt.Compute("Count(tsGunzi)", "tsGunzi='×'"))
               + Convert.ToInt32(dt.Compute("Count(tsNeiquan)", "tsNeiquan='×'")) + Convert.ToInt32(dt.Compute("Count(tsWaiquan)", "tsWaiquan='×'"))
               + Convert.ToInt32(dt.Compute("Count(tsGunziShengci)", "tsGunziShengci='×'")) + Convert.ToInt32(dt.Compute("Count(Measurement1ScrapMark)", "Measurement1ScrapMark='×'"))
               + Convert.ToInt32(dt.Compute("Count(Measurement2ScrapMark)", "Measurement2ScrapMark='×'"));
                tyData2.Clear();
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(zcdm)", "zcdm='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(zccx)", "zccx='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(wgWaiquan)", "wgWaiquan='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(tsGunzi)", "tsGunzi='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(tsNeiquan)", "tsNeiquan='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(tsWaiquan)", "tsWaiquan='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(tsGunziShengci)", "tsGunziShengci='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(Measurement1ScrapMark)", "Measurement1ScrapMark='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(Measurement2ScrapMark)", "Measurement2ScrapMark='√'")));
                tyData2.Add(Convert.ToInt32(dt.Compute("Count(s_inTime)", "s_inTime<>''")));
                //tyData2.Add(Convert.ToInt32(dt.Compute("Count(s_outTime)", "s_outTime<>''")));
                tyData2.Add(zcbfCount);
            }
            else
            {
                tyData2 = new List<int>() { 87, 96, 87, 84, 95, 74, 89, 87, 58, 78, 4 };
            }
            //tyData2.Reverse();

            chart1.Series[0].Points.DataBindXY(txData2, tyData2);

        }
        CancellationTokenSource cancelltokenSource = new CancellationTokenSource();

        private void UserZCJC_Load(object sender, EventArgs e)
        {
            this.Font = new Font("微软雅黑", 10);
            for (int i = 2; i < 13; i++)
            {
                //this.dataGridView1.Columns[i].Width = 85;

            }
            //this.dataGridView1.Columns[13].Width = 210;
            //this.dataGridView1.Columns[14].Width = 210;
            Task.Factory.StartNew(() =>
            {
                while (!cancelltokenSource.IsCancellationRequested)
                {
                    Test();
                    flashTableDataGridView();
                    Task.Delay(1000).Wait();
                }
            }, cancelltokenSource.Token);
            InitDataTable();
            //添加的两组Test数据
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
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10);
            chart1.ChartAreas[0].AxisY.Minimum = 0;//设定y轴的最小值
            //chart1.ChartAreas[0].AxisY.Maximum = 1000;//设定y轴的最大值
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;   //设置是否交错显示,比如数据多的时间分成两行来显示 
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
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
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

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
        private void UserZCJC_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception)
            {

                timer1.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
    }
}
