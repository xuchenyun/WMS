namespace Warehouse.UI
{
    partial class ucMaterialBack
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
            this.txt_MaterialCode = new CIT.Client.TXTextBox();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_back = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Sdoc_No = new CIT.Client.TXTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_CreateTimeMax = new System.Windows.Forms.DateTimePicker();
            this.dtp_CreateTimeMin = new System.Windows.Forms.DateTimePicker();
            this.lbl_typeCode = new System.Windows.Forms.Label();
            this.lbl_typeName = new System.Windows.Forms.Label();
            this.btn_query = new CIT.Client.TXButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_Material = new System.Windows.Forms.DataGridView();
            this.S_Doc_NO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Detail = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receive_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Material)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_MaterialCode);
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Sdoc_No);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtp_CreateTimeMax);
            this.panel1.Controls.Add(this.dtp_CreateTimeMin);
            this.panel1.Controls.Add(this.lbl_typeCode);
            this.panel1.Controls.Add(this.lbl_typeName);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 110);
            this.panel1.TabIndex = 147;
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
            this.txt_MaterialCode.Location = new System.Drawing.Point(79, 29);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_MaterialCode.PasswordChar = '\0';
            this.txt_MaterialCode.Required = false;
            this.txt_MaterialCode.Size = new System.Drawing.Size(203, 27);
            this.txt_MaterialCode.TabIndex = 165;
            this.txt_MaterialCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MaterialCode_KeyPress);
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_back});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(992, 31);
            this.txToolStrip1.TabIndex = 164;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_back
            // 
            this.btn_back.Image = global::Warehouse.Properties.Resources.lock_off;
            this.btn_back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(60, 28);
            this.btn_back.Text = "退料";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(313, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 150;
            this.label1.Text = "单据号";
            // 
            // txt_Sdoc_No
            // 
            this.txt_Sdoc_No.BackColor = System.Drawing.Color.Transparent;
            this.txt_Sdoc_No.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Sdoc_No.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Sdoc_No.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Sdoc_No.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Sdoc_No.Image = null;
            this.txt_Sdoc_No.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Sdoc_No.Location = new System.Drawing.Point(378, 30);
            this.txt_Sdoc_No.Name = "txt_Sdoc_No";
            this.txt_Sdoc_No.Padding = new System.Windows.Forms.Padding(2);
            this.txt_Sdoc_No.PasswordChar = '\0';
            this.txt_Sdoc_No.Required = false;
            this.txt_Sdoc_No.Size = new System.Drawing.Size(203, 27);
            this.txt_Sdoc_No.TabIndex = 149;
            this.txt_Sdoc_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Sdoc_No_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 148;
            this.label6.Text = "--";
            // 
            // dtp_CreateTimeMax
            // 
            this.dtp_CreateTimeMax.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_CreateTimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_CreateTimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_CreateTimeMax.Location = new System.Drawing.Point(378, 69);
            this.dtp_CreateTimeMax.Name = "dtp_CreateTimeMax";
            this.dtp_CreateTimeMax.Size = new System.Drawing.Size(203, 26);
            this.dtp_CreateTimeMax.TabIndex = 146;
            // 
            // dtp_CreateTimeMin
            // 
            this.dtp_CreateTimeMin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_CreateTimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_CreateTimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_CreateTimeMin.Location = new System.Drawing.Point(79, 69);
            this.dtp_CreateTimeMin.Name = "dtp_CreateTimeMin";
            this.dtp_CreateTimeMin.Size = new System.Drawing.Size(203, 26);
            this.dtp_CreateTimeMin.TabIndex = 144;
            // 
            // lbl_typeCode
            // 
            this.lbl_typeCode.AutoSize = true;
            this.lbl_typeCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeCode.Location = new System.Drawing.Point(3, 73);
            this.lbl_typeCode.Name = "lbl_typeCode";
            this.lbl_typeCode.Size = new System.Drawing.Size(72, 16);
            this.lbl_typeCode.TabIndex = 119;
            this.lbl_typeCode.Text = "创建时间";
            // 
            // lbl_typeName
            // 
            this.lbl_typeName.AutoSize = true;
            this.lbl_typeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeName.Location = new System.Drawing.Point(8, 34);
            this.lbl_typeName.Name = "lbl_typeName";
            this.lbl_typeName.Size = new System.Drawing.Size(72, 16);
            this.lbl_typeName.TabIndex = 118;
            this.lbl_typeName.Text = "物料代码";
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(595, 68);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 116;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 110);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_Material);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_Detail);
            this.splitContainer2.Size = new System.Drawing.Size(992, 356);
            this.splitContainer2.SplitterDistance = 184;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgv_Material
            // 
            this.dgv_Material.AllowUserToAddRows = false;
            this.dgv_Material.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Material.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_Doc_NO2,
            this.MaterialCode2,
            this.dataGridViewTextBoxColumn5,
            this.UserName,
            this.Create_Time});
            this.dgv_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Material.Location = new System.Drawing.Point(0, 0);
            this.dgv_Material.Name = "dgv_Material";
            this.dgv_Material.RowHeadersVisible = false;
            this.dgv_Material.RowTemplate.Height = 23;
            this.dgv_Material.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Material.Size = new System.Drawing.Size(992, 184);
            this.dgv_Material.TabIndex = 2;
            this.dgv_Material.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Material_CellClick);
            this.dgv_Material.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Material_MouseDoubleClick);
            // 
            // S_Doc_NO2
            // 
            this.S_Doc_NO2.DataPropertyName = "S_Doc_NO";
            this.S_Doc_NO2.HeaderText = "单据号";
            this.S_Doc_NO2.Name = "S_Doc_NO2";
            this.S_Doc_NO2.ReadOnly = true;
            // 
            // MaterialCode2
            // 
            this.MaterialCode2.DataPropertyName = "MaterialCode";
            this.MaterialCode2.HeaderText = "物料代码";
            this.MaterialCode2.MinimumWidth = 120;
            this.MaterialCode2.Name = "MaterialCode2";
            this.MaterialCode2.ReadOnly = true;
            this.MaterialCode2.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Qty";
            this.dataGridViewTextBoxColumn5.HeaderText = "数量";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "创建人";
            this.UserName.Name = "UserName";
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            // 
            // dgv_Detail
            // 
            this.dgv_Detail.AllowUserToAddRows = false;
            this.dgv_Detail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.SerialNumber,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.Receive_Flag});
            this.dgv_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Detail.Location = new System.Drawing.Point(0, 0);
            this.dgv_Detail.Name = "dgv_Detail";
            this.dgv_Detail.RowHeadersVisible = false;
            this.dgv_Detail.RowTemplate.Height = 23;
            this.dgv_Detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Detail.Size = new System.Drawing.Size(992, 169);
            this.dgv_Detail.TabIndex = 2;
            this.dgv_Detail.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Detail_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "S_Doc_NO";
            this.dataGridViewTextBoxColumn10.HeaderText = "单据号";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // SerialNumber
            // 
            this.SerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "物料SN";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            this.SerialNumber.Width = 66;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "MaterialCode";
            this.dataGridViewTextBoxColumn12.HeaderText = "物料代码";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 120;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Qty";
            this.dataGridViewTextBoxColumn13.HeaderText = "数量";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // Receive_Flag
            // 
            this.Receive_Flag.DataPropertyName = "Receive_Flag";
            this.Receive_Flag.HeaderText = "状态";
            this.Receive_Flag.Name = "Receive_Flag";
            // 
            // ucMaterialBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucMaterialBack";
            this.Size = new System.Drawing.Size(992, 466);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Material)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_back;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXTextBox txt_Sdoc_No;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_CreateTimeMax;
        private System.Windows.Forms.DateTimePicker dtp_CreateTimeMin;
        private System.Windows.Forms.Label lbl_typeCode;
        private System.Windows.Forms.Label lbl_typeName;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CIT.Client.TXTextBox txt_MaterialCode;
        private System.Windows.Forms.DataGridView dgv_Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_Doc_NO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridView dgv_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receive_Flag;
    }
}
