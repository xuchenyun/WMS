using CIT.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	[DesignTimeVisible(false)]
	[Designer(typeof(XPanderPanelDesigner))]
	public class XPanderPanel : BasePanel
	{
		private Image m_imageChevron;

		private Image m_imageChevronUp;

		private Image m_imageChevronDown;

		private CustomXPanderPanelColors m_customColors;

		private Image m_imageClosePanel;

		private bool m_bIsClosable = true;

		private CaptionStyle m_captionStyle;

		private IContainer components = null;

		[Category("Appearance")]
		[Description("Gets or sets a value indicating whether the expand icon in a XPanderPanel is visible.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		[Browsable(false)]
		public override bool ShowExpandIcon
		{
			get
			{
				return base.ShowExpandIcon;
			}
			set
			{
				base.ShowExpandIcon = value;
			}
		}

		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Description("Gets or sets a value indicating whether the close icon in a XPanderPanel is visible.")]
		[Category("Appearance")]
		public override bool ShowCloseIcon
		{
			get
			{
				return base.ShowCloseIcon;
			}
			set
			{
				base.ShowCloseIcon = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance")]
		[Description("The custom colors which are used for the XPanderPanel.")]
		public CustomXPanderPanelColors CustomColors
		{
			get
			{
				return m_customColors;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public CaptionStyle CaptionStyle
		{
			get
			{
				return m_captionStyle;
			}
			set
			{
				if (!value.Equals(m_captionStyle))
				{
					m_captionStyle = value;
					OnCaptionStyleChanged(this, EventArgs.Empty);
				}
			}
		}

		[Description("Gets or sets a value indicating whether this XPanderPanel is closable.")]
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool IsClosable
		{
			get
			{
				return m_bIsClosable;
			}
			set
			{
				if (!value.Equals(m_bIsClosable))
				{
					m_bIsClosable = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Browsable(false)]
		public new Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Rectangle DisplayRectangle
		{
			get
			{
				Padding padding = base.Padding;
				Rectangle result = new Rectangle(padding.Left + 1, padding.Top + base.CaptionHeight, base.ClientRectangle.Width - padding.Left - padding.Right - 2, base.ClientRectangle.Height - base.CaptionHeight - padding.Top - padding.Bottom);
				if (base.Controls.Count > 0)
				{
					XPanderPanelList xPanderPanelList = base.Controls[0] as XPanderPanelList;
					if (xPanderPanelList != null && xPanderPanelList.Dock == DockStyle.Fill)
					{
						result = new Rectangle(padding.Left, padding.Top + base.CaptionHeight, base.ClientRectangle.Width - padding.Left - padding.Right, base.ClientRectangle.Height - base.CaptionHeight - padding.Top - padding.Bottom - 1);
					}
				}
				return result;
			}
		}

		[Description("The CaptionStyleChanged event occurs when CaptionStyle flags have been changed.")]
		public event EventHandler<EventArgs> CaptionStyleChanged;

		public XPanderPanel()
		{
			InitializeComponent();
			BackColor = Color.Transparent;
			CaptionStyle = CaptionStyle.Normal;
			ForeColor = SystemColors.ControlText;
			base.Height = base.CaptionHeight;
			ShowBorder = true;
			m_customColors = new CustomXPanderPanelColors();
			m_customColors.CustomColorsChanged += OnCustomColorsChanged;
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			base.BackColor = Color.Transparent;
			Color xPanderPanelBackColor = base.PanelColors.XPanderPanelBackColor;
			if (xPanderPanelBackColor != Color.Empty && xPanderPanelBackColor != Color.Transparent)
			{
				Rectangle rect = new Rectangle(0, base.CaptionHeight, base.ClientRectangle.Width, base.ClientRectangle.Height - base.CaptionHeight);
				using (SolidBrush brush = new SolidBrush(xPanderPanelBackColor))
				{
					pevent.Graphics.FillRectangle(brush, rect);
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!BasePanel.IsZeroWidthOrHeight(base.CaptionRectangle))
			{
				using (new UseAntiAlias(e.Graphics))
				{
					Graphics graphics = e.Graphics;
					using (new UseClearTypeGridFit(graphics))
					{
						bool expand = Expand;
						bool showBorder = ShowBorder;
						Color borderColor = base.PanelColors.BorderColor;
						Rectangle clientRectangle = base.ClientRectangle;
						switch (PanelStyle)
						{
						case PanelStyle.Default:
						case PanelStyle.Office2007:
							DrawCaptionbar(graphics, expand, showBorder, PanelStyle);
							CalculatePanelHeights();
							DrawBorders(graphics, this);
							break;
						}
					}
				}
			}
		}

		protected override void OnPanelExpanding(object sender, XPanderStateChangeEventArgs e)
		{
			bool expand = e.Expand;
			if (expand)
			{
				Expand = expand;
				Invalidate(invalidateChildren: false);
			}
			base.OnPanelExpanding(sender, e);
		}

		protected virtual void OnCaptionStyleChanged(object sender, EventArgs e)
		{
			Invalidate(base.CaptionRectangle);
			if (this.CaptionStyleChanged != null)
			{
				this.CaptionStyleChanged(sender, e);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (base.CaptionRectangle.Contains(e.X, e.Y))
			{
				if (!ShowCloseIcon && !ShowExpandIcon)
				{
					OnExpandClick(this, EventArgs.Empty);
				}
				else if (ShowCloseIcon && !ShowExpandIcon && !RectangleCloseIcon.Contains(e.X, e.Y))
				{
					OnExpandClick(this, EventArgs.Empty);
				}
				if (ShowExpandIcon)
				{
					OnExpandClick(this, EventArgs.Empty);
				}
				if (ShowCloseIcon && m_bIsClosable && RectangleCloseIcon.Contains(e.X, e.Y))
				{
					OnCloseClick(this, EventArgs.Empty);
				}
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (!base.DesignMode)
			{
				if (!base.Visible && Expand)
				{
					Expand = false;
					foreach (Control control in base.Parent.Controls)
					{
						XPanderPanel xPanderPanel = control as XPanderPanel;
						if (xPanderPanel != null && xPanderPanel.Visible)
						{
							xPanderPanel.Expand = true;
							return;
						}
					}
				}
				CalculatePanelHeights();
			}
		}

		private void DrawCaptionbar(Graphics graphics, bool bExpand, bool bShowBorder, PanelStyle panelStyle)
		{
			Rectangle captionRectangle = base.CaptionRectangle;
			Color color = base.PanelColors.XPanderPanelCaptionGradientBegin;
			Color color2 = base.PanelColors.XPanderPanelCaptionGradientEnd;
			Color color3 = base.PanelColors.XPanderPanelCaptionGradientMiddle;
			Color color4 = base.PanelColors.XPanderPanelCaptionText;
			Color foreColorCloseIcon = base.PanelColors.XPanderPanelCaptionCloseIcon;
			Color foreColorExpandIcon = base.PanelColors.XPanderPanelCaptionExpandIcon;
			bool flag = (base.HoverStateCaptionBar == HoverState.Hover) ? true : false;
			if (m_imageClosePanel == null)
			{
				m_imageClosePanel = Resources.closePanel;
			}
			if (m_imageChevronUp == null)
			{
				m_imageChevronUp = Resources.ChevronUp;
			}
			if (m_imageChevronDown == null)
			{
				m_imageChevronDown = Resources.ChevronDown;
			}
			m_imageChevron = m_imageChevronDown;
			if (bExpand)
			{
				m_imageChevron = m_imageChevronUp;
			}
			if (m_captionStyle == CaptionStyle.Normal)
			{
				if (flag)
				{
					color = base.PanelColors.XPanderPanelSelectedCaptionBegin;
					color2 = base.PanelColors.XPanderPanelSelectedCaptionEnd;
					color3 = base.PanelColors.XPanderPanelSelectedCaptionMiddle;
					if (bExpand)
					{
						color = base.PanelColors.XPanderPanelPressedCaptionBegin;
						color2 = base.PanelColors.XPanderPanelPressedCaptionEnd;
						color3 = base.PanelColors.XPanderPanelPressedCaptionMiddle;
					}
					color4 = base.PanelColors.XPanderPanelSelectedCaptionText;
					foreColorCloseIcon = color4;
					foreColorExpandIcon = color4;
				}
				else if (bExpand)
				{
					color = base.PanelColors.XPanderPanelCheckedCaptionBegin;
					color2 = base.PanelColors.XPanderPanelCheckedCaptionEnd;
					color3 = base.PanelColors.XPanderPanelCheckedCaptionMiddle;
					color4 = base.PanelColors.XPanderPanelSelectedCaptionText;
					foreColorCloseIcon = color4;
					foreColorExpandIcon = color4;
				}
				if (panelStyle != PanelStyle.Office2007)
				{
					BasePanel.RenderDoubleBackgroundGradient(graphics, captionRectangle, color, color3, color2, LinearGradientMode.Vertical, flipHorizontal: false);
				}
				else
				{
					BasePanel.RenderButtonBackground(graphics, captionRectangle, color, color3, color2);
				}
			}
			else
			{
				Color xPanderPanelFlatCaptionGradientBegin = base.PanelColors.XPanderPanelFlatCaptionGradientBegin;
				Color xPanderPanelFlatCaptionGradientEnd = base.PanelColors.XPanderPanelFlatCaptionGradientEnd;
				Color innerBorderColor = base.PanelColors.InnerBorderColor;
				color4 = base.PanelColors.XPanderPanelCaptionText;
				foreColorExpandIcon = color4;
				BasePanel.RenderFlatButtonBackground(graphics, captionRectangle, xPanderPanelFlatCaptionGradientBegin, xPanderPanelFlatCaptionGradientEnd, flag);
				DrawInnerBorders(graphics, this);
			}
			BasePanel.DrawImagesAndText(graphics, captionRectangle, 3, base.ImageRectangle, base.Image, RightToLeft, m_bIsClosable, ShowCloseIcon, m_imageClosePanel, foreColorCloseIcon, ref RectangleCloseIcon, ShowExpandIcon, m_imageChevron, foreColorExpandIcon, ref RectangleExpandIcon, base.CaptionFont, color4, Text);
		}

		private static void DrawBorders(Graphics graphics, XPanderPanel xpanderPanel)
		{
			if (xpanderPanel.ShowBorder)
			{
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					using (Pen pen = new Pen(xpanderPanel.PanelColors.BorderColor, 1f))
					{
						Rectangle captionRectangle = xpanderPanel.CaptionRectangle;
						Rectangle rectangle = captionRectangle;
						if (xpanderPanel.Expand)
						{
							rectangle = xpanderPanel.ClientRectangle;
							graphics.DrawLine(pen, captionRectangle.Left, captionRectangle.Top + captionRectangle.Height - 1, captionRectangle.Left + captionRectangle.Width, captionRectangle.Top + captionRectangle.Height - 1);
						}
						XPanderPanelList xPanderPanelList = xpanderPanel.Parent as XPanderPanelList;
						if (xPanderPanelList != null && xPanderPanelList.Dock == DockStyle.Fill)
						{
							TXPanelFrame tXPanelFrame = xPanderPanelList.Parent as TXPanelFrame;
							XPanderPanel xPanderPanel = xPanderPanelList.Parent as XPanderPanel;
							if ((tXPanelFrame != null && tXPanelFrame.Padding == new Padding(0)) || (xPanderPanel != null && xPanderPanel.Padding == new Padding(0)))
							{
								if (xpanderPanel.Top != 0)
								{
									graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left + captionRectangle.Width, rectangle.Top);
								}
								graphics.DrawLine(pen, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Top + rectangle.Height);
								graphics.DrawLine(pen, rectangle.Left + rectangle.Width - 1, rectangle.Top, rectangle.Left + rectangle.Width - 1, rectangle.Top + rectangle.Height);
							}
							else
							{
								if (xpanderPanel.Top == 0)
								{
									graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left + rectangle.Width, rectangle.Top);
								}
								graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Top + rectangle.Height);
								graphicsPath.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - 1, rectangle.Left + rectangle.Width - 1, rectangle.Top + rectangle.Height - 1);
								graphicsPath.AddLine(rectangle.Left + rectangle.Width - 1, rectangle.Top, rectangle.Left + rectangle.Width - 1, rectangle.Top + rectangle.Height);
							}
						}
						else
						{
							if (xpanderPanel.Top == 0)
							{
								graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left + rectangle.Width, rectangle.Top);
							}
							graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Top + rectangle.Height);
							graphicsPath.AddLine(rectangle.Left, rectangle.Top + rectangle.Height - 1, rectangle.Left + rectangle.Width - 1, rectangle.Top + rectangle.Height - 1);
							graphicsPath.AddLine(rectangle.Left + rectangle.Width - 1, rectangle.Top, rectangle.Left + rectangle.Width - 1, rectangle.Top + rectangle.Height);
						}
					}
					using (Pen pen = new Pen(xpanderPanel.PanelColors.BorderColor, 1f))
					{
						graphics.DrawPath(pen, graphicsPath);
					}
				}
			}
		}

		private static void DrawInnerBorders(Graphics graphics, XPanderPanel xpanderPanel)
		{
			if (xpanderPanel.ShowBorder)
			{
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					Rectangle captionRectangle = xpanderPanel.CaptionRectangle;
					XPanderPanelList xPanderPanelList = xpanderPanel.Parent as XPanderPanelList;
					if (xPanderPanelList != null && xPanderPanelList.Dock == DockStyle.Fill)
					{
						TXPanelFrame tXPanelFrame = xPanderPanelList.Parent as TXPanelFrame;
						XPanderPanel xPanderPanel = xPanderPanelList.Parent as XPanderPanel;
						if ((tXPanelFrame != null && tXPanelFrame.Padding == new Padding(0)) || (xPanderPanel != null && xPanderPanel.Padding == new Padding(0)))
						{
							graphicsPath.AddLine(captionRectangle.X, captionRectangle.Y + captionRectangle.Height, captionRectangle.X, captionRectangle.Y + 1);
							if (xpanderPanel.Top == 0)
							{
								graphicsPath.AddLine(captionRectangle.X, captionRectangle.Y, captionRectangle.X + captionRectangle.Width, captionRectangle.Y);
							}
							else
							{
								graphicsPath.AddLine(captionRectangle.X, captionRectangle.Y + 1, captionRectangle.X + captionRectangle.Width, captionRectangle.Y + 1);
							}
						}
					}
					else
					{
						graphicsPath.AddLine(captionRectangle.X + 1, captionRectangle.Y + captionRectangle.Height, captionRectangle.X + 1, captionRectangle.Y);
						if (xpanderPanel.Top == 0)
						{
							graphicsPath.AddLine(captionRectangle.X + 1, captionRectangle.Y + 1, captionRectangle.X + captionRectangle.Width - 1, captionRectangle.Y + 1);
						}
						else
						{
							graphicsPath.AddLine(captionRectangle.X + 1, captionRectangle.Y, captionRectangle.X + captionRectangle.Width - 1, captionRectangle.Y);
						}
					}
					using (Pen pen = new Pen(xpanderPanel.PanelColors.InnerBorderColor))
					{
						graphics.DrawPath(pen, graphicsPath);
					}
				}
			}
		}

		private void CalculatePanelHeights()
		{
			if (base.Parent != null)
			{
				int num = base.Parent.Padding.Top;
				foreach (Control control2 in base.Parent.Controls)
				{
					XPanderPanel xPanderPanel = control2 as XPanderPanel;
					if (xPanderPanel != null && xPanderPanel.Visible)
					{
						num += xPanderPanel.CaptionHeight;
					}
				}
				num += base.Parent.Padding.Bottom;
				foreach (Control control3 in base.Parent.Controls)
				{
					XPanderPanel xPanderPanel = control3 as XPanderPanel;
					if (xPanderPanel != null)
					{
						if (xPanderPanel.Expand)
						{
							xPanderPanel.Height = base.Parent.Height + xPanderPanel.CaptionHeight - num;
						}
						else
						{
							xPanderPanel.Height = xPanderPanel.CaptionHeight;
						}
					}
				}
				int num2 = base.Parent.Padding.Top;
				foreach (Control control4 in base.Parent.Controls)
				{
					XPanderPanel xPanderPanel = control4 as XPanderPanel;
					if (xPanderPanel != null && xPanderPanel.Visible)
					{
						xPanderPanel.Top = num2;
						num2 += xPanderPanel.Height;
					}
				}
			}
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
			BackColor = System.Drawing.Color.FromArgb(214, 223, 247);
		}
	}
}
