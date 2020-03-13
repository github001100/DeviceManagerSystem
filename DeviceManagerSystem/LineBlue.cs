using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceManagerSystem
{
    public partial class LineBlue : UserControl
    {
        private Color lineColor = Color.Black;
        private int lineHeight = 1;
        public LineBlue()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //e.Graphics.DrawLine(new Pen(lineColor), 1, 1, this.Width, lineHeight);

            Pen p = new Pen(Color.Blue, 5);
            Graphics g = this.CreateGraphics(); //this.CreateGraphics();
            //DrawArrow(g, p, 50, 20, 100, 20);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//恢复实线
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;//定义线尾的样式为箭头
            g.DrawLine(p, 10, 30, 200, 30);
            p.Dispose();
            g.Dispose();
        }
    }
}
