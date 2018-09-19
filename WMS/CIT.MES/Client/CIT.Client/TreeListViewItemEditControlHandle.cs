using System;
using System.Runtime.InteropServices;
using System.Win32;
using System.Windows.Forms;

namespace CIT.Client
{
	internal class TreeListViewItemEditControlHandle : NativeWindow, IWin32Window
	{
		private CustomEdit _customedit;

		private Control _control;

		private TXTreeListView _treelistview;

		public new IntPtr Handle => base.Handle;

		public TreeListViewItemEditControlHandle(TXTreeListView treelistview, Control control, CustomEdit customedit)
		{
			_control = control;
			_treelistview = treelistview;
			_customedit = customedit;
			if (!control.Created)
			{
				control.CreateControl();
			}
			AssignHandle(control.Handle);
		}

		private void EndEdit(bool Cancel)
		{
			if (_treelistview.InEdit)
			{
				_treelistview.ExitEdit(Cancel, _control.Text);
			}
		}

		private bool OnKillFocus(Message m)
		{
			if (!(_control is ComboBox))
			{
				return true;
			}
			PCOMBOBOXINFO cbi = default(PCOMBOBOXINFO);
			cbi.cbSize = (uint)Marshal.SizeOf(typeof(PCOMBOBOXINFO));
			if (!NativeMethods.GetComboBoxInfo(_control.Handle, ref cbi))
			{
				return true;
			}
			if (m.WParam == cbi.hwndCombo || m.WParam == cbi.hwndItem || m.WParam == cbi.hwndList)
			{
				ReleaseHandle();
				AssignHandle(m.WParam);
				return false;
			}
			return true;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 256:
			{
				Keys keys = (Keys)(int)m.WParam;
				if (keys == Keys.Return || keys == Keys.Escape)
				{
					bool cancel = keys != Keys.Return;
					EndEdit(cancel);
					return;
				}
				break;
			}
			case 8:
				if (OnKillFocus(m))
				{
					EndEdit(!(_control is ComboBox) || !(_treelistview.EditedItem.Label != _control.Text));
					return;
				}
				break;
			}
			base.WndProc(ref m);
		}

		private int HighOrder(IntPtr Param)
		{
			int num = Param.ToInt32();
			return (num >> 16) & 0xFFFF;
		}

		private int LowOrder(IntPtr Param)
		{
			int num = Param.ToInt32();
			return num & 0xFFFF;
		}
	}
}
