namespace BaseData.UI
{
    partial class FrmOrganize
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
            this.cbo_ParentOrg = new CIT.Client.TXComboBox();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.txtCurrentOrg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbo_ParentOrg);
            this.panel1.Controls.Add(this.btn_no);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Controls.Add(this.txtCurrentOrg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 255);
            this.panel1.TabIndex = 0;
            // 
            // cbo_ParentOrg
            // 
            this.cbo_ParentOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ParentOrg.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_ParentOrg.FormattingEnabled = true;
            this.cbo_ParentOrg.Location = new System.Drawing.Point(126, 46);
            this.cbo_ParentOrg.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_ParentOrg.Name = "cbo_ParentOrg";
            this.cbo_ParentOrg.Size = new System.Drawing.Size(177, 24);
            this.cbo_ParentOrg.TabIndex = 172;
            // 
            // btn_no
            // 
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(204, 169);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(69, 35);
            this.btn_no.TabIndex = 163;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(123, 169);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 35);
            this.btn_ok.TabIndex = 162;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txtCurrentOrg
            // 
            this.txtCurrentOrg.Location = new System.Drawing.Point(127, 108);
            this.txtCurrentOrg.Name = "txtCurrentOrg";
            this.txtCurrentOrg.Size = new System.Drawing.Size(177, 21);
            this.txtCurrentOrg.TabIndex = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 158;
            this.label2.Text = "父节点名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 156;
            this.label1.Text = "节点名称";
            // 
            // FrmOrganize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 283);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmOrganize";
            this.Text = "组织管理";
            this.Load += new System.EventHandler(this.FrmOrganize_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCurrentOrg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private CIT.Client.TXComboBox cbo_ParentOrg;
    }
}