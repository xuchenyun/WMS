namespace BaseData.UI
{
    partial class FormCustomerEdit
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_no = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_customerCode = new System.Windows.Forms.TextBox();
            this.txt_customerName = new System.Windows.Forms.TextBox();
            this.txt_contract = new System.Windows.Forms.TextBox();
            this.txt_contractNum = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "联系人";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "联系电话";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "邮箱";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "送货地址";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(50, 226);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_no
            // 
            this.btn_no.Location = new System.Drawing.Point(165, 226);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(75, 23);
            this.btn_no.TabIndex = 11;
            this.btn_no.Text = "取消";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "客户名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "客户代码";
            // 
            // txt_customerCode
            // 
            this.txt_customerCode.Location = new System.Drawing.Point(87, 12);
            this.txt_customerCode.Name = "txt_customerCode";
            this.txt_customerCode.Size = new System.Drawing.Size(176, 21);
            this.txt_customerCode.TabIndex = 15;
            // 
            // txt_customerName
            // 
            this.txt_customerName.Location = new System.Drawing.Point(87, 46);
            this.txt_customerName.Name = "txt_customerName";
            this.txt_customerName.Size = new System.Drawing.Size(176, 21);
            this.txt_customerName.TabIndex = 16;
            // 
            // txt_contract
            // 
            this.txt_contract.Location = new System.Drawing.Point(87, 80);
            this.txt_contract.Name = "txt_contract";
            this.txt_contract.Size = new System.Drawing.Size(176, 21);
            this.txt_contract.TabIndex = 17;
            // 
            // txt_contractNum
            // 
            this.txt_contractNum.Location = new System.Drawing.Point(87, 114);
            this.txt_contractNum.Name = "txt_contractNum";
            this.txt_contractNum.Size = new System.Drawing.Size(176, 21);
            this.txt_contractNum.TabIndex = 18;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(87, 148);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(176, 21);
            this.txt_email.TabIndex = 19;
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(87, 182);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(176, 21);
            this.txt_address.TabIndex = 20;
            // 
            // FormCustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 283);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_contractNum);
            this.Controls.Add(this.txt_contract);
            this.Controls.Add(this.txt_customerName);
            this.Controls.Add(this.txt_customerCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "FormCustomerEdit";
            this.Text = "客户管理";
            this.Load += new System.EventHandler(this.FormCustomerEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_customerCode;
        private System.Windows.Forms.TextBox txt_customerName;
        private System.Windows.Forms.TextBox txt_contract;
        private System.Windows.Forms.TextBox txt_contractNum;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_address;
    }
}