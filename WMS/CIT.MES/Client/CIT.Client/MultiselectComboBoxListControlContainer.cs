using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxItem(false)]
	public class MultiselectComboBoxListControlContainer : UserControl
	{
		public MultiselectComboBoxListControlContainer()
		{
			BackColor = SystemColors.Window;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.AutoScaleMode = AutoScaleMode.Inherit;
			base.ResizeRedraw = true;
			MinimumSize = new Size(1, 1);
			MaximumSize = new Size(500, 500);
		}

		protected override void WndProc(ref Message m)
		{
			if (!(base.Parent as Popup).ProcessResizing(ref m))
			{
				base.WndProc(ref m);
			}
		}
	}
}
