namespace CIT.uControl
{
    partial class PagerControl
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnGo = new DevComponents.DotNetBar.ButtonX();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.txtBxNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtperpage = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelCount = new DevComponents.DotNetBar.LabelX();
            this.lblPageNum = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelEx1.Controls.Add(this.btnGo);
            this.panelEx1.Controls.Add(this.lnkLast);
            this.panelEx1.Controls.Add(this.lnkNext);
            this.panelEx1.Controls.Add(this.lnkPrev);
            this.panelEx1.Controls.Add(this.lnkFirst);
            this.panelEx1.Controls.Add(this.txtBxNumber);
            this.panelEx1.Controls.Add(this.txtperpage);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelCount);
            this.panelEx1.Controls.Add(this.lblPageNum);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(583, 38);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.LightCyan;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGo.Location = new System.Drawing.Point(286, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(30, 20);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Location = new System.Drawing.Point(147, 15);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(29, 12);
            this.lnkLast.TabIndex = 5;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = "末页";
            this.lnkLast.Click += new System.EventHandler(this.InkLast_Click);
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Location = new System.Drawing.Point(100, 15);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(41, 12);
            this.lnkNext.TabIndex = 5;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "下一页";
            this.lnkNext.Click += new System.EventHandler(this.InkNext_Click);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Location = new System.Drawing.Point(51, 15);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(41, 12);
            this.lnkPrev.TabIndex = 5;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "上一页";
            this.lnkPrev.Click += new System.EventHandler(this.InkPrew_Click);
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Location = new System.Drawing.Point(17, 15);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(29, 12);
            this.lnkFirst.TabIndex = 4;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.Click += new System.EventHandler(this.InkFirst_Click);
            // 
            // txtBxNumber
            // 
            // 
            // 
            // 
            this.txtBxNumber.Border.Class = "TextBoxBorder";
            this.txtBxNumber.Location = new System.Drawing.Point(215, 10);
            this.txtBxNumber.Name = "txtBxNumber";
            this.txtBxNumber.Size = new System.Drawing.Size(40, 21);
            this.txtBxNumber.TabIndex = 3;
            this.txtBxNumber.TextChanged += new System.EventHandler(this.txtBxNumber_TextChanged);
            // 
            // txtperpage
            // 
            // 
            // 
            // 
            this.txtperpage.Border.Class = "TextBoxBorder";
            this.txtperpage.Location = new System.Drawing.Point(501, 10);
            this.txtperpage.Name = "txtperpage";
            this.txtperpage.Size = new System.Drawing.Size(40, 21);
            this.txtperpage.TabIndex = 2;
            this.txtperpage.Text = "50";
            this.txtperpage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtperpage_KeyPress);
            this.txtperpage.Leave += new System.EventHandler(this.txtperpage_Leave);
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(259, 12);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(20, 23);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "页";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(547, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(20, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "条";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(182, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(30, 20);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "转到";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(467, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(30, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "每页";
            // 
            // labelCount
            // 
            this.labelCount.Location = new System.Drawing.Point(378, 11);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(88, 20);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "共0条";
            // 
            // lblPageNum
            // 
            this.lblPageNum.Location = new System.Drawing.Point(329, 11);
            this.lblPageNum.Name = "lblPageNum";
            this.lblPageNum.Size = new System.Drawing.Size(60, 20);
            this.lblPageNum.TabIndex = 0;
            this.lblPageNum.Text = "1/1页";
            // 
            // PagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(583, 38);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX lblPageNum;
        private DevComponents.DotNetBar.LabelX labelCount;
        private DevComponents.DotNetBar.Controls.TextBoxX txtperpage;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBxNumber;
        private System.Windows.Forms.LinkLabel lnkFirst;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkLast;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnGo;
        private DevComponents.DotNetBar.LabelX labelX4;


    }
}
