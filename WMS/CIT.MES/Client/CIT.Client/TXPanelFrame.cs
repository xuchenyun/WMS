using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	[Designer(typeof(PanelDesigner))]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(Panel))]
	[DefaultEvent("CloseClick")]
	public class TXPanelFrame : BasePanel
	{
		private Rectangle m_restoreBounds;

		private bool m_bShowTransparentBackground;

		private bool m_bShowXPanderPanelProfessionalStyle;

		private bool m_bShowCaptionbar;

		private LinearGradientMode m_linearGradientMode;

		private Image m_imageClosePanel;

		private CustomPanelColors m_customColors;

		private Image m_imgHoverBackground;

		private Splitter m_associatedSplitter;

		private IContainer components = null;

		[Category("Behavior")]
		[Description("The associated Splitter.")]
		public virtual Splitter AssociatedSplitter
		{
			get
			{
				return m_associatedSplitter;
			}
			set
			{
				m_associatedSplitter = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The custom colors which are used for the panel.")]
		[Category("Appearance")]
		public CustomPanelColors CustomColors
		{
			get
			{
				return m_customColors;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override bool Expand
		{
			get
			{
				return base.Expand;
			}
			set
			{
				base.Expand = value;
			}
		}

		[Description("LinearGradientMode of the Panels background")]
		[Category("Appearance")]
		[DefaultValue(1)]
		public LinearGradientMode LinearGradientMode
		{
			get
			{
				return m_linearGradientMode;
			}
			set
			{
				if (!value.Equals(m_linearGradientMode))
				{
					m_linearGradientMode = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("A value indicating whether the panels captionbar is displayed.")]
		public bool ShowCaptionbar
		{
			get
			{
				return m_bShowCaptionbar;
			}
			set
			{
				if (!value.Equals(m_bShowCaptionbar))
				{
					m_bShowCaptionbar = value;
					Invalidate(invalidateChildren: true);
				}
			}
		}

		[Description("Gets or sets a value indicating whether the controls background is transparent")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool ShowTransparentBackground
		{
			get
			{
				return m_bShowTransparentBackground;
			}
			set
			{
				if (!value.Equals(m_bShowTransparentBackground))
				{
					m_bShowTransparentBackground = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("Gets or sets a value indicating whether the controls caption professional colorscheme is the same then the XPanderPanels")]
		public bool ShowXPanderPanelProfessionalStyle
		{
			get
			{
				return m_bShowXPanderPanelProfessionalStyle;
			}
			set
			{
				if (!value.Equals(m_bShowXPanderPanelProfessionalStyle))
				{
					m_bShowXPanderPanelProfessionalStyle = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Browsable(false)]
		public Rectangle RestoreBounds
		{
			get
			{
				return m_restoreBounds;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Rectangle DisplayRectangle
		{
			get
			{
				Padding padding = base.Padding;
				Rectangle result = new Rectangle(base.ClientRectangle.Left + padding.Left, base.ClientRectangle.Top + padding.Top, base.ClientRectangle.Width - padding.Left - padding.Right, base.ClientRectangle.Height - padding.Top - padding.Bottom);
				if (m_bShowCaptionbar && base.Controls.Count > 0)
				{
					XPanderPanelList xPanderPanelList = base.Controls[0] as XPanderPanelList;
					result = ((xPanderPanelList != null && xPanderPanelList.Dock == DockStyle.Fill) ? new Rectangle(padding.Left, base.CaptionHeight + padding.Top + 1, base.ClientRectangle.Width - padding.Left - padding.Right, base.ClientRectangle.Height - base.CaptionHeight - padding.Top - padding.Bottom - 2) : new Rectangle(padding.Left + 1, base.CaptionHeight + padding.Top + 1, base.ClientRectangle.Width - padding.Left - padding.Right - 2, base.ClientRectangle.Height - base.CaptionHeight - padding.Top - padding.Bottom - 2));
				}
				return result;
			}
		}

		public TXPanelFrame()
		{
			InitializeComponent();
			base.CaptionFont = new Font("宋体", 9.5f);
			BackColor = Color.Transparent;
			ForeColor = SystemColors.ControlText;
			ShowTransparentBackground = true;
			ShowXPanderPanelProfessionalStyle = false;
			ColorScheme = ColorScheme.Custom;
			LinearGradientMode = LinearGradientMode.Vertical;
			Expand = true;
			base.CaptionHeight = 22;
			base.ImageSize = new Size(16, 16);
			m_bShowCaptionbar = true;
			m_customColors = new CustomPanelColors();
			m_customColors.CustomColorsChanged += OnCustomColorsChanged;
		}

		public override void SetPanelProperties(PanelColors panelColors)
		{
			m_imgHoverBackground = null;
			base.SetPanelProperties(panelColors);
		}

		protected override void OnExpandClick(object sender, EventArgs e)
		{
			Expand = !Expand;
			base.OnExpandClick(sender, e);
		}

		protected override void OnExpandIconHoverStateChanged(object sender, HoverStateChangeEventArgs e)
		{
			Invalidate(RectangleExpandIcon);
			base.OnExpandIconHoverStateChanged(sender, e);
		}

		protected override void OnCloseIconHoverStateChanged(object sender, HoverStateChangeEventArgs e)
		{
			Invalidate(RectangleCloseIcon);
			base.OnCloseIconHoverStateChanged(sender, e);
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			if (ShowTransparentBackground)
			{
				BackColor = Color.Transparent;
			}
			else
			{
				Rectangle bounds = base.ClientRectangle;
				if (m_bShowCaptionbar)
				{
					BackColor = Color.Transparent;
					bounds = new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top + base.CaptionHeight, base.ClientRectangle.Width, base.ClientRectangle.Height - base.CaptionHeight);
				}
				BasePanel.RenderBackgroundGradient(pevent.Graphics, bounds, base.PanelColors.PanelContentGradientBegin, base.PanelColors.PanelContentGradientEnd, LinearGradientMode);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			PanelStyle panelStyle = PanelStyle;
			if (m_bShowCaptionbar)
			{
				using (new UseAntiAlias(e.Graphics))
				{
					Graphics graphics = e.Graphics;
					using (new UseClearTypeGridFit(graphics))
					{
						Rectangle captionRectangle = base.CaptionRectangle;
						Color colorGradientBegin = base.PanelColors.PanelCaptionGradientBegin;
						Color colorGradientEnd = base.PanelColors.PanelCaptionGradientEnd;
						Color colorGradientMiddle = base.PanelColors.PanelCaptionGradientMiddle;
						Color color = base.PanelColors.PanelCaptionText;
						bool showXPanderPanelProfessionalStyle = ShowXPanderPanelProfessionalStyle;
						ColorScheme colorScheme = ColorScheme;
						if (showXPanderPanelProfessionalStyle && colorScheme == ColorScheme.Professional && panelStyle != PanelStyle.Office2007)
						{
							colorGradientBegin = base.PanelColors.XPanderPanelCaptionGradientBegin;
							colorGradientEnd = base.PanelColors.XPanderPanelCaptionGradientEnd;
							colorGradientMiddle = base.PanelColors.XPanderPanelCaptionGradientMiddle;
							color = base.PanelColors.XPanderPanelCaptionText;
						}
						Image image = base.Image;
						RightToLeft rightToLeft = RightToLeft;
						Font captionFont = base.CaptionFont;
						Rectangle clientRectangle = base.ClientRectangle;
						string text = Text;
						DockStyle dock = Dock;
						bool expand = Expand;
						if (m_imageClosePanel == null)
						{
							m_imageClosePanel = Resources.closePanel;
						}
						Color color2 = base.PanelColors.PanelCaptionCloseIcon;
						if (color2 == Color.Empty)
						{
							color2 = color;
						}
						bool showExpandIcon = ShowExpandIcon;
						bool showCloseIcon = ShowCloseIcon;
						switch (panelStyle)
						{
						case PanelStyle.Default:
						case PanelStyle.Office2007:
							DrawStyleDefault(graphics, captionRectangle, colorGradientBegin, colorGradientEnd, colorGradientMiddle);
							break;
						}
						DrawBorder(graphics, clientRectangle, captionRectangle, base.PanelColors.BorderColor, base.PanelColors.InnerBorderColor);
						if (dock == DockStyle.Fill || dock == DockStyle.None || (!showExpandIcon && !showCloseIcon))
						{
							BasePanel.DrawImagesAndText(graphics, captionRectangle, 3, base.ImageRectangle, image, rightToLeft, captionFont, color, text);
						}
						else if (showExpandIcon || showCloseIcon)
						{
							Image expandImage = GetExpandImage(dock, expand);
							BasePanel.DrawImagesAndText(graphics, dock, 3, captionRectangle, clientRectangle, base.ImageRectangle, image, rightToLeft, showCloseIcon, m_imageClosePanel, color2, ref RectangleCloseIcon, showExpandIcon, expand, expandImage, color, ref RectangleExpandIcon, captionFont, color, base.PanelColors.PanelCollapsedCaptionText, text);
							if (m_imgHoverBackground == null)
							{
								m_imgHoverBackground = GetPanelIconBackground(graphics, base.ImageRectangle, base.PanelColors.PanelCaptionSelectedGradientBegin, base.PanelColors.PanelCaptionSelectedGradientEnd);
							}
							if (m_imgHoverBackground != null)
							{
								Rectangle rectangleCloseIcon = RectangleCloseIcon;
								if (rectangleCloseIcon != Rectangle.Empty && base.HoverStateCloseIcon == HoverState.Hover)
								{
									graphics.DrawImage(m_imgHoverBackground, rectangleCloseIcon);
									BasePanel.DrawIcon(graphics, m_imageClosePanel, rectangleCloseIcon, color2, rectangleCloseIcon.Y);
								}
								Rectangle rectangleExpandIcon = RectangleExpandIcon;
								if (rectangleExpandIcon != Rectangle.Empty && base.HoverStateExpandIcon == HoverState.Hover)
								{
									graphics.DrawImage(m_imgHoverBackground, rectangleExpandIcon);
									BasePanel.DrawIcon(graphics, expandImage, rectangleExpandIcon, color, rectangleExpandIcon.Y);
								}
							}
						}
					}
				}
			}
		}

		protected override void OnPanelCollapsing(object sender, XPanderStateChangeEventArgs e)
		{
			if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				foreach (Control control in base.Controls)
				{
					control.Hide();
				}
			}
			if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				if (base.ClientRectangle.Width > base.CaptionHeight)
				{
					m_restoreBounds = base.ClientRectangle;
				}
				base.Width = base.CaptionHeight;
			}
			if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
			{
				if (base.ClientRectangle.Height > base.CaptionHeight)
				{
					m_restoreBounds = base.ClientRectangle;
				}
				base.Height = base.CaptionHeight;
			}
			base.OnPanelCollapsing(sender, e);
		}

		protected override void OnPanelExpanding(object sender, XPanderStateChangeEventArgs e)
		{
			if (Dock == DockStyle.Left || Dock == DockStyle.Right)
			{
				foreach (Control control in base.Controls)
				{
					control.Show();
				}
				if (base.ClientRectangle.Width == base.CaptionHeight)
				{
					base.Width = m_restoreBounds.Width;
				}
			}
			if (Dock == DockStyle.Top || Dock == DockStyle.Bottom)
			{
				base.Height = m_restoreBounds.Height;
			}
			base.OnPanelExpanding(sender, e);
		}

		protected override void OnPanelStyleChanged(object sender, PanelStyleChangeEventArgs e)
		{
			OnLayout(new LayoutEventArgs(this, null));
			base.OnPanelStyleChanged(sender, e);
		}

		protected override void OnCreateControl()
		{
			m_restoreBounds = base.ClientRectangle;
			MinimumSize = new Size(base.CaptionHeight, base.CaptionHeight);
			base.OnCreateControl();
		}

		protected override void OnResize(EventArgs e)
		{
			if (ShowExpandIcon)
			{
				if (!Expand)
				{
					if ((Dock == DockStyle.Left || Dock == DockStyle.Right) && base.Width > base.CaptionHeight)
					{
						Expand = true;
					}
					if ((Dock == DockStyle.Top || Dock == DockStyle.Bottom) && base.Height > base.CaptionHeight)
					{
						Expand = true;
					}
				}
				else
				{
					if ((Dock == DockStyle.Left || Dock == DockStyle.Right) && base.Width == base.CaptionHeight)
					{
						Expand = false;
					}
					if ((Dock == DockStyle.Top || Dock == DockStyle.Bottom) && base.Height == base.CaptionHeight)
					{
						Expand = false;
					}
				}
			}
			base.OnResize(e);
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			Splitter associatedSplitter = AssociatedSplitter;
			if (associatedSplitter != null)
			{
				associatedSplitter.Visible = base.Visible;
			}
			base.OnVisibleChanged(e);
		}

		private static Image GetPanelIconBackground(Graphics graphics, Rectangle rectanglePanelIcon, Color backgroundColorBegin, Color backgroundColorEnd)
		{
			Rectangle bounds = rectanglePanelIcon;
			bounds.X = 0;
			bounds.Y = 0;
			Image image = new Bitmap(rectanglePanelIcon.Width, rectanglePanelIcon.Height, graphics);
			using (Graphics graphics2 = Graphics.FromImage(image))
			{
				BasePanel.RenderBackgroundGradient(graphics2, bounds, backgroundColorBegin, backgroundColorEnd, LinearGradientMode.Vertical);
			}
			return image;
		}

		private static void DrawStyleDefault(Graphics graphics, Rectangle captionRectangle, Color colorGradientBegin, Color colorGradientEnd, Color colorGradientMiddle)
		{
			BasePanel.RenderDoubleBackgroundGradient(graphics, captionRectangle, colorGradientBegin, colorGradientMiddle, colorGradientEnd, LinearGradientMode.Vertical, flipHorizontal: true);
		}

		private static void DrawBorder(Graphics graphics, Rectangle panelRectangle, Rectangle captionRectangle, Color borderColor, Color innerBorderColor)
		{
			using (Pen pen = new Pen(borderColor))
			{
				Rectangle rectangle = captionRectangle;
				rectangle.Width--;
				rectangle.Offset(1, 1);
				ControlPaint.DrawBorder(graphics, panelRectangle, borderColor, ButtonBorderStyle.Solid);
				graphics.DrawLine(pen, captionRectangle.X, captionRectangle.Y + captionRectangle.Height, captionRectangle.Width, captionRectangle.Y + captionRectangle.Height);
				if (panelRectangle.Height != captionRectangle.Height)
				{
					Rectangle rectangle2 = panelRectangle;
					rectangle2.Y = captionRectangle.Height;
					rectangle2.Height -= captionRectangle.Height + (int)pen.Width;
					rectangle2.Width -= (int)pen.Width;
					Point[] points = new Point[4]
					{
						new Point(rectangle2.X, rectangle2.Y),
						new Point(rectangle2.X, rectangle2.Y + rectangle2.Height),
						new Point(rectangle2.X + rectangle2.Width, rectangle2.Y + rectangle2.Height),
						new Point(rectangle2.X + rectangle2.Width, rectangle2.Y)
					};
					graphics.DrawLines(pen, points);
				}
			}
		}

		private static Image GetExpandImage(DockStyle dockStyle, bool bIsExpanded)
		{
			Image result = null;
			if (dockStyle == DockStyle.Left && bIsExpanded)
			{
				result = Resources.ChevronLeft;
			}
			else if (dockStyle == DockStyle.Left && !bIsExpanded)
			{
				result = Resources.ChevronRight;
			}
			else if (dockStyle == DockStyle.Right && bIsExpanded)
			{
				result = Resources.ChevronRight;
			}
			else if (dockStyle == DockStyle.Right && !bIsExpanded)
			{
				result = Resources.ChevronLeft;
			}
			else if (dockStyle == DockStyle.Top && bIsExpanded)
			{
				result = Resources.ChevronUp;
			}
			else if (dockStyle == DockStyle.Top && !bIsExpanded)
			{
				result = Resources.ChevronDown;
			}
			else if (dockStyle == DockStyle.Bottom && bIsExpanded)
			{
				result = Resources.ChevronDown;
			}
			else if (dockStyle == DockStyle.Bottom && !bIsExpanded)
			{
				result = Resources.ChevronUp;
			}
			return result;
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
			base.Size = new System.Drawing.Size(200, 100);
		}
	}
}
