namespace Common.UI
{
    partial class FrmWoCode
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
            this.btn_query = new CIT.Client.TXButton();
            this.lbl_sfcno = new System.Windows.Forms.Label();
            this.txt_sfcno = new CIT.Client.TXTextBox();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_woCode = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_woCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.lbl_sfcno);
            this.panel1.Controls.Add(this.txt_sfcno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 54);
            this.panel1.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(244, 9);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 39);
            this.btn_query.TabIndex = 87;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_sfcno
            // 
            this.lbl_sfcno.AutoSize = true;
            this.lbl_sfcno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sfcno.Location = new System.Drawing.Point(14, 20);
            this.lbl_sfcno.Name = "lbl_sfcno";
            this.lbl_sfcno.Size = new System.Drawing.Size(56, 16);
            this.lbl_sfcno.TabIndex = 86;
            this.lbl_sfcno.Text = "制令单";
            // 
            // txt_sfcno
            // 
            this.txt_sfcno.BackColor = System.Drawing.Color.Transparent;
            this.txt_sfcno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_sfcno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sfcno.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_sfcno.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_sfcno.Image = null;
            this.txt_sfcno.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_sfcno.Location = new System.Drawing.Point(76, 15);
            this.txt_sfcno.Name = "txt_sfcno";
            this.txt_sfcno.Padding = new System.Windows.Forms.Padding(2);
            this.txt_sfcno.PasswordChar = '\0';
            this.txt_sfcno.Required = false;
            this.txt_sfcno.Size = new System.Drawing.Size(150, 27);
            this.txt_sfcno.TabIndex = 85;
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(588, 359);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(73, 39);
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
            this.btn_ok.Location = new System.Drawing.Point(497, 359);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 39);
            this.btn_ok.TabIndex = 122;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_woCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 272);
            this.panel2.TabIndex = 124;
            // 
            // dgv_woCode
            // 
            this.dgv_woCode.AllowUserToAddRows = false;
            this.dgv_woCode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_woCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_woCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_woCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dgv_woCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_woCode.Location = new System.Drawing.Point(0, 0);
            this.dgv_woCode.Name = "dgv_woCode";
            this.dgv_woCode.RowHeadersVisible = false;
            this.dgv_woCode.RowTemplate.Height = 23;
            this.dgv_woCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_woCode.Size = new System.Drawing.Size(690, 272);
            this.dgv_woCode.TabIndex = 1;
            this.dgv_woCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_woCode_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FGuid";
            this.Column1.HeaderText = "标识列";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SfcNo";
            this.Column3.HeaderText = "制令单";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 280;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "WoCode";
            this.Column2.HeaderText = "工单";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // FrmWoCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 409);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmWoCode";
            this.Text = "工单表";
            this.Load += new System.EventHandler(this.FrmWoCode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_woCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_woCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_sfcno;
        private CIT.Client.TXTextBox txt_sfcno;
    }
}