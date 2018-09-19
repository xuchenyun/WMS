namespace Common.UI
{
    partial class FrmProductCode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_ProductCode = new CIT.Client.TXTextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.lbl_materialCode = new System.Windows.Forms.Label();
            this.Fguid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_no);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.dgv_product);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 369);
            this.panel1.TabIndex = 0;
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(595, 324);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(73, 29);
            this.btn_no.TabIndex = 123;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(516, 324);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 29);
            this.btn_ok.TabIndex = 122;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // dgv_product
            // 
            this.dgv_product.AllowUserToAddRows = false;
            this.dgv_product.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_product.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fguid,
            this.ProductCode,
            this.ProductName});
            this.dgv_product.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_product.Location = new System.Drawing.Point(0, 39);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowHeadersVisible = false;
            this.dgv_product.RowTemplate.Height = 23;
            this.dgv_product.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_product.Size = new System.Drawing.Size(677, 275);
            this.dgv_product.TabIndex = 0;
            this.dgv_product.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_product_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_ProductCode);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.lbl_materialCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 39);
            this.panel2.TabIndex = 127;
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_ProductCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_ProductCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ProductCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ProductCode.Image = null;
            this.txt_ProductCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ProductCode.Location = new System.Drawing.Point(93, 7);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_ProductCode.PasswordChar = '\0';
            this.txt_ProductCode.Required = false;
            this.txt_ProductCode.Size = new System.Drawing.Size(150, 27);
            this.txt_ProductCode.TabIndex = 124;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(261, 6);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 28);
            this.btn_query.TabIndex = 126;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_materialCode
            // 
            this.lbl_materialCode.AutoSize = true;
            this.lbl_materialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_materialCode.Location = new System.Drawing.Point(17, 12);
            this.lbl_materialCode.Name = "lbl_materialCode";
            this.lbl_materialCode.Size = new System.Drawing.Size(72, 16);
            this.lbl_materialCode.TabIndex = 125;
            this.lbl_materialCode.Text = "产品代码";
            // 
            // Fguid
            // 
            this.Fguid.DataPropertyName = "Fguid";
            this.Fguid.HeaderText = "标识列";
            this.Fguid.Name = "Fguid";
            this.Fguid.Visible = false;
            // 
            // ProductCode
            // 
            this.ProductCode.DataPropertyName = "ProductCode";
            this.ProductCode.HeaderText = "产品代码";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.ReadOnly = true;
            this.ProductCode.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "产品名称";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // FrmProductCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 397);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmProductCode";
            this.Text = "产品选择";
            this.Load += new System.EventHandler(this.FrmProductCode_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_product;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXTextBox txt_ProductCode;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_materialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fguid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
    }
}