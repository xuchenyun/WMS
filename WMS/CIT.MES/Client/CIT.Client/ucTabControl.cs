using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	public class ucTabControl : TabControl
	{
		private IContainer components = null;

		public ucTabControl()
		{
			InitializeComponent();
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
			base.Name = "ucTabControl";
			base.Size = new System.Drawing.Size(712, 402);
			ResumeLayout(performLayout: false);
		}
	}
}
