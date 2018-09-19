namespace BaseData.UI
{
    partial class ucMaterialRelation
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
            this.tspMenu = new CIT.Client.TXToolStrip();
            this.tol_add = new System.Windows.Forms.ToolStripButton();
            this.tol_del = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtSupply = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupplyMaterial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tsb_edit = new System.Windows.Forms.ToolStripButton();
            this.TBMR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplyMaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tspMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tspMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 32);
            this.panel1.TabIndex = 0;
            // 
            // tspMenu
            // 
            this.tspMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tspMenu.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tspMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tspMenu.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tspMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tol_add,
            this.tsb_edit,
            this.tol_del});
            this.tspMenu.Location = new System.Drawing.Point(0, 0);
            this.tspMenu.Name = "tspMenu";
            this.tspMenu.Size = new System.Drawing.Size(875, 32);
            this.tspMenu.TabIndex = 8;
            this.tspMenu.Text = "txToolStrip1";
            // 
            // tol_add
            // 
            this.tol_add.Image = global::BaseData.Properties.Resources.add;
            this.tol_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_add.Name = "tol_add";
            this.tol_add.Size = new System.Drawing.Size(60, 29);
            this.tol_add.Text = "新增";
            this.tol_add.Click += new System.EventHandler(this.tol_add_Click);
            // 
            // tol_del
            // 
            this.tol_del.Image = global::BaseData.Properties.Resources.delbinding;
            this.tol_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_del.Name = "tol_del";
            this.tol_del.Size = new System.Drawing.Size(60, 29);
            this.tol_del.Text = "删除";
            this.tol_del.Click += new System.EventHandler(this.tol_del_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.txtSupply);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSupplyMaterial);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtLocalMaterial);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 62);
            this.panel2.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(764, 19);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtSupply
            // 
            this.txtSupply.Location = new System.Drawing.Point(562, 20);
            this.txtSupply.Name = "txtSupply";
            this.txtSupply.Size = new System.Drawing.Size(148, 21);
            this.txtSupply.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "供应商编码";
            // 
            // txtSupplyMaterial
            // 
            this.txtSupplyMaterial.Location = new System.Drawing.Point(322, 20);
            this.txtSupplyMaterial.Name = "txtSupplyMaterial";
            this.txtSupplyMaterial.Size = new System.Drawing.Size(148, 21);
            this.txtSupplyMaterial.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "供应商料号";
            // 
            // txtLocalMaterial
            // 
            this.txtLocalMaterial.Location = new System.Drawing.Point(77, 20);
            this.txtLocalMaterial.Name = "txtLocalMaterial";
            this.txtLocalMaterial.Size = new System.Drawing.Size(148, 21);
            this.txtLocalMaterial.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "本厂料号";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(875, 359);
            this.panel3.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TBMR_ID,
            this.LocalMaterialCode,
            this.SupplyMaterialCode,
            this.Supply,
            this.Remark});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(875, 359);
            this.dgvData.TabIndex = 0;
            // 
            // tsb_edit
            // 
            this.tsb_edit.Image = global::BaseData.Properties.Resources.edit;
            this.tsb_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_edit.Name = "tsb_edit";
            this.tsb_edit.Size = new System.Drawing.Size(60, 29);
            this.tsb_edit.Text = "编辑";
            this.tsb_edit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // TBMR_ID
            // 
            this.TBMR_ID.DataPropertyName = "TBMR_ID";
            this.TBMR_ID.HeaderText = "TBMR_ID";
            this.TBMR_ID.Name = "TBMR_ID";
            this.TBMR_ID.ReadOnly = true;
            this.TBMR_ID.Visible = false;
            // 
            // LocalMaterialCode
            // 
            this.LocalMaterialCode.DataPropertyName = "LocalMaterialCode";
            this.LocalMaterialCode.HeaderText = "本厂料号";
            this.LocalMaterialCode.Name = "LocalMaterialCode";
            this.LocalMaterialCode.ReadOnly = true;
            this.LocalMaterialCode.Width = 180;
            // 
            // SupplyMaterialCode
            // 
            this.SupplyMaterialCode.DataPropertyName = "SupplyMaterialCode";
            this.SupplyMaterialCode.HeaderText = "供应商料号";
            this.SupplyMaterialCode.Name = "SupplyMaterialCode";
            this.SupplyMaterialCode.ReadOnly = true;
            this.SupplyMaterialCode.Width = 180;
            // 
            // Supply
            // 
            this.Supply.DataPropertyName = "Supply";
            this.Supply.HeaderText = "供应商代码";
            this.Supply.Name = "Supply";
            this.Supply.ReadOnly = true;
            this.Supply.Width = 180;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 180;
            // 
            // ucMaterialRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMaterialRelation";
            this.Size = new System.Drawing.Size(875, 453);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tspMenu.ResumeLayout(false);
            this.tspMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXToolStrip tspMenu;
        private System.Windows.Forms.ToolStripButton tol_add;
        private System.Windows.Forms.ToolStripButton tol_del;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtSupplyMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ToolStripButton tsb_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBMR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplyMaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}
