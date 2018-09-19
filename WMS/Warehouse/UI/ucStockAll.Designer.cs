namespace Warehouse.UI
{
    partial class ucStockAll
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_stockAll = new System.Windows.Forms.DataGridView();
            this.Storage_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Storage_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_materialCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_location = new CIT.Client.TXComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_area = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new CIT.Client.TXButton();
            this.btn_stockAll = new CIT.Client.TXButton();
            this.cbo_stockName = new CIT.Client.TXComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stockAll)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_stockAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 404);
            this.panel2.TabIndex = 1;
            // 
            // dgv_stockAll
            // 
            this.dgv_stockAll.AllowUserToAddRows = false;
            this.dgv_stockAll.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_stockAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stockAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Storage_SN,
            this.Storage_Name,
            this.Area_Name,
            this.Location_Name,
            this.MaterialCode,
            this.QTY});
            this.dgv_stockAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_stockAll.Location = new System.Drawing.Point(0, 0);
            this.dgv_stockAll.Name = "dgv_stockAll";
            this.dgv_stockAll.ReadOnly = true;
            this.dgv_stockAll.RowHeadersVisible = false;
            this.dgv_stockAll.RowTemplate.Height = 23;
            this.dgv_stockAll.Size = new System.Drawing.Size(847, 404);
            this.dgv_stockAll.TabIndex = 0;
            this.dgv_stockAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_stockAll_MouseDoubleClick);
            // 
            // Storage_SN
            // 
            this.Storage_SN.DataPropertyName = "Storage_SN";
            this.Storage_SN.HeaderText = "仓库SN";
            this.Storage_SN.Name = "Storage_SN";
            this.Storage_SN.ReadOnly = true;
            this.Storage_SN.Visible = false;
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
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 149;
            this.label1.Text = "料号";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.Location = new System.Drawing.Point(329, 68);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Size = new System.Drawing.Size(177, 21);
            this.txt_materialCode.TabIndex = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 153;
            this.label3.Text = "仓库";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_location);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbo_area);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btn_stockAll);
            this.panel1.Controls.Add(this.cbo_stockName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_materialCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 122);
            this.panel1.TabIndex = 0;
            // 
            // cbo_location
            // 
            this.cbo_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_location.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_location.FormattingEnabled = true;
            this.cbo_location.Location = new System.Drawing.Point(73, 68);
            this.cbo_location.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_location.Name = "cbo_location";
            this.cbo_location.Size = new System.Drawing.Size(177, 24);
            this.cbo_location.TabIndex = 166;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 165;
            this.label4.Text = "库位";
            // 
            // cbo_area
            // 
            this.cbo_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_area.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_area.FormattingEnabled = true;
            this.cbo_area.Location = new System.Drawing.Point(329, 25);
            this.cbo_area.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_area.Name = "cbo_area";
            this.cbo_area.Size = new System.Drawing.Size(177, 24);
            this.cbo_area.TabIndex = 164;
            this.cbo_area.SelectionChangeCommitted += new System.EventHandler(this.cbo_area_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 163;
            this.label2.Text = "库区";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Image = null;
            this.btnExport.Location = new System.Drawing.Point(623, 65);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 27);
            this.btnExport.TabIndex = 162;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btn_stockAll
            // 
            this.btn_stockAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_stockAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_stockAll.Image = null;
            this.btn_stockAll.Location = new System.Drawing.Point(521, 65);
            this.btn_stockAll.Name = "btn_stockAll";
            this.btn_stockAll.Size = new System.Drawing.Size(81, 27);
            this.btn_stockAll.TabIndex = 161;
            this.btn_stockAll.Text = "汇总";
            this.btn_stockAll.UseVisualStyleBackColor = true;
            this.btn_stockAll.Click += new System.EventHandler(this.btn_stockAll_Click);
            // 
            // cbo_stockName
            // 
            this.cbo_stockName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_stockName.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_stockName.FormattingEnabled = true;
            this.cbo_stockName.Location = new System.Drawing.Point(73, 25);
            this.cbo_stockName.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_stockName.Name = "cbo_stockName";
            this.cbo_stockName.Size = new System.Drawing.Size(177, 24);
            this.cbo_stockName.TabIndex = 156;
            this.cbo_stockName.SelectionChangeCommitted += new System.EventHandler(this.cbo_stockName_SelectionChangeCommitted);
            // 
            // ucStockAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucStockAll";
            this.Size = new System.Drawing.Size(847, 526);
            this.Load += new System.EventHandler(this.ucStockAll_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stockAll)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_stockAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_materialCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXComboBox cbo_stockName;
        private CIT.Client.TXButton btn_stockAll;
        private CIT.Client.TXButton btnExport;
        private CIT.Client.TXComboBox cbo_location;
        private System.Windows.Forms.Label label4;
        private CIT.Client.TXComboBox cbo_area;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storage_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storage_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
    }
}
