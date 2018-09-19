namespace Warehouse.UI
{
    partial class Frm_LocationLotAdd
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
            this.txt_End_LocationSN = new CIT.Client.TXTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ParentStorage = new System.Windows.Forms.Label();
            this.cbo_ParentStorage = new CIT.Client.TXComboBox();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.txt_fixChar = new CIT.Client.TXTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.txt_Begin_LocationSN.Location = new System.Drawing.Point(139, 84);
            this.txt_Begin_LocationSN.Name = "txt_Begin_LocationSN";
            this.txt_Begin_LocationSN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_Begin_LocationSN.PasswordChar = '\0';
            this.txt_Begin_LocationSN.Required = false;
            this.txt_Begin_LocationSN.Size = new System.Drawing.Size(137, 27);
            this.txt_Begin_LocationSN.TabIndex = 126;
            // 
            // lbl_SN
            // 
            this.lbl_SN.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SN.Location = new System.Drawing.Point(66, 88);
            this.lbl_SN.Name = "lbl_SN";
            this.lbl_SN.Size = new System.Drawing.Size(67, 12);
            this.lbl_SN.TabIndex = 125;
            this.lbl_SN.Text = "开始库位SN";
            this.lbl_SN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_End_LocationSN
            // 
            this.txt_End_LocationSN.BackColor = System.Drawing.Color.Transparent;
            this.txt_End_LocationSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_End_LocationSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_End_LocationSN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_End_LocationSN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_End_LocationSN.Image = null;
            this.txt_End_LocationSN.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_End_LocationSN.Location = new System.Drawing.Point(139, 123);
            this.txt_End_LocationSN.Name = "txt_End_LocationSN";
            this.txt_End_LocationSN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_End_LocationSN.PasswordChar = '\0';
            this.txt_End_LocationSN.Required = false;
            this.txt_End_LocationSN.Size = new System.Drawing.Size(137, 27);
            this.txt_End_LocationSN.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(66, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 127;
            this.label1.Text = "结束库位SN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ParentStorage
            // 
            this.lbl_ParentStorage.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ParentStorage.Location = new System.Drawing.Point(47, 51);
            this.lbl_ParentStorage.Name = "lbl_ParentStorage";
            this.lbl_ParentStorage.Size = new System.Drawing.Size(87, 12);
            this.lbl_ParentStorage.TabIndex = 130;
            this.lbl_ParentStorage.Text = "库位SN";
            this.lbl_ParentStorage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_ParentStorage
            // 
            this.cbo_ParentStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ParentStorage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_ParentStorage.FormattingEnabled = true;
            this.cbo_ParentStorage.Location = new System.Drawing.Point(139, 45);
            this.cbo_ParentStorage.Name = "cbo_ParentStorage";
            this.cbo_ParentStorage.Size = new System.Drawing.Size(137, 24);
            this.cbo_ParentStorage.TabIndex = 129;
            this.cbo_ParentStorage.SelectedIndexChanged += new System.EventHandler(this.cbo_ParentStorage_SelectedIndexChanged);
            // 
            // btn_no
            // 
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(203, 231);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(64, 35);
            this.btn_no.TabIndex = 135;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(107, 231);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 35);
            this.btn_ok.TabIndex = 134;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_fixChar
            // 
            this.txt_fixChar.BackColor = System.Drawing.Color.Transparent;
            this.txt_fixChar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_fixChar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_fixChar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_fixChar.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_fixChar.Image = null;
            this.txt_fixChar.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_fixChar.Location = new System.Drawing.Point(139, 156);
            this.txt_fixChar.Name = "txt_fixChar";
            this.txt_fixChar.Padding = new System.Windows.Forms.Padding(2);
            this.txt_fixChar.PasswordChar = '\0';
            this.txt_fixChar.Required = false;
            this.txt_fixChar.Size = new System.Drawing.Size(137, 27);
            this.txt_fixChar.TabIndex = 137;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(66, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 136;
            this.label2.Text = "固定字符";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(68, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 12);
            this.label3.TabIndex = 138;
            this.label3.Text = "友情提示：固定字符将会填充在SN前，非必填项。";
            // 
            // Frm_LocationLotAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(398, 270);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_fixChar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_ParentStorage);
            this.Controls.Add(this.cbo_ParentStorage);
            this.Controls.Add(this.txt_End_LocationSN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Begin_LocationSN);
            this.Controls.Add(this.lbl_SN);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_LocationLotAdd";
            this.Text = "批量添加库位";
            this.Load += new System.EventHandler(this.Frm_LocationLotAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CIT.Client.TXTextBox txt_Begin_LocationSN;
        private System.Windows.Forms.Label lbl_SN;
        private CIT.Client.TXTextBox txt_End_LocationSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ParentStorage;
        private CIT.Client.TXComboBox cbo_ParentStorage;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private CIT.Client.TXTextBox txt_fixChar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}