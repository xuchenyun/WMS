namespace CIT.MES.Setting
{
    partial class FrmSetting
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
            this.txTabControl1 = new CIT.Client.TXTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnInitialize = new CIT.Client.TXButton();
            this.btnSave = new CIT.Client.TXButton();
            this.chbIsCheckErpWoState = new CIT.Client.TXCheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txPanel1 = new CIT.Client.TXPanel();
            this.txtMSlotCut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.txPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txTabControl1
            // 
            this.txTabControl1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txTabControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txTabControl1.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txTabControl1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txTabControl1.Controls.Add(this.tabPage3);
            this.txTabControl1.Controls.Add(this.tabPage1);
            this.txTabControl1.Controls.Add(this.tabPage2);
            this.txTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txTabControl1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txTabControl1.Location = new System.Drawing.Point(1, 27);
            this.txTabControl1.Name = "txTabControl1";
            this.txTabControl1.SelectedIndex = 0;
            this.txTabControl1.ShowContextMenu = true;
            this.txTabControl1.Size = new System.Drawing.Size(646, 368);
            this.txTabControl1.TabCornerRadius = 3;
            this.txTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "打印设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnInitialize);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "初始化货架";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnInitialize
            // 
            this.BtnInitialize.Image = null;
            this.BtnInitialize.Location = new System.Drawing.Point(233, 100);
            this.BtnInitialize.Name = "BtnInitialize";
            this.BtnInitialize.Size = new System.Drawing.Size(100, 28);
            this.BtnInitialize.TabIndex = 0;
            this.BtnInitialize.Text = "初始化货架";
            this.BtnInitialize.UseVisualStyleBackColor = true;
            this.BtnInitialize.Click += new System.EventHandler(this.BtnInitialize_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = null;
            this.btnSave.Location = new System.Drawing.Point(517, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chbIsCheckErpWoState
            // 
            this.chbIsCheckErpWoState.AutoSize = true;
            this.chbIsCheckErpWoState.Location = new System.Drawing.Point(29, 18);
            this.chbIsCheckErpWoState.MinimumSize = new System.Drawing.Size(20, 20);
            this.chbIsCheckErpWoState.Name = "chbIsCheckErpWoState";
            this.chbIsCheckErpWoState.Size = new System.Drawing.Size(162, 20);
            this.chbIsCheckErpWoState.TabIndex = 2;
            this.chbIsCheckErpWoState.Text = "是否开启ERP工单状态校验";
            this.chbIsCheckErpWoState.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txPanel1);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(638, 335);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "常规设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txPanel1
            // 
            this.txPanel1.BackBeginColor = System.Drawing.Color.Transparent;
            this.txPanel1.BackColor = System.Drawing.Color.Transparent;
            this.txPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txPanel1.Controls.Add(this.label1);
            this.txPanel1.Controls.Add(this.txtMSlotCut);
            this.txPanel1.Controls.Add(this.chbIsCheckErpWoState);
            this.txPanel1.Location = new System.Drawing.Point(34, 23);
            this.txPanel1.Name = "txPanel1";
            this.txPanel1.Size = new System.Drawing.Size(587, 240);
            this.txPanel1.TabIndex = 3;
            // 
            // txtMSlotCut
            // 
            this.txtMSlotCut.Location = new System.Drawing.Point(128, 56);
            this.txtMSlotCut.MaxLength = 1;
            this.txtMSlotCut.Name = "txtMSlotCut";
            this.txtMSlotCut.Size = new System.Drawing.Size(63, 21);
            this.txtMSlotCut.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "料站表分割符:";
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 396);
            this.Controls.Add(this.txTabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetting";
            this.Text = "系统设置";
            this.txTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.txPanel1.ResumeLayout(false);
            this.txPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Client.TXTabControl txTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Client.TXButton BtnInitialize;
        private System.Windows.Forms.TabPage tabPage3;
        private Client.TXPanel txPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSlotCut;
        private Client.TXCheckBox chbIsCheckErpWoState;
        private Client.TXButton btnSave;
    }
}