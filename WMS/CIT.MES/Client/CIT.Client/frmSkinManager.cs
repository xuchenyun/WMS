using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	internal class frmSkinManager : BaseForm
	{
		private IContainer components = null;

		protected TXButton btnCancel;

		protected TXButton btnOK;

		protected TXPanel panelWorkArea;

		protected Panel panelControlArea;

		protected TXButton btnApply;

		private TableLayoutPanel tableLayoutPanel1;

		private TXRadioButton rbn0;

		private TXRadioButton rbn1;

		private TXRadioButton rbn3;

		private TXRadioButton rbn2;

		private TXRadioButton rbn4;

		private Panel panel1;

		private PictureBox picBoxBg;

		private TrackBar trackOpacity;

		private Label label1;

		private TXCheckBox cbBgEnable;

		public frmSkinManager()
		{
			InitializeComponent();
			ControlHelper.BindMouseMoveEvent(panelControlArea);
		}

		private void frmSkinManager_Load(object sender, EventArgs e)
		{
			BindTheme();
		}

		protected virtual void OnBtnOkClick(object sender, EventArgs e)
		{
			SaveTheme();
			ApplyTheme();
			base.DialogResult = DialogResult.OK;
		}

		protected virtual void OnBtnCancelClick(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			SaveTheme();
			ApplyTheme();
		}

		private void ApplyTheme()
		{
			foreach (Form openForm in Application.OpenForms)
			{
				openForm.Invalidate();
			}
		}

		private void BindTheme()
		{
			cbBgEnable.Checked = SkinManager.CurrentSkin.BackGroundImageEnable;
			picBoxBg.BackgroundImage = SkinManager.CurrentSkin.BackGroundImage;
			trackOpacity.Value = (int)(SkinManager.CurrentSkin.BackGroundImageOpacity * 100f);
			switch (SkinManager.CurrentSkin.ThemeStyle)
			{
			case EnumTheme.Default:
				rbn0.Checked = true;
				break;
			case EnumTheme.BlueSea:
				rbn1.Checked = true;
				break;
			case EnumTheme.KissOfAngel:
				rbn2.Checked = true;
				break;
			case EnumTheme.NoFlower:
				rbn3.Checked = true;
				break;
			case EnumTheme.SunsetRed:
				rbn4.Checked = true;
				break;
			}
		}

		private void SaveTheme()
		{
			int num = (!rbn0.Checked) ? (rbn1.Checked ? 1 : (rbn2.Checked ? 2 : (rbn3.Checked ? 3 : (rbn4.Checked ? 4 : 0)))) : 0;
			SkinManager.SettingSkinTeme(num.ToEnumByValue<EnumTheme>());
			SkinManager.CurrentSkin.BackGroundImageEnable = cbBgEnable.Checked;
			SkinManager.CurrentSkin.BackGroundImageOpacity = (float)trackOpacity.Value / 100f;
			SkinManager.CurrentSkin.BackGroundImage = (Bitmap)picBoxBg.BackgroundImage;
			SkinManager.Save();
		}

		private void picBoxBg_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "(所有文件)|*.*|(jpg图片)|*.jpg|(jpeg)|*.jpeg|(gif图片)|*.gif";
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				picBoxBg.BackgroundImage = Image.FromFile(openFileDialog.FileName);
			}
		}

		private void rbn_CheckedChanged(object sender, EventArgs e)
		{
			TXRadioButton tXRadioButton = (TXRadioButton)sender;
			if (tXRadioButton == null)
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			panelWorkArea = new CIT.Client.TXPanel();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			rbn0 = new CIT.Client.TXRadioButton();
			rbn1 = new CIT.Client.TXRadioButton();
			rbn3 = new CIT.Client.TXRadioButton();
			rbn2 = new CIT.Client.TXRadioButton();
			rbn4 = new CIT.Client.TXRadioButton();
			panel1 = new System.Windows.Forms.Panel();
			cbBgEnable = new CIT.Client.TXCheckBox();
			label1 = new System.Windows.Forms.Label();
			trackOpacity = new System.Windows.Forms.TrackBar();
			picBoxBg = new System.Windows.Forms.PictureBox();
			panelControlArea = new System.Windows.Forms.Panel();
			btnApply = new CIT.Client.TXButton();
			btnCancel = new CIT.Client.TXButton();
			btnOK = new CIT.Client.TXButton();
			panelWorkArea.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackOpacity).BeginInit();
			((System.ComponentModel.ISupportInitialize)picBoxBg).BeginInit();
			panelControlArea.SuspendLayout();
			SuspendLayout();
			panelWorkArea.BackColor = System.Drawing.Color.Transparent;
			panelWorkArea.BorderColor = System.Drawing.Color.LightGray;
			panelWorkArea.Controls.Add(tableLayoutPanel1);
			panelWorkArea.CornerRadius = 5;
			panelWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
			panelWorkArea.ForeColor = System.Drawing.SystemColors.ControlText;
			panelWorkArea.Location = new System.Drawing.Point(4, 30);
			panelWorkArea.MinimumSize = new System.Drawing.Size(27, 27);
			panelWorkArea.Name = "panelWorkArea";
			panelWorkArea.Size = new System.Drawing.Size(445, 205);
			panelWorkArea.TabIndex = 0;
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(rbn0, 1, 0);
			tableLayoutPanel1.Controls.Add(rbn1, 1, 1);
			tableLayoutPanel1.Controls.Add(rbn3, 1, 2);
			tableLayoutPanel1.Controls.Add(rbn2, 1, 3);
			tableLayoutPanel1.Controls.Add(rbn4, 1, 4);
			tableLayoutPanel1.Controls.Add(panel1, 1, 5);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 6;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(445, 205);
			tableLayoutPanel1.TabIndex = 1;
			rbn0.AutoSize = true;
			rbn0.Location = new System.Drawing.Point(23, 3);
			rbn0.MaxRadius = 8;
			rbn0.MinimumSize = new System.Drawing.Size(22, 22);
			rbn0.MinRadius = 4;
			rbn0.Name = "rbn0";
			rbn0.Size = new System.Drawing.Size(71, 22);
			rbn0.TabIndex = 1;
			rbn0.Tag = "0";
			rbn0.Text = "默认皮肤";
			rbn0.UseVisualStyleBackColor = true;
			rbn0.CheckedChanged += new System.EventHandler(rbn_CheckedChanged);
			rbn1.AutoSize = true;
			rbn1.Location = new System.Drawing.Point(23, 31);
			rbn1.MaxRadius = 8;
			rbn1.MinimumSize = new System.Drawing.Size(22, 22);
			rbn1.MinRadius = 4;
			rbn1.Name = "rbn1";
			rbn1.Size = new System.Drawing.Size(131, 22);
			rbn1.TabIndex = 2;
			rbn1.Tag = "1";
			rbn1.Text = "面朝大海，春暖花开";
			rbn1.UseVisualStyleBackColor = true;
			rbn3.AutoSize = true;
			rbn3.Location = new System.Drawing.Point(23, 59);
			rbn3.MaxRadius = 8;
			rbn3.MinimumSize = new System.Drawing.Size(22, 22);
			rbn3.MinRadius = 4;
			rbn3.Name = "rbn3";
			rbn3.Size = new System.Drawing.Size(131, 22);
			rbn3.TabIndex = 3;
			rbn3.Tag = "3";
			rbn3.Text = "如花美眷，流年似水";
			rbn3.UseVisualStyleBackColor = true;
			rbn2.AutoSize = true;
			rbn2.Location = new System.Drawing.Point(23, 87);
			rbn2.MaxRadius = 8;
			rbn2.MinimumSize = new System.Drawing.Size(22, 22);
			rbn2.MinRadius = 4;
			rbn2.Name = "rbn2";
			rbn2.Size = new System.Drawing.Size(71, 22);
			rbn2.TabIndex = 4;
			rbn2.Tag = "2";
			rbn2.Text = "天使之吻";
			rbn2.UseVisualStyleBackColor = true;
			rbn4.AutoSize = true;
			rbn4.Location = new System.Drawing.Point(23, 115);
			rbn4.MaxRadius = 8;
			rbn4.MinimumSize = new System.Drawing.Size(22, 22);
			rbn4.MinRadius = 4;
			rbn4.Name = "rbn4";
			rbn4.Size = new System.Drawing.Size(131, 22);
			rbn4.TabIndex = 5;
			rbn4.Tag = "4";
			rbn4.Text = "夕阳西下，明月天涯";
			rbn4.UseVisualStyleBackColor = true;
			panel1.Controls.Add(cbBgEnable);
			panel1.Controls.Add(label1);
			panel1.Controls.Add(trackOpacity);
			panel1.Controls.Add(picBoxBg);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(23, 143);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(419, 59);
			panel1.TabIndex = 6;
			cbBgEnable.AutoSize = true;
			cbBgEnable.Location = new System.Drawing.Point(3, 17);
			cbBgEnable.MinimumSize = new System.Drawing.Size(20, 20);
			cbBgEnable.Name = "cbBgEnable";
			cbBgEnable.Size = new System.Drawing.Size(96, 20);
			cbBgEnable.TabIndex = 3;
			cbBgEnable.Text = "开启主题背景";
			cbBgEnable.UseVisualStyleBackColor = true;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(208, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 2;
			label1.Text = "透明度";
			trackOpacity.BackColor = System.Drawing.Color.White;
			trackOpacity.Location = new System.Drawing.Point(244, 14);
			trackOpacity.Maximum = 100;
			trackOpacity.Name = "trackOpacity";
			trackOpacity.Size = new System.Drawing.Size(168, 45);
			trackOpacity.TabIndex = 1;
			trackOpacity.TickFrequency = 5;
			trackOpacity.Value = 20;
			picBoxBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			picBoxBg.Location = new System.Drawing.Point(105, 4);
			picBoxBg.Name = "picBoxBg";
			picBoxBg.Size = new System.Drawing.Size(68, 50);
			picBoxBg.TabIndex = 0;
			picBoxBg.TabStop = false;
			picBoxBg.Click += new System.EventHandler(picBoxBg_Click);
			panelControlArea.BackColor = System.Drawing.Color.Transparent;
			panelControlArea.Controls.Add(btnApply);
			panelControlArea.Controls.Add(btnCancel);
			panelControlArea.Controls.Add(btnOK);
			panelControlArea.Dock = System.Windows.Forms.DockStyle.Bottom;
			panelControlArea.Location = new System.Drawing.Point(4, 235);
			panelControlArea.Margin = new System.Windows.Forms.Padding(0);
			panelControlArea.Name = "panelControlArea";
			panelControlArea.Size = new System.Drawing.Size(445, 30);
			panelControlArea.TabIndex = 1;
			btnApply.Image = null;
			btnApply.Location = new System.Drawing.Point(182, 1);
			btnApply.Name = "btnApply";
			btnApply.Size = new System.Drawing.Size(80, 25);
			btnApply.TabIndex = 2;
			btnApply.Text = "应 用";
			btnApply.UseVisualStyleBackColor = true;
			btnApply.Click += new System.EventHandler(btnApply_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Image = null;
			btnCancel.Location = new System.Drawing.Point(271, 1);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(80, 25);
			btnCancel.TabIndex = 1;
			btnCancel.Text = "取 消";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(OnBtnCancelClick);
			btnOK.Image = null;
			btnOK.Location = new System.Drawing.Point(93, 1);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(80, 25);
			btnOK.TabIndex = 0;
			btnOK.Text = "确 定";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(OnBtnOkClick);
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(453, 266);
			base.Controls.Add(panelWorkArea);
			base.Controls.Add(panelControlArea);
			base.CornerRadius = 1;
			Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Location = new System.Drawing.Point(0, 0);
			base.MaximizeBox = false;
			base.Name = "frmSkinManager";
			base.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
			base.ResizeEnable = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "皮肤管理中心";
			base.Load += new System.EventHandler(frmSkinManager_Load);
			panelWorkArea.ResumeLayout(performLayout: false);
			tableLayoutPanel1.ResumeLayout(performLayout: false);
			tableLayoutPanel1.PerformLayout();
			panel1.ResumeLayout(performLayout: false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)trackOpacity).EndInit();
			((System.ComponentModel.ISupportInitialize)picBoxBg).EndInit();
			panelControlArea.ResumeLayout(performLayout: false);
			ResumeLayout(performLayout: false);
		}
	}
}
