#define DEBUG
using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.APIs;
using System.Win32;
using System.Windows.Forms;

namespace CIT.Client
{
	public class TreeListViewItem : ListViewItem
	{
		private TreeListViewItem _Parent;

		private TreeListViewItemCollection _Items;

		private bool _IsExpanded;

		public TreeListViewItem NextVisibleItem
		{
			get
			{
				if (!IsInATreeListView || !Visible)
				{
					return null;
				}
				ListView treeListView = TreeListView;
				if (base.Index >= treeListView.Items.Count - 1)
				{
					return null;
				}
				return (TreeListViewItem)treeListView.Items[base.Index + 1];
			}
		}

		public TreeListViewItem PrevVisibleItem
		{
			get
			{
				if (!IsInATreeListView || !Visible)
				{
					return null;
				}
				ListView treeListView = TreeListView;
				if (base.Index < 1)
				{
					return null;
				}
				return (TreeListViewItem)treeListView.Items[base.Index - 1];
			}
		}

		public new bool Checked
		{
			get
			{
				try
				{
					return base.Checked;
				}
				catch
				{
					return false;
				}
			}
			set
			{
				if (IsInATreeListView && TreeListView.InvokeRequired)
				{
					throw new Exception("Invoke required");
				}
				try
				{
					if (ListView != null && ListView.CheckDirection == CheckDirection.Downwards && _Items.Count > 0)
					{
						foreach (TreeListViewItem item in _Items)
						{
							item.Checked = value;
						}
					}
					if (base.Checked != value)
					{
						base.Checked = value;
					}
				}
				catch
				{
				}
			}
		}

		public CheckState CheckStatus
		{
			get
			{
				if (_Items.Count <= 0)
				{
					return Checked ? CheckState.Checked : CheckState.Unchecked;
				}
				bool flag = true;
				bool flag2 = true;
				TreeListViewItem[] array = Items.ToArray();
				TreeListViewItem[] array2 = array;
				foreach (TreeListViewItem treeListViewItem in array2)
				{
					if (treeListViewItem.CheckStatus == CheckState.Indeterminate)
					{
						return CheckState.Indeterminate;
					}
					if (treeListViewItem.CheckStatus == CheckState.Checked)
					{
						flag2 = false;
					}
					else
					{
						flag = false;
					}
				}
				if (flag)
				{
					return CheckState.Checked;
				}
				if (flag2)
				{
					return CheckState.Unchecked;
				}
				return CheckState.Indeterminate;
			}
		}

		[Browsable(false)]
		public TreeListViewItem[] ParentsInHierarch
		{
			get
			{
				return GetParentsInHierarch().ToArray();
			}
		}

