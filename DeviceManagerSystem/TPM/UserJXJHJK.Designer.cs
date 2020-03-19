namespace DeviceManagerSystem.TPM
{
    partial class UserJXJHJK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检修日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工班组 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检修工序 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.任务计划 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检修数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新增数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 760);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轮轴车间检修计划监控";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox2.Location = new System.Drawing.Point(3, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1142, 727);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检修任务计划监控表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeight = 55;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.检修日期,
            this.工班组,
            this.检修工序,
            this.任务计划,
            this.检修数量,
            this.新增数量});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 55;
            this.dataGridView1.Size = new System.Drawing.Size(1136, 694);
            this.dataGridView1.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.MinimumWidth = 6;
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 检修日期
            // 
            this.检修日期.HeaderText = "检修日期";
            this.检修日期.MinimumWidth = 6;
            this.检修日期.Name = "检修日期";
            this.检修日期.ReadOnly = true;
            // 
            // 工班组
            // 
            this.工班组.HeaderText = "工班组";
            this.工班组.MinimumWidth = 6;
            this.工班组.Name = "工班组";
            this.工班组.ReadOnly = true;
            // 
            // 检修工序
            // 
            this.检修工序.HeaderText = "检修工序";
            this.检修工序.MinimumWidth = 6;
            this.检修工序.Name = "检修工序";
            this.检修工序.ReadOnly = true;
            // 
            // 任务计划
            // 
            this.任务计划.HeaderText = "任务计划";
            this.任务计划.MinimumWidth = 6;
            this.任务计划.Name = "任务计划";
            this.任务计划.ReadOnly = true;
            // 
            // 检修数量
            // 
            this.检修数量.HeaderText = "检修数量";
            this.检修数量.MinimumWidth = 6;
            this.检修数量.Name = "检修数量";
            this.检修数量.ReadOnly = true;
            // 
            // 新增数量
            // 
            this.新增数量.HeaderText = "新增数量";
            this.新增数量.MinimumWidth = 6;
            this.新增数量.Name = "新增数量";
            this.新增数量.ReadOnly = true;
            // 
            // UserJXJHJK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "UserJXJHJK";
            this.Size = new System.Drawing.Size(1148, 760);
            this.Load += new System.EventHandler(this.UserJXJHJK_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工班组;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修工序;
        private System.Windows.Forms.DataGridViewTextBoxColumn 任务计划;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新增数量;
    }
}
