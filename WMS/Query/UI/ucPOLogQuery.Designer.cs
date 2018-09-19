namespace Query.UI
{
    partial class ucPOLogQuery
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_potype = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.txt_SupplierCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_po = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.tol_del = new System.Windows.Forms.ToolStripButton();
            this.tsbRelPrint = new System.Windows.Forms.ToolStripButton();
            this.tsb_repeatPrint = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_po = new System.Windows.Forms.DataGridView();
            this.POID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_po)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 97);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtMaterialCode);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cbo_potype);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btn_query);
            this.panel4.Controls.Add(this.txt_SupplierCode);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txt_po);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1143, 64);
            this.panel4.TabIndex = 1;
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(475, 32);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(172, 21);
            this.txtMaterialCode.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "料号";
            // 
            // cbo_potype
            // 
            this.cbo_potype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_potype.FormattingEnabled = true;
            this.cbo_potype.Location = new System.Drawing.Point(98, 32);
            this.cbo_potype.Name = "cbo_potype";
            this.cbo_potype.Size = new System.Drawing.Size(121, 20);
            this.cbo_potype.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "采购类型编码";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(693, 31);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(84, 23);
            this.btn_query.TabIndex = 11;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_SupplierCode
            // 
            this.txt_SupplierCode.Location = new System.Drawing.Point(475, 6);
            this.txt_SupplierCode.Name = "txt_SupplierCode";
            this.txt_SupplierCode.Size = new System.Drawing.Size(172, 21);
            this.txt_SupplierCode.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "供应商编码";
            // 
            // txt_po
            // 
            this.txt_po.Location = new System.Drawing.Point(98, 6);
            this.txt_po.Name = "txt_po";
            this.txt_po.Size = new System.Drawing.Size(190, 21);
            this.txt_po.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "采购订单编号";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txToolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1143, 33);
            this.panel3.TabIndex = 0;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.tol_del,
            this.tsbRelPrint,
            this.tsb_repeatPrint});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(1143, 31);
            this.txToolStrip1.TabIndex = 154;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::Query.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 28);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
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
            // tsbRelPrint
            // 
            this.tsbRelPrint.Image = global::Query.Properties.Resources.png_0649;
            this.tsbRelPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRelPrint.Name = "tsbRelPrint";
            this.tsbRelPrint.Size = new System.Drawing.Size(84, 28);
            this.tsbRelPrint.Text = "来料打印";
            this.tsbRelPrint.Click += new System.EventHandler(this.tsbRelPrint_Click);
            // 
            // tsb_repeatPrint
            // 
            this.tsb_repeatPrint.Image = global::Query.Properties.Resources.png_0649;
            this.tsb_repeatPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_repeatPrint.Name = "tsb_repeatPrint";
            this.tsb_repeatPrint.Size = new System.Drawing.Size(84, 28);
            this.tsb_repeatPrint.Text = "标签重打";
            this.tsb_repeatPrint.Click += new System.EventHandler(this.tsb_repeatPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_po);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1143, 404);
            this.panel2.TabIndex = 1;
            // 
            // dgv_po
            // 
            this.dgv_po.AllowUserToAddRows = false;
            this.dgv_po.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_po.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_po.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POID});
            this.dgv_po.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_po.Location = new System.Drawing.Point(0, 0);
            this.dgv_po.Name = "dgv_po";
            this.dgv_po.ReadOnly = true;
            this.dgv_po.RowHeadersVisible = false;
            this.dgv_po.RowTemplate.Height = 23;
            this.dgv_po.Size = new System.Drawing.Size(1143, 404);
            this.dgv_po.TabIndex = 0;
            // 
            // POID
            // 
            this.POID.DataPropertyName = "POID";
            this.POID.HeaderText = "POID";
            this.POID.Name = "POID";
            this.POID.ReadOnly = true;
            this.POID.Visible = false;
            // 
            // ucPOLogQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucPOLogQuery";
            this.Size = new System.Drawing.Size(1143, 501);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_po)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_po;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbo_potype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.TextBox txt_SupplierCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_po;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton tol_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn POID;
        private System.Windows.Forms.ToolStripButton tsbRelPrint;
        private System.Windows.Forms.ToolStripButton tsb_repeatPrint;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.Label label4;
    }
}
