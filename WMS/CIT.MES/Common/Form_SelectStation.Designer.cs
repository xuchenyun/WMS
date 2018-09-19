namespace Common
{
    partial class Form_SelectStation
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
            this.dgv_Main = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.cbx_Line = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_WorkStation_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txt_WorkStation_SN = new System.Windows.Forms.TextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.checkId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TBS_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WORKSTATION_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WORKSTATION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBG_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUP_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Main
            // 
            this.dgv_Main.AllowUserToAddRows = false;
            this.dgv_Main.AllowUserToDeleteRows = false;
            this.dgv_Main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkId,
            this.TBS_ID,
            this.WORKSTATION_SN,
            this.WORKSTATION_NAME,
            this.TBG_ID,
            this.GROUP_NAME,
            this.PLCODE,
            this.PLName});
            this.dgv_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Main.Location = new System.Drawing.Point(0, 118);
            this.dgv_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_Main.MultiSelect = false;
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.RowHeadersWidth = 21;
            this.dgv_Main.RowTemplate.Height = 23;
            this.dgv_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Main.Size = new System.Drawing.Size(1302, 454);
            this.dgv_Main.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbx_Line);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_WorkStation_Name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.txt_WorkStation_SN);
            this.panel1.Controls.Add(this.lblGroupName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 118);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1302, 42);
            this.panel2.TabIndex = 11;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(0, 3);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(112, 34);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // cbx_Line
            // 
            this.cbx_Line.FormattingEnabled = true;
            this.cbx_Line.Location = new System.Drawing.Point(902, 69);
            this.cbx_Line.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbx_Line.Name = "cbx_Line";
            this.cbx_Line.Size = new System.Drawing.Size(223, 26);
            this.cbx_Line.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(752, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 34);
            this.label2.TabIndex = 9;
            this.label2.Text = "线别";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_WorkStation_Name
            // 
            this.txt_WorkStation_Name.Location = new System.Drawing.Point(526, 69);
            this.txt_WorkStation_Name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_WorkStation_Name.Name = "txt_WorkStation_Name";
            this.txt_WorkStation_Name.Size = new System.Drawing.Size(223, 28);
            this.txt_WorkStation_Name.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(376, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "工位名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1136, 68);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(112, 34);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查 询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txt_WorkStation_SN
            // 
            this.txt_WorkStation_SN.Location = new System.Drawing.Point(152, 69);
            this.txt_WorkStation_SN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_WorkStation_SN.Name = "txt_WorkStation_SN";
            this.txt_WorkStation_SN.Size = new System.Drawing.Size(223, 28);
            this.txt_WorkStation_SN.TabIndex = 1;
            // 
            // lblGroupName
            // 
            this.lblGroupName.Location = new System.Drawing.Point(2, 68);
            this.lblGroupName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(150, 34);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "工位SN";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkId
            // 
            this.checkId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.checkId.DataPropertyName = "checkId";
            this.checkId.HeaderText = "";
            this.checkId.Name = "checkId";
            this.checkId.Width = 5;
            // 
            // TBS_ID
            // 
            this.TBS_ID.DataPropertyName = "TBS_ID";
            this.TBS_ID.HeaderText = "TBS_ID";
            this.TBS_ID.Name = "TBS_ID";
            this.TBS_ID.ReadOnly = true;
            this.TBS_ID.Visible = false;
            // 
            // WORKSTATION_SN
            // 
            this.WORKSTATION_SN.DataPropertyName = "WORKSTATION_SN";
            this.WORKSTATION_SN.HeaderText = "工位SN";
            this.WORKSTATION_SN.Name = "WORKSTATION_SN";
            this.WORKSTATION_SN.ReadOnly = true;
            this.WORKSTATION_SN.Width = 200;
            // 
            // WORKSTATION_NAME
            // 
            this.WORKSTATION_NAME.DataPropertyName = "WORKSTATION_NAME";
            this.WORKSTATION_NAME.HeaderText = "工位名称";
            this.WORKSTATION_NAME.Name = "WORKSTATION_NAME";
            this.WORKSTATION_NAME.ReadOnly = true;
            this.WORKSTATION_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WORKSTATION_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WORKSTATION_NAME.Width = 200;
            // 
            // TBG_ID
            // 
            this.TBG_ID.DataPropertyName = "TBG_ID";
            this.TBG_ID.HeaderText = "工序ID";
            this.TBG_ID.Name = "TBG_ID";
            this.TBG_ID.ReadOnly = true;
            this.TBG_ID.Visible = false;
            // 
            // GROUP_NAME
            // 
            this.GROUP_NAME.DataPropertyName = "GROUP_NAME";
            this.GROUP_NAME.HeaderText = "工序名称";
            this.GROUP_NAME.Name = "GROUP_NAME";
            this.GROUP_NAME.ReadOnly = true;
            this.GROUP_NAME.Width = 200;
            // 
            // PLCODE
            // 
            this.PLCODE.DataPropertyName = "PLCODE";
            this.PLCODE.HeaderText = "线别代码";
            this.PLCODE.Name = "PLCODE";
            this.PLCODE.ReadOnly = true;
            this.PLCODE.Visible = false;
            // 
            // PLName
            // 
            this.PLName.DataPropertyName = "PLName";
            this.PLName.HeaderText = "线别名称";
            this.PLName.Name = "PLName";
            this.PLName.ReadOnly = true;
            this.PLName.Width = 200;
            // 
            // Form_SelectStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 572);
            this.Controls.Add(this.dgv_Main);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_SelectStation";
            this.Text = "工位--选择";
            this.Load += new System.EventHandler(this.Form_SelectStation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Main;
        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXComboBox cbx_Line;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_WorkStation_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txt_WorkStation_SN;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBS_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WORKSTATION_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn WORKSTATION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBG_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUP_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLName;
    }
}