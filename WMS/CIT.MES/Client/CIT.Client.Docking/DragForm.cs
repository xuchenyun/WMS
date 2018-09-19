using System;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal class DragForm : Form
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 128;
				return createParams;
			}
		}

		public DragForm()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
			SetStyle(ControlStyles.Selectable, value: false);
			base.Enabled = false;
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 132)
			{
				m.Result = (IntPtr)(-1L);
			}
			else
			{
				base.WndProc(ref m);
			}
		}

		public virtual void Show(bool bActivate)
		{
			if (bActivate)
			{
				Show();
			}
			else
			{
				NativeMethods.ShowWindow(base.Handle, 4);
			}
		}
	}
}
