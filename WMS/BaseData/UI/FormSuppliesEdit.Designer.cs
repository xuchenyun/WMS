namespace BaseData.UI
{
    partial class FormSuppliesEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_suppliesName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_suppliesCode = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "供应商名称";
            // 
            // txt_suppliesName
            // 
            this.txt_suppliesName.Location = new System.Drawing.Point(83, 29);
            this.txt_suppliesName.Name = "txt_suppliesName";
            this.txt_suppliesName.Size = new System.Drawing.Size(178, 21);
            this.txt_suppliesName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "供应商代码";
            // 
            // txt_suppliesCode
            // 
            this.txt_suppliesCode.Location = new System.Drawing.Point(83, 86);
            this.txt_suppliesCode.Name = "txt_suppliesCode";
            this.txt_suppliesCode.Size = new System.Drawing.Size(178, 21);
            this.txt_suppliesCode.TabIndex = 3;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(54, 166);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_no
            // 
            this.btn_no.Location = new System.Drawing.Point(155, 166);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(75, 23);
            this.btn_no.TabIndex = 5;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // FormSuppliesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 246);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_suppliesCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_suppliesName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FormSuppliesEdit";
            this.Text = "供应商管理";
            this.Load += new System.EventHandler(this.FormSuppliesEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_suppliesName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_suppliesCode;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_no;
    }
}