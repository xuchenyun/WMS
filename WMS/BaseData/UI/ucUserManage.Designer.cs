namespace BaseData.UI
{
    partial class ucUserManage
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
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_typeName = new System.Windows.Forms.Label();
            this.txt_MaterialCode = new CIT.Client.TXTextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.dgv_User = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_Menu = new System.Windows.Forms.DataGridView();
            this.CHK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txToolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Menu)).BeginInit();
            this.SuspendLayout();
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
            this.txToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.txToolStrip1.Size = new System.Drawing.Size(1532, 31);
            this.txToolStrip1.TabIndex = 7;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::BaseData.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(74, 28);
            this.btn_add.Text = "新增";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Image = global::BaseData.Properties.Resources.edit;
            this.btn_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(74, 28);
            this.btn_edit.Text = "编辑";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_del
            // 
            this.btn_del.Image = global::BaseData.Properties.Resources.delbinding;
            this.btn_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(74, 28);
            this.btn_del.Text = "删除";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_typeName);
            this.panel1.Controls.Add(this.txt_MaterialCode);
            this.panel1.Controls.Add(this.btn_query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1532, 81);
            this.panel1.TabIndex = 8;
            // 
            // lbl_typeName
            // 
            this.lbl_typeName.AutoSize = true;
            this.lbl_typeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeName.Location = new System.Drawing.Point(43, 25);
            this.lbl_typeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_typeName.Name = "lbl_typeName";
            this.lbl_typeName.Size = new System.Drawing.Size(82, 24);
            this.lbl_typeName.TabIndex = 113;
            this.lbl_typeName.Text = "用户ID";
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
            this.txt_MaterialCode.Location = new System.Drawing.Point(133, 18);
            this.txt_MaterialCode.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Padding = new System.Windows.Forms.Padding(3);
            this.txt_MaterialCode.PasswordChar = '\0';
            this.txt_MaterialCode.Required = false;
            this.txt_MaterialCode.Size = new System.Drawing.Size(225, 40);
            this.txt_MaterialCode.TabIndex = 112;
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(366, 18);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(122, 40);
            this.btn_query.TabIndex = 111;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // dgv_User
            // 
            this.dgv_User.AllowUserToAddRows = false;
            this.dgv_User.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHK,
            this.UserID,
            this.UserName});
            this.dgv_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_User.Location = new System.Drawing.Point(0, 0);
            this.dgv_User.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_User.Name = "dgv_User";
            this.dgv_User.RowHeadersVisible = false;
            this.dgv_User.RowTemplate.Height = 23;
            this.dgv_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_User.Size = new System.Drawing.Size(916, 605);
            this.dgv_User.TabIndex = 0;
            this.dgv_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_User_CellClick);
            this.dgv_User.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Material_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 112);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_User);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Menu);
            this.splitContainer1.Size = new System.Drawing.Size(1532, 605);
            this.splitContainer1.SplitterDistance = 916;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // dgv_Menu
            // 
            this.dgv_Menu.AllowUserToAddRows = false;
            this.dgv_Menu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Menu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuCode,
            this.MenuName});
            this.dgv_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Menu.Location = new System.Drawing.Point(0, 0);
            this.dgv_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Menu.Name = "dgv_Menu";
            this.dgv_Menu.RowHeadersVisible = false;
            this.dgv_Menu.RowTemplate.Height = 23;
            this.dgv_Menu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Menu.Size = new System.Drawing.Size(610, 605);
            this.dgv_Menu.TabIndex = 0;
            this.dgv_Menu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_StepAndQulity_MouseDoubleClick);
            // 
            // CHK
            // 
            this.CHK.DataPropertyName = "CHK";
            this.CHK.HeaderText = "";
            this.CHK.Name = "CHK";
            this.CHK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CHK.Width = 50;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "用户ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Width = 150;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "名称";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserName.Width = 150;
            // 
            // MenuCode
            // 
            this.MenuCode.DataPropertyName = "MenuCode";
            this.MenuCode.HeaderText = "菜单代码";
            this.MenuCode.Name = "MenuCode";
            this.MenuCode.Visible = false;
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "菜单名称";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            this.MenuName.Width = 150;
            // 
            // ucUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txToolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucUserManage";
            this.Size = new System.Drawing.Size(1532, 717);
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Menu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_del;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_typeName;
        private CIT.Client.TXTextBox txt_MaterialCode;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.DataGridView dgv_User;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Menu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHK;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
    }
}
