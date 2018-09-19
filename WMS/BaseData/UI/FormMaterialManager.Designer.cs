namespace BaseData.UI
{
    partial class frmMaterialManager
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
            this.txt_safeQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_shelfLifeTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_isMSD = new CIT.Client.TXComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_packType = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_packMin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_packMax = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_inComingType = new CIT.Client.TXComboBox();
            this.cbo_isSendCheck = new CIT.Client.TXComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbo_secMateiralClass = new CIT.Client.TXComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbo_houseCode2 = new CIT.Client.TXComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_houseCode1 = new CIT.Client.TXComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_materialName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_houseCode = new CIT.Client.TXComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_Type = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_materialCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_safeQty);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_shelfLifeTime);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbo_isMSD);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txt_packType);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txt_packMin);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txt_packMax);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cbo_inComingType);
            this.panel1.Controls.Add(this.cbo_isSendCheck);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cbo_secMateiralClass);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbo_houseCode2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbo_houseCode1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_materialName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbo_houseCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbo_Type);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_materialCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 507);
            this.panel1.TabIndex = 0;
            // 
            // txt_safeQty
            // 
            this.txt_safeQty.Location = new System.Drawing.Point(371, 421);
            this.txt_safeQty.Name = "txt_safeQty";
            this.txt_safeQty.Size = new System.Drawing.Size(77, 21);
            this.txt_safeQty.TabIndex = 183;
            this.txt_safeQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_safeQty_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(301, 425);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 182;
            this.label10.Text = "安全库存";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(173, 425);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 181;
            this.label9.Text = "个月";
            // 
            // txt_shelfLifeTime
            // 
            this.txt_shelfLifeTime.Location = new System.Drawing.Point(90, 421);
            this.txt_shelfLifeTime.Name = "txt_shelfLifeTime";
            this.txt_shelfLifeTime.Size = new System.Drawing.Size(77, 21);
            this.txt_shelfLifeTime.TabIndex = 180;
            this.txt_shelfLifeTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_shelfLifeTime_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 179;
            this.label7.Text = "有效期";
            // 
            // cbo_isMSD
            // 
            this.cbo_isMSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_isMSD.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_isMSD.FormattingEnabled = true;
            this.cbo_isMSD.Location = new System.Drawing.Point(90, 215);
            this.cbo_isMSD.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_isMSD.Name = "cbo_isMSD";
            this.cbo_isMSD.Size = new System.Drawing.Size(177, 24);
            this.cbo_isMSD.TabIndex = 178;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 177;
            this.label16.Text = "是否MSD";
            // 
            // txt_packType
            // 
            this.txt_packType.Location = new System.Drawing.Point(90, 319);
            this.txt_packType.Name = "txt_packType";
            this.txt_packType.Size = new System.Drawing.Size(177, 21);
            this.txt_packType.TabIndex = 176;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 175;
            this.label15.Text = "包装类型";
            // 
            // txt_packMin
            // 
            this.txt_packMin.Location = new System.Drawing.Point(371, 370);
            this.txt_packMin.Name = "txt_packMin";
            this.txt_packMin.Size = new System.Drawing.Size(177, 21);
            this.txt_packMin.TabIndex = 174;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(306, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 173;
            this.label13.Text = "最小包装";
            // 
            // txt_packMax
            // 
            this.txt_packMax.Location = new System.Drawing.Point(90, 370);
            this.txt_packMax.Name = "txt_packMax";
            this.txt_packMax.Size = new System.Drawing.Size(177, 21);
            this.txt_packMax.TabIndex = 172;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 374);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 171;
            this.label14.Text = "最大包装";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(302, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 170;
            this.label12.Text = "供料模式";
            // 
            // cbo_inComingType
            // 
            this.cbo_inComingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_inComingType.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_inComingType.FormattingEnabled = true;
            this.cbo_inComingType.Location = new System.Drawing.Point(371, 266);
            this.cbo_inComingType.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_inComingType.Name = "cbo_inComingType";
            this.cbo_inComingType.Size = new System.Drawing.Size(177, 24);
            this.cbo_inComingType.TabIndex = 169;
            // 
            // cbo_isSendCheck
            // 
            this.cbo_isSendCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_isSendCheck.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_isSendCheck.FormattingEnabled = true;
            this.cbo_isSendCheck.Location = new System.Drawing.Point(371, 215);
            this.cbo_isSendCheck.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_isSendCheck.Name = "cbo_isSendCheck";
            this.cbo_isSendCheck.Size = new System.Drawing.Size(177, 24);
            this.cbo_isSendCheck.TabIndex = 168;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(302, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 167;
            this.label11.Text = "是否送检";
            // 
            // cbo_secMateiralClass
            // 
            this.cbo_secMateiralClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_secMateiralClass.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_secMateiralClass.FormattingEnabled = true;
            this.cbo_secMateiralClass.Location = new System.Drawing.Point(90, 266);
            this.cbo_secMateiralClass.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_secMateiralClass.Name = "cbo_secMateiralClass";
            this.cbo_secMateiralClass.Size = new System.Drawing.Size(177, 24);
            this.cbo_secMateiralClass.TabIndex = 163;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 162;
            this.label8.Text = "辅材等级";
            // 
            // cbo_houseCode2
            // 
            this.cbo_houseCode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseCode2.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_houseCode2.FormattingEnabled = true;
            this.cbo_houseCode2.Location = new System.Drawing.Point(371, 164);
            this.cbo_houseCode2.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_houseCode2.Name = "cbo_houseCode2";
            this.cbo_houseCode2.Size = new System.Drawing.Size(177, 24);
            this.cbo_houseCode2.TabIndex = 159;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 158;
            this.label6.Text = "备用仓库2";
            // 
            // cbo_houseCode1
            // 
            this.cbo_houseCode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseCode1.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_houseCode1.FormattingEnabled = true;
            this.cbo_houseCode1.Location = new System.Drawing.Point(90, 164);
            this.cbo_houseCode1.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_houseCode1.Name = "cbo_houseCode1";
            this.cbo_houseCode1.Size = new System.Drawing.Size(177, 24);
            this.cbo_houseCode1.TabIndex = 157;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 156;
            this.label5.Text = "备用仓库1";
            // 
            // txt_materialName
            // 
            this.txt_materialName.Location = new System.Drawing.Point(371, 64);
            this.txt_materialName.Name = "txt_materialName";
            this.txt_materialName.Size = new System.Drawing.Size(177, 21);
            this.txt_materialName.TabIndex = 155;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 154;
            this.label4.Text = "品名";
            // 
            // cbo_houseCode
            // 
            this.cbo_houseCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseCode.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_houseCode.FormattingEnabled = true;
            this.cbo_houseCode.Location = new System.Drawing.Point(371, 113);
            this.cbo_houseCode.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_houseCode.Name = "cbo_houseCode";
            this.cbo_houseCode.Size = new System.Drawing.Size(177, 24);
            this.cbo_houseCode.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 152;
            this.label3.Text = "默认仓库";
            // 
            // cbo_Type
            // 
            this.cbo_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Type.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_Type.FormattingEnabled = true;
            this.cbo_Type.Location = new System.Drawing.Point(90, 113);
            this.cbo_Type.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_Type.Name = "cbo_Type";
            this.cbo_Type.Size = new System.Drawing.Size(177, 24);
            this.cbo_Type.TabIndex = 151;
            this.cbo_Type.SelectionChangeCommitted += new System.EventHandler(this.cbo_Type_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 150;
            this.label2.Text = "类型";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.Location = new System.Drawing.Point(90, 64);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Size = new System.Drawing.Size(177, 21);
            this.txt_materialCode.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 148;
            this.label1.Text = "料号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_no);
            this.panel2.Controls.Add(this.btn_ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 534);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 97);
            this.panel2.TabIndex = 1;
            // 
            // btn_no
            // 
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(298, 18);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(69, 35);
            this.btn_no.TabIndex = 121;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(217, 18);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 35);
            this.btn_ok.TabIndex = 120;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // frmMaterialManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 632);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMaterialManager";
            this.Text = "料号管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMaterialManager_FormClosing);
            this.Load += new System.EventHandler(this.frmMaterialManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXComboBox cbo_houseCode;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXComboBox cbo_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_materialCode;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXComboBox cbo_houseCode2;
        private System.Windows.Forms.Label label6;
        private CIT.Client.TXComboBox cbo_houseCode1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_materialName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private CIT.Client.TXComboBox cbo_isSendCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_packType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_packMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_packMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private CIT.Client.TXComboBox cbo_inComingType;
        private CIT.Client.TXComboBox cbo_isMSD;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_safeQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_shelfLifeTime;
        private System.Windows.Forms.Label label7;
        private CIT.Client.TXComboBox cbo_secMateiralClass;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
    }
}