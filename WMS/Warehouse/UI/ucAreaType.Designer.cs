namespace Warehouse.UI
{
    partial class ucAreaType
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
            this.dgv_stockAll = new System.Windows.Forms.DataGridView();
            this.Guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Delete = new CIT.Client.TXButton();
            this.txt_TypeSN = new System.Windows.Forms.TextBox();
            this.btn_Edit = new CIT.Client.TXButton();
            this.btn_Add = new CIT.Client.TXButton();
            this.lbl_AreaType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TypeName = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stockAll)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_stockAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 404);
            this.panel2.TabIndex = 1;
            // 
            // dgv_stockAll
            // 
            this.dgv_stockAll.AllowUserToAddRows = false;
            this.dgv_stockAll.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_stockAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stockAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Guid,
            this.TypeSN,
            this.TypeName,
            this.Remark});
            this.dgv_stockAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_stockAll.Location = new System.Drawing.Point(0, 0);
            this.dgv_stockAll.Name = "dgv_stockAll";
            this.dgv_stockAll.ReadOnly = true;
            this.dgv_stockAll.RowHeadersVisible = false;
            this.dgv_stockAll.RowTemplate.Height = 23;
            this.dgv_stockAll.Size = new System.Drawing.Size(847, 404);
            this.dgv_stockAll.TabIndex = 0;
            this.dgv_stockAll.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_stockAll_MouseDoubleClick);
            // 
            // Guid
            // 
            this.Guid.DataPropertyName = "Guid";
            this.Guid.HeaderText = "Guid";
            this.Guid.Name = "Guid";
            this.Guid.ReadOnly = true;
            this.Guid.Visible = false;
            // 
            // TypeSN
            // 
            this.TypeSN.DataPropertyName = "TypeSN";
            this.TypeSN.HeaderText = "类型SN";
            this.TypeSN.Name = "TypeSN";
            this.TypeSN.ReadOnly = true;
            this.TypeSN.Width = 150;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "类型名称";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            this.TypeName.Width = 150;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 255;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 149;
            this.label1.Text = "备注";
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(358, 22);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(177, 21);
            this.txt_Remark.TabIndex = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_TypeName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Delete);
            this.panel1.Controls.Add(this.txt_TypeSN);
            this.panel1.Controls.Add(this.btn_Edit);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.lbl_AreaType);
            this.panel1.Controls.Add(this.txt_Remark);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 122);
            this.panel1.TabIndex = 0;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.Image = null;
            this.btn_Delete.Location = new System.Drawing.Point(736, 63);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(81, 27);
            this.btn_Delete.TabIndex = 170;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // txt_TypeSN
            // 
            this.txt_TypeSN.Location = new System.Drawing.Point(93, 22);
            this.txt_TypeSN.Name = "txt_TypeSN";
            this.txt_TypeSN.Size = new System.Drawing.Size(177, 21);
            this.txt_TypeSN.TabIndex = 169;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit.Image = null;
            this.btn_Edit.Location = new System.Drawing.Point(649, 63);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(81, 27);
            this.btn_Edit.TabIndex = 168;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Add.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.Image = null;
            this.btn_Add.Location = new System.Drawing.Point(562, 63);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(81, 27);
            this.btn_Add.TabIndex = 167;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbl_AreaType
            // 
            this.lbl_AreaType.AutoSize = true;
            this.lbl_AreaType.Location = new System.Drawing.Point(25, 25);
            this.lbl_AreaType.Name = "lbl_AreaType";
            this.lbl_AreaType.Size = new System.Drawing.Size(41, 12);
            this.lbl_AreaType.TabIndex = 165;
            this.lbl_AreaType.Text = "类型SN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 171;
            this.label2.Text = "类型名称";
            // 
            // txt_TypeName
            // 
            this.txt_TypeName.Location = new System.Drawing.Point(93, 54);
            this.txt_TypeName.Name = "txt_TypeName";
            this.txt_TypeName.Size = new System.Drawing.Size(177, 21);
            this.txt_TypeName.TabIndex = 172;
            // 
            // ucAreaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucAreaType";
            this.Size = new System.Drawing.Size(847, 526);
            this.Load += new System.EventHandler(this.ucStockAll_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stockAll)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_stockAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_AreaType;
        private CIT.Client.TXButton btn_Add;
        private CIT.Client.TXButton btn_Edit;
        private CIT.Client.TXButton btn_Delete;
        private System.Windows.Forms.TextBox txt_TypeSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.TextBox txt_TypeName;
        private System.Windows.Forms.Label label2;
    }
}
