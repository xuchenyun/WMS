namespace Query.UI
{
    partial class ucDocQuery
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_barCode = new System.Windows.Forms.DataGridView();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receive_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Doc_NO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MaterialCode = new System.Windows.Forms.TextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SerialNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new CIT.Client.TXButton();
            this.cbo_Type = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1139, 428);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_barCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 428);
            this.panel1.TabIndex = 0;
            // 
            // dgv_barCode
            // 
            this.dgv_barCode.AllowUserToAddRows = false;
            this.dgv_barCode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_barCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_barCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.MaterialCode,
            this.SerialNumber,
            this.TYPE_NAME,
            this.QTY,
            this.Lot_No,
            this.DateCode,
            this.Creator,
            this.Create_Time,
            this.Receive_Flag});
            this.dgv_barCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_barCode.Location = new System.Drawing.Point(0, 0);
            this.dgv_barCode.Name = "dgv_barCode";
            this.dgv_barCode.RowHeadersVisible = false;
            this.dgv_barCode.RowTemplate.Height = 23;
            this.dgv_barCode.Size = new System.Drawing.Size(1139, 428);
            this.dgv_barCode.TabIndex = 0;
            this.dgv_barCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_barCode_MouseDoubleClick);
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "单据号";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
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
            this.SerialNumber.Width = 170;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.DataPropertyName = "TYPE_NAME";
            this.TYPE_NAME.HeaderText = "类型";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // Lot_No
            // 
            this.Lot_No.DataPropertyName = "Lot_No";
            this.Lot_No.HeaderText = "Lot";
            this.Lot_No.Name = "Lot_No";
            this.Lot_No.ReadOnly = true;
            // 
            // DateCode
            // 
            this.DateCode.DataPropertyName = "DateCode";
            this.DateCode.HeaderText = "DateCode";
            this.DateCode.Name = "DateCode";
            this.DateCode.ReadOnly = true;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "创建人";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            // 
            // Receive_Flag
            // 
            this.Receive_Flag.DataPropertyName = "Receive_Flag";
            this.Receive_Flag.HeaderText = "是否交接";
            this.Receive_Flag.Name = "Receive_Flag";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 149;
            this.label1.Text = "单据号";
            // 
            // txt_Doc_NO
            // 
            this.txt_Doc_NO.Location = new System.Drawing.Point(67, 41);
            this.txt_Doc_NO.Name = "txt_Doc_NO";
            this.txt_Doc_NO.Size = new System.Drawing.Size(147, 21);
            this.txt_Doc_NO.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 151;
            this.label2.Text = "料号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(733, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 153;
            this.label3.Text = "类型";
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.Location = new System.Drawing.Point(299, 41);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Size = new System.Drawing.Size(147, 21);
            this.txt_MaterialCode.TabIndex = 155;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(937, 38);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 156;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 156;
            this.label4.Text = "唯一码";
            // 
            // txt_SerialNumber
            // 
            this.txt_SerialNumber.Location = new System.Drawing.Point(552, 41);
            this.txt_SerialNumber.Name = "txt_SerialNumber";
            this.txt_SerialNumber.Size = new System.Drawing.Size(147, 21);
            this.txt_SerialNumber.TabIndex = 157;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.cbo_Type);
            this.panel2.Controls.Add(this.txt_SerialNumber);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.txt_MaterialCode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_Doc_NO);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1139, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Image = null;
            this.btnExport.Location = new System.Drawing.Point(937, 67);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 27);
            this.btnExport.TabIndex = 167;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbo_Type
            // 
            this.cbo_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Type.FormattingEnabled = true;
            this.cbo_Type.Location = new System.Drawing.Point(780, 41);
            this.cbo_Type.Name = "cbo_Type";
            this.cbo_Type.Size = new System.Drawing.Size(145, 20);
            this.cbo_Type.TabIndex = 159;
            // 
            // ucDocQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ucDocQuery";
            this.Size = new System.Drawing.Size(1139, 528);
            this.Load += new System.EventHandler(this.uc_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_barCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Doc_NO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MaterialCode;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SerialNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receive_Flag;
        private System.Windows.Forms.ComboBox cbo_Type;
        private CIT.Client.TXButton btnExport;
    }
}
