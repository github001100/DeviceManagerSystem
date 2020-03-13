using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManagerSystem
{
    public partial class MainForm : Form
    {
        //1.声明自适应类实例  
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private string display = "false";
        public MainForm()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (display == "false")
            {
                display = "true";
                panel1.Visible = true;

            }
            else
            {
                display = "false";

                panel1.Visible = false;

            }
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.AliceBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.White;

        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.AliceBlue;

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.White;

        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Color.AliceBlue;

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.White;

        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = Color.AliceBlue;

        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.White;

        }

    }
}
