namespace Query.UI
{
    partial class ucDocCollectQuery
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.txt_Doc_NO = new CIT.Client.TXTextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.cbo_DocType = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_materialCode = new CIT.Client.TXTextBox();
            this.lbl_typeName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_DocCollect = new System.Windows.Forms.DataGridView();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tol_del = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DocCollect)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txt_Doc_NO);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.cbo_DocType);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_materialCode);
            this.panel1.Controls.Add(this.lbl_typeName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txToolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1040, 32);
            this.panel3.TabIndex = 168;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.tol_del});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(1040, 31);
            this.txToolStrip1.TabIndex = 159;
            this.txToolStrip1.Text = "txToolStrip1";
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
            // txt_Doc_NO
            // 
            this.txt_Doc_NO.BackColor = System.Drawing.Color.Transparent;
            this.txt_Doc_NO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Doc_NO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Doc_NO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Doc_NO.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Doc_NO.Image = null;
            this.txt_Doc_NO.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Doc_NO.Location = new System.Drawing.Point(90, 55);
            this.txt_Doc_NO.Name = "txt_Doc_NO";
            this.txt_Doc_NO.Padding = new System.Windows.Forms.Padding(2);
            this.txt_Doc_NO.PasswordChar = '\0';
            this.txt_Doc_NO.Required = false;
            this.txt_Doc_NO.Size = new System.Drawing.Size(201, 27);
            this.txt_Doc_NO.TabIndex = 167;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(908, 56);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 166;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cbo_DocType
            // 
            this.cbo_DocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_DocType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_DocType.FormattingEnabled = true;
            this.cbo_DocType.Location = new System.Drawing.Point(673, 58);
            this.cbo_DocType.Name = "cbo_DocType";
            this.cbo_DocType.Size = new System.Drawing.Size(203, 24);
            this.cbo_DocType.TabIndex = 164;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(597, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 163;
            this.label2.Text = "单据类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(318, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 162;
            this.label1.Text = "料号";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_materialCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_materialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_materialCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_materialCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_materialCode.Image = null;
            this.txt_materialCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_materialCode.Location = new System.Drawing.Point(382, 56);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_materialCode.PasswordChar = '\0';
            this.txt_materialCode.Required = false;
            this.txt_materialCode.Size = new System.Drawing.Size(201, 27);
            this.txt_materialCode.TabIndex = 161;
            // 
            // lbl_typeName
            // 
            this.lbl_typeName.AutoSize = true;
            this.lbl_typeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeName.Location = new System.Drawing.Point(12, 60);
            this.lbl_typeName.Name = "lbl_typeName";
            this.lbl_typeName.Size = new System.Drawing.Size(56, 16);
            this.lbl_typeName.TabIndex = 160;
            this.lbl_typeName.Text = "单据号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_DocCollect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 494);
            this.panel2.TabIndex = 1;
            // 
            // dgv_DocCollect
            // 
            this.dgv_DocCollect.AllowUserToAddRows = false;
            this.dgv_DocCollect.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_DocCollect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DocCollect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.TYPE_NAME,
            this.PO,
            this.UserName,
            this.CreateTime,
            this.MaterialCode,
            this.QTY,
            this.RowNumber});
            this.dgv_DocCollect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DocCollect.Location = new System.Drawing.Point(0, 0);
            this.dgv_DocCollect.Name = "dgv_DocCollect";
            this.dgv_DocCollect.RowHeadersVisible = false;
            this.dgv_DocCollect.RowTemplate.Height = 23;
            this.dgv_DocCollect.Size = new System.Drawing.Size(1040, 494);
            this.dgv_DocCollect.TabIndex = 0;
            this.dgv_DocCollect.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_DocCollect_MouseDoubleClick);
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "单据号";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.DataPropertyName = "TYPE_NAME";
            this.TYPE_NAME.HeaderText = "类型";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            // 
            // PO
            // 
            this.PO.DataPropertyName = "PO";
            this.PO.HeaderText = "采购单号";
            this.PO.Name = "PO";
            this.PO.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "创建人";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "Create_Time";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
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
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "行号";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            // 
            // tol_del
            // 
            this.tol_del.Image = global::Query.Properties.Resources.delbinding;
            this.tol_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_del.Name = "tol_del";
            this.tol_del.Size = new System.Drawing.Size(60, 28);
            this.tol_del.Text = "删除";
            this.tol_del.Click += new System.EventHandler(this.tol_del_Click);
            // 
            // ucDocCollectQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucDocCollectQuery";
            this.Size = new System.Drawing.Size(1040, 594);
            this.Load += new System.EventHandler(this.ucDocCollectQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DocCollect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXComboBox cbo_DocType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXTextBox txt_materialCode;
        private System.Windows.Forms.Label lbl_typeName;
        private CIT.Client.TXTextBox txt_Doc_NO;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.DataGridView dgv_DocCollect;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton tol_del;
    }
}
