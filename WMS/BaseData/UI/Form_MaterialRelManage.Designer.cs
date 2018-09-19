namespace BaseData.UI
{
    partial class Form_MaterialRelManage
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
            this.txtLocalMaterial = new System.Windows.Forms.TextBox();
            this.txtSupplyMaterial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSupply = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本厂料号";
            // 
            // txtLocalMaterial
            // 
            this.txtLocalMaterial.Location = new System.Drawing.Point(109, 39);
            this.txtLocalMaterial.Name = "txtLocalMaterial";
            this.txtLocalMaterial.Size = new System.Drawing.Size(242, 21);
            this.txtLocalMaterial.TabIndex = 1;
            // 
            // txtSupplyMaterial
            // 
            this.txtSupplyMaterial.Location = new System.Drawing.Point(109, 87);
            this.txtSupplyMaterial.Name = "txtSupplyMaterial";
            this.txtSupplyMaterial.Size = new System.Drawing.Size(242, 21);
            this.txtSupplyMaterial.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "供应商料号";
            // 
            // txtSupply
            // 
            this.txtSupply.Location = new System.Drawing.Point(109, 132);
            this.txtSupply.Name = "txtSupply";
            this.txtSupply.Size = new System.Drawing.Size(242, 21);
            this.txtSupply.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "供应商代码";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(109, 182);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(242, 21);
            this.txtRemark.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "备注";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(109, 244);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(250, 244);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "关闭";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // Form_MaterialRelManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 300);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSupply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSupplyMaterial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocalMaterial);
            this.Controls.Add(this.label1);
            this.Name = "Form_MaterialRelManage";
            this.Text = "料号关系维护";
            this.Load += new System.EventHandler(this.Form_MaterialRelManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalMaterial;
        private System.Windows.Forms.TextBox txtSupplyMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSupply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNo;
    }
}