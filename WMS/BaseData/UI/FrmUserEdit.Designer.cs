namespace BaseData.UI
{
    partial class FrmUserEdit
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Password = new CIT.Client.TXTextBox();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.txt_UserName = new CIT.Client.TXTextBox();
            this.lbl_typeCode = new System.Windows.Forms.Label();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.txt_UserID = new CIT.Client.TXTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Menu = new System.Windows.Forms.DataGridView();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Menu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_no);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 46);
            this.panel1.TabIndex = 0;
            // 
            // btn_no
            // 
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(100, 5);
            this.btn_no.Margin = new System.Windows.Forms.Padding(4);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(96, 33);
            this.btn_no.TabIndex = 103;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(4, 5);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(96, 33);
            this.btn_ok.TabIndex = 102;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_Password);
            this.panel2.Controls.Add(this.lbl_Pwd);
            this.panel2.Controls.Add(this.txt_UserName);
            this.panel2.Controls.Add(this.lbl_typeCode);
            this.panel2.Controls.Add(this.lbl_UserID);
            this.panel2.Controls.Add(this.txt_UserID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 73);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 75);
            this.panel2.TabIndex = 1;
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.Transparent;
            this.txt_Password.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Password.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Password.Image = null;
            this.txt_Password.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Password.Location = new System.Drawing.Point(853, 16);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Padding = new System.Windows.Forms.Padding(3);
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Required = false;
            this.txt_Password.Size = new System.Drawing.Size(225, 40);
            this.txt_Password.TabIndex = 107;
            // 
            // lbl_Pwd
            // 
            this.lbl_Pwd.AutoSize = true;
            this.lbl_Pwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Pwd.Location = new System.Drawing.Point(787, 24);
            this.lbl_Pwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(58, 24);
            this.lbl_Pwd.TabIndex = 106;
            this.lbl_Pwd.Text = "密码";
            // 
            // txt_UserName
            // 
            this.txt_UserName.BackColor = System.Drawing.Color.Transparent;
            this.txt_UserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_UserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_UserName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_UserName.Image = null;
            this.txt_UserName.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_UserName.Location = new System.Drawing.Point(484, 16);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Padding = new System.Windows.Forms.Padding(3);
            this.txt_UserName.PasswordChar = '\0';
            this.txt_UserName.Required = false;
            this.txt_UserName.Size = new System.Drawing.Size(225, 40);
            this.txt_UserName.TabIndex = 105;
            // 
            // lbl_typeCode
            // 
            this.lbl_typeCode.AutoSize = true;
            this.lbl_typeCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeCode.Location = new System.Drawing.Point(418, 24);
            this.lbl_typeCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_typeCode.Name = "lbl_typeCode";
            this.lbl_typeCode.Size = new System.Drawing.Size(58, 24);
            this.lbl_typeCode.TabIndex = 104;
            this.lbl_typeCode.Text = "名称";
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.AutoSize = true;
            this.lbl_UserID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_UserID.Location = new System.Drawing.Point(40, 24);
            this.lbl_UserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(82, 24);
            this.lbl_UserID.TabIndex = 103;
            this.lbl_UserID.Text = "用户ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.BackColor = System.Drawing.Color.Transparent;
            this.txt_UserID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_UserID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_UserID.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_UserID.Image = null;
            this.txt_UserID.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_UserID.Location = new System.Drawing.Point(130, 16);
            this.txt_UserID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.Padding = new System.Windows.Forms.Padding(3);
            this.txt_UserID.PasswordChar = '\0';
            this.txt_UserID.Required = false;
            this.txt_UserID.Size = new System.Drawing.Size(225, 40);
            this.txt_UserID.TabIndex = 102;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Menu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 148);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1130, 501);
            this.panel3.TabIndex = 2;
            // 
            // dgv_Menu
            // 
            this.dgv_Menu.AllowUserToAddRows = false;
            this.dgv_Menu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Menu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHK,
            this.MenuCode,
            this.MenuName});
            this.dgv_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Menu.Location = new System.Drawing.Point(0, 0);
            this.dgv_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Menu.Name = "dgv_Menu";
            this.dgv_Menu.RowHeadersVisible = false;
            this.dgv_Menu.RowTemplate.Height = 23;
            this.dgv_Menu.Size = new System.Drawing.Size(1130, 501);
            this.dgv_Menu.TabIndex = 0;
            this.dgv_Menu.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Menu_CellValueChanged);
            // 
            // CHK
            // 
            this.CHK.DataPropertyName = "CHK";
            this.CHK.HeaderText = "";
            this.CHK.Name = "CHK";
            this.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CHK.Width = 50;
            // 
            // MenuCode
            // 
            this.MenuCode.DataPropertyName = "MenuCode";
            this.MenuCode.HeaderText = "菜单代码";
            this.MenuCode.MinimumWidth = 120;
            this.MenuCode.Name = "MenuCode";
            this.MenuCode.ReadOnly = true;
            this.MenuCode.Visible = false;
            this.MenuCode.Width = 130;
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "菜单名称";
            this.MenuName.Name = "MenuName";
            this.MenuName.Width = 120;
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUserEdit";
            this.Text = "用户信息编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUserEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmUserEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Menu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXTextBox txt_UserName;
        private System.Windows.Forms.Label lbl_typeCode;
        private System.Windows.Forms.Label lbl_UserID;
        private CIT.Client.TXTextBox txt_UserID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_Menu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private CIT.Client.TXTextBox txt_Password;
        private System.Windows.Forms.Label lbl_Pwd;
    }
}