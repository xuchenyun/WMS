namespace CIT.MES.Setting.PrintView
{
    partial class FrmLineOutReel
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
            this.LabCompany = new System.Windows.Forms.Label();
            this.Labdp = new System.Windows.Forms.Label();
            this.LabWo = new System.Windows.Forms.Label();
            this.LabTitle = new System.Windows.Forms.Label();
            this.LabPN = new System.Windows.Forms.Label();
            this.LabDesc = new System.Windows.Forms.Label();
            this.LabQty = new System.Windows.Forms.Label();
            this.LabUser = new System.Windows.Forms.Label();
            this.LbxListProject = new CIT.Client.TXListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_print = new CIT.Client.TXButton();
            this.txt_dp = new System.Windows.Forms.TextBox();
            this.txt_wo = new System.Windows.Forms.TextBox();
            this.txt_br = new System.Windows.Forms.TextBox();
            this.txt_qc = new System.Windows.Forms.TextBox();
            this.txt_rec = new System.Windows.Forms.TextBox();
            this.txt_Product = new System.Windows.Forms.TextBox();
            this.LabProduct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabCompany
            // 
            this.LabCompany.AutoSize = true;
            this.LabCompany.BackColor = System.Drawing.Color.Transparent;
            this.LabCompany.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabCompany.Location = new System.Drawing.Point(50, 38);
            this.LabCompany.Name = "LabCompany";
            this.LabCompany.Size = new System.Drawing.Size(0, 24);
            this.LabCompany.TabIndex = 0;
            // 
            // Labdp
            // 
            this.Labdp.AutoSize = true;
            this.Labdp.BackColor = System.Drawing.Color.Transparent;
            this.Labdp.Location = new System.Drawing.Point(46, 70);
            this.Labdp.Name = "Labdp";
            this.Labdp.Size = new System.Drawing.Size(41, 12);
            this.Labdp.TabIndex = 4;
            this.Labdp.Text = "生产线";
            // 
            // LabWo
            // 
            this.LabWo.AutoSize = true;
            this.LabWo.BackColor = System.Drawing.Color.Transparent;
            this.LabWo.Location = new System.Drawing.Point(46, 118);
            this.LabWo.Name = "LabWo";
            this.LabWo.Size = new System.Drawing.Size(41, 12);
            this.LabWo.TabIndex = 6;
            this.LabWo.Text = "工单号";
            // 
            // LabTitle
            // 
            this.LabTitle.AutoSize = true;
            this.LabTitle.BackColor = System.Drawing.Color.Transparent;
            this.LabTitle.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabTitle.Location = new System.Drawing.Point(419, 50);
            this.LabTitle.Name = "LabTitle";
            this.LabTitle.Size = new System.Drawing.Size(85, 24);
            this.LabTitle.TabIndex = 7;
            this.LabTitle.Text = "退料单";
            // 
            // LabPN
            // 
            this.LabPN.AutoSize = true;
            this.LabPN.BackColor = System.Drawing.Color.Transparent;
            this.LabPN.Location = new System.Drawing.Point(58, 142);
            this.LabPN.Name = "LabPN";
            this.LabPN.Size = new System.Drawing.Size(101, 12);
            this.LabPN.TabIndex = 8;
            this.LabPN.Text = "Code no 元件编码";
            // 
            // LabDesc
            // 
            this.LabDesc.AutoSize = true;
            this.LabDesc.BackColor = System.Drawing.Color.Transparent;
            this.LabDesc.Location = new System.Drawing.Point(255, 142);
            this.LabDesc.Name = "LabDesc";
            this.LabDesc.Size = new System.Drawing.Size(125, 12);
            this.LabDesc.TabIndex = 9;
            this.LabDesc.Text = "Description规格/名称";
            // 
            // LabQty
            // 
            this.LabQty.AutoSize = true;
            this.LabQty.BackColor = System.Drawing.Color.Transparent;
            this.LabQty.Location = new System.Drawing.Point(477, 142);
            this.LabQty.Name = "LabQty";
            this.LabQty.Size = new System.Drawing.Size(77, 12);
            this.LabQty.TabIndex = 10;
            this.LabQty.Text = "Quantity数量";
            // 
            // LabUser
            // 
            this.LabUser.AutoSize = true;
            this.LabUser.BackColor = System.Drawing.Color.Transparent;
            this.LabUser.Location = new System.Drawing.Point(699, 142);
            this.LabUser.Name = "LabUser";
            this.LabUser.Size = new System.Drawing.Size(71, 12);
            this.LabUser.TabIndex = 11;
            this.LabUser.Text = "User 退料人";
            // 
            // LbxListProject
            // 
            this.LbxListProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbxListProject.BackColor = System.Drawing.Color.White;
            this.LbxListProject.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.LbxListProject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LbxListProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LbxListProject.ColumnsWidthType = System.Windows.Forms.SizeType.AutoSize;
            this.LbxListProject.Font = new System.Drawing.Font("宋体", 9.6F);
            this.LbxListProject.FullRowSelect = true;
            this.LbxListProject.GridLines = true;
            this.LbxListProject.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.LbxListProject.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.LbxListProject.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LbxListProject.Location = new System.Drawing.Point(50, 168);
            this.LbxListProject.Name = "LbxListProject";
            this.LbxListProject.OwnerDraw = true;
            this.LbxListProject.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.LbxListProject.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.LbxListProject.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.LbxListProject.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
            this.LbxListProject.Size = new System.Drawing.Size(858, 303);
            this.LbxListProject.TabIndex = 12;
            this.LbxListProject.UseCompatibleStateImageBehavior = false;
            this.LbxListProject.View = System.Windows.Forms.View.Details;
            this.LbxListProject.SizeChanged += new System.EventHandler(this.LbxListProject_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 25;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 25;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 25;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_print.Image = null;
            this.btn_print.Location = new System.Drawing.Point(684, 479);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(115, 42);
            this.btn_print.TabIndex = 19;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // txt_dp
            // 
            this.txt_dp.Location = new System.Drawing.Point(95, 66);
            this.txt_dp.Name = "txt_dp";
            this.txt_dp.Size = new System.Drawing.Size(103, 21);
            this.txt_dp.TabIndex = 20;
            // 
            // txt_wo
            // 
            this.txt_wo.Location = new System.Drawing.Point(95, 114);
            this.txt_wo.Name = "txt_wo";
            this.txt_wo.Size = new System.Drawing.Size(196, 21);
            this.txt_wo.TabIndex = 21;
            // 
            // txt_br
            // 
            this.txt_br.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_br.Location = new System.Drawing.Point(50, 487);
            this.txt_br.Name = "txt_br";
            this.txt_br.Size = new System.Drawing.Size(129, 21);
            this.txt_br.TabIndex = 22;
            // 
            // txt_qc
            // 
            this.txt_qc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_qc.Location = new System.Drawing.Point(279, 487);
            this.txt_qc.Name = "txt_qc";
            this.txt_qc.Size = new System.Drawing.Size(129, 21);
            this.txt_qc.TabIndex = 23;
            // 
            // txt_rec
            // 
            this.txt_rec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_rec.Location = new System.Drawing.Point(504, 487);
            this.txt_rec.Name = "txt_rec";
            this.txt_rec.Size = new System.Drawing.Size(129, 21);
            this.txt_rec.TabIndex = 24;
            // 
            // txt_Product
            // 
            this.txt_Product.Location = new System.Drawing.Point(95, 90);
            this.txt_Product.Name = "txt_Product";
            this.txt_Product.Size = new System.Drawing.Size(103, 21);
            this.txt_Product.TabIndex = 26;
            // 
            // LabProduct
            // 
            this.LabProduct.AutoSize = true;
            this.LabProduct.BackColor = System.Drawing.Color.Transparent;
            this.LabProduct.Location = new System.Drawing.Point(58, 94);
            this.LabProduct.Name = "LabProduct";
            this.LabProduct.Size = new System.Drawing.Size(29, 12);
            this.LabProduct.TabIndex = 25;
            this.LabProduct.Text = "产品";
            // 
            // FrmLineOutReel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 527);
            this.Controls.Add(this.txt_Product);
            this.Controls.Add(this.LabProduct);
            this.Controls.Add(this.txt_rec);
            this.Controls.Add(this.txt_qc);
            this.Controls.Add(this.txt_br);
            this.Controls.Add(this.txt_wo);
            this.Controls.Add(this.txt_dp);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.LbxListProject);
            this.Controls.Add(this.LabUser);
            this.Controls.Add(this.LabQty);
            this.Controls.Add(this.LabDesc);
            this.Controls.Add(this.LabPN);
            this.Controls.Add(this.LabTitle);
            this.Controls.Add(this.LabWo);
            this.Controls.Add(this.Labdp);
            this.Controls.Add(this.LabCompany);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineOutReel";
            this.Text = "退料单打印";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabCompany;
        private System.Windows.Forms.Label Labdp;
        private System.Windows.Forms.Label LabWo;
        private System.Windows.Forms.Label LabTitle;
        private System.Windows.Forms.Label LabPN;
        private System.Windows.Forms.Label LabDesc;
        private System.Windows.Forms.Label LabQty;
        private System.Windows.Forms.Label LabUser;
        private Client.TXListView LbxListProject;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Client.TXButton btn_print;
        private System.Windows.Forms.TextBox txt_dp;
        private System.Windows.Forms.TextBox txt_wo;
        private System.Windows.Forms.TextBox txt_br;
        private System.Windows.Forms.TextBox txt_qc;
        private System.Windows.Forms.TextBox txt_rec;
        private System.Windows.Forms.TextBox txt_Product;
        private System.Windows.Forms.Label LabProduct;

    }
}