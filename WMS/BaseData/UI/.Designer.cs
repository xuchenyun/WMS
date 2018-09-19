namespace BaseData.UI
{
    partial class ucMaterialQuery
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
            this.cbo_houseName = new CIT.Client.TXComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_TYPE = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_materialCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_query = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Material = new System.Windows.Forms.DataGridView();
            this.MaterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShelfLifeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondMaterialClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SafeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSendCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INCOMINGTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackagingMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackagingMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Material)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 33);
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
            this.txToolStrip1.Size = new System.Drawing.Size(1106, 31);
            this.txToolStrip1.TabIndex = 8;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::BaseData.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 28);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = global::BaseData.Properties.Resources.edit;
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(60, 28);
            this.btn_edit.Text = "编辑";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_del
            // 
            this.btn_del.Image = global::BaseData.Properties.Resources.delbinding;
            this.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(60, 28);
            this.btn_del.Text = "删除";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_houseName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbo_TYPE);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_materialCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1106, 77);
            this.panel2.TabIndex = 1;
            // 
            // cbo_houseName
            // 
            this.cbo_houseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_houseName.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_houseName.FormattingEnabled = true;
            this.cbo_houseName.Location = new System.Drawing.Point(571, 24);
            this.cbo_houseName.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_houseName.Name = "cbo_houseName";
            this.cbo_houseName.Size = new System.Drawing.Size(177, 24);
            this.cbo_houseName.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 146;
            this.label3.Text = "仓库";
            // 
            // cbo_TYPE
            // 
            this.cbo_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TYPE.Font = new System.Drawing.Font("宋体", 12F);
            this.cbo_TYPE.FormattingEnabled = true;
            this.cbo_TYPE.Location = new System.Drawing.Point(311, 24);
            this.cbo_TYPE.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_TYPE.Name = "cbo_TYPE";
            this.cbo_TYPE.Size = new System.Drawing.Size(177, 24);
            this.cbo_TYPE.TabIndex = 145;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "类型";
            // 
            // txt_materialCode
            // 
            this.txt_materialCode.Location = new System.Drawing.Point(73, 26);
            this.txt_materialCode.Name = "txt_materialCode";
            this.txt_materialCode.Size = new System.Drawing.Size(155, 21);
            this.txt_materialCode.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "料号";
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(775, 25);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 5;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Material);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1106, 400);
            this.panel3.TabIndex = 2;
            // 
            // dgv_Material
            // 
            this.dgv_Material.AllowUserToAddRows = false;
            this.dgv_Material.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Material.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialCode,
            this.MaterialName,
            this.Type,
            this.HouseCode,
            this.ShelfLifeTime,
            this.Spec,
            this.HouseCode1,
            this.HouseCode2,
            this.IsMSD,
            this.SecondMaterialClass,
            this.SafeQty,
            this.IsSendCheck,
            this.INCOMINGTYPE,
            this.PackagingMax,
            this.PackagingMin,
            this.PackageType});
            this.dgv_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Material.Location = new System.Drawing.Point(0, 0);
            this.dgv_Material.Name = "dgv_Material";
            this.dgv_Material.RowHeadersVisible = false;
            this.dgv_Material.RowTemplate.Height = 23;
            this.dgv_Material.Size = new System.Drawing.Size(1106, 400);
            this.dgv_Material.TabIndex = 0;
            this.dgv_Material.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Material_MouseDoubleClick);
            // 
            // MaterialCode
            // 
            this.MaterialCode.DataPropertyName = "MaterialCode";
            this.MaterialCode.HeaderText = "料号";
            this.MaterialCode.Name = "MaterialCode";
            this.MaterialCode.ReadOnly = true;
            // 
            // MaterialName
            // 
            this.MaterialName.DataPropertyName = "MaterialName";
            this.MaterialName.HeaderText = "品名";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // HouseCode
            // 
            this.HouseCode.DataPropertyName = "HouseCode";
            this.HouseCode.HeaderText = "仓库";
            this.HouseCode.Name = "HouseCode";
            this.HouseCode.ReadOnly = true;
            // 
            // ShelfLifeTime
            // 
            this.ShelfLifeTime.DataPropertyName = "ShelfLifeTime";
            this.ShelfLifeTime.HeaderText = "保质期";
            this.ShelfLifeTime.Name = "ShelfLifeTime";
            this.ShelfLifeTime.ReadOnly = true;
            // 
            // Spec
            // 
            this.Spec.DataPropertyName = "Spec";
            this.Spec.HeaderText = "规格";
            this.Spec.Name = "Spec";
            this.Spec.ReadOnly = true;
            // 
            // HouseCode1
            // 
            this.HouseCode1.DataPropertyName = "HouseCode1";
            this.HouseCode1.HeaderText = "备用仓库1";
            this.HouseCode1.Name = "HouseCode1";
            this.HouseCode1.ReadOnly = true;
            // 
            // HouseCode2
            // 
            this.HouseCode2.DataPropertyName = "HouseCode2";
            this.HouseCode2.HeaderText = "备用仓库2";
            this.HouseCode2.Name = "HouseCode2";
            this.HouseCode2.ReadOnly = true;
            // 
            // IsMSD
            // 
            this.IsMSD.DataPropertyName = "IsMSD";
            this.IsMSD.HeaderText = "是否MSD";
            this.IsMSD.Name = "IsMSD";
            this.IsMSD.ReadOnly = true;
            // 
            // SecondMaterialClass
            // 
            this.SecondMaterialClass.DataPropertyName = "SecondMaterialClass";
            this.SecondMaterialClass.HeaderText = "辅材等级";
            this.SecondMaterialClass.Name = "SecondMaterialClass";
            this.SecondMaterialClass.ReadOnly = true;
            // 
            // SafeQty
            // 
            this.SafeQty.DataPropertyName = "SafeQty";
            this.SafeQty.HeaderText = "安全库存";
            this.SafeQty.Name = "SafeQty";
            this.SafeQty.ReadOnly = true;
            // 
            // IsSendCheck
            // 
            this.IsSendCheck.DataPropertyName = "IsSendCheck";
            this.IsSendCheck.HeaderText = "是否送检";
            this.IsSendCheck.Name = "IsSendCheck";
            this.IsSendCheck.ReadOnly = true;
            // 
            // INCOMINGTYPE
            // 
            this.INCOMINGTYPE.DataPropertyName = "INCOMINGTYPE";
            this.INCOMINGTYPE.HeaderText = "供料模式";
            this.INCOMINGTYPE.Name = "INCOMINGTYPE";
            this.INCOMINGTYPE.ReadOnly = true;
            // 
            // PackagingMax
            // 
            this.PackagingMax.DataPropertyName = "PackagingMax";
            this.PackagingMax.HeaderText = "最大包装";
            this.PackagingMax.Name = "PackagingMax";
            this.PackagingMax.ReadOnly = true;
            // 
            // PackagingMin
            // 
            this.PackagingMin.DataPropertyName = "PackagingMin";
            this.PackagingMin.HeaderText = "最小包装";
            this.PackagingMin.Name = "PackagingMin";
            this.PackagingMin.ReadOnly = true;
            // 
            // PackageType
            // 
            this.PackageType.DataPropertyName = "PackageType";
            this.PackageType.HeaderText = "包装类型";
            this.PackageType.Name = "PackageType";
            this.PackageType.ReadOnly = true;
            // 
            // ucMaterialQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucMaterialQuery";
            this.Size = new System.Drawing.Size(1106, 510);
            this.Load += new System.EventHandler(this.ucMaterialQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Material)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_materialCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_query;
        private CIT.Client.TXComboBox cbo_houseName;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXComboBox cbo_TYPE;
        private System.Windows.Forms.DataGridView dgv_Material;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShelfLifeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsMSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondMaterialClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn SafeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSendCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn INCOMINGTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackagingMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackagingMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageType;
    }
}
