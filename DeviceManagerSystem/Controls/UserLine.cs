using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DeviceManagerSystem.Controls
{

    public partial class UserLine : UserControl
    {
        public UserLine()
        {
            InitializeComponent();
            starPointF = new PointF(0, this.Height / 2);
            endPointF = new PointF(this.Width / 8 * 5, this.Height / 2);
            triangleSize = new Size(10, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Red, starPointF, endPointF);

            //这是按照水平向左的方向画图的 ,现在要实现的是任意角度，关键的是p1,p2,p3坐标怎么算的呢， 
            //看着真的很简单，高中知识，可是我现在解二元二次方程， 搞的我头都大了，还是不能用starPointF，endPointF，triangleSize来表示。

            PointF p1 = new PointF(endPointF.X, endPointF.Y - triangleSize.Height / 2);
            PointF p2 = new PointF(endPointF.X, endPointF.Y + triangleSize.Height / 2);
            PointF p3 = new PointF(endPointF.X + triangleSize.Width, endPointF.Y);

            Brush brush = new SolidBrush(Color.Red);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(p1, p2);
            path.AddLine(p2, p3);
            path.AddLine(p3, p1);
            g.FillPath(brush, path);
        }

        PointF starPointF = new PointF(0, 0);
        PointF endPointF = new PointF(0, 0);

        public PointF StarPointF
        {
            get { return starPointF; }
            set { starPointF = value; }
        }

        public PointF EndPointF
        {
            get { return endPointF; }
            set { endPointF = value; }
        }

        SizeF triangleSize;
        /// <summary>
        /// 三角形大小 ，这个是等腰三角形， 宽度表示定点到底边的距离， 高表示底边的长度
        /// </summary>
        public SizeF TriangleSize
        {
            get { return triangleSize; }
            set
            {
                if (triangleSize != value)
                {
                    triangleSize = value;
                    base.Invalidate();
                }
            }
        }

    }

}
