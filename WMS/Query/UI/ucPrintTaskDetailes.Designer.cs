namespace Query.UI
{
    partial class ucPrintTaskDetailes
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
            this.btn_query = new CIT.Client.TXButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_TimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeMin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PartNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txButton1 = new CIT.Client.TXButton();
            this.dgv_barCode = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(817, 19);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 208;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 207;
            this.label5.Text = "～";
            // 
            // dtp_TimeMax
            // 
            this.dtp_TimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMax.Location = new System.Drawing.Point(648, 17);
            this.dtp_TimeMax.Name = "dtp_TimeMax";
            this.dtp_TimeMax.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMax.TabIndex = 206;
            // 
            // dtp_TimeMin
            // 
            this.dtp_TimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMin.Location = new System.Drawing.Point(497, 17);
            this.dtp_TimeMin.Name = "dtp_TimeMin";
            this.dtp_TimeMin.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMin.TabIndex = 205;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 204;
            this.label4.Text = "时间";
            // 
            // txt_PartNumber
            // 
            this.txt_PartNumber.Location = new System.Drawing.Point(284, 22);
            this.txt_PartNumber.Name = "txt_PartNumber";
            this.txt_PartNumber.Size = new System.Drawing.Size(147, 21);
            this.txt_PartNumber.TabIndex = 203;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 202;
            this.label2.Text = "料号";
            // 
            // txt_BillNo
            // 
            this.txt_BillNo.Location = new System.Drawing.Point(77, 22);
            this.txt_BillNo.Name = "txt_BillNo";
            this.txt_BillNo.Size = new System.Drawing.Size(147, 21);
            this.txt_BillNo.TabIndex = 201;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 200;
            this.label1.Text = "单据号";
            // 
            // txButton1
            // 
            this.txButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txButton1.Image = null;
            this.txButton1.Location = new System.Drawing.Point(32, 69);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(81, 27);
            this.txButton1.TabIndex = 209;
            this.txButton1.Text = "标签打印";
            this.txButton1.UseVisualStyleBackColor = true;
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
            this.dgv_barCode.Location = new System.Drawing.Point(32, 114);
            this.dgv_barCode.Name = "dgv_barCode";
            this.dgv_barCode.RowHeadersVisible = false;
            this.dgv_barCode.RowTemplate.Height = 23;
            this.dgv_barCode.Size = new System.Drawing.Size(1153, 396);
            this.dgv_barCode.TabIndex = 210;
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
            this.No.HeaderText = "采购单号";
            this.No.Name = "No";
            // 
            // BillType
            // 
            this.BillType.DataPropertyName = "BillType";
            this.BillType.HeaderText = "行号";
            this.BillType.Name = "BillType";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "收货人";
            this.Column1.Name = "Column1";
            // 
            // InstockNo
            // 
            this.InstockNo.DataPropertyName = "InstockNo";
            this.InstockNo.HeaderText = "料号";
            this.InstockNo.Name = "InstockNo";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "入库时间";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "DateCode";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "生产Lot ";
            this.Column4.Name = "Column4";
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "批号";
            this.Creator.Name = "Creator";
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "数量";
            this.CreateTime.Name = "CreateTime";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "库存单位";
            this.Status.Name = "Status";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "打印数量";
            this.Column5.Name = "Column5";
            // 
            // ucPrintTaskDetailes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_barCode);
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
            this.Name = "ucPrintTaskDetailes";
            this.Size = new System.Drawing.Size(1209, 634);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_TimeMax;
        private System.Windows.Forms.DateTimePicker dtp_TimeMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_PartNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BillNo;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton txButton1;
        private System.Windows.Forms.DataGridView dgv_barCode;
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
    }
}
