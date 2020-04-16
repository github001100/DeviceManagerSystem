using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DeviceManagerSystem.TPM
{
    /// <summary>
    /// 轮轴组装各工序完工数量进度监控 
    /// </summary>
    public partial class UserLZZZ : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private static UserLZZZ frm = null;

        public static UserLZZZ CreateInstrance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new UserLZZZ();
            }
            return frm;
        }
        public UserLZZZ()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        public void InitDataTable()
        {
            //列标题居中
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index].Cells[0].Value = "24";
            this.dataGridView2.Rows[index].Cells[1].Value = "24";
            this.dataGridView2.Rows[index].Cells[2].Value = "24";
            this.dataGridView2.Rows[index].Cells[3].Value = "18";
            this.dataGridView2.Rows[index].Cells[4].Value = "2";
            this.dataGridView2.Rows[index].Cells[5].Value = "24";
            this.dataGridView2.Rows[index].Cells[6].Value = "24";
            this.dataGridView2.Rows[index].Cells[7].Value = "24";
            this.dataGridView2.Rows[index].Cells[8].Value = "24";
            dataGridView2.Rows[0].Selected = false;
            //列标题居中
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("微软雅黑", 10);
            dataGridView1.Columns[1].Width = 180;

            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView1.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index11 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index11].Cells[0].Value = "1";
            this.dataGridView1.Rows[index11].Cells[1].Value = "043-17081";
            this.dataGridView1.Rows[index11].Cells[2].Value = "√";
            this.dataGridView1.Rows[index11].Cells[3].Value = "√";
            this.dataGridView1.Rows[index11].Cells[4].Value = "√";
            this.dataGridView1.Rows[index11].Cells[5].Value = "√";
            this.dataGridView1.Rows[index11].Cells[6].Value = "√";
            this.dataGridView1.Rows[index11].Cells[7].Value = "√";
            this.dataGridView1.Rows[index11].Cells[8].Value = "√";
            this.dataGridView1.Rows[index11].Cells[9].Value = "√";
            this.dataGridView1.Rows[index11].Cells[10].Value = "√";
            this.dataGridView1.Rows[index11].Cells[11].Value = "√";
            this.dataGridView1.Rows[index11].Cells[12].Value = "√";
            this.dataGridView1.Rows[index11].Cells[13].Value = "√";
            this.dataGridView1.Rows[index11].Cells[14].Value = "√";
            this.dataGridView1.Rows[index11].Cells[15].Value = "√";
            int index12 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index12].Cells[0].Value = "2";
            this.dataGridView1.Rows[index12].Cells[1].Value = "063-25361";
            this.dataGridView1.Rows[index12].Cells[2].Value = "√";
            this.dataGridView1.Rows[index12].Cells[3].Value = "√";
            this.dataGridView1.Rows[index12].Cells[4].Value = "√";
            this.dataGridView1.Rows[index12].Cells[5].Value = "√";
            this.dataGridView1.Rows[index12].Cells[6].Value = "√";
            this.dataGridView1.Rows[index12].Cells[7].Value = "√";
            this.dataGridView1.Rows[index12].Cells[8].Value = "√";
            this.dataGridView1.Rows[index12].Cells[9].Value = "√";
            this.dataGridView1.Rows[index12].Cells[10].Value = "√";
            this.dataGridView1.Rows[index12].Cells[11].Value = "√";
            this.dataGridView1.Rows[index12].Cells[12].Value = "√";
            this.dataGridView1.Rows[index12].Cells[13].Value = "√";
            this.dataGridView1.Rows[index12].Cells[14].Value = "√";
            this.dataGridView1.Rows[index12].Cells[15].Value = "- ";
            int index13 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index13].Cells[0].Value = "3";
            this.dataGridView1.Rows[index13].Cells[1].Value = "105-34968";
            this.dataGridView1.Rows[index13].Cells[2].Value = "√";
            this.dataGridView1.Rows[index13].Cells[3].Value = "√";
            this.dataGridView1.Rows[index13].Cells[4].Value = "√";
            this.dataGridView1.Rows[index13].Cells[5].Value = "√";
            this.dataGridView1.Rows[index13].Cells[6].Value = "√";
            this.dataGridView1.Rows[index13].Cells[7].Value = "√";
            this.dataGridView1.Rows[index13].Cells[8].Value = "√";
            this.dataGridView1.Rows[index13].Cells[9].Value = "√";
            this.dataGridView1.Rows[index13].Cells[10].Value = "√";
            this.dataGridView1.Rows[index13].Cells[11].Value = "√";
            this.dataGridView1.Rows[index13].Cells[12].Value = "√";
            this.dataGridView1.Rows[index13].Cells[13].Value = "-";
            this.dataGridView1.Rows[index13].Cells[14].Value = "-";
            this.dataGridView1.Rows[index13].Cells[15].Value = "- ";

            int index14 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index14].Cells[0].Value = "4";
            this.dataGridView1.Rows[index14].Cells[1].Value = "114-53421";
            this.dataGridView1.Rows[index14].Cells[2].Value = "√";
            this.dataGridView1.Rows[index14].Cells[3].Value = "√";
            this.dataGridView1.Rows[index14].Cells[4].Value = "√";
            this.dataGridView1.Rows[index14].Cells[5].Value = "√";
            this.dataGridView1.Rows[index14].Cells[6].Value = "√";
            this.dataGridView1.Rows[index14].Cells[7].Value = "√";
            this.dataGridView1.Rows[index14].Cells[8].Value = "√";
            this.dataGridView1.Rows[index14].Cells[9].Value = "√";
            this.dataGridView1.Rows[index14].Cells[10].Value = "√";
            this.dataGridView1.Rows[index14].Cells[11].Value = "√";
            this.dataGridView1.Rows[index14].Cells[12].Value = "-";
            this.dataGridView1.Rows[index14].Cells[13].Value = "-";
            this.dataGridView1.Rows[index14].Cells[14].Value = "-";
            this.dataGridView1.Rows[index14].Cells[15].Value = "- ";

            int index15 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index15].Cells[0].Value = "5";
            this.dataGridView1.Rows[index15].Cells[1].Value = "105-88675";
            this.dataGridView1.Rows[index15].Cells[2].Value = "√";
            this.dataGridView1.Rows[index15].Cells[3].Value = "√";
            this.dataGridView1.Rows[index15].Cells[4].Value = "√";
            this.dataGridView1.Rows[index15].Cells[5].Value = "√";
            this.dataGridView1.Rows[index15].Cells[6].Value = "√";
            this.dataGridView1.Rows[index15].Cells[7].Value = "√";
            this.dataGridView1.Rows[index15].Cells[8].Value = "√";
            this.dataGridView1.Rows[index15].Cells[9].Value = "√";
            this.dataGridView1.Rows[index15].Cells[10].Value = "√";
            this.dataGridView1.Rows[index15].Cells[11].Value = "-";
            this.dataGridView1.Rows[index15].Cells[12].Value = "-";
            this.dataGridView1.Rows[index15].Cells[13].Value = "-";
            this.dataGridView1.Rows[index15].Cells[14].Value = "-";
            this.dataGridView1.Rows[index15].Cells[15].Value = "- ";

            int index16 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index16].Cells[0].Value = "6";
            this.dataGridView1.Rows[index16].Cells[1].Value = "043-25391";
            this.dataGridView1.Rows[index16].Cells[2].Value = "√";
            this.dataGridView1.Rows[index16].Cells[3].Value = "√";
            this.dataGridView1.Rows[index16].Cells[4].Value = "√";
            this.dataGridView1.Rows[index16].Cells[5].Value = "√";
            this.dataGridView1.Rows[index16].Cells[6].Value = "√";
            this.dataGridView1.Rows[index16].Cells[7].Value = "√";
            this.dataGridView1.Rows[index16].Cells[8].Value = "√";
            this.dataGridView1.Rows[index16].Cells[9].Value = "-";
            this.dataGridView1.Rows[index16].Cells[10].Value = "-";
            this.dataGridView1.Rows[index16].Cells[11].Value = "-";
            this.dataGridView1.Rows[index16].Cells[12].Value = "-";
            this.dataGridView1.Rows[index16].Cells[13].Value = "-";
            this.dataGridView1.Rows[index16].Cells[14].Value = "-";
            this.dataGridView1.Rows[index16].Cells[15].Value = "- ";

            //dataGridView1.Rows[index12].DefaultCellStyle.BackColor = Color.LawnGreen;

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
        private void UserLZZZ_Load(object sender, EventArgs e)
        {
            this.groupBox2.Font = new Font("微软雅黑", 10);
            this.groupBox3.Font = new Font("微软雅黑", 10);
            this.groupBox1.Font = new Font("微软雅黑", 10);
            //this.groupBox4.Font = new Font("微软雅黑", 10);

            InitDataTable();
            Thread thread = new Thread(new ThreadStart(new Action(delegate
            {
                while (true)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(500);
                        circleProgramBar1.Progress = i + 1;
                    }
                }

            })));
            thread.IsBackground = true;
            //thread.Start();
            dataGridView1_CellClick(this, null);
        }

        private void UserLZZZ_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = dataGridView1.SelectedRows[0].Index; //获取选中行的行号

            //textBox1.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            if (dataGridView1.CurrentRow == null) return;
            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            string val = dgvr.Cells[1].Value.ToString();//轴号
            textBox1.Text = val;
            switch (dataGridView1.CurrentRow.Index)
            {
                case 0:
                    circleProgramBar1.Progress = 30;
                    break;
                case 1:
                    circleProgramBar1.Progress = 38;
                    break;
                case 2:
                    circleProgramBar1.Progress = 58;
                    break;
                case 3:
                    circleProgramBar1.Progress = 35;
                    break;
                case 4:
                    circleProgramBar1.Progress = 59;
                    break;
                case 5:
                    circleProgramBar1.Progress = 78;
                    break;
                default:
                    circleProgramBar1.Progress = 69;
                    break;
            }
            string val2 = dgvr.Cells[2].Value.ToString();
            string val3 = dgvr.Cells[3].Value.ToString();
            string val4 = dgvr.Cells[4].Value.ToString();
            string val5 = dgvr.Cells[5].Value.ToString();
            string val6 = dgvr.Cells[6].Value.ToString();
            string val7 = dgvr.Cells[7].Value.ToString();
            string val8 = dgvr.Cells[8].Value.ToString();
            string val9 = dgvr.Cells[9].Value.ToString();
            string val10 = dgvr.Cells[10].Value.ToString();
            string val11 = dgvr.Cells[11].Value.ToString();
            string val12 = dgvr.Cells[12].Value.ToString();
            string val13 = dgvr.Cells[13].Value.ToString();
            string val14 = dgvr.Cells[14].Value.ToString();
            string val15 = dgvr.Cells[15].Value.ToString();
            if (val2 == "√")
                label3.BackColor = Color.LimeGreen;

            else
                label3.BackColor = Color.LightGray;
            if (val3 == "√")
                label4.BackColor = Color.LimeGreen;

            else
                label4.BackColor = Color.LightGray; 
            if (val4 == "√")
                label5.BackColor = Color.LimeGreen;

            else
                label5.BackColor = Color.LightGray;
            if (val5 == "√")
                label6.BackColor = Color.LimeGreen;

            else
                label6.BackColor = Color.LightGray;
            if (val6 == "√")
                label7.BackColor = Color.LimeGreen;

            else
                label7.BackColor = Color.LightGray;
            if (val7 == "√")
                label8.BackColor = Color.LimeGreen;

            else
                label8.BackColor = Color.LightGray;
            if (val8 == "√")
                label9.BackColor = Color.LimeGreen;

            else
                label9.BackColor = Color.LightGray;
            if (val9 == "√")
                label10.BackColor = Color.LimeGreen;

            else
                label10.BackColor = Color.LightGray;
            if (val10 == "√")
                label11.BackColor = Color.LimeGreen;

            else
                label11.BackColor = Color.LightGray;
            if (val11 == "√")
                label12.BackColor = Color.LimeGreen;

            else
                label12.BackColor = Color.LightGray;
            if (val12 == "√")
                label13.BackColor = Color.LimeGreen;

            else
                label13.BackColor = Color.LightGray;
            if (val13 == "√")
                label14.BackColor = Color.LimeGreen;

            else
                label14.BackColor = Color.LightGray;
            if (val14 == "√")
                label15.BackColor = Color.LimeGreen;

            else
                label15.BackColor = Color.LightGray;
            if (val15 == "√")
                label16.BackColor = Color.LimeGreen;

            else
                label16.BackColor = Color.LightGray;
           
        }
    }
}
