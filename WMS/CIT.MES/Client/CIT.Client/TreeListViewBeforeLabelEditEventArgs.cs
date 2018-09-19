using System;
using System.Windows.Forms;

namespace CIT.Client
{
	[Serializable]
	public class TreeListViewBeforeLabelEditEventArgs : TreeListViewLabelEditEventArgs
	{
		private Control _Editor;

		public new int ColumnIndex
		{
			get
			{
				return _columnIndex;
			}
			set
			{
				_columnIndex = value;
			}
		}

		public Control Editor
		{
			get
			{
				return _Editor;
			}
			set
			{
				_Editor = value;
			}
		}

		public TreeListViewBeforeLabelEditEventArgs(TreeListViewItem item, int column, string label)
			: base(item, column, label)
		{
		}
	}
}
