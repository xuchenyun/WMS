namespace Query.UI
{
    partial class Form_CreateDocEdit
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtBeforeDoc = new System.Windows.Forms.TextBox();
            this.txtDocNO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_Type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtVer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Before_Doc_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.cmMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 75);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtBeforeDoc);
            this.panel6.Controls.Add(this.txtDocNO);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.cbo_Type);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 30);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1002, 45);
            this.panel6.TabIndex = 1;
            // 
            // txtBeforeDoc
            // 
            this.txtBeforeDoc.Location = new System.Drawing.Point(412, 6);
            this.txtBeforeDoc.Name = "txtBeforeDoc";
            this.txtBeforeDoc.Size = new System.Drawing.Size(204, 21);
            this.txtBeforeDoc.TabIndex = 12;
            this.txtBeforeDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBeforeDoc_KeyPress);
            // 
            // txtDocNO
            // 
            this.txtDocNO.Location = new System.Drawing.Point(762, 6);
            this.txtDocNO.Name = "txtDocNO";
            this.txtDocNO.ReadOnly = true;
            this.txtDocNO.Size = new System.Drawing.Size(204, 21);
            this.txtDocNO.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(703, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "单据号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "上游单据";
            // 
            // cbo_Type
            // 
            this.cbo_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Type.FormattingEnabled = true;
            this.cbo_Type.Location = new System.Drawing.Point(77, 6);
            this.cbo_Type.Name = "cbo_Type";
            this.cbo_Type.Size = new System.Drawing.Size(192, 20);
            this.cbo_Type.TabIndex = 5;
            this.cbo_Type.SelectionChangeCommitted += new System.EventHandler(this.cbo_Type_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "单据类型";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1002, 30);
            this.panel5.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 387);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(281, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(721, 387);
            this.panel4.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.MaterialCode,
            this.QTY,
            this.Ver,
            this.TYPE_CODE,
            this.TYPE_NAME,
            this.Before_Doc_No,
            this.RowNumber});
            this.dgvData.ContextMenuStrip = this.cmMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(721, 387);
            this.dgvData.TabIndex = 2;
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtVer);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtQty);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtMaterialCode);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 387);
            this.panel3.TabIndex = 0;
            // 
            // txtVer
            // 
            this.txtVer.Location = new System.Drawing.Point(63, 26);
            this.txtVer.Name = "txtVer";
            this.txtVer.Size = new System.Drawing.Size(192, 21);
            this.txtVer.TabIndex = 17;
            this.txtVer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVer_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "版本";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(63, 127);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(192, 21);
            this.txtQty.TabIndex = 19;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "数量";
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(63, 76);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(192, 21);
            this.txtMaterialCode.TabIndex = 21;
            this.txtMaterialCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaterialCode_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "料号";
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "单据号";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
            this.S_Doc_NO.Width = 120;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Width = 120;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量 ";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            this.QTY.Width = 120;
            // 
            // Ver
            // 
            this.Ver.DataPropertyName = "Ver";
            this.Ver.HeaderText = "版本";
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            // 
            // TYPE_CODE
            // 
            this.TYPE_CODE.DataPropertyName = "TYPE_CODE";
            this.TYPE_CODE.HeaderText = "单据Code";
            this.TYPE_CODE.Name = "TYPE_CODE";
            this.TYPE_CODE.ReadOnly = true;
            this.TYPE_CODE.Visible = false;
            this.TYPE_CODE.Width = 120;
            // 
            // TYPE_NAME
            // 
            this.TYPE_NAME.DataPropertyName = "TYPE_NAME";
            this.TYPE_NAME.HeaderText = "单据类型";
            this.TYPE_NAME.Name = "TYPE_NAME";
            this.TYPE_NAME.ReadOnly = true;
            // 
            // Before_Doc_No
            // 
            this.Before_Doc_No.DataPropertyName = "Before_Doc_No";
            this.Before_Doc_No.HeaderText = "上游单据";
            this.Before_Doc_No.Name = "Before_Doc_No";
            this.Before_Doc_No.ReadOnly = true;
            this.Before_Doc_No.Width = 120;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "行号";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 120;
            // 
            // Form_CreateDocEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form_CreateDocEdit";
            this.Text = "单据开立";
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.cmMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbo_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocNO;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox txtBeforeDoc;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Before_Doc_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
    }
}