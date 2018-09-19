namespace Warehouse.UI
{
    partial class ucMaterialMove
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaterialCode = new CIT.Client.TXTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DocNO = new CIT.Client.TXTextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_MaterialDoc = new System.Windows.Forms.DataGridView();
            this.S_Doc_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_Storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target_Storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaterialDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 35);
            this.panel1.TabIndex = 0;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_edit,
            this.btn_del});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(1104, 31);
            this.txToolStrip1.TabIndex = 10;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::Warehouse.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 28);
            this.btn_add.Text = "开单";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = global::Warehouse.Properties.Resources.edit;
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(60, 28);
            this.btn_edit.Text = "编辑";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_del
            // 
            this.btn_del.Image = global::Warehouse.Properties.Resources.delbinding;
            this.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(60, 28);
            this.btn_del.Text = "删除";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_MaterialCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_DocNO);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1104, 86);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(258, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 140;
            this.label1.Text = "料号";
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_MaterialCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_MaterialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_MaterialCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_MaterialCode.Image = null;
            this.txt_MaterialCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_MaterialCode.Location = new System.Drawing.Point(317, 28);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_MaterialCode.PasswordChar = '\0';
            this.txt_MaterialCode.Required = false;
            this.txt_MaterialCode.Size = new System.Drawing.Size(150, 27);
            this.txt_MaterialCode.TabIndex = 139;
            this.txt_MaterialCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MaterialCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 138;
            this.label2.Text = "单据号";
            // 
            // txt_DocNO
            // 
            this.txt_DocNO.BackColor = System.Drawing.Color.Transparent;
            this.txt_DocNO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_DocNO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DocNO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_DocNO.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_DocNO.Image = null;
            this.txt_DocNO.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_DocNO.Location = new System.Drawing.Point(94, 28);
            this.txt_DocNO.Name = "txt_DocNO";
            this.txt_DocNO.Padding = new System.Windows.Forms.Padding(2);
            this.txt_DocNO.PasswordChar = '\0';
            this.txt_DocNO.Required = false;
            this.txt_DocNO.Size = new System.Drawing.Size(150, 27);
            this.txt_DocNO.TabIndex = 137;
            this.txt_DocNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DocNO_KeyPress);
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(486, 28);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 136;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_MaterialDoc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1104, 428);
            this.panel3.TabIndex = 2;
            // 
            // dgv_MaterialDoc
            // 
            this.dgv_MaterialDoc.AllowUserToAddRows = false;
            this.dgv_MaterialDoc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_MaterialDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MaterialDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO,
            this.MaterialCode,
            this.Plan_Qty,
            this.QTY,
            this.Source_Storage,
            this.Target_Storage,
            this.UserName,
            this.Create_Time,
            this.Memo});
            this.dgv_MaterialDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_MaterialDoc.Location = new System.Drawing.Point(0, 0);
            this.dgv_MaterialDoc.Name = "dgv_MaterialDoc";
            this.dgv_MaterialDoc.RowHeadersVisible = false;
            this.dgv_MaterialDoc.RowTemplate.Height = 23;
            this.dgv_MaterialDoc.Size = new System.Drawing.Size(1104, 428);
            this.dgv_MaterialDoc.TabIndex = 0;
            this.dgv_MaterialDoc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MaterialDoc_MouseDoubleClick);
            // 
            // S_Doc_NO
            // 
            this.S_Doc_NO.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO.HeaderText = "单据";
            this.S_Doc_NO.Name = "S_Doc_NO";
            this.S_Doc_NO.ReadOnly = true;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            // 
            // Plan_Qty
            // 
            this.Plan_Qty.DataPropertyName = "Plan_Qty";
            this.Plan_Qty.HeaderText = "计划数量";
            this.Plan_Qty.Name = "Plan_Qty";
            this.Plan_Qty.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "调拨数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // Source_Storage
            // 
            this.Source_Storage.DataPropertyName = "Source_Storage";
            this.Source_Storage.HeaderText = "原仓库";
            this.Source_Storage.Name = "Source_Storage";
            this.Source_Storage.ReadOnly = true;
            // 
            // Target_Storage
            // 
            this.Target_Storage.DataPropertyName = "Target_Storage";
            this.Target_Storage.HeaderText = "目的仓库";
            this.Target_Storage.Name = "Target_Storage";
            this.Target_Storage.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "创建人";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            // 
            // ucMaterialMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMaterialMove";
            this.Size = new System.Drawing.Size(1104, 549);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MaterialDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_del;
        private System.Windows.Forms.DataGridView dgv_MaterialDoc;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXTextBox txt_MaterialCode;
        private System.Windows.Forms.Label label2;
        private CIT.Client.TXTextBox txt_DocNO;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source_Storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target_Storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
    }
}
