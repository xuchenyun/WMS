using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

namespace CIT.Client
{
	[DesignTimeVisible(false)]
	public class BasePanel : ScrollableControl, IPanel
	{
		public const int CaptionSpacing = 3;

		private int m_iCaptionHeight;

		private Font m_captionFont;

		private Rectangle m_imageRectangle;

		private bool m_bShowBorder;

		private bool m_bExpand;

		private Size m_imageSize;

		private ColorScheme m_eColorScheme;

		private PanelColors m_panelColors;

		private PanelStyle m_ePanelStyle;

		private Image m_image;

		private HoverState m_hoverStateCaptionBar;

		private HoverState m_hoverStateExpandIcon;

		private string m_strToolTipTextExpandIconPanelExpanded;

		private string m_strToolTipTextExpandIconPanelCollapsed;

		private HoverState m_hoverStateCloseIcon;

		private string m_strToolTipTextCloseIcon;

		private bool m_bShowExpandIcon;

		private bool m_bShowCloseIcon;

		private ToolTip m_toolTip;

		protected Rectangle RectangleExpandIcon = Rectangle.Empty;

		protected Rectangle RectangleCloseIcon = Rectangle.Empty;

		[DefaultValue(0)]
		[Description("Style of the panel")]
		[Category("Appearance")]
		public virtual PanelStyle PanelStyle
		{
			get
			{
				return m_ePanelStyle;
			}
			set
			{
				if (!value.Equals(m_ePanelStyle))
				{
					m_ePanelStyle = value;
					OnPanelStyleChanged(this, new PanelStyleChangeEventArgs(m_ePanelStyle));
				}
			}
		}

		[Category("Appearance")]
		[Description("Gets or sets the image that is displayed on a Panels caption.")]
		public Image Image
		{
			get
			{
				return m_image;
			}
			set
			{
				if (value != m_image)
				{
					m_image = value;
					Invalidate(CaptionRectangle);
				}
			}
		}

		[Browsable(true)]
		[Category("Appearance")]
		[DefaultValue(ColorScheme.Professional)]
		[Description("ColorScheme of the Panel")]
		public virtual ColorScheme ColorScheme
		{
			get
			{
				return m_eColorScheme;
			}
			set
			{
				if (!value.Equals(m_eColorScheme))
				{
					m_eColorScheme = value;
					OnColorSchemeChanged(this, new ColorSchemeChangeEventArgs(m_eColorScheme));
				}
			}
		}

