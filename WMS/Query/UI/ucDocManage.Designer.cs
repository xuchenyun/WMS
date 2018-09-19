namespace Query.UI
{
    partial class ucDocManage
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtBeforeDoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_TimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeMin = new System.Windows.Forms.DateTimePicker();
            this.workTimeMin = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.cbo_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Doc_NO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tolMenu = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvStorageDetail = new System.Windows.Forms.DataGridView();
            this.S_Doc_NO_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_StorageMaterial = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_StorageDoc = new System.Windows.Forms.DataGridView();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Doc_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Before_Doc_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAutoCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Doc_NO_Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TSDM_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tolMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorageDetail)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StorageMaterial)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StorageDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.tolMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 84);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtBeforeDoc);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.dtp_TimeMax);
            this.panel5.Controls.Add(this.dtp_TimeMin);
            this.panel5.Controls.Add(this.workTimeMin);
            this.panel5.Controls.Add(this.btn_query);
            this.panel5.Controls.Add(this.cbo_Type);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txt_Doc_NO);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1213, 53);
            this.panel5.TabIndex = 161;
            // 
            // txtBeforeDoc
            // 
            this.txtBeforeDoc.Location = new System.Drawing.Point(713, 0);
            this.txtBeforeDoc.Name = "txtBeforeDoc";
            this.txtBeforeDoc.Size = new System.Drawing.Size(129, 21);
            this.txtBeforeDoc.TabIndex = 174;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(654, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 173;
            this.label2.Text = "上游单据";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 172;
            this.label5.Text = "--";
            // 
            // dtp_TimeMax
            // 
            this.dtp_TimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMax.Location = new System.Drawing.Point(399, 27);
            this.dtp_TimeMax.Name = "dtp_TimeMax";
            this.dtp_TimeMax.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMax.TabIndex = 170;
            // 
            // dtp_TimeMin
            // 
            this.dtp_TimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMin.Location = new System.Drawing.Point(101, 27);
            this.dtp_TimeMin.Name = "dtp_TimeMin";
            this.dtp_TimeMin.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMin.TabIndex = 168;
            // 
            // workTimeMin
            // 
            this.workTimeMin.AutoSize = true;
            this.workTimeMin.Location = new System.Drawing.Point(60, 34);
            this.workTimeMin.Name = "workTimeMin";
            this.workTimeMin.Size = new System.Drawing.Size(29, 12);
            this.workTimeMin.TabIndex = 167;
            this.workTimeMin.Text = "时间";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(859, -1);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 24);
            this.btn_query.TabIndex = 166;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cbo_Type
            // 
            this.cbo_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Type.FormattingEnabled = true;
            this.cbo_Type.Location = new System.Drawing.Point(399, 1);
            this.cbo_Type.Name = "cbo_Type";
            this.cbo_Type.Size = new System.Drawing.Size(129, 20);
            this.cbo_Type.TabIndex = 165;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 164;
            this.label3.Text = "类型";
            // 
            // txt_Doc_NO
            // 
            this.txt_Doc_NO.Location = new System.Drawing.Point(100, 3);
            this.txt_Doc_NO.Name = "txt_Doc_NO";
            this.txt_Doc_NO.Size = new System.Drawing.Size(129, 21);
            this.txt_Doc_NO.TabIndex = 159;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 158;
            this.label1.Text = "单据号";
            // 
            // tolMenu
            // 
            this.tolMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tolMenu.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tolMenu.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tolMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add});
            this.tolMenu.Location = new System.Drawing.Point(0, 0);
            this.tolMenu.Name = "tolMenu";
            this.tolMenu.Size = new System.Drawing.Size(1213, 31);
            this.tolMenu.TabIndex = 160;
            this.tolMenu.Text = "txToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::Query.Properties.Resources.edit;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 28);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1213, 587);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvStorageDetail);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(549, 261);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(664, 326);
            this.panel6.TabIndex = 2;
            // 
            // dgvStorageDetail
            // 
            this.dgvStorageDetail.AllowUserToAddRows = false;
            this.dgvStorageDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStorageDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStorageDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO_Detail,
            this.SerialNumber,
            this.MaterialCode_Detail,
            this.DateCode,
            this.MPN,
            this.Creator_Detail,
            this.Create_Time_Detail});
            this.dgvStorageDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStorageDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvStorageDetail.Name = "dgvStorageDetail";
            this.dgvStorageDetail.ReadOnly = true;
            this.dgvStorageDetail.RowHeadersVisible = false;
            this.dgvStorageDetail.RowTemplate.Height = 23;
            this.dgvStorageDetail.Size = new System.Drawing.Size(664, 326);
            this.dgvStorageDetail.TabIndex = 1;
            // 
            // S_Doc_NO_Detail
            // 
            this.S_Doc_NO_Detail.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO_Detail.HeaderText = "单据号";
            this.S_Doc_NO_Detail.Name = "S_Doc_NO_Detail";
            this.S_Doc_NO_Detail.ReadOnly = true;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "条码";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // MaterialCode_Detail
            // 
            this.MaterialCode_Detail.DataPropertyName = "MaterialCode";
            this.MaterialCode_Detail.HeaderText = "料号";
            this.MaterialCode_Detail.Name = "MaterialCode_Detail";
            this.MaterialCode_Detail.ReadOnly = true;
            // 
            // DateCode
            // 
            this.DateCode.DataPropertyName = "DateCode";
            this.DateCode.HeaderText = "DateCode";
            this.DateCode.Name = "DateCode";
            this.DateCode.ReadOnly = true;
            // 
            // MPN
            // 
            this.MPN.DataPropertyName = "MPN";
            this.MPN.HeaderText = "MPN";
            this.MPN.Name = "MPN";
            this.MPN.ReadOnly = true;
            // 
            // Creator_Detail
            // 
            this.Creator_Detail.DataPropertyName = "Creator";
            this.Creator_Detail.HeaderText = "Creator";
            this.Creator_Detail.Name = "Creator_Detail";
            this.Creator_Detail.ReadOnly = true;
            this.Creator_Detail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Create_Time_Detail
            // 
            this.Create_Time_Detail.DataPropertyName = "Create_Time";
            this.Create_Time_Detail.HeaderText = "创建时间";
            this.Create_Time_Detail.Name = "Create_Time_Detail";
            this.Create_Time_Detail.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_StorageMaterial);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(549, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(664, 261);
            this.panel3.TabIndex = 1;
            // 
            // dgv_StorageMaterial
            // 
            this.dgv_StorageMaterial.AllowUserToAddRows = false;
            this.dgv_StorageMaterial.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_StorageMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StorageMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO_Material,
            this.MaterialCode,
            this.QTY,
            this.Ver,
            this.RowNumber,
            this.Plan_Qty,
            this.TSDM_ID});
            this.dgv_StorageMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_StorageMaterial.Location = new System.Drawing.Point(0, 0);
            this.dgv_StorageMaterial.Name = "dgv_StorageMaterial";
            this.dgv_StorageMaterial.ReadOnly = true;
            this.dgv_StorageMaterial.RowHeadersVisible = false;
            this.dgv_StorageMaterial.RowTemplate.Height = 23;
            this.dgv_StorageMaterial.Size = new System.Drawing.Size(664, 261);
            this.dgv_StorageMaterial.TabIndex = 1;
            this.dgv_StorageMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_StorageMaterial_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_StorageDoc);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 587);
            this.panel2.TabIndex = 0;
            // 
            // dgv_StorageDoc
            // 
            this.dgv_StorageDoc.AllowUserToAddRows = false;
            this.dgv_StorageDoc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_StorageDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StorageDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.S_Doc_Type,
            this.Creator,
            this.Create_Time,
            this.Before_Doc_No,
            this.IsAutoCreate});
            this.dgv_StorageDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_StorageDoc.Location = new System.Drawing.Point(0, 0);
            this.dgv_StorageDoc.Name = "dgv_StorageDoc";
            this.dgv_StorageDoc.ReadOnly = true;
            this.dgv_StorageDoc.RowHeadersVisible = false;
            this.dgv_StorageDoc.RowTemplate.Height = 23;
            this.dgv_StorageDoc.Size = new System.Drawing.Size(549, 587);
            this.dgv_StorageDoc.TabIndex = 0;
            this.dgv_StorageDoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_StorageDoc_CellClick);
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "单据号";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
            this.S_Doc_NO.Width = 80;
            // 
            // S_Doc_Type
            // 
            this.S_Doc_Type.DataPropertyName = "S_Doc_Type";
            this.S_Doc_Type.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.S_Doc_Type.HeaderText = "单据类型";
            this.S_Doc_Type.Name = "S_Doc_Type";
            this.S_Doc_Type.ReadOnly = true;
            this.S_Doc_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.S_Doc_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.S_Doc_Type.Width = 80;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "创建人";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            this.Creator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Creator.Width = 80;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            // 
            // Before_Doc_No
            // 
            this.Before_Doc_No.DataPropertyName = "Before_Doc_No";
            this.Before_Doc_No.HeaderText = "上游单据";
            this.Before_Doc_No.Name = "Before_Doc_No";
            this.Before_Doc_No.ReadOnly = true;
            this.Before_Doc_No.Width = 120;
            // 
            // IsAutoCreate
            // 
            this.IsAutoCreate.DataPropertyName = "IsAutoCreate";
            this.IsAutoCreate.HeaderText = "是否自动生成";
            this.IsAutoCreate.Name = "IsAutoCreate";
            this.IsAutoCreate.ReadOnly = true;
            // 
            // S_Doc_NO_Material
            // 
            this.S_Doc_NO_Material.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO_Material.HeaderText = "单据号";
            this.S_Doc_NO_Material.Name = "S_Doc_NO_Material";
            this.S_Doc_NO_Material.ReadOnly = true;
            this.S_Doc_NO_Material.Width = 130;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Width = 130;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            this.QTY.Width = 130;
            // 
            // Ver
            // 
            this.Ver.DataPropertyName = "Ver";
            this.Ver.HeaderText = "版本";
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "行号";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 130;
            // 
            // Plan_Qty
            // 
            this.Plan_Qty.DataPropertyName = "Plan_Qty";
            this.Plan_Qty.HeaderText = "计划数";
            this.Plan_Qty.Name = "Plan_Qty";
            this.Plan_Qty.ReadOnly = true;
            this.Plan_Qty.Width = 130;
            // 
            // TSDM_ID
            // 
            this.TSDM_ID.DataPropertyName = "TSDM_ID";
            this.TSDM_ID.HeaderText = "TSDM_ID";
            this.TSDM_ID.Name = "TSDM_ID";
            this.TSDM_ID.ReadOnly = true;
            this.TSDM_ID.Visible = false;
            // 
            // ucDocManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "ucDocManage";
            this.Size = new System.Drawing.Size(1213, 671);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tolMenu.ResumeLayout(false);
            this.tolMenu.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorageDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StorageMaterial)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StorageDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private CIT.Client.TXToolStrip tolMenu;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgv_StorageDoc;
        private System.Windows.Forms.DataGridView dgvStorageDetail;
        private System.Windows.Forms.DataGridView dgv_StorageMaterial;
        private System.Windows.Forms.TextBox txt_Doc_NO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_Type;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_TimeMax;
        private System.Windows.Forms.DateTimePicker dtp_TimeMin;
        private System.Windows.Forms.Label workTimeMin;
        private System.Windows.Forms.TextBox txtBeforeDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewComboBoxColumn S_Doc_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Before_Doc_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsAutoCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO_Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TSDM_ID;
    }
}
