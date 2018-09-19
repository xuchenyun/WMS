namespace CIT.MES.Control
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lkBlog = new System.Windows.Forms.LinkLabel();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lkBlog
            // 
            this.lkBlog.AutoSize = true;
            this.lkBlog.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkBlog.Location = new System.Drawing.Point(26, 21);
            this.lkBlog.Name = "lkBlog";
            this.lkBlog.Size = new System.Drawing.Size(222, 16);
            this.lkBlog.TabIndex = 0;
            this.lkBlog.TabStop = true;
            this.lkBlog.Text = "疯狂的耗子(CraxyMouse)的Blog";
            this.lkBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkBlog_LinkClicked);
            // 
            // tbDesc
            // 
            this.tbDesc.BackColor = System.Drawing.Color.White;
            this.tbDesc.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDesc.ForeColor = System.Drawing.Color.Blue;
            this.tbDesc.Location = new System.Drawing.Point(29, 50);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ReadOnly = true;
            this.tbDesc.Size = new System.Drawing.Size(505, 392);
            this.tbDesc.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Image = global::CIT.MES.Properties.Resources.stop;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(423, 450);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "  关闭(&C)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 509);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.lkBlog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lkBlog;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Button button1;
    }
}