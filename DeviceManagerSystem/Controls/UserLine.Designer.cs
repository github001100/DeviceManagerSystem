namespace DeviceManagerSystem.Controls
{
    partial class UserLine
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
            this.lineBlue1 = new DeviceManagerSystem.LineBlue();
            this.SuspendLayout();
            // 
            // lineBlue1
            // 
            this.lineBlue1.Location = new System.Drawing.Point(32, 15);
            this.lineBlue1.Name = "lineBlue1";
            this.lineBlue1.Size = new System.Drawing.Size(205, 61);
            this.lineBlue1.TabIndex = 0;
            // 
            // UserLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineBlue1);
            this.Name = "UserLine";
            this.Size = new System.Drawing.Size(289, 128);
            this.ResumeLayout(false);

        }

        #endregion

        private LineBlue lineBlue1;

    }
}
