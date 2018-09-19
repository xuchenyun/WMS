using System;

namespace CIT.Client
{
	[Serializable]
	public class TreeListViewCancelEventArgs : TreeListViewEventArgs
	{
		private bool _Cancel = false;

		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		public TreeListViewCancelEventArgs(TreeListViewItem item, TreeListViewAction action)
			: base(item, action)
		{
		}
	}
}
