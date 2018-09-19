namespace CIT.MES.BarCode.Control
{
    partial class FrmSetName
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tmpname = new CIT.Client.TXTextBox();
            this.btn_ok = new CIT.Client.TXButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(87, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板名称";
            // 
            // txt_tmpname
            // 
            this.txt_tmpname.BackColor = System.Drawing.Color.Transparent;
            this.txt_tmpname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_tmpname.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_tmpname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_tmpname.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_tmpname.Image = null;
            this.txt_tmpname.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_tmpname.Location = new System.Drawing.Point(148, 85);
            this.txt_tmpname.Name = "txt_tmpname";
            this.txt_tmpname.Padding = new System.Windows.Forms.Padding(2);
            this.txt_tmpname.PasswordChar = '\0';
            this.txt_tmpname.Required = false;
            this.txt_tmpname.Size = new System.Drawing.Size(180, 22);
            this.txt_tmpname.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(158, 157);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(100, 28);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // FrmSetName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 232);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_tmpname);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetName";
            this.Text = "设置模板名称";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Client.TXTextBox txt_tmpname;
        private Client.TXButton btn_ok;
    }
}