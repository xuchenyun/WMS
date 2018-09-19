namespace Warehouse.UI
{
    partial class ucInventoryManager
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
            this.miniToolStrip = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_inventorycollect = new System.Windows.Forms.ToolStripButton();
            this.btn_delete = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.top_action = new CIT.Client.TXToolStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbo_status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_houseName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.txt_PN = new CIT.Client.TXTextBox();
            this.lbl_ReelID = new System.Windows.Forms.Label();
            this.lbl_PartNumber = new System.Windows.Forms.Label();
            this.txt_inventoryCode = new CIT.Client.TXTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_inventory = new System.Windows.Forms.DataGridView();
            this.InventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.top_action.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.miniToolStrip.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(165, 10);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(997, 40);
            this.miniToolStrip.TabIndex = 7;
            // 
            // btn_add
            // 
            this.btn_add.Image = global::Warehouse.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 37);
            this.btn_add.Text = "开单";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_inventorycollect
            // 
            this.btn_inventorycollect.Image = global::Warehouse.Properties.Resources.refill;
            this.btn_inventorycollect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_inventorycollect.Name = "btn_inventorycollect";
            this.btn_inventorycollect.Size = new System.Drawing.Size(76, 37);
            this.btn_inventorycollect.Text = "盘点汇总";
            this.btn_inventorycollect.Click += new System.EventHandler(this.btn_inventorycollect_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Image = global::Warehouse.Properties.Resources.delbinding;
            this.btn_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(52, 37);
            this.btn_delete.Text = "删除";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.top_action);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(997, 40);
            this.panel1.TabIndex = 2;
            // 
            // top_action
            // 
            this.top_action.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.top_action.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.top_action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.top_action.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.top_action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_inventorycollect,
            this.btn_delete});
            this.top_action.Location = new System.Drawing.Point(0, 0);
            this.top_action.Name = "top_action";
            this.top_action.Size = new System.Drawing.Size(997, 40);
            this.top_action.TabIndex = 7;
            this.top_action.Text = "txToolStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 82);
            this.panel2.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbo_status);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.cbo_houseName);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.btn_query);
            this.panel6.Controls.Add(this.txt_PN);
            this.panel6.Controls.Add(this.lbl_ReelID);
            this.panel6.Controls.Add(this.lbl_PartNumber);
            this.panel6.Controls.Add(this.txt_inventoryCode);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(997, 100);
            this.panel6.TabIndex = 1;
            // 
            // cbo_status
            // 
            this.cbo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_status.FormattingEnabled = true;
            this.cbo_status.Items.AddRange(new object[] {
            "",
            "开立",
            "盘点中",
            "完成"});
            this.cbo_status.Location = new System.Drawing.Point(497, 51);
            this.cbo_status.Name = "cbo_status";
            this.cbo_status.Size = new System.Drawing.Size(143, 24);
            this.cbo_status.TabIndex = 127;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(451, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 126;
            this.label2.Text = "状态";
            // 
            // cbo_houseName
            // 
            this.cbo_houseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_houseName.FormattingEnabled = true;
            this.cbo_houseName.Location = new System.Drawing.Point(135, 51);
            this.cbo_houseName.Name = "cbo_houseName";
            this.cbo_houseName.Size = new System.Drawing.Size(143, 24);
            this.cbo_houseName.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(89, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 124;
            this.label1.Text = "仓库";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(736, 25);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(91, 35);
            this.btn_query.TabIndex = 123;
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
            this.txt_PN.Location = new System.Drawing.Point(497, 7);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_PN.PasswordChar = '\0';
            this.txt_PN.Required = false;
            this.txt_PN.Size = new System.Drawing.Size(143, 27);
            this.txt_PN.TabIndex = 122;
            // 
            // lbl_ReelID
            // 
            this.lbl_ReelID.AutoSize = true;
            this.lbl_ReelID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ReelID.Location = new System.Drawing.Point(451, 12);
            this.lbl_ReelID.Name = "lbl_ReelID";
            this.lbl_ReelID.Size = new System.Drawing.Size(40, 16);
            this.lbl_ReelID.TabIndex = 121;
            this.lbl_ReelID.Text = "料号";
            // 
            // lbl_PartNumber
            // 
            this.lbl_PartNumber.AutoSize = true;
            this.lbl_PartNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PartNumber.Location = new System.Drawing.Point(57, 12);
            this.lbl_PartNumber.Name = "lbl_PartNumber";
            this.lbl_PartNumber.Size = new System.Drawing.Size(72, 16);
            this.lbl_PartNumber.TabIndex = 120;
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
            this.txt_inventoryCode.Location = new System.Drawing.Point(135, 7);
            this.txt_inventoryCode.Name = "txt_inventoryCode";
            this.txt_inventoryCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_inventoryCode.PasswordChar = '\0';
            this.txt_inventoryCode.Required = false;
            this.txt_inventoryCode.Size = new System.Drawing.Size(143, 27);
            this.txt_inventoryCode.TabIndex = 119;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_inventory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 122);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 346);
            this.panel4.TabIndex = 4;
            // 
            // dgv_inventory
            // 
            this.dgv_inventory.AllowUserToAddRows = false;
            this.dgv_inventory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryCode,
            this.PN,
            this.Status,
            this.HouseName,
            this.HouseCode,
            this.StorageArea,
            this.StorageLocation,
            this.Creator,
            this.CreateTime});
            this.dgv_inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inventory.Location = new System.Drawing.Point(0, 0);
            this.dgv_inventory.Name = "dgv_inventory";
            this.dgv_inventory.RowHeadersVisible = false;
            this.dgv_inventory.RowTemplate.Height = 23;
            this.dgv_inventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_inventory.Size = new System.Drawing.Size(997, 346);
            this.dgv_inventory.TabIndex = 2;
            this.dgv_inventory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_inventory_MouseDoubleClick);
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
            this.PN.Width = 200;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "盘点状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // HouseName
            // 
            this.HouseName.DataPropertyName = "HouseName";
            this.HouseName.HeaderText = "仓库";
            this.HouseName.Name = "HouseName";
            this.HouseName.ReadOnly = true;
            // 
            // HouseCode
            // 
            this.HouseCode.DataPropertyName = "HouseCode";
            this.HouseCode.HeaderText = "仓库号";
            this.HouseCode.Name = "HouseCode";
            this.HouseCode.ReadOnly = true;
            this.HouseCode.Visible = false;
            // 
            // StorageArea
            // 
            this.StorageArea.DataPropertyName = "StorageArea";
            this.StorageArea.HeaderText = "库区";
            this.StorageArea.Name = "StorageArea";
            this.StorageArea.ReadOnly = true;
            // 
            // StorageLocation
            // 
            this.StorageLocation.DataPropertyName = "StorageLocation";
            this.StorageLocation.HeaderText = "库位";
            this.StorageLocation.Name = "StorageLocation";
            this.StorageLocation.ReadOnly = true;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "创建人";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 150;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucInventoryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucInventoryManager";
            this.Size = new System.Drawing.Size(997, 468);
            this.Load += new System.EventHandler(this.ucInventoryManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.top_action.ResumeLayout(false);
            this.top_action.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CIT.Client.TXToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_inventorycollect;
        private System.Windows.Forms.ToolStripButton btn_delete;
        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXToolStrip top_action;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbo_houseName;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton btn_query;
        private CIT.Client.TXTextBox txt_PN;
        private System.Windows.Forms.Label lbl_ReelID;
        private System.Windows.Forms.Label lbl_PartNumber;
        private CIT.Client.TXTextBox txt_inventoryCode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_inventory;
        private System.Windows.Forms.ComboBox cbo_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.Timer timer1;
    }
}
