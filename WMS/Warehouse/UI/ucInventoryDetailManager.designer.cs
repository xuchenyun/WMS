namespace Warehouse.UI
{
    partial class ucInventoryDetailManager
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
            this.cbo_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_houseName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.txt_ReelId = new CIT.Client.TXTextBox();
            this.lbl_ReelID = new System.Windows.Forms.Label();
            this.lbl_PartNumber = new System.Windows.Forms.Label();
            this.txt_inventoryCode = new CIT.Client.TXTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_inventoryManager = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.InventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DifferQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventoryManager)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_status);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbo_houseName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.txt_ReelId);
            this.panel1.Controls.Add(this.lbl_ReelID);
            this.panel1.Controls.Add(this.lbl_PartNumber);
            this.panel1.Controls.Add(this.txt_inventoryCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 82);
            this.panel1.TabIndex = 0;
            // 
            // cbo_status
            // 
            this.cbo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_status.FormattingEnabled = true;
            this.cbo_status.Items.AddRange(new object[] {
            "",
            "未盘",
            "已盘"});
            this.cbo_status.Location = new System.Drawing.Point(382, 52);
            this.cbo_status.Name = "cbo_status";
            this.cbo_status.Size = new System.Drawing.Size(150, 24);
            this.cbo_status.TabIndex = 141;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(327, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 140;
            this.label2.Text = "状态";
            // 
            // cbo_houseName
            // 
            this.cbo_houseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_houseName.FormattingEnabled = true;
            this.cbo_houseName.Location = new System.Drawing.Point(81, 52);
            this.cbo_houseName.Name = "cbo_houseName";
            this.cbo_houseName.Size = new System.Drawing.Size(150, 24);
            this.cbo_houseName.TabIndex = 139;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 138;
            this.label1.Text = "仓库";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(629, 23);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(91, 35);
            this.btn_query.TabIndex = 137;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_ReelId
            // 
            this.txt_ReelId.BackColor = System.Drawing.Color.Transparent;
            this.txt_ReelId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_ReelId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ReelId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ReelId.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ReelId.Image = null;
            this.txt_ReelId.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ReelId.Location = new System.Drawing.Point(382, 6);
            this.txt_ReelId.Name = "txt_ReelId";
            this.txt_ReelId.Padding = new System.Windows.Forms.Padding(2);
            this.txt_ReelId.PasswordChar = '\0';
            this.txt_ReelId.Required = false;
            this.txt_ReelId.Size = new System.Drawing.Size(150, 27);
            this.txt_ReelId.TabIndex = 136;
            // 
            // lbl_ReelID
            // 
            this.lbl_ReelID.AutoSize = true;
            this.lbl_ReelID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ReelID.Location = new System.Drawing.Point(316, 11);
            this.lbl_ReelID.Name = "lbl_ReelID";
            this.lbl_ReelID.Size = new System.Drawing.Size(56, 16);
            this.lbl_ReelID.TabIndex = 135;
            this.lbl_ReelID.Text = "ReelId";
            // 
            // lbl_PartNumber
            // 
            this.lbl_PartNumber.AutoSize = true;
            this.lbl_PartNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PartNumber.Location = new System.Drawing.Point(3, 11);
            this.lbl_PartNumber.Name = "lbl_PartNumber";
            this.lbl_PartNumber.Size = new System.Drawing.Size(72, 16);
            this.lbl_PartNumber.TabIndex = 134;
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
            this.txt_inventoryCode.Location = new System.Drawing.Point(81, 6);
            this.txt_inventoryCode.Name = "txt_inventoryCode";
            this.txt_inventoryCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_inventoryCode.PasswordChar = '\0';
            this.txt_inventoryCode.Required = false;
            this.txt_inventoryCode.Size = new System.Drawing.Size(150, 27);
            this.txt_inventoryCode.TabIndex = 133;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_inventoryManager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1115, 434);
            this.panel2.TabIndex = 1;
            // 
            // dgv_inventoryManager
            // 
            this.dgv_inventoryManager.AllowUserToAddRows = false;
            this.dgv_inventoryManager.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_inventoryManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventoryManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryCode,
            this.ReelId,
            this.Status,
            this.HouseCode,
            this.HouseName,
            this.StorageArea,
            this.Location_SN,
            this.MaterialCode,
            this.Qty,
            this.CurrentQty,
            this.DifferQty,
            this.Creator,
            this.CreateTime});
            this.dgv_inventoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inventoryManager.Location = new System.Drawing.Point(0, 0);
            this.dgv_inventoryManager.Name = "dgv_inventoryManager";
            this.dgv_inventoryManager.RowHeadersVisible = false;
            this.dgv_inventoryManager.RowTemplate.Height = 23;
            this.dgv_inventoryManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_inventoryManager.Size = new System.Drawing.Size(1115, 434);
            this.dgv_inventoryManager.TabIndex = 4;
            this.dgv_inventoryManager.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_inventoryManager_MouseDoubleClick);
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
            // ReelId
            // 
            this.ReelId.DataPropertyName = "ReelId";
            this.ReelId.HeaderText = "ReelId";
            this.ReelId.Name = "ReelId";
            this.ReelId.ReadOnly = true;
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
            // Location_SN
            // 
            this.Location_SN.DataPropertyName = "Location_SN";
            this.Location_SN.HeaderText = "库位";
            this.Location_SN.Name = "Location_SN";
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "数量";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // CurrentQty
            // 
            this.CurrentQty.DataPropertyName = "CurrentQty";
            this.CurrentQty.HeaderText = "已盘数";
            this.CurrentQty.Name = "CurrentQty";
            this.CurrentQty.ReadOnly = true;
            // 
            // DifferQty
            // 
            this.DifferQty.DataPropertyName = "DifferQty";
            this.DifferQty.HeaderText = "差异数";
            this.DifferQty.Name = "DifferQty";
            this.DifferQty.ReadOnly = true;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "盘点人";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "盘点时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // ucInventoryDetailManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucInventoryDetailManager";
            this.Size = new System.Drawing.Size(1115, 516);
            this.Load += new System.EventHandler(this.ucInventoryDetailManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventoryManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_houseName;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton btn_query;
        private CIT.Client.TXTextBox txt_ReelId;
        private System.Windows.Forms.Label lbl_ReelID;
        private System.Windows.Forms.Label lbl_PartNumber;
        private CIT.Client.TXTextBox txt_inventoryCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_inventoryManager;
        private System.Windows.Forms.ComboBox cbo_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DifferQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
    }
}
