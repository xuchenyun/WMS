namespace Query.UI
{
    partial class ucMaterialLog
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
            this.btn_query = new CIT.Client.TXButton();
            this.cbo_operateType = new CIT.Client.TXComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_materialCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_serialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_materialLog = new System.Windows.Forms.DataGridView();
            this.WoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.cbo_operateType);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_materialCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_serialNumber);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 82);
            this.panel2.TabIndex = 1;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(746, 28);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 174;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // cbo_operateType
            // 
            this.cbo_operateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_operateType.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_operateType.FormattingEnabled = true;
            this.cbo_operateType.Location = new System.Drawing.Point(568, 29);
            this.cbo_operateType.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_operateType.Name = "cbo_operateType";
            this.cbo_operateType.Size = new System.Drawing.Size(155, 24);
            this.cbo_operateType.TabIndex = 173;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 172;
            this.label3.Text = "操作名称";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.Location = new System.Drawing.Point(314, 31);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Size = new System.Drawing.Size(155, 21);
            this.txt_materialCode.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 75;
            this.label2.Text = "料号";
            // 
            // txt_serialNumber
            // 
            this.txt_serialNumber.Location = new System.Drawing.Point(84, 31);
            this.txt_serialNumber.Name = "txt_serialNumber";
            this.txt_serialNumber.Size = new System.Drawing.Size(155, 21);
            this.txt_serialNumber.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "物料SN";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_materialLog);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 415);
            this.panel3.TabIndex = 2;
            // 
            // dgv_materialLog
            // 
            this.dgv_materialLog.AllowUserToAddRows = false;
            this.dgv_materialLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_materialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materialLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WoCode,
            this.SerialNumber,
            this.MaterialCode,
            this.OperateType,
            this.QTY,
            this.UserName,
            this.CreateTime,
            this.Memo});
            this.dgv_materialLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_materialLog.Location = new System.Drawing.Point(0, 0);
            this.dgv_materialLog.Name = "dgv_materialLog";
            this.dgv_materialLog.RowHeadersVisible = false;
            this.dgv_materialLog.RowTemplate.Height = 23;
            this.dgv_materialLog.Size = new System.Drawing.Size(870, 415);
            this.dgv_materialLog.TabIndex = 0;
            this.dgv_materialLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_materialLog_MouseDoubleClick);
            // 
            // WoCode
            // 
            this.WoCode.DataPropertyName = "WoCode";
            this.WoCode.HeaderText = "工单";
            this.WoCode.Name = "WoCode";
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "物料SN";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Width = 150;
            // 
            // OperateType
            // 
            this.OperateType.DataPropertyName = "OperateType";
            this.OperateType.HeaderText = "操作名称";
            this.OperateType.Name = "OperateType";
            this.OperateType.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
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
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            // 
            // ucMaterialLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ucMaterialLog";
            this.Size = new System.Drawing.Size(870, 497);
            this.Load += new System.EventHandler(this.ucMaterialLog_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_serialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_materialLog;
        private System.Windows.Forms.TextBox txt_materialCode;
        private System.Windows.Forms.Label label2;
        private CIT.Client.TXComboBox cbo_operateType;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.DataGridViewTextBoxColumn WoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
    }
}
