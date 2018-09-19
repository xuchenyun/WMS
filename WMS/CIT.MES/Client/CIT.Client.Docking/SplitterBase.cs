using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal class SplitterBase : Control
	{
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				SuspendLayout();
				base.Dock = value;
				if (Dock == DockStyle.Left || Dock == DockStyle.Right)
				{
					base.Width = SplitterSize;
				}
				else if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
				{
					base.Height = SplitterSize;
				}
				else
				{
					base.Bounds = Rectangle.Empty;
				}
				if (Dock == DockStyle.Left || Dock == DockStyle.Right)
				{
					Cursor = Cursors.VSplit;
				}
				else if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
				{
					Cursor = Cursors.HSplit;
				}
				else
				{
					Cursor = Cursors.Default;
				}
				ResumeLayout();
			}
		}

		protected virtual int SplitterSize => 0;

		public SplitterBase()
		{
			SetStyle(ControlStyles.Selectable, value: false);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				StartDrag();
			}
		}

		protected virtual void StartDrag()
		{
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg != 33)
			{
				base.WndProc(ref m);
			}
		}
	}
}
