namespace Query.UI
{
    partial class Form_ShowDocDetail
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
            this.btn_export = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tab_data = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 30);
            this.panel1.TabIndex = 0;
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(12, 3);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 0;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tab_data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 372);
            this.panel2.TabIndex = 1;
            // 
            // tab_data
            // 
            this.tab_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_data.Location = new System.Drawing.Point(0, 0);
            this.tab_data.Name = "tab_data";
            this.tab_data.SelectedIndex = 0;
            this.tab_data.Size = new System.Drawing.Size(855, 372);
            this.tab_data.TabIndex = 0;
            // 
            // Form_ShowDocDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 402);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_ShowDocDetail";
            this.Text = "单据明细";
            this.Load += new System.EventHandler(this.Form_ShowDocDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tab_data;
    }
}