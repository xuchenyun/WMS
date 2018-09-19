namespace CIT.MES.BaseControl
{
    partial class FrmSetColumns
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
            this.btn_ok = new CIT.Client.TXButton();
            this.chklist_columnsName = new System.Windows.Forms.CheckedListBox();
            this.chx_selectAll = new CIT.Client.TXCheckBox();
            this.lab_tablename = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Image = null;
            this.btn_ok.Location = new System.Drawing.Point(320, 373);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(98, 31);
            this.btn_ok.TabIndex = 10;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // chklist_columnsName
            // 
            this.chklist_columnsName.FormattingEnabled = true;
            this.chklist_columnsName.Location = new System.Drawing.Point(33, 53);
            this.chklist_columnsName.Name = "chklist_columnsName";
            this.chklist_columnsName.Size = new System.Drawing.Size(385, 292);
            this.chklist_columnsName.TabIndex = 9;
            // 
            // chx_selectAll
            // 
            this.chx_selectAll.AutoSize = true;
            this.chx_selectAll.BackColor = System.Drawing.Color.Transparent;
            this.chx_selectAll.Location = new System.Drawing.Point(34, 361);
            this.chx_selectAll.MinimumSize = new System.Drawing.Size(20, 20);
            this.chx_selectAll.Name = "chx_selectAll";
            this.chx_selectAll.Size = new System.Drawing.Size(48, 20);
            this.chx_selectAll.TabIndex = 8;
            this.chx_selectAll.Text = "全选";
            this.chx_selectAll.UseVisualStyleBackColor = false;
            this.chx_selectAll.CheckedChanged += new System.EventHandler(this.chx_selectAll_CheckedChanged);
            // 
            // lab_tablename
            // 
            this.lab_tablename.AutoSize = true;
            this.lab_tablename.BackColor = System.Drawing.Color.Transparent;
            this.lab_tablename.Location = new System.Drawing.Point(96, 26);
            this.lab_tablename.Name = "lab_tablename";
            this.lab_tablename.Size = new System.Drawing.Size(11, 12);
            this.lab_tablename.TabIndex = 7;
            this.lab_tablename.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "表单名称:";
            // 
            // FrmSetColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 421);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.chklist_columnsName);
            this.Controls.Add(this.chx_selectAll);
            this.Controls.Add(this.lab_tablename);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetColumns";
            this.Text = "自定义显示";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Client.TXButton btn_ok;
        private System.Windows.Forms.CheckedListBox chklist_columnsName;
        private Client.TXCheckBox chx_selectAll;
        private System.Windows.Forms.Label lab_tablename;
        private System.Windows.Forms.Label label1;
    }
}