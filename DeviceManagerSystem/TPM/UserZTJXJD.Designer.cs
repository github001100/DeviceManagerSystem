namespace DeviceManagerSystem.TPM
{
    partial class UserZTJXJD
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检修单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.零件名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.任务计划数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.待检修数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合格数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.不合格数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.开工时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合格率 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作时长 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1369, 722);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轮轴车间检修总体进度监控";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox3.Location = new System.Drawing.Point(3, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1363, 478);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检修计划进度监控柱状图";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 30);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "百分比(%)";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1357, 445);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox2.Location = new System.Drawing.Point(3, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1363, 209);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "检修进度计划监控表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LawnGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 55;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.检修单位,
            this.工序,
            this.零件名称,
            this.任务计划数,
            this.待检修数,
            this.合格数,
            this.不合格数,
            this.开工时间,
            this.合格率,
            this.工作时长});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 42;
            this.dataGridView1.Size = new System.Drawing.Size(1357, 176);
            this.dataGridView1.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.MinimumWidth = 6;
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 检修单位
            // 
            this.检修单位.HeaderText = "检修单位";
            this.检修单位.MinimumWidth = 6;
            this.检修单位.Name = "检修单位";
            this.检修单位.ReadOnly = true;
            // 
            // 工序
            // 
            this.工序.HeaderText = "工序";
            this.工序.MinimumWidth = 6;
            this.工序.Name = "工序";
            this.工序.ReadOnly = true;
            // 
            // 零件名称
            // 
            this.零件名称.HeaderText = "零件名称";
            this.零件名称.MinimumWidth = 6;
            this.零件名称.Name = "零件名称";
            this.零件名称.ReadOnly = true;
            // 
            // 任务计划数
            // 
            this.任务计划数.HeaderText = "任务计划数";
            this.任务计划数.MinimumWidth = 6;
            this.任务计划数.Name = "任务计划数";
            this.任务计划数.ReadOnly = true;
            // 
            // 待检修数
            // 
            this.待检修数.HeaderText = "待检修数";
            this.待检修数.MinimumWidth = 6;
            this.待检修数.Name = "待检修数";
            this.待检修数.ReadOnly = true;
            // 
            // 合格数
            // 
            this.合格数.HeaderText = "合格数";
            this.合格数.MinimumWidth = 6;
            this.合格数.Name = "合格数";
            this.合格数.ReadOnly = true;
            // 
            // 不合格数
            // 
            this.不合格数.HeaderText = "不合格数";
            this.不合格数.MinimumWidth = 6;
            this.不合格数.Name = "不合格数";
            this.不合格数.ReadOnly = true;
            // 
            // 开工时间
            // 
            this.开工时间.HeaderText = "开工时间";
            this.开工时间.MinimumWidth = 6;
            this.开工时间.Name = "开工时间";
            this.开工时间.ReadOnly = true;
            // 
            // 合格率
            // 
            this.合格率.HeaderText = "合格率";
            this.合格率.MinimumWidth = 6;
            this.合格率.Name = "合格率";
            this.合格率.ReadOnly = true;
            // 
            // 工作时长
            // 
            this.工作时长.HeaderText = "工作时长";
            this.工作时长.MinimumWidth = 6;
            this.工作时长.Name = "工作时长";
            this.工作时长.ReadOnly = true;
            // 
            // UserZTJXJD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserZTJXJD";
            this.Size = new System.Drawing.Size(1369, 722);
            this.Load += new System.EventHandler(this.UserZTJXJD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序;
        private System.Windows.Forms.DataGridViewTextBoxColumn 零件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 任务计划数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 待检修数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合格数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 不合格数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 开工时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合格率;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作时长;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
