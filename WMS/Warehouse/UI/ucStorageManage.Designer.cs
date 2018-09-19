namespace Warehouse.UI
{
    partial class ucStorageManage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.btn_add = new System.Windows.Forms.ToolStripButton();
            this.btn_edit = new System.Windows.Forms.ToolStripButton();
            this.btn_del = new System.Windows.Forms.ToolStripButton();
            this.btn_import = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tv_Storage = new System.Windows.Forms.TreeView();
            this.cbo_Type = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_SN = new System.Windows.Forms.Label();
            this.txt_StorageSN = new CIT.Client.TXTextBox();
            this.txt_StorageName = new CIT.Client.TXTextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_ParentStorage = new System.Windows.Forms.Label();
            this.cbo_ParentStorage = new CIT.Client.TXComboBox();
            this.btn_ok = new CIT.Client.TXButton();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.btn_no = new CIT.Client.TXButton();
            this.chk_Enable_Flag = new System.Windows.Forms.CheckBox();
            this.lblPerson = new System.Windows.Forms.Label();
            this.cbo_Person = new CIT.Client.TXComboBox();
            this.cmb_AreaType = new CIT.Client.TXComboBox();
            this.lbl_AreaType = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.txToolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 25);
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
            this.btn_del,
            this.btn_import});
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(814, 31);
            this.txToolStrip1.TabIndex = 9;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // btn_add
            // 
            this.btn_add.Image = global::Warehouse.Properties.Resources.add;
            this.btn_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(60, 28);
            this.btn_add.Text = "新增";
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
            // btn_import
            // 
            this.btn_import.Image = global::Warehouse.Properties.Resources.aync_wo;
            this.btn_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(108, 28);
            this.btn_import.Text = "批量添加库位";
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tv_Storage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 359);
            this.panel2.TabIndex = 1;
            // 
            // tv_Storage
            // 
            this.tv_Storage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Storage.Location = new System.Drawing.Point(0, 0);
            this.tv_Storage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tv_Storage.Name = "tv_Storage";
            this.tv_Storage.Size = new System.Drawing.Size(414, 359);
            this.tv_Storage.TabIndex = 0;
            this.tv_Storage.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Storage_AfterSelect);
            // 
            // cbo_Type
            // 
            this.cbo_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Type.Enabled = false;
            this.cbo_Type.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_Type.FormattingEnabled = true;
            this.cbo_Type.Location = new System.Drawing.Point(531, 57);
            this.cbo_Type.Name = "cbo_Type";
            this.cbo_Type.Size = new System.Drawing.Size(164, 24);
            this.cbo_Type.TabIndex = 121;
            this.cbo_Type.SelectedIndexChanged += new System.EventHandler(this.cbo_Type_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(441, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 122;
            this.label2.Text = "储位类型";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_SN
            // 
            this.lbl_SN.Location = new System.Drawing.Point(473, 135);
            this.lbl_SN.Name = "lbl_SN";
            this.lbl_SN.Size = new System.Drawing.Size(53, 12);
            this.lbl_SN.TabIndex = 123;
            this.lbl_SN.Text = "储位SN";
            this.lbl_SN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_StorageSN
            // 
            this.txt_StorageSN.BackColor = System.Drawing.Color.Transparent;
            this.txt_StorageSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_StorageSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_StorageSN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_StorageSN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_StorageSN.Image = null;
            this.txt_StorageSN.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_StorageSN.Location = new System.Drawing.Point(531, 127);
            this.txt_StorageSN.Name = "txt_StorageSN";
            this.txt_StorageSN.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_StorageSN.PasswordChar = '\0';
            this.txt_StorageSN.ReadOnly = true;
            this.txt_StorageSN.Required = false;
            this.txt_StorageSN.Size = new System.Drawing.Size(164, 27);
            this.txt_StorageSN.TabIndex = 124;
            // 
            // txt_StorageName
            // 
            this.txt_StorageName.BackColor = System.Drawing.Color.Transparent;
            this.txt_StorageName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_StorageName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_StorageName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_StorageName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_StorageName.Image = null;
            this.txt_StorageName.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_StorageName.Location = new System.Drawing.Point(531, 167);
            this.txt_StorageName.Name = "txt_StorageName";
            this.txt_StorageName.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_StorageName.PasswordChar = '\0';
            this.txt_StorageName.ReadOnly = true;
            this.txt_StorageName.Required = false;
            this.txt_StorageName.Size = new System.Drawing.Size(163, 27);
            this.txt_StorageName.TabIndex = 126;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(454, 175);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(72, 12);
            this.lbl_Name.TabIndex = 125;
            this.lbl_Name.Text = "储位名称";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ParentStorage
            // 
            this.lbl_ParentStorage.Location = new System.Drawing.Point(439, 99);
            this.lbl_ParentStorage.Name = "lbl_ParentStorage";
            this.lbl_ParentStorage.Size = new System.Drawing.Size(87, 12);
            this.lbl_ParentStorage.TabIndex = 128;
            this.lbl_ParentStorage.Text = "父级储位";
            this.lbl_ParentStorage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_ParentStorage
            // 
            this.cbo_ParentStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ParentStorage.Enabled = false;
            this.cbo_ParentStorage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_ParentStorage.FormattingEnabled = true;
            this.cbo_ParentStorage.Location = new System.Drawing.Point(531, 93);
            this.cbo_ParentStorage.Name = "cbo_ParentStorage";
            this.cbo_ParentStorage.Size = new System.Drawing.Size(164, 24);
            this.cbo_ParentStorage.TabIndex = 127;
            // 
            // btn_ok
            // 
            this.btn_ok.Enabled = false;
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(531, 360);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(64, 35);
            this.btn_ok.TabIndex = 129;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_Msg.Font = new System.Drawing.Font("宋体", 30F);
            this.lbl_Msg.Location = new System.Drawing.Point(0, 384);
            this.lbl_Msg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(814, 47);
            this.lbl_Msg.TabIndex = 131;
            this.lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_no
            // 
            this.btn_no.Enabled = false;
            this.btn_no.Image = null;
            this.btn_no.Location = new System.Drawing.Point(631, 360);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(64, 35);
            this.btn_no.TabIndex = 133;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // chk_Enable_Flag
            // 
            this.chk_Enable_Flag.AutoSize = true;
            this.chk_Enable_Flag.Checked = true;
            this.chk_Enable_Flag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Enable_Flag.Enabled = false;
            this.chk_Enable_Flag.Location = new System.Drawing.Point(531, 38);
            this.chk_Enable_Flag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chk_Enable_Flag.Name = "chk_Enable_Flag";
            this.chk_Enable_Flag.Size = new System.Drawing.Size(48, 16);
            this.chk_Enable_Flag.TabIndex = 134;
            this.chk_Enable_Flag.Text = "启用";
            this.chk_Enable_Flag.UseVisualStyleBackColor = true;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(454, 216);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(72, 12);
            this.lblPerson.TabIndex = 135;
            this.lblPerson.Text = "仓库负责人";
            this.lblPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_Person
            // 
            this.cbo_Person.Enabled = false;
            this.cbo_Person.FormattingEnabled = true;
            this.cbo_Person.Location = new System.Drawing.Point(532, 213);
            this.cbo_Person.Name = "cbo_Person";
            this.cbo_Person.Size = new System.Drawing.Size(163, 20);
            this.cbo_Person.TabIndex = 136;
            this.cbo_Person.Visible = false;
            this.cbo_Person.TextUpdate += new System.EventHandler(this.cbo_Person_TextUpdate);
            // 
            // cmb_AreaType
            // 
            this.cmb_AreaType.Enabled = false;
            this.cmb_AreaType.FormattingEnabled = true;
            this.cmb_AreaType.Location = new System.Drawing.Point(532, 254);
            this.cmb_AreaType.Name = "cmb_AreaType";
            this.cmb_AreaType.Size = new System.Drawing.Size(163, 20);
            this.cmb_AreaType.TabIndex = 137;
            this.cmb_AreaType.Visible = false;
            // 
            // lbl_AreaType
            // 
            this.lbl_AreaType.Location = new System.Drawing.Point(454, 257);
            this.lbl_AreaType.Name = "lbl_AreaType";
            this.lbl_AreaType.Size = new System.Drawing.Size(72, 12);
            this.lbl_AreaType.TabIndex = 138;
            this.lbl_AreaType.Text = "库区类型";
            this.lbl_AreaType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucStorageManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_AreaType);
            this.Controls.Add(this.cmb_AreaType);
            this.Controls.Add(this.cbo_Person);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.chk_Enable_Flag);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_ParentStorage);
            this.Controls.Add(this.cbo_ParentStorage);
            this.Controls.Add(this.txt_StorageName);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.txt_StorageSN);
            this.Controls.Add(this.lbl_SN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_Type);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_Msg);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucStorageManage";
            this.Size = new System.Drawing.Size(814, 431);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.txToolStrip1.ResumeLayout(false);
            this.txToolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tv_Storage;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add;
        private System.Windows.Forms.ToolStripButton btn_edit;
        private System.Windows.Forms.ToolStripButton btn_del;
        private CIT.Client.TXComboBox cbo_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_SN;
        private CIT.Client.TXTextBox txt_StorageSN;
        private CIT.Client.TXTextBox txt_StorageName;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_ParentStorage;
        private CIT.Client.TXComboBox cbo_ParentStorage;
        private CIT.Client.TXButton btn_ok;
        private System.Windows.Forms.Label lbl_Msg;
        private System.Windows.Forms.ToolStripButton btn_import;
        private CIT.Client.TXButton btn_no;
        private System.Windows.Forms.CheckBox chk_Enable_Flag;
        private System.Windows.Forms.Label lblPerson;
        private CIT.Client.TXComboBox cbo_Person;
        private CIT.Client.TXComboBox cmb_AreaType;
        private System.Windows.Forms.Label lbl_AreaType;
    }
}