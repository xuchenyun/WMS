namespace Common.UI
{
    partial class FrmBarcodeRule
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
            this.btn_query = new CIT.Client.TXButton();
            this.txt_ruleName = new System.Windows.Forms.TextBox();
            this.lbl_ruleName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_barcodeRule = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.TBBR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RULE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_CHECK_SN_LENGTH = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SN_LENGTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_CHECK_SAME_STRING = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SAME_STRING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAME_STRING_BEGIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATERIAL_FLAG = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MATERIAL_LENGTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATERIAL_CODE_BEGIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SN_BEGIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barcodeRule)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.txt_ruleName);
            this.panel1.Controls.Add(this.lbl_ruleName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 63);
            this.panel1.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(255, 21);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 27);
            this.btn_query.TabIndex = 80;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_ruleName
            // 
            this.txt_ruleName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ruleName.Location = new System.Drawing.Point(88, 21);
            this.txt_ruleName.Name = "txt_ruleName";
            this.txt_ruleName.Size = new System.Drawing.Size(157, 26);
            this.txt_ruleName.TabIndex = 79;
            // 
            // lbl_ruleName
            // 
            this.lbl_ruleName.AutoSize = true;
            this.lbl_ruleName.Font = new System.Drawing.Font("宋体", 9F);
            this.lbl_ruleName.Location = new System.Drawing.Point(25, 28);
            this.lbl_ruleName.Name = "lbl_ruleName";
            this.lbl_ruleName.Size = new System.Drawing.Size(53, 12);
            this.lbl_ruleName.TabIndex = 78;
            this.lbl_ruleName.Text = "条码规则";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_barcodeRule);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 314);
            this.panel2.TabIndex = 1;
            // 
            // dgv_barcodeRule
            // 
            this.dgv_barcodeRule.AllowUserToAddRows = false;
            this.dgv_barcodeRule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_barcodeRule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TBBR_ID,
            this.RULE_NAME,
            this.IS_CHECK_SN_LENGTH,
            this.SN_LENGTH,
            this.IS_CHECK_SAME_STRING,
            this.SAME_STRING,
            this.SAME_STRING_BEGIN,
            this.MATERIAL_FLAG,
            this.MATERIAL_LENGTH,
            this.MATERIAL_CODE_BEGIN,
            this.SN_BEGIN});
            this.dgv_barcodeRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_barcodeRule.Location = new System.Drawing.Point(0, 0);
            this.dgv_barcodeRule.Name = "dgv_barcodeRule";
            this.dgv_barcodeRule.RowHeadersVisible = false;
            this.dgv_barcodeRule.RowTemplate.Height = 23;
            this.dgv_barcodeRule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_barcodeRule.Size = new System.Drawing.Size(853, 314);
            this.dgv_barcodeRule.TabIndex = 3;
            this.dgv_barcodeRule.DoubleClick += new System.EventHandler(this.btn_query_Click);
            this.dgv_barcodeRule.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_barcodeRule_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_no);
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 404);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(853, 69);
            this.panel3.TabIndex = 2;
            // 
            // btn_no
            // 
            this.btn_no.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_no.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(735, 18);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(73, 39);
            this.btn_no.TabIndex = 80;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(656, 18);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 39);
            this.btn_ok.TabIndex = 79;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
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
            this.RULE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RULE_NAME.DataPropertyName = "RULE_NAME";
            this.RULE_NAME.HeaderText = "条码规则";
            this.RULE_NAME.Name = "RULE_NAME";
            this.RULE_NAME.ReadOnly = true;
            this.RULE_NAME.Width = 78;
            // 
            // IS_CHECK_SN_LENGTH
            // 
            this.IS_CHECK_SN_LENGTH.DataPropertyName = "IS_CHECK_SN_LENGTH";
            this.IS_CHECK_SN_LENGTH.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IS_CHECK_SN_LENGTH.HeaderText = "是否校验条码长度";
            this.IS_CHECK_SN_LENGTH.Name = "IS_CHECK_SN_LENGTH";
            this.IS_CHECK_SN_LENGTH.ReadOnly = true;
            this.IS_CHECK_SN_LENGTH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IS_CHECK_SN_LENGTH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IS_CHECK_SN_LENGTH.Width = 200;
            // 
            // SN_LENGTH
            // 
            this.SN_LENGTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SN_LENGTH.DataPropertyName = "SN_LENGTH";
            this.SN_LENGTH.HeaderText = "条码长度";
            this.SN_LENGTH.Name = "SN_LENGTH";
            this.SN_LENGTH.ReadOnly = true;
            this.SN_LENGTH.Width = 78;
            // 
            // IS_CHECK_SAME_STRING
            // 
            this.IS_CHECK_SAME_STRING.DataPropertyName = "IS_CHECK_SAME_STRING";
            this.IS_CHECK_SAME_STRING.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IS_CHECK_SAME_STRING.HeaderText = "是否校验固定字符";
            this.IS_CHECK_SAME_STRING.Name = "IS_CHECK_SAME_STRING";
            this.IS_CHECK_SAME_STRING.ReadOnly = true;
            this.IS_CHECK_SAME_STRING.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IS_CHECK_SAME_STRING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IS_CHECK_SAME_STRING.Width = 120;
            // 
            // SAME_STRING
            // 
            this.SAME_STRING.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SAME_STRING.DataPropertyName = "SAME_STRING";
            this.SAME_STRING.HeaderText = "固定字符";
            this.SAME_STRING.Name = "SAME_STRING";
            this.SAME_STRING.ReadOnly = true;
            this.SAME_STRING.Width = 78;
            // 
            // SAME_STRING_BEGIN
            // 
            this.SAME_STRING_BEGIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SAME_STRING_BEGIN.DataPropertyName = "SAME_STRING_BEGIN";
            this.SAME_STRING_BEGIN.HeaderText = "条码固定字符起始位置";
            this.SAME_STRING_BEGIN.Name = "SAME_STRING_BEGIN";
            this.SAME_STRING_BEGIN.ReadOnly = true;
            this.SAME_STRING_BEGIN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SAME_STRING_BEGIN.Width = 150;
            // 
            // MATERIAL_FLAG
            // 
            this.MATERIAL_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MATERIAL_FLAG.DataPropertyName = "MATERIAL_FLAG";
            this.MATERIAL_FLAG.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.MATERIAL_FLAG.HeaderText = "物料代码比对";
            this.MATERIAL_FLAG.Name = "MATERIAL_FLAG";
            this.MATERIAL_FLAG.ReadOnly = true;
            this.MATERIAL_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MATERIAL_FLAG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MATERIAL_FLAG.Width = 102;
            // 
            // MATERIAL_LENGTH
            // 
            this.MATERIAL_LENGTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MATERIAL_LENGTH.DataPropertyName = "MATERIAL_LENGTH";
            this.MATERIAL_LENGTH.HeaderText = "物料代码长度";
            this.MATERIAL_LENGTH.Name = "MATERIAL_LENGTH";
            this.MATERIAL_LENGTH.ReadOnly = true;
            this.MATERIAL_LENGTH.Width = 102;
            // 
            // MATERIAL_CODE_BEGIN
            // 
            this.MATERIAL_CODE_BEGIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MATERIAL_CODE_BEGIN.DataPropertyName = "MATERIAL_CODE_BEGIN";
            this.MATERIAL_CODE_BEGIN.HeaderText = "物料代码起始位置";
            this.MATERIAL_CODE_BEGIN.Name = "MATERIAL_CODE_BEGIN";
            this.MATERIAL_CODE_BEGIN.ReadOnly = true;
            this.MATERIAL_CODE_BEGIN.Width = 126;
            // 
            // SN_BEGIN
            // 
            this.SN_BEGIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SN_BEGIN.DataPropertyName = "SN_BEGIN";
            this.SN_BEGIN.HeaderText = "条码起始位置";
            this.SN_BEGIN.Name = "SN_BEGIN";
            this.SN_BEGIN.ReadOnly = true;
            this.SN_BEGIN.Width = 102;
            // 
            // FrmBarcodeRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 474);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmBarcodeRule";
            this.Text = "FrmBarcodeRule";
            this.Load += new System.EventHandler(this.FrmBarcodeRule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_barcodeRule)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.TextBox txt_ruleName;
        private System.Windows.Forms.Label lbl_ruleName;
        private System.Windows.Forms.DataGridView dgv_barcodeRule;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBBR_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RULE_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn IS_CHECK_SN_LENGTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN_LENGTH;
        private System.Windows.Forms.DataGridViewComboBoxColumn IS_CHECK_SAME_STRING;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAME_STRING;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAME_STRING_BEGIN;
        private System.Windows.Forms.DataGridViewComboBoxColumn MATERIAL_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIAL_LENGTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIAL_CODE_BEGIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN_BEGIN;
    }
}