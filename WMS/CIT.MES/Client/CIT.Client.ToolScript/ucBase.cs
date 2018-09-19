using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.ToolScript
{
	public class ucBase : ucBaseCore
	{
		private IContainer components = null;

		private ToolStrip toolStrip1;

		private ToolStripButton tol_refresh;

		private ToolStripButton tol_add;

		private ToolStripButton toolStripButton3;

		private ToolStripButton toolStripButton4;

		private ToolStripButton toolStripButton5;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton toolStripButton6;

		private ToolStripButton toolStripButton7;

		private ToolStripButton toolStripButton8;

		private ToolStripButton toolStripButton9;

		public ucBase()
		{
			InitializeComponent();
			base.Height = toolStrip1.Height;
			base.Width = toolStrip1.Width;
		}

		private void tol_add_Click(object sender, EventArgs e)
		{
			AddBefore();
			AddAfter();
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CIT.Client.ToolScript.ucBase));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			tol_refresh = new System.Windows.Forms.ToolStripButton();
			tol_add = new System.Windows.Forms.ToolStripButton();
			toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[10]
			{
				tol_refresh,
				tol_add,
				toolStripButton3,
				toolStripButton4,
				toolStripButton5,
				toolStripSeparator1,
				toolStripButton6,
				toolStripButton7,
				toolStripButton8,
				toolStripButton9
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new System.Drawing.Size(848, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			tol_refresh.Image = (System.Drawing.Image)componentResourceManager.GetObject("tol_refresh.Image");
			tol_refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			tol_refresh.Name = "tol_refresh";
			tol_refresh.Size = new System.Drawing.Size(52, 22);
			tol_refresh.Text = "刷新";
			tol_add.Image = (System.Drawing.Image)componentResourceManager.GetObject("tol_add.Image");
			tol_add.ImageTransparentColor = System.Drawing.Color.Magenta;
			tol_add.Name = "tol_add";
			tol_add.Size = new System.Drawing.Size(52, 22);
			tol_add.Text = "新增";
			tol_add.Click += new System.EventHandler(tol_add_Click);
			toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton3.Name = "toolStripButton3";
			toolStripButton3.Size = new System.Drawing.Size(36, 22);
			toolStripButton3.Text = "编辑";
			toolStripButton4.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton4.Image");
			toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton4.Name = "toolStripButton4";
			toolStripButton4.Size = new System.Drawing.Size(52, 22);
			toolStripButton4.Text = "删除";
			toolStripButton5.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton5.Image");
			toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton5.Name = "toolStripButton5";
			toolStripButton5.Size = new System.Drawing.Size(52, 22);
			toolStripButton5.Text = "保存";
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			toolStripButton6.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton6.Image");
			toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton6.Name = "toolStripButton6";
			toolStripButton6.Size = new System.Drawing.Size(52, 22);
			toolStripButton6.Text = "导入";
			toolStripButton7.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton7.Image");
			toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton7.Name = "toolStripButton7";
			toolStripButton7.Size = new System.Drawing.Size(52, 22);
			toolStripButton7.Text = "导出";
			toolStripButton8.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton8.Image");
			toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton8.Name = "toolStripButton8";
			toolStripButton8.Size = new System.Drawing.Size(52, 22);
			toolStripButton8.Text = "下载";
			toolStripButton9.Image = (System.Drawing.Image)componentResourceManager.GetObject("toolStripButton9.Image");
			toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton9.Name = "toolStripButton9";
			toolStripButton9.Size = new System.Drawing.Size(52, 22);
			toolStripButton9.Text = "分享";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(toolStrip1);
			base.Name = "ucBase";
			base.Size = new System.Drawing.Size(848, 115);
			toolStrip1.ResumeLayout(performLayout: false);
			toolStrip1.PerformLayout();
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}
