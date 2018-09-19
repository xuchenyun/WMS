namespace Warehouse.UI
{
    partial class FrmMaterialMoveAdd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_TargetStorage = new CIT.Client.TXComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_SourceStorage = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DOC_NO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_no = new CIT.Client.TXButton();
            this.btn_ok = new CIT.Client.TXButton();
            this.dgv_MaterialMoveAdd = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaterialMoveAdd)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_memo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbo_TargetStorage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbo_SourceStorage);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_DOC_NO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 100);
            this.panel1.TabIndex = 0;
            // 
            // txt_memo
            // 
            this.txt_memo.Location = new System.Drawing.Point(809, 35);
            this.txt_memo.Multiline = true;
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(177, 21);
            this.txt_memo.TabIndex = 159;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(759, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 158;
            this.label4.Text = "备注";
            // 
            // cbo_TargetStorage
            // 
            this.cbo_TargetStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TargetStorage.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_TargetStorage.FormattingEnabled = true;
            this.cbo_TargetStorage.Location = new System.Drawing.Point(561, 33);
            this.cbo_TargetStorage.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_TargetStorage.Name = "cbo_TargetStorage";
            this.cbo_TargetStorage.Size = new System.Drawing.Size(177, 24);
            this.cbo_TargetStorage.TabIndex = 161;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 160;
            this.label3.Text = "目的仓库";
            // 
            // cbo_SourceStorage
            // 
            this.cbo_SourceStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_SourceStorage.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_SourceStorage.FormattingEnabled = true;
            this.cbo_SourceStorage.Location = new System.Drawing.Point(303, 35);
            this.cbo_SourceStorage.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_SourceStorage.Name = "cbo_SourceStorage";
            this.cbo_SourceStorage.Size = new System.Drawing.Size(177, 24);
            this.cbo_SourceStorage.TabIndex = 159;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 158;
            this.label2.Text = "原仓库";
            // 
            // txt_DOC_NO
            // 
            this.txt_DOC_NO.Location = new System.Drawing.Point(68, 38);
            this.txt_DOC_NO.Name = "txt_DOC_NO";
            this.txt_DOC_NO.Size = new System.Drawing.Size(177, 21);
            this.txt_DOC_NO.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 156;
            this.label1.Text = "单据号";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgv_MaterialMoveAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 446);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_no);
            this.panel3.Controls.Add(this.btn_ok);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 304);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1080, 142);
            this.panel3.TabIndex = 1;
            // 
            // btn_no
            // 
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(380, 37);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(69, 35);
            this.btn_no.TabIndex = 125;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(299, 37);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 35);
            this.btn_ok.TabIndex = 124;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // dgv_MaterialMoveAdd
            // 
            this.dgv_MaterialMoveAdd.AllowUserToAddRows = false;
            this.dgv_MaterialMoveAdd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_MaterialMoveAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MaterialMoveAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.MaterialCode,
            this.StorageQTY,
            this.Plan_Qty});
            this.dgv_MaterialMoveAdd.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_MaterialMoveAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_MaterialMoveAdd.Location = new System.Drawing.Point(0, 0);
            this.dgv_MaterialMoveAdd.Name = "dgv_MaterialMoveAdd";
            this.dgv_MaterialMoveAdd.RowHeadersVisible = false;
            this.dgv_MaterialMoveAdd.RowTemplate.Height = 23;
            this.dgv_MaterialMoveAdd.Size = new System.Drawing.Size(1080, 304);
            this.dgv_MaterialMoveAdd.TabIndex = 0;
            this.dgv_MaterialMoveAdd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MaterialMoveAdd_CellContentClick);
            this.dgv_MaterialMoveAdd.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_MaterialMoveAdd_CellLeave);
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "行号";
            this.RowNumber.Name = "RowNumber";
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            // 
            // StorageQTY
            // 
            this.StorageQTY.DataPropertyName = "QTY";
            this.StorageQTY.HeaderText = "库存数量";
            this.StorageQTY.Name = "StorageQTY";
            // 
            // Plan_Qty
            // 
            this.Plan_Qty.DataPropertyName = "Plan_Qty";
            this.Plan_Qty.HeaderText = "计划数量";
            this.Plan_Qty.Name = "Plan_Qty";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新增ToolStripMenuItem.Text = "新增";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteToolStripMenuItem.Text = "删除";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // FrmMaterialMoveAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 574);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmMaterialMoveAdd";
            this.Text = "调拨开单";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMaterialMoveAdd_FormClosing);
            this.Load += new System.EventHandler(this.FrmMaterialMoveAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaterialMoveAdd)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXComboBox cbo_TargetStorage;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXComboBox cbo_SourceStorage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DOC_NO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_MaterialMoveAdd;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXButton btn_no;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Qty;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
    }
}