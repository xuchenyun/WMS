namespace Query.UI
{
    partial class ucStorageDocQuery
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Doc_Tbsd = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv_DocMaterial_tsdm = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_Detail_tbsdd = new System.Windows.Forms.DataGridView();
            this.tsdm_S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO_DetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reback_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsdd_PO_DetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S_Doc_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reback_Over = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrival_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_S_Doc_NO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_S_Doc_NO_Type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_LotNo = new System.Windows.Forms.TextBox();
            this.txt_PO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Arrival_NO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_qeury = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Doc_Tbsd)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DocMaterial_tsdm)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail_tbsdd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 40);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_qeury);
            this.panel2.Controls.Add(this.txt_Arrival_NO);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_PO);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_LotNo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbo_S_Doc_NO_Type);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_S_Doc_NO);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1085, 58);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Doc_Tbsd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(546, 387);
            this.panel3.TabIndex = 2;
            // 
            // dgv_Doc_Tbsd
            // 
            this.dgv_Doc_Tbsd.AllowUserToAddRows = false;
            this.dgv_Doc_Tbsd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Doc_Tbsd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Doc_Tbsd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.S_Doc_Type,
            this.Create_Time,
            this.Creator,
            this.Memo,
            this.PLCode,
            this.LotNo,
            this.Reback_Over,
            this.PO,
            this.POID,
            this.Arrival_NO,
            this.Arrival_ID});
            this.dgv_Doc_Tbsd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Doc_Tbsd.Location = new System.Drawing.Point(0, 0);
            this.dgv_Doc_Tbsd.Name = "dgv_Doc_Tbsd";
            this.dgv_Doc_Tbsd.ReadOnly = true;
            this.dgv_Doc_Tbsd.RowHeadersVisible = false;
            this.dgv_Doc_Tbsd.RowTemplate.Height = 23;
            this.dgv_Doc_Tbsd.Size = new System.Drawing.Size(546, 387);
            this.dgv_Doc_Tbsd.TabIndex = 0;
            this.dgv_Doc_Tbsd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Doc_Tbsd_CellClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgv_DocMaterial_tsdm);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(546, 98);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(539, 185);
            this.panel4.TabIndex = 3;
            // 
            // dgv_DocMaterial_tsdm
            // 
            this.dgv_DocMaterial_tsdm.AllowUserToAddRows = false;
            this.dgv_DocMaterial_tsdm.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_DocMaterial_tsdm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DocMaterial_tsdm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tsdm_S_Doc_NO,
            this.MaterialCode,
            this.QTY,
            this.RowNumber,
            this.PO_DetailID});
            this.dgv_DocMaterial_tsdm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DocMaterial_tsdm.Location = new System.Drawing.Point(0, 0);
            this.dgv_DocMaterial_tsdm.Name = "dgv_DocMaterial_tsdm";
            this.dgv_DocMaterial_tsdm.ReadOnly = true;
            this.dgv_DocMaterial_tsdm.RowHeadersVisible = false;
            this.dgv_DocMaterial_tsdm.RowTemplate.Height = 23;
            this.dgv_DocMaterial_tsdm.Size = new System.Drawing.Size(539, 185);
            this.dgv_DocMaterial_tsdm.TabIndex = 0;
            this.dgv_DocMaterial_tsdm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DocMaterial_tsdm_CellClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv_Detail_tbsdd);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(546, 283);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(539, 202);
            this.panel5.TabIndex = 4;
            // 
            // dgv_Detail_tbsdd
            // 
            this.dgv_Detail_tbsdd.AllowUserToAddRows = false;
            this.dgv_Detail_tbsdd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Detail_tbsdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detail_tbsdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tbsdd_S_Doc_NO,
            this.tbsdd_MaterialCode,
            this.tbsdd_Qty,
            this.tbsdd_Create_Time,
            this.tbsdd_Creator,
            this.SerialNumber,
            this.Reback_Flag,
            this.tbsdd_RowNumber,
            this.tbsdd_PO_DetailID});
            this.dgv_Detail_tbsdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Detail_tbsdd.Location = new System.Drawing.Point(0, 0);
            this.dgv_Detail_tbsdd.Name = "dgv_Detail_tbsdd";
            this.dgv_Detail_tbsdd.ReadOnly = true;
            this.dgv_Detail_tbsdd.RowHeadersVisible = false;
            this.dgv_Detail_tbsdd.RowTemplate.Height = 23;
            this.dgv_Detail_tbsdd.Size = new System.Drawing.Size(539, 202);
            this.dgv_Detail_tbsdd.TabIndex = 0;
            // 
            // tsdm_S_Doc_NO
            // 
            this.tsdm_S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.tsdm_S_Doc_NO.HeaderText = "单据号";
            this.tsdm_S_Doc_NO.Name = "tsdm_S_Doc_NO";
            this.tsdm_S_Doc_NO.ReadOnly = true;
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
            this.QTY.HeaderText = "汇总数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            this.QTY.Width = 80;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "行号";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 145;
            // 
            // PO_DetailID
            // 
            this.PO_DetailID.DataPropertyName = "PO_DetailID";
            this.PO_DetailID.HeaderText = "采购单物料项ID";
            this.PO_DetailID.Name = "PO_DetailID";
            this.PO_DetailID.ReadOnly = true;
            this.PO_DetailID.Visible = false;
            this.PO_DetailID.Width = 111;
            // 
            // tbsdd_S_Doc_NO
            // 
            this.tbsdd_S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.tbsdd_S_Doc_NO.HeaderText = "单据号";
            this.tbsdd_S_Doc_NO.Name = "tbsdd_S_Doc_NO";
            this.tbsdd_S_Doc_NO.ReadOnly = true;
            // 
            // tbsdd_MaterialCode
            // 
            this.tbsdd_MaterialCode.DataPropertyName = "MaterialCode";
            this.tbsdd_MaterialCode.HeaderText = "料号";
            this.tbsdd_MaterialCode.Name = "tbsdd_MaterialCode";
            this.tbsdd_MaterialCode.ReadOnly = true;
            // 
            // tbsdd_Qty
            // 
            this.tbsdd_Qty.DataPropertyName = "QTY";
            this.tbsdd_Qty.HeaderText = "物料(产品)数量";
            this.tbsdd_Qty.Name = "tbsdd_Qty";
            this.tbsdd_Qty.ReadOnly = true;
            this.tbsdd_Qty.Width = 130;
            // 
            // tbsdd_Create_Time
            // 
            this.tbsdd_Create_Time.DataPropertyName = "Create_Time";
            this.tbsdd_Create_Time.HeaderText = "操作时间";
            this.tbsdd_Create_Time.Name = "tbsdd_Create_Time";
            this.tbsdd_Create_Time.ReadOnly = true;
            // 
            // tbsdd_Creator
            // 
            this.tbsdd_Creator.DataPropertyName = "Creator";
            this.tbsdd_Creator.HeaderText = "员工号";
            this.tbsdd_Creator.Name = "tbsdd_Creator";
            this.tbsdd_Creator.ReadOnly = true;
            this.tbsdd_Creator.Width = 70;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "容器SN";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // Reback_Flag
            // 
            this.Reback_Flag.DataPropertyName = "Reback_Flag";
            this.Reback_Flag.HeaderText = "是否退料";
            this.Reback_Flag.Name = "Reback_Flag";
            this.Reback_Flag.ReadOnly = true;
            // 
            // tbsdd_RowNumber
            // 
            this.tbsdd_RowNumber.DataPropertyName = "RowNumber";
            this.tbsdd_RowNumber.HeaderText = "行号";
            this.tbsdd_RowNumber.Name = "tbsdd_RowNumber";
            this.tbsdd_RowNumber.ReadOnly = true;
            // 
            // tbsdd_PO_DetailID
            // 
            this.tbsdd_PO_DetailID.DataPropertyName = "PO_DetailID";
            this.tbsdd_PO_DetailID.HeaderText = "采购单物料项ID";
            this.tbsdd_PO_DetailID.Name = "tbsdd_PO_DetailID";
            this.tbsdd_PO_DetailID.ReadOnly = true;
            this.tbsdd_PO_DetailID.Visible = false;
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
            this.S_Doc_Type.HeaderText = "单据类型";
            this.S_Doc_Type.Name = "S_Doc_Type";
            this.S_Doc_Type.ReadOnly = true;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "员工号";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.Width = 70;
            // 
            // PLCode
            // 
            this.PLCode.DataPropertyName = "PLCode";
            this.PLCode.HeaderText = "线别代码";
            this.PLCode.Name = "PLCode";
            this.PLCode.ReadOnly = true;
            // 
            // LotNo
            // 
            this.LotNo.DataPropertyName = "LotNo";
            this.LotNo.HeaderText = "批次号";
            this.LotNo.Name = "LotNo";
            this.LotNo.ReadOnly = true;
            // 
            // Reback_Over
            // 
            this.Reback_Over.DataPropertyName = "Reback_Over";
            this.Reback_Over.HeaderText = "退料结束";
            this.Reback_Over.Name = "Reback_Over";
            this.Reback_Over.ReadOnly = true;
            // 
            // PO
            // 
            this.PO.DataPropertyName = "PO";
            this.PO.HeaderText = "采购单号";
            this.PO.Name = "PO";
            this.PO.ReadOnly = true;
            // 
            // POID
            // 
            this.POID.DataPropertyName = "POID";
            this.POID.HeaderText = "采购单ID";
            this.POID.Name = "POID";
            this.POID.ReadOnly = true;
            this.POID.Visible = false;
            // 
            // Arrival_NO
            // 
            this.Arrival_NO.DataPropertyName = "Arrival_NO";
            this.Arrival_NO.HeaderText = "到货单（ERP）";
            this.Arrival_NO.Name = "Arrival_NO";
            this.Arrival_NO.ReadOnly = true;
            this.Arrival_NO.Width = 130;
            // 
            // Arrival_ID
            // 
            this.Arrival_ID.DataPropertyName = "Arrival_ID";
            this.Arrival_ID.HeaderText = "ERP回传的到货单ID";
            this.Arrival_ID.Name = "Arrival_ID";
            this.Arrival_ID.ReadOnly = true;
            this.Arrival_ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单据号";
            // 
            // txt_S_Doc_NO
            // 
            this.txt_S_Doc_NO.Location = new System.Drawing.Point(56, 19);
            this.txt_S_Doc_NO.Name = "txt_S_Doc_NO";
            this.txt_S_Doc_NO.Size = new System.Drawing.Size(132, 21);
            this.txt_S_Doc_NO.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "单据类型";
            // 
            // cbo_S_Doc_NO_Type
            // 
            this.cbo_S_Doc_NO_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_S_Doc_NO_Type.FormattingEnabled = true;
            this.cbo_S_Doc_NO_Type.Location = new System.Drawing.Point(261, 19);
            this.cbo_S_Doc_NO_Type.Name = "cbo_S_Doc_NO_Type";
            this.cbo_S_Doc_NO_Type.Size = new System.Drawing.Size(121, 20);
            this.cbo_S_Doc_NO_Type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "批次号";
            // 
            // txt_LotNo
            // 
            this.txt_LotNo.Location = new System.Drawing.Point(443, 19);
            this.txt_LotNo.Name = "txt_LotNo";
            this.txt_LotNo.Size = new System.Drawing.Size(132, 21);
            this.txt_LotNo.TabIndex = 5;
            // 
            // txt_PO
            // 
            this.txt_PO.Location = new System.Drawing.Point(648, 19);
            this.txt_PO.Name = "txt_PO";
            this.txt_PO.Size = new System.Drawing.Size(132, 21);
            this.txt_PO.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "采购单号";
            // 
            // txt_Arrival_NO
            // 
            this.txt_Arrival_NO.Location = new System.Drawing.Point(841, 19);
            this.txt_Arrival_NO.Name = "txt_Arrival_NO";
            this.txt_Arrival_NO.Size = new System.Drawing.Size(132, 21);
            this.txt_Arrival_NO.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(790, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "到货单";
            // 
            // btn_qeury
            // 
            this.btn_qeury.Location = new System.Drawing.Point(983, 18);
            this.btn_qeury.Name = "btn_qeury";
            this.btn_qeury.Size = new System.Drawing.Size(75, 23);
            this.btn_qeury.TabIndex = 10;
            this.btn_qeury.Text = "查询";
            this.btn_qeury.UseVisualStyleBackColor = true;
            this.btn_qeury.Click += new System.EventHandler(this.btn_qeury_Click);
            // 
            // ucStorageDocQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucStorageDocQuery";
            this.Size = new System.Drawing.Size(1085, 485);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Doc_Tbsd)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DocMaterial_tsdm)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail_tbsdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_Doc_Tbsd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgv_DocMaterial_tsdm;
        private System.Windows.Forms.DataGridView dgv_Detail_tbsdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn tsdm_S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO_DetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reback_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbsdd_PO_DetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reback_Over;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn POID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrival_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_S_Doc_NO;
        private System.Windows.Forms.ComboBox cbo_S_Doc_NO_Type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_LotNo;
        private System.Windows.Forms.TextBox txt_Arrival_NO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_qeury;
    }
}
