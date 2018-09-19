namespace Common.UI
{
    partial class Frm_PrintBoxLable
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
            this.lbl_sfcno = new System.Windows.Forms.Label();
            this.txt_sn = new CIT.Client.TXTextBox();
            this.SuspendLayout();
            // 
            // lbl_sfcno
            // 
            this.lbl_sfcno.AutoSize = true;
            this.lbl_sfcno.Font = new System.Drawing.Font("宋体", 30F);
            this.lbl_sfcno.Location = new System.Drawing.Point(13, 43);
            this.lbl_sfcno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_sfcno.Name = "lbl_sfcno";
            this.lbl_sfcno.Size = new System.Drawing.Size(145, 60);
            this.lbl_sfcno.TabIndex = 88;
            this.lbl_sfcno.Text = "箱SN";
            // 
            // txt_sn
            // 
            this.txt_sn.BackColor = System.Drawing.Color.Transparent;
            this.txt_sn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_sn.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold);
            this.txt_sn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_sn.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_sn.Image = null;
            this.txt_sn.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_sn.Location = new System.Drawing.Point(166, 43);
            this.txt_sn.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sn.Name = "txt_sn";
            this.txt_sn.Padding = new System.Windows.Forms.Padding(3);
            this.txt_sn.PasswordChar = '\0';
            this.txt_sn.Required = false;
            this.txt_sn.Size = new System.Drawing.Size(813, 70);
            this.txt_sn.TabIndex = 87;
            this.txt_sn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_sn_KeyDown);
            // 
            // Frm_PrintBoxLable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 152);
            this.Controls.Add(this.txt_sn);
            this.Controls.Add(this.lbl_sfcno);
            this.Name = "Frm_PrintBoxLable";
            this.Text = "打印外包装条码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_sfcno;
        private CIT.Client.TXTextBox txt_sn;
    }
}