		[Browsable(false)]
		public string FullPath
		{
			get
			{
				if (Parent != null)
				{
					string text = IsInATreeListView ? TreeListView.PathSeparator : "\\";
					string text2 = Parent.FullPath + text + Text;
					return text2.Replace(text + text, text);
				}
				return Text;
			}
		}

		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				Container?.Sort(recursively: false);
			}
		}

		public TreeListViewItemCollection Container
		{
			get
			{
				if (Parent != null)
				{
					return Parent.Items;
				}
				if (IsInATreeListView)
				{
					return TreeListView.Items;
				}
				return null;
			}
		}

		internal bool IsInATreeListView => TreeListView != null;

		[Browsable(false)]
		public int LastChildIndexInListView
		{
			get
			{
				if (!IsInATreeListView)
				{
					throw new Exception("No ListView control");
				}
				int num = base.Index;
				foreach (TreeListViewItem item in Items)
				{
					if (item.Visible)
					{
						int lastChildIndexInListView = item.LastChildIndexInListView;
						if (lastChildIndexInListView > num)
						{
							num = lastChildIndexInListView;
						}
					}
				}
				return num;
			}
		}

		[Browsable(false)]
		public int ChildrenCount
		{
			get
			{
				TreeListViewItem[] array = _Items.ToArray();
				int num = array.Length;
				TreeListViewItem[] array2 = array;
				foreach (TreeListViewItem treeListViewItem in array2)
				{
					num += treeListViewItem.ChildrenCount;
				}
				return num;
			}
		}

		public bool IsExpanded
		{
			get
			{
				return _IsExpanded;
			}
			set
			{
				if (_IsExpanded != value)
				{
					if (value)
					{
						Expand();
					}
					else
					{
						Collapse();
					}
				}
			}
		}

		[Browsable(false)]
		public int Level
		{
			get
			{
				return (Parent != null) ? (Parent.Level + 1) : 0;
			}
		}

		public TreeListViewItem Parent => _Parent;

		public TreeListViewItemCollection Items => _Items;

		public new TXTreeListView ListView
		{
			get
			{
				if (base.ListView != null)
				{
					return (TXTreeListView)base.ListView;
				}
				if (Parent != null)
				{
					return Parent.ListView;
				}
				return null;
			}
		}

		public TXTreeListView TreeListView => ListView;

		public bool Visible => base.Index > -1;

		public event TreeListViewItemHandler AfterCollapse;

		public event TreeListViewItemHandler AfterExpand;

		public TreeListViewItem()
		{
			_Items = new TreeListViewItemCollection(this);
		}

		public TreeListViewItem(string value)
			: this()
		{
			Text = value;
		}

		public TreeListViewItem(string value, int imageIndex)
			: this(value)
		{
			base.ImageIndex = imageIndex;
		}

		internal void GetCheckedItems(ref TreeListViewItemCollection items)
		{
			if (Checked)
			{
				items.Add(this);
			}
			foreach (TreeListViewItem item in Items)
			{
				item.GetCheckedItems(ref items);
			}
		}

		public void BeginEdit(int column)
		{
			if (TreeListView == null)
			{
				throw new Exception("The item is not associated with a TreeListView");
			}
			if (!TreeListView.Visible)
			{
				throw new Exception("The item is not visible");
			}
			if (column + 1 > TreeListView.Columns.Count)
			{
				throw new Exception("The column is greater the number of columns in the TreeListView");
			}
			TreeListView.Focus();
			base.Focused = true;
			TreeListView._LastItemClicked = new EditItemInformations(this, column, base.SubItems[column].Text);
			base.BeginEdit();
		}

		public new void BeginEdit()
		{
			BeginEdit(0);
		}

		public void Redraw()
		{
			if (ListView != null && Visible)
			{
				try
				{
					NativeMethods.SendMessage(ListView.Handle, 4117, base.Index, base.Index);
				}
				catch
				{
				}
			}
		}

		public Rectangle GetBounds(TreeListViewItemBoundsPortion portion)
		{
			if (portion == TreeListViewItemBoundsPortion.PlusMinus)
			{
				if (TreeListView == null)
				{
					throw new Exception("This item is not associated with a TreeListView control");
				}
				Point location = GetBounds(ItemBoundsPortion.Entire).Location;
				Point location2 = new Point(Level * SystemInformation.SmallIconSize.Width + 1 + location.X, TreeListView.GetItemRect(base.Index, ItemBoundsPortion.Entire).Top + 1);
				return new Rectangle(location2, TreeListView.ShowPlusMinus ? SystemInformation.SmallIconSize : new Size(0, 0));
			}
			return GetBounds((ItemBoundsPortion)portion);
		}

		internal void SetParent(TreeListViewItem parent)
		{
			_Parent = parent;
		}

		public new void Remove()
		{
			if (ListView != null && ListView.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			Container?.Remove(this);
		}

		public bool IsAParentOf(TreeListViewItem item)
		{
			TreeListViewItem[] parentsInHierarch = item.ParentsInHierarch;
			TreeListViewItem[] array = parentsInHierarch;
			foreach (TreeListViewItem treeListViewItem in array)
			{
				if (treeListViewItem == this)
				{
					return true;
				}
			}
			return false;
		}

		public new void EnsureVisible()
		{
			if (!Visible)
			{
				if (IsInATreeListView)
				{
					TreeListView.BeginUpdate();
				}
				if (ListView != null)
				{
					ListView.Invoke(new MethodInvoker(ExpandParents));
				}
				else
				{
					ExpandParents();
				}
				if (TreeListView != null)
				{
					TreeListView.EndUpdate();
				}
			}
			base.EnsureVisible();
		}

		internal void ExpandParents()
		{
			if (Parent != null)
			{
				if (!Parent.IsExpanded)
				{
					Parent.ExpandInternal();
				}
				Parent.ExpandParents();
			}
		}

		public bool SetIndentation()
		{
			if (!IsInATreeListView)
			{
				return false;
			}
			bool result = true;
			LV_ITEM lParam = default(LV_ITEM);
			lParam.iItem = base.Index;
			lParam.iIndent = Level;
			if (TreeListView.ShowPlusMinus)
			{
				lParam.iIndent++;
			}
			lParam.mask = ListViewItemFlags.INDENT;
			try
			{
				SendMessage(ListView.Handle, ListViewMessages.SETITEM, 0, ref lParam);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public void RefreshIndentation(bool recursively)
		{
			if (ListView != null)
			{
				if (ListView.InvokeRequired)
				{
					throw new Exception("Invoke Required");
				}
				if (Visible)
				{
					SetIndentation();
					if (recursively)
					{
						try
						{
							foreach (TreeListViewItem item in Items)
							{
								item.RefreshIndentation(recursively: true);
							}
						}
						catch
						{
						}
					}
				}
			}
		}

		public void Expand()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
			ExpandInternal();
			if (TreeListView != null)
			{
				TreeListView.EndUpdate();
			}
		}

		internal void ExpandInternal()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			TreeListViewItem treeListViewItem = null;
			if (TreeListView != null)
			{
				treeListViewItem = TreeListView.FocusedItem;
			}
			CheckDirection checkDirection = CheckDirection.All;
			if (ListView != null)
			{
				checkDirection = ListView.CheckDirection;
				ListView.CheckDirection = CheckDirection.None;
			}
			if (Visible && !_IsExpanded && ListView != null)
			{
				TreeListViewCancelEventArgs treeListViewCancelEventArgs = new TreeListViewCancelEventArgs(this, TreeListViewAction.Expand);
				ListView.RaiseBeforeExpand(treeListViewCancelEventArgs);
				if (treeListViewCancelEventArgs.Cancel)
				{
					return;
				}
			}
			if (Visible)
			{
				for (int num = Items.Count - 1; num >= 0; num--)
				{
					TreeListViewItem treeListViewItem2 = Items[num];
					if (!treeListViewItem2.Visible)
					{
						ListView treeListView = TreeListView;
						treeListView.Items.Insert(base.Index + 1, treeListViewItem2);
						treeListViewItem2.SetIndentation();
					}
					if (treeListViewItem2.IsExpanded)
					{
						treeListViewItem2.Expand();
					}
				}
			}
			if (Visible && !_IsExpanded && IsInATreeListView)
			{
				_IsExpanded = true;
				TreeListViewEventArgs e = new TreeListViewEventArgs(this, TreeListViewAction.Expand);
				ListView.RaiseAfterExpand(e);
				if (this.AfterExpand != null)
				{
					this.AfterExpand(this);
				}
			}
			_IsExpanded = true;
			if (IsInATreeListView)
			{
				ListView.CheckDirection = checkDirection;
			}
			if (TreeListView != null && treeListViewItem != null && treeListViewItem.Visible)
			{
				treeListViewItem.Focused = true;
			}
		}

		public void ExpandAll()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
			ExpandAllInternal();
			if (TreeListView != null)
			{
				TreeListView.EndUpdate();
			}
		}

		internal void ExpandAllInternal()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			ExpandInternal();
			if (IsExpanded)
			{
				for (int i = 0; i < Items.Count; i++)
				{
					Items[i].ExpandAllInternal();
				}
			}
		}

		public void Collapse()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
			CollapseInternal();
			if (TreeListView != null)
			{
				TreeListView.EndUpdate();
			}
		}

		internal void CollapseInternal()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			TreeListViewItem treeListViewItem = null;
			if (TreeListView != null)
			{
				treeListViewItem = TreeListView.FocusedItem;
			}
			if (Visible && _IsExpanded && ListView != null)
			{
				TreeListViewCancelEventArgs treeListViewCancelEventArgs = new TreeListViewCancelEventArgs(this, TreeListViewAction.Collapse);
				ListView.RaiseBeforeCollapse(treeListViewCancelEventArgs);
				if (treeListViewCancelEventArgs.Cancel)
				{
					return;
				}
			}
			if (Visible)
			{
				foreach (TreeListViewItem item in Items)
				{
					item.Hide();
				}
			}
			if (Visible && _IsExpanded && IsInATreeListView)
			{
				_IsExpanded = false;
				TreeListViewEventArgs e = new TreeListViewEventArgs(this, TreeListViewAction.Collapse);
				ListView.RaiseAfterCollapse(e);
				if (this.AfterCollapse != null)
				{
					this.AfterCollapse(this);
				}
			}
			_IsExpanded = false;
			if (IsInATreeListView && treeListViewItem != null)
			{
				if (treeListViewItem.Visible)
				{
					treeListViewItem.Focused = true;
				}
				else
				{
					ListView treeListView = TreeListView;
					treeListView.SelectedItems.Clear();
					TreeListViewItem[] parentsInHierarch = treeListViewItem.ParentsInHierarch;
					int num = parentsInHierarch.Length - 1;
					while (true)
					{
						if (num < 0)
						{
							return;
						}
						if (parentsInHierarch[num].Visible)
						{
							break;
						}
						num--;
					}
					parentsInHierarch[num].Focused = true;
				}
			}
		}

		public void CollapseAll()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			if (TreeListView != null)
			{
				TreeListView.BeginUpdate();
			}
			CollapseAllInternal();
			if (TreeListView != null)
			{
				TreeListView.EndUpdate();
			}
		}

		internal void CollapseAllInternal()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			foreach (TreeListViewItem item in Items)
			{
				item.CollapseAllInternal();
			}
			CollapseInternal();
		}

		internal void Hide()
		{
			if (IsInATreeListView && ListView.InvokeRequired)
			{
				throw new Exception("Invoke Required");
			}
			foreach (TreeListViewItem item in Items)
			{
				item.Hide();
			}
			if (Visible)
			{
				base.Remove();
			}
			base.Selected = false;
		}

		internal void DrawPlusMinus()
		{
			if (IsInATreeListView && !TreeListView._Updating)
			{
				using (Graphics g = Graphics.FromHwnd(TreeListView.Handle))
				{
					DrawPlusMinus(g);
				}
			}
		}

		internal void DrawPlusMinus(Graphics g)
		{
			if (IsInATreeListView && !TreeListView._Updating && Items.Count != 0 && TreeListView.Columns.Count != 0)
			{
				using (ImageAttributes imageAttributes = new ImageAttributes())
				{
					imageAttributes.SetColorKey(Color.Transparent, Color.Transparent);
					if (TreeListView.Columns[0].Width > (Level + 1) * SystemInformation.SmallIconSize.Width)
					{
						g.DrawImage(IsExpanded ? Resources.Collapse1 : Resources.Expand1, GetBounds(TreeListViewItemBoundsPortion.PlusMinus), 0, 0, SystemInformation.SmallIconSize.Width, SystemInformation.SmallIconSize.Height, GraphicsUnit.Pixel, imageAttributes);
					}
				}
			}
		}

		internal void DrawPlusMinusLines()
		{
			if (IsInATreeListView && !TreeListView._Updating)
			{
				using (Graphics g = Graphics.FromHwnd(TreeListView.Handle))
				{
					DrawPlusMinusLines(g);
				}
			}
		}

		internal void DrawPlusMinusLines(Graphics g)
		{
			if (IsInATreeListView && !TreeListView._Updating && TreeListView.ShowPlusMinus && TreeListView.Columns.Count != 0)
			{
				int level = Level;
				Rectangle bounds = GetBounds(TreeListViewItemBoundsPortion.PlusMinus);
				Rectangle bounds2 = GetBounds(TreeListViewItemBoundsPortion.Entire);
				using (HatchBrush brush = new HatchBrush(HatchStyle.Percent50, TreeListView.PlusMinusLineColor, base.BackColor))
				{
					using (Pen pen = new Pen(brush))
					{
						Point pt = new Point(bounds.Right - SystemInformation.SmallIconSize.Width / 2 - 1, bounds2.Top);
						Point pt2 = new Point(pt.X, bounds2.Bottom);
						if (!HasLevelBeforeItem(level))
						{
							pt.Y += SystemInformation.SmallIconSize.Height / 2;
						}
						if (!HasLevelAfterItem(level))
						{
							pt2.Y -= SystemInformation.SmallIconSize.Height / 2 + 1;
						}
						if (TreeListView.Columns[0].Width > (Level + 1) * SystemInformation.SmallIconSize.Width)
						{
							g.DrawLine(pen, pt, pt2);
						}
						pt = new Point(bounds.Right - SystemInformation.SmallIconSize.Width / 2 - 1, GetBounds(TreeListViewItemBoundsPortion.Entire).Top + SystemInformation.SmallIconSize.Height / 2);
						pt2 = new Point(bounds.Right + 1, pt.Y);
						if (TreeListView.Columns[0].Width > (Level + 1) * SystemInformation.SmallIconSize.Width)
						{
							g.DrawLine(pen, pt, pt2);
						}
						for (int num = Level - 1; num > -1; num--)
						{
							if (HasLevelAfterItem(num))
							{
								pt = new Point(SystemInformation.SmallIconSize.Width * (2 * num + 1) / 2 + bounds2.X, bounds2.Top);
								pt2 = new Point(pt.X, bounds2.Bottom);
								if (TreeListView.Columns[0].Width > (num + 1) * SystemInformation.SmallIconSize.Width)
								{
									g.DrawLine(pen, pt, pt2);
								}
							}
						}
					}
				}
			}
		}

		internal bool HasLevelAfterItem(int level)
		{
			if (TreeListView == null)
			{
				return false;
			}
			int level2 = Level;
			ListView treeListView = TreeListView;
			for (int i = base.Index + 1; i < treeListView.Items.Count; i++)
			{
				int level3 = ((TreeListViewItem)treeListView.Items[i]).Level;
				if (level3 == level)
				{
					return true;
				}
				if (level3 < level)
				{
					return false;
				}
			}
			return false;
		}

		internal bool HasLevelBeforeItem(int level)
		{
			if (TreeListView == null)
			{
				return false;
			}
			Debug.Assert(!TreeListView.InvokeRequired);
			int level2 = Level;
			ListView treeListView = TreeListView;
			for (int num = base.Index - 1; num > -1; num--)
			{
				int level3 = ((TreeListViewItem)treeListView.Items[num]).Level;
				if (level3 <= level)
				{
					return true;
				}
			}
			return false;
		}

		internal void DrawFocusCues()
		{
			if (IsInATreeListView && !TreeListView._Updating && (!TreeListView.HideSelection || TreeListView.Focused))
			{
				Graphics graphics = Graphics.FromHwnd(TreeListView.Handle);
				if (Visible)
				{
					Rectangle bounds = GetBounds(ItemBoundsPortion.Entire);
					if ((float)bounds.Bottom > (float)bounds.Height * 1.5f)
					{
						Rectangle bounds2 = GetBounds(ItemBoundsPortion.Label);
						Rectangle bounds3 = GetBounds(ItemBoundsPortion.ItemOnly);
						Rectangle rect = new Rectangle(bounds2.Left, bounds2.Top, TreeListView.FullRowSelect ? (bounds.Width - bounds2.Left - 1) : (bounds3.Width - SystemInformation.SmallIconSize.Width - 1), bounds2.Height - 1);
						Pen pen = new Pen((TreeListView.Focused && base.Selected) ? Color.Blue : ColorUtil.CalculateColor(System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.Window, 130));
						for (int i = 1; i < TreeListView.Columns.Count; i++)
						{
							Rectangle subItemRect = TreeListView.GetSubItemRect(base.Index, i);
							if (subItemRect.X < rect.X)
							{
								rect = new Rectangle(subItemRect.X, rect.Y, rect.Width + (rect.X - subItemRect.X), rect.Height);
							}
						}
						graphics.DrawRectangle(new Pen(ColorUtil.VSNetSelectionColor), rect);
						if (!TreeListView.FullRowSelect)
						{
							graphics.FillRectangle(new SolidBrush(base.BackColor), bounds3.Right - 1, bounds3.Top, bounds2.Width - bounds3.Width + SystemInformation.SmallIconSize.Width + 1, rect.Height + 1);
						}
						bool flag = true;
						if (PrevVisibleItem != null && PrevVisibleItem.Selected)
						{
							flag = false;
						}
						if (flag)
						{
							graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
						}
						graphics.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom);
						flag = true;
						if (NextVisibleItem != null && NextVisibleItem.Selected)
						{
							flag = false;
						}
						if (flag)
						{
							graphics.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
						}
						graphics.DrawLine(pen, rect.Right, rect.Top, rect.Right, rect.Bottom);
						if (!TreeListView.FullRowSelect && NextVisibleItem != null && NextVisibleItem.Selected)
						{
							int width = NextVisibleItem.GetBounds(TreeListViewItemBoundsPortion.ItemOnly).Width;
							if (width != bounds3.Width)
							{
								graphics.DrawLine(pen, rect.Right, rect.Bottom, rect.Right - (bounds3.Width - width), rect.Bottom);
							}
						}
						pen.Dispose();
					}
				}
				graphics.Dispose();
			}
		}

		internal void DrawIntermediateState()
		{
			if (IsInATreeListView && !TreeListView._Updating)
			{
				using (Graphics g = Graphics.FromHwnd(TreeListView.Handle))
				{
					DrawIntermediateState(g);
				}
			}
		}

		internal void DrawIntermediateState(Graphics g)
		{
			if (IsInATreeListView && !TreeListView._Updating && TreeListView.CheckBoxes == CheckBoxesTypes.Recursive && TreeListView.Columns.Count != 0 && CheckStatus == CheckState.Indeterminate)
			{
				Rectangle bounds = GetBounds(ItemBoundsPortion.Icon);
				Rectangle rect = (TreeListView._Comctl32Version >= 6) ? new Rectangle(bounds.Left - 14, bounds.Top + 5, bounds.Height - 10, bounds.Height - 10) : new Rectangle(bounds.Left - 11, bounds.Top + 5, bounds.Height - 10, bounds.Height - 10);
				using (Brush brush = new LinearGradientBrush(rect, Color.Gray, Color.LightBlue, 45f, isAngleScaleable: false))
				{
					if (TreeListView.Columns[0].Width > (Level + ((!TreeListView.ShowPlusMinus) ? 1 : 2)) * SystemInformation.SmallIconSize.Width)
					{
						g.FillRectangle(brush, rect);
					}
				}
			}
		}

		private TreeListViewItemCollection GetParentsInHierarch()
		{
			TreeListViewItemCollection treeListViewItemCollection = (Parent != null) ? Parent.GetParentsInHierarch() : new TreeListViewItemCollection();
			if (Parent != null)
			{
				treeListViewItemCollection.Add(Parent);
			}
			return treeListViewItemCollection;
		}

		[DllImport("user32.dll")]
		internal static extern bool SendMessage(IntPtr hWnd, ListViewMessages msg, int wParam, ref LV_ITEM lParam);
	}
}
