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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CMES.Controller.SYS;
using System.Web.Script.Serialization;
using System.Threading;

namespace DeviceManagerSystem.TPM
{
    /// <summary>
    /// 轮轴车间检修总体进度监控
    /// </summary>
    public partial class UserZTJXJD : UserControl
    {
        ZtjkController ztjk = new ZtjkController();//整体检修 业务逻辑2.0
        public DataSet ds;
        List<Double> tyData2 = new List<Double>();
        List<String> txData2 = new List<String>() { "轮对", "轴承", "轮轴拆分", "轮轴组装", "轴箱", "前盖", "防尘挡圈" };
        private Queue<double> dataQueue = new Queue<double>(100);
        private static UserZTJXJD frm = null;

        public static UserZTJXJD CreateInstrance()
        {
            if (frm == null|| frm.IsDisposed)
            {
                frm = new UserZTJXJD();
            }
            return frm;
        }
        public void RefreshList()
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                tyData2.Clear();
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[0].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[0].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[0].Cells["任务计划数"].Value), 3) * 100);
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[1].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[1].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[1].Cells["任务计划数"].Value), 3) * 100);
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[2].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[2].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[2].Cells["任务计划数"].Value), 3) * 100);
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[3].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[3].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[3].Cells["任务计划数"].Value), 3) * 100);
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[4].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[4].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[4].Cells["任务计划数"].Value), 3) * 100);
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[5].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[5].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[5].Cells["任务计划数"].Value), 3) * 100);
                tyData2.Add(Math.Round((Convert.ToDouble(this.dataGridView1.Rows[6].Cells[8].Value) + Convert.ToDouble(this.dataGridView1.Rows[6].Cells[9].Value)) / Convert.ToDouble(this.dataGridView1.Rows[6].Cells["任务计划数"].Value), 3) * 100);
            }
            else
            {
                tyData2 = new List<Double>() { 33.6, 39.6, 58.9, 48.6, 59.4, 58.4, 39.7 };
            }
            chart1.Series[0].Points.DataBindXY(txData2, tyData2);

        }
        private void FullDataSource()
        {

            SetTable();
        }
        public UserZTJXJD()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //UpdateStatus.Continue;  
            UpdateStyles();
            InitDataTable();

        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
                return;
            base.WndProc(ref m);
        }
        string jsonStr2 = "";
        public void SetTable()
        {
            try
            {               
                //整体检修进度表
                //JObject jsonobj2 = null;
                jsonStr2 = ztjk.GetZtjkInfoByProcedureNameToJson("ALL","ALL");//获取所以信息
                JObject o2 = JObject.Parse(jsonStr2);
                JArray json2 = (JArray)o2["data"];
                //ds = JsonToDataSet("date:{"+ json2 + "}");
                dynamic model = JsonConvert.DeserializeObject(jsonStr2);
                //this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = model.data;//                        未包含data的定义 2020.4.03
                //this.dataGridView1.Columns["SerialNumber"].Visible = false;
                //this.dataGridView1.Columns["Others"].Visible = false;
                //this.dataGridView1.Columns["OverhaulDate"].Visible = false;
                //this.dataGridView1.Columns["UpdateTime"].Visible = false;
                //this.dataGridView1.Columns["开工时间"].DefaultCellStyle.Format = "yyyy-MM-dd";//yyyy-MM-dd hh:mm:ss
                this.dataGridView1.Refresh();
                this.dataGridView1.Update();
                this.dataGridView1.EndEdit();
                //DataTable dt = new DataTable();
                //this.dataGridView1.DataSource = ds.Tables["ds"];
 
                RefreshList();
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                //throw;
            }

        }
        /// <summary>
        /// 将JSON解析成DataSet只限标准的JSON数据
        /// 例如：Json＝{t1:[{name:'数据name',type:'数据type'}]} 
        /// 或 Json＝{t1:[{name:'数据name',type:'数据type'}],t2:[{id:'数据id',gx:'数据gx',val:'数据val'}]}
        /// </summary>
        /// <param name="Json">Json字符串</param>
        /// <returns>DataSet</returns>
        public static DataSet JsonToDataSet(string Json)
        {
            try
            {
                DataSet ds = new DataSet();
                JavaScriptSerializer JSS = new JavaScriptSerializer();

                object obj = JSS.DeserializeObject(Json);
                Dictionary<string, object> datajson = (Dictionary<string, object>)obj;

                foreach (var item in datajson)
                {
                    DataTable dt = new DataTable(item.Key);
                    object[] rows = (object[])item.Value;
                    foreach (var row in rows)
                    {
                        Dictionary<string, object> val = (Dictionary<string, object>)row;
                        DataRow dr = dt.NewRow();
                        foreach (KeyValuePair<string, object> sss in val)
                        {
                            if (!dt.Columns.Contains(sss.Key))
                            {
                                dt.Columns.Add(sss.Key.ToString());
                                dr[sss.Key] = sss.Value;
                            }
                            else
                                dr[sss.Key] = sss.Value;
                        }
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch
            {
                return null;
            }
        }
        #region 表格初始化
        public void InitDataTable()
        {
            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0x00, 0xCC, 0x99);
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "1";
            this.dataGridView1.Rows[index].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index].Cells[2].Value = "轮轴拆分";
            this.dataGridView1.Rows[index].Cells[3].Value = "轮轴";
            this.dataGridView1.Rows[index].Cells[4].Value = "24";
            this.dataGridView1.Rows[index].Cells[5].Value = "18";
            this.dataGridView1.Rows[index].Cells[6].Value = "4";
            this.dataGridView1.Rows[index].Cells[7].Value = "2";
            this.dataGridView1.Rows[index].Cells[8].Value = "08:16:35";
            this.dataGridView1.Rows[index].Cells[9].Value = "66.7%";
            this.dataGridView1.Rows[index].Cells[10].Value = "01:16:35";

            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "2";
            this.dataGridView1.Rows[index2].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index2].Cells[2].Value = "轮对检修";
            this.dataGridView1.Rows[index2].Cells[3].Value = "轮对";
            this.dataGridView1.Rows[index2].Cells[4].Value = "26";
            this.dataGridView1.Rows[index2].Cells[5].Value = "18";
            this.dataGridView1.Rows[index2].Cells[6].Value = "6";
            this.dataGridView1.Rows[index2].Cells[7].Value = "2";
            this.dataGridView1.Rows[index2].Cells[8].Value = "08:16:35";
            this.dataGridView1.Rows[index2].Cells[9].Value = "75.0%";
            this.dataGridView1.Rows[index2].Cells[10].Value = "01:22:35";
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "3";
            this.dataGridView1.Rows[index3].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index3].Cells[2].Value = "轴承检修";
            this.dataGridView1.Rows[index3].Cells[3].Value = "轴承";
            this.dataGridView1.Rows[index3].Cells[4].Value = "128";
            this.dataGridView1.Rows[index3].Cells[5].Value = "89";
            this.dataGridView1.Rows[index3].Cells[6].Value = "33";
            this.dataGridView1.Rows[index3].Cells[7].Value = "6";
            this.dataGridView1.Rows[index3].Cells[8].Value = "08:23:28";
            this.dataGridView1.Rows[index3].Cells[9].Value = "84.7%";
            this.dataGridView1.Rows[index3].Cells[10].Value = "01:28:35";

            int index4 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index4].Cells[0].Value = "4";
            this.dataGridView1.Rows[index4].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index4].Cells[2].Value = "零部件检修";
            this.dataGridView1.Rows[index4].Cells[3].Value = "轴箱";
            this.dataGridView1.Rows[index4].Cells[4].Value = "48";
            this.dataGridView1.Rows[index4].Cells[5].Value = "16";
            this.dataGridView1.Rows[index4].Cells[6].Value = "21";
            this.dataGridView1.Rows[index4].Cells[7].Value = "1";
            this.dataGridView1.Rows[index4].Cells[8].Value = "08:43:10";
            this.dataGridView1.Rows[index4].Cells[9].Value = "95.5%";
            this.dataGridView1.Rows[index4].Cells[10].Value = "03:16:35";
            int index5 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index5].Cells[0].Value = "5";
            this.dataGridView1.Rows[index5].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index5].Cells[2].Value = "零部件检修";
            this.dataGridView1.Rows[index5].Cells[3].Value = "前盖";
            this.dataGridView1.Rows[index5].Cells[4].Value = "48";
            this.dataGridView1.Rows[index5].Cells[5].Value = "22";
            this.dataGridView1.Rows[index5].Cells[6].Value = "25";
            this.dataGridView1.Rows[index5].Cells[7].Value = "1";
            this.dataGridView1.Rows[index5].Cells[8].Value = "08:52:09";
            this.dataGridView1.Rows[index5].Cells[9].Value = "96.2%";
            this.dataGridView1.Rows[index5].Cells[10].Value = "04:16:35";
            int index6 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index6].Cells[0].Value = "6";
            this.dataGridView1.Rows[index6].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index6].Cells[2].Value = "零部件检修";
            this.dataGridView1.Rows[index6].Cells[3].Value = "防尘挡圈";
            this.dataGridView1.Rows[index6].Cells[4].Value = "48";
            this.dataGridView1.Rows[index6].Cells[5].Value = "28";
            this.dataGridView1.Rows[index6].Cells[6].Value = "18";
            this.dataGridView1.Rows[index6].Cells[7].Value = "2";
            this.dataGridView1.Rows[index6].Cells[8].Value = "08:53:16";
            this.dataGridView1.Rows[index6].Cells[9].Value = "90.0%";
            this.dataGridView1.Rows[index6].Cells[10].Value = "03:16:35";
            int index7 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index7].Cells[0].Value = "7";
            this.dataGridView1.Rows[index7].Cells[1].Value = "西辆(573)";
            this.dataGridView1.Rows[index7].Cells[2].Value = "轮轴组装";
            this.dataGridView1.Rows[index7].Cells[3].Value = "轮轴";
            this.dataGridView1.Rows[index7].Cells[4].Value = "24";
            this.dataGridView1.Rows[index7].Cells[5].Value = "22";
            this.dataGridView1.Rows[index7].Cells[6].Value = "2";
            this.dataGridView1.Rows[index7].Cells[7].Value = "0";
            this.dataGridView1.Rows[index7].Cells[8].Value = "08:00:00";
            this.dataGridView1.Rows[index7].Cells[9].Value = "100.0%";
            this.dataGridView1.Rows[index7].Cells[10].Value = "00:36:35";

            dataGridView1.Rows[0].Selected = false;
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Rows[index3].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Rows[index5].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Rows[index7].DefaultCellStyle.BackColor = Color.LightGray;

        }
        #endregion
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
        CancellationTokenSource cancelltokenSource = new CancellationTokenSource();

        private void UserZTJXJD_Load(object sender, EventArgs e)
        {
            this.Font = new Font("微软雅黑", 10);
            //Thread t = new Thread(new ThreadStart(FullDataSource));
            //t.Start();
            //添加的两组Test数据
            chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false; //X轴上网格
            chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = false; //y轴上网格
            chart1.ChartAreas[0].Axes[0].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart1.ChartAreas[0].Axes[0].MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].Axes[0].MajorTickMark.Enabled = false; // x轴上突出的小点
            chart1.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false; //
            chart1.ChartAreas[0].Axes[1].InterlacedColor = Color.LightGray; //显示交错带颜色
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10);

            chart1.ChartAreas[0].Axes[0].LabelStyle.Format = "# (%)"; //设置X轴显示样式
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineDashStyle = ChartDashStyle.Dash; //网格类型 短横线
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineColor = Color.Blue;
            chart1.ChartAreas[0].Axes[1].MajorGrid.LineWidth = 3;
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent; //设置区域内背景透明
            //chart1.Series[0].Points.DataBindXY(txData2, tyData2); 
            chart1.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            chart1.Series[0].Label = "#VAL"; //设置显示X Y的值
            chart1.Series[0].ToolTip = "#VALX(%)\r#VAL"; //鼠标移动到对应点显示数值
            //柱状图其他设置
            //chart1.Series[0]["DrawingStyle"] = "Emboss";   //设置柱状平面形状
            chart1.Series[0]["PointWidth"] = "0.5"; //设置柱状大小
            timer1.Enabled = true;

            dataGridView1.EnableHeadersVisualStyles = false;
            //开启设备连接线程
            Task.Factory.StartNew(() =>
            {
                while (!cancelltokenSource.IsCancellationRequested)
                {

                    //Task.Delay(5000).Wait();
                }
            }, cancelltokenSource.Token);
        }
        //刷新虚函数
        public void ReflashData()
        {
            //UserZTJXJD_Load(this, null);//调用当前激活界面的Load事件
            SetTable();
        }

        //重写刷新函数
        //public override void ReflashData()
        //{
        //}
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["开工时间"].Index || e.ColumnIndex == dataGridView1.Columns["开工时间"].Index)
            {
                //if (dpString.dTrim(e.Value) != "")
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("MM-dd-yyyy");
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["合格率"].Index)
            {
                //if (dpString.dTrim(e.Value) != "")
                {
                    e.Value = (Convert.ToDouble(e.Value) / 1000).ToString("0.0%");//
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["工作进度"].Index)
            {
                //if (dpString.dTrim(e.Value) != "")
                {
                    e.Value = Convert.ToDouble(e.Value) / 10 + "%";
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ReflashData();

        }
    }
}
