namespace Warehouse.UI
{
    partial class FrmMaterialBack
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
            this.txt_Begin_LocationSN = new CIT.Client.TXTextBox();
            this.lbl_SN = new System.Windows.Forms.Label();
            this.txt_Qty = new CIT.Client.TXTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Begin_LocationSN
            // 
            this.txt_Begin_LocationSN.BackColor = System.Drawing.Color.Transparent;
            this.txt_Begin_LocationSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Begin_LocationSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Begin_LocationSN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Begin_LocationSN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Begin_LocationSN.Image = null;
            this.txt_Begin_LocationSN.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Begin_LocationSN.Location = new System.Drawing.Point(119, 66);
            this.txt_Begin_LocationSN.Name = "txt_Begin_LocationSN";
            this.txt_Begin_LocationSN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_Begin_LocationSN.PasswordChar = '\0';
            this.txt_Begin_LocationSN.Required = false;
            this.txt_Begin_LocationSN.Size = new System.Drawing.Size(313, 27);
            this.txt_Begin_LocationSN.TabIndex = 128;
            this.txt_Begin_LocationSN.TextChange += new System.EventHandler(this.txt_Begin_LocationSN_TextChange);
            this.txt_Begin_LocationSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Begin_LocationSN_KeyPress);
            // 
            // lbl_SN
            // 
            this.lbl_SN.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SN.Location = new System.Drawing.Point(47, 74);
            this.lbl_SN.Name = "lbl_SN";
            this.lbl_SN.Size = new System.Drawing.Size(67, 12);
            this.lbl_SN.TabIndex = 127;
            this.lbl_SN.Text = "物料SN";
            this.lbl_SN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Qty
            // 
            this.txt_Qty.BackColor = System.Drawing.Color.Transparent;
            this.txt_Qty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Qty.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Qty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Qty.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Qty.Image = null;
            this.txt_Qty.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Qty.Location = new System.Drawing.Point(119, 113);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Padding = new System.Windows.Forms.Padding(2);
            this.txt_Qty.PasswordChar = '\0';
            this.txt_Qty.Required = false;
            this.txt_Qty.Size = new System.Drawing.Size(313, 27);
            this.txt_Qty.TabIndex = 130;
            this.txt_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Qty_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(47, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 129;
            this.label1.Text = "数量";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMaterialBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 239);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Begin_LocationSN);
            this.Controls.Add(this.lbl_SN);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMaterialBack";
            this.Text = "退料清点";
            this.Load += new System.EventHandler(this.FrmMaterialBack_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CIT.Client.TXTextBox txt_Begin_LocationSN;
        private System.Windows.Forms.Label lbl_SN;
        private CIT.Client.TXTextBox txt_Qty;
        private System.Windows.Forms.Label label1;
    }
}