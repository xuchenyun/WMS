namespace Query.UI
{
    partial class ucIQC
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
            this.btn_query = new CIT.Client.TXButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_TimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_TimeMin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PartNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txButton1 = new CIT.Client.TXButton();
            this.dgv_barCode = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(689, 18);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 228;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 227;
            this.label5.Text = "～";
            // 
            // dtp_TimeMax
            // 
            this.dtp_TimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMax.Location = new System.Drawing.Point(515, 70);
            this.dtp_TimeMax.Name = "dtp_TimeMax";
            this.dtp_TimeMax.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMax.TabIndex = 226;
            // 
            // dtp_TimeMin
            // 
            this.dtp_TimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMin.Location = new System.Drawing.Point(364, 70);
            this.dtp_TimeMin.Name = "dtp_TimeMin";
            this.dtp_TimeMin.Size = new System.Drawing.Size(129, 26);
            this.dtp_TimeMin.TabIndex = 225;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 224;
            this.label4.Text = "送检日期";
            // 
            // txt_PartNumber
            // 
            this.txt_PartNumber.Location = new System.Drawing.Point(278, 22);
            this.txt_PartNumber.Name = "txt_PartNumber";
            this.txt_PartNumber.Size = new System.Drawing.Size(147, 21);
            this.txt_PartNumber.TabIndex = 223;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 222;
            this.label2.Text = "料号";
            // 
            // txt_BillNo
            // 
            this.txt_BillNo.Location = new System.Drawing.Point(86, 22);
            this.txt_BillNo.Name = "txt_BillNo";
            this.txt_BillNo.Size = new System.Drawing.Size(147, 21);
            this.txt_BillNo.TabIndex = 221;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 220;
            this.label1.Text = "检验单编号";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(499, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 21);
            this.textBox1.TabIndex = 232;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 231;
            this.label3.Text = "采购号";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(147, 21);
            this.textBox2.TabIndex = 230;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 229;
            this.label6.Text = "判断结果";
            // 
            // txButton1
            // 
            this.txButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txButton1.Image = null;
            this.txButton1.Location = new System.Drawing.Point(22, 133);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(81, 27);
            this.txButton1.TabIndex = 233;
            this.txButton1.Text = "打印";
            this.txButton1.UseVisualStyleBackColor = true;
            // 
            // dgv_barCode
            // 
            this.dgv_barCode.AllowUserToAddRows = false;
            this.dgv_barCode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_barCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_barCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.No,
            this.BillType,
            this.Column1,
            this.InstockNo,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgv_barCode.Location = new System.Drawing.Point(22, 173);
            this.dgv_barCode.Name = "dgv_barCode";
            this.dgv_barCode.RowHeadersVisible = false;
            this.dgv_barCode.RowTemplate.Height = 23;
            this.dgv_barCode.Size = new System.Drawing.Size(783, 186);
            this.dgv_barCode.TabIndex = 234;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView1.Location = new System.Drawing.Point(22, 375);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(783, 186);
            this.dataGridView1.TabIndex = 235;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "No";
            this.dataGridViewTextBoxColumn1.HeaderText = "PO单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BillType";
            this.dataGridViewTextBoxColumn2.HeaderText = "行号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "料号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InstockNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "批次号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "送检数";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "判断结果";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 110;
            // 
            // checkbox
            // 
            this.checkbox.HeaderText = "";
            this.checkbox.Name = "checkbox";
            this.checkbox.Width = 50;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "检验单编号";
            this.No.Name = "No";
            this.No.Width = 110;
            // 
            // BillType
            // 
            this.BillType.DataPropertyName = "BillType";
            this.BillType.HeaderText = "采购单号";
            this.BillType.Name = "BillType";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "质检库位";
            this.Column1.Name = "Column1";
            // 
            // InstockNo
            // 
            this.InstockNo.DataPropertyName = "InstockNo";
            this.InstockNo.HeaderText = "创建人";
            this.InstockNo.Name = "InstockNo";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "创建时间";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "状态";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "是否同步ERP";
            this.Column4.Name = "Column4";
            // 
            // ucIQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgv_barCode);
            this.Controls.Add(this.txButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp_TimeMax);
            this.Controls.Add(this.dtp_TimeMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_PartNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_BillNo);
            this.Controls.Add(this.label1);
            this.Name = "ucIQC";
            this.Size = new System.Drawing.Size(939, 594);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_TimeMax;
        private System.Windows.Forms.DateTimePicker dtp_TimeMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_PartNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BillNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private CIT.Client.TXButton txButton1;
        private System.Windows.Forms.DataGridView dgv_barCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
