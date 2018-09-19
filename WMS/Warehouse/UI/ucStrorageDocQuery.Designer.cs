namespace Warehouse.UI
{
    partial class ucStrorageDocQuery
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
            this.cbo_StorageSN = new CIT.Client.TXComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_MaterialCode = new CIT.Client.TXComboBox();
            this.cmb_Line = new CIT.Client.TXComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_ExcelOut = new System.Windows.Forms.ToolStripButton();
            this.cbo_DocType = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Sdoc_No = new CIT.Client.TXTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_CreateTimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_CreateTimeMin = new System.Windows.Forms.DateTimePicker();
            this.lbl_typeCode = new System.Windows.Forms.Label();
            this.lbl_typeName = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_SDoc_NO = new System.Windows.Forms.DataGridView();
            this.dgv_SDocNoDetl = new System.Windows.Forms.DataGridView();
            this.SDoc_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Container_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREAROR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Storage_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Doc_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SDoc_NO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SDocNoDetl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_StorageSN);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbo_MaterialCode);
            this.panel1.Controls.Add(this.cmb_Line);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Controls.Add(this.cbo_DocType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Sdoc_No);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtp_CreateTimeMax);
            this.panel1.Controls.Add(this.dtp_CreateTimeMin);
            this.panel1.Controls.Add(this.lbl_typeCode);
            this.panel1.Controls.Add(this.lbl_typeName);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1818, 205);
            this.panel1.TabIndex = 0;
            // 
            // cbo_StorageSN
            // 
            this.cbo_StorageSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_StorageSN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_StorageSN.FormattingEnabled = true;
            this.cbo_StorageSN.Location = new System.Drawing.Point(188, 157);
            this.cbo_StorageSN.Name = "cbo_StorageSN";
            this.cbo_StorageSN.Size = new System.Drawing.Size(309, 29);
            this.cbo_StorageSN.TabIndex = 163;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(128, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 162;
            this.label4.Text = "仓库";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_MaterialCode
            // 
            this.cbo_MaterialCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_MaterialCode.FormattingEnabled = true;
            this.cbo_MaterialCode.Location = new System.Drawing.Point(188, 52);
            this.cbo_MaterialCode.Name = "cbo_MaterialCode";
            this.cbo_MaterialCode.Size = new System.Drawing.Size(308, 29);
            this.cbo_MaterialCode.TabIndex = 159;
            this.cbo_MaterialCode.TextUpdate += new System.EventHandler(this.cbo_MaterialCode_TextUpdate);
            // 
            // cmb_Line
            // 
            this.cmb_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Line.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Line.FormattingEnabled = true;
            this.cmb_Line.Location = new System.Drawing.Point(188, 110);
            this.cmb_Line.Name = "cmb_Line";
            this.cmb_Line.Size = new System.Drawing.Size(309, 29);
            this.cmb_Line.TabIndex = 155;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(113, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 154;
            this.label5.Text = "生产线";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_ExcelOut});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.txToolStrip1.Size = new System.Drawing.Size(1818, 31);
            this.txToolStrip1.TabIndex = 153;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_ExcelOut
            // 
            this.btn_ExcelOut.Image = global::Warehouse.Properties.Resources.aync_wo;
            this.btn_ExcelOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ExcelOut.Name = "btn_ExcelOut";
            this.btn_ExcelOut.Size = new System.Drawing.Size(74, 28);
            this.btn_ExcelOut.Text = "导出";
            this.btn_ExcelOut.Click += new System.EventHandler(this.btn_ExcelOut_Click);
            // 
            // cbo_DocType
            // 
            this.cbo_DocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DocType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_DocType.FormattingEnabled = true;
            this.cbo_DocType.Location = new System.Drawing.Point(1071, 50);
            this.cbo_DocType.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_DocType.Name = "cbo_DocType";
            this.cbo_DocType.Size = new System.Drawing.Size(302, 32);
            this.cbo_DocType.TabIndex = 152;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(957, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 151;
            this.label2.Text = "单据类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(538, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 150;
            this.label1.Text = "单据号";
            // 
            // txt_Sdoc_No
            // 
            this.txt_Sdoc_No.BackColor = System.Drawing.Color.Transparent;
            this.txt_Sdoc_No.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Sdoc_No.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Sdoc_No.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Sdoc_No.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Sdoc_No.Image = null;
            this.txt_Sdoc_No.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Sdoc_No.Location = new System.Drawing.Point(635, 46);
            this.txt_Sdoc_No.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Sdoc_No.Name = "txt_Sdoc_No";
            this.txt_Sdoc_No.Padding = new System.Windows.Forms.Padding(3);
            this.txt_Sdoc_No.PasswordChar = '\0';
            this.txt_Sdoc_No.Required = false;
            this.txt_Sdoc_No.Size = new System.Drawing.Size(302, 40);
            this.txt_Sdoc_No.TabIndex = 149;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(997, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 18);
            this.label6.TabIndex = 148;
            this.label6.Text = "--";
            // 
            // dtp_CreateTimeMax
            // 
            this.dtp_CreateTimeMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_CreateTimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_CreateTimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_CreateTimeMax.Location = new System.Drawing.Point(1071, 107);
            this.dtp_CreateTimeMax.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_CreateTimeMax.Name = "dtp_CreateTimeMax";
            this.dtp_CreateTimeMax.Size = new System.Drawing.Size(302, 35);
            this.dtp_CreateTimeMax.TabIndex = 146;
            // 
            // dtp_CreateTimeMin
            // 
            this.dtp_CreateTimeMin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_CreateTimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_CreateTimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_CreateTimeMin.Location = new System.Drawing.Point(635, 107);
            this.dtp_CreateTimeMin.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_CreateTimeMin.Name = "dtp_CreateTimeMin";
            this.dtp_CreateTimeMin.Size = new System.Drawing.Size(302, 35);
            this.dtp_CreateTimeMin.TabIndex = 144;
            // 
            // lbl_typeCode
            // 
            this.lbl_typeCode.AutoSize = true;
            this.lbl_typeCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeCode.Location = new System.Drawing.Point(521, 114);
            this.lbl_typeCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_typeCode.Name = "lbl_typeCode";
            this.lbl_typeCode.Size = new System.Drawing.Size(106, 24);
            this.lbl_typeCode.TabIndex = 119;
            this.lbl_typeCode.Text = "创建时间";
            // 
            // lbl_typeName
            // 
            this.lbl_typeName.AutoSize = true;
            this.lbl_typeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeName.Location = new System.Drawing.Point(80, 52);
            this.lbl_typeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_typeName.Name = "lbl_typeName";
            this.lbl_typeName.Size = new System.Drawing.Size(106, 24);
            this.lbl_typeName.TabIndex = 118;
            this.lbl_typeName.Text = "物料代码";
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(525, 150);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(122, 40);
            this.btn_query.TabIndex = 116;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 205);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_SDoc_NO);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_SDocNoDetl);
            this.splitContainer1.Size = new System.Drawing.Size(1818, 465);
            this.splitContainer1.SplitterDistance = 877;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgv_SDoc_NO
            // 
            this.dgv_SDoc_NO.AllowUserToAddRows = false;
            this.dgv_SDoc_NO.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_SDoc_NO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SDoc_NO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Storage_Name,
            this.S_Doc_NO,
            this.S_Doc_Type,
            this.Column1,
            this.materialc,
            this.Q,
            this.Memo,
            this.Create_Time,
            this.UserName});
            this.dgv_SDoc_NO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SDoc_NO.Location = new System.Drawing.Point(0, 0);
            this.dgv_SDoc_NO.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_SDoc_NO.Name = "dgv_SDoc_NO";
            this.dgv_SDoc_NO.RowHeadersVisible = false;
            this.dgv_SDoc_NO.RowTemplate.Height = 23;
            this.dgv_SDoc_NO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_SDoc_NO.Size = new System.Drawing.Size(877, 465);
            this.dgv_SDoc_NO.TabIndex = 0;
            this.dgv_SDoc_NO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SDoc_NO_CellClick);
            this.dgv_SDoc_NO.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_SDoc_NO_MouseDoubleClick);
            // 
            // dgv_SDocNoDetl
            // 
            this.dgv_SDocNoDetl.AllowUserToAddRows = false;
            this.dgv_SDocNoDetl.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_SDocNoDetl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SDocNoDetl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SDoc_No,
            this.Container_SN,
            this.Location_SN,
            this.PLCode,
            this.MaterialCode,
            this.QTY,
            this.CreateTime,
            this.CREAROR});
            this.dgv_SDocNoDetl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SDocNoDetl.Location = new System.Drawing.Point(0, 0);
            this.dgv_SDocNoDetl.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_SDocNoDetl.Name = "dgv_SDocNoDetl";
            this.dgv_SDocNoDetl.RowHeadersVisible = false;
            this.dgv_SDocNoDetl.RowTemplate.Height = 23;
            this.dgv_SDocNoDetl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_SDocNoDetl.Size = new System.Drawing.Size(935, 465);
            this.dgv_SDocNoDetl.TabIndex = 0;
            // 
            // SDoc_No
            // 
            this.SDoc_No.DataPropertyName = "S_Doc_NO";
            this.SDoc_No.HeaderText = "单据号";
            this.SDoc_No.Name = "SDoc_No";
            this.SDoc_No.ReadOnly = true;
            // 
            // Container_SN
            // 
            this.Container_SN.DataPropertyName = "Container_SN";
            this.Container_SN.HeaderText = "容器SN";
            this.Container_SN.Name = "Container_SN";
            this.Container_SN.ReadOnly = true;
            // 
            // Location_SN
            // 
            this.Location_SN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Location_SN.DataPropertyName = "Location_SN";
            this.Location_SN.HeaderText = "库位SN";
            this.Location_SN.Name = "Location_SN";
            this.Location_SN.ReadOnly = true;
            this.Location_SN.Width = 98;
            // 
            // PLCode
            // 
            this.PLCode.DataPropertyName = "PLCode";
            this.PLCode.HeaderText = "线别代码";
            this.PLCode.MinimumWidth = 120;
            this.PLCode.Name = "PLCode";
            this.PLCode.ReadOnly = true;
            this.PLCode.Width = 120;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "物料代码";
            this.MaterialCode.MinimumWidth = 120;
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Width = 120;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.MinimumWidth = 80;
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            this.QTY.Width = 120;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "Create_Time";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.MinimumWidth = 120;
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 120;
            // 
            // CREAROR
            // 
            this.CREAROR.DataPropertyName = "Creator";
            this.CREAROR.HeaderText = "创建者";
            this.CREAROR.MinimumWidth = 100;
            this.CREAROR.Name = "CREAROR";
            this.CREAROR.ReadOnly = true;
            // 
            // Storage_Name
            // 
            this.Storage_Name.DataPropertyName = "Storage_Name";
            this.Storage_Name.HeaderText = "仓库";
            this.Storage_Name.Name = "Storage_Name";
            this.Storage_Name.ReadOnly = true;
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "单据号";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
            // 
            // S_Doc_Type
            // 
            this.S_Doc_Type.DataPropertyName = "S_Doc_Type";
            this.S_Doc_Type.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.S_Doc_Type.HeaderText = "单据类型";
            this.S_Doc_Type.MinimumWidth = 120;
            this.S_Doc_Type.Name = "S_Doc_Type";
            this.S_Doc_Type.ReadOnly = true;
            this.S_Doc_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.S_Doc_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.S_Doc_Type.Width = 120;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PLCode";
            this.Column1.HeaderText = "线别代码";
            this.Column1.MinimumWidth = 120;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // materialc
            // 
            this.materialc.DataPropertyName = "MaterialCode";
            this.materialc.HeaderText = "物料代码";
            this.materialc.MinimumWidth = 120;
            this.materialc.Name = "materialc";
            this.materialc.ReadOnly = true;
            this.materialc.Width = 120;
            // 
            // Q
            // 
            this.Q.DataPropertyName = "Qty";
            this.Q.HeaderText = "数量";
            this.Q.MinimumWidth = 80;
            this.Q.Name = "Q";
            this.Q.ReadOnly = true;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.MinimumWidth = 80;
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.Visible = false;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.MinimumWidth = 120;
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Width = 120;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "创建者";
            this.UserName.MinimumWidth = 100;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // ucStrorageDocQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucStrorageDocQuery";
            this.Size = new System.Drawing.Size(1818, 670);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SDoc_NO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SDocNoDetl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_SDoc_NO;
        private System.Windows.Forms.DataGridView dgv_SDocNoDetl;
        private System.Windows.Forms.Label lbl_typeCode;
        private System.Windows.Forms.Label lbl_typeName;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_CreateTimeMax;
        private System.Windows.Forms.DateTimePicker dtp_CreateTimeMin;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXTextBox txt_Sdoc_No;
        private CIT.Client.TXComboBox cbo_DocType;
        private System.Windows.Forms.Label label2;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_ExcelOut;
        private CIT.Client.TXComboBox cmb_Line;
        private System.Windows.Forms.Label label5;
        private CIT.Client.TXComboBox cbo_MaterialCode;
        private CIT.Client.TXComboBox cbo_StorageSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDoc_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Container_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREAROR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storage_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewComboBoxColumn S_Doc_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    }
}
