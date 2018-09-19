namespace Query.UI
{
    partial class ucFixtureUsed
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Wocode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_serialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_workTimeMax = new System.Windows.Forms.TextBox();
            this.dtp_workTimeMax = new System.Windows.Forms.DateTimePicker();
            this.txt_workTimeMin = new System.Windows.Forms.TextBox();
            this.dtp_workTimeMin = new System.Windows.Forms.DateTimePicker();
            this.workTimeMin = new System.Windows.Forms.Label();
            this.txt_partSN = new System.Windows.Forms.TextBox();
            this.materialNumber = new System.Windows.Forms.Label();
            this.txt_sfcNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_materialUsed = new System.Windows.Forms.DataGridView();
            this.WoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFCNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIALNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIXTURE_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_ProductCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialUsed)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Wocode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_serialNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_workTimeMax);
            this.panel1.Controls.Add(this.dtp_workTimeMax);
            this.panel1.Controls.Add(this.txt_workTimeMin);
            this.panel1.Controls.Add(this.dtp_workTimeMin);
            this.panel1.Controls.Add(this.workTimeMin);
            this.panel1.Controls.Add(this.txt_partSN);
            this.panel1.Controls.Add(this.materialNumber);
            this.panel1.Controls.Add(this.txt_sfcNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1608, 136);
            this.panel1.TabIndex = 0;
            // 
            // txt_Wocode
            // 
            this.txt_Wocode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Wocode.Location = new System.Drawing.Point(90, 75);
            this.txt_Wocode.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Wocode.Name = "txt_Wocode";
            this.txt_Wocode.Size = new System.Drawing.Size(260, 35);
            this.txt_Wocode.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 139;
            this.label4.Text = "工单";
            // 
            // txt_serialNumber
            // 
            this.txt_serialNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_serialNumber.Location = new System.Drawing.Point(444, 20);
            this.txt_serialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txt_serialNumber.Name = "txt_serialNumber";
            this.txt_serialNumber.Size = new System.Drawing.Size(260, 35);
            this.txt_serialNumber.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 137;
            this.label2.Text = "产品条码";
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(1070, 76);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(110, 34);
            this.btn_query.TabIndex = 136;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 135;
            this.label5.Text = "--";
            // 
            // txt_workTimeMax
            // 
            this.txt_workTimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workTimeMax.Location = new System.Drawing.Point(802, 76);
            this.txt_workTimeMax.Margin = new System.Windows.Forms.Padding(4);
            this.txt_workTimeMax.Name = "txt_workTimeMax";
            this.txt_workTimeMax.Size = new System.Drawing.Size(218, 35);
            this.txt_workTimeMax.TabIndex = 134;
            // 
            // dtp_workTimeMax
            // 
            this.dtp_workTimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_workTimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_workTimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_workTimeMax.Location = new System.Drawing.Point(802, 76);
            this.dtp_workTimeMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_workTimeMax.Name = "dtp_workTimeMax";
            this.dtp_workTimeMax.Size = new System.Drawing.Size(260, 35);
            this.dtp_workTimeMax.TabIndex = 133;
            this.dtp_workTimeMax.CloseUp += new System.EventHandler(this.dtp_workTimeMax_CloseUp);
            // 
            // txt_workTimeMin
            // 
            this.txt_workTimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workTimeMin.Location = new System.Drawing.Point(444, 76);
            this.txt_workTimeMin.Margin = new System.Windows.Forms.Padding(4);
            this.txt_workTimeMin.Name = "txt_workTimeMin";
            this.txt_workTimeMin.Size = new System.Drawing.Size(218, 35);
            this.txt_workTimeMin.TabIndex = 132;
            // 
            // dtp_workTimeMin
            // 
            this.dtp_workTimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_workTimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_workTimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_workTimeMin.Location = new System.Drawing.Point(444, 76);
            this.dtp_workTimeMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_workTimeMin.Name = "dtp_workTimeMin";
            this.dtp_workTimeMin.Size = new System.Drawing.Size(260, 35);
            this.dtp_workTimeMin.TabIndex = 131;
            this.dtp_workTimeMin.CloseUp += new System.EventHandler(this.dtp_workTimeMin_CloseUp);
            // 
            // workTimeMin
            // 
            this.workTimeMin.AutoSize = true;
            this.workTimeMin.Location = new System.Drawing.Point(362, 85);
            this.workTimeMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workTimeMin.Name = "workTimeMin";
            this.workTimeMin.Size = new System.Drawing.Size(80, 18);
            this.workTimeMin.TabIndex = 130;
            this.workTimeMin.Text = "作业时间";
            // 
            // txt_partSN
            // 
            this.txt_partSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_partSN.Location = new System.Drawing.Point(798, 20);
            this.txt_partSN.Margin = new System.Windows.Forms.Padding(4);
            this.txt_partSN.Name = "txt_partSN";
            this.txt_partSN.Size = new System.Drawing.Size(260, 35);
            this.txt_partSN.TabIndex = 129;
            // 
            // materialNumber
            // 
            this.materialNumber.AutoSize = true;
            this.materialNumber.Location = new System.Drawing.Point(712, 30);
            this.materialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialNumber.Name = "materialNumber";
            this.materialNumber.Size = new System.Drawing.Size(80, 18);
            this.materialNumber.TabIndex = 128;
            this.materialNumber.Text = "治具条码";
            // 
            // txt_sfcNo
            // 
            this.txt_sfcNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sfcNo.Location = new System.Drawing.Point(90, 20);
            this.txt_sfcNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sfcNo.Name = "txt_sfcNo";
            this.txt_sfcNo.Size = new System.Drawing.Size(260, 35);
            this.txt_sfcNo.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 124;
            this.label1.Text = "制令单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_materialUsed);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 136);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1608, 571);
            this.panel2.TabIndex = 1;
            // 
            // dgv_materialUsed
            // 
            this.dgv_materialUsed.AllowUserToAddRows = false;
            this.dgv_materialUsed.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_materialUsed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materialUsed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WoCode,
            this.SFCNO,
            this.SERIALNUMBER,
            this.FIXTURE_SN,
            this.CREATE_TIME});
            this.dgv_materialUsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_materialUsed.Location = new System.Drawing.Point(0, 0);
            this.dgv_materialUsed.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_materialUsed.Name = "dgv_materialUsed";
            this.dgv_materialUsed.RowHeadersVisible = false;
            this.dgv_materialUsed.RowTemplate.Height = 23;
            this.dgv_materialUsed.Size = new System.Drawing.Size(1608, 510);
            this.dgv_materialUsed.TabIndex = 0;
            this.dgv_materialUsed.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_materialUsed_MouseDoubleClick);
            // 
            // WoCode
            // 
            this.WoCode.DataPropertyName = "WoCode";
            this.WoCode.HeaderText = "工单";
            this.WoCode.Name = "WoCode";
            this.WoCode.ReadOnly = true;
            // 
            // SFCNO
            // 
            this.SFCNO.DataPropertyName = "SFCNO";
            this.SFCNO.HeaderText = "制令单";
            this.SFCNO.Name = "SFCNO";
            this.SFCNO.ReadOnly = true;
            // 
            // SERIALNUMBER
            // 
            this.SERIALNUMBER.DataPropertyName = "SERIALNUMBER";
            this.SERIALNUMBER.HeaderText = "产品条码";
            this.SERIALNUMBER.Name = "SERIALNUMBER";
            this.SERIALNUMBER.ReadOnly = true;
            this.SERIALNUMBER.Width = 120;
            // 
            // FIXTURE_SN
            // 
            this.FIXTURE_SN.DataPropertyName = "FIXTURE_SN";
            this.FIXTURE_SN.HeaderText = "治具条码";
            this.FIXTURE_SN.Name = "FIXTURE_SN";
            this.FIXTURE_SN.ReadOnly = true;
            this.FIXTURE_SN.Width = 120;
            // 
            // CREATE_TIME
            // 
            this.CREATE_TIME.DataPropertyName = "CREATE_TIME";
            this.CREATE_TIME.HeaderText = "作业时间";
            this.CREATE_TIME.Name = "CREATE_TIME";
            this.CREATE_TIME.ReadOnly = true;
            this.CREATE_TIME.Width = 120;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_ProductCount);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 510);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1608, 61);
            this.panel3.TabIndex = 1;
            // 
            // lbl_ProductCount
            // 
            this.lbl_ProductCount.AutoSize = true;
            this.lbl_ProductCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lbl_ProductCount.ForeColor = System.Drawing.Color.Red;
            this.lbl_ProductCount.Location = new System.Drawing.Point(177, 16);
            this.lbl_ProductCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ProductCount.Name = "lbl_ProductCount";
            this.lbl_ProductCount.Size = new System.Drawing.Size(28, 30);
            this.lbl_ProductCount.TabIndex = 126;
            this.lbl_ProductCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(28, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 30);
            this.label3.TabIndex = 125;
            this.label3.Text = "产品数量：";
            this.label3.Visible = false;
            // 
            // ucFixtureUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucFixtureUsed";
            this.Size = new System.Drawing.Size(1608, 707);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialUsed)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_serialNumber;
        private System.Windows.Forms.Label label2;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_workTimeMax;
        private System.Windows.Forms.DateTimePicker dtp_workTimeMax;
        private System.Windows.Forms.TextBox txt_workTimeMin;
        private System.Windows.Forms.DateTimePicker dtp_workTimeMin;
        private System.Windows.Forms.Label workTimeMin;
        private System.Windows.Forms.TextBox txt_partSN;
        private System.Windows.Forms.Label materialNumber;
        private System.Windows.Forms.TextBox txt_sfcNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_materialUsed;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_ProductCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn WoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFCNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIALNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIXTURE_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_TIME;
        private System.Windows.Forms.TextBox txt_Wocode;
        private System.Windows.Forms.Label label4;
    }
}
