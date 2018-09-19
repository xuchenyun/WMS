namespace Warehouse.UI
{
    partial class ucInventoryDetail
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_houseName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.txt_PN = new CIT.Client.TXTextBox();
            this.lbl_ReelID = new System.Windows.Forms.Label();
            this.lbl_PartNumber = new System.Windows.Forms.Label();
            this.txt_inventoryCode = new CIT.Client.TXTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_inventoryDetail = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.InventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DifferQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventoryDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_houseName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.txt_PN);
            this.panel1.Controls.Add(this.lbl_ReelID);
            this.panel1.Controls.Add(this.lbl_PartNumber);
            this.panel1.Controls.Add(this.txt_inventoryCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 100);
            this.panel1.TabIndex = 0;
            // 
            // cbo_houseName
            // 
            this.cbo_houseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_houseName.FormattingEnabled = true;
            this.cbo_houseName.Location = new System.Drawing.Point(533, 37);
            this.cbo_houseName.Name = "cbo_houseName";
            this.cbo_houseName.Size = new System.Drawing.Size(150, 24);
            this.cbo_houseName.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(478, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 131;
            this.label1.Text = "仓库";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(704, 33);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(91, 35);
            this.btn_query.TabIndex = 130;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_PN
            // 
            this.txt_PN.BackColor = System.Drawing.Color.Transparent;
            this.txt_PN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_PN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_PN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_PN.Image = null;
            this.txt_PN.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_PN.Location = new System.Drawing.Point(302, 36);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_PN.PasswordChar = '\0';
            this.txt_PN.Required = false;
            this.txt_PN.Size = new System.Drawing.Size(150, 27);
            this.txt_PN.TabIndex = 129;
            // 
            // lbl_ReelID
            // 
            this.lbl_ReelID.AutoSize = true;
            this.lbl_ReelID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ReelID.Location = new System.Drawing.Point(256, 41);
            this.lbl_ReelID.Name = "lbl_ReelID";
            this.lbl_ReelID.Size = new System.Drawing.Size(40, 16);
            this.lbl_ReelID.TabIndex = 128;
            this.lbl_ReelID.Text = "料号";
            // 
            // lbl_PartNumber
            // 
            this.lbl_PartNumber.AutoSize = true;
            this.lbl_PartNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PartNumber.Location = new System.Drawing.Point(10, 41);
            this.lbl_PartNumber.Name = "lbl_PartNumber";
            this.lbl_PartNumber.Size = new System.Drawing.Size(72, 16);
            this.lbl_PartNumber.TabIndex = 127;
            this.lbl_PartNumber.Text = "盘点单号";
            // 
            // txt_inventoryCode
            // 
            this.txt_inventoryCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_inventoryCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_inventoryCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_inventoryCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_inventoryCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_inventoryCode.Image = null;
            this.txt_inventoryCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_inventoryCode.Location = new System.Drawing.Point(88, 36);
            this.txt_inventoryCode.Name = "txt_inventoryCode";
            this.txt_inventoryCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_inventoryCode.PasswordChar = '\0';
            this.txt_inventoryCode.Required = false;
            this.txt_inventoryCode.Size = new System.Drawing.Size(150, 27);
            this.txt_inventoryCode.TabIndex = 126;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_inventoryDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 400);
            this.panel2.TabIndex = 1;
            // 
            // dgv_inventoryDetail
            // 
            this.dgv_inventoryDetail.AllowUserToAddRows = false;
            this.dgv_inventoryDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_inventoryDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventoryDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryCode,
            this.PN,
            this.Status,
            this.HouseCode,
            this.HouseName,
            this.StorageArea,
            this.Qty,
            this.DifferQty,
            this.CurrentQty});
            this.dgv_inventoryDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inventoryDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_inventoryDetail.Name = "dgv_inventoryDetail";
            this.dgv_inventoryDetail.RowHeadersVisible = false;
            this.dgv_inventoryDetail.RowTemplate.Height = 23;
            this.dgv_inventoryDetail.Size = new System.Drawing.Size(1001, 400);
            this.dgv_inventoryDetail.TabIndex = 3;
            this.dgv_inventoryDetail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_inventoryDetail_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InventoryCode
            // 
            this.InventoryCode.DataPropertyName = "InventoryCode";
            this.InventoryCode.HeaderText = "盘点号";
            this.InventoryCode.Name = "InventoryCode";
            this.InventoryCode.ReadOnly = true;
            // 
            // PN
            // 
            this.PN.DataPropertyName = "PN";
            this.PN.HeaderText = "料号";
            this.PN.Name = "PN";
            this.PN.ReadOnly = true;
            this.PN.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "盘点状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // HouseCode
            // 
            this.HouseCode.DataPropertyName = "HouseCode";
            this.HouseCode.HeaderText = "仓库号";
            this.HouseCode.Name = "HouseCode";
            this.HouseCode.ReadOnly = true;
            this.HouseCode.Visible = false;
            // 
            // HouseName
            // 
            this.HouseName.DataPropertyName = "HouseName";
            this.HouseName.HeaderText = "仓库";
            this.HouseName.Name = "HouseName";
            this.HouseName.ReadOnly = true;
            // 
            // StorageArea
            // 
            this.StorageArea.DataPropertyName = "StorageArea";
            this.StorageArea.HeaderText = "库区";
            this.StorageArea.Name = "StorageArea";
            this.StorageArea.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "数量";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // DifferQty
            // 
            this.DifferQty.DataPropertyName = "DifferQty";
            this.DifferQty.HeaderText = "差异数";
            this.DifferQty.Name = "DifferQty";
            this.DifferQty.ReadOnly = true;
            // 
            // CurrentQty
            // 
            this.CurrentQty.DataPropertyName = "CurrentQty";
            this.CurrentQty.HeaderText = "已盘数";
            this.CurrentQty.Name = "CurrentQty";
            this.CurrentQty.ReadOnly = true;
            // 
            // ucInventoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucInventoryDetail";
            this.Size = new System.Drawing.Size(1001, 500);
            this.Load += new System.EventHandler(this.ucInventoryDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventoryDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_houseName;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton btn_query;
        private CIT.Client.TXTextBox txt_PN;
        private System.Windows.Forms.Label lbl_ReelID;
        private System.Windows.Forms.Label lbl_PartNumber;
        private CIT.Client.TXTextBox txt_inventoryCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_inventoryDetail;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DifferQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentQty;
    }
}
