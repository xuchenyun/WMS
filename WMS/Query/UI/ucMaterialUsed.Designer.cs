namespace Query.UI
{
    partial class ucMaterialUsed
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
            this.PLName = new System.Windows.Forms.Label();
            this.txt_workStationSN = new System.Windows.Forms.TextBox();
            this.workSN = new System.Windows.Forms.Label();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_ProductCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_wocode = new System.Windows.Forms.TextBox();
            this.WoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFCNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARTNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbo_PLName = new CIT.Client.TXComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialUsed)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_PLName);
            this.panel1.Controls.Add(this.txt_wocode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PLName);
            this.panel1.Controls.Add(this.txt_workStationSN);
            this.panel1.Controls.Add(this.workSN);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 140);
            this.panel1.TabIndex = 0;
            // 
            // PLName
            // 
            this.PLName.AutoSize = true;
            this.PLName.Location = new System.Drawing.Point(281, 60);
            this.PLName.Name = "PLName";
            this.PLName.Size = new System.Drawing.Size(29, 12);
            this.PLName.TabIndex = 141;
            this.PLName.Text = "线别";
            // 
            // txt_workStationSN
            // 
            this.txt_workStationSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workStationSN.Location = new System.Drawing.Point(567, 55);
            this.txt_workStationSN.Name = "txt_workStationSN";
            this.txt_workStationSN.Size = new System.Drawing.Size(175, 26);
            this.txt_workStationSN.TabIndex = 140;
            // 
            // workSN
            // 
            this.workSN.AutoSize = true;
            this.workSN.Location = new System.Drawing.Point(520, 62);
            this.workSN.Name = "workSN";
            this.workSN.Size = new System.Drawing.Size(41, 12);
            this.workSN.TabIndex = 139;
            this.workSN.Text = "工位SN";
            // 
            // txt_serialNumber
            // 
            this.txt_serialNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_serialNumber.Location = new System.Drawing.Point(567, 13);
            this.txt_serialNumber.Name = "txt_serialNumber";
            this.txt_serialNumber.Size = new System.Drawing.Size(175, 26);
            this.txt_serialNumber.TabIndex = 138;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 137;
            this.label2.Text = "产品条码";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(522, 95);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 23);
            this.btn_query.TabIndex = 136;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 135;
            this.label5.Text = "--";
            // 
            // txt_workTimeMax
            // 
            this.txt_workTimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workTimeMax.Location = new System.Drawing.Point(319, 92);
            this.txt_workTimeMax.Name = "txt_workTimeMax";
            this.txt_workTimeMax.Size = new System.Drawing.Size(147, 26);
            this.txt_workTimeMax.TabIndex = 134;
            // 
            // dtp_workTimeMax
            // 
            this.dtp_workTimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_workTimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_workTimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_workTimeMax.Location = new System.Drawing.Point(319, 92);
            this.dtp_workTimeMax.Name = "dtp_workTimeMax";
            this.dtp_workTimeMax.Size = new System.Drawing.Size(175, 26);
            this.dtp_workTimeMax.TabIndex = 133;
            this.dtp_workTimeMax.CloseUp += new System.EventHandler(this.dtp_workTimeMax_CloseUp);
            // 
            // txt_workTimeMin
            // 
            this.txt_workTimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workTimeMin.Location = new System.Drawing.Point(82, 92);
            this.txt_workTimeMin.Name = "txt_workTimeMin";
            this.txt_workTimeMin.Size = new System.Drawing.Size(147, 26);
            this.txt_workTimeMin.TabIndex = 132;
            // 
            // dtp_workTimeMin
            // 
            this.dtp_workTimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_workTimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_workTimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_workTimeMin.Location = new System.Drawing.Point(82, 92);
            this.dtp_workTimeMin.Name = "dtp_workTimeMin";
            this.dtp_workTimeMin.Size = new System.Drawing.Size(175, 26);
            this.dtp_workTimeMin.TabIndex = 131;
            this.dtp_workTimeMin.CloseUp += new System.EventHandler(this.dtp_workTimeMin_CloseUp);
            // 
            // workTimeMin
            // 
            this.workTimeMin.AutoSize = true;
            this.workTimeMin.Location = new System.Drawing.Point(14, 101);
            this.workTimeMin.Name = "workTimeMin";
            this.workTimeMin.Size = new System.Drawing.Size(53, 12);
            this.workTimeMin.TabIndex = 130;
            this.workTimeMin.Text = "作业时间";
            // 
            // txt_partSN
            // 
            this.txt_partSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_partSN.Location = new System.Drawing.Point(82, 53);
            this.txt_partSN.Name = "txt_partSN";
            this.txt_partSN.Size = new System.Drawing.Size(175, 26);
            this.txt_partSN.TabIndex = 129;
            // 
            // materialNumber
            // 
            this.materialNumber.AutoSize = true;
            this.materialNumber.Location = new System.Drawing.Point(16, 60);
            this.materialNumber.Name = "materialNumber";
            this.materialNumber.Size = new System.Drawing.Size(53, 12);
            this.materialNumber.TabIndex = 128;
            this.materialNumber.Text = "物料条码";
            // 
            // txt_sfcNo
            // 
            this.txt_sfcNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sfcNo.Location = new System.Drawing.Point(316, 13);
            this.txt_sfcNo.Name = "txt_sfcNo";
            this.txt_sfcNo.Size = new System.Drawing.Size(175, 26);
            this.txt_sfcNo.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 124;
            this.label1.Text = "制令单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_materialUsed);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 331);
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
            this.Column3,
            this.Column10,
            this.PARTNUMBER,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Step,
            this.Column8,
            this.Column9,
            this.Column11});
            this.dgv_materialUsed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_materialUsed.Location = new System.Drawing.Point(0, 0);
            this.dgv_materialUsed.Name = "dgv_materialUsed";
            this.dgv_materialUsed.RowHeadersVisible = false;
            this.dgv_materialUsed.RowTemplate.Height = 23;
            this.dgv_materialUsed.Size = new System.Drawing.Size(1072, 290);
            this.dgv_materialUsed.TabIndex = 0;
            this.dgv_materialUsed.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_materialUsed_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_ProductCount);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 290);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1072, 41);
            this.panel3.TabIndex = 1;
            // 
            // lbl_ProductCount
            // 
            this.lbl_ProductCount.AutoSize = true;
            this.lbl_ProductCount.Font = new System.Drawing.Font("宋体", 15F);
            this.lbl_ProductCount.ForeColor = System.Drawing.Color.Red;
            this.lbl_ProductCount.Location = new System.Drawing.Point(118, 11);
            this.lbl_ProductCount.Name = "lbl_ProductCount";
            this.lbl_ProductCount.Size = new System.Drawing.Size(19, 20);
            this.lbl_ProductCount.TabIndex = 126;
            this.lbl_ProductCount.Text = "0";
            this.lbl_ProductCount.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 125;
            this.label3.Text = "产品数量：";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 143;
            this.label4.Text = "工单";
            // 
            // txt_wocode
            // 
            this.txt_wocode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_wocode.Location = new System.Drawing.Point(82, 13);
            this.txt_wocode.Name = "txt_wocode";
            this.txt_wocode.Size = new System.Drawing.Size(175, 26);
            this.txt_wocode.TabIndex = 144;
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
            // Column3
            // 
            this.Column3.DataPropertyName = "SERIALNUMBER";
            this.Column3.HeaderText = "产品条码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "PARTNUMBER";
            this.Column10.HeaderText = "料号";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // PARTNUMBER
            // 
            this.PARTNUMBER.DataPropertyName = "PART_SN";
            this.PARTNUMBER.HeaderText = "物料条码";
            this.PARTNUMBER.Name = "PARTNUMBER";
            this.PARTNUMBER.ReadOnly = true;
            this.PARTNUMBER.Width = 120;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "WORKSTATION_SN";
            this.Column4.HeaderText = "工位SN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "WORKSTATION_NAME";
            this.Column5.HeaderText = "工位名称";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PLName";
            this.Column6.HeaderText = "线别";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Step
            // 
            this.Step.DataPropertyName = "Step";
            this.Step.HeaderText = "阶别";
            this.Step.Name = "Step";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "QTY";
            this.Column8.HeaderText = "数量";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "CREATOR";
            this.Column9.HeaderText = "作业人";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "CREATE_TIME";
            this.Column11.HeaderText = "作业时间";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 120;
            // 
            // cbo_PLName
            // 
            this.cbo_PLName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_PLName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_PLName.FormattingEnabled = true;
            this.cbo_PLName.Location = new System.Drawing.Point(317, 55);
            this.cbo_PLName.Name = "cbo_PLName";
            this.cbo_PLName.Size = new System.Drawing.Size(175, 24);
            this.cbo_PLName.TabIndex = 111;
            // 
            // ucMaterialUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMaterialUsed";
            this.Size = new System.Drawing.Size(1072, 471);
            this.Load += new System.EventHandler(this.ucMaterialUsed_Load);
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
        private System.Windows.Forms.Label PLName;
        private System.Windows.Forms.TextBox txt_workStationSN;
        private System.Windows.Forms.Label workSN;
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
        private System.Windows.Forms.TextBox txt_wocode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn WoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFCNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARTNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Step;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private CIT.Client.TXComboBox cbo_PLName;
    }
}
