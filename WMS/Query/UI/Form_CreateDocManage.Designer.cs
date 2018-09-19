namespace Query.UI
{
    partial class Form_CreateDocManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tol_del = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_TypeCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_doc = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbStorage = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_Storage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.S_Doc_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doc)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tol_del
            // 
            this.tol_del.Name = "tol_del";
            this.tol_del.Size = new System.Drawing.Size(100, 22);
            this.tol_del.Text = "删除";
            this.tol_del.Click += new System.EventHandler(this.tol_del_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(819, 15);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(38, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(681, 16);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(132, 21);
            this.txtQuantity.TabIndex = 7;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(646, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "数量";
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(482, 16);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(142, 21);
            this.txtMaterialCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "料号";
            // 
            // cbo_TypeCode
            // 
            this.cbo_TypeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TypeCode.FormattingEnabled = true;
            this.cbo_TypeCode.Location = new System.Drawing.Point(305, 16);
            this.cbo_TypeCode.Name = "cbo_TypeCode";
            this.cbo_TypeCode.Size = new System.Drawing.Size(121, 20);
            this.cbo_TypeCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "采购类型";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_doc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(944, 293);
            this.panel3.TabIndex = 5;
            // 
            // dgv_doc
            // 
            this.dgv_doc.AllowUserToAddRows = false;
            this.dgv_doc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_doc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.Source_Storage,
            this.S_Doc_Type,
            this.EmployeeCode,
            this.MaterialCode,
            this.Quantity});
            this.dgv_doc.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_doc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_doc.Location = new System.Drawing.Point(0, 0);
            this.dgv_doc.Name = "dgv_doc";
            this.dgv_doc.ReadOnly = true;
            this.dgv_doc.RowHeadersVisible = false;
            this.dgv_doc.RowTemplate.Height = 23;
            this.dgv_doc.Size = new System.Drawing.Size(944, 293);
            this.dgv_doc.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tol_del});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbStorage);
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Controls.Add(this.txtQuantity);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtMaterialCode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbo_TypeCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 64);
            this.panel2.TabIndex = 4;
            // 
            // cmbStorage
            // 
            this.cmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStorage.FormattingEnabled = true;
            this.cmbStorage.Location = new System.Drawing.Point(83, 16);
            this.cmbStorage.Name = "cmbStorage";
            this.cmbStorage.Size = new System.Drawing.Size(121, 20);
            this.cmbStorage.TabIndex = 9;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(25, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 52);
            this.panel1.TabIndex = 3;
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "采购订单编号";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
            // 
            // Source_Storage
            // 
            this.Source_Storage.DataPropertyName = "Source_Storage";
            this.Source_Storage.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Source_Storage.HeaderText = "仓库";
            this.Source_Storage.Name = "Source_Storage";
            this.Source_Storage.ReadOnly = true;
            this.Source_Storage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Source_Storage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // S_Doc_Type
            // 
            this.S_Doc_Type.DataPropertyName = "S_Doc_Type";
            this.S_Doc_Type.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.S_Doc_Type.HeaderText = "采购类型";
            this.S_Doc_Type.Name = "S_Doc_Type";
            this.S_Doc_Type.ReadOnly = true;
            this.S_Doc_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.S_Doc_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.DataPropertyName = "EmployeeCode";
            this.EmployeeCode.HeaderText = "员工号";
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.ReadOnly = true;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Form_CreateDocManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 409);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_CreateDocManage";
            this.Text = "开单";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_doc)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tol_del;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_TypeCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_doc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbStorage;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewComboBoxColumn Source_Storage;
        private System.Windows.Forms.DataGridViewComboBoxColumn S_Doc_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}