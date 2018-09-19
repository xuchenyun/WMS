namespace CIT.WMS.BRIO
{
    partial class ucMateBinding
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tol_add = new System.Windows.Forms.ToolStripButton();
            this.tol_edit = new System.Windows.Forms.ToolStripButton();
            this.tol_del = new System.Windows.Forms.ToolStripButton();
            this.tol_Import = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_search = new CIT.Client.TXTextBox();
            this.pagerControl1 = new CIT.uControl.PagerControl();
            this.txToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.tol_add,
            this.tol_edit,
            this.tol_del,
            this.tol_Import});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(632, 25);
            this.txToolStrip1.TabIndex = 1;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CIT.MES.Properties.Resources.refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "刷新";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tol_add
            // 
            this.tol_add.Image = global::CIT.MES.Properties.Resources.add;
            this.tol_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_add.Name = "tol_add";
            this.tol_add.Size = new System.Drawing.Size(52, 22);
            this.tol_add.Text = "新增";
            this.tol_add.Click += new System.EventHandler(this.tol_add_Click);
            // 
            // tol_edit
            // 
            this.tol_edit.Image = global::CIT.MES.Properties.Resources.edit;
            this.tol_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_edit.Name = "tol_edit";
            this.tol_edit.Size = new System.Drawing.Size(52, 22);
            this.tol_edit.Text = "编辑";
            this.tol_edit.Click += new System.EventHandler(this.tol_edit_Click);
            // 
            // tol_del
            // 
            this.tol_del.Image = global::CIT.MES.Properties.Resources.delbinding;
            this.tol_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_del.Name = "tol_del";
            this.tol_del.Size = new System.Drawing.Size(52, 22);
            this.tol_del.Text = "删除";
            this.tol_del.Click += new System.EventHandler(this.tol_del_Click);
            // 
            // tol_Import
            // 
            this.tol_Import.Image = global::CIT.MES.Properties.Resources.aync_wo;
            this.tol_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tol_Import.Name = "tol_Import";
            this.tol_Import.Size = new System.Drawing.Size(52, 22);
            this.tol_Import.Text = "导入";
            this.tol_Import.Click += new System.EventHandler(this.tol_Import_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 21;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(632, 326);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_search.BackColor = System.Drawing.Color.Transparent;
            this.txt_search.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_search.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_search.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_search.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_search.Image = null;
            this.txt_search.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_search.Location = new System.Drawing.Point(449, 3);
            this.txt_search.Name = "txt_search";
            this.txt_search.Padding = new System.Windows.Forms.Padding(2);
            this.txt_search.PasswordChar = '\0';
            this.txt_search.Required = false;
            this.txt_search.Size = new System.Drawing.Size(180, 22);
            this.txt_search.TabIndex = 4;
            this.txt_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_search_KeyPress);
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.DisplayCount = 0;
            this.pagerControl1.Location = new System.Drawing.Point(0, 354);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.Size = new System.Drawing.Size(632, 38);
            this.pagerControl1.TabIndex = 3;
            // 
            // ucMateBinding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txToolStrip1);
            this.Name = "ucMateBinding";
            this.Size = new System.Drawing.Size(632, 392);
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tol_add;
        private System.Windows.Forms.ToolStripButton tol_edit;
        private System.Windows.Forms.ToolStripButton tol_del;
        private System.Windows.Forms.DataGridView dataGridView1;
        private uControl.PagerControl pagerControl1;
        private Client.TXTextBox txt_search;
        private System.Windows.Forms.ToolStripButton tol_Import;
    }
}
