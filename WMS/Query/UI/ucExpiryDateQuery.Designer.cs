namespace Query.UI
{
    partial class ucExpiryDateQuery
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
            this.btn_sendCheck = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvBarCode = new System.Windows.Forms.DataGridView();
            this.Storage_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_Locked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lock_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 33);
            this.panel1.TabIndex = 0;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_sendCheck});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(1002, 31);
            this.txToolStrip1.TabIndex = 155;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_sendCheck
            // 
            this.btn_sendCheck.Image = global::Query.Properties.Resources.edit;
            this.btn_sendCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_sendCheck.Name = "btn_sendCheck";
            this.btn_sendCheck.Size = new System.Drawing.Size(60, 28);
            this.btn_sendCheck.Text = "送检";
            this.btn_sendCheck.Click += new System.EventHandler(this.btn_sendCheck_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.txtMaterialCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 75);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(952, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "预警";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(889, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "超期";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(258, 26);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(84, 23);
            this.btn_query.TabIndex = 13;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(47, 27);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(172, 21);
            this.txtMaterialCode.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "料号";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvBarCode);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1002, 393);
            this.panel3.TabIndex = 2;
            // 
            // dgvBarCode
            // 
            this.dgvBarCode.AllowUserToAddRows = false;
            this.dgvBarCode.AllowUserToDeleteRows = false;
            this.dgvBarCode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Storage_SN,
            this.Area_SN,
            this.Location_SN,
            this.MaterialCode,
            this.QTY,
            this.Is_Locked,
            this.In_Time,
            this.Lock_Time,
            this.SerialNumber,
            this.flag});
            this.dgvBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarCode.Location = new System.Drawing.Point(0, 0);
            this.dgvBarCode.Name = "dgvBarCode";
            this.dgvBarCode.ReadOnly = true;
            this.dgvBarCode.RowHeadersVisible = false;
            this.dgvBarCode.RowTemplate.Height = 23;
            this.dgvBarCode.Size = new System.Drawing.Size(1002, 393);
            this.dgvBarCode.TabIndex = 1;
            this.dgvBarCode.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvBarCode_RowPrePaint);
            // 
            // Storage_SN
            // 
            this.Storage_SN.DataPropertyName = "Storage_SN";
            this.Storage_SN.HeaderText = "仓库SN";
            this.Storage_SN.Name = "Storage_SN";
            this.Storage_SN.ReadOnly = true;
            this.Storage_SN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Area_SN
            // 
            this.Area_SN.DataPropertyName = "Area_SN";
            this.Area_SN.HeaderText = "库区SN";
            this.Area_SN.Name = "Area_SN";
            this.Area_SN.ReadOnly = true;
            this.Area_SN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Location_SN
            // 
            this.Location_SN.DataPropertyName = "Location_SN";
            this.Location_SN.HeaderText = "库位SN";
            this.Location_SN.Name = "Location_SN";
            this.Location_SN.ReadOnly = true;
            this.Location_SN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "数量";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            this.QTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Is_Locked
            // 
            this.Is_Locked.DataPropertyName = "Is_Locked";
            this.Is_Locked.HeaderText = "锁定状态";
            this.Is_Locked.Name = "Is_Locked";
            this.Is_Locked.ReadOnly = true;
            this.Is_Locked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // In_Time
            // 
            this.In_Time.DataPropertyName = "In_Time";
            this.In_Time.HeaderText = "入库时间";
            this.In_Time.Name = "In_Time";
            this.In_Time.ReadOnly = true;
            this.In_Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lock_Time
            // 
            this.Lock_Time.DataPropertyName = "Lock_Time";
            this.Lock_Time.HeaderText = "锁定时间";
            this.Lock_Time.Name = "Lock_Time";
            this.Lock_Time.ReadOnly = true;
            this.Lock_Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SerialNumber
            // 
            this.SerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "条码";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            this.SerialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // flag
            // 
            this.flag.DataPropertyName = "flag";
            this.flag.HeaderText = "flag";
            this.flag.Name = "flag";
            this.flag.ReadOnly = true;
            this.flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.flag.Visible = false;
            // 
            // ucExpiryDateQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucExpiryDateQuery";
            this.Size = new System.Drawing.Size(1002, 501);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvBarCode;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_sendCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storage_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Is_Locked;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lock_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn flag;
    }
}
