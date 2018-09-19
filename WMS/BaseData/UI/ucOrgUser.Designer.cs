namespace BaseData.UI
{
    partial class ucOrgUser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.trv_org = new System.Windows.Forms.TreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txToolStrip2 = new CIT.Client.TXToolStrip();
            this.btn_addOrg = new System.Windows.Forms.ToolStripButton();
            this.btn_editOrg = new System.Windows.Forms.ToolStripButton();
            this.btn_deleteOrg = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_user = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_typeName = new System.Windows.Forms.Label();
            this.txt_userName = new CIT.Client.TXTextBox();
            this.btn_query = new CIT.Client.TXButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.txt_MaterialCode = new CIT.Client.TXTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.txToolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 822);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(612, 822);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "组织管理";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.trv_org);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(4, 80);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(604, 738);
            this.panel7.TabIndex = 1;
            // 
            // trv_org
            // 
            this.trv_org.BackColor = System.Drawing.SystemColors.Window;
            this.trv_org.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_org.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trv_org.Location = new System.Drawing.Point(0, 0);
            this.trv_org.Margin = new System.Windows.Forms.Padding(4);
            this.trv_org.Name = "trv_org";
            this.trv_org.Size = new System.Drawing.Size(604, 738);
            this.trv_org.TabIndex = 0;
            this.trv_org.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_org_AfterSelect);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txToolStrip2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(4, 32);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(604, 48);
            this.panel6.TabIndex = 0;
            // 
            // txToolStrip2
            // 
            this.txToolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip2.BeginBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txToolStrip2.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_addOrg,
            this.btn_editOrg,
            this.btn_deleteOrg});
            this.txToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip2.Name = "txToolStrip2";
            this.txToolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.txToolStrip2.Size = new System.Drawing.Size(604, 31);
            this.txToolStrip2.TabIndex = 9;
            this.txToolStrip2.Text = "txToolStrip2";
            // 
            // btn_addOrg
            // 
            this.btn_addOrg.Image = global::BaseData.Properties.Resources.add;
            this.btn_addOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_addOrg.Name = "btn_addOrg";
            this.btn_addOrg.Size = new System.Drawing.Size(74, 28);
            this.btn_addOrg.Text = "新增";
            this.btn_addOrg.Click += new System.EventHandler(this.btn_addOrg_Click);
            // 
            // btn_editOrg
            // 
            this.btn_editOrg.Image = global::BaseData.Properties.Resources.edit;
            this.btn_editOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_editOrg.Name = "btn_editOrg";
            this.btn_editOrg.Size = new System.Drawing.Size(74, 28);
            this.btn_editOrg.Text = "编辑";
            this.btn_editOrg.Click += new System.EventHandler(this.btn_editOrg_Click);
            // 
            // btn_deleteOrg
            // 
            this.btn_deleteOrg.Image = global::BaseData.Properties.Resources.delbinding;
            this.btn_deleteOrg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_deleteOrg.Name = "btn_deleteOrg";
            this.btn_deleteOrg.Size = new System.Drawing.Size(74, 28);
            this.btn_deleteOrg.Text = "删除";
            this.btn_deleteOrg.Click += new System.EventHandler(this.btn_deleteOrg_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(612, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 822);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1200, 822);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "人员管理";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgv_user);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 174);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1192, 644);
            this.panel5.TabIndex = 2;
            // 
            // dgv_user
            // 
            this.dgv_user.AllowUserToAddRows = false;
            this.dgv_user.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_user.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.Text});
            this.dgv_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_user.Location = new System.Drawing.Point(0, 0);
            this.dgv_user.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_user.Name = "dgv_user";
            this.dgv_user.ReadOnly = true;
            this.dgv_user.RowHeadersVisible = false;
            this.dgv_user.RowTemplate.Height = 23;
            this.dgv_user.Size = new System.Drawing.Size(1192, 644);
            this.dgv_user.TabIndex = 0;
            this.dgv_user.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_user_MouseDoubleClick);
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "用户ID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Text
            // 
            this.Text.DataPropertyName = "Text";
            this.Text.HeaderText = "所属部门";
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbl_typeName);
            this.panel4.Controls.Add(this.txt_userName);
            this.panel4.Controls.Add(this.btn_query);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 80);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1192, 94);
            this.panel4.TabIndex = 1;
            // 
            // lbl_typeName
            // 
            this.lbl_typeName.AutoSize = true;
            this.lbl_typeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeName.Location = new System.Drawing.Point(27, 36);
            this.lbl_typeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_typeName.Name = "lbl_typeName";
            this.lbl_typeName.Size = new System.Drawing.Size(82, 24);
            this.lbl_typeName.TabIndex = 116;
            this.lbl_typeName.Text = "用户名";
            // 
            // txt_userName
            // 
            this.txt_userName.BackColor = System.Drawing.Color.Transparent;
            this.txt_userName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_userName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_userName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_userName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_userName.Image = null;
            this.txt_userName.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_userName.Location = new System.Drawing.Point(117, 28);
            this.txt_userName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Padding = new System.Windows.Forms.Padding(3);
            this.txt_userName.PasswordChar = '\0';
            this.txt_userName.Required = false;
            this.txt_userName.Size = new System.Drawing.Size(225, 40);
            this.txt_userName.TabIndex = 115;
            // 
            // btn_query
            // 
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(350, 28);
            this.btn_query.Margin = new System.Windows.Forms.Padding(4);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(122, 40);
            this.btn_query.TabIndex = 114;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txToolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 32);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1192, 48);
            this.panel3.TabIndex = 0;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_add,
            this.btn_edit,
            this.btn_del});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.txToolStrip1.Size = new System.Drawing.Size(1192, 31);
            this.txToolStrip1.TabIndex = 8;
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
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_MaterialCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_MaterialCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_MaterialCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_MaterialCode.Image = null;
            this.txt_MaterialCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_MaterialCode.Location = new System.Drawing.Point(82, 20);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Padding = new System.Windows.Forms.Padding(2);
            this.txt_MaterialCode.PasswordChar = '\0';
            this.txt_MaterialCode.Required = false;
            this.txt_MaterialCode.Size = new System.Drawing.Size(150, 27);
            this.txt_MaterialCode.TabIndex = 115;
            // 
            // ucOrgUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucOrgUser";
            this.Size = new System.Drawing.Size(1812, 822);
            this.Load += new System.EventHandler(this.ucOrgUser_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.txToolStrip2.ResumeLayout(false);
            this.txToolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_user)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TreeView trv_org;
        private System.Windows.Forms.Panel panel6;
        private CIT.Client.TXToolStrip txToolStrip2;
        private System.Windows.Forms.ToolStripButton btn_addOrg;
        private System.Windows.Forms.ToolStripButton btn_editOrg;
        private System.Windows.Forms.ToolStripButton btn_deleteOrg;
        private System.Windows.Forms.DataGridView dgv_user;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_del;
        private CIT.Client.TXTextBox txt_MaterialCode;
        private System.Windows.Forms.Label lbl_typeName;
        private CIT.Client.TXTextBox txt_userName;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
    }
}
