namespace DeviceManagerSystem.TPM
{
    partial class UserLBJJXJD
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.circleProgramBar = new DeviceManagerSystem.Controls.CircleProgramBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.检修项目2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.除锈清洗 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.二维码喷码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.外观检查 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.尺寸测量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入库 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.检修项目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检修任务计划量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.待检修数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合格品数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.不合品数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.合格率 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1363, 745);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轮轴车间轮轴零部件检修进度监控";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.circleProgramBar);
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox4.Location = new System.Drawing.Point(3, 394);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1357, 348);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "轮轴零部件检修各工序数量监控";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1052, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "整体进度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // circleProgramBar
            // 
            this.circleProgramBar.BackColor = System.Drawing.Color.White;
            this.circleProgramBar.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circleProgramBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.circleProgramBar.FinishedColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.circleProgramBar.Font = new System.Drawing.Font("微软雅黑", 24F);
            this.circleProgramBar.Location = new System.Drawing.Point(1052, 30);
            this.circleProgramBar.MaxValue = 100;
            this.circleProgramBar.Name = "circleProgramBar";
            this.circleProgramBar.Progress = 50;
            this.circleProgramBar.Size = new System.Drawing.Size(302, 286);
            this.circleProgramBar.TabIndex = 1;
            this.circleProgramBar.Text = "circleProgramBar1";
            this.circleProgramBar.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.Title = "工序名称";
            chartArea1.AxisY.Title = "完工数量";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 30);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "合格数";
            series1.YValuesPerPoint = 6;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "不合格";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1049, 315);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox3.Location = new System.Drawing.Point(3, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1357, 183);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "轮轴零部件各工序检修进度监控表";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.检修项目2,
            this.除锈清洗,
            this.二维码喷码,
            this.外观检查,
            this.尺寸测量,
            this.入库});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 30);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(1351, 150);
            this.dataGridView2.TabIndex = 0;
            // 
            // 检修项目2
            // 
            this.检修项目2.HeaderText = "检修项目";
            this.检修项目2.Name = "检修项目2";
            this.检修项目2.ReadOnly = true;
            // 
            // 除锈清洗
            // 
            this.除锈清洗.HeaderText = "除锈清洗";
            this.除锈清洗.Name = "除锈清洗";
            this.除锈清洗.ReadOnly = true;
            // 
            // 二维码喷码
            // 
            this.二维码喷码.HeaderText = "二维码喷码";
            this.二维码喷码.Name = "二维码喷码";
            this.二维码喷码.ReadOnly = true;
            // 
            // 外观检查
            // 
            this.外观检查.HeaderText = "外观检查";
            this.外观检查.Name = "外观检查";
            this.外观检查.ReadOnly = true;
            // 
            // 尺寸测量
            // 
            this.尺寸测量.HeaderText = "尺寸测量";
            this.尺寸测量.Name = "尺寸测量";
            this.尺寸测量.ReadOnly = true;
            // 
            // 入库
            // 
            this.入库.HeaderText = "入库";
            this.入库.Name = "入库";
            this.入库.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox2.Location = new System.Drawing.Point(3, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1357, 188);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轮轴零部件检修进度整体监控表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.检修项目,
            this.检修任务计划量,
            this.待检修数,
            this.合格品数,
            this.不合品数,
            this.合格率});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1351, 155);
            this.dataGridView1.TabIndex = 0;
            // 
            // 检修项目
            // 
            this.检修项目.HeaderText = "检修项目";
            this.检修项目.Name = "检修项目";
            this.检修项目.ReadOnly = true;
            // 
            // 检修任务计划量
            // 
            this.检修任务计划量.HeaderText = "检修任务计划量";
            this.检修任务计划量.Name = "检修任务计划量";
            this.检修任务计划量.ReadOnly = true;
            // 
            // 待检修数
            // 
            this.待检修数.HeaderText = "待检修数";
            this.待检修数.Name = "待检修数";
            this.待检修数.ReadOnly = true;
            // 
            // 合格品数
            // 
            this.合格品数.HeaderText = "合格品数";
            this.合格品数.Name = "合格品数";
            this.合格品数.ReadOnly = true;
            // 
            // 不合品数
            // 
            this.不合品数.HeaderText = "不合品数";
            this.不合品数.Name = "不合品数";
            this.不合品数.ReadOnly = true;
            // 
            // 合格率
            // 
            this.合格率.HeaderText = "合格率";
            this.合格率.Name = "合格率";
            this.合格率.ReadOnly = true;
            // 
            // UserLBJJXJD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserLBJJXJD";
            this.Size = new System.Drawing.Size(1363, 745);
            this.Load += new System.EventHandler(this.UserLBJJXJD_Load);
            this.SizeChanged += new System.EventHandler(this.UserLBJJXJD_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修项目;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修任务计划量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 待检修数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合格品数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 不合品数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 合格率;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修项目2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 除锈清洗;
        private System.Windows.Forms.DataGridViewTextBoxColumn 二维码喷码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 外观检查;
        private System.Windows.Forms.DataGridViewTextBoxColumn 尺寸测量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入库;
        private Controls.CircleProgramBar circleProgramBar;
        private System.Windows.Forms.Label label1;
    }
}
