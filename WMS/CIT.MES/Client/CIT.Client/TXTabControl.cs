using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(TabControl))]
	public class TXTabControl : TabControl
	{
		private class UpDownButtonNativeWindow : NativeWindow, IDisposable
		{
			private TXTabControl _owner;

			private bool _bPainting;

			public UpDownButtonNativeWindow(TXTabControl owner)
			{
				_owner = owner;
				AssignHandle(owner.UpDownButtonHandle);
			}

			private bool LeftKeyPressed()
			{
				if (SystemInformation.MouseButtonsSwapped)
				{
					return Win32.GetKeyState(2) < 0;
				}
				return Win32.GetKeyState(1) < 0;
			}

			private void DrawUpDownButton()
			{
				bool flag = false;
				bool mousePress = LeftKeyPressed();
				bool flag2 = false;
				RECT r = default(RECT);
				Win32.GetClientRect(base.Handle, ref r);
				Rectangle clipRect = Rectangle.FromLTRB(r.top, r.left, r.right, r.bottom);
				Point lpPoint = default(Point);
				Win32.GetCursorPos(ref lpPoint);
				Win32.GetWindowRect(base.Handle, ref r);
				flag = Win32.PtInRect(ref r, lpPoint);
				lpPoint.X -= r.left;
				lpPoint.Y -= r.top;
				flag2 = (lpPoint.X < clipRect.Width / 2);
				using (Graphics graphics = Graphics.FromHwnd(base.Handle))
				{
					UpDownButtonPaintEventArgs e = new UpDownButtonPaintEventArgs(graphics, clipRect, flag, mousePress, flag2);
					_owner.OnPaintUpDownButton(e);
				}
			}

			protected override void WndProc(ref Message m)
			{
				int msg = m.Msg;
				if (msg == 15)
				{
					if (!_bPainting)
					{
						PAINTSTRUCT ps = default(PAINTSTRUCT);
						_bPainting = true;
						Win32.BeginPaint(m.HWnd, ref ps);
						DrawUpDownButton();
						Win32.EndPaint(m.HWnd, ref ps);
						_bPainting = false;
						m.Result = Win32.TRUE;
					}
					else
					{
						base.WndProc(ref m);
					}
				}
				else
				{
					base.WndProc(ref m);
				}
			}

			public void Dispose()
			{
				_owner = null;
				base.ReleaseHandle();
			}
		}

		private const string UpDownButtonClassName = "msctls_updown32";

		private UpDownButtonNativeWindow _upDownButtonNativeWindow;

		private Color _BaseTabolor = SkinManager.CurrentSkin.DefaultControlColor.First;

		private Color _BackColor = SkinManager.CurrentSkin.BaseColor;

		private Color _BorderColor = SkinManager.CurrentSkin.BorderColor;

		private Color _HeightLightTabColor = SkinManager.CurrentSkin.HeightLightControlColor.First;

		private Color _CheckedTabColor = SkinManager.CurrentSkin.FocusedControlColor.First;

		private int _TabCornerRadius = 3;

		private int _TabMargin = 0;

		private Font _CaptionFont = SystemFonts.DefaultFont;

		private Color _CaptionForceColor = SystemColors.ControlText;

		private bool _ShowCloseButton = true;

		private EnumTabStyle _TabStyle = EnumTabStyle.AnglesWing;

		private static readonly object EventPaintUpDownButton = new object();

		private bool _flag = true;

		private ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

		private int flag = 0;

		private int index = 0;

		private int CLOSE_SIZE = 15;

		private IContainer components = null;

		[Description("标题栏的字体")]
		[Category("TXProperties")]
		[DefaultValue(typeof(Font), "DefaultFont")]
		public Font CaptionFont
		{
			get
			{
				return _CaptionFont;
			}
			set
			{
				if (value != null)
				{
					_CaptionFont = value;
				}
				else
				{
					_CaptionFont = SystemFonts.CaptionFont;
				}
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[DefaultValue(typeof(Color), "ControlText")]
		[Description("标题栏的字体颜色")]
		public Color CaptionForceColor
		{
			get
			{
				return _CaptionForceColor;
			}
			set
			{
				_CaptionForceColor = value;
				Invalidate();
			}
		}

		[Description("标签的基本背景色")]
		[Category("TXProperties")]
		public Color BaseTabColor
		{
			get
			{
				return _BaseTabolor;
			}
			set
			{
				_BaseTabolor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[DefaultValue(TabAppearance.Buttons)]
		[Category("TXProperties")]
		[Description("标签按钮的展现方式")]
		public new TabAppearance Appearance
		{
			get
			{
				return base.Appearance;
			}
			set
			{
				base.Appearance = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Description("标签之间的间距")]
		[Category("TXProperties")]
		[DefaultValue(0)]
		public int TabMargin
		{
			get
			{
				return _TabMargin;
			}
			set
			{
				_TabMargin = ((value > 0) ? value : 0);
				Invalidate(invalidateChildren: true);
			}
		}

		[DefaultValue(EnumTabStyle.AnglesWing)]
		[Description("标签按钮的边框样式")]
		[Category("TXProperties")]
		public EnumTabStyle TabStyle
		{
			get
			{
				return _TabStyle;
			}
			set
			{
				_TabStyle = value;
				Invalidate();
			}
		}

		[Description("基本背景色")]
		[Browsable(true)]
		[Category("TXProperties")]
		public override Color BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Category("TXProperties")]
		[Description("边框色")]
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
		[Description("标签的高亮背景色")]
		public Color HeightLightTabColor
		{
			get
			{
				return _HeightLightTabColor;
			}
			set
			{
				_HeightLightTabColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Category("TXProperties")]
		[Description("标签的选中背景色")]
		public Color CheckedTabColor
		{
			get
			{
				return _CheckedTabColor;
			}
			set
			{
				_CheckedTabColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Description("标签的上面圆角半径值")]
		[Category("TXProperties")]
		public int TabCornerRadius
		{
			get
			{
				return _TabCornerRadius;
			}
			set
			{
				_TabCornerRadius = ((value > 0) ? value : 0);
				Invalidate(invalidateChildren: true);
			}
		}

		[Category("TXProperties")]
		[Description("是否显示X按钮")]
		public bool ShowContextMenu
		{
			get
			{
				return _ShowCloseButton;
			}
			set
			{
				_ShowCloseButton = value;
				Invalidate(invalidateChildren: true);
			}
		}

		internal IntPtr UpDownButtonHandle => FindUpDownButton();

		public event UpDownButtonPaintEventHandler PaintUpDownButton
		{
			add
			{
				base.Events.AddHandler(EventPaintUpDownButton, value);
			}
			remove
			{
				base.Events.RemoveHandler(EventPaintUpDownButton, value);
			}
		}

		public event EventHandler TabpageAdd;

		public event EventHandler TabpageCloseAll;

		public event EventHandler TabpageCurrentClose;

		public event EventHandler TabpageCloseExcaptCurrentClose;

		public TXTabControl()
		{
			SetStyles();
			base.Appearance = TabAppearance.Buttons;
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem.Text = "关闭当前页签";
			toolStripMenuItem.Click -= t1_Click;
			toolStripMenuItem.Click += t1_Click;
			toolStripMenuItem.Size = new Size(148, 22);
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem2.Text = "关闭所有页签";
			toolStripMenuItem2.Click -= t2_Click;
			toolStripMenuItem2.Click += t2_Click;
			toolStripMenuItem2.Size = new Size(148, 22);
			ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
			toolStripMenuItem3.Text = "除此之外全部关闭";
			toolStripMenuItem3.Click -= t5_Click;
			toolStripMenuItem3.Click += t5_Click;
			toolStripMenuItem3.Size = new Size(148, 22);
			ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
			ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
			toolStripMenuItem4.Text = "新建页签";
			toolStripMenuItem4.Click -= t3_Click;
			toolStripMenuItem4.Click += t3_Click;
			toolStripMenuItem4.Size = new Size(148, 22);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
			{
				toolStripMenuItem,
				toolStripMenuItem2,
				toolStripMenuItem3
			});
		}

		private void OnTabpageAdd()
		{
			if (this.TabpageAdd != null)
			{
				this.TabpageAdd(this, EventArgs.Empty);
			}
		}

		private void OnTabpageCloseAll()
		{
			if (this.TabpageCloseAll != null)
			{
				this.TabpageCloseAll(this, EventArgs.Empty);
			}
		}

		private void OnTabpageCurrentClose()
		{
			if (this.TabpageCurrentClose != null)
			{
				this.TabpageCurrentClose(this, EventArgs.Empty);
			}
		}

		private void OnTabpageCloseExcaptCurrentClose()
		{
			if (this.TabpageCloseExcaptCurrentClose != null)
			{
				this.TabpageCloseExcaptCurrentClose(this, EventArgs.Empty);
			}
		}

		protected virtual void OnPaintUpDownButton(UpDownButtonPaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle clipRectangle = e.ClipRectangle;
			Color baseColor = SkinManager.CurrentSkin.DefaultControlColor.First;
			Color borderColor = _BorderColor;
			Color arrowColor = Color.Green;
			Color baseColor2 = SkinManager.CurrentSkin.DefaultControlColor.First;
			Color borderColor2 = _BorderColor;
			Color arrowColor2 = Color.Green;
			Rectangle rect = clipRectangle;
			rect.X += 2;
			rect.Y += 2;
			rect.Width = clipRectangle.Width / 2 - 4;
			rect.Height -= 4;
			Rectangle rect2 = clipRectangle;
			rect2.X = rect.Right;
			rect2.Y += 2;
			rect2.Width = clipRectangle.Width / 2 - 4;
			rect2.Height -= 4;
			if (base.Enabled)
			{
				if (e.MouseOver)
				{
					if (e.MousePress)
					{
						if (e.MouseInUpButton)
						{
							baseColor = SkinManager.CurrentSkin.HeightLightControlColor.First;
						}
						else
						{
							baseColor2 = SkinManager.CurrentSkin.HeightLightControlColor.First;
						}
					}
					else if (e.MouseInUpButton)
					{
						baseColor = SkinManager.CurrentSkin.DefaultControlColor.First;
					}
					else
					{
						baseColor2 = SkinManager.CurrentSkin.DefaultControlColor.First;
					}
				}
			}
			else
			{
				baseColor = SystemColors.Control;
				borderColor = SystemColors.ControlDark;
				arrowColor = SystemColors.ControlDark;
				baseColor2 = SystemColors.Control;
				borderColor2 = SystemColors.ControlDark;
				arrowColor2 = SystemColors.ControlDark;
			}
			GDIHelper.FillPath(graphics, new RoundRectangle(clipRectangle, default(CornerRadius)), _BackColor, _BackColor);
			RenderButton(graphics, rect, baseColor, borderColor, arrowColor, ArrowDirection.Left);
			RenderButton(graphics, rect2, baseColor2, borderColor2, arrowColor2, ArrowDirection.Right);
			(base.Events[EventPaintUpDownButton] as UpDownButtonPaintEventHandler)?.Invoke(this, e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			DrawX(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DrawTabContrl(e.Graphics);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (UpDownButtonHandle != IntPtr.Zero && _upDownButtonNativeWindow == null)
			{
				_upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (UpDownButtonHandle != IntPtr.Zero && _upDownButtonNativeWindow == null)
			{
				_upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
			}
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (_upDownButtonNativeWindow != null)
			{
				_upDownButtonNativeWindow.Dispose();
				_upDownButtonNativeWindow = null;
			}
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (UpDownButtonHandle != IntPtr.Zero && _upDownButtonNativeWindow == null)
			{
				_upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (UpDownButtonHandle != IntPtr.Zero && _upDownButtonNativeWindow == null)
			{
				_upDownButtonNativeWindow = new UpDownButtonNativeWindow(this);
			}
		}

		private IntPtr FindUpDownButton()
		{
			return Win32.FindWindowEx(base.Handle, IntPtr.Zero, "msctls_updown32", null);
		}

		private void SetStyles()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, value: true);
			UpdateStyles();
		}

		private void DrawTabContrl(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.InterpolationMode = InterpolationMode.HighQualityBilinear;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			DrawDrawBackgroundAndHeader(g);
			DrawTabPages(g);
			DrawBorder(g);
		}

		private void DrawDrawBackgroundAndHeader(Graphics g)
		{
			int x = 0;
			int y = 0;
			int width = 0;
			int height = 0;
			switch (base.Alignment)
			{
			case TabAlignment.Top:
				x = 0;
				y = 0;
				width = base.ClientRectangle.Width;
				height = base.ClientRectangle.Height - DisplayRectangle.Height;
				break;
			case TabAlignment.Bottom:
				x = 0;
				y = DisplayRectangle.Height;
				width = base.ClientRectangle.Width;
				height = base.ClientRectangle.Height - DisplayRectangle.Height;
				break;
			case TabAlignment.Left:
				x = 0;
				y = 0;
				width = base.ClientRectangle.Width - DisplayRectangle.Width;
				height = base.ClientRectangle.Height;
				break;
			case TabAlignment.Right:
				x = DisplayRectangle.Width;
				y = 0;
				width = base.ClientRectangle.Width - DisplayRectangle.Width;
				height = base.ClientRectangle.Height;
				break;
			}
			Rectangle rect = new Rectangle(x, y, width, height);
			using (SolidBrush brush = new SolidBrush(_BackColor))
			{
				g.FillRectangle(brush, base.ClientRectangle);
				g.FillRectangle(brush, rect);
			}
		}

		private void DrawX(MouseEventArgs e)
		{
			if (ShowContextMenu && e.Button == MouseButtons.Right)
			{
				int x = e.X;
				int y = e.Y;
				Rectangle tabRect = GetTabRect(base.SelectedIndex);
				tabRect.Width = tabRect.Width;
				tabRect.Height = tabRect.Height;
				if (x > tabRect.X && x < tabRect.Right && y > tabRect.Y && y < tabRect.Bottom)
				{
					contextMenuStrip1.Show(this, new Point(e.X, e.Y));
				}
			}
		}

		private void t3_Click(object sender, EventArgs e)
		{
			OnTabpageAdd();
		}

		private void t2_Click(object sender, EventArgs e)
		{
			OnTabpageCloseAll();
		}

		private void t1_Click(object sender, EventArgs e)
		{
			OnTabpageCurrentClose();
		}

		private void t5_Click(object sender, EventArgs e)
		{
			OnTabpageCloseExcaptCurrentClose();
		}

		private void DrawTabPages(Graphics g)
		{
			Point pt = PointToClient(Control.MousePosition);
			bool flag = false;
			bool flag2 = base.Alignment == TabAlignment.Top || base.Alignment == TabAlignment.Bottom;
			LinearGradientMode linearGradientMode = flag2 ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
			if (flag2)
			{
				IntPtr upDownButtonHandle = UpDownButtonHandle;
				if (upDownButtonHandle != IntPtr.Zero && Win32.IsWindowVisible(upDownButtonHandle))
				{
					RECT lpRect = default(RECT);
					Win32.GetWindowRect(upDownButtonHandle, ref lpRect);
					Rectangle r = Rectangle.FromLTRB(lpRect.left, lpRect.top, lpRect.right, lpRect.bottom);
					r = RectangleToClient(r);
					switch (base.Alignment)
					{
					case TabAlignment.Top:
						r.Y = 0;
						break;
					case TabAlignment.Bottom:
						r.Y = base.ClientRectangle.Height - DisplayRectangle.Height;
						break;
					}
					r.Height = base.ClientRectangle.Height;
					g.SetClip(r, CombineMode.Exclude);
					flag = true;
				}
			}
			for (int i = 0; i < base.TabCount; i++)
			{
				TabPage tabPage = base.TabPages[i];
				Rectangle tabRect = GetTabRect(i);
				bool flag3 = tabRect.Contains(pt);
				bool flag4 = base.SelectedIndex == i;
				Color color = _BaseTabolor;
				Color borderColor = _BorderColor;
				Blend blend = new Blend();
				blend.Positions = new float[5]
				{
					0f,
					0.3f,
					0.5f,
					0.7f,
					1f
				};
				blend.Factors = new float[5]
				{
					0.1f,
					0.3f,
					0.5f,
					0.8f,
					1f
				};
				if (flag4)
				{
					color = _CheckedTabColor;
				}
				else if (flag3)
				{
					color = _HeightLightTabColor;
					blend.Positions = new float[5]
					{
						0f,
						0.3f,
						0.6f,
						0.8f,
						1f
					};
					blend.Factors = new float[5]
					{
						0.2f,
						0.4f,
						0.6f,
						0.5f,
						0.4f
					};
				}
				Rectangle rect = new Rectangle(tabRect.Left, tabRect.Bottom, tabRect.Width, 1);
				g.SetClip(rect, CombineMode.Exclude);
				CornerRadius cornerRadius = new CornerRadius(_TabCornerRadius, _TabCornerRadius, 0, 0);
				tabRect.X += _TabMargin;
				tabRect.Width -= _TabMargin;
				tabRect.Y++;
				tabRect.Height--;
				RoundRectangle roundRect = new RoundRectangle(tabRect, cornerRadius);
				GDIHelper.InitializeGraphics(g);
				switch (_TabStyle)
				{
				case EnumTabStyle.AnglesWing:
					cornerRadius = new CornerRadius(_TabCornerRadius);
					tabRect.X += _TabCornerRadius;
					tabRect.Width -= _TabCornerRadius * 2;
					roundRect = new RoundRectangle(tabRect, cornerRadius);
					using (GraphicsPath path = roundRect.ToGraphicsAnglesWingPath())
					{
						using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(roundRect.Rect, color, _BackColor, LinearGradientMode.Vertical))
						{
							linearGradientBrush.Blend = blend;
							g.FillPath(linearGradientBrush, path);
						}
					}
					using (GraphicsPath path = roundRect.ToGraphicsAnglesWingPath())
					{
						using (Pen pen = new Pen(_BorderColor, 1f))
						{
							g.DrawPath(pen, path);
						}
					}
					break;
				case EnumTabStyle.Default:
					GDIHelper.FillPath(g, roundRect, color, _BackColor, blend);
					GDIHelper.DrawPathBorder(g, roundRect, _BorderColor);
					break;
				}
				g.ResetClip();
				if (base.Alignment == TabAlignment.Top)
				{
					Image image = null;
					Size imageSize = Size.Empty;
					if (base.ImageList != null && tabPage.ImageIndex >= 0)
					{
						image = base.ImageList.Images[tabPage.ImageIndex];
						imageSize = image.Size;
					}
					GDIHelper.DrawImageAndString(g, tabRect, image, imageSize, tabPage.Text, _CaptionFont, _CaptionForceColor);
				}
				else
				{
					bool hasImage = DrawTabImage(g, tabPage, tabRect);
					DrawtabText(g, tabPage, tabRect, hasImage);
				}
			}
			if (flag)
			{
				g.ResetClip();
			}
			if (base.SelectedIndex > -1)
			{
				bool flag5 = true;
			}
		}

		private void DrawtabText(Graphics g, TabPage page, Rectangle tabRect, bool hasImage)
		{
			Rectangle rectangle = tabRect;
			switch (base.Alignment)
			{
			case TabAlignment.Top:
			case TabAlignment.Bottom:
				if (hasImage)
				{
					rectangle.X = tabRect.X + _TabCornerRadius / 2 + tabRect.Height - 2;
					rectangle.Width = tabRect.Width - _TabCornerRadius - tabRect.Height;
				}
				TextRenderer.DrawText(g, page.Text, page.Font, rectangle, page.ForeColor);
				break;
			case TabAlignment.Left:
			{
				if (hasImage)
				{
					rectangle.Height = tabRect.Height - tabRect.Width + 2;
				}
				g.TranslateTransform((float)rectangle.X, (float)rectangle.Bottom);
				g.RotateTransform(270f);
				StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.Trimming = StringTrimming.Character;
				RectangleF layoutRectangle = rectangle;
				layoutRectangle.X = 0f;
				layoutRectangle.Y = 0f;
				layoutRectangle.Width = (float)rectangle.Height;
				layoutRectangle.Height = (float)rectangle.Width;
				using (Brush brush = new SolidBrush(page.ForeColor))
				{
					g.DrawString(page.Text, page.Font, brush, layoutRectangle, stringFormat);
				}
				g.ResetTransform();
				break;
			}
			case TabAlignment.Right:
			{
				if (hasImage)
				{
					rectangle.Y = tabRect.Y + _TabCornerRadius / 2 + tabRect.Width - 2;
					rectangle.Height = tabRect.Height - _TabCornerRadius - tabRect.Width;
				}
				g.TranslateTransform((float)rectangle.Right, (float)rectangle.Y);
				g.RotateTransform(90f);
				StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.Trimming = StringTrimming.Character;
				RectangleF layoutRectangle = rectangle;
				layoutRectangle.X = 0f;
				layoutRectangle.Y = 0f;
				layoutRectangle.Width = (float)rectangle.Height;
				layoutRectangle.Height = (float)rectangle.Width;
				using (Brush brush = new SolidBrush(page.ForeColor))
				{
					g.DrawString(page.Text, page.Font, brush, layoutRectangle, stringFormat);
				}
				g.ResetTransform();
				break;
			}
			}
		}

		private void DrawBorder(Graphics g)
		{
			if (base.SelectedIndex != -1)
			{
				Rectangle tabRect = GetTabRect(base.SelectedIndex);
				Rectangle clientRectangle = base.ClientRectangle;
				Point[] array = new Point[6];
				IntPtr upDownButtonHandle = UpDownButtonHandle;
				if (upDownButtonHandle != IntPtr.Zero && Win32.IsWindowVisible(upDownButtonHandle))
				{
					RECT lpRect = default(RECT);
					Win32.GetWindowRect(upDownButtonHandle, ref lpRect);
					Rectangle r = Rectangle.FromLTRB(lpRect.left, lpRect.top, lpRect.right, lpRect.bottom);
					r = RectangleToClient(r);
					tabRect.X = ((tabRect.X > r.X) ? r.X : tabRect.X);
					tabRect.Width = ((tabRect.Right > r.X) ? (r.X - tabRect.X) : tabRect.Width);
				}
				int num = 0;
				if (_TabStyle == EnumTabStyle.AnglesWing)
				{
					num = _TabCornerRadius / 2;
				}
				switch (base.Alignment)
				{
				case TabAlignment.Top:
					array[0] = new Point(tabRect.X + _TabMargin + num, tabRect.Bottom);
					array[1] = new Point(clientRectangle.X, tabRect.Bottom);
					array[2] = new Point(clientRectangle.X, clientRectangle.Bottom - 1);
					array[3] = new Point(clientRectangle.Right - 1, clientRectangle.Bottom - 1);
					array[4] = new Point(clientRectangle.Right - 1, tabRect.Bottom);
					array[5] = new Point(tabRect.Right - num, tabRect.Bottom);
					break;
				case TabAlignment.Bottom:
					array[0] = new Point(tabRect.X, tabRect.Y);
					array[1] = new Point(clientRectangle.X, tabRect.Y);
					array[2] = new Point(clientRectangle.X, clientRectangle.Y);
					array[3] = new Point(clientRectangle.Right - 1, clientRectangle.Y);
					array[4] = new Point(clientRectangle.Right - 1, tabRect.Y);
					array[5] = new Point(tabRect.Right, tabRect.Y);
					break;
				case TabAlignment.Left:
					array[0] = new Point(tabRect.Right, tabRect.Y);
					array[1] = new Point(tabRect.Right, clientRectangle.Y);
					array[2] = new Point(clientRectangle.Right - 1, clientRectangle.Y);
					array[3] = new Point(clientRectangle.Right - 1, clientRectangle.Bottom - 1);
					array[4] = new Point(tabRect.Right, clientRectangle.Bottom - 1);
					array[5] = new Point(tabRect.Right, tabRect.Bottom);
					break;
				case TabAlignment.Right:
					array[0] = new Point(tabRect.X, tabRect.Y);
					array[1] = new Point(tabRect.X, clientRectangle.Y);
					array[2] = new Point(clientRectangle.X, clientRectangle.Y);
					array[3] = new Point(clientRectangle.X, clientRectangle.Bottom - 1);
					array[4] = new Point(tabRect.X, clientRectangle.Bottom - 1);
					array[5] = new Point(tabRect.X, tabRect.Bottom);
					break;
				}
				using (Pen pen = new Pen(_BorderColor))
				{
					g.DrawLines(pen, array);
				}
			}
		}

		internal void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
		{
			Point point = new Point(dropDownRect.Left + dropDownRect.Width / 2, dropDownRect.Top + dropDownRect.Height / 2);
			Point[] array = null;
			switch (direction)
			{
			case ArrowDirection.Left:
				array = new Point[3]
				{
					new Point(point.X + 2, point.Y - 6),
					new Point(point.X + 2, point.Y + 6),
					new Point(point.X - 4, point.Y)
				};
				break;
			case ArrowDirection.Up:
				array = new Point[3]
				{
					new Point(point.X - 4, point.Y + 2),
					new Point(point.X + 4, point.Y + 2),
					new Point(point.X, point.Y - 2)
				};
				break;
			case ArrowDirection.Right:
				array = new Point[3]
				{
					new Point(point.X - 2, point.Y - 6),
					new Point(point.X - 2, point.Y + 6),
					new Point(point.X + 4, point.Y)
				};
				break;
			default:
				array = new Point[3]
				{
					new Point(point.X - 4, point.Y - 2),
					new Point(point.X + 4, point.Y - 2),
					new Point(point.X, point.Y + 2)
				};
				break;
			}
			g.FillPolygon(brush, array);
		}

		internal void RenderButton(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color arrowColor, ArrowDirection direction)
		{
			CornerRadius cornerRadius = default(CornerRadius);
			switch (direction)
			{
			case ArrowDirection.Left:
				cornerRadius = new CornerRadius(2, 0, 2, 0);
				break;
			case ArrowDirection.Right:
				cornerRadius = new CornerRadius(0, 2, 0, 2);
				break;
			}
			RoundRectangle roundRect = new RoundRectangle(rect, cornerRadius);
			GDIHelper.FillPath(g, roundRect, baseColor, baseColor);
			GDIHelper.DrawPathBorder(g, roundRect);
			using (SolidBrush brush = new SolidBrush(arrowColor))
			{
				RenderArrowInternal(g, rect, direction, brush);
			}
		}

		internal void RenderTabBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, float basePosition, LinearGradientMode mode)
		{
			using (GraphicsPath graphicsPath = CreateTabPath(rect))
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
				{
					Color[] colors = new Color[4]
					{
						GetColor(baseColor, 0, 35, 24, 9),
						GetColor(baseColor, 0, 13, 8, 3),
						baseColor,
						GetColor(baseColor, 0, 68, 69, 54)
					};
					ColorBlend colorBlend = new ColorBlend();
					colorBlend.Positions = new float[4]
					{
						0f,
						basePosition,
						basePosition + 0.05f,
						1f
					};
					colorBlend.Colors = colors;
					linearGradientBrush.InterpolationColors = colorBlend;
					g.FillPath(linearGradientBrush, graphicsPath);
				}
				if (baseColor.A > 80)
				{
					Rectangle rect2 = rect;
					if (mode == LinearGradientMode.Vertical)
					{
						rect2.Height = (int)((float)rect2.Height * basePosition);
					}
					else
					{
						rect2.Width = (int)((float)rect.Width * basePosition);
					}
					using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
					{
						g.FillRectangle(brush, rect2);
					}
				}
				rect.Inflate(-1, -1);
				using (GraphicsPath graphicsPath2 = CreateTabPath(rect))
				{
					using (Pen pen = new Pen(Color.FromArgb(255, 255, 255)))
					{
						if (base.Multiline)
						{
							g.DrawPath(pen, graphicsPath2);
						}
						else
						{
							g.DrawLines(pen, graphicsPath2.PathPoints);
						}
					}
				}
				using (Pen pen = new Pen(borderColor))
				{
					if (base.Multiline)
					{
						g.DrawPath(pen, graphicsPath);
					}
					g.DrawLines(pen, graphicsPath.PathPoints);
				}
			}
		}

		private bool DrawTabImage(Graphics g, TabPage page, Rectangle rect)
		{
			bool result = false;
			if (base.ImageList != null)
			{
				Image image = null;
				if (page.ImageIndex != -1)
				{
					image = base.ImageList.Images[page.ImageIndex];
				}
				else if (page.ImageKey != null)
				{
					image = base.ImageList.Images[page.ImageKey];
				}
				if (image != null)
				{
					result = true;
					Rectangle destRect = Rectangle.Empty;
					Rectangle srcRect = new Rectangle(Point.Empty, image.Size);
					switch (base.Alignment)
					{
					case TabAlignment.Top:
					case TabAlignment.Bottom:
						destRect = new Rectangle(rect.X + _TabCornerRadius / 2 + 2, rect.Y + 2, rect.Height - 4, rect.Height - 4);
						break;
					case TabAlignment.Left:
						destRect = new Rectangle(rect.X + 2, rect.Bottom - (rect.Width - 4) - _TabCornerRadius / 2 - 2, rect.Width - 4, rect.Width - 4);
						break;
					case TabAlignment.Right:
						destRect = new Rectangle(rect.X + 2, rect.Y + _TabCornerRadius / 2 + 2, rect.Width - 4, rect.Width - 4);
						break;
					}
					g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
				}
			}
			return result;
		}

		private GraphicsPath CreateTabPath(Rectangle rect)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			switch (base.Alignment)
			{
			case TabAlignment.Top:
				rect.X++;
				rect.Width -= 2;
				graphicsPath.AddLine(rect.X, rect.Bottom, rect.X, rect.Y + _TabCornerRadius / 2);
				graphicsPath.AddArc(rect.X, rect.Y, _TabCornerRadius, _TabCornerRadius, 180f, 90f);
				graphicsPath.AddArc(rect.Right - _TabCornerRadius, rect.Y, _TabCornerRadius, _TabCornerRadius, 270f, 90f);
				graphicsPath.AddLine(rect.Right, rect.Y + _TabCornerRadius / 2, rect.Right, rect.Bottom);
				break;
			case TabAlignment.Bottom:
				rect.X++;
				rect.Width -= 2;
				graphicsPath.AddLine(rect.X, rect.Y, rect.X, rect.Bottom - _TabCornerRadius / 2);
				graphicsPath.AddArc(rect.X, rect.Bottom - _TabCornerRadius, _TabCornerRadius, _TabCornerRadius, 180f, -90f);
				graphicsPath.AddArc(rect.Right - _TabCornerRadius, rect.Bottom - _TabCornerRadius, _TabCornerRadius, _TabCornerRadius, 90f, -90f);
				graphicsPath.AddLine(rect.Right, rect.Bottom - _TabCornerRadius / 2, rect.Right, rect.Y);
				break;
			case TabAlignment.Left:
				rect.Y++;
				rect.Height -= 2;
				graphicsPath.AddLine(rect.Right, rect.Y, rect.X + _TabCornerRadius / 2, rect.Y);
				graphicsPath.AddArc(rect.X, rect.Y, _TabCornerRadius, _TabCornerRadius, 270f, -90f);
				graphicsPath.AddArc(rect.X, rect.Bottom - _TabCornerRadius, _TabCornerRadius, _TabCornerRadius, 180f, -90f);
				graphicsPath.AddLine(rect.X + _TabCornerRadius / 2, rect.Bottom, rect.Right, rect.Bottom);
				break;
			case TabAlignment.Right:
				rect.Y++;
				rect.Height -= 2;
				graphicsPath.AddLine(rect.X, rect.Y, rect.Right - _TabCornerRadius / 2, rect.Y);
				graphicsPath.AddArc(rect.Right - _TabCornerRadius, rect.Y, _TabCornerRadius, _TabCornerRadius, 270f, 90f);
				graphicsPath.AddArc(rect.Right - _TabCornerRadius, rect.Bottom - _TabCornerRadius, _TabCornerRadius, _TabCornerRadius, 0f, 90f);
				graphicsPath.AddLine(rect.Right - _TabCornerRadius / 2, rect.Bottom, rect.X, rect.Bottom);
				break;
			}
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		private Color GetColor(Color colorBase, int a, int r, int g, int b)
		{
			int a2 = colorBase.A;
			int r2 = colorBase.R;
			int g2 = colorBase.G;
			int b2 = colorBase.B;
			a = ((a + a2 <= 255) ? Math.Max(a + a2, 0) : 255);
			r = ((r + r2 <= 255) ? Math.Max(r + r2, 0) : 255);
			g = ((g + g2 <= 255) ? Math.Max(g + g2, 0) : 255);
			b = ((b + b2 <= 255) ? Math.Max(b + b2, 0) : 255);
			return Color.FromArgb(a, r, g, b);
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
			SuspendLayout();
			ResumeLayout(performLayout: false);
		}
	}
}
