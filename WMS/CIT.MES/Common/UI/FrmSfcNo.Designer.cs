namespace Common.UI
{
    partial class FrmSfcNo
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_sfcNo = new System.Windows.Forms.DataGridView();
            this.FGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SfcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sfcNo)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(657, 54);
            this.panel1.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(263, 9);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 39);
            this.btn_query.TabIndex = 84;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_sfcno
            // 
            this.lbl_sfcno.AutoSize = true;
            this.lbl_sfcno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sfcno.Location = new System.Drawing.Point(16, 20);
            this.lbl_sfcno.Name = "lbl_sfcno";
            this.lbl_sfcno.Size = new System.Drawing.Size(56, 16);
            this.lbl_sfcno.TabIndex = 83;
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
            this.txt_sfcno.Location = new System.Drawing.Point(82, 14);
            this.txt_sfcno.Name = "txt_sfcno";
            this.txt_sfcno.Padding = new System.Windows.Forms.Padding(2);
            this.txt_sfcno.PasswordChar = '\0';
            this.txt_sfcno.Required = false;
            this.txt_sfcno.Size = new System.Drawing.Size(175, 27);
            this.txt_sfcno.TabIndex = 82;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_sfcNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 293);
            this.panel2.TabIndex = 1;
            // 
            // dgv_sfcNo
            // 
            this.dgv_sfcNo.AllowUserToAddRows = false;
            this.dgv_sfcNo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_sfcNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_sfcNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sfcNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGuid,
            this.SfcNo,
            this.WoCode});
            this.dgv_sfcNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sfcNo.Location = new System.Drawing.Point(0, 0);
            this.dgv_sfcNo.Name = "dgv_sfcNo";
            this.dgv_sfcNo.RowHeadersVisible = false;
            this.dgv_sfcNo.RowTemplate.Height = 23;
            this.dgv_sfcNo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sfcNo.Size = new System.Drawing.Size(657, 293);
            this.dgv_sfcNo.TabIndex = 122;
            this.dgv_sfcNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_sfcNo_MouseDoubleClick);
            // 
            // FGuid
            // 
            this.FGuid.DataPropertyName = "FGuid";
            this.FGuid.HeaderText = "标识列";
            this.FGuid.Name = "FGuid";
            this.FGuid.Visible = false;
            // 
            // SfcNo
            // 
            this.SfcNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SfcNo.DataPropertyName = "SfcNo";
            this.SfcNo.HeaderText = "制令单";
            this.SfcNo.Name = "SfcNo";
            this.SfcNo.ReadOnly = true;
            // 
            // WoCode
            // 
            this.WoCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WoCode.DataPropertyName = "WoCode";
            this.WoCode.HeaderText = "工单 ";
            this.WoCode.Name = "WoCode";
            this.WoCode.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_no);
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 374);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 62);
            this.panel3.TabIndex = 2;
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(521, 6);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(73, 39);
            this.btn_no.TabIndex = 79;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(424, 6);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 39);
            this.btn_ok.TabIndex = 78;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // FrmSfcNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 437);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmSfcNo";
            this.Text = "制令单表";
            this.Load += new System.EventHandler(this.FrmSfcNo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sfcNo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_sfcNo;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_sfcno;
        private CIT.Client.TXTextBox txt_sfcno;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SfcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WoCode;
    }
}