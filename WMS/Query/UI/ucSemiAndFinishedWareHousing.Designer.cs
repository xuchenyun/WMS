namespace Query.UI
{
    partial class ucSemiAndFinishedWareHousing
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
            this.cbo_BillType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_InstockNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_TimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeMin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_barCode = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_InStockRows = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_InStockRowDetails = new System.Windows.Forms.DataGridView();
            this.btn_query = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InStockRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InStockRowDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo_BillType
            // 
            this.cbo_BillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_BillType.FormattingEnabled = true;
            this.cbo_BillType.Location = new System.Drawing.Point(300, 35);
            this.cbo_BillType.Name = "cbo_BillType";
            this.cbo_BillType.Size = new System.Drawing.Size(145, 20);
            this.cbo_BillType.TabIndex = 168;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(693, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 165;
            this.label4.Text = "时间";
            // 
            // txt_InstockNo
            // 
            this.txt_InstockNo.Location = new System.Drawing.Point(520, 35);
            this.txt_InstockNo.Name = "txt_InstockNo";
            this.txt_InstockNo.Size = new System.Drawing.Size(147, 21);
            this.txt_InstockNo.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 163;
            this.label3.Text = "单据类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 162;
            this.label2.Text = "入库单号";
            // 
            // txt_BillNo
            // 
            this.txt_BillNo.Location = new System.Drawing.Point(77, 34);
            this.txt_BillNo.Name = "txt_BillNo";
            this.txt_BillNo.Size = new System.Drawing.Size(147, 21);
            this.txt_BillNo.TabIndex = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 160;
            this.label1.Text = "单据号";
            // 
            // dtp_TimeMax
            // 
            this.dtp_TimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMax.Location = new System.Drawing.Point(879, 32);
            this.dtp_TimeMax.Name = "dtp_TimeMax";
            this.dtp_TimeMax.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMax.TabIndex = 172;
            // 
            // dtp_TimeMin
            // 
            this.dtp_TimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMin.Location = new System.Drawing.Point(728, 32);
            this.dtp_TimeMin.Name = "dtp_TimeMin";
            this.dtp_TimeMin.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMin.TabIndex = 171;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 173;
            this.label5.Text = "～";
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
            this.Creator,
            this.CreateTime,
            this.InstockNo,
            this.Status});
            this.dgv_barCode.Location = new System.Drawing.Point(32, 88);
            this.dgv_barCode.Name = "dgv_barCode";
            this.dgv_barCode.RowHeadersVisible = false;
            this.dgv_barCode.RowTemplate.Height = 23;
            this.dgv_barCode.Size = new System.Drawing.Size(657, 130);
            this.dgv_barCode.TabIndex = 175;
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
            // InstockNo
            // 
            this.InstockNo.DataPropertyName = "InstockNo";
            this.InstockNo.HeaderText = "入库单号";
            this.InstockNo.Name = "InstockNo";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            // 
            // dgv_InStockRows
            // 
            this.dgv_InStockRows.AllowUserToAddRows = false;
            this.dgv_InStockRows.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_InStockRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InStockRows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.PartNumber,
            this.PlanQty,
            this.Row,
            this.RealQty,
            this.Unit});
            this.dgv_InStockRows.Location = new System.Drawing.Point(705, 88);
            this.dgv_InStockRows.Name = "dgv_InStockRows";
            this.dgv_InStockRows.RowHeadersVisible = false;
            this.dgv_InStockRows.RowTemplate.Height = 23;
            this.dgv_InStockRows.Size = new System.Drawing.Size(605, 128);
            this.dgv_InStockRows.TabIndex = 176;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "No";
            this.dataGridViewTextBoxColumn1.HeaderText = "单据号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // PartNumber
            // 
            this.PartNumber.DataPropertyName = "PartNumber";
            this.PartNumber.HeaderText = "料号";
            this.PartNumber.Name = "PartNumber";
            // 
            // PlanQty
            // 
            this.PlanQty.DataPropertyName = "PlanQty";
            this.PlanQty.HeaderText = "计划数量";
            this.PlanQty.Name = "PlanQty";
            // 
            // Row
            // 
            this.Row.DataPropertyName = "Row";
            this.Row.HeaderText = "行";
            this.Row.Name = "Row";
            // 
            // RealQty
            // 
            this.RealQty.DataPropertyName = "RealQty";
            this.RealQty.HeaderText = "收货数";
            this.RealQty.Name = "RealQty";
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "库存单位";
            this.Unit.Name = "Unit";
            // 
            // dgv_InStockRowDetails
            // 
            this.dgv_InStockRowDetails.AllowUserToAddRows = false;
            this.dgv_InStockRowDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_InStockRowDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InStockRowDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.LotNo,
            this.BoxNo});
            this.dgv_InStockRowDetails.Location = new System.Drawing.Point(32, 253);
            this.dgv_InStockRowDetails.Name = "dgv_InStockRowDetails";
            this.dgv_InStockRowDetails.RowHeadersVisible = false;
            this.dgv_InStockRowDetails.RowTemplate.Height = 23;
            this.dgv_InStockRowDetails.Size = new System.Drawing.Size(1278, 345);
            this.dgv_InStockRowDetails.TabIndex = 177;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(1048, 32);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(80, 29);
            this.btn_query.TabIndex = 178;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BillNo";
            this.dataGridViewTextBoxColumn7.HeaderText = "单据号";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PartNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "料号";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "CreateTime";
            this.dataGridViewTextBoxColumn10.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Creator";
            this.dataGridViewTextBoxColumn11.HeaderText = "创建人";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // LotNo
            // 
            this.LotNo.DataPropertyName = "LotNo";
            this.LotNo.HeaderText = "批号";
            this.LotNo.Name = "LotNo";
            this.LotNo.Width = 150;
            // 
            // BoxNo
            // 
            this.BoxNo.DataPropertyName = "BoxNo";
            this.BoxNo.HeaderText = "箱号";
            this.BoxNo.Name = "BoxNo";
            this.BoxNo.Width = 150;
            // 
            // ucSemiAndFinishedWareHousing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.dgv_InStockRowDetails);
            this.Controls.Add(this.dgv_InStockRows);
            this.Controls.Add(this.dgv_barCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp_TimeMax);
            this.Controls.Add(this.dtp_TimeMin);
            this.Controls.Add(this.cbo_BillType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_InstockNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_BillNo);
            this.Controls.Add(this.label1);
            this.Name = "ucSemiAndFinishedWareHousing";
            this.Size = new System.Drawing.Size(1340, 661);
            this.Load += new System.EventHandler(this.ucSemiAndFinishedWareHousing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InStockRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InStockRowDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_BillType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_InstockNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BillNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_TimeMax;
        private System.Windows.Forms.DateTimePicker dtp_TimeMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_barCode;
        private System.Windows.Forms.DataGridView dgv_InStockRows;
        private System.Windows.Forms.DataGridView dgv_InStockRowDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
    }
}
