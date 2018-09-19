using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(ListView))]
	public class TXListView : ListView
	{
		internal class HeaderNativeWindow : NativeWindow, IDisposable
		{
			private TXListView _owner;

			public HeaderNativeWindow(TXListView owner)
			{
				_owner = owner;
				AssignHandle(owner.HeaderWnd);
			}

			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				int msg = m.Msg;
				if (msg == 15 || msg == 71)
				{
					IntPtr dC = Win32.GetDC(m.HWnd);
					try
					{
						using (Graphics graphics = Graphics.FromHdc(dC))
						{
							Rectangle rect = _owner.HeaderEndRect();
							GDIHelper.InitializeGraphics(graphics);
							GDIHelper.FillPath(graphics, new RoundRectangle(rect, 0), _owner._HeaderBeginColor, _owner._HeaderEndColor);
							rect.Width--;
							rect.Height--;
							if (_owner.BorderStyle != 0)
							{
								using (Pen pen = new Pen(_owner.BorderColor))
								{
									graphics.DrawLine(pen, new Point(rect.Left, rect.Bottom), new Point(rect.Left, rect.Top));
									graphics.DrawLine(pen, new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Top));
									graphics.DrawLine(pen, new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom));
								}
							}
							else
							{
								GDIHelper.DrawPathBorder(graphics, new RoundRectangle(rect, 0), _owner._BorderColor);
							}
						}
					}
					finally
					{
						Win32.ReleaseDC(m.HWnd, dC);
					}
				}
			}

			public void Dispose()
			{
				ReleaseHandle();
				_owner = null;
			}
		}

		public struct EmbeddedItem
		{
			public ListViewItem.ListViewSubItem SubItem;

			public Control EmbeddedControl;

			public int ItemIndex;
		}

		private Color _RowBackColor1 = Color.FromArgb(255, 255, 254);

		private Color _RowBackColor2 = Color.FromArgb(243, 246, 253);

		private Color _SelectedBeginColor = Color.FromArgb(211, 238, 255);

		private Color _SelectedEndColor = Color.FromArgb(175, 225, 253);

		private Color _HeaderBeginColor = Color.FromArgb(253, 253, 253);

		private Color _HeaderEndColor = Color.FromArgb(235, 235, 235);

		private Color _BorderColor = SkinManager.CurrentSkin.BorderColor;

		private SizeType _ColumnsWidthType = SizeType.Absolute;

		private HeaderNativeWindow _headerNativeWindow;

		private Font _Font;

		private Size _CheckBoxSize = new Size(12, 12);

		private ArrayList _EmbeddedItems = new ArrayList();

		private int _cpadding = 3;

		private int _HeaderHeight;

		private IContainer components = null;

		[Category("TXProperties")]
		public override Font Font
		{
			get
			{
				return _Font;
			}
			set
			{
				_Font = value;
				base.Font = new Font(value.FontFamily, value.Size + 4f);
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[DefaultValue(typeof(Size), "12,12")]
		[Description("复选框的大小，设置显示复选框才会有效")]
		public Size CheckBoxSize
		{
			get
			{
				return _CheckBoxSize;
			}
			set
			{
				_CheckBoxSize = value;
			}
		}

		[Category("TXProperties")]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				Invalidate();
			}
		}

		[Description("行交替颜色1")]
		[Category("TXProperties")]
		public Color RowBackColor1
		{
			get
			{
				return _RowBackColor1;
			}
			set
			{
				_RowBackColor1 = value;
				Invalidate();
			}
		}

		[Description("行交替颜色2")]
		[Category("TXProperties")]
		public Color RowBackColor2
		{
			get
			{
				return _RowBackColor2;
			}
			set
			{
				_RowBackColor2 = value;
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Description("标题颜色")]
		public Color HeaderBeginColor
		{
			get
			{
				return _HeaderBeginColor;
			}
			set
			{
				_HeaderBeginColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Description("标题颜色")]
		[Category("TXProperties")]
		public Color HeaderEndColor
		{
			get
			{
				return _HeaderEndColor;
			}
			set
			{
				_HeaderEndColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Description("边框颜色")]
		[Category("TXProperties")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Category("TXProperties")]
		[Description("选择状态颜色")]
		public Color SelectedBeginColor
		{
			get
			{
				return _SelectedBeginColor;
			}
			set
			{
				_SelectedBeginColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Category("TXProperties")]
		[Description("选择状态颜色")]
		public Color SelectedEndColor
		{
			get
			{
				return _SelectedEndColor;
			}
			set
			{
				_SelectedEndColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[DefaultValue(typeof(SizeType), "Absolute")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("TXProperties")]
		[Description("列的宽度类型")]
		public SizeType ColumnsWidthType
		{
			get
			{
				return _ColumnsWidthType;
			}
			set
			{
				_ColumnsWidthType = value;
				ResetColoumsWidth();
				Invalidate(invalidateChildren: true);
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(typeof(BorderStyle), "FixedSingle")]
		[Category("TXProperties")]
		public new BorderStyle BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				base.BorderStyle = value;
				Invalidate();
			}
		}

		private IntPtr HeaderWnd => new IntPtr(Win32.SendMessage(base.Handle, 4127, 0, 0));

		private int ColumnCount => Win32.SendMessage(HeaderWnd, 4608, 0, 0);

		public TXListView()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			UpdateStyles();
			SuspendLayout();
			base.OwnerDraw = true;
			base.FullRowSelect = true;
			base.View = View.Details;
			base.BorderStyle = BorderStyle.FixedSingle;
			BackColor = Color.White;
			Font = new Font("宋体", 9.6f);
			ResetColoumsWidth();
			_HeaderHeight = 0;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (_headerNativeWindow == null && HeaderWnd != IntPtr.Zero)
			{
				_headerNativeWindow = new HeaderNativeWindow(this);
			}
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (_headerNativeWindow != null)
			{
				_headerNativeWindow.Dispose();
				_headerNativeWindow = null;
			}
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			switch (m.Msg)
			{
			case 15:
				BindEmbeddedItem();
				break;
			case 133:
				NcPaint(ref m);
				break;
			case 71:
			{
				IntPtr result = m.Result;
				NcPaint(ref m);
				m.Result = result;
				break;
			}
			}
		}

		protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
		{
			base.OnDrawColumnHeader(e);
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle bounds = e.Bounds;
			GDIHelper.FillPath(graphics, new RoundRectangle(bounds, 0), _HeaderBeginColor, _HeaderEndColor);
			bounds.Height--;
			if (BorderStyle != 0)
			{
				using (Pen pen = new Pen(BorderColor))
				{
					graphics.DrawLine(pen, new Point(bounds.Right, bounds.Bottom), new Point(bounds.Right, bounds.Top));
					graphics.DrawLine(pen, new Point(bounds.Left, bounds.Bottom), new Point(bounds.Right, bounds.Bottom));
				}
			}
			else
			{
				GDIHelper.DrawPathBorder(graphics, new RoundRectangle(bounds, 0), _BorderColor);
			}
			bounds.Height++;
			TextFormatFlags formatFlags = GetFormatFlags(e.Header.TextAlign);
			Rectangle rectangle = new Rectangle(bounds.X + 3, bounds.Y, bounds.Width - 6, bounds.Height);
			Image image = null;
			Size imageSize = new Size(16, 16);
			Rectangle empty = Rectangle.Empty;
			if (e.Header.ImageList != null)
			{
				image = ((e.Header.ImageIndex == -1) ? null : e.Header.ImageList.Images[e.Header.ImageIndex]);
			}
			GDIHelper.DrawImageAndString(graphics, bounds, image, imageSize, e.Header.Text, _Font, e.ForeColor);
		}

		protected override void OnDrawItem(DrawListViewItemEventArgs e)
		{
			base.OnDrawItem(e);
			if (base.View != View.Details)
			{
				e.DrawDefault = true;
			}
		}

		protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
		{
			base.OnDrawSubItem(e);
			if (base.View == View.Details && e.ItemIndex != -1)
			{
				Rectangle bounds = e.Bounds;
				ListViewItemStates itemState = e.ItemState;
				Graphics graphics = e.Graphics;
				GDIHelper.InitializeGraphics(graphics);
				Blend blend = new Blend();
				blend.Positions = new float[4]
				{
					0f,
					0.4f,
					0.7f,
					1f
				};
				blend.Factors = new float[4]
				{
					0f,
					0.3f,
					0.8f,
					0.2f
				};
				if ((itemState & ListViewItemStates.Selected) == ListViewItemStates.Selected)
				{
					Color selectedBeginColor = _SelectedBeginColor;
					Color selectedEndColor = _SelectedEndColor;
					selectedBeginColor = SkinManager.CurrentSkin.HeightLightControlColor.First;
					selectedEndColor = SkinManager.CurrentSkin.HeightLightControlColor.Second;
					blend.Factors = SkinManager.CurrentSkin.HeightLightControlColor.Factors;
					blend.Positions = SkinManager.CurrentSkin.HeightLightControlColor.Positions;
					GDIHelper.FillPath(graphics, new RoundRectangle(bounds, 0), selectedBeginColor, selectedEndColor, blend);
				}
				else
				{
					if (e.ColumnIndex == 0)
					{
						bounds.Inflate(0, -1);
					}
					Color selectedBeginColor = (e.ItemIndex % 2 == 0) ? _RowBackColor1 : _RowBackColor2;
					Color selectedEndColor = selectedBeginColor;
					GDIHelper.FillPath(graphics, new RoundRectangle(bounds, 0), selectedBeginColor, selectedEndColor, blend);
				}
				if (e.ColumnIndex == 0)
				{
					OnDrawFirstSubItem(e, graphics);
				}
				else
				{
					DrawNormalSubItem(e, graphics);
				}
			}
		}

		private void DrawNormalSubItem(DrawListViewSubItemEventArgs e, Graphics g)
		{
			TextFormatFlags formatFlags = GetFormatFlags(e.Header.TextAlign);
			Rectangle bounds = e.Bounds;
			bounds.X += 2;
			bounds.Width -= 4;
			Color foreColor = ((e.ItemState & ListViewItemStates.Selected) == ListViewItemStates.Selected) ? Color.White : e.SubItem.ForeColor;
			TextRenderer.DrawText(g, e.SubItem.Text, _Font, bounds, foreColor, formatFlags);
		}

		protected virtual void OnDrawFirstSubItem(DrawListViewSubItemEventArgs e, Graphics g)
		{
			TextFormatFlags formatFlags = GetFormatFlags(e.Header.TextAlign);
			Rectangle bounds = e.Bounds;
			Image image = null;
			Size empty = Size.Empty;
			Rectangle rectangle = new Rectangle(bounds.X, bounds.Y, 0, 0);
			Rectangle rect = rectangle;
			Rectangle bounds2 = bounds;
			int num = 2;
			if (e.Item.ListView.CheckBoxes)
			{
				rectangle.X += num * 2;
				rectangle.Y = bounds.Top + (bounds.Height - _CheckBoxSize.Height) / 2;
				rectangle.Width = _CheckBoxSize.Width;
				rectangle.Height = _CheckBoxSize.Height;
				rect.X = rectangle.Right;
				bounds2.X = rectangle.Right;
				bounds2.Width -= _CheckBoxSize.Width - num * 2;
				GDIHelper.DrawCheckBox(g, new RoundRectangle(rectangle, 1));
				if (e.Item.Checked)
				{
					GDIHelper.DrawCheckedStateByImage(g, rectangle);
				}
			}
			if (e.Item.ImageList != null && e.Item.ImageIndex >= 0)
			{
				image = e.Item.ImageList.Images[e.Item.ImageIndex];
				empty = e.Item.ImageList.ImageSize;
				rect.X += num * 3;
				rect.Y = bounds.Y + num;
				int num4 = rect.Height = (rect.Width = bounds.Height - num * 2);
				bounds2.X = rect.Right;
				bounds2.Width -= num4 - num * 2;
				GDIHelper.DrawImage(g, rect, image, empty);
			}
			bounds2.X += num;
			bounds2.Width -= num * 2;
			Color foreColor = ((e.ItemState & ListViewItemStates.Selected) == ListViewItemStates.Selected) ? Color.White : e.SubItem.ForeColor;
			TextRenderer.DrawText(g, e.SubItem.Text, _Font, bounds2, foreColor, formatFlags);
		}

		protected TextFormatFlags GetFormatFlags(HorizontalAlignment align)
		{
			TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
			switch (align)
			{
			case HorizontalAlignment.Center:
				textFormatFlags |= TextFormatFlags.HorizontalCenter;
				break;
			case HorizontalAlignment.Right:
				textFormatFlags |= TextFormatFlags.Right;
				break;
			case HorizontalAlignment.Left:
				textFormatFlags = textFormatFlags;
				break;
			}
			return textFormatFlags;
		}

		private int ColumnAtIndex(int column)
		{
			HDITEM lParam = default(HDITEM);
			lParam.mask = 128;
			for (int i = 0; i < ColumnCount; i++)
			{
				if (Win32.SendMessage(HeaderWnd, 4611, column, ref lParam) != IntPtr.Zero)
				{
					return lParam.iOrder;
				}
			}
			return 0;
		}

		private Rectangle HeaderEndRect()
		{
			RECT lParam = default(RECT);
			IntPtr headerWnd = HeaderWnd;
			Win32.SendMessage(headerWnd, 4615, ColumnAtIndex(ColumnCount - 1), ref lParam);
			int right = lParam.right;
			Win32.GetWindowRect(headerWnd, ref lParam);
			Win32.OffsetRect(ref lParam, -lParam.left, -lParam.top);
			lParam.left = right;
			return Rectangle.FromLTRB(lParam.left, lParam.top, lParam.right, lParam.bottom);
		}

		private void ResetColoumsWidth()
		{
			if (base.Columns.Count > 0 && _ColumnsWidthType != SizeType.Absolute)
			{
				int num = 0;
				foreach (ColumnHeader column in base.Columns)
				{
					num += column.Width;
				}
				float num2 = 1f;
				foreach (ColumnHeader column2 in base.Columns)
				{
					num2 = Convert.ToSingle(column2.Width) / Convert.ToSingle(num);
					column2.Width = Convert.ToInt32((float)(base.Width - 20) * num2);
				}
			}
		}

		private void BindEmbeddedItem()
		{
			if (_HeaderHeight <= 0)
			{
				_HeaderHeight = HeaderEndRect().Height;
			}
			using (Graphics graphics = CreateGraphics())
			{
				foreach (EmbeddedItem embeddedItem2 in _EmbeddedItems)
				{
					EmbeddedItem embeddedItem = embeddedItem2;
					Rectangle bounds = embeddedItem.SubItem.Bounds;
					if (bounds.Y > _HeaderHeight - bounds.Height && bounds.Y > 0 && bounds.Y < base.ClientRectangle.Height)
					{
						embeddedItem.EmbeddedControl.Visible = true;
						int num = Convert.ToInt32(graphics.MeasureString(embeddedItem.EmbeddedControl.Text, embeddedItem.SubItem.Font).Width) + 2 * _cpadding;
						if (bounds.X <= 10 && num >= base.Columns[0].Width)
						{
							num = base.Columns[0].Width - 2 * _cpadding;
						}
						embeddedItem.EmbeddedControl.Bounds = new Rectangle(bounds.X + _cpadding, bounds.Y + _cpadding, num, bounds.Height - 2 * _cpadding);
					}
					else
					{
						embeddedItem.EmbeddedControl.Visible = false;
					}
				}
			}
		}

		private void NcPaint(ref Message msg)
		{
			if (base.BorderStyle != 0)
			{
				IntPtr windowDC = Win32.GetWindowDC(msg.HWnd);
				if (windowDC == IntPtr.Zero)
				{
					throw new Win32Exception();
				}
				Rectangle rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				using (Graphics g = Graphics.FromHdc(windowDC))
				{
					GDIHelper.DrawPathBorder(g, new RoundRectangle(rect, 0), _BorderColor);
				}
				msg.Result = IntPtr.Zero;
				Win32.ReleaseDC(msg.HWnd, windowDC);
			}
		}

		public void AddControlToSubItem(Control control, ListViewItem.ListViewSubItem item, int itemIndex)
		{
			base.Controls.Add(control);
			EmbeddedItem embeddedItem = default(EmbeddedItem);
			embeddedItem.EmbeddedControl = control;
			embeddedItem.SubItem = item;
			embeddedItem.ItemIndex = itemIndex;
			_EmbeddedItems.Add(embeddedItem);
		}

		public void ClearEmbeddedItems()
		{
			foreach (EmbeddedItem embeddedItem2 in _EmbeddedItems)
			{
				EmbeddedItem embeddedItem = embeddedItem2;
				embeddedItem.EmbeddedControl.Visible = false;
				embeddedItem.EmbeddedControl.Dispose();
			}
			_EmbeddedItems.Clear();
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
			components = new System.ComponentModel.Container();
		}
	}
}
