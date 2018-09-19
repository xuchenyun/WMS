namespace Query.UI
{
    partial class ucDeviceRequestManage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txToolStrip1 = new CIT.Client.TXToolStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btn_query = new CIT.Client.TXButton();
            this.txt_StationSN = new CIT.Client.TXTextBox();
            this.lbl_typeName = new System.Windows.Forms.Label();
            this.txtSerialNumber = new CIT.Client.TXTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TimeMax = new System.Windows.Forms.TextBox();
            this.dtp_TimeMax = new System.Windows.Forms.DateTimePicker();
            this.txt_TimeMin = new System.Windows.Forms.TextBox();
            this.dtp_TimeMin = new System.Windows.Forms.DateTimePicker();
            this.cmb_isRequest = new CIT.Client.TXComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WORKSTATION_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WORKSTATION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JsonText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txToolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 37);
            this.panel1.TabIndex = 0;
            // 
            // txToolStrip1
            // 
            this.txToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.BeginBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.EndBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.txToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.txToolStrip1.Name = "txToolStrip1";
            this.txToolStrip1.Size = new System.Drawing.Size(1044, 25);
            this.txToolStrip1.TabIndex = 160;
            this.txToolStrip1.Text = "txToolStrip1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_isRequest);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_TimeMax);
            this.panel2.Controls.Add(this.dtp_TimeMax);
            this.panel2.Controls.Add(this.txt_TimeMin);
            this.panel2.Controls.Add(this.dtp_TimeMin);
            this.panel2.Controls.Add(this.txtSerialNumber);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_StationSN);
            this.panel2.Controls.Add(this.lbl_typeName);
            this.panel2.Controls.Add(this.btn_query);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 80);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvData);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 117);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1044, 384);
            this.panel3.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.DeviceCode,
            this.WORKSTATION_SN,
            this.WORKSTATION_NAME,
            this.JsonText,
            this.IsRequest,
            this.CreateTime,
            this.RequestTime,
            this.ID});
            this.dgvData.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1044, 384);
            this.dgvData.TabIndex = 0;
            // 
            // btn_query
            // 
            this.btn_query.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_query.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_query.Image = null;
            this.btn_query.Location = new System.Drawing.Point(818, 41);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(81, 27);
            this.btn_query.TabIndex = 167;
            this.btn_query.Text = "查询";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // txt_StationSN
            // 
            this.txt_StationSN.BackColor = System.Drawing.Color.Transparent;
            this.txt_StationSN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txt_StationSN.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_StationSN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_StationSN.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_StationSN.Image = null;
            this.txt_StationSN.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_StationSN.Location = new System.Drawing.Point(90, 6);
            this.txt_StationSN.Name = "txt_StationSN";
            this.txt_StationSN.Padding = new System.Windows.Forms.Padding(2);
            this.txt_StationSN.PasswordChar = '\0';
            this.txt_StationSN.Required = false;
            this.txt_StationSN.Size = new System.Drawing.Size(201, 27);
            this.txt_StationSN.TabIndex = 169;
            // 
            // lbl_typeName
            // 
            this.lbl_typeName.AutoSize = true;
            this.lbl_typeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_typeName.Location = new System.Drawing.Point(12, 11);
            this.lbl_typeName.Name = "lbl_typeName";
            this.lbl_typeName.Size = new System.Drawing.Size(56, 16);
            this.lbl_typeName.TabIndex = 168;
            this.lbl_typeName.Text = "工位SN";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtSerialNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(168)))), ((int)(((byte)(192)))));
            this.txtSerialNumber.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSerialNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerialNumber.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtSerialNumber.Image = null;
            this.txtSerialNumber.ImageSize = new System.Drawing.Size(0, 0);
            this.txtSerialNumber.Location = new System.Drawing.Point(394, 6);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Padding = new System.Windows.Forms.Padding(2);
            this.txtSerialNumber.PasswordChar = '\0';
            this.txtSerialNumber.Required = false;
            this.txtSerialNumber.Size = new System.Drawing.Size(201, 27);
            this.txtSerialNumber.TabIndex = 171;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(316, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 170;
            this.label1.Text = "条码SN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 177;
            this.label5.Text = "--";
            // 
            // txt_TimeMax
            // 
            this.txt_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_TimeMax.Location = new System.Drawing.Point(394, 41);
            this.txt_TimeMax.Name = "txt_TimeMax";
            this.txt_TimeMax.Size = new System.Drawing.Size(173, 26);
            this.txt_TimeMax.TabIndex = 176;
            // 
            // dtp_TimeMax
            // 
            this.dtp_TimeMax.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMax.Location = new System.Drawing.Point(394, 41);
            this.dtp_TimeMax.Name = "dtp_TimeMax";
            this.dtp_TimeMax.Size = new System.Drawing.Size(201, 26);
            this.dtp_TimeMax.TabIndex = 175;
            this.dtp_TimeMax.CloseUp += new System.EventHandler(this.dtp_TimeMax_CloseUp);
            // 
            // txt_TimeMin
            // 
            this.txt_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_TimeMin.Location = new System.Drawing.Point(91, 41);
            this.txt_TimeMin.Name = "txt_TimeMin";
            this.txt_TimeMin.Size = new System.Drawing.Size(172, 26);
            this.txt_TimeMin.TabIndex = 174;
            // 
            // dtp_TimeMin
            // 
            this.dtp_TimeMin.CustomFormat = "yyyy-MM-dd ";
            this.dtp_TimeMin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TimeMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_TimeMin.Location = new System.Drawing.Point(91, 41);
            this.dtp_TimeMin.Name = "dtp_TimeMin";
            this.dtp_TimeMin.Size = new System.Drawing.Size(200, 26);
            this.dtp_TimeMin.TabIndex = 173;
            this.dtp_TimeMin.CloseUp += new System.EventHandler(this.dtp_TimeMin_CloseUp);
            // 
            // cmb_isRequest
            // 
            this.cmb_isRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_isRequest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_isRequest.FormattingEnabled = true;
            this.cmb_isRequest.Location = new System.Drawing.Point(696, 7);
            this.cmb_isRequest.Name = "cmb_isRequest";
            this.cmb_isRequest.Size = new System.Drawing.Size(203, 24);
            this.cmb_isRequest.TabIndex = 179;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(620, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 178;
            this.label2.Text = "人工请求";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(29, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 180;
            this.label3.Text = "时间";
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "条码";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // DeviceCode
            // 
            this.DeviceCode.DataPropertyName = "DeviceCode";
            this.DeviceCode.HeaderText = "设备编号";
            this.DeviceCode.Name = "DeviceCode";
            this.DeviceCode.ReadOnly = true;
            // 
            // WORKSTATION_SN
            // 
            this.WORKSTATION_SN.DataPropertyName = "WORKSTATION_SN";
            this.WORKSTATION_SN.HeaderText = "工位SN";
            this.WORKSTATION_SN.Name = "WORKSTATION_SN";
            this.WORKSTATION_SN.ReadOnly = true;
            // 
            // WORKSTATION_NAME
            // 
            this.WORKSTATION_NAME.DataPropertyName = "WORKSTATION_NAME";
            this.WORKSTATION_NAME.HeaderText = "工位名称";
            this.WORKSTATION_NAME.Name = "WORKSTATION_NAME";
            this.WORKSTATION_NAME.ReadOnly = true;
            // 
            // JsonText
            // 
            this.JsonText.DataPropertyName = "JsonText";
            this.JsonText.HeaderText = "JsonText";
            this.JsonText.Name = "JsonText";
            this.JsonText.ReadOnly = true;
            this.JsonText.Width = 300;
            // 
            // IsRequest
            // 
            this.IsRequest.DataPropertyName = "IsRequest";
            this.IsRequest.HeaderText = "人工请求";
            this.IsRequest.Name = "IsRequest";
            this.IsRequest.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // RequestTime
            // 
            this.RequestTime.DataPropertyName = "RequestTime";
            this.RequestTime.HeaderText = "请求时间";
            this.RequestTime.Name = "RequestTime";
            this.RequestTime.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ucDeviceRequestManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucDeviceRequestManage";
            this.Size = new System.Drawing.Size(1044, 501);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CIT.Client.TXToolStrip txToolStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvData;
        private CIT.Client.TXButton btn_query;
        private CIT.Client.TXTextBox txt_StationSN;
        private System.Windows.Forms.Label lbl_typeName;
        private CIT.Client.TXTextBox txtSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TimeMax;
        private System.Windows.Forms.DateTimePicker dtp_TimeMax;
        private System.Windows.Forms.TextBox txt_TimeMin;
        private System.Windows.Forms.DateTimePicker dtp_TimeMin;
        private CIT.Client.TXComboBox cmb_isRequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WORKSTATION_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn WORKSTATION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn JsonText;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}
