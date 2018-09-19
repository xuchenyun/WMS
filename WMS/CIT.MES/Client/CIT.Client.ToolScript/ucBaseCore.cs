using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.ToolScript
{
	public class ucBaseCore : UserControl
	{
		private IContainer components = null;

		public ucBaseCore()
		{
			InitializeComponent();
		}

		public virtual bool AddBefore()
		{
			return false;
		}

		public virtual bool AddAfter()
		{
			return false;
		}

		public virtual bool AddBeforeAfter()
		{
			return false;
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
			SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Name = "ucBaseCore";
			base.Size = new System.Drawing.Size(293, 121);
			ResumeLayout(performLayout: false);
		}
	}
}
