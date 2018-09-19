namespace Query.UI
{
    partial class Form_ReelPrint
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
            this.lblItems = new System.Windows.Forms.Label();
            this.lblProductionDate = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.btnPrint = new CIT.Client.TXButton();
            this.btnClear = new CIT.Client.TXButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PO = new CIT.Client.TXTextBox();
            this.txt_MaterialCode = new CIT.Client.TXTextBox();
            this.txt_MPN = new CIT.Client.TXTextBox();
            this.txt_DateCode = new CIT.Client.TXTextBox();
            this.txt_MinPackage = new CIT.Client.TXTextBox();
            this.txtLotNo = new CIT.Client.TXTextBox();
            this.txt_Qty = new CIT.Client.TXTextBox();
            this.txtVersion = new CIT.Client.TXTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblItems
            // 
            this.lblItems.BackColor = System.Drawing.Color.Transparent;
            this.lblItems.Location = new System.Drawing.Point(81, 106);
            this.lblItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(74, 21);
            this.lblItems.TabIndex = 74;
            this.lblItems.Text = "料号";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProductionDate
            // 
            this.lblProductionDate.BackColor = System.Drawing.Color.Transparent;
            this.lblProductionDate.Location = new System.Drawing.Point(68, 258);
            this.lblProductionDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductionDate.Name = "lblProductionDate";
            this.lblProductionDate.Size = new System.Drawing.Size(87, 27);
            this.lblProductionDate.TabIndex = 76;
            this.lblProductionDate.Text = "DateCode";
            this.lblProductionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.Transparent;
            this.lblQty.Location = new System.Drawing.Point(68, 418);
            this.lblQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(87, 27);
            this.lblQty.TabIndex = 80;
            this.lblQty.Text = "来料数量";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = null;
            this.btnPrint.Location = new System.Drawing.Point(188, 490);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(153, 50);
            this.btnPrint.TabIndex = 89;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = null;
            this.btnClear.Location = new System.Drawing.Point(369, 490);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(153, 50);
            this.btnClear.TabIndex = 90;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(64, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 180;
            this.label1.Text = "最小包装";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(81, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 182;
            this.label2.Text = "MPN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(81, 314);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 187;
            this.label3.Text = "LotNo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(81, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 189;
            this.label4.Text = "采购单";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_PO
            // 
            this.txt_PO.BackColor = System.Drawing.Color.Transparent;
            this.txt_PO.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_PO.Enabled = false;
            this.txt_PO.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_PO.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_PO.Image = null;
            this.txt_PO.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_PO.Location = new System.Drawing.Point(174, 51);
            this.txt_PO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_PO.Name = "txt_PO";
            this.txt_PO.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_PO.PasswordChar = '\0';
            this.txt_PO.ReadOnly = true;
            this.txt_PO.Required = false;
            this.txt_PO.Size = new System.Drawing.Size(406, 33);
            this.txt_PO.TabIndex = 81;
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_MaterialCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_MaterialCode.Enabled = false;
            this.txt_MaterialCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_MaterialCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_MaterialCode.Image = null;
            this.txt_MaterialCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_MaterialCode.Location = new System.Drawing.Point(174, 100);
            this.txt_MaterialCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_MaterialCode.PasswordChar = '\0';
            this.txt_MaterialCode.ReadOnly = true;
            this.txt_MaterialCode.Required = false;
            this.txt_MaterialCode.Size = new System.Drawing.Size(406, 33);
            this.txt_MaterialCode.TabIndex = 82;
            // 
            // txt_MPN
            // 
            this.txt_MPN.BackColor = System.Drawing.Color.Transparent;
            this.txt_MPN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_MPN.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MPN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_MPN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_MPN.Image = null;
            this.txt_MPN.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_MPN.Location = new System.Drawing.Point(174, 150);
            this.txt_MPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_MPN.Name = "txt_MPN";
            this.txt_MPN.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_MPN.PasswordChar = '\0';
            this.txt_MPN.Required = false;
            this.txt_MPN.Size = new System.Drawing.Size(406, 33);
            this.txt_MPN.TabIndex = 83;
            this.txt_MPN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_MPN_KeyDown);
            // 
            // txt_DateCode
            // 
            this.txt_DateCode.BackColor = System.Drawing.Color.Transparent;
            this.txt_DateCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_DateCode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_DateCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_DateCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_DateCode.Image = null;
            this.txt_DateCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_DateCode.Location = new System.Drawing.Point(174, 255);
            this.txt_DateCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_DateCode.Name = "txt_DateCode";
            this.txt_DateCode.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_DateCode.PasswordChar = '\0';
            this.txt_DateCode.Required = false;
            this.txt_DateCode.Size = new System.Drawing.Size(406, 33);
            this.txt_DateCode.TabIndex = 85;
            this.txt_DateCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DateCode_KeyPress);
            // 
            // txt_MinPackage
            // 
            this.txt_MinPackage.BackColor = System.Drawing.Color.Transparent;
            this.txt_MinPackage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_MinPackage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MinPackage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_MinPackage.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_MinPackage.Image = null;
            this.txt_MinPackage.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_MinPackage.Location = new System.Drawing.Point(174, 201);
            this.txt_MinPackage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_MinPackage.Name = "txt_MinPackage";
            this.txt_MinPackage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_MinPackage.PasswordChar = '\0';
            this.txt_MinPackage.Required = false;
            this.txt_MinPackage.Size = new System.Drawing.Size(406, 33);
            this.txt_MinPackage.TabIndex = 84;
            this.txt_MinPackage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_MinPackage_KeyDown);
            // 
            // txtLotNo
            // 
            this.txtLotNo.BackColor = System.Drawing.Color.Transparent;
            this.txtLotNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtLotNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLotNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLotNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLotNo.Image = null;
            this.txtLotNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLotNo.Location = new System.Drawing.Point(174, 308);
            this.txtLotNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txtLotNo.PasswordChar = '\0';
            this.txtLotNo.Required = false;
            this.txtLotNo.Size = new System.Drawing.Size(406, 33);
            this.txtLotNo.TabIndex = 86;
            this.txtLotNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLotNo_KeyDown);
            // 
            // txt_Qty
            // 
            this.txt_Qty.BackColor = System.Drawing.Color.Transparent;
            this.txt_Qty.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_Qty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Qty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_Qty.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_Qty.Image = null;
            this.txt_Qty.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_Qty.Location = new System.Drawing.Point(174, 416);
            this.txt_Qty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txt_Qty.PasswordChar = '\0';
            this.txt_Qty.Required = false;
            this.txt_Qty.Size = new System.Drawing.Size(406, 33);
            this.txt_Qty.TabIndex = 88;
            this.txt_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.Color.Transparent;
            this.txtVersion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtVersion.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVersion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVersion.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtVersion.Image = null;
            this.txtVersion.ImageSize = new System.Drawing.Size(0, 0);
            this.txtVersion.Location = new System.Drawing.Point(174, 360);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.txtVersion.PasswordChar = '\0';
            this.txtVersion.Required = false;
            this.txtVersion.Size = new System.Drawing.Size(406, 33);
            this.txtVersion.TabIndex = 87;
            this.txtVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVersion_KeyDown);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(68, 363);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 27);
            this.label5.TabIndex = 190;
            this.label5.Text = "版本";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_ReelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 568);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DateCode);
            this.Controls.Add(this.txt_PO);
            this.Controls.Add(this.txt_MaterialCode);
            this.Controls.Add(this.txt_MPN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MinPackage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblProductionDate);
            this.Controls.Add(this.lblItems);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_ReelPrint";
            this.Load += new System.EventHandler(this.Form_ReelPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblProductionDate;
        private System.Windows.Forms.Label lblQty;
        private CIT.Client.TXButton btnPrint;
        private CIT.Client.TXButton btnClear;
        private CIT.Client.TXTextBox txt_MinPackage;
        private System.Windows.Forms.Label label1;
        private CIT.Client.TXTextBox txt_MPN;
        private System.Windows.Forms.Label label2;
        private CIT.Client.TXTextBox txt_MaterialCode;
        private CIT.Client.TXTextBox txt_PO;
        private CIT.Client.TXTextBox txt_DateCode;
        private CIT.Client.TXTextBox txtLotNo;
        private CIT.Client.TXTextBox txtVersion;
        private CIT.Client.TXTextBox txt_Qty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
