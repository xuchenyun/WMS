namespace Warehouse.UI
{
    partial class ucReelPrint
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
            this.txt_SUPPLIER_CODE = new CIT.Client.TXTextBox();
            this.lblCusCode = new System.Windows.Forms.Label();
            this.txt_MaterialDesc = new CIT.Client.TXTextBox();
            this.lblItemDes = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblProductionDate = new System.Windows.Forms.Label();
            this.dtpProductionDate = new System.Windows.Forms.DateTimePicker();
            this.txt_Qty = new CIT.Client.TXTextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtSN = new CIT.Client.TXTextBox();
            this.lblSN = new System.Windows.Forms.Label();
            this.btnPrint = new CIT.Client.TXButton();
            this.btnCancel = new CIT.Client.TXButton();
            this.cbo_PO = new CIT.Client.TXComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_MaterialCode = new CIT.Client.TXComboBox();
            this.txt_MinPackage = new CIT.Client.TXTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_SUPPLIER_CODE
            // 
            this.txt_SUPPLIER_CODE.BackColor = System.Drawing.Color.Transparent;
            this.txt_SUPPLIER_CODE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_SUPPLIER_CODE.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_SUPPLIER_CODE.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_SUPPLIER_CODE.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_SUPPLIER_CODE.Image = null;
            this.txt_SUPPLIER_CODE.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_SUPPLIER_CODE.Location = new System.Drawing.Point(195, 63);
            this.txt_SUPPLIER_CODE.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SUPPLIER_CODE.Name = "txt_SUPPLIER_CODE";
            this.txt_SUPPLIER_CODE.Padding = new System.Windows.Forms.Padding(3);
            this.txt_SUPPLIER_CODE.PasswordChar = '\0';
            this.txt_SUPPLIER_CODE.ReadOnly = true;
            this.txt_SUPPLIER_CODE.Required = false;
            this.txt_SUPPLIER_CODE.Size = new System.Drawing.Size(406, 33);
            this.txt_SUPPLIER_CODE.TabIndex = 71;
            // 
            // lblCusCode
            // 
            this.lblCusCode.Location = new System.Drawing.Point(68, 58);
            this.lblCusCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCusCode.Name = "lblCusCode";
            this.lblCusCode.Size = new System.Drawing.Size(108, 44);
            this.lblCusCode.TabIndex = 70;
            this.lblCusCode.Text = "供应商代码";
            this.lblCusCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_MaterialDesc
            // 
            this.txt_MaterialDesc.BackColor = System.Drawing.Color.Transparent;
            this.txt_MaterialDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_MaterialDesc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_MaterialDesc.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_MaterialDesc.Image = null;
            this.txt_MaterialDesc.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_MaterialDesc.Location = new System.Drawing.Point(195, 161);
            this.txt_MaterialDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaterialDesc.Name = "txt_MaterialDesc";
            this.txt_MaterialDesc.Padding = new System.Windows.Forms.Padding(3);
            this.txt_MaterialDesc.PasswordChar = '\0';
            this.txt_MaterialDesc.ReadOnly = true;
            this.txt_MaterialDesc.Required = false;
            this.txt_MaterialDesc.Size = new System.Drawing.Size(406, 33);
            this.txt_MaterialDesc.TabIndex = 73;
            // 
            // lblItemDes
            // 
            this.lblItemDes.Location = new System.Drawing.Point(68, 156);
            this.lblItemDes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemDes.Name = "lblItemDes";
            this.lblItemDes.Size = new System.Drawing.Size(108, 44);
            this.lblItemDes.TabIndex = 72;
            this.lblItemDes.Text = "物料描述";
            this.lblItemDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItems
            // 
            this.lblItems.Location = new System.Drawing.Point(68, 105);
            this.lblItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(108, 44);
            this.lblItems.TabIndex = 74;
            this.lblItems.Text = "料号*行号";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProductionDate
            // 
            this.lblProductionDate.Location = new System.Drawing.Point(70, 261);
            this.lblProductionDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductionDate.Name = "lblProductionDate";
            this.lblProductionDate.Size = new System.Drawing.Size(108, 44);
            this.lblProductionDate.TabIndex = 76;
            this.lblProductionDate.Text = "生产日期";
            this.lblProductionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpProductionDate
            // 
            this.dtpProductionDate.CustomFormat = "yyyy/MM/dd";
            this.dtpProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProductionDate.Location = new System.Drawing.Point(199, 264);
            this.dtpProductionDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpProductionDate.Name = "dtpProductionDate";
            this.dtpProductionDate.Size = new System.Drawing.Size(402, 28);
            this.dtpProductionDate.TabIndex = 77;
            this.dtpProductionDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpProductionDate_KeyPress);
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
            this.txt_Qty.Location = new System.Drawing.Point(197, 315);
            this.txt_Qty.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Padding = new System.Windows.Forms.Padding(3);
            this.txt_Qty.PasswordChar = '\0';
            this.txt_Qty.Required = false;
            this.txt_Qty.Size = new System.Drawing.Size(406, 33);
            this.txt_Qty.TabIndex = 81;
            this.txt_Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(69, 310);
            this.lblQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(108, 44);
            this.lblQty.TabIndex = 80;
            this.lblQty.Text = "来料数量";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSN
            // 
            this.txtSN.BackColor = System.Drawing.Color.Transparent;
            this.txtSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtSN.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtSN.Image = null;
            this.txtSN.ImageSize = new System.Drawing.Size(0, 0);
            this.txtSN.Location = new System.Drawing.Point(197, 377);
            this.txtSN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSN.Name = "txtSN";
            this.txtSN.Padding = new System.Windows.Forms.Padding(3);
            this.txtSN.PasswordChar = '\0';
            this.txtSN.ReadOnly = true;
            this.txtSN.Required = false;
            this.txtSN.Size = new System.Drawing.Size(406, 33);
            this.txtSN.TabIndex = 83;
            // 
            // lblSN
            // 
            this.lblSN.Location = new System.Drawing.Point(73, 373);
            this.lblSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(108, 44);
            this.lblSN.TabIndex = 82;
            this.lblSN.Text = "S/N";
            this.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = null;
            this.btnPrint.Location = new System.Drawing.Point(232, 443);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(153, 50);
            this.btnPrint.TabIndex = 84;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(448, 443);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 50);
            this.btnCancel.TabIndex = 85;
            this.btnCancel.Text = "清除";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbo_PO
            // 
            this.cbo_PO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_PO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_PO.FormattingEnabled = true;
            this.cbo_PO.Location = new System.Drawing.Point(195, 17);
            this.cbo_PO.Name = "cbo_PO";
            this.cbo_PO.Size = new System.Drawing.Size(406, 29);
            this.cbo_PO.TabIndex = 178;
            this.cbo_PO.SelectedIndexChanged += new System.EventHandler(this.cbo_PO_SelectedIndexChanged);
            this.cbo_PO.TextChanged += new System.EventHandler(this.cbo_PO_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(98, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 177;
            this.label5.Text = "采购单";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbo_MaterialCode
            // 
            this.cbo_MaterialCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_MaterialCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_MaterialCode.FormattingEnabled = true;
            this.cbo_MaterialCode.Location = new System.Drawing.Point(195, 112);
            this.cbo_MaterialCode.Name = "cbo_MaterialCode";
            this.cbo_MaterialCode.Size = new System.Drawing.Size(406, 29);
            this.cbo_MaterialCode.TabIndex = 179;
            this.cbo_MaterialCode.SelectedIndexChanged += new System.EventHandler(this.cbo_MaterialCode_SelectedIndexChanged);
            this.cbo_MaterialCode.TextChanged += new System.EventHandler(this.cbo_MaterialCode_TextChanged);
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
            this.txt_MinPackage.Location = new System.Drawing.Point(197, 209);
            this.txt_MinPackage.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MinPackage.Name = "txt_MinPackage";
            this.txt_MinPackage.Padding = new System.Windows.Forms.Padding(3);
            this.txt_MinPackage.PasswordChar = '\0';
            this.txt_MinPackage.ReadOnly = true;
            this.txt_MinPackage.Required = false;
            this.txt_MinPackage.Size = new System.Drawing.Size(406, 33);
            this.txt_MinPackage.TabIndex = 181;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(69, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 44);
            this.label1.TabIndex = 180;
            this.label1.Text = "最小包装";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucReelPrint_Old
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_MinPackage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_MaterialCode);
            this.Controls.Add(this.cbo_PO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtSN);
            this.Controls.Add(this.lblSN);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.dtpProductionDate);
            this.Controls.Add(this.lblProductionDate);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.txt_MaterialDesc);
            this.Controls.Add(this.lblItemDes);
            this.Controls.Add(this.txt_SUPPLIER_CODE);
            this.Controls.Add(this.lblCusCode);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucReelPrint_Old";
            this.Size = new System.Drawing.Size(806, 609);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CIT.Client.TXTextBox txt_SUPPLIER_CODE;
        private System.Windows.Forms.Label lblCusCode;
        private CIT.Client.TXTextBox txt_MaterialDesc;
        private System.Windows.Forms.Label lblItemDes;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblProductionDate;
        private System.Windows.Forms.DateTimePicker dtpProductionDate;
        private CIT.Client.TXTextBox txt_Qty;
        private System.Windows.Forms.Label lblQty;
        private CIT.Client.TXTextBox txtSN;
        private System.Windows.Forms.Label lblSN;
        private CIT.Client.TXButton btnPrint;
        private CIT.Client.TXButton btnCancel;
        private CIT.Client.TXComboBox cbo_PO;
        private System.Windows.Forms.Label label5;
        private CIT.Client.TXComboBox cbo_MaterialCode;
        private CIT.Client.TXTextBox txt_MinPackage;
        private System.Windows.Forms.Label label1;
    }
}
