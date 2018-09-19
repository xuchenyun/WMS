using System;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	internal class CustomEdit : NativeWindow, IWin32Window
	{
		private TreeListViewItemEditControlHandle _EditorHandle;

		private EditItemInformations _Informations;

		private Control _Editor;

		private TXTreeListView _TreeListView;

		public new IntPtr Handle => base.Handle;

		private CustomEdit()
		{
		}

		public CustomEdit(IntPtr handle, TXTreeListView treeListView, Control editor)
		{
			_TreeListView = treeListView;
			_Informations = _TreeListView.EditedItem;
			if (editor == null)
			{
				_Editor = new TextBox();
			}
			else
			{
				_Editor = editor;
			}
			_Editor.Hide();
			if (!_TreeListView.Controls.Contains(_Editor))
			{
				_TreeListView.Controls.Add(_Editor);
			}
			_EditorHandle = new TreeListViewItemEditControlHandle(_TreeListView, _Editor, this);
			AssignHandle(handle);
		}

		public void ShowEditControl()
		{
			if (_TreeListView.FocusedItem != null)
			{
				ListViewItem item = _TreeListView.EditedItem.Item;
				Rectangle rectangle = (_TreeListView.EditedItem.ColumnIndex > 0) ? _TreeListView.GetSubItemRect(item.Index, _TreeListView.EditedItem.ColumnIndex) : _TreeListView.GetItemRect(item.Index, ItemBoundsPortion.Label);
				_Editor.Size = rectangle.Size;
				_Editor.Location = rectangle.Location;
				_Editor.Top--;
				_Editor.Show();
				_Editor.Text = item.SubItems[_TreeListView.EditedItem.ColumnIndex].Text;
				_Editor.Focus();
			}
		}

		public void HideEditControl()
		{
			_Editor.Hide();
			ReleaseHandle();
			_EditorHandle.ReleaseHandle();
		}

		public void SendMessage(ref Message m)
		{
			WndProc(ref m);
		}

		protected override void WndProc(ref Message m)
		{
			WindowMessages msg = (WindowMessages)m.Msg;
			if (msg == WindowMessages.WM_SHOWWINDOW)
			{
				if (m.WParam != IntPtr.Zero)
				{
					ShowEditControl();
				}
				else
				{
					HideEditControl();
				}
			}
		}
	}
}
