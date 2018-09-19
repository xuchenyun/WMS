using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.APIs;
using System.Threading;
using System.Win32;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(ListView))]
	public class TXTreeListView : TXListView
	{
		private delegate TreeListViewItem[] ItemArrayHandler();

		private IContainer components;

		private CheckBoxesTypes _CheckBoxes = CheckBoxesTypes.None;

		private ImageList _SmallImagList = null;

		private SortOrder _Sorting = SortOrder.Ascending;

		private TreeListViewExpandMethod _ExpandMethod = TreeListViewExpandMethod.EntireItemDbleClick;

		private DateTime _LastDoubleClick;

		private DateTime _DblClickTime = DateTime.Now;

		private CustomEdit _CustomEdit;

		private TreeListViewItemCollection _Items;

		private Point _MouseScrollPosition = new Point(0, 0);

		private Color _PlusMinusLineColor = Color.DarkGray;

		private int _PlusMinusLinePattern = 0;

		private bool _HasMarquee = false;

		private bool _InEdit;

		private bool _ShowPlusMinus = true;

		private bool _UseXPHighLightStyle = true;

		private string _PathSeparator = "\\";

		private bool _Scrollable = true;

		internal TreeListViewItem _SelectionMark = null;

		internal CheckDirection CheckDirection = CheckDirection.None;

		internal EditItemInformations _EditedItem = default(EditItemInformations);

		internal EditItemInformations _LastItemClicked;

		internal bool _Updating = false;

		internal bool _SkipMouseDownEvent = false;

		internal bool FreezeCheckBoxes = false;

		private ImageList imageList1;

		internal ImageList plusMinusImageList;

		internal int _Comctl32Version;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Gets or sets a value indicating whether a scroll bar is added to the control when there is not enough room to display all items")]
		[DefaultValue(true)]
		[Browsable(true)]
		public new bool Scrollable
		{
			get
			{
				return _Scrollable;
			}
			set
			{
				_Scrollable = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Gets or sets a value indicating whether a check box appears next to each item in the control")]
		[DefaultValue(typeof(CheckBoxesTypes), "None")]
		[Browsable(true)]
		public new CheckBoxesTypes CheckBoxes
		{
			get
			{
				return _CheckBoxes;
			}
			set
			{
				if (_CheckBoxes != value)
				{
					_CheckBoxes = value;
					CheckDirection = ((value == CheckBoxesTypes.Recursive) ? CheckDirection.All : CheckDirection.None);
					base.CheckBoxes = ((value != 0) ? true : false);
					if (base.Created)
					{
						Invalidate();
					}
				}
			}
		}

		[Browsable(true)]
		[Description("Gets or sets a value indicating whether clicking an item selects all its subitems")]
		[DefaultValue(true)]
		public new bool FullRowSelect
		{
			get
			{
				return base.FullRowSelect;
			}
			set
			{
				base.FullRowSelect = value;
			}
		}

		[Browsable(false)]
		public new ImageList StateImageList
		{
			get
			{
				return base.StateImageList;
			}
			set
			{
				base.StateImageList = value;
			}
		}

		[Browsable(false)]
		public new ImageList LargeImageList
		{
			get
			{
				return base.LargeImageList;
			}
			set
			{
				base.LargeImageList = value;
			}
		}

		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Gets or sets the ImageList to use when displaying items as small icons in the control")]
		[Browsable(true)]
		public new ImageList SmallImageList
		{
			get
			{
				return _SmallImagList;
			}
			set
			{
				_SmallImagList = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(typeof(SortOrder), "Ascending")]
		[Browsable(true)]
		[Description("Get or Set the sort order")]
		public new SortOrder Sorting
		{
			get
			{
				return _Sorting;
			}
			set
			{
				if (_Sorting != value)
				{
					_Sorting = value;
					Items.SortOrderRecursively = value;
				}
			}
		}

		[DefaultValue(typeof(TreeListViewExpandMethod), "EntireItemDbleClick")]
		[Description("Get or Set the expand method")]
		[Browsable(true)]
		public TreeListViewExpandMethod ExpandMethod
		{
			get
			{
				return _ExpandMethod;
			}
			set
			{
				_ExpandMethod = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new View View
		{
			get
			{
				return base.View;
			}
			set
			{
				base.View = View.Details;
			}
		}

		[Browsable(false)]
		[Description("Items of the TreeListView")]
		public new TreeListViewItemCollection Items
		{
			get
			{
				return _Items;
			}
		}

		[Browsable(false)]
		public new SelectedTreeListViewItemCollection SelectedItems
		{
			get
			{
				return new SelectedTreeListViewItemCollection(this);
			}
		}

		[Browsable(false)]
		public new TreeListViewItem[] CheckedItems
		{
			get
			{
				return (TreeListViewItem[])Invoke(new ItemArrayHandler(GetCheckedItems));
			}
		}

		[Browsable(false)]
		public new TreeListViewItem FocusedItem
		{
			get
			{
				return (TreeListViewItem)base.FocusedItem;
			}
		}

		[Browsable(false)]
		public bool HasMarquee
		{
			get
			{
				return _HasMarquee;
			}
		}

		[Browsable(false)]
		public EditItemInformations EditedItem
		{
			get
			{
				return _EditedItem;
			}
		}

		[Browsable(false)]
		public bool InEdit
		{
			get
			{
				return _InEdit;
			}
		}

		[Browsable(false)]
		public int ItemsCount
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

		[Browsable(false)]
		public ITreeListViewItemComparer Comparer
		{
			get
			{
				return Items.Comparer;
			}
			set
			{
				Items.Comparer = value;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		[Description("Gets or sets a value indicating whether plus-sign (+) and minus-sign (-) buttons are displayed next to TreeListView that contain child TreeListViews")]
		public bool ShowPlusMinus
		{
			get
			{
				return _ShowPlusMinus;
			}
			set
			{
				if (_ShowPlusMinus != value)
				{
					_ShowPlusMinus = value;
					if (base.Created)
					{
						Invoke(new MethodInvoker(VisChanged));
					}
				}
			}
		}

		[Description("Gets or Sets the color of the lines if ShowPlusMinus property is enabled")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(typeof(Color), "DarkGray")]
		[Browsable(true)]
		public Color PlusMinusLineColor
		{
			get
			{
				return _PlusMinusLineColor;
			}
			set
			{
				_PlusMinusLineColor = value;
				if (base.Created)
				{
					Invalidate();
				}
			}
		}

		[DefaultValue(0)]
		[Description("获取或者自定义线的样式，为0表示视线，否则为虚线的空白间隔，以像素为单位")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		public int PlusMinusLinePattern
		{
			get
			{
				return _PlusMinusLinePattern;
			}
			set
			{
				_PlusMinusLinePattern = ((value > 0) ? value : 0);
				if (base.Created)
				{
					Invalidate();
				}
			}
		}

		[Description("Gets or Sets whether the control draw XP-Style highlight color")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(true)]
		[Browsable(true)]
		public bool UseXPHighlightStyle
		{
			get
			{
				return _UseXPHighLightStyle;
			}
			set
			{
				_UseXPHighLightStyle = value;
				if (base.Created)
				{
					Invalidate();
				}
			}
		}

		[Browsable(true)]
		[Description("Gets or sets the delimiter string that the TreeListViewItem path uses")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue("\\")]
		public string PathSeparator
		{
			get
			{
				return _PathSeparator;
			}
			set
			{
				_PathSeparator = value;
			}
		}

		[Description("Occurs when the label for an item is edited by the user.")]
		public new event TreeListViewLabelEditEventHandler AfterLabelEdit;

		[Description("Occurs when the user starts editing the label of an item.")]
		[Browsable(true)]
		public new event TreeListViewBeforeLabelEditEventHandler BeforeLabelEdit;

		[Description("Occurs before the tree node is collapsed")]
		public event TreeListViewCancelEventHandler BeforeExpand;

		[Description("Occurs before the tree node is collapsed")]
		public event TreeListViewCancelEventHandler BeforeCollapse;

		[Description("Occurs after the tree node is expanded")]
		public event TreeListViewEventHandler AfterExpand;

		[Description("Occurs after the tree node is collapsed")]
		public event TreeListViewEventHandler AfterCollapse;

		public TXTreeListView()
		{
			InitializeComponent();
			if (!base.IsHandleCreated)
			{
				CreateHandle();
			}
			_Items = new TreeListViewItemCollection(this);
			_Items.SortOrder = _Sorting;
			_Comctl32Version = NativeMethods.GetMajorVersion();
			int num = NativeMethods.SendMessage(base.Handle, 4151, 0, 0);
			num |= 0x4400;
			NativeMethods.SendMessage(base.Handle, 4150, 0, num);
		}

		protected virtual void OnAfterLabelEdit(TreeListViewLabelEditEventArgs e)
		{
			if (this.AfterLabelEdit != null)
			{
				this.AfterLabelEdit(this, e);
			}
		}

		protected override void OnAfterLabelEdit(LabelEditEventArgs e)
		{
			throw new Exception("Please use OnAfterLabelEdit(TreeListViewLabelEditEventArgs e)");
		}

		protected virtual void OnBeforeLabelEdit(TreeListViewBeforeLabelEditEventArgs e)
		{
			if (this.BeforeLabelEdit != null)
			{
				this.BeforeLabelEdit(this, e);
			}
		}

		protected override void OnBeforeLabelEdit(LabelEditEventArgs e)
		{
			throw new Exception("Please use OnBeforeLabelEdit(TreeListViewLabelEditEventArgs e)");
		}

		protected virtual void OnBeforeExpand(TreeListViewCancelEventArgs e)
		{
			if (this.BeforeExpand != null)
			{
				this.BeforeExpand(this, e);
			}
		}

		protected virtual void OnAfterExpand(TreeListViewEventArgs e)
		{
			if (this.AfterExpand != null)
			{
				this.AfterExpand(this, e);
			}
		}

		protected virtual void OnBeforeCollapse(TreeListViewCancelEventArgs e)
		{
			if (this.BeforeCollapse != null)
			{
				this.BeforeCollapse(this, e);
			}
		}

		protected virtual void OnAfterCollapse(TreeListViewEventArgs e)
		{
			if (this.AfterCollapse != null)
			{
				this.AfterCollapse(this, e);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (!_SkipMouseDownEvent)
			{
				base.OnMouseDown(e);
			}
		}

		internal void RaiseBeforeExpand(TreeListViewCancelEventArgs e)
		{
			OnBeforeExpand(e);
		}

		internal void RaiseBeforeCollapse(TreeListViewCancelEventArgs e)
		{
			OnBeforeCollapse(e);
		}

		internal void RaiseAfterExpand(TreeListViewEventArgs e)
		{
			OnAfterExpand(e);
		}

		internal void RaiseAfterCollapse(TreeListViewEventArgs e)
		{
			OnAfterCollapse(e);
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			Invalidate(invalidateChildren: true);
		}

		protected override void WndProc(ref Message m)
		{
			TreeListViewItem treeListViewItem = null;
			switch (m.Msg)
			{
			case 78:
			case 8270:
			{
				NMHDR nMHDR = (NMHDR)m.GetLParam(typeof(NMHDR));
				NMHEADER nMHEADER = (NMHEADER)m.GetLParam(typeof(NMHEADER));
				switch (nMHDR.code)
				{
				case -156:
					if ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.Left)
					{
						m.Result = (IntPtr)1;
					}
					else
					{
						_HasMarquee = true;
					}
					break;
				case -100:
				{
					NMLISTVIEW nMLISTVIEW = (NMLISTVIEW)m.GetLParam(typeof(NMLISTVIEW));
					if (nMLISTVIEW.iItem >= 0 && (treeListViewItem = GetTreeListViewItemFromIndex(nMLISTVIEW.iItem)) != null)
					{
						bool flag2 = false;
						if (nMLISTVIEW.Select)
						{
							if (_SelectionMark == null)
							{
								_SelectionMark = treeListViewItem;
							}
							else if (!_SelectionMark.Visible)
							{
								_SelectionMark = treeListViewItem;
							}
							if (HasMarquee)
							{
								treeListViewItem.Focused = true;
							}
						}
						else if (nMLISTVIEW.UnSelect && HasMarquee)
						{
							if (treeListViewItem.NextVisibleItem != null && treeListViewItem.NextVisibleItem.Selected)
							{
								treeListViewItem.NextVisibleItem.Focused = true;
							}
							if (treeListViewItem.PrevVisibleItem != null && treeListViewItem.PrevVisibleItem.Selected)
							{
								treeListViewItem.PrevVisibleItem.Focused = true;
							}
						}
						if (_DblClickTime.AddMilliseconds(500.0).CompareTo(DateTime.Now) > 0 && (nMLISTVIEW.Select || nMLISTVIEW.Focus) && FocusedItem != treeListViewItem)
						{
							flag2 = true;
						}
						if ((nMLISTVIEW.uNewState & 2) == 2 && base.MultiSelect && base.SelectedIndices.Count > 0 && GetTreeListViewItemFromIndex(nMLISTVIEW.iItem).Parent != SelectedItems[0].Parent)
						{
							flag2 = true;
						}
						bool flag3 = (nMLISTVIEW.uChanged & 8) == 8;
						bool flag4 = (Control.ModifierKeys & Keys.Control) == Keys.Control;
						bool flag5 = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
						if ((nMLISTVIEW.Check || nMLISTVIEW.UnCheck) && (HasMarquee || flag4 || flag5))
						{
							flag2 = true;
						}
						if (flag2)
						{
							m.Result = (IntPtr)1;
							return;
						}
					}
					break;
				}
				case -175:
					if (_LastDoubleClick.AddMilliseconds(450.0) > DateTime.Now)
					{
						Message m2 = Message.Create(base.Handle, 4275, IntPtr.Zero, IntPtr.Zero);
						WndProc(ref m2);
						m.Result = (IntPtr)1;
					}
					else
					{
						treeListViewItem = _LastItemClicked.Item;
						treeListViewItem.EnsureVisible();
						while (treeListViewItem.SubItems.Count - 1 < _LastItemClicked.ColumnIndex)
						{
							treeListViewItem.SubItems.Add("");
						}
						TreeListViewBeforeLabelEditEventArgs treeListViewBeforeLabelEditEventArgs = new TreeListViewBeforeLabelEditEventArgs(FocusedItem, _LastItemClicked.ColumnIndex, treeListViewItem.SubItems[_LastItemClicked.ColumnIndex].Text);
						OnBeforeLabelEdit(treeListViewBeforeLabelEditEventArgs);
						if (treeListViewBeforeLabelEditEventArgs.Cancel)
						{
							Message m2 = Message.Create(base.Handle, 4275, IntPtr.Zero, IntPtr.Zero);
							WndProc(ref m2);
							m.Result = (IntPtr)1;
						}
						else
						{
							_InEdit = true;
							Message m3 = Message.Create(base.Handle, 4120, IntPtr.Zero, IntPtr.Zero);
							WndProc(ref m3);
							IntPtr result = m3.Result;
							_CustomEdit = new CustomEdit(result, this, treeListViewBeforeLabelEditEventArgs.Editor);
							_EditedItem = new EditItemInformations(FocusedItem, treeListViewBeforeLabelEditEventArgs.ColumnIndex, FocusedItem.SubItems[treeListViewBeforeLabelEditEventArgs.ColumnIndex].Text);
							m.Result = IntPtr.Zero;
						}
					}
					return;
				case -176:
					if (_CustomEdit != null)
					{
						_CustomEdit.HideEditControl();
					}
					_CustomEdit = null;
					_InEdit = false;
					_EditedItem = default(EditItemInformations);
					m.Result = IntPtr.Zero;
					return;
				case -12:
					base.WndProc(ref m);
					return;
				case -180:
					_Updating = true;
					break;
				case -181:
					_Updating = false;
					break;
				case -310:
					nMHEADER = (NMHEADER)m.GetLParam(typeof(NMHEADER));
					if (nMHEADER.iItem == 0)
					{
						m.Result = (IntPtr)1;
						return;
					}
					break;
				case -311:
				{
					nMHEADER = (NMHEADER)m.GetLParam(typeof(NMHEADER));
					IntPtr hWnd = (IntPtr)NativeMethods.SendMessage(base.Handle, 4127, IntPtr.Zero, IntPtr.Zero);
					System.Win32.POINTAPI point = new System.Win32.POINTAPI(Control.MousePosition);
					NativeMethods.ScreenToClient(hWnd, ref point);
					RECT lParam = default(RECT);
					SendMessage(hWnd, 4615, 0, ref lParam);
					int num = lParam.right - lParam.left;
					if (point.X <= lParam.left + num / 2 || nMHEADER.iItem == 0)
					{
						m.Result = (IntPtr)1;
						return;
					}
					break;
				}
				case -327:
					Invalidate();
					break;
				}
				break;
			}
			case 513:
				if (base.Columns.Count != 0)
				{
					int num2 = GetColumnAt(Control.MousePosition);
					if (num2 == -1)
					{
						num2 = 0;
					}
					treeListViewItem = GetItemAtFullRow(PointToClient(Control.MousePosition));
					_LastItemClicked = new EditItemInformations(treeListViewItem, num2, "");
					if (_SelectionMark == null || !_SelectionMark.Visible)
					{
						_SelectionMark = treeListViewItem;
					}
					if (((int)m.WParam & 4) != 4 && (((int)m.WParam & 8) != 8 || treeListViewItem.Parent == _SelectionMark.Parent))
					{
						_SelectionMark = treeListViewItem;
					}
					LVHITTESTINFO lParam2 = default(LVHITTESTINFO);
					lParam2.pt = new POINTAPI(PointToClient(Control.MousePosition));
					SendMessage(base.Handle, 4114, 0, ref lParam2);
					if (treeListViewItem != null)
					{
						if (treeListViewItem.GetBounds(TreeListViewItemBoundsPortion.PlusMinus).Contains(PointToClient(Control.MousePosition)) && ShowPlusMinus && treeListViewItem.Items.Count > 0 && base.Columns[0].Width > (treeListViewItem.Level + 1) * SystemInformation.SmallIconSize.Width)
						{
							Focus();
							if (treeListViewItem.IsExpanded)
							{
								treeListViewItem.Collapse();
							}
							else
							{
								treeListViewItem.Expand();
							}
							OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, PointToClient(Control.MousePosition).X, PointToClient(Control.MousePosition).Y, 0));
							return;
						}
						if (base.SelectedIndices.Count > 0 && (((int)m.WParam & 4) == 4 || ((int)m.WParam & 8) == 8) && base.MultiSelect && _SelectionMark.Parent == treeListViewItem.Parent && ((int)m.WParam & 4) == 4)
						{
							_Updating = true;
							SetSelectedItemsRange(treeListViewItem, _SelectionMark);
							m.WParam = (IntPtr)8L;
							base.WndProc(ref m);
							treeListViewItem.Selected = true;
							_Updating = false;
							DrawSelectedItemsFocusCues();
							return;
						}
					}
				}
				break;
			case 515:
				_LastDoubleClick = DateTime.Now;
				if (FocusedItem != null)
				{
					treeListViewItem = FocusedItem;
					bool flag = false;
					switch (ExpandMethod)
					{
					case TreeListViewExpandMethod.IconDbleClick:
						if (treeListViewItem.GetBounds(ItemBoundsPortion.Icon).Contains(PointToClient(Control.MousePosition)))
						{
							flag = true;
						}
						break;
					case TreeListViewExpandMethod.ItemOnlyDbleClick:
						if (treeListViewItem.GetBounds(ItemBoundsPortion.ItemOnly).Contains(PointToClient(Control.MousePosition)))
						{
							flag = true;
						}
						break;
					case TreeListViewExpandMethod.EntireItemDbleClick:
						if (treeListViewItem.GetBounds(ItemBoundsPortion.Entire).Contains(PointToClient(Control.MousePosition)))
						{
							flag = true;
						}
						break;
					}
					if (flag)
					{
						_DblClickTime = DateTime.Now;
						Cursor = Cursors.WaitCursor;
						BeginUpdate();
						if (treeListViewItem.IsExpanded)
						{
							treeListViewItem.Collapse();
						}
						else
						{
							treeListViewItem.Expand();
						}
						EndUpdate();
						Cursor = Cursors.Default;
					}
				}
				OnDoubleClick(new EventArgs());
				return;
			case 512:
				if ((Control.MouseButtons & MouseButtons.Left) != MouseButtons.Left && HasMarquee)
				{
					_HasMarquee = false;
				}
				break;
			case 258:
			case 265:
				CharPressed((char)(int)m.WParam);
				return;
			case 256:
				OnKeyDown(new KeyEventArgs((Keys)(int)m.WParam));
				return;
			case 15:
				if (InEdit && EditedItem.Item != null)
				{
					System.Win32.RECT rcInvalidated = new System.Win32.RECT(EditedItem.Item.GetBounds(ItemBoundsPortion.Entire));
					NativeMethods.ValidateRect(base.Handle, ref rcInvalidated);
				}
				base.WndProc(ref m);
				return;
			case 276:
			case 277:
			case 4115:
				if (!Scrollable)
				{
					m.Result = (IntPtr)0;
					return;
				}
				break;
			}
			base.WndProc(ref m);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			if (FocusedItem == null)
			{
				if (base.Items.Count > 0 && (keyCode == Keys.Down || keyCode == Keys.Up || keyCode == Keys.Left || keyCode == Keys.Right))
				{
					base.Items[0].Selected = true;
					base.Items[0].Focused = true;
					base.Items[0].EnsureVisible();
				}
				base.OnKeyDown(e);
			}
			else
			{
				TreeListViewItem focusedItem = FocusedItem;
				switch (keyCode)
				{
				case Keys.Down:
					if (focusedItem.NextVisibleItem != null)
					{
						TreeListViewItem nextVisibleItem = focusedItem.NextVisibleItem;
						if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && base.MultiSelect)
						{
							if (focusedItem.Parent != nextVisibleItem.Parent && focusedItem.Selected)
							{
								while ((nextVisibleItem = nextVisibleItem.NextVisibleItem) != null && nextVisibleItem.Parent != focusedItem.Parent)
								{
								}
							}
							if (nextVisibleItem != null)
							{
								SetSelectedItemsRange(_SelectionMark, nextVisibleItem);
							}
							else
							{
								nextVisibleItem = focusedItem.NextVisibleItem;
							}
						}
						else if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
						{
							SetSelectedItemsRange(nextVisibleItem, nextVisibleItem);
							_SelectionMark = nextVisibleItem;
						}
						nextVisibleItem.Focused = true;
						nextVisibleItem.EnsureVisible();
					}
					break;
				case Keys.Up:
					if (focusedItem.PrevVisibleItem != null)
					{
						TreeListViewItem prevVisibleItem = focusedItem.PrevVisibleItem;
						if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift && base.MultiSelect)
						{
							if (focusedItem.Parent != prevVisibleItem.Parent && focusedItem.Selected)
							{
								while ((prevVisibleItem = prevVisibleItem.PrevVisibleItem) != null && prevVisibleItem.Parent != focusedItem.Parent)
								{
								}
							}
							if (prevVisibleItem != null)
							{
								SetSelectedItemsRange(_SelectionMark, prevVisibleItem);
							}
							else
							{
								prevVisibleItem = focusedItem.PrevVisibleItem;
							}
						}
						else if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
						{
							SetSelectedItemsRange(prevVisibleItem, prevVisibleItem);
							_SelectionMark = prevVisibleItem;
						}
						prevVisibleItem.Focused = true;
						prevVisibleItem.EnsureVisible();
					}
					break;
				case Keys.Return:
					base.SelectedItems.Clear();
					if (focusedItem.IsExpanded)
					{
						focusedItem.Collapse();
					}
					else
					{
						focusedItem.Expand();
					}
					focusedItem.Selected = true;
					focusedItem.EnsureVisible();
					break;
				case Keys.Left:
					if (focusedItem.IsExpanded)
					{
						base.SelectedItems.Clear();
						focusedItem.Selected = true;
						focusedItem.Collapse();
						focusedItem.EnsureVisible();
					}
					else if (focusedItem.Parent != null)
					{
						base.SelectedItems.Clear();
						focusedItem.Parent.Selected = true;
						focusedItem.Parent.Focused = true;
						focusedItem.Parent.EnsureVisible();
					}
					break;
				case Keys.Right:
					if (focusedItem.Items.Count != 0)
					{
						if (!focusedItem.IsExpanded)
						{
							base.SelectedItems.Clear();
							focusedItem.Selected = true;
							focusedItem.Expand();
							focusedItem.EnsureVisible();
						}
						else
						{
							base.SelectedItems.Clear();
							focusedItem.Items[focusedItem.Items.Count - 1].Selected = true;
							focusedItem.Items[focusedItem.Items.Count - 1].Focused = true;
							focusedItem.Items[focusedItem.Items.Count - 1].EnsureVisible();
						}
					}
					break;
				case Keys.Space:
					if (base.CheckBoxes)
					{
						focusedItem.Checked = !focusedItem.Checked;
					}
					break;
				}
				base.OnKeyDown(e);
			}
		}

		private void CharPressed(char character)
		{
			string text = character.ToString().ToUpper();
			if (FocusedItem != null)
			{
				TreeListViewItem focusedItem = FocusedItem;
				base.SelectedItems.Clear();
				focusedItem.Selected = true;
				if ((text.CompareTo("A") >= 0 && text.CompareTo("Z") <= 0) || text == " ")
				{
					TreeListViewItemCollection treeListViewItemCollection = (focusedItem.Parent == null) ? Items : focusedItem.Parent.Items;
					bool flag = false;
					for (int i = treeListViewItemCollection.GetIndexOf(focusedItem) + 1; i < treeListViewItemCollection.Count; i++)
					{
						if (treeListViewItemCollection[i].Text.ToUpper().StartsWith(text))
						{
							treeListViewItemCollection[i].Selected = true;
							treeListViewItemCollection[i].Focused = true;
							treeListViewItemCollection[i].EnsureVisible();
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						int i = 0;
						while (true)
						{
							if (i >= treeListViewItemCollection.GetIndexOf(focusedItem))
							{
								return;
							}
							if (treeListViewItemCollection[i].Text.ToUpper().StartsWith(text))
							{
								break;
							}
							i++;
						}
						treeListViewItemCollection[i].Selected = true;
						treeListViewItemCollection[i].Focused = true;
						treeListViewItemCollection[i].EnsureVisible();
						flag = true;
					}
				}
			}
		}

		private unsafe void CustomDraw(ref Message m)
		{
			NMLVCUSTOMDRAW* ptr = (NMLVCUSTOMDRAW*)m.LParam.ToPointer();
			switch (ptr->nmcd.dwDrawStage)
			{
			case 1:
				m.Result = (IntPtr)32L;
				break;
			case 65537:
				m.Result = (IntPtr)32L;
				break;
			case 196609:
			{
				int dwItemSpec = (int)ptr->nmcd.dwItemSpec;
				int iSubItem = ptr->iSubItem;
				bool selected = base.Items[dwItemSpec].Selected;
				TreeListViewItem treeListViewItemFromIndex = GetTreeListViewItemFromIndex(dwItemSpec);
				if (selected && _UseXPHighLightStyle)
				{
					Color color = Focused ? ColorUtil.VSNetSelectionColor : ColorUtil.VSNetSelectionUnfocusedColor;
					if (base.HideSelection && !Focused)
					{
						color = base.BackColor;
					}
					if (FullRowSelect || iSubItem == 0)
					{
						ptr->clrTextBk = (int)ColorUtil.RGB(color.R, color.G, color.B);
					}
					ptr->nmcd.uItemState &= 4294967294u;
					if (iSubItem == 0)
					{
						treeListViewItemFromIndex.DrawFocusCues();
					}
				}
				if (iSubItem == 0)
				{
					treeListViewItemFromIndex.DrawIntermediateState();
					treeListViewItemFromIndex.DrawPlusMinusLines();
					treeListViewItemFromIndex.DrawPlusMinus();
				}
				m.Result = (IntPtr)2L;
				break;
			}
			}
		}

		internal void DrawIntermediateStateItems()
		{
			if (CheckBoxes == CheckBoxesTypes.Recursive && !_Updating)
			{
				TreeListViewItemCollection visibleItems = GetVisibleItems();
				using (Graphics g = Graphics.FromHwnd(base.Handle))
				{
					foreach (TreeListViewItem item in visibleItems)
					{
						item.DrawIntermediateState(g);
					}
				}
			}
		}

		internal void DrawSelectedItemsFocusCues()
		{
			if (!_Updating && (!base.HideSelection || Focused) && _UseXPHighLightStyle)
			{
				SelectedTreeListViewItemCollection selectedItems = SelectedItems;
				if (FocusedItem != null && Focused)
				{
					FocusedItem.DrawFocusCues();
				}
				foreach (TreeListViewItem item in selectedItems)
				{
					item.DrawFocusCues();
				}
			}
		}

		internal void DrawPlusMinusItems()
		{
			if (!_Updating)
			{
				using (Graphics g = Graphics.FromHwnd(base.Handle))
				{
					TreeListViewItemCollection visibleItems = GetVisibleItems();
					foreach (TreeListViewItem item in visibleItems)
					{
						item.DrawPlusMinus(g);
					}
				}
			}
		}

		internal void DrawPlusMinusItemsLines()
		{
			if (!_Updating)
			{
				using (Graphics g = Graphics.FromHwnd(base.Handle))
				{
					TreeListViewItemCollection visibleItems = GetVisibleItems();
					foreach (TreeListViewItem item in visibleItems)
					{
						item.DrawPlusMinusLines(g);
					}
				}
			}
		}

		protected override void OnDrawFirstSubItem(DrawListViewSubItemEventArgs e, Graphics g)
		{
			if (e.ColumnIndex <= 0)
			{
				GDIHelper.InitializeGraphics(g);
				TreeListViewItem treeListViewItem = e.Item as TreeListViewItem;
				int num = 18;
				Rectangle bounds = e.Bounds;
				Image image = null;
				Size empty = Size.Empty;
				Rectangle rectangle = new Rectangle(bounds.X, bounds.Y, 0, 0);
				Size size = new Size(12, 12);
				int num2 = 2;
				Rectangle rect = new Rectangle(new Point(num2 * 2, bounds.Top + (bounds.Height - size.Height) / 2), size);
				rect.X += treeListViewItem.Level * num;
				Rectangle rect2 = rectangle;
				Rectangle bounds2 = bounds;
				bounds2.X = rect.Right;
				if (treeListViewItem.Parent != null)
				{
					Point point = new Point(rect.X + size.Width / 2 - num, treeListViewItem.Parent.Bounds.Bottom - num2);
					Point point2 = new Point((treeListViewItem.Items.Count <= 0) ? (rect.X + size.Width) : (rect.X - num2), bounds.Top + bounds.Height / 2);
					Point point3 = new Point(point.X, point2.Y);
					Color color = Color.FromArgb(46, 117, 35);
					using (Pen pen = new Pen(_PlusMinusLineColor, 1f))
					{
						if (_PlusMinusLinePattern > 0)
						{
							pen.DashStyle = DashStyle.Custom;
							pen.DashPattern = new float[2]
							{
								3f,
								(float)_PlusMinusLinePattern
							};
						}
						g.DrawLines(pen, new Point[3]
						{
							point,
							point3,
							point2
						});
					}
					rect2.X += num + num2;
					bounds2.X += num + num2;
					bounds2.Width -= num2 + num2 * 2;
				}
				if (treeListViewItem.Items.Count > 0)
				{
					GDIHelper.DrawImage(g, rect, treeListViewItem.IsExpanded ? Resources.Collapse1 : Resources.Expand1, size);
					rect2.X += rect.Width + num2;
					bounds2.X += rect.Width + num2;
					bounds2.Width -= rect.Width + num2;
				}
				if (e.Item.ListView.CheckBoxes)
				{
					rectangle.X += num2 * 2 + rect.Right;
					rectangle.Y = bounds.Top + (bounds.Height - base.CheckBoxSize.Height) / 2;
					rectangle.Width = base.CheckBoxSize.Width;
					rectangle.Height = base.CheckBoxSize.Height;
					rect2.X = rectangle.Right;
					bounds2.X = rectangle.Right;
					bounds2.Width -= base.CheckBoxSize.Width - num2 * 2;
					GDIHelper.DrawCheckBox(g, new RoundRectangle(rectangle, 1));
					switch (treeListViewItem.CheckStatus)
					{
					case CheckState.Checked:
						GDIHelper.DrawCheckedStateByImage(g, rectangle);
						break;
					case CheckState.Indeterminate:
					{
						Rectangle rect3 = rectangle;
						rect3.Inflate(-3, -3);
						Color color2 = Color.FromArgb(46, 117, 35);
						GDIHelper.FillRectangle(g, new RoundRectangle(rect3, 1), color2);
						break;
					}
					}
				}
				if (e.Item.ImageList != null && e.Item.ImageIndex >= 0)
				{
					image = e.Item.ImageList.Images[e.Item.ImageIndex];
					empty = e.Item.ImageList.ImageSize;
					rect2.X += num2 * 3;
					rect2.Y = bounds.Y + num2;
					int num5 = rect2.Height = (rect2.Width = bounds.Height - num2 * 2);
					bounds2.X = rect2.Right;
					bounds2.Width -= num5 - num2 * 2;
					GDIHelper.DrawImage(g, rect2, image, empty);
				}
				bounds2.X += num2;
				bounds2.Width -= num2 * 2;
				TextFormatFlags formatFlags = GetFormatFlags(e.Header.TextAlign);
				Color foreColor = ((e.ItemState & System.Windows.Forms.ListViewItemStates.Selected) == System.Windows.Forms.ListViewItemStates.Selected) ? Color.White : e.SubItem.ForeColor;
				TextRenderer.DrawText(g, e.SubItem.Text, Font, bounds2, foreColor, formatFlags);
			}
		}

		private void SetSelectedItemsRange(TreeListViewItem item1, TreeListViewItem item2)
		{
			if (base.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			if (item1 != null && item2 != null && item1.Visible && item2.Visible && item1.Parent == item2.Parent)
			{
				TreeListViewItemCollection container = item1.Container;
				int indexOf = container.GetIndexOf(item1);
				int indexOf2 = container.GetIndexOf(item2);
				ListViewItem[] array = new ListViewItem[base.SelectedItems.Count];
				base.SelectedItems.CopyTo(array, 0);
				ListViewItem[] array2 = array;
				foreach (ListViewItem listViewItem in array2)
				{
					int indexOf3 = container.GetIndexOf((TreeListViewItem)listViewItem);
					if (indexOf3 < Math.Min(indexOf, indexOf2) || indexOf3 > Math.Max(indexOf, indexOf2))
					{
						listViewItem.Selected = false;
					}
				}
				for (int j = Math.Min(indexOf, indexOf2); j <= Math.Max(indexOf, indexOf2); j++)
				{
					if (!container[j].Selected)
					{
						container[j].Selected = true;
					}
				}
			}
		}

		public void ExpandAll()
		{
			if (base.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			BeginUpdate();
			foreach (TreeListViewItem item in Items)
			{
				item.ExpandAllInternal();
			}
			EndUpdate();
		}

		public void CollapseAll()
		{
			if (base.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			BeginUpdate();
			foreach (TreeListViewItem item in Items)
			{
				item.CollapseAllInternal();
			}
			EndUpdate();
		}

		internal void ExitEdit(bool cancel, string text)
		{
			if (InEdit && EditedItem.Item != null)
			{
				Point point = (EditedItem.Item != null) ? EditedItem.Item.GetBounds(TreeListViewItemBoundsPortion.Icon).Location : new Point(0, 0);
				point.Offset(1, 1);
				EditItemInformations editedItem = EditedItem;
				Message m = Message.Create(base.Handle, 513, (IntPtr)1, (IntPtr)((point.Y << 16) + point.X));
				_SkipMouseDownEvent = true;
				base.WndProc(ref m);
				_SkipMouseDownEvent = false;
				if (!cancel)
				{
					TreeListViewLabelEditEventArgs treeListViewLabelEditEventArgs = new TreeListViewLabelEditEventArgs(EditedItem.Item, EditedItem.ColumnIndex, text);
					OnAfterLabelEdit(treeListViewLabelEditEventArgs);
					if (!treeListViewLabelEditEventArgs.Cancel)
					{
						editedItem.Item.SubItems[editedItem.ColumnIndex].Text = text;
					}
				}
				_InEdit = false;
				_EditedItem = new EditItemInformations(null, 0, "");
			}
		}

		public Rectangle GetItemRect(int index, TreeListViewItemBoundsPortion portion)
		{
			if (index >= base.Items.Count || index < 0)
			{
				throw new Exception("Out of range exception");
			}
			TreeListViewItem treeListViewItem = (TreeListViewItem)base.Items[index];
			return treeListViewItem.GetBounds(portion);
		}

		public void KillFocus()
		{
			NativeMethods.SendMessage(base.Handle, 8, IntPtr.Zero, IntPtr.Zero);
		}

		protected override void OnItemCheck(ItemCheckEventArgs e)
		{
			base.OnItemCheck(e);
			ListViewItemCollection items = base.Items;
			if (e.Index < base.Items.Count && e.Index >= 0)
			{
				TreeListViewItem treeListViewItem = (TreeListViewItem)base.Items[e.Index];
				if (treeListViewItem != null && CheckDirection != 0)
				{
					CheckDirection checkDirection = CheckDirection;
					TreeListViewItem parent = treeListViewItem.Parent;
					if (parent != null && (checkDirection & CheckDirection.Upwards) == CheckDirection.Upwards)
					{
						CheckDirection = CheckDirection.Upwards;
						while (parent != null)
						{
							if (e.NewValue == CheckState.Checked)
							{
								if (!parent.Checked)
								{
									parent.Checked = true;
									break;
								}
								bool flag = true;
								foreach (TreeListViewItem item in parent.Items)
								{
									if (item != treeListViewItem && !item.Checked)
									{
										flag = false;
										break;
									}
								}
								if (flag)
								{
									parent.Redraw();
								}
							}
							else
							{
								bool flag2 = true;
								foreach (TreeListViewItem item2 in parent.Items)
								{
									if (item2 != treeListViewItem && item2.Checked)
									{
										flag2 = false;
										break;
									}
								}
								if (flag2 && parent.Checked)
								{
									parent.Checked = false;
									break;
								}
							}
							parent = parent.Parent;
						}
					}
					if ((checkDirection & CheckDirection.Downwards) == CheckDirection.Downwards)
					{
						CheckDirection = CheckDirection.Downwards;
						foreach (TreeListViewItem item3 in treeListViewItem.Items)
						{
							item3.Checked = (e.NewValue == CheckState.Checked);
						}
					}
					CheckDirection = checkDirection;
				}
			}
		}

		protected override void OnColumnClick(ColumnClickEventArgs e)
		{
			base.OnColumnClick(e);
			Cursor = Cursors.WaitCursor;
			ListViewItem[] array = new ListViewItem[base.SelectedItems.Count];
			base.SelectedItems.CopyTo(array, 0);
			CheckDirection checkDirection = CheckDirection;
			CheckDirection = CheckDirection.None;
			BeginUpdate();
			if (Comparer.Column == e.Column)
			{
				Sorting = ((Sorting != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
			}
			else
			{
				Comparer.Column = e.Column;
				Items.SortOrderRecursivelyWithoutSort = SortOrder.Ascending;
				try
				{
					Items.Sort(recursively: true);
				}
				catch
				{
				}
			}
			if (FocusedItem != null)
			{
				FocusedItem.EnsureVisible();
			}
			ListViewItem[] array2 = array;
			foreach (ListViewItem listViewItem in array2)
			{
				if (listViewItem.Index > -1)
				{
					listViewItem.Selected = true;
				}
			}
			EndUpdate();
			CheckDirection = checkDirection;
			Cursor = Cursors.Default;
			Invalidate(new Rectangle(Point.Empty, new Size(base.Width, 20)), invalidateChildren: true);
		}

		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
		{
			base.OnDrawColumnHeader(e);
			if (Comparer.Column == e.ColumnIndex)
			{
				Rectangle bounds = e.Bounds;
				int num = 3;
				Size arrowSize = new Size(8, 6);
				Rectangle rect = new Rectangle(bounds.Right - num - arrowSize.Width, bounds.Y + (bounds.Height - arrowSize.Height) / 2, arrowSize.Width, arrowSize.Height);
				Graphics graphics = e.Graphics;
				GDIHelper.InitializeGraphics(graphics);
				Color c = Color.FromArgb(46, 117, 35);
				switch (Sorting)
				{
				case SortOrder.Ascending:
					GDIHelper.DrawArrow(graphics, System.Windows.Forms.ArrowDirection.Up, rect, arrowSize, 1.5f, c);
					break;
				case SortOrder.Descending:
					GDIHelper.DrawArrow(graphics, System.Windows.Forms.ArrowDirection.Down, rect, arrowSize, 1.5f, c);
					break;
				}
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (base.SmallImageList != _SmallImagList)
			{
				base.SmallImageList = _SmallImagList;
			}
			VisChanged();
		}

		internal void VisChanged()
		{
			if (base.Visible)
			{
				BeginUpdate();
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
				if (FocusedItem != null)
				{
					FocusedItem.EnsureVisible();
				}
				EndUpdate();
			}
		}

		public TreeListViewItem GetItemAt(Point p)
		{
			return GetItemAt(p.X, p.Y);
		}

		public TreeListViewItem GetItemAtFullRow(Point p)
		{
			if (FullRowSelect)
			{
				return GetItemAt(p);
			}
			TreeListViewItemCollection visibleItems = GetVisibleItems();
			foreach (TreeListViewItem item in visibleItems)
			{
				if (item.GetBounds(TreeListViewItemBoundsPortion.Entire).Contains(p))
				{
					return item;
				}
			}
			return null;
		}

		public new TreeListViewItem GetItemAt(int x, int y)
		{
			return (TreeListViewItem)base.GetItemAt(x, y);
		}

		public TreeListViewItem GetTreeListViewItemFromIndex(int index)
		{
			if (base.Items.Count < index + 1)
			{
				return null;
			}
			return (TreeListViewItem)base.Items[index];
		}

		public new void Sort()
		{
			if (base.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			Items.Sort(recursively: true);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		public new void BeginUpdate()
		{
			_Updating = true;
			base.BeginUpdate();
		}

		public new void EndUpdate()
		{
			_Updating = false;
			base.EndUpdate();
		}

		public int GetColumnIndex(int columnOrder)
		{
			if (columnOrder < 0 || columnOrder > base.Columns.Count - 1)
			{
				return -1;
			}
			return NativeMethods.SendMessage(base.Handle, 4623, columnOrder, 0);
		}

		public int GetColumnOrder(int columnIndex)
		{
			if (base.Columns.Count == 0)
			{
				return -1;
			}
			if (columnIndex < 0 || columnIndex > base.Columns.Count - 1)
			{
				return -1;
			}
			IntPtr[] array = new IntPtr[base.Columns.Count];
			SendMessage(base.Handle, 4155, (IntPtr)base.Columns.Count, ref array[0]);
			return (int)array[columnIndex];
		}

		public int[] GetColumnsOrder()
		{
			if (base.Columns.Count == 0)
			{
				return new int[0];
			}
			IntPtr[] array = new IntPtr[base.Columns.Count];
			try
			{
				SendMessage(base.Handle, 4155, (IntPtr)base.Columns.Count, ref array[0]);
			}
			catch
			{
			}
			int[] array2 = new int[base.Columns.Count];
			for (int i = 0; i < base.Columns.Count; i++)
			{
				array2[i] = (int)array[i];
			}
			return array2;
		}

		public void SetColumnsOrder(int[] columnOrderArray)
		{
			if (base.Columns.Count != 0 && columnOrderArray.Length == base.Columns.Count && columnOrderArray[0] == 0)
			{
				IntPtr[] array = new IntPtr[base.Columns.Count];
				for (int i = 0; i < base.Columns.Count; i++)
				{
					array[i] = (IntPtr)columnOrderArray[i];
				}
				try
				{
					SendMessage(base.Handle, 4154, (IntPtr)base.Columns.Count, ref array[0]);
				}
				catch
				{
				}
				Refresh();
			}
		}

		private void InnerScroll()
		{
			while (Control.MouseButtons == MouseButtons.Middle)
			{
				int x = Control.MousePosition.Y - _MouseScrollPosition.Y;
				int y = Control.MousePosition.Y - _MouseScrollPosition.Y;
				Scroll(x, y);
				Thread.Sleep(100);
			}
			Cursor = Cursors.Default;
		}

		public void Scroll(int x, int y)
		{
			NativeMethods.SendMessage(base.Handle, 4116, x, y);
		}

		public void SetColumnsOrder(string columnsOrder)
		{
			if (columnsOrder != null)
			{
				int[] array = new int[columnsOrder.Length];
				for (int i = 0; i < columnsOrder.Length; i++)
				{
					array[i] = int.Parse(new string(columnsOrder[i], 1));
				}
				SetColumnsOrder(array);
			}
		}

		public TreeListViewItemCollection GetVisibleItems()
		{
			TreeListViewItemCollection treeListViewItemCollection = new TreeListViewItemCollection();
			if (base.Items.Count == 0)
			{
				return treeListViewItemCollection;
			}
			int index = base.TopItem.Index;
			int num = NativeMethods.SendMessage(base.Handle, 4100, IntPtr.Zero, IntPtr.Zero);
			int num2 = (index + num > base.Items.Count) ? base.Items.Count : (index + num);
			for (int i = index; i < num2; i++)
			{
				treeListViewItemCollection.Add((TreeListViewItem)base.Items[i]);
			}
			return treeListViewItemCollection;
		}

		public int GetColumnAt(Point p)
		{
			LVHITTESTINFO lParam = default(LVHITTESTINFO);
			lParam.pt = new POINTAPI(PointToClient(Control.MousePosition));
			SendMessage(base.Handle, 4153, 0, ref lParam);
			return lParam.iSubItem;
		}

		public Rectangle GetSubItemRect(TreeListViewItem item, int column)
		{
			return GetSubItemRect(item.Index, column);
		}

		public Rectangle GetSubItemRect(int row, int col)
		{
			RECT lParam = default(RECT);
			lParam.top = col;
			lParam.left = 0;
			SendMessage(base.Handle, 4152, row, ref lParam);
			if (col == 0)
			{
				Rectangle headerItemRect = GetHeaderItemRect(col);
				return new Rectangle(lParam.left, lParam.top, headerItemRect.Width, lParam.bottom - lParam.top);
			}
			return new Rectangle(lParam.left, lParam.top, lParam.right - lParam.left, lParam.bottom - lParam.top);
		}

		public string GetHeaderItemText(int index)
		{
			HDITEM lParam = default(HDITEM);
			lParam.mask = 2;
			lParam.cchTextMax = 255;
			lParam.pszText = Marshal.AllocHGlobal(255);
			SendMessage(base.Handle, HeaderControlMessages.GETITEMW, index, ref lParam);
			return Marshal.PtrToStringAuto(lParam.pszText);
		}

		protected Rectangle GetHeaderItemRect(int index)
		{
			RECT lParam = default(RECT);
			IntPtr dlgItem = NativeMethods.GetDlgItem(base.Handle, 0);
			SendMessage(dlgItem, 4615, index, ref lParam);
			return new Rectangle(lParam.left, lParam.top, lParam.right - lParam.left, lParam.bottom - lParam.top);
		}

		public Rectangle GetRowRect(int row)
		{
			RECT lParam = default(RECT);
			lParam.top = 0;
			lParam.left = 0;
			SendMessage(base.Handle, 4152, row, ref lParam);
			return new Rectangle(lParam.left, lParam.top, lParam.right - lParam.left, lParam.bottom - lParam.top);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CIT.Client.TXTreeListView));
			imageList1 = new System.Windows.Forms.ImageList(components);
			plusMinusImageList = new System.Windows.Forms.ImageList(components);
			SuspendLayout();
			imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			imageList1.ImageSize = new System.Drawing.Size(16, 16);
			imageList1.TransparentColor = System.Drawing.Color.Transparent;
			plusMinusImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("plusMinusImageList.ImageStream");
			plusMinusImageList.TransparentColor = System.Drawing.Color.Transparent;
			plusMinusImageList.Images.SetKeyName(0, "");
			plusMinusImageList.Images.SetKeyName(1, "");
			FullRowSelect = true;
			View = System.Windows.Forms.View.Details;
			ResumeLayout(performLayout: false);
		}

		private TreeListViewItem[] GetCheckedItems()
		{
			if (base.InvokeRequired)
			{
				throw new Exception("Invoke required");
			}
			TreeListViewItemCollection items = new TreeListViewItemCollection();
			foreach (TreeListViewItem item in Items)
			{
				item.GetCheckedItems(ref items);
			}
			return items.ToArray();
		}

		[DllImport("user32.dll")]
		internal static extern bool SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);

		[DllImport("user32.dll")]
		internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref LVHITTESTINFO lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern int SendMessage(IntPtr hWnd, HeaderControlMessages msg, int wParam, ref HDITEM lParam);
	}
}