		[Category("Appearance")]
		[Description("Gets or sets the height of the panels caption.")]
		[DefaultValue(25)]
		public int CaptionHeight
		{
			get
			{
				return m_iCaptionHeight;
			}
			set
			{
				if (value < 18)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_InvalidOperationExceptionInteger, new object[3]
					{
						value,
						"CaptionHeight",
						18
					}));
				}
				m_iCaptionHeight = value;
				OnCaptionHeightChanged(this, EventArgs.Empty);
			}
		}

		[DefaultValue(typeof(Font), "Microsoft Sans Serif; 8,25pt; style=Bold")]
		[Category("Appearance")]
		[Description("Gets or sets the font of the text displayed on the caption.")]
		public Font CaptionFont
		{
			get
			{
				return m_captionFont;
			}
			set
			{
				if (value != null && !value.Equals(m_captionFont))
				{
					m_captionFont = value;
					Invalidate(CaptionRectangle);
				}
			}
		}

		[Description("Expand the panel or xpanderpanel")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(false)]
		[Category("Appearance")]
		public virtual bool Expand
		{
			get
			{
				return m_bExpand;
			}
			set
			{
				if (!value.Equals(m_bExpand))
				{
					m_bExpand = value;
					if (m_bExpand)
					{
						OnPanelExpanding(this, new XPanderStateChangeEventArgs(m_bExpand));
					}
					else
					{
						OnPanelCollapsing(this, new XPanderStateChangeEventArgs(m_bExpand));
					}
				}
			}
		}

		[DefaultValue(true)]
		[Category("Appearance")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Gets or sets a value indicating whether the control shows a border")]
		public virtual bool ShowBorder
		{
			get
			{
				return m_bShowBorder;
			}
			set
			{
				if (!value.Equals(m_bShowBorder))
				{
					m_bShowBorder = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Category("Appearance")]
		[Description("Gets or sets a value indicating whether the expand icon in a Panel or XPanderPanel is visible.")]
		[DefaultValue(false)]
		public virtual bool ShowExpandIcon
		{
			get
			{
				return m_bShowExpandIcon;
			}
			set
			{
				if (!value.Equals(m_bShowExpandIcon))
				{
					m_bShowExpandIcon = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Category("Behavior")]
		[Description("Specifies the text to show on a ToolTip when the mouse moves over the closeicon.")]
		public virtual string ToolTipTextCloseIcon
		{
			get
			{
				return m_strToolTipTextCloseIcon;
			}
			set
			{
				m_strToolTipTextCloseIcon = value;
			}
		}

		[Description("Specifies the text to show on a ToolTip when the mouse moves over the expandicon and the panel is collapsed.")]
		[Category("Behavior")]
		public virtual string ToolTipTextExpandIconPanelCollapsed
		{
			get
			{
				return m_strToolTipTextExpandIconPanelCollapsed;
			}
			set
			{
				m_strToolTipTextExpandIconPanelCollapsed = value;
			}
		}

		[Category("Behavior")]
		[Description("Specifies the text to show on a ToolTip when the mouse moves over the expandicon and the panel is expanded.")]
		public virtual string ToolTipTextExpandIconPanelExpanded
		{
			get
			{
				return m_strToolTipTextExpandIconPanelExpanded;
			}
			set
			{
				m_strToolTipTextExpandIconPanelExpanded = value;
			}
		}

		[DefaultValue(false)]
		[Description("Gets or sets a value indicating whether the close icon in a Panel or XPanderPanel is visible.")]
		[Category("Appearance")]
		public virtual bool ShowCloseIcon
		{
			get
			{
				return m_bShowCloseIcon;
			}
			set
			{
				if (!value.Equals(m_bShowCloseIcon))
				{
					m_bShowCloseIcon = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		protected PanelColors PanelColors => m_panelColors;

		internal HoverState HoverStateCaptionBar
		{
			get
			{
				return m_hoverStateCaptionBar;
			}
			set
			{
				m_hoverStateCaptionBar = value;
			}
		}

		internal HoverState HoverStateCloseIcon
		{
			get
			{
				return m_hoverStateCloseIcon;
			}
			set
			{
				m_hoverStateCloseIcon = value;
			}
		}

		internal HoverState HoverStateExpandIcon
		{
			get
			{
				return m_hoverStateExpandIcon;
			}
			set
			{
				m_hoverStateExpandIcon = value;
			}
		}

		internal Size ImageSize
		{
			get
			{
				return m_imageSize;
			}
			set
			{
				m_imageSize = value;
			}
		}

		internal Rectangle CaptionRectangle => new Rectangle(0, 0, base.ClientRectangle.Width, CaptionHeight);

		internal Rectangle ImageRectangle
		{
			get
			{
				if (m_imageRectangle == Rectangle.Empty)
				{
					m_imageRectangle = new Rectangle(3, CaptionHeight, m_imageSize.Width, m_imageSize.Height);
				}
				return m_imageRectangle;
			}
		}

		[Description("Occurs when the close icon in the caption of the panel or xpanderpanel is clicked.")]
		public event EventHandler<EventArgs> CloseClick;

		[Description("Occurs when the expand icon in the caption of the panel or xpanderpanel is clicked.")]
		public event EventHandler<EventArgs> ExpandClick;

		[Description("Occurs when the panel or xpanderpanel expands.")]
		public event EventHandler<XPanderStateChangeEventArgs> PanelExpanding;

		[Description("Occurs when the panel or xpanderpanel collapse.")]
		public event EventHandler<XPanderStateChangeEventArgs> PanelCollapsing;

		[Description("The PanelStyleChanged event occurs when PanelStyle flags have been changed.")]
		public event EventHandler<PanelStyleChangeEventArgs> PanelStyleChanged;

		[Description("The ColorSchemeChanged event occurs when ColorScheme flags have been changed.")]
		public event EventHandler<ColorSchemeChangeEventArgs> ColorSchemeChanged;

		[Description("Occurs when the value of the CustomColors property changes.")]
		public event EventHandler<EventArgs> CustomColorsChanged;

		[Description("Occurs when the value of the CaptionHeight property changes.")]
		public event EventHandler<EventArgs> CaptionHeightChanged;

		[Description("Occurs when the value of the CaptionBar HoverState changes.")]
		public event EventHandler<HoverStateChangeEventArgs> CaptionBarHoverStateChanged;

		[Description("Occurs when the value of the CloseIcon HoverState changes.")]
		protected event EventHandler<HoverStateChangeEventArgs> CloseIconHoverStateChanged;

		[Description("Occurs when the value of the ExpandIcon HoverState changes.")]
		protected event EventHandler<HoverStateChangeEventArgs> ExpandIconHoverStateChanged;

		public virtual void SetPanelProperties(PanelColors panelColors)
		{
			if (panelColors == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ArgumentException, new object[1]
				{
					"panelColors"
				}));
			}
			m_panelColors = panelColors;
			ColorScheme = ColorScheme.Professional;
			Invalidate(invalidateChildren: true);
		}

		protected BasePanel()
		{
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			SetStyle(ControlStyles.ContainerControl, value: true);
			CaptionFont = new Font(SystemFonts.CaptionFont.FontFamily, SystemFonts.CaptionFont.SizeInPoints - 1f, FontStyle.Bold);
			CaptionHeight = 25;
			PanelStyle = PanelStyle.Default;
			m_panelColors = new PanelColors(this);
			m_imageSize = new Size(16, 16);
			m_imageRectangle = Rectangle.Empty;
			m_toolTip = new ToolTip();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			Invalidate(CaptionRectangle);
			base.OnTextChanged(e);
		}

		protected virtual void OnColorSchemeChanged(object sender, ColorSchemeChangeEventArgs e)
		{
			PanelColors.Clear();
			Invalidate(invalidateChildren: false);
			if (this.ColorSchemeChanged != null)
			{
				this.ColorSchemeChanged(sender, e);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (ShowExpandIcon && RectangleExpandIcon.Contains(e.X, e.Y))
			{
				OnExpandClick(this, EventArgs.Empty);
			}
			if (ShowCloseIcon && RectangleCloseIcon.Contains(e.X, e.Y))
			{
				OnCloseClick(this, EventArgs.Empty);
			}
			base.OnMouseUp(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (CaptionRectangle.Contains(e.X, e.Y))
			{
				if (m_hoverStateCaptionBar == HoverState.None)
				{
					m_hoverStateCaptionBar = HoverState.Hover;
					OnCaptionBarHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateCaptionBar));
				}
			}
			else if (m_hoverStateCaptionBar == HoverState.Hover)
			{
				m_hoverStateCaptionBar = HoverState.None;
				OnCaptionBarHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateCaptionBar));
			}
			if (ShowExpandIcon || ShowCloseIcon)
			{
				if (RectangleExpandIcon.Contains(e.X, e.Y))
				{
					if (m_hoverStateExpandIcon == HoverState.None)
					{
						m_hoverStateExpandIcon = HoverState.Hover;
						OnExpandIconHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateExpandIcon));
					}
				}
				else if (m_hoverStateExpandIcon == HoverState.Hover)
				{
					m_hoverStateExpandIcon = HoverState.None;
					OnExpandIconHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateExpandIcon));
				}
				if (RectangleCloseIcon.Contains(e.X, e.Y))
				{
					if (m_hoverStateCloseIcon == HoverState.None)
					{
						m_hoverStateCloseIcon = HoverState.Hover;
						OnCloseIconHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateCloseIcon));
					}
				}
				else if (m_hoverStateCloseIcon == HoverState.Hover)
				{
					m_hoverStateCloseIcon = HoverState.None;
					OnCloseIconHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateCloseIcon));
				}
			}
			base.OnMouseMove(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (m_hoverStateCaptionBar == HoverState.Hover)
			{
				m_hoverStateCaptionBar = HoverState.None;
				OnCaptionBarHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateCaptionBar));
			}
			if (m_hoverStateExpandIcon == HoverState.Hover)
			{
				m_hoverStateExpandIcon = HoverState.None;
				OnExpandIconHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateExpandIcon));
			}
			if (m_hoverStateCloseIcon == HoverState.Hover)
			{
				m_hoverStateCloseIcon = HoverState.None;
				OnCloseIconHoverStateChanged(this, new HoverStateChangeEventArgs(m_hoverStateCloseIcon));
			}
			base.OnMouseLeave(e);
		}

		protected virtual void OnPanelExpanding(object sender, XPanderStateChangeEventArgs e)
		{
			if (this.PanelExpanding != null)
			{
				this.PanelExpanding(sender, e);
			}
		}

		protected virtual void OnPanelCollapsing(object sender, XPanderStateChangeEventArgs e)
		{
			if (this.PanelCollapsing != null)
			{
				this.PanelCollapsing(sender, e);
			}
		}

		protected virtual void OnPanelStyleChanged(object sender, PanelStyleChangeEventArgs e)
		{
			switch (e.PanelStyle)
			{
			case PanelStyle.Default:
				m_panelColors = new PanelColors(this);
				break;
			case PanelStyle.Office2007:
				m_panelColors = new PanelColorsOffice2007Blue(this);
				break;
			}
			Invalidate(invalidateChildren: true);
			if (this.PanelStyleChanged != null)
			{
				this.PanelStyleChanged(sender, e);
			}
		}

		protected virtual void OnCloseClick(object sender, EventArgs e)
		{
			if (this.CloseClick != null)
			{
				this.CloseClick(sender, e);
			}
		}

		protected virtual void OnExpandClick(object sender, EventArgs e)
		{
			Invalidate(invalidateChildren: false);
			if (this.ExpandClick != null)
			{
				this.ExpandClick(sender, e);
			}
		}

		protected virtual void OnExpandIconHoverStateChanged(object sender, HoverStateChangeEventArgs e)
		{
			if (e.HoverState == HoverState.Hover)
			{
				if (Cursor != Cursors.Hand)
				{
					Cursor = Cursors.Hand;
					if (Expand)
					{
						bool flag = 0 == 0;
					}
					else if (!string.IsNullOrEmpty(m_strToolTipTextExpandIconPanelCollapsed))
					{
						m_toolTip.SetToolTip(this, m_strToolTipTextExpandIconPanelCollapsed);
					}
				}
			}
			else if (Cursor == Cursors.Hand)
			{
				m_toolTip.SetToolTip(this, string.Empty);
				m_toolTip.Hide(this);
				Cursor = Cursors.Default;
			}
			if (this.ExpandIconHoverStateChanged != null)
			{
				this.ExpandIconHoverStateChanged(sender, e);
			}
		}

		protected virtual void OnCaptionHeightChanged(object sender, EventArgs e)
		{
			OnLayout(new LayoutEventArgs(this, null));
			Invalidate(invalidateChildren: false);
			if (this.CaptionHeightChanged != null)
			{
				this.CaptionHeightChanged(sender, e);
			}
		}

		protected virtual void OnCaptionBarHoverStateChanged(object sender, HoverStateChangeEventArgs e)
		{
			if (this is XPanderPanel)
			{
				if (e.HoverState == HoverState.Hover)
				{
					if (Cursor != Cursors.Hand)
					{
						Cursor = Cursors.Hand;
					}
				}
				else
				{
					Cursor = Cursors.Default;
				}
				Invalidate(CaptionRectangle);
			}
			if (this.CaptionBarHoverStateChanged != null)
			{
				this.CaptionBarHoverStateChanged(sender, e);
			}
		}

		protected virtual void OnCloseIconHoverStateChanged(object sender, HoverStateChangeEventArgs e)
		{
			if (e.HoverState == HoverState.Hover)
			{
				if (Cursor != Cursors.Hand)
				{
					Cursor = Cursors.Hand;
				}
				if (!string.IsNullOrEmpty(m_strToolTipTextCloseIcon))
				{
					m_toolTip.SetToolTip(this, m_strToolTipTextCloseIcon);
				}
			}
			else if (Cursor == Cursors.Hand)
			{
				m_toolTip.SetToolTip(this, string.Empty);
				m_toolTip.Hide(this);
				Cursor = Cursors.Default;
			}
			if (this.CloseIconHoverStateChanged != null)
			{
				this.CloseIconHoverStateChanged(sender, e);
			}
		}

		protected virtual void OnCustomColorsChanged(object sender, EventArgs e)
		{
			if (ColorScheme == ColorScheme.Custom)
			{
				PanelColors.Clear();
				Invalidate(invalidateChildren: false);
			}
			if (this.CustomColorsChanged != null)
			{
				this.CustomColorsChanged(sender, e);
			}
		}

		protected static void DrawString(Graphics graphics, RectangleF layoutRectangle, Font font, Color fontColor, string strText, RightToLeft rightToLeft, StringAlignment stringAlignment)
		{
			if (graphics == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ArgumentException, new object[1]
				{
					typeof(Graphics).Name
				}));
			}
			using (SolidBrush brush = new SolidBrush(fontColor))
			{
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					if (rightToLeft == RightToLeft.Yes)
					{
						stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
					}
					stringFormat.Trimming = StringTrimming.EllipsisCharacter;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = stringAlignment;
					graphics.DrawString(strText, font, brush, layoutRectangle, stringFormat);
				}
			}
		}

		protected static void DrawIcon(Graphics graphics, Image imgPanelIcon, Rectangle imageRectangle, Color foreColorImage, int iconPositionY)
		{
			if (graphics == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ArgumentException, new object[1]
				{
					typeof(Graphics).Name
				}));
			}
			if (imgPanelIcon == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ArgumentException, new object[1]
				{
					typeof(Image).Name
				}));
			}
			int left = imageRectangle.Left;
			int width = imgPanelIcon.Width;
			int height = imgPanelIcon.Height;
			Rectangle destRect = new Rectangle(left + width / 2 - 1, iconPositionY + height / 2 - 1, imgPanelIcon.Width, imgPanelIcon.Height - 1);
			using (ImageAttributes imageAttributes = new ImageAttributes())
			{
				imageAttributes.SetColorKey(Color.Magenta, Color.Magenta);
				ColorMap colorMap = new ColorMap();
				colorMap.OldColor = Color.FromArgb(0, 60, 166);
				colorMap.NewColor = foreColorImage;
				imageAttributes.SetRemapTable(new ColorMap[1]
				{
					colorMap
				});
				graphics.DrawImage(imgPanelIcon, destRect, 0, 0, width, height, GraphicsUnit.Pixel, imageAttributes);
			}
		}

		protected static void DrawImage(Graphics graphics, Image image, Rectangle imageRectangle)
		{
			if (graphics == null)
			{
				throw new ArgumentNullException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ArgumentException, new object[1]
				{
					typeof(Graphics).Name
				}));
			}
			if (image != null)
			{
				graphics.DrawImage(image, imageRectangle);
			}
		}

		protected static void DrawImagesAndText(Graphics graphics, Rectangle captionRectangle, int iSpacing, Rectangle imageRectangle, Image image, RightToLeft rightToLeft, Font fontCaption, Color captionForeColor, string strCaptionText)
		{
			int num = iSpacing;
			int num2 = captionRectangle.Right - iSpacing;
			imageRectangle.Y = (captionRectangle.Height - imageRectangle.Height) / 2;
			if (rightToLeft == RightToLeft.No && image != null)
			{
				DrawImage(graphics, image, imageRectangle);
				num += imageRectangle.Width + iSpacing;
			}
			Rectangle r = captionRectangle;
			r.X = num;
			r.Width -= num + iSpacing;
			r.Y += (r.Height - Convert.ToInt32(graphics.MeasureString(strCaptionText, fontCaption).Height)) / 2;
			if (rightToLeft == RightToLeft.Yes && image != null)
			{
				Rectangle imageRectangle2 = imageRectangle;
				imageRectangle2.X = num2 - imageRectangle.Width;
				DrawImage(graphics, image, imageRectangle2);
				num2 = imageRectangle2.X - iSpacing;
			}
			r.Width = num2 - num;
			DrawString(graphics, r, fontCaption, captionForeColor, strCaptionText, rightToLeft, StringAlignment.Near);
		}

		protected static void DrawImagesAndText(Graphics graphics, Rectangle captionRectangle, int iSpacing, Rectangle imageRectangle, Image image, RightToLeft rightToLeft, bool bIsClosable, bool bShowCloseIcon, Image imageClosePanel, Color foreColorCloseIcon, ref Rectangle rectangleImageClosePanel, bool bShowExpandIcon, Image imageExandPanel, Color foreColorExpandIcon, ref Rectangle rectangleImageExandPanel, Font fontCaption, Color captionForeColor, string strCaptionText)
		{
			int num = iSpacing;
			int num2 = captionRectangle.Right - iSpacing;
			imageRectangle.Y = (captionRectangle.Height - imageRectangle.Height) / 2;
			if (rightToLeft == RightToLeft.No)
			{
				if (image != null)
				{
					DrawImage(graphics, image, imageRectangle);
					num += imageRectangle.Width + iSpacing;
					num2 -= num;
				}
			}
			else
			{
				if (bShowCloseIcon && imageClosePanel != null)
				{
					rectangleImageClosePanel = imageRectangle;
					rectangleImageClosePanel.X = imageRectangle.X;
					if (bIsClosable)
					{
						DrawIcon(graphics, imageClosePanel, rectangleImageClosePanel, foreColorCloseIcon, imageRectangle.Y);
					}
					num = rectangleImageClosePanel.X + rectangleImageClosePanel.Width;
				}
				if (bShowExpandIcon && imageExandPanel != null)
				{
					rectangleImageExandPanel = imageRectangle;
					rectangleImageExandPanel.X = imageRectangle.X;
					if (bShowCloseIcon && imageClosePanel != null)
					{
						rectangleImageExandPanel.X = num + iSpacing / 2;
					}
					DrawIcon(graphics, imageExandPanel, rectangleImageExandPanel, foreColorExpandIcon, imageRectangle.Y);
					num = rectangleImageExandPanel.X + rectangleImageExandPanel.Width;
				}
			}
			RectangleF layoutRectangle = captionRectangle;
			layoutRectangle.X = (float)num;
			layoutRectangle.Width -= (float)(num + iSpacing);
			if (rightToLeft == RightToLeft.No)
			{
				if (bShowCloseIcon && imageClosePanel != null)
				{
					rectangleImageClosePanel = imageRectangle;
					rectangleImageClosePanel.X = captionRectangle.Right - iSpacing - imageRectangle.Width;
					if (bIsClosable)
					{
						DrawIcon(graphics, imageClosePanel, rectangleImageClosePanel, foreColorCloseIcon, imageRectangle.Y);
					}
					num2 = rectangleImageClosePanel.X;
				}
				if (bShowExpandIcon && imageExandPanel != null)
				{
					rectangleImageExandPanel = imageRectangle;
					rectangleImageExandPanel.X = captionRectangle.Right - iSpacing - imageRectangle.Width;
					if (bShowCloseIcon && imageClosePanel != null)
					{
						rectangleImageExandPanel.X = num2 - iSpacing / 2 - imageRectangle.Width;
					}
					DrawIcon(graphics, imageExandPanel, rectangleImageExandPanel, foreColorExpandIcon, imageRectangle.Y);
					num2 = rectangleImageExandPanel.X;
				}
				if (bShowCloseIcon && imageClosePanel != null && bShowExpandIcon && imageExandPanel != null)
				{
					num2 -= iSpacing;
				}
			}
			else if (image != null)
			{
				Rectangle imageRectangle2 = imageRectangle;
				imageRectangle2.X = num2 - imageRectangle.Width;
				DrawImage(graphics, image, imageRectangle2);
				num2 = imageRectangle2.X - iSpacing;
			}
			layoutRectangle.Width = (float)(num2 - num);
			layoutRectangle.Y = (float)(captionRectangle.Height - fontCaption.Height) / 2f;
			layoutRectangle.Height = (float)(fontCaption.Height + 4);
			DrawString(graphics, layoutRectangle, fontCaption, captionForeColor, strCaptionText, rightToLeft, StringAlignment.Near);
			if (!bIsClosable)
			{
				rectangleImageClosePanel = Rectangle.Empty;
			}
		}

		protected static void DrawImagesAndText(Graphics graphics, DockStyle dockStyle, int iSpacing, Rectangle captionRectangle, Rectangle panelRectangle, Rectangle imageRectangle, Image image, RightToLeft rightToLeft, bool bShowCloseIcon, Image imageClosePanel, Color foreColorCloseIcon, ref Rectangle rectangleImageClosePanel, bool bShowExpandIcon, bool bIsExpanded, Image imageExandPanel, Color foreColorExpandPanel, ref Rectangle rectangleImageExandPanel, Font fontCaption, Color captionForeColor, Color collapsedForeColor, string strCaptionText)
		{
			switch (dockStyle)
			{
			case DockStyle.Left:
			case DockStyle.Right:
				if (bIsExpanded)
				{
					DrawImagesAndText(graphics, captionRectangle, iSpacing, imageRectangle, image, rightToLeft, bIsClosable: true, bShowCloseIcon, imageClosePanel, foreColorCloseIcon, ref rectangleImageClosePanel, bShowExpandIcon, imageExandPanel, foreColorExpandPanel, ref rectangleImageExandPanel, fontCaption, captionForeColor, strCaptionText);
				}
				else
				{
					rectangleImageClosePanel = Rectangle.Empty;
					DrawVerticalImagesAndText(graphics, captionRectangle, panelRectangle, imageRectangle, dockStyle, image, rightToLeft, imageExandPanel, foreColorExpandPanel, ref rectangleImageExandPanel, fontCaption, collapsedForeColor, strCaptionText);
				}
				break;
			case DockStyle.Top:
			case DockStyle.Bottom:
				DrawImagesAndText(graphics, captionRectangle, iSpacing, imageRectangle, image, rightToLeft, bIsClosable: true, bShowCloseIcon, imageClosePanel, foreColorCloseIcon, ref rectangleImageClosePanel, bShowExpandIcon, imageExandPanel, foreColorExpandPanel, ref rectangleImageExandPanel, fontCaption, captionForeColor, strCaptionText);
				break;
			}
		}

		protected static void RenderDoubleBackgroundGradient(Graphics graphics, Rectangle bounds, Color beginColor, Color middleColor, Color endColor, LinearGradientMode linearGradientMode, bool flipHorizontal)
		{
			int num = bounds.Height / 2;
			int secondGradientWidth = bounds.Height - num;
			RenderDoubleBackgroundGradient(graphics, bounds, beginColor, middleColor, endColor, num, secondGradientWidth, linearGradientMode, flipHorizontal);
		}

		protected static void RenderBackgroundGradient(Graphics graphics, Rectangle bounds, Color beginColor, Color endColor, LinearGradientMode linearGradientMode)
		{
			if (graphics == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture, Resources.IDS_ArgumentException, new object[1]
				{
					typeof(Graphics).Name
				}));
			}
			if (!IsZeroWidthOrHeight(bounds))
			{
				using (LinearGradientBrush brush = new LinearGradientBrush(bounds, beginColor, endColor, linearGradientMode))
				{
					graphics.FillRectangle(brush, bounds);
				}
			}
		}

		protected static void RenderButtonBackground(Graphics graphics, Rectangle bounds, Color colorGradientBegin, Color colorGradientMiddle, Color colorGradientEnd)
		{
			RectangleF rect = bounds;
			rect.Height = (float)bounds.Height * 0.4f;
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, colorGradientBegin, colorGradientMiddle, LinearGradientMode.Vertical))
			{
				if (linearGradientBrush != null)
				{
					Blend blend = new Blend();
					blend.Positions = new float[2]
					{
						0f,
						1f
					};
					blend.Factors = new float[2]
					{
						0f,
						0.6f
					};
					linearGradientBrush.Blend = blend;
					graphics.FillRectangle(linearGradientBrush, rect);
				}
			}
			RectangleF rectangleF = bounds;
			rectangleF.Y = rect.Height;
			rectangleF.Height = (float)bounds.Height - rect.Height;
			using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rectangleF, colorGradientMiddle, colorGradientEnd, LinearGradientMode.Vertical))
			{
				if (linearGradientBrush2 != null)
				{
					graphics.FillRectangle(linearGradientBrush2, rectangleF);
				}
			}
			RectangleF rect2 = rectangleF;
			rect2.Y -= 1f;
			rect2.Height = 2f;
			using (SolidBrush brush = new SolidBrush(colorGradientMiddle))
			{
				graphics.FillRectangle(brush, rect2);
			}
		}

		protected static void RenderFlatButtonBackground(Graphics graphics, Rectangle bounds, Color colorGradientBegin, Color colorGradientEnd, bool bHover)
		{
			using (LinearGradientBrush linearGradientBrush = GetFlatGradientBackBrush(bounds, colorGradientBegin, colorGradientEnd, bHover))
			{
				if (linearGradientBrush != null)
				{
					graphics.FillRectangle(linearGradientBrush, bounds);
				}
			}
		}

		protected static GraphicsPath GetPath(Rectangle bounds, int radius)
		{
			int x = bounds.X;
			int y = bounds.Y;
			int width = bounds.Width;
			int height = bounds.Height;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(x, y, radius, radius, 180f, 90f);
			graphicsPath.AddArc(x + width - radius, y, radius, radius, 270f, 90f);
			graphicsPath.AddArc(x + width - radius, y + height - radius, radius, radius, 0f, 90f);
			graphicsPath.AddArc(x, y + height - radius, radius, radius, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		protected static GraphicsPath GetUpperBackgroundPath(Rectangle bounds, int radius)
		{
			int x = bounds.X;
			int y = bounds.Y;
			int width = bounds.Width;
			int height = bounds.Height;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(x, y + height, x, y - radius);
			graphicsPath.AddArc(x, y, radius, radius, 180f, 90f);
			graphicsPath.AddArc(x + width - radius, y, radius, radius, 270f, 90f);
			graphicsPath.AddLine(x + width, y + radius, x + width, y + height);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		protected static GraphicsPath GetBackgroundPath(Rectangle bounds, int radius)
		{
			int x = bounds.X;
			int y = bounds.Y;
			int width = bounds.Width;
			int height = bounds.Height;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(x, y, radius, radius, 180f, 90f);
			graphicsPath.AddArc(x + width - radius, y, radius, radius, 270f, 90f);
			graphicsPath.AddArc(x + width - radius, y + height - radius, radius, radius, 0f, 90f);
			graphicsPath.AddArc(x, y + height - radius, radius, radius, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		protected static LinearGradientBrush GetFlatGradientBackBrush(Rectangle bounds, Color colorGradientBegin, Color colorGradientEnd, bool bHover)
		{
			LinearGradientBrush linearGradientBrush = null;
			Blend blend = new Blend();
			blend.Positions = new float[9]
			{
				0f,
				0.2f,
				0.3f,
				0.4f,
				0.5f,
				0.6f,
				0.7f,
				0.8f,
				1f
			};
			if (!bHover)
			{
				blend.Factors = new float[9]
				{
					0f,
					0f,
					0.2f,
					0.4f,
					0.6f,
					0.4f,
					0.2f,
					0f,
					0f
				};
			}
			else
			{
				blend.Factors = new float[9]
				{
					0.4f,
					0.5f,
					0.6f,
					0.8f,
					1f,
					0.8f,
					0.6f,
					0.5f,
					0.4f
				};
			}
			linearGradientBrush = (linearGradientBrush = new LinearGradientBrush(bounds, colorGradientBegin, colorGradientEnd, LinearGradientMode.Horizontal));
			if (linearGradientBrush != null)
			{
				linearGradientBrush.Blend = blend;
			}
			return linearGradientBrush;
		}

		protected static bool IsZeroWidthOrHeight(Rectangle rectangle)
		{
			if (rectangle.Width != 0)
			{
				return rectangle.Height == 0;
			}
			return true;
		}

		private static void RenderDoubleBackgroundGradient(Graphics graphics, Rectangle bounds, Color beginColor, Color middleColor, Color endColor, int firstGradientWidth, int secondGradientWidth, LinearGradientMode mode, bool flipHorizontal)
		{
			if (bounds.Width != 0 && bounds.Height != 0)
			{
				Rectangle rect = bounds;
				Rectangle rect2 = bounds;
				bool flag = true;
				if (mode == LinearGradientMode.Horizontal)
				{
					if (flipHorizontal)
					{
						Color color = endColor;
						endColor = beginColor;
						beginColor = color;
					}
					rect2.Width = firstGradientWidth;
					rect.Width = secondGradientWidth + 1;
					rect.X = bounds.Right - rect.Width;
					flag = (bounds.Width > firstGradientWidth + secondGradientWidth);
				}
				else
				{
					rect2.Height = firstGradientWidth;
					rect.Height = secondGradientWidth + 1;
					rect.Y = bounds.Bottom - rect.Height;
					flag = (bounds.Height > firstGradientWidth + secondGradientWidth);
				}
				if (flag)
				{
					using (Brush brush = new SolidBrush(middleColor))
					{
						graphics.FillRectangle(brush, bounds);
					}
					using (Brush brush2 = new LinearGradientBrush(rect2, beginColor, middleColor, mode))
					{
						graphics.FillRectangle(brush2, rect2);
					}
					using (LinearGradientBrush brush3 = new LinearGradientBrush(rect, middleColor, endColor, mode))
					{
						if (mode == LinearGradientMode.Horizontal)
						{
							rect.X++;
							rect.Width--;
						}
						else
						{
							rect.Y++;
							rect.Height--;
						}
						graphics.FillRectangle(brush3, rect);
					}
				}
				else
				{
					using (Brush brush4 = new LinearGradientBrush(bounds, beginColor, endColor, mode))
					{
						graphics.FillRectangle(brush4, bounds);
					}
				}
			}
		}

		private static void DrawVerticalImagesAndText(Graphics graphics, Rectangle captionRectangle, Rectangle panelRectangle, Rectangle imageRectangle, DockStyle dockStyle, Image image, RightToLeft rightToLeft, Image imageExandPanel, Color foreColorExpandPanel, ref Rectangle rectangleImageExandPanel, Font captionFont, Color collapsedCaptionForeColor, string strCaptionText)
		{
			imageRectangle.Y = (captionRectangle.Height - imageRectangle.Height) / 2;
			if (imageExandPanel != null)
			{
				rectangleImageExandPanel = imageRectangle;
				rectangleImageExandPanel.X = (panelRectangle.Width - imageRectangle.Width) / 2;
				DrawIcon(graphics, imageExandPanel, rectangleImageExandPanel, foreColorExpandPanel, imageRectangle.Y);
			}
			int num = 3;
			int num2 = panelRectangle.Height - 3;
			if (image != null)
			{
				imageRectangle.Y = num2 - imageRectangle.Height;
				imageRectangle.X = (panelRectangle.Width - imageRectangle.Width) / 2;
				DrawImage(graphics, image, imageRectangle);
				num += imageRectangle.Height + 3;
			}
			num2 -= captionRectangle.Height + num;
			Rectangle r = new Rectangle(num, panelRectangle.Y, num2, captionRectangle.Height);
			using (new SolidBrush(collapsedCaptionForeColor))
			{
				if (dockStyle == DockStyle.Left)
				{
					graphics.TranslateTransform(0f, (float)panelRectangle.Height);
					graphics.RotateTransform(-90f);
					DrawString(graphics, r, captionFont, collapsedCaptionForeColor, strCaptionText, rightToLeft, StringAlignment.Center);
					graphics.ResetTransform();
				}
				if (dockStyle == DockStyle.Right)
				{
					graphics.TranslateTransform((float)panelRectangle.Width, 0f);
					graphics.RotateTransform(90f);
					DrawString(graphics, r, captionFont, collapsedCaptionForeColor, strCaptionText, rightToLeft, StringAlignment.Center);
					graphics.ResetTransform();
				}
			}
		}
	}
}
