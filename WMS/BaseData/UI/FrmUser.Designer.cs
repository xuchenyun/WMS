namespace BaseData.UI
{
    partial class FrmUser
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
            this.cbo_Org = new CIT.Client.TXComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_userID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_Org);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_no);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.txt_userName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_userID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 437);
            this.panel1.TabIndex = 0;
            // 
            // cbo_Org
            // 
            this.cbo_Org.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Org.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_Org.FormattingEnabled = true;
            this.cbo_Org.Location = new System.Drawing.Point(220, 190);
            this.cbo_Org.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_Org.Name = "cbo_Org";
            this.cbo_Org.Size = new System.Drawing.Size(177, 24);
            this.cbo_Org.TabIndex = 171;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 170;
            this.label3.Text = "所属部门";
            // 
            // btn_no
            // 
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(305, 256);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(69, 35);
            this.btn_no.TabIndex = 169;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(224, 256);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 35);
            this.btn_ok.TabIndex = 168;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(220, 138);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(177, 21);
            this.txt_userName.TabIndex = 167;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 166;
            this.label2.Text = "用户ID";
            // 
            // txt_userID
            // 
            this.txt_userID.Location = new System.Drawing.Point(220, 80);
            this.txt_userID.Name = "txt_userID";
            this.txt_userID.Size = new System.Drawing.Size(177, 21);
            this.txt_userID.TabIndex = 165;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 164;
            this.label1.Text = "用户名";
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 465);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmUser";
            this.Text = "人员管理";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_userID;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXComboBox cbo_Org;
    }
}