namespace DeviceManagerSystem
{
    partial class Model
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel11 = new System.Windows.Forms.Panel();
            this.myCircle26 = new DeviceManagerSystem.MyCircle();
            this.label58 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.myCircle26);
            this.panel11.Controls.Add(this.label58);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(80, 89);
            this.panel11.TabIndex = 87;
            // 
            // myCircle26
            // 
            this.myCircle26.BorderColor = System.Drawing.Color.YellowGreen;
            this.myCircle26.BorderTransparent = 255;
            this.myCircle26.BorderWidth = 0;
            this.myCircle26.ButtonCenterColorEnd = System.Drawing.Color.YellowGreen;
            this.myCircle26.ButtonCenterColorStart = System.Drawing.Color.YellowGreen;
            this.myCircle26.DistanceToBorder = 4;
            this.myCircle26.IsShowIcon = false;
            this.myCircle26.Location = new System.Drawing.Point(40, 35);
            this.myCircle26.Name = "myCircle26";
            this.myCircle26.Size = new System.Drawing.Size(30, 41);
            this.myCircle26.TabIndex = 1;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(3, 54);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(44, 26);
            this.label58.TabIndex = 0;
            this.label58.Text = "04#";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "端盖清洗";
            // 
            // Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel11);
            this.Name = "Model";
            this.Size = new System.Drawing.Size(80, 89);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private MyCircle myCircle26;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label1;
    }
}
