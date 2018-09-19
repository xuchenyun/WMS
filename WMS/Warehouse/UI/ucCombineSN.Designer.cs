namespace Warehouse.UI
{
    partial class ucCombineSN
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_combine = new CIT.Client.TXButton();
            this.txtFsn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMsn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trv_node = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_combine);
            this.groupBox1.Controls.Add(this.txtFsn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMsn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合盘操作";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.Location = new System.Drawing.Point(477, 83);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(236, 48);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "         ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(388, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "总数量";
            // 
            // btn_combine
            // 
            this.btn_combine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_combine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_combine.Image = null;
            this.btn_combine.Location = new System.Drawing.Point(258, 124);
            this.btn_combine.Name = "btn_combine";
            this.btn_combine.Size = new System.Drawing.Size(81, 27);
            this.btn_combine.TabIndex = 175;
            this.btn_combine.Text = "合盘";
            this.btn_combine.UseVisualStyleBackColor = true;
            this.btn_combine.Click += new System.EventHandler(this.btn_combine_Click);
            // 
            // txtFsn
            // 
            this.txtFsn.Location = new System.Drawing.Point(100, 97);
            this.txtFsn.Name = "txtFsn";
            this.txtFsn.Size = new System.Drawing.Size(239, 21);
            this.txtFsn.TabIndex = 80;
            this.txtFsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFsn_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 79;
            this.label1.Text = "附料卷";
            // 
            // txtMsn
            // 
            this.txtMsn.Location = new System.Drawing.Point(100, 48);
            this.txtMsn.Name = "txtMsn";
            this.txtMsn.Size = new System.Drawing.Size(239, 21);
            this.txtMsn.TabIndex = 78;
            this.txtMsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsn_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "主料卷";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trv_node);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 289);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // trv_node
            // 
            this.trv_node.BackColor = System.Drawing.Color.White;
            this.trv_node.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trv_node.Location = new System.Drawing.Point(3, 17);
            this.trv_node.Name = "trv_node";
            this.trv_node.Size = new System.Drawing.Size(753, 269);
            this.trv_node.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 515);
            this.panel1.TabIndex = 0;
            // 
            // ucCombineSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucCombineSN";
            this.Size = new System.Drawing.Size(759, 515);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private CIT.Client.TXButton btn_combine;
        private System.Windows.Forms.TextBox txtFsn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView trv_node;
        private System.Windows.Forms.Panel panel1;
    }
}
