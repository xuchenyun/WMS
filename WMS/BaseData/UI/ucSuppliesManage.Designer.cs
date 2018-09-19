namespace BaseData.UI
{
    partial class ucSuppliesManage
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
            this.txt_suppliesCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_suppliesName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSupplies = new System.Windows.Forms.DataGridView();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.top_outHouse = new CIT.Client.TXToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplies)).BeginInit();
            this.panel2.SuspendLayout();
            this.top_outHouse.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_suppliesCode
            // 
            this.txt_suppliesCode.Location = new System.Drawing.Point(332, 21);
            this.txt_suppliesCode.Name = "txt_suppliesCode";
            this.txt_suppliesCode.Size = new System.Drawing.Size(155, 21);
            this.txt_suppliesCode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "供应商代码";
            // 
            // txt_suppliesName
            // 
            this.txt_suppliesName.Location = new System.Drawing.Point(83, 21);
            this.txt_suppliesName.Name = "txt_suppliesName";
            this.txt_suppliesName.Size = new System.Drawing.Size(155, 21);
            this.txt_suppliesName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "供应商名称";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(510, 21);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 0;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSupplies);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(883, 406);
            this.panel3.TabIndex = 5;
            // 
            // dgvSupplies
            // 
            this.dgvSupplies.AllowUserToAddRows = false;
            this.dgvSupplies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSupplies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierName,
            this.SupplierCode});
            this.dgvSupplies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplies.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplies.Name = "dgvSupplies";
            this.dgvSupplies.ReadOnly = true;
            this.dgvSupplies.RowHeadersVisible = false;
            this.dgvSupplies.RowTemplate.Height = 23;
            this.dgvSupplies.Size = new System.Drawing.Size(883, 406);
            this.dgvSupplies.TabIndex = 0;
            // 
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "供应商名称";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // SupplierCode
            // 
            this.SupplierCode.DataPropertyName = "SupplierCode";
            this.SupplierCode.HeaderText = "供应商代码";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_suppliesCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_suppliesName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 73);
            this.panel2.TabIndex = 4;
            // 
            // btn_del
            // 
            this.btn_del.Image = global::BaseData.Properties.Resources.delbinding;
            this.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(52, 27);
            this.btn_del.Text = "删除";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = global::BaseData.Properties.Resources.slot;
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(52, 27);
            this.btn_edit.Text = "编辑";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_add
            // 
            this.btn_add.Image = global::BaseData.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(52, 27);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // top_outHouse
            // 
            this.top_outHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.top_outHouse.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.top_outHouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.top_outHouse.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.top_outHouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_edit,
            this.btn_del});
            this.top_outHouse.Location = new System.Drawing.Point(0, 0);
            this.top_outHouse.Name = "top_outHouse";
            this.top_outHouse.Size = new System.Drawing.Size(883, 30);
            this.top_outHouse.TabIndex = 8;
            this.top_outHouse.Text = "txToolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.top_outHouse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 30);
            this.panel1.TabIndex = 3;
            // 
            // ucSuppliesManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucSuppliesManage";
            this.Size = new System.Drawing.Size(883, 509);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplies)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.top_outHouse.ResumeLayout(false);
            this.top_outHouse.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_suppliesCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_suppliesName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSupplies;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btn_del;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_add;
        private CIT.Client.TXToolStrip top_outHouse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCode;
    }
}
