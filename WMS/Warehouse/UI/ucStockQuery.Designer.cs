namespace Warehouse.UI
{
    partial class ucStockQuery
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
            this.btnExport = new CIT.Client.TXButton();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_serialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_stockName = new CIT.Client.TXComboBox();
            this.btn_query = new CIT.Client.TXButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_materialCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_Stock = new System.Windows.Forms.DataGridView();
            this.Storage_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lock_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finally_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QC_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.txtLocation);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_serialNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbo_stockName);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_materialCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Image = null;
            this.btnExport.Location = new System.Drawing.Point(690, 49);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 27);
            this.btnExport.TabIndex = 166;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(447, 52);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(209, 21);
            this.txtLocation.TabIndex = 165;
            this.txtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocation_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 164;
            this.label4.Text = "库位";
            // 
            // txt_serialNumber
            // 
            this.txt_serialNumber.Location = new System.Drawing.Point(88, 52);
            this.txt_serialNumber.Name = "txt_serialNumber";
            this.txt_serialNumber.Size = new System.Drawing.Size(210, 21);
            this.txt_serialNumber.TabIndex = 163;
            this.txt_serialNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_serialNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 162;
            this.label2.Text = "唯一码";
            // 
            // cbo_stockName
            // 
            this.cbo_stockName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_stockName.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_stockName.FormattingEnabled = true;
            this.cbo_stockName.Location = new System.Drawing.Point(88, 13);
            this.cbo_stockName.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_stockName.Name = "cbo_stockName";
            this.cbo_stockName.Size = new System.Drawing.Size(210, 24);
            this.cbo_stockName.TabIndex = 161;
            this.cbo_stockName.SelectionChangeCommitted += new System.EventHandler(this.cbo_stockName_SelectionChangeCommitted);
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(690, 15);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 160;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 159;
            this.label3.Text = "仓库";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.Location = new System.Drawing.Point(447, 13);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Size = new System.Drawing.Size(209, 21);
            this.txt_materialCode.TabIndex = 158;
            this.txt_materialCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_materialCode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 157;
            this.label1.Text = "料号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Stock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 419);
            this.panel2.TabIndex = 1;
            // 
            // dgv_Stock
            // 
            this.dgv_Stock.AllowUserToAddRows = false;
            this.dgv_Stock.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Storage_Name,
            this.Area_Name,
            this.Location_Name,
            this.MaterialCode,
            this.SerialNumber,
            this.QTY,
            this.Lock_Flag,
            this.Finally_Time,
            this.In_Time,
            this.DateCode,
            this.Lot_No,
            this.QC_Result});
            this.dgv_Stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Stock.Location = new System.Drawing.Point(0, 0);
            this.dgv_Stock.Name = "dgv_Stock";
            this.dgv_Stock.ReadOnly = true;
            this.dgv_Stock.RowHeadersVisible = false;
            this.dgv_Stock.RowTemplate.Height = 23;
            this.dgv_Stock.Size = new System.Drawing.Size(1154, 419);
            this.dgv_Stock.TabIndex = 0;
            this.dgv_Stock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Stock_MouseDoubleClick);
            // 
            // Storage_Name
            // 
            this.Storage_Name.DataPropertyName = "Storage_Name";
            this.Storage_Name.HeaderText = "仓库";
            this.Storage_Name.Name = "Storage_Name";
            this.Storage_Name.ReadOnly = true;
            // 
            // Area_Name
            // 
            this.Area_Name.DataPropertyName = "Area_Name";
            this.Area_Name.HeaderText = "库区";
            this.Area_Name.Name = "Area_Name";
            this.Area_Name.ReadOnly = true;
            // 
            // Location_Name
            // 
            this.Location_Name.DataPropertyName = "Location_Name";
            this.Location_Name.HeaderText = "库位";
            this.Location_Name.Name = "Location_Name";
            this.Location_Name.ReadOnly = true;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "唯一码";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // Lock_Flag
            // 
            this.Lock_Flag.DataPropertyName = "Lock_Flag";
            this.Lock_Flag.HeaderText = "状态";
            this.Lock_Flag.Name = "Lock_Flag";
            this.Lock_Flag.ReadOnly = true;
            // 
            // Finally_Time
            // 
            this.Finally_Time.DataPropertyName = "Finally_Time";
            this.Finally_Time.HeaderText = "有效期";
            this.Finally_Time.Name = "Finally_Time";
            this.Finally_Time.ReadOnly = true;
            // 
            // In_Time
            // 
            this.In_Time.DataPropertyName = "In_Time";
            this.In_Time.HeaderText = "入库时间";
            this.In_Time.Name = "In_Time";
            this.In_Time.ReadOnly = true;
            // 
            // DateCode
            // 
            this.DateCode.DataPropertyName = "DateCode";
            this.DateCode.HeaderText = "DateCode";
            this.DateCode.Name = "DateCode";
            this.DateCode.ReadOnly = true;
            // 
            // Lot_No
            // 
            this.Lot_No.DataPropertyName = "Lot_No";
            this.Lot_No.HeaderText = "Lot_No";
            this.Lot_No.Name = "Lot_No";
            this.Lot_No.ReadOnly = true;
            // 
            // QC_Result
            // 
            this.QC_Result.DataPropertyName = "QC_Result";
            this.QC_Result.HeaderText = "IQC结果";
            this.QC_Result.Name = "QC_Result";
            this.QC_Result.ReadOnly = true;
            // 
            // ucStockQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucStockQuery";
            this.Size = new System.Drawing.Size(1154, 519);
            this.Load += new System.EventHandler(this.uc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXComboBox cbo_stockName;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_materialCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Stock;
        private System.Windows.Forms.TextBox txt_serialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label4;
        private CIT.Client.TXButton btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storage_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lock_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finally_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn QC_Result;
    }
}
