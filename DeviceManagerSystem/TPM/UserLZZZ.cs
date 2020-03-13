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
    public partial class UserLZZZ : UserControl
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

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
            this.dataGridView1.Rows[index14].Cells[12].Value = "√";
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
            this.dataGridView1.Rows[index15].Cells[11].Value = "√";
            this.dataGridView1.Rows[index15].Cells[12].Value = "√";
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
            this.dataGridView1.Rows[index16].Cells[9].Value = "√";
            this.dataGridView1.Rows[index16].Cells[10].Value = "√";
            this.dataGridView1.Rows[index16].Cells[11].Value = "√";
            this.dataGridView1.Rows[index16].Cells[12].Value = "√";
            this.dataGridView1.Rows[index16].Cells[13].Value = "-";
            this.dataGridView1.Rows[index16].Cells[14].Value = "-";
            this.dataGridView1.Rows[index16].Cells[15].Value = "- ";

            dataGridView1.Rows[0].Selected = false;
            //dataGridView1.Rows[index12].DefaultCellStyle.BackColor = Color.LawnGreen;

        }
        private void UserLZZZ_Load(object sender, EventArgs e)
        {
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
            thread.Start();
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
            string val = dgvr.Cells[1].Value.ToString();
            textBox1.Text = val;
        }
    }
}
