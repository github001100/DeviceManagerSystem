using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManagerSystem.TPM
{
    public partial class UserJXJHXD_LBJ : UserControl
    {
        public UserJXJHXD_LBJ()
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
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
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
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView2.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index1 = this.dataGridView2.Rows.Add();
            this.dataGridView2.Rows[index1].Cells[0].Value = "轮对";
            this.dataGridView2.Rows[index].Cells[1].Value = "2020/02/20";
            this.dataGridView2.Rows[index1].Cells[2].Value = "24";
            this.dataGridView2.Rows[index1].Cells[3].Value = "24";
            this.dataGridView2.Rows[index1].Cells[4].Value = "0";
            this.dataGridView2.Rows[index1].Cells[5].Value = "";
            //列标题居中
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView3.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index2 = this.dataGridView3.Rows.Add();
            this.dataGridView3.Rows[index2].Cells[0].Value = "轮对";
            this.dataGridView3.Rows[index2].Cells[1].Value = "2020/02/20";
            this.dataGridView3.Rows[index2].Cells[2].Value = "24";
            this.dataGridView3.Rows[index2].Cells[3].Value = "24";
            this.dataGridView3.Rows[index2].Cells[4].Value = "0";
            this.dataGridView3.Rows[index2].Cells[5].Value = "";
            //列标题居中
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView4.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index3 = this.dataGridView4.Rows.Add();
            this.dataGridView4.Rows[index3].Cells[0].Value = "轮对";
            this.dataGridView4.Rows[index3].Cells[1].Value = "2020/02/20";
            this.dataGridView4.Rows[index3].Cells[2].Value = "24";
            this.dataGridView4.Rows[index3].Cells[3].Value = "24";
            this.dataGridView4.Rows[index3].Cells[4].Value = "0";
            this.dataGridView4.Rows[index3].Cells[5].Value = "";
            //列标题居中
            dataGridView5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.Turquoise;
            //单元格内容居中
            foreach (DataGridViewColumn item in this.dataGridView5.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;//列标题右边有预留一个排序小箭头的位置，所以整个列标题就向左边多一点，而当把SortMode属性设置为NotSortable时，不使用排序，也就没有那个预留的位置，所有完全居中了

            }
            int index4 = this.dataGridView5.Rows.Add();
            this.dataGridView5.Rows[index4].Cells[0].Value = "轮对";
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


        }
        private void UserJXJHXD_LBJ_Load(object sender, EventArgs e)
        {
            InitDataTable();
        }
    }
}
