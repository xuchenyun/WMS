namespace Common.UI
{
    partial class FrmStationSelect
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
            this.cbo_plCode = new CIT.Client.TXComboBox();
            this.lbl_plCode = new System.Windows.Forms.Label();
            this.lbl_stationSn = new System.Windows.Forms.Label();
            this.txt_stationSn = new CIT.Client.TXTextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.lbl_stationName = new System.Windows.Forms.Label();
            this.txt_stationName = new CIT.Client.TXTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_workStation = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUP_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_workStation)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_plCode);
            this.panel1.Controls.Add(this.lbl_plCode);
            this.panel1.Controls.Add(this.lbl_stationSn);
            this.panel1.Controls.Add(this.txt_stationSn);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.lbl_stationName);
            this.panel1.Controls.Add(this.txt_stationName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 82);
            this.panel1.TabIndex = 0;
            // 
            // cbo_plCode
            // 
            this.cbo_plCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_plCode.FormattingEnabled = true;
            this.cbo_plCode.Location = new System.Drawing.Point(126, 28);
            this.cbo_plCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbo_plCode.Name = "cbo_plCode";
            this.cbo_plCode.Size = new System.Drawing.Size(229, 26);
            this.cbo_plCode.TabIndex = 87;
            // 
            // lbl_plCode
            // 
            this.lbl_plCode.AutoSize = true;
            this.lbl_plCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_plCode.Location = new System.Drawing.Point(57, 32);
            this.lbl_plCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_plCode.Name = "lbl_plCode";
            this.lbl_plCode.Size = new System.Drawing.Size(58, 24);
            this.lbl_plCode.TabIndex = 85;
            this.lbl_plCode.Text = "线别";
            // 
            // lbl_stationSn
            // 
            this.lbl_stationSn.AutoSize = true;
            this.lbl_stationSn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_stationSn.Location = new System.Drawing.Point(366, 32);
            this.lbl_stationSn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_stationSn.Name = "lbl_stationSn";
            this.lbl_stationSn.Size = new System.Drawing.Size(82, 24);
            this.lbl_stationSn.TabIndex = 86;
            this.lbl_stationSn.Text = "工位SN";
            // 
            // txt_stationSn
            // 
            this.txt_stationSn.BackColor = System.Drawing.Color.Transparent;
            this.txt_stationSn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_stationSn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_stationSn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_stationSn.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_stationSn.Image = null;
            this.txt_stationSn.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_stationSn.Location = new System.Drawing.Point(450, 24);
            this.txt_stationSn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_stationSn.Name = "txt_stationSn";
            this.txt_stationSn.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_stationSn.PasswordChar = '\0';
            this.txt_stationSn.Required = false;
            this.txt_stationSn.Size = new System.Drawing.Size(225, 40);
            this.txt_stationSn.TabIndex = 85;
            this.txt_stationSn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_stationSn_KeyDown);
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(998, 15);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(110, 58);
            this.btn_query.TabIndex = 84;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_stationName
            // 
            this.lbl_stationName.AutoSize = true;
            this.lbl_stationName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_stationName.Location = new System.Drawing.Point(675, 32);
            this.lbl_stationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_stationName.Name = "lbl_stationName";
            this.lbl_stationName.Size = new System.Drawing.Size(58, 24);
            this.lbl_stationName.TabIndex = 83;
            this.lbl_stationName.Text = "工位";
            // 
            // txt_stationName
            // 
            this.txt_stationName.BackColor = System.Drawing.Color.Transparent;
            this.txt_stationName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_stationName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_stationName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_stationName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_stationName.Image = null;
            this.txt_stationName.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_stationName.Location = new System.Drawing.Point(735, 24);
            this.txt_stationName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_stationName.Name = "txt_stationName";
            this.txt_stationName.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_stationName.PasswordChar = '\0';
            this.txt_stationName.Required = false;
            this.txt_stationName.Size = new System.Drawing.Size(225, 40);
            this.txt_stationName.TabIndex = 82;
            this.txt_stationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_stationName_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_workStation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 122);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1212, 472);
            this.panel2.TabIndex = 1;
            // 
            // dgv_workStation
            // 
            this.dgv_workStation.AllowUserToAddRows = false;
            this.dgv_workStation.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_workStation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_workStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_workStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column5,
            this.GROUP_NAME});
            this.dgv_workStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_workStation.Location = new System.Drawing.Point(0, 0);
            this.dgv_workStation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_workStation.Name = "dgv_workStation";
            this.dgv_workStation.RowHeadersVisible = false;
            this.dgv_workStation.RowTemplate.Height = 23;
            this.dgv_workStation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_workStation.Size = new System.Drawing.Size(1212, 472);
            this.dgv_workStation.TabIndex = 0;
            this.dgv_workStation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_workStation_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_no);
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 594);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1212, 91);
            this.panel3.TabIndex = 2;
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(1034, 9);
            this.btn_no.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(110, 58);
            this.btn_no.TabIndex = 80;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(915, 9);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(110, 58);
            this.btn_ok.TabIndex = 79;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TBS_ID";
            this.Column1.HeaderText = "工位ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "PLName";
            this.Column4.HeaderText = "线别";
            this.Column4.MinimumWidth = 200;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "WORKSTATION_SN";
            this.Column2.HeaderText = "工位SN";
            this.Column2.MinimumWidth = 200;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "WORKSTATION_NAME";
            this.Column3.HeaderText = "工位名称";
            this.Column3.MinimumWidth = 200;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "PLCode";
            this.Column5.HeaderText = "线别代码";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // GROUP_NAME
            // 
            this.GROUP_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GROUP_NAME.DataPropertyName = "GROUP_NAME";
            this.GROUP_NAME.HeaderText = "工序名称";
            this.GROUP_NAME.Name = "GROUP_NAME";
            this.GROUP_NAME.ReadOnly = true;
            // 
            // FrmStationSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 687);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmStationSelect";
            this.Text = "工位选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStationSelect_FormClosing);
            this.Load += new System.EventHandler(this.FrmStationSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_workStation)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_stationName;
        private CIT.Client.TXTextBox txt_stationName;
        private System.Windows.Forms.DataGridView dgv_workStation;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.Label lbl_plCode;
        private System.Windows.Forms.Label lbl_stationSn;
        private CIT.Client.TXTextBox txt_stationSn;
        private CIT.Client.TXComboBox cbo_plCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUP_NAME;
    }
}