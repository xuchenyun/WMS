namespace Common.UI
{
    partial class FrmSfcnoSelect
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
            this.dgv_sfnc = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_query = new CIT.Client.TXButton();
            this.lbl_sfcno = new System.Windows.Forms.Label();
            this.txt_sfcno = new CIT.Client.TXTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txButton2 = new CIT.Client.TXButton();
            this.txButton1 = new CIT.Client.TXButton();
            this.FGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SfcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sfnc)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_sfnc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 337);
            this.panel1.TabIndex = 0;
            // 
            // dgv_sfnc
            // 
            this.dgv_sfnc.AllowUserToAddRows = false;
            this.dgv_sfnc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_sfnc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_sfnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sfnc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGuid,
            this.SfcNo,
            this.TBT_ID,
            this.Product});
            this.dgv_sfnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sfnc.Location = new System.Drawing.Point(0, 0);
            this.dgv_sfnc.Name = "dgv_sfnc";
            this.dgv_sfnc.RowHeadersVisible = false;
            this.dgv_sfnc.RowTemplate.Height = 23;
            this.dgv_sfnc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sfnc.Size = new System.Drawing.Size(530, 337);
            this.dgv_sfnc.TabIndex = 0;
            this.dgv_sfnc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_sfnc_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Controls.Add(this.lbl_sfcno);
            this.panel2.Controls.Add(this.txt_sfcno);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 57);
            this.panel2.TabIndex = 1;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(257, 13);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(73, 39);
            this.btn_query.TabIndex = 84;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // lbl_sfcno
            // 
            this.lbl_sfcno.AutoSize = true;
            this.lbl_sfcno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_sfcno.Location = new System.Drawing.Point(27, 24);
            this.lbl_sfcno.Name = "lbl_sfcno";
            this.lbl_sfcno.Size = new System.Drawing.Size(56, 16);
            this.lbl_sfcno.TabIndex = 83;
            this.lbl_sfcno.Text = "制令单";
            // 
            // txt_sfcno
            // 
            this.txt_sfcno.BackColor = System.Drawing.Color.Transparent;
            this.txt_sfcno.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_sfcno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sfcno.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_sfcno.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_sfcno.Image = null;
            this.txt_sfcno.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_sfcno.Location = new System.Drawing.Point(89, 19);
            this.txt_sfcno.Name = "txt_sfcno";
            this.txt_sfcno.Padding = new System.Windows.Forms.Padding(2);
            this.txt_sfcno.PasswordChar = '\0';
            this.txt_sfcno.Required = false;
            this.txt_sfcno.Size = new System.Drawing.Size(150, 27);
            this.txt_sfcno.TabIndex = 82;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txButton2);
            this.panel3.Controls.Add(this.txButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(1, 352);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(530, 69);
            this.panel3.TabIndex = 2;
            // 
            // txButton2
            // 
            this.txButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton2.Image = null;
            this.txButton2.Location = new System.Drawing.Point(442, 15);
            this.txButton2.Name = "txButton2";
            this.txButton2.Size = new System.Drawing.Size(73, 39);
            this.txButton2.TabIndex = 86;
            this.txButton2.Text = "取消";
            this.txButton2.UseVisualStyleBackColor = true;
            this.txButton2.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // txButton1
            // 
            this.txButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txButton1.Image = null;
            this.txButton1.Location = new System.Drawing.Point(363, 15);
            this.txButton1.Name = "txButton1";
            this.txButton1.Size = new System.Drawing.Size(73, 39);
            this.txButton1.TabIndex = 85;
            this.txButton1.Text = "确定";
            this.txButton1.UseVisualStyleBackColor = true;
            this.txButton1.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // FGuid
            // 
            this.FGuid.DataPropertyName = "FGuid";
            this.FGuid.HeaderText = "FGuid";
            this.FGuid.Name = "FGuid";
            this.FGuid.Visible = false;
            // 
            // SfcNo
            // 
            this.SfcNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SfcNo.DataPropertyName = "SfcNo";
            this.SfcNo.HeaderText = "制令单";
            this.SfcNo.Name = "SfcNo";
            this.SfcNo.ReadOnly = true;
            // 
            // TBT_ID
            // 
            this.TBT_ID.DataPropertyName = "TBT_ID";
            this.TBT_ID.HeaderText = "工艺ID";
            this.TBT_ID.Name = "TBT_ID";
            this.TBT_ID.ReadOnly = true;
            this.TBT_ID.Visible = false;
            this.TBT_ID.Width = 260;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product";
            this.Product.HeaderText = "产品代码";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Visible = false;
            // 
            // FrmSfcnoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 422);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmSfcnoSelect";
            this.Text = "制令单选择";
            this.Load += new System.EventHandler(this.FrmSfcnoSelect_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sfnc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_sfnc;
        private System.Windows.Forms.Panel panel2;
        private CIT.Client.TXButton btn_query;
        private System.Windows.Forms.Label lbl_sfcno;
        private CIT.Client.TXTextBox txt_sfcno;
        private System.Windows.Forms.Panel panel3;
        private CIT.Client.TXButton txButton2;
        private CIT.Client.TXButton txButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn SfcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TBT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
    }
}