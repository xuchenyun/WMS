namespace Warehouse.UI
{
    partial class ucInventoryCollect
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
            this.cbo_flag = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PN = new CIT.Client.TXTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.txt_InventoryNumber = new CIT.Client.TXTextBox();
            this.lbl_ReelID = new System.Windows.Forms.Label();
            this.lbl_PartNumber = new System.Windows.Forms.Label();
            this.txt_inventoryCode = new CIT.Client.TXTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_inventoryManager = new System.Windows.Forms.DataGridView();
            this.InventoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Controls.Add(this.cbo_flag);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_PN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.txt_InventoryNumber);
            this.panel1.Controls.Add(this.lbl_ReelID);
            this.panel1.Controls.Add(this.lbl_PartNumber);
            this.panel1.Controls.Add(this.txt_inventoryCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1154, 100);
            this.panel1.TabIndex = 0;
            // 
            // cbo_flag
            // 
            this.cbo_flag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_flag.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_flag.FormattingEnabled = true;
            this.cbo_flag.Items.AddRange(new object[] {
            "",
            "盘盈",
            "盘亏"});
            this.cbo_flag.Location = new System.Drawing.Point(816, 37);
            this.cbo_flag.Name = "cbo_flag";
            this.cbo_flag.Size = new System.Drawing.Size(143, 24);
            this.cbo_flag.TabIndex = 128;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(738, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 147;
            this.label2.Text = "盘盈盘亏";
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
            this.txt_PN.Location = new System.Drawing.Point(561, 36);
            this.txt_PN.Name = "txt_PN";
            this.txt_PN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_PN.PasswordChar = '\0';
            this.txt_PN.Required = false;
            this.txt_PN.Size = new System.Drawing.Size(150, 27);
            this.txt_PN.TabIndex = 146;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(515, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 145;
            this.label1.Text = "料号";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(974, 32);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(91, 35);
            this.btn_query.TabIndex = 144;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_InventoryNumber
            // 
            this.txt_InventoryNumber.BackColor = System.Drawing.Color.Transparent;
            this.txt_InventoryNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_InventoryNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_InventoryNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_InventoryNumber.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_InventoryNumber.Image = null;
            this.txt_InventoryNumber.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_InventoryNumber.Location = new System.Drawing.Point(344, 36);
            this.txt_InventoryNumber.Name = "txt_InventoryNumber";
            this.txt_InventoryNumber.Padding = new System.Windows.Forms.Padding(2);
            this.txt_InventoryNumber.PasswordChar = '\0';
            this.txt_InventoryNumber.Required = false;
            this.txt_InventoryNumber.Size = new System.Drawing.Size(150, 27);
            this.txt_InventoryNumber.TabIndex = 143;
            // 
            // lbl_ReelID
            // 
            this.lbl_ReelID.AutoSize = true;
            this.lbl_ReelID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ReelID.Location = new System.Drawing.Point(250, 41);
            this.lbl_ReelID.Name = "lbl_ReelID";
            this.lbl_ReelID.Size = new System.Drawing.Size(88, 16);
            this.lbl_ReelID.TabIndex = 142;
            this.lbl_ReelID.Text = "盘盈盘亏号";
            // 
            // lbl_PartNumber
            // 
            this.lbl_PartNumber.AutoSize = true;
            this.lbl_PartNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_PartNumber.Location = new System.Drawing.Point(16, 41);
            this.lbl_PartNumber.Name = "lbl_PartNumber";
            this.lbl_PartNumber.Size = new System.Drawing.Size(72, 16);
            this.lbl_PartNumber.TabIndex = 141;
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
            this.txt_inventoryCode.Location = new System.Drawing.Point(94, 36);
            this.txt_inventoryCode.Name = "txt_inventoryCode";
            this.txt_inventoryCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_inventoryCode.PasswordChar = '\0';
            this.txt_inventoryCode.Required = false;
            this.txt_inventoryCode.Size = new System.Drawing.Size(150, 27);
            this.txt_inventoryCode.TabIndex = 140;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_inventoryManager);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1154, 303);
            this.panel2.TabIndex = 1;
            // 
            // dgv_inventoryManager
            // 
            this.dgv_inventoryManager.AllowUserToAddRows = false;
            this.dgv_inventoryManager.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_inventoryManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inventoryManager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryCode,
            this.InventoryNumber,
            this.PN,
            this.Flag,
            this.DifferQty,
            this.Creator,
            this.CreateTime});
            this.dgv_inventoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inventoryManager.Location = new System.Drawing.Point(0, 0);
            this.dgv_inventoryManager.Name = "dgv_inventoryManager";
            this.dgv_inventoryManager.RowHeadersVisible = false;
            this.dgv_inventoryManager.RowTemplate.Height = 23;
            this.dgv_inventoryManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_inventoryManager.Size = new System.Drawing.Size(1154, 303);
            this.dgv_inventoryManager.TabIndex = 5;
            this.dgv_inventoryManager.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_inventoryManager_MouseDoubleClick);
            // 
            // InventoryCode
            // 
            this.InventoryCode.DataPropertyName = "InventoryCode";
            this.InventoryCode.HeaderText = "盘点号";
            this.InventoryCode.Name = "InventoryCode";
            this.InventoryCode.ReadOnly = true;
            this.InventoryCode.Width = 150;
            // 
            // InventoryNumber
            // 
            this.InventoryNumber.DataPropertyName = "InventoryNumber";
            this.InventoryNumber.HeaderText = "盘盈盘亏号";
            this.InventoryNumber.Name = "InventoryNumber";
            this.InventoryNumber.ReadOnly = true;
            this.InventoryNumber.Width = 150;
            // 
            // PN
            // 
            this.PN.DataPropertyName = "PN";
            this.PN.HeaderText = "料号";
            this.PN.Name = "PN";
            this.PN.ReadOnly = true;
            this.PN.Width = 150;
            // 
            // Flag
            // 
            this.Flag.DataPropertyName = "Flag";
            this.Flag.HeaderText = "盘盈盘亏";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            // 
            // DifferQty
            // 
            this.DifferQty.DataPropertyName = "DifferQty";
            this.DifferQty.HeaderText = "差异数";
            this.DifferQty.Name = "DifferQty";
            this.DifferQty.ReadOnly = true;
            this.DifferQty.Width = 120;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "盘点汇总人";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            this.Creator.Width = 150;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "盘点汇总时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 150;
            // 
            // ucInventoryCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucInventoryCollect";
            this.Size = new System.Drawing.Size(1154, 403);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inventoryManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private CIT.Client.TXTextBox txt_PN;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton btn_query;
        private CIT.Client.TXTextBox txt_InventoryNumber;
        private System.Windows.Forms.Label lbl_ReelID;
        private System.Windows.Forms.Label lbl_PartNumber;
        private CIT.Client.TXTextBox txt_inventoryCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_inventoryManager;
        private System.Windows.Forms.ComboBox cbo_flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn DifferQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
    }
}
