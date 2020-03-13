namespace DeviceManagerSystem.TPM
{
    partial class UserJXJHXD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.序号1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.组装日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车种车型车号1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支出处所 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.修程1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工作状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进度2 = new DeviceManagerSystem.Others.DataGridViewProgressBarColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收入日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车种车型车号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收入来源 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.修程 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.检修状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.进度 = new System.Windows.Forms.DataGridViewImageColumn();
            this.进度1 = new DeviceManagerSystem.Others.DataGridViewProgressBarColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProgressBarColumn1 = new DeviceManagerSystem.Others.DataGridViewProgressBarColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(1029, 617);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轮轴车间检修作业计划修订";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 362);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1023, 252);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "组装轮轴车辆信息";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号1,
            this.组装日期,
            this.车种车型车号1,
            this.支出处所,
            this.修程1,
            this.工作状态,
            this.进度2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 27);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(1017, 222);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView2_DataError);
            this.dataGridView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView2_DragEnter);
            // 
            // 序号1
            // 
            this.序号1.HeaderText = "序号";
            this.序号1.Name = "序号1";
            this.序号1.ReadOnly = true;
            // 
            // 组装日期
            // 
            this.组装日期.HeaderText = "组装日期";
            this.组装日期.Name = "组装日期";
            this.组装日期.ReadOnly = true;
            // 
            // 车种车型车号1
            // 
            this.车种车型车号1.HeaderText = "车种车型车号";
            this.车种车型车号1.Name = "车种车型车号1";
            this.车种车型车号1.ReadOnly = true;
            // 
            // 支出处所
            // 
            this.支出处所.HeaderText = "支出处所";
            this.支出处所.Name = "支出处所";
            this.支出处所.ReadOnly = true;
            // 
            // 修程1
            // 
            this.修程1.HeaderText = "修程";
            this.修程1.Name = "修程1";
            this.修程1.ReadOnly = true;
            // 
            // 工作状态
            // 
            this.工作状态.HeaderText = "工作状态";
            this.工作状态.Name = "工作状态";
            this.工作状态.ReadOnly = true;
            // 
            // 进度2
            // 
            this.进度2.HeaderText = "进度 ";
            this.进度2.Name = "进度2";
            this.进度2.ReadOnly = true;
            this.进度2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.进度2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1023, 198);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "拆分轮轴车辆信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.收入日期,
            this.车种车型车号,
            this.收入来源,
            this.修程,
            this.检修状态,
            this.进度,
            this.进度1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 168);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 收入日期
            // 
            this.收入日期.HeaderText = "收入日期";
            this.收入日期.Name = "收入日期";
            this.收入日期.ReadOnly = true;
            // 
            // 车种车型车号
            // 
            this.车种车型车号.HeaderText = "车种车型车号";
            this.车种车型车号.Name = "车种车型车号";
            this.车种车型车号.ReadOnly = true;
            // 
            // 收入来源
            // 
            this.收入来源.HeaderText = "收入来源";
            this.收入来源.Name = "收入来源";
            this.收入来源.ReadOnly = true;
            // 
            // 修程
            // 
            this.修程.HeaderText = "修程";
            this.修程.Name = "修程";
            this.修程.ReadOnly = true;
            // 
            // 检修状态
            // 
            this.检修状态.HeaderText = "检修状态";
            this.检修状态.Name = "检修状态";
            this.检修状态.ReadOnly = true;
            // 
            // 进度
            // 
            this.进度.DataPropertyName = "PressImg";
            this.进度.HeaderText = "进度";
            this.进度.Name = "进度";
            this.进度.ReadOnly = true;
            this.进度.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.进度.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.进度.Visible = false;
            // 
            // 进度1
            // 
            this.进度1.DataPropertyName = "Press";
            dataGridViewCellStyle1.NullValue = null;
            this.进度1.DefaultCellStyle = dataGridViewCellStyle1;
            this.进度1.HeaderText = "进度";
            this.进度1.Name = "进度1";
            this.进度1.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1023, 137);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修车计划录入";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 107);
            this.panel1.TabIndex = 0;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "拆分",
            "组装"});
            this.comboBox3.Location = new System.Drawing.Point(709, 37);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(68, 32);
            this.comboBox3.TabIndex = 7;
            this.comboBox3.Text = "拆分";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "A2",
            "A3"});
            this.comboBox2.Location = new System.Drawing.Point(558, 37);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(68, 32);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.Text = "A2";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(409, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(81, 32);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "573";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(913, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(807, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "YW25T35226";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(632, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "模式:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(492, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "修程:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(302, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "收入来源:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "车种车型车号:";
            // 
            // dataGridViewProgressBarColumn1
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewProgressBarColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProgressBarColumn1.HeaderText = "进度1";
            this.dataGridViewProgressBarColumn1.Name = "dataGridViewProgressBarColumn1";
            this.dataGridViewProgressBarColumn1.Width = 122;
            // 
            // UserJXJHXD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserJXJHXD";
            this.Size = new System.Drawing.Size(1029, 617);
            this.Load += new System.EventHandler(this.UserJXJHXD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Others.DataGridViewProgressBarColumn dataGridViewProgressBarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收入日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车种车型车号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收入来源;
        private System.Windows.Forms.DataGridViewTextBoxColumn 修程;
        private System.Windows.Forms.DataGridViewTextBoxColumn 检修状态;
        private System.Windows.Forms.DataGridViewImageColumn 进度;
        private Others.DataGridViewProgressBarColumn 进度1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组装日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车种车型车号1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支出处所;
        private System.Windows.Forms.DataGridViewTextBoxColumn 修程1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工作状态;
        private Others.DataGridViewProgressBarColumn 进度2;
    }
}
