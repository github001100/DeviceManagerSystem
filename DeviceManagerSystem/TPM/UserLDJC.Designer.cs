namespace DeviceManagerSystem.TPM
{
    partial class UserLDJC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收入 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.磁粉探伤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.微机探 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轮轴超探 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.镟修 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轮辋超探 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.动平衡检测 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支出测量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入库 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支出 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1205, 689);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轮轴车间轮对检修进度监控";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 328);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1199, 358);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "043-11061轮对检修工序流程监控";
            // 
            // chart1
            // 
            chartArea8.AxisX.Interval = 1D;
            chartArea8.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea8.AxisX.Title = "工序名称";
            chartArea8.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea8.AxisX.TitleForeColor = System.Drawing.Color.Crimson;
            chartArea8.AxisY.Title = "完成数量(套)";
            chartArea8.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea8.AxisY.TitleForeColor = System.Drawing.Color.Brown;
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(3, 27);
            this.chart1.Name = "chart1";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "工序";
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(1193, 328);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1199, 216);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "轮对进度计划监控表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.轴号,
            this.轴型,
            this.收入,
            this.磁粉探伤,
            this.微机探,
            this.轮轴超探,
            this.镟修,
            this.轮辋超探,
            this.动平衡检测,
            this.支出测量,
            this.入库,
            this.支出});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 39;
            this.dataGridView1.Size = new System.Drawing.Size(1193, 186);
            this.dataGridView1.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.MinimumWidth = 6;
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 轴号
            // 
            this.轴号.HeaderText = "轴号";
            this.轴号.MinimumWidth = 6;
            this.轴号.Name = "轴号";
            this.轴号.ReadOnly = true;
            // 
            // 轴型
            // 
            this.轴型.HeaderText = "轴型";
            this.轴型.MinimumWidth = 6;
            this.轴型.Name = "轴型";
            this.轴型.ReadOnly = true;
            // 
            // 收入
            // 
            this.收入.HeaderText = "收入";
            this.收入.MinimumWidth = 6;
            this.收入.Name = "收入";
            this.收入.ReadOnly = true;
            // 
            // 磁粉探伤
            // 
            this.磁粉探伤.HeaderText = "磁粉探伤";
            this.磁粉探伤.MinimumWidth = 6;
            this.磁粉探伤.Name = "磁粉探伤";
            this.磁粉探伤.ReadOnly = true;
            // 
            // 微机探
            // 
            this.微机探.HeaderText = "微机探";
            this.微机探.MinimumWidth = 6;
            this.微机探.Name = "微机探";
            this.微机探.ReadOnly = true;
            // 
            // 轮轴超探
            // 
            this.轮轴超探.HeaderText = "轮轴超探";
            this.轮轴超探.MinimumWidth = 6;
            this.轮轴超探.Name = "轮轴超探";
            this.轮轴超探.ReadOnly = true;
            // 
            // 镟修
            // 
            this.镟修.HeaderText = "镟修";
            this.镟修.MinimumWidth = 6;
            this.镟修.Name = "镟修";
            this.镟修.ReadOnly = true;
            // 
            // 轮辋超探
            // 
            this.轮辋超探.HeaderText = "轮辋超探";
            this.轮辋超探.MinimumWidth = 6;
            this.轮辋超探.Name = "轮辋超探";
            this.轮辋超探.ReadOnly = true;
            // 
            // 动平衡检测
            // 
            this.动平衡检测.HeaderText = "动平衡检测";
            this.动平衡检测.MinimumWidth = 6;
            this.动平衡检测.Name = "动平衡检测";
            this.动平衡检测.ReadOnly = true;
            // 
            // 支出测量
            // 
            this.支出测量.HeaderText = "支出测量";
            this.支出测量.MinimumWidth = 6;
            this.支出测量.Name = "支出测量";
            this.支出测量.ReadOnly = true;
            // 
            // 入库
            // 
            this.入库.HeaderText = "入库";
            this.入库.MinimumWidth = 6;
            this.入库.Name = "入库";
            this.入库.ReadOnly = true;
            // 
            // 支出
            // 
            this.支出.HeaderText = "支出";
            this.支出.MinimumWidth = 6;
            this.支出.Name = "支出";
            this.支出.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1199, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轮对检修计划";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 55);
            this.panel1.TabIndex = 0;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1091, 16);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 31);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "33.3%";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(855, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 31);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "1";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(623, 15);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 31);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "7";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(390, 15);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 31);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "16";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "24";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(994, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "整体进度:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(758, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "不合格数:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(537, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "合格数:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(316, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "待检数:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "日检修计划数:";
            // 
            // UserLDJC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserLDJC";
            this.Size = new System.Drawing.Size(1205, 689);
            this.Load += new System.EventHandler(this.UserLDJC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收入;
        private System.Windows.Forms.DataGridViewTextBoxColumn 磁粉探伤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 微机探;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轮轴超探;
        private System.Windows.Forms.DataGridViewTextBoxColumn 镟修;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轮辋超探;
        private System.Windows.Forms.DataGridViewTextBoxColumn 动平衡检测;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支出测量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入库;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支出;
    }
}
