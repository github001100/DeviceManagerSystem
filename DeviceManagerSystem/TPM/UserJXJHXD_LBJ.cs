using CMES.Controller.SYS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeviceManagerSystem.TPM
{
    public partial class UserJXJHXD_LBJ : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        ZtjkController ztjk = new ZtjkController();//整体检修 业务逻辑2.0
        private static UserJXJHXD_LBJ frm = null;

        public static UserJXJHXD_LBJ CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new UserJXJHXD_LBJ();
            }
            return frm;
        }
        public UserJXJHXD_LBJ()
        {
            InitializeComponent();
            //asc.controllInitializeSize(this);
            foreach (Control gbox in groupBox1.Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Tag = gbox.Location.Y;
            }
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
        }
        string jsonStr2 = "";
        public void SetTable(DataGridView dgv, string ProcedureName, string PartsName)
        {
            try
            {
                //轮轴检修计划表
                //JObject jsonobj2 = null;
                jsonStr2 = ztjk.GetZtjkInfoByProcedureNameToJson(ProcedureName, PartsName);
                JObject o2 = JObject.Parse(jsonStr2);
                JArray json2 = (JArray)o2["data"];
                //ds = JsonToDataSet("date:{"+ json2 + "}");
                dynamic model = JsonConvert.DeserializeObject(jsonStr2);
                //this.dataGridView1.DataSource = null;
                dgv.DataSource = model.data;

                dgv.Refresh();
                dgv.Update();
                dgv.EndEdit();
                //DataTable dt = new DataTable();
                //this.dataGridView1.DataSource = ds.Tables["ds"];

                //RefreshList();
            }
            catch (Exception ex)
            {
                //timer1.Enabled = false;
                Console.WriteLine(ex.Message);
                //throw;
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
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[0].Value = "轮对";
            this.dataGridView1.Rows[index].Cells[1].Value = "2020/02/20";
            this.dataGridView1.Rows[index].Cells[2].Value = "24";
            this.dataGridView1.Rows[index].Cells[3].Value = "24";
            this.dataGridView1.Rows[index].Cells[4].Value = "0";
            this.dataGridView1.Rows[index].Cells[5].Value = "";

            //列标题居中
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView2.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index1 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index1].Cells[0].Value = "轴承";
            this.dataGridView2.Rows[index1].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index1].Cells[2].Value = "24";
            this.dataGridView2.Rows[index1].Cells[3].Value = "24";
            this.dataGridView2.Rows[index1].Cells[4].Value = "0";
            this.dataGridView2.Rows[index1].Cells[5].Value = "";
            //列标题居中
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView3.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView3.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index2 = this.dataGridView3.Rows.Add();
            this.dataGridView3.Rows[index2].Cells[0].Value = "轴箱";
            this.dataGridView3.Rows[index2].Cells[1].Value = "2020/02/20";
            this.dataGridView3.Rows[index2].Cells[2].Value = "24";
            this.dataGridView3.Rows[index2].Cells[3].Value = "24";
            this.dataGridView3.Rows[index2].Cells[4].Value = "0";
            this.dataGridView3.Rows[index2].Cells[5].Value = "";
            //列标题居中
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView4.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView4.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index3 = this.dataGridView4.Rows.Add();
            this.dataGridView4.Rows[index3].Cells[0].Value = "防尘挡圈";
            this.dataGridView4.Rows[index3].Cells[1].Value = "2020/02/20";
            this.dataGridView4.Rows[index3].Cells[2].Value = "24";
            this.dataGridView4.Rows[index3].Cells[3].Value = "24";
            this.dataGridView4.Rows[index3].Cells[4].Value = "0";
            this.dataGridView4.Rows[index3].Cells[5].Value = "";
            //列标题居中
            dataGridView5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView5.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView5.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index4 = this.dataGridView5.Rows.Add();
            this.dataGridView5.Rows[index4].Cells[0].Value = "前盖";
            this.dataGridView5.Rows[index4].Cells[1].Value = "2020/02/20";
            this.dataGridView5.Rows[index4].Cells[2].Value = "24";
            this.dataGridView5.Rows[index4].Cells[3].Value = "24";
            this.dataGridView5.Rows[index4].Cells[4].Value = "0";
            this.dataGridView5.Rows[index4].Cells[5].Value = "";
            dataGridView1.Rows[0].Selected = false;
            dataGridView2.Rows[0].Selected = false;
            dataGridView3.Rows[0].Selected = false;
            dataGridView4.Rows[0].Selected = false;
            dataGridView5.Rows[0].Selected = false;
            //列标题居中
            dataGridView6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView6.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView6.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            dataGridView7.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView7.EnableHeadersVisualStyles = false;
            dataGridView7.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            dataGridView7.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView7.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
        }
        private void UserJXJHXD_LBJ_Load(object sender, EventArgs e)
        {
            InitDataTable();
            //this.Font = new Font("微软雅黑", 12);
            this.groupBox1.Font = new Font("微软雅黑", 10);
            this.groupBox2.Font = new Font("微软雅黑", 10);
            this.groupBox3.Font = new Font("微软雅黑", 10);
            this.groupBox4.Font = new Font("微软雅黑", 10);
            this.groupBox5.Font = new Font("微软雅黑", 10);
            timer1.Enabled = true;
        }

        private void UserJXJHXD_LBJ_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SysVar.lz_SN_1 = textBox1.Text.Trim();
            ztjk.UpdateZtjkInfoByProcedureNameToJson("轮对检修", "轮对", textBox1.Text, textBox2.Text,
                "" + (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text))
                , DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
            JObject o2 = JObject.Parse(jsonStr2);
            JArray json2 = (JArray)o2["data"];
            //ds = JsonToDataSet("date:{"+ json2 + "}");
            dynamic model = JsonConvert.DeserializeObject(jsonStr2);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control gbox in groupBox1.Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Location = new Point(gbox.Location.X, (int)gbox.Tag - e.NewValue);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ztjk.UpdateZtjkInfoByProcedureNameToJson("轴承检修", "轴承", textBox3.Text, textBox4.Text,
                "" + (Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox4.Text))
                , DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ztjk.UpdateZtjkInfoByProcedureNameToJson("零部件检修", "轴箱", textBox6.Text, textBox5.Text,
                "" + (Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox6.Text))
                 , DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ztjk.UpdateZtjkInfoByProcedureNameToJson("零部件检修", "防尘挡圈", textBox8.Text, textBox7.Text,
                "" + (Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox8.Text))
                , DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ztjk.UpdateZtjkInfoByProcedureNameToJson("零部件检修", "前盖", textBox10.Text, textBox9.Text,
                "" + (Convert.ToInt32(textBox10.Text) + Convert.ToInt32(textBox9.Text))
                 , DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetTable(this.dataGridView1, "轮对检修", "轮对");
            SetTable(this.dataGridView2, "轴承检修", "轴承");
            SetTable(this.dataGridView3, "零部件检修", "轴箱");
            SetTable(this.dataGridView4, "零部件检修", "防尘挡圈");
            SetTable(this.dataGridView5, "零部件检修", "前盖");
            SetTable(this.dataGridView6, "轮轴拆分", "轮轴");
            SetTable(this.dataGridView7, "轮轴组装", "轮轴");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ztjk.UpdateZtjkInfoByProcedureNameToJson("轮轴拆分", "轮轴", textBox12.Text, textBox11.Text,
                "" + (Convert.ToInt32(textBox11.Text) + Convert.ToInt32(textBox12.Text)), DateTime.Now.ToShortDateString()
                , DateTime.Now.ToLongTimeString());

        }

        private void button14_Click(object sender, EventArgs e)
        {
            ztjk.UpdateZtjkInfoByProcedureNameToJson("轮轴组装", "轮轴", textBox14.Text, textBox13.Text,
                "" + (Convert.ToInt32(textBox13.Text) + Convert.ToInt32(textBox14.Text))
                 , DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        //public override Font Font
        //{
        //    get
        //    {
        //        return base.Font;
        //    }
        //    set
        //    {
        //        foreach (Control var in base.Controls)
        //        {
        //            SetControlFont(var, value);
        //        }

        //        base.Font = value;
        //    }
        //}
        //private void SetControlFont(Control c, Font f)
        //{
        //    c.Font = f;
        //    if (c.Controls.Count > 0)
        //    {
        //        foreach (Control var in c.Controls)
        //        {
        //            SetControlFont(var, f);

        //        }
        //    }
        //}
    }
}
