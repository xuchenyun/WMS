namespace Warehouse.UI
{
    partial class Frm_InventoryAdd
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_no = new System.Windows.Forms.Button();
            this.cbo_PN = new CIT.Client.TXComboBox();
            this.cbo_houseName = new CIT.Client.TXComboBox();
            this.cbo_areaName = new CIT.Client.TXComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "仓库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "库区";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "料号";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(121, 205);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 34);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_no
            // 
            this.btn_no.Location = new System.Drawing.Point(245, 205);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(75, 34);
            this.btn_no.TabIndex = 9;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // cbo_PN
            // 
            this.cbo_PN.FormattingEnabled = true;
            this.cbo_PN.Location = new System.Drawing.Point(157, 152);
            this.cbo_PN.Name = "cbo_PN";
            this.cbo_PN.Size = new System.Drawing.Size(150, 20);
            this.cbo_PN.TabIndex = 111;
            this.cbo_PN.TextUpdate += new System.EventHandler(this.cbo_PN_TextUpdate);
            // 
            // cbo_houseName
            // 
            this.cbo_houseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseName.FormattingEnabled = true;
            this.cbo_houseName.Location = new System.Drawing.Point(157, 63);
            this.cbo_houseName.Name = "cbo_houseName";
            this.cbo_houseName.Size = new System.Drawing.Size(150, 20);
            this.cbo_houseName.TabIndex = 112;
            // 
            // cbo_areaName
            // 
            this.cbo_areaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_areaName.FormattingEnabled = true;
            this.cbo_areaName.Location = new System.Drawing.Point(157, 109);
            this.cbo_areaName.Name = "cbo_areaName";
            this.cbo_areaName.Size = new System.Drawing.Size(150, 20);
            this.cbo_areaName.TabIndex = 113;
            // 
            // Frm_InventoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 326);
            this.Controls.Add(this.cbo_areaName);
            this.Controls.Add(this.cbo_houseName);
            this.Controls.Add(this.cbo_PN);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_InventoryAdd";
            this.Text = "新增盘点单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_InventoryAdd_FormClosing);
            this.Load += new System.EventHandler(this.Frm_InventoryAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_no;
        private CIT.Client.TXComboBox cbo_PN;
        private CIT.Client.TXComboBox cbo_houseName;
        private CIT.Client.TXComboBox cbo_areaName;
    }
}