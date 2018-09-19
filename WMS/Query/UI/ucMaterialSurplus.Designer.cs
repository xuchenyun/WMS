namespace Query.UI
{
    partial class ucMaterialSurplus
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
            this.btn_query = new CIT.Client.TXButton();
            this.txt_partNumber = new System.Windows.Forms.TextBox();
            this.materialNumber = new System.Windows.Forms.Label();
            this.txt_sfcNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_materialSurplus = new System.Windows.Forms.DataGridView();
            this.WoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFCNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surplus_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialSurplus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Controls.Add(this.txt_partNumber);
            this.panel1.Controls.Add(this.materialNumber);
            this.panel1.Controls.Add(this.txt_sfcNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1608, 76);
            this.panel1.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(698, 21);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(110, 34);
            this.btn_query.TabIndex = 136;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_partNumber
            // 
            this.txt_partNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_partNumber.Location = new System.Drawing.Point(430, 20);
            this.txt_partNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txt_partNumber.Name = "txt_partNumber";
            this.txt_partNumber.Size = new System.Drawing.Size(260, 35);
            this.txt_partNumber.TabIndex = 129;
            // 
            // materialNumber
            // 
            this.materialNumber.AutoSize = true;
            this.materialNumber.Location = new System.Drawing.Point(378, 29);
            this.materialNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialNumber.Name = "materialNumber";
            this.materialNumber.Size = new System.Drawing.Size(44, 18);
            this.materialNumber.TabIndex = 128;
            this.materialNumber.Text = "料号";
            // 
            // txt_sfcNo
            // 
            this.txt_sfcNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sfcNo.Location = new System.Drawing.Point(90, 20);
            this.txt_sfcNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sfcNo.Name = "txt_sfcNo";
            this.txt_sfcNo.Size = new System.Drawing.Size(260, 35);
            this.txt_sfcNo.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 124;
            this.label1.Text = "制令单";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_materialSurplus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1608, 596);
            this.panel2.TabIndex = 1;
            // 
            // dgv_materialSurplus
            // 
            this.dgv_materialSurplus.AllowUserToAddRows = false;
            this.dgv_materialSurplus.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_materialSurplus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_materialSurplus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WoCode,
            this.SFCNO,
            this.MaterialCode,
            this.QTY,
            this.Surplus_Qty});
            this.dgv_materialSurplus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_materialSurplus.Location = new System.Drawing.Point(0, 0);
            this.dgv_materialSurplus.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_materialSurplus.Name = "dgv_materialSurplus";
            this.dgv_materialSurplus.RowHeadersVisible = false;
            this.dgv_materialSurplus.RowTemplate.Height = 23;
            this.dgv_materialSurplus.Size = new System.Drawing.Size(1608, 596);
            this.dgv_materialSurplus.TabIndex = 0;
            this.dgv_materialSurplus.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_materialUsed_MouseDoubleClick);
            // 
            // WoCode
            // 
            this.WoCode.DataPropertyName = "WoCode";
            this.WoCode.HeaderText = "工单";
            this.WoCode.MinimumWidth = 200;
            this.WoCode.Name = "WoCode";
            this.WoCode.ReadOnly = true;
            this.WoCode.Width = 200;
            // 
            // SFCNO
            // 
            this.SFCNO.DataPropertyName = "SFCNO";
            this.SFCNO.HeaderText = "制令单";
            this.SFCNO.MinimumWidth = 200;
            this.SFCNO.Name = "SFCNO";
            this.SFCNO.ReadOnly = true;
            this.SFCNO.Width = 200;
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.MinimumWidth = 200;
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            this.MaterialCode.Width = 200;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "发料数";
            this.QTY.MinimumWidth = 200;
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            this.QTY.Width = 200;
            // 
            // Surplus_Qty
            // 
            this.Surplus_Qty.DataPropertyName = "Surplus_Qty";
            this.Surplus_Qty.HeaderText = "剩余数量";
            this.Surplus_Qty.MinimumWidth = 200;
            this.Surplus_Qty.Name = "Surplus_Qty";
            this.Surplus_Qty.ReadOnly = true;
            this.Surplus_Qty.Width = 200;
            // 
            // ucMaterialSurplus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucMaterialSurplus";
            this.Size = new System.Drawing.Size(1608, 672);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_materialSurplus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.TextBox txt_partNumber;
        private System.Windows.Forms.Label materialNumber;
        private System.Windows.Forms.TextBox txt_sfcNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_materialSurplus;
        private System.Windows.Forms.DataGridViewTextBoxColumn WoCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFCNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surplus_Qty;
    }
}
