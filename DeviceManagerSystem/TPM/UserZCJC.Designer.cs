﻿namespace DeviceManagerSystem.TPM
{
    partial class UserZCJC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴承编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新旧轴承 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴承厂家 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴承打码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴承除锈 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.外观检查 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.滚子探伤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.内圈探伤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.外圈探伤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴承清洗 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.尺寸测量1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.尺寸测量2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.轴承入库 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.选配出库 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1166, 688);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轴承车间轴承检修进度监控";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox4.Location = new System.Drawing.Point(3, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1160, 453);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "轴承检修各工序数量监控";
            // 
            // chart1
            // 
            chartArea4.AxisX.Interval = 1D;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.Title = "工序名称";
            chartArea4.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.Crimson;
            chartArea4.AxisY.Title = "完成数量(套)";
            chartArea4.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea4.AxisY.TitleForeColor = System.Drawing.Color.Brown;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(3, 30);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "工序";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1154, 420);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox3.Location = new System.Drawing.Point(3, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1160, 156);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "轴承进度计划监控表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Chartreuse;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.轴承编号,
            this.新旧轴承,
            this.轴承厂家,
            this.轴承打码,
            this.轴承除锈,
            this.外观检查,
            this.滚子探伤,
            this.内圈探伤,
            this.外圈探伤,
            this.轴承清洗,
            this.尺寸测量1,
            this.尺寸测量2,
            this.轴承入库,
            this.选配出库});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 39;
            this.dataGridView1.Size = new System.Drawing.Size(1154, 123);
            this.dataGridView1.TabIndex = 0;
            // 
            // 序号
            // 
            this.序号.FillWeight = 101.2601F;
            this.序号.HeaderText = "序号";
            this.序号.MinimumWidth = 6;
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 轴承编号
            // 
            this.轴承编号.FillWeight = 101.0229F;
            this.轴承编号.HeaderText = "轴承编号";
            this.轴承编号.MinimumWidth = 6;
            this.轴承编号.Name = "轴承编号";
            this.轴承编号.ReadOnly = true;
            // 
            // 新旧轴承
            // 
            this.新旧轴承.FillWeight = 100.8017F;
            this.新旧轴承.HeaderText = "新旧轴承";
            this.新旧轴承.MinimumWidth = 6;
            this.新旧轴承.Name = "新旧轴承";
            this.新旧轴承.ReadOnly = true;
            // 
            // 轴承厂家
            // 
            this.轴承厂家.FillWeight = 100.5954F;
            this.轴承厂家.HeaderText = "轴承厂家";
            this.轴承厂家.MinimumWidth = 6;
            this.轴承厂家.Name = "轴承厂家";
            this.轴承厂家.ReadOnly = true;
            // 
            // 轴承打码
            // 
            this.轴承打码.FillWeight = 100.403F;
            this.轴承打码.HeaderText = "轴承打码";
            this.轴承打码.MinimumWidth = 6;
            this.轴承打码.Name = "轴承打码";
            this.轴承打码.ReadOnly = true;
            // 
            // 轴承除锈
            // 
            this.轴承除锈.FillWeight = 100.2237F;
            this.轴承除锈.HeaderText = "轴承除锈";
            this.轴承除锈.MinimumWidth = 6;
            this.轴承除锈.Name = "轴承除锈";
            this.轴承除锈.ReadOnly = true;
            // 
            // 外观检查
            // 
            this.外观检查.FillWeight = 100.0564F;
            this.外观检查.HeaderText = "外观检查";
            this.外观检查.MinimumWidth = 6;
            this.外观检查.Name = "外观检查";
            this.外观检查.ReadOnly = true;
            // 
            // 滚子探伤
            // 
            this.滚子探伤.FillWeight = 99.90042F;
            this.滚子探伤.HeaderText = "滚子探伤";
            this.滚子探伤.MinimumWidth = 6;
            this.滚子探伤.Name = "滚子探伤";
            this.滚子探伤.ReadOnly = true;
            // 
            // 内圈探伤
            // 
            this.内圈探伤.FillWeight = 99.75497F;
            this.内圈探伤.HeaderText = "内圈探伤";
            this.内圈探伤.MinimumWidth = 6;
            this.内圈探伤.Name = "内圈探伤";
            this.内圈探伤.ReadOnly = true;
            // 
            // 外圈探伤
            // 
            this.外圈探伤.FillWeight = 99.61935F;
            this.外圈探伤.HeaderText = "外圈探伤";
            this.外圈探伤.MinimumWidth = 6;
            this.外圈探伤.Name = "外圈探伤";
            this.外圈探伤.ReadOnly = true;
            // 
            // 轴承清洗
            // 
            this.轴承清洗.FillWeight = 99.49289F;
            this.轴承清洗.HeaderText = "轴承清洗";
            this.轴承清洗.MinimumWidth = 6;
            this.轴承清洗.Name = "轴承清洗";
            this.轴承清洗.ReadOnly = true;
            // 
            // 尺寸测量1
            // 
            this.尺寸测量1.FillWeight = 99.37495F;
            this.尺寸测量1.HeaderText = "尺寸测量1";
            this.尺寸测量1.MinimumWidth = 6;
            this.尺寸测量1.Name = "尺寸测量1";
            this.尺寸测量1.ReadOnly = true;
            // 
            // 尺寸测量2
            // 
            this.尺寸测量2.FillWeight = 99.26498F;
            this.尺寸测量2.HeaderText = "尺寸测量2";
            this.尺寸测量2.MinimumWidth = 6;
            this.尺寸测量2.Name = "尺寸测量2";
            this.尺寸测量2.ReadOnly = true;
            // 
            // 轴承入库
            // 
            this.轴承入库.FillWeight = 99.16243F;
            this.轴承入库.HeaderText = "轴承入库";
            this.轴承入库.MinimumWidth = 6;
            this.轴承入库.Name = "轴承入库";
            this.轴承入库.ReadOnly = true;
            // 
            // 选配出库
            // 
            this.选配出库.FillWeight = 99.06682F;
            this.选配出库.HeaderText = "选配出库";
            this.选配出库.MinimumWidth = 6;
            this.选配出库.Name = "选配出库";
            this.选配出库.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1160, 49);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轴承检修计划";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(885, 16);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(82, 34);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "56.9%";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(695, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(82, 34);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "10";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(502, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(82, 34);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "102";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(312, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(82, 34);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "98";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(124, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(82, 34);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "112";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(791, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "整体进度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "不合格数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "合格数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "待检数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "日检修计划";
            // 
            // UserZCJC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "UserZCJC";
            this.Size = new System.Drawing.Size(1166, 688);
            this.Load += new System.EventHandler(this.UserZCJC_Load);
            this.SizeChanged += new System.EventHandler(this.UserZCJC_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴承编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新旧轴承;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴承厂家;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴承打码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴承除锈;
        private System.Windows.Forms.DataGridViewTextBoxColumn 外观检查;
        private System.Windows.Forms.DataGridViewTextBoxColumn 滚子探伤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 内圈探伤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 外圈探伤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴承清洗;
        private System.Windows.Forms.DataGridViewTextBoxColumn 尺寸测量1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 尺寸测量2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 轴承入库;
        private System.Windows.Forms.DataGridViewTextBoxColumn 选配出库;
    }
}
