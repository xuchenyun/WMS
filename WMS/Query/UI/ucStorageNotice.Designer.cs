namespace Query.UI
{
    partial class ucStorageNotice
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
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_TimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeMin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PartNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txButton2 = new CIT.Client.TXButton();
            this.txButton1 = new CIT.Client.TXButton();
            this.btn_query = new CIT.Client.TXButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_barCode = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txButton3 = new CIT.Client.TXButton();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 189;
            this.label5.Text = "～";
            // 
            // dtp_TimeMax
            // 
            this.dtp_TimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMax.Location = new System.Drawing.Point(634, 12);
            this.dtp_TimeMax.Name = "dtp_TimeMax";
            this.dtp_TimeMax.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMax.TabIndex = 188;
            // 
            // dtp_TimeMin
            // 
            this.dtp_TimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMin.Location = new System.Drawing.Point(483, 12);
            this.dtp_TimeMin.Name = "dtp_TimeMin";
            this.dtp_TimeMin.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMin.TabIndex = 187;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 186;
            this.label4.Text = "时间";
            // 
            // txt_PartNumber
            // 
            this.txt_PartNumber.Location = new System.Drawing.Point(270, 17);
            this.txt_PartNumber.Name = "txt_PartNumber";
            this.txt_PartNumber.Size = new System.Drawing.Size(147, 21);
            this.txt_PartNumber.TabIndex = 185;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 184;
            this.label2.Text = "料号";
            // 
            // txt_BillNo
            // 
            this.txt_BillNo.Location = new System.Drawing.Point(63, 17);
            this.txt_BillNo.Name = "txt_BillNo";
            this.txt_BillNo.Size = new System.Drawing.Size(147, 21);
            this.txt_BillNo.TabIndex = 183;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 182;
            this.label1.Text = "单据号";
            // 
            // txButton2
            // 
            this.txButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txButton2.Image = null;
            this.txButton2.Location = new System.Drawing.Point(124, 87);
            this.txButton2.Name = "txButton2";
            this.txButton2.Size = new System.Drawing.Size(108, 27);
            this.txButton2.TabIndex = 192;
            this.txButton2.Text = "打印批次清单";
            this.txButton2.UseVisualStyleBackColor = true;
            // 
            // txButton1
            // 
            this.txButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txButton1.Image = null;
            this.txButton1.Location = new System.Drawing.Point(18, 87);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(100, 27);
            this.txButton1.TabIndex = 191;
            this.txButton1.Text = "收货完成";
            this.txButton1.UseVisualStyleBackColor = true;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(803, 14);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 190;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 193;
            this.label3.Text = "单据信息";
            // 
            // dgv_barCode
            // 
            this.dgv_barCode.AllowUserToAddRows = false;
            this.dgv_barCode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_barCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_barCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.No,
            this.BillType,
            this.Column1,
            this.InstockNo,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Creator,
            this.CreateTime,
            this.Status,
            this.Column5});
            this.dgv_barCode.Location = new System.Drawing.Point(18, 138);
            this.dgv_barCode.Name = "dgv_barCode";
            this.dgv_barCode.RowHeadersVisible = false;
            this.dgv_barCode.RowTemplate.Height = 23;
            this.dgv_barCode.Size = new System.Drawing.Size(1156, 184);
            this.dgv_barCode.TabIndex = 194;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 195;
            this.label6.Text = "物料信息";
            // 
            // txButton3
            // 
            this.txButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txButton3.Image = null;
            this.txButton3.Location = new System.Drawing.Point(18, 393);
            this.txButton3.Name = "txButton3";
            this.txButton3.Size = new System.Drawing.Size(100, 27);
            this.txButton3.TabIndex = 196;
            this.txButton3.Text = "收货信息录入";
            this.txButton3.UseVisualStyleBackColor = true;
            // 
            // checkbox
            // 
            this.checkbox.HeaderText = "";
            this.checkbox.Name = "checkbox";
            this.checkbox.Width = 50;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "单据号";
            this.No.Name = "No";
            // 
            // BillType
            // 
            this.BillType.DataPropertyName = "BillType";
            this.BillType.HeaderText = "单据类型";
            this.BillType.Name = "BillType";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "供应商编号";
            this.Column1.Name = "Column1";
            // 
            // InstockNo
            // 
            this.InstockNo.DataPropertyName = "InstockNo";
            this.InstockNo.HeaderText = "相关单号";
            this.InstockNo.Name = "InstockNo";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ERP采购单";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "采购人";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "采购部门";
            this.Column4.Name = "Column4";
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "创建人";
            this.Creator.Name = "Creator";
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "备注";
            this.Column5.Name = "Column5";
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.Column11,
            this.Column12,
            this.Column6});
            this.dataGridView3.Location = new System.Drawing.Point(18, 451);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(908, 150);
            this.dataGridView3.TabIndex = 197;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "行";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "物料编号";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "物料名称";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "是否IQC";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "是否允许超收";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "计划数";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "包装";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "未收数";
            this.Column12.Name = "Column12";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "备注";
            this.Column6.Name = "Column6";
            // 
            // ucRecipientConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.txButton3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgv_barCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txButton2);
            this.Controls.Add(this.txButton1);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp_TimeMax);
            this.Controls.Add(this.dtp_TimeMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_PartNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_BillNo);
            this.Controls.Add(this.label1);
            this.Name = "ucRecipientConfirm";
            this.Size = new System.Drawing.Size(1201, 733);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_TimeMax;
        private System.Windows.Forms.DateTimePicker dtp_TimeMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_PartNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BillNo;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton txButton2;
        private CIT.Client.TXButton txButton1;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_barCode;
        private System.Windows.Forms.Label label6;
        private CIT.Client.TXButton txButton3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
