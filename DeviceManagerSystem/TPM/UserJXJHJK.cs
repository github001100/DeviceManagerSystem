using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMES.Controller.SYS;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;

namespace DeviceManagerSystem.TPM
{
    public partial class UserJXJHJK : UserControl
    {
        ZtjkController ztjk = new ZtjkController();//整体检修 业务逻辑2.0

        /// <summary>
        /// 检修任务计划监控
        /// </summary>
        public UserJXJHJK()
        {
            InitializeComponent();
        }
        string jsonStr2 = "";
        public void RefreshList()
        {

            this.dataGridView1.Rows[2].Cells["检修工序"].Value = "轮轴拆分";
            this.dataGridView1.Rows[3].Cells["检修工序"].Value = "轮轴组装";
            //this.dataGridView1.Rows[0].Cells["新增数量"].Value = Convert.ToInt32(SysVar.lz_SN_1);
            //this.dataGridView1.Rows[0].Cells["任务计划"].Value = Convert.ToInt32(SysVar.lz_SN_1) + Convert.ToInt32(this.dataGridView1.Rows[0].Cells["检修数量"].Value)+"";
        }
        public void SetTable()
        {
            try
            {
                //轮轴检修计划表
                //JObject jsonobj2 = null;
                jsonStr2 = ztjk.GetZtjkInfoByProcedureNameToJson("ALL","ALL");
                JObject o2 = JObject.Parse(jsonStr2);
                JArray json2 = (JArray)o2["data"];
                //ds = JsonToDataSet("date:{"+ json2 + "}");
                dynamic model = JsonConvert.DeserializeObject(jsonStr2);
                //this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = model.data;
             
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
        CancellationTokenSource cancelltokenSource = new CancellationTokenSource();

        public void InitDataTable()
        {
            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "1";
            this.dataGridView1.Rows[index].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index].Cells[2].Value = "轮轴检修班";
            this.dataGridView1.Rows[index].Cells[3].Value = "轮轴拆分";
            this.dataGridView1.Rows[index].Cells[4].Value = "24";
            this.dataGridView1.Rows[index].Cells[5].Value = "24";
            this.dataGridView1.Rows[index].Cells[6].Value = "0";

            int index1 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index1].Cells[0].Value = "2";
            this.dataGridView1.Rows[index1].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index1].Cells[2].Value = "轮轴检修班";
            this.dataGridView1.Rows[index1].Cells[3].Value = "轮对检修";
            this.dataGridView1.Rows[index1].Cells[4].Value = "26";
            this.dataGridView1.Rows[index1].Cells[5].Value = "24";
            this.dataGridView1.Rows[index1].Cells[6].Value = "2";
            int index2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index2].Cells[0].Value = "3";
            this.dataGridView1.Rows[index2].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index2].Cells[2].Value = "轴承检修班";
            this.dataGridView1.Rows[index2].Cells[3].Value = "轴承检修";
            this.dataGridView1.Rows[index2].Cells[4].Value = "120";
            this.dataGridView1.Rows[index2].Cells[5].Value = "96";
            this.dataGridView1.Rows[index2].Cells[6].Value = "24";
            int index3 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index3].Cells[0].Value = "4";
            this.dataGridView1.Rows[index3].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index3].Cells[2].Value = "轮轴组装班";
            this.dataGridView1.Rows[index3].Cells[3].Value = "轴箱检修";
            this.dataGridView1.Rows[index3].Cells[4].Value = "48";
            this.dataGridView1.Rows[index3].Cells[5].Value = "48";
            this.dataGridView1.Rows[index3].Cells[6].Value = "0";
            int index4 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index4].Cells[0].Value = "5";
            this.dataGridView1.Rows[index4].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index4].Cells[2].Value = "轮轴组装班";
            this.dataGridView1.Rows[index4].Cells[3].Value = "前盖检修";
            this.dataGridView1.Rows[index4].Cells[4].Value = "70";
            this.dataGridView1.Rows[index4].Cells[5].Value = "48";
            this.dataGridView1.Rows[index4].Cells[6].Value = "22";
            int index5 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index5].Cells[0].Value = "6";
            this.dataGridView1.Rows[index5].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index5].Cells[2].Value = "轴承检修班";
            this.dataGridView1.Rows[index5].Cells[3].Value = "防尘挡圈检修";
            this.dataGridView1.Rows[index5].Cells[4].Value = "58";
            this.dataGridView1.Rows[index5].Cells[5].Value = "48";
            this.dataGridView1.Rows[index5].Cells[6].Value = "10";
            int index6 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index6].Cells[0].Value = "7";
            this.dataGridView1.Rows[index6].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index6].Cells[2].Value = "轮轴组装班";
            this.dataGridView1.Rows[index6].Cells[3].Value = "轮轴组装检修";
            this.dataGridView1.Rows[index6].Cells[4].Value = "24";
            this.dataGridView1.Rows[index6].Cells[5].Value = "24";
            this.dataGridView1.Rows[index6].Cells[6].Value = "0";

            dataGridView1.Rows[0].Selected = false;
        }
        private void UserJXJHJK_Load(object sender, EventArgs e)
        {

            InitDataTable();
            this.Font = new Font("微软雅黑", 10);
            Task.Factory.StartNew(() =>
            {
                while (!cancelltokenSource.IsCancellationRequested)
                {
                   
                    Task.Delay(5000).Wait();
                }
            }, cancelltokenSource.Token);
            timer1.Enabled = true;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetTable();
        }
    }
}
