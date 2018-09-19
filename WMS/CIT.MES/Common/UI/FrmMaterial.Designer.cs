namespace Common.UI
{
    partial class FrmMaterial
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
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_materialRule = new System.Windows.Forms.DataGridView();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBBR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RULE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_query = new CIT.Client.TXButton();
            this.lbl_materialCode = new System.Windows.Forms.Label();
            this.txt_materialCode = new CIT.Client.TXTextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialRule)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(551, 9);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(73, 39);
            this.btn_no.TabIndex = 77;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(454, 9);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 39);
            this.btn_ok.TabIndex = 76;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 373);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_no);
            this.panel4.Controls.Add(this.btn_ok);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 309);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(660, 64);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_materialRule);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 251);
            this.panel3.TabIndex = 1;
            // 
            // dgv_materialRule
            // 
            this.dgv_materialRule.AllowUserToAddRows = false;
            this.dgv_materialRule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_materialRule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materialRule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialCode,
            this.TBBR_ID,
            this.RULE_NAME});
            this.dgv_materialRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_materialRule.Location = new System.Drawing.Point(0, 0);
            this.dgv_materialRule.Name = "dgv_materialRule";
            this.dgv_materialRule.RowHeadersVisible = false;
            this.dgv_materialRule.RowTemplate.Height = 23;
            this.dgv_materialRule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_materialRule.Size = new System.Drawing.Size(660, 251);
            this.dgv_materialRule.TabIndex = 1;
            this.dgv_materialRule.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_materialRule_MouseDoubleClick);
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Width = 250;
            // 
            // TBBR_ID
            // 
            this.TBBR_ID.DataPropertyName = "TBBR_ID";
            this.TBBR_ID.HeaderText = "条码规则ID";
            this.TBBR_ID.Name = "TBBR_ID";
            this.TBBR_ID.Visible = false;
            // 
            // RULE_NAME
            // 
            this.RULE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RULE_NAME.DataPropertyName = "RULE_NAME";
            this.RULE_NAME.HeaderText = "条码规则";
            this.RULE_NAME.Name = "RULE_NAME";
            this.RULE_NAME.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.lbl_materialCode);
            this.panel2.Controls.Add(this.txt_materialCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 58);
            this.panel2.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(239, 13);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 39);
            this.btn_query.TabIndex = 84;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_materialCode
            // 
            this.lbl_materialCode.AutoSize = true;
            this.lbl_materialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_materialCode.Location = new System.Drawing.Point(12, 25);
            this.lbl_materialCode.Name = "lbl_materialCode";
            this.lbl_materialCode.Size = new System.Drawing.Size(40, 16);
            this.lbl_materialCode.TabIndex = 83;
            this.lbl_materialCode.Text = "料号";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_materialCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_materialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_materialCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_materialCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_materialCode.Image = null;
            this.txt_materialCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_materialCode.Location = new System.Drawing.Point(58, 20);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_materialCode.PasswordChar = '\0';
            this.txt_materialCode.Required = false;
            this.txt_materialCode.Size = new System.Drawing.Size(175, 27);
            this.txt_materialCode.TabIndex = 82;
            // 
            // FrmMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 401);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmMaterial";
            this.Text = "料号条码规则";
            this.Load += new System.EventHandler(this.FrmMaterial_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialRule)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CIT.Client.TXButton btn_ok;
        private CIT.Client.TXButton btn_no;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_materialRule;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_materialCode;
        private CIT.Client.TXTextBox txt_materialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBBR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RULE_NAME;
    }
}