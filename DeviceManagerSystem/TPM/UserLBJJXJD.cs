using CMES.Controller.SYS;
using CMES.NET;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DeviceManagerSystem.TPM
{
    /// <summary>
    /// 轮轴车间轮轴零部件检修进度监控
    /// </summary>
    public partial class UserLBJJXJD : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private DataTable dt = new DataTable();
        ZtjkController ztjk = new ZtjkController();//整体检修 业务逻辑2.0

        BindingSource bs = new BindingSource();
        private static UserLBJJXJD frm = null;

        public static UserLBJJXJD CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new UserLBJJXJD();
            }
            return frm;
        }
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
            this.dataGridView1.Rows[index2].Cells[0].Value = "防尘挡圈";
            this.dataGridView1.Rows[index2].Cells[1].Value = "56";
            this.dataGridView1.Rows[index2].Cells[2].Value = "35";
            this.dataGridView1.Rows[index2].Cells[3].Value = "20";
            this.dataGridView1.Rows[index2].Cells[4].Value = "2";
            this.dataGridView1.Rows[index2].Cells[5].Value = "95.0%";
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "端盖";
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
            this.dataGridView2.Rows[index4].Cells[5].Value = "32";
            int index5 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index5].Cells[0].Value = "防尘挡圈";
            this.dataGridView2.Rows[index5].Cells[1].Value = "56";
            this.dataGridView2.Rows[index5].Cells[2].Value = "35";
            this.dataGridView2.Rows[index5].Cells[3].Value = "20";
            this.dataGridView2.Rows[index5].Cells[4].Value = "2";
            this.dataGridView2.Rows[index5].Cells[5].Value = "22";
            int index6 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index6].Cells[0].Value = "端盖";
            this.dataGridView2.Rows[index6].Cells[1].Value = "52";
            this.dataGridView2.Rows[index6].Cells[2].Value = "28";
            this.dataGridView2.Rows[index6].Cells[3].Value = "24";
            this.dataGridView2.Rows[index6].Cells[4].Value = "0";
            this.dataGridView2.Rows[index6].Cells[5].Value = "20";

            //dataGridView2.Rows[0].Selected = false;
            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
            dataGridView1.Rows[index3].DefaultCellStyle.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
            //dataGridView2.Rows[index4].DefaultCellStyle.BackColor = Color.LawnGreen;
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
        //添加的两组Test数据
        List<String> txData2 = new List<String>() { "除锈清洗", "二维码喷码", "外观检查", "尺寸测量", "管理入库" };
        List<int> tyData2 = new List<int>() { 87, 96, 87, 84, 95 };
        List<int> tyData3 = new List<int>() { 0, 1, 0, 0, 0 };
        public void RefreshList(int row)
        {
            if (this.dataGridView2.Rows.Count > 0)
            {
                tyData2.Clear();
                tyData2.Add(Convert.ToInt16(this.dataGridView2.Rows[row].Cells[1].Value));
                tyData2.Add(Convert.ToInt16(this.dataGridView2.Rows[row].Cells[2].Value));
                tyData2.Add(Convert.ToInt16(this.dataGridView2.Rows[row].Cells[3].Value));
                tyData2.Add(Convert.ToInt16(this.dataGridView2.Rows[row].Cells[4].Value));
                tyData2.Add(Convert.ToInt16(this.dataGridView2.Rows[row].Cells[5].Value));
            }
            else
            {
                tyData2 = new List<int>() { 5, 7, 9, 3, 8 };
            }
            chart1.Series[0].Points.DataBindXY(txData2, tyData2);
        }
        private void UserLBJJXJD_Load(object sender, EventArgs e)
        {
            this.Font = new Font("微软雅黑", 10);

            InitDataTable();

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
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10);
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
            //thread.Start();
            string jsonStr22 = ztjk.GetZtjkInfoByProcedureNameToJson("'轴箱检修','前盖检修','防尘挡圈检修'", "'轴箱','前盖','防尘挡圈'");
            JObject o2 = JObject.Parse(jsonStr22);
            //JObject jsonobj2 = null;

            JArray json2 = (JArray)o2["data"];
            //ToDataTableTwo(json2.ToString());
            DataTable dt = Json.ToTable(json2.ToString());
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                //jsonobj2 = (JObject)json2[j];
                //MessageBox.Show(jsonobj2[0]["id"].ToString() + "|" + jsonobj2["ProcedureName"].ToString(), json2.Count + "共");
                this.dataGridView1.Rows[j].Cells[1].Value = dt.Rows[j]["TaskPlans"].ToString();
                this.dataGridView1.Rows[j].Cells[2].Value = dt.Rows[j]["OverhaulQuantity"].ToString();
                this.dataGridView1.Rows[j].Cells[3].Value = dt.Rows[j]["QualifiedQuantity"].ToString();
                this.dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j]["UnqualifiedQuantity"].ToString();
                this.dataGridView1.Rows[j].Cells[5].Value = Convert.ToDouble(dt.Rows[j]["PassRate"].ToString()) / 10 + "%";

            }
            //DataSet ds = Json.ToDataSet(json2.ToJson().ToString());
            //this.dataGridView1.DataSource = dt;
            dataGridView2_CellClick(this, null);

        }

        private void UserLBJJXJD_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow == null) return;
            DataGridViewRow dgvr = dataGridView2.CurrentRow;
            string val = dgvr.Cells[0].Value.ToString();
            groupBox4.Text = "轮轴零部件各工序检修进度监控表" + "--------------------" + val;
            switch (dataGridView2.CurrentRow.Index)
            {
                case 0:
                    RefreshList(0);
                    circleProgramBar.Progress = 100 * (Convert.ToInt16(this.dataGridView1.Rows[0].Cells[3].Value) + Convert.ToInt16(this.dataGridView1.Rows[0].Cells[4].Value)) / Convert.ToInt16(this.dataGridView1.Rows[0].Cells[1].Value);
                    break;
                case 1:
                    RefreshList(1);
                    circleProgramBar.Progress = 100 * (Convert.ToInt16(this.dataGridView1.Rows[1].Cells[3].Value) + Convert.ToInt16(this.dataGridView1.Rows[1].Cells[4].Value)) / Convert.ToInt16(this.dataGridView1.Rows[1].Cells[1].Value);
                    break;
                case 2:
                    RefreshList(2);
                    circleProgramBar.Progress = 100 * (Convert.ToInt16(this.dataGridView1.Rows[2].Cells[3].Value) + Convert.ToInt16(this.dataGridView1.Rows[2].Cells[4].Value)) / Convert.ToInt16(this.dataGridView1.Rows[2].Cells[1].Value);
                    break;
                default:
                    RefreshList(0);
                    circleProgramBar.Progress = 100 * (Convert.ToInt16(this.dataGridView1.Rows[0].Cells[3].Value) + Convert.ToInt16(this.dataGridView1.Rows[0].Cells[4].Value)) / Convert.ToInt16(this.dataGridView1.Rows[0].Cells[1].Value);
                    break;
            }
        }
        PartsController partsController = new PartsController();
        private void timer1_Tick(object sender, EventArgs e)
        {
            string jsonStr22 = ztjk.GetZtjkInfoByProcedureNameToJson("'轴箱检修','前盖检修','防尘挡圈检修'", "'轴箱','前盖','防尘挡圈'");
            string jsonStr23 = partsController.GetPartsInfoToJson("ALL", "ALL");
            JObject o2 = JObject.Parse(jsonStr22);
            JObject o3 = JObject.Parse(jsonStr23);
            //JObject jsonobj2 = null;

            JArray json2 = (JArray)o2["data"];
            JArray json3 = (JArray)o3["data"];
            //ToDataTableTwo(json2.ToString());
            DataTable dt = Json.ToTable(json2.ToString());
            DataTable dt1 = Json.ToTable(json3.ToString());
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                //jsonobj2 = (JObject)json2[j];
                //MessageBox.Show(jsonobj2[0]["id"].ToString() + "|" + jsonobj2["ProcedureName"].ToString(), json2.Count + "共");
                this.dataGridView1.Rows[j].Cells[1].Value = dt.Rows[j]["TaskPlans"].ToString();
                this.dataGridView1.Rows[j].Cells[2].Value = dt.Rows[j]["OverhaulQuantity"].ToString();
                this.dataGridView1.Rows[j].Cells[3].Value = dt.Rows[j]["QualifiedQuantity"].ToString();
                this.dataGridView1.Rows[j].Cells[4].Value = dt.Rows[j]["UnqualifiedQuantity"].ToString();
                this.dataGridView1.Rows[j].Cells[5].Value = Convert.ToDouble(dt.Rows[j]["PassRate"].ToString()) / 10 + "%";

            }
            for (int j = 0; j < dt1.Rows.Count; j++)
            {
                this.dataGridView2.Rows[j].Cells[1].Value = dt1.Rows[j]["CXQX"].ToString();
                this.dataGridView2.Rows[j].Cells[2].Value = dt1.Rows[j]["QrCode"].ToString();
                this.dataGridView2.Rows[j].Cells[3].Value = dt1.Rows[j]["WGJC"].ToString();
                this.dataGridView2.Rows[j].Cells[4].Value = dt1.Rows[j]["CCCL"].ToString();
                this.dataGridView2.Rows[j].Cells[5].Value = dt1.Rows[j]["RK"].ToString();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView2.CurrentRow == null) return;
            //DataGridViewRow dgvr = dataGridView2.CurrentRow;
            //switch (dataGridView2.CurrentRow.Index)
            //{
            //    case 0:
            //        circleProgramBar.Progress = 68;
            //        break;
            //    case 1:
            //        circleProgramBar.Progress = 39;
            //        break;
            //    case 2:
            //        circleProgramBar.Progress = 58;
            //        break;
            //    default:
            //        circleProgramBar.Progress = 48;
            //        break;
            //}
        }
    }
}
