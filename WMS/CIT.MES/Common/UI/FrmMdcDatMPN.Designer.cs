namespace Common.UI
{
    partial class FrmMdcDatMPN
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
            this.dgv_mdmt = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_query = new CIT.Client.TXButton();
            this.lbl_materialCode = new System.Windows.Forms.Label();
            this.txt_materialCode = new CIT.Client.TXTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mdmt)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_mdmt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 112);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 429);
            this.panel1.TabIndex = 1;
            // 
            // dgv_mdmt
            // 
            this.dgv_mdmt.AllowUserToAddRows = false;
            this.dgv_mdmt.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_mdmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_mdmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mdmt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv_mdmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_mdmt.Location = new System.Drawing.Point(0, 0);
            this.dgv_mdmt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_mdmt.Name = "dgv_mdmt";
            this.dgv_mdmt.RowHeadersVisible = false;
            this.dgv_mdmt.RowTemplate.Height = 23;
            this.dgv_mdmt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mdmt.Size = new System.Drawing.Size(539, 429);
            this.dgv_mdmt.TabIndex = 0;
            this.dgv_mdmt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_mdmt_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.lbl_materialCode);
            this.panel2.Controls.Add(this.txt_materialCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 72);
            this.panel2.TabIndex = 2;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(374, -1);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(110, 58);
            this.btn_query.TabIndex = 81;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_materialCode
            // 
            this.lbl_materialCode.AutoSize = true;
            this.lbl_materialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_materialCode.Location = new System.Drawing.Point(52, 20);
            this.lbl_materialCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_materialCode.Name = "lbl_materialCode";
            this.lbl_materialCode.Size = new System.Drawing.Size(58, 24);
            this.lbl_materialCode.TabIndex = 80;
            this.lbl_materialCode.Text = "料号";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_materialCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_materialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_materialCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_materialCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_materialCode.Image = null;
            this.txt_materialCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_materialCode.Location = new System.Drawing.Point(122, 12);
            this.txt_materialCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_materialCode.PasswordChar = '\0';
            this.txt_materialCode.Required = false;
            this.txt_materialCode.Size = new System.Drawing.Size(225, 40);
            this.txt_materialCode.TabIndex = 79;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_no);
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 541);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 171);
            this.panel3.TabIndex = 3;
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(393, 89);
            this.btn_no.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(110, 58);
            this.btn_no.TabIndex = 78;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(275, 89);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(110, 58);
            this.btn_ok.TabIndex = 77;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "MaterialCode";
            this.Column1.HeaderText = "物料代码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaterialName";
            this.Column2.HeaderText = "物料名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            this.Column2.Width = 180;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Spec";
            this.Column3.HeaderText = "规格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // FrmMdcDatMPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 714);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMdcDatMPN";
            this.Text = "物料选择";
            this.Load += new System.EventHandler(this.FrmMdcDatMPN_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mdmt)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_mdmt;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_materialCode;
        private CIT.Client.TXTextBox txt_materialCode;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}