using CIT.Client.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(Panel))]
	[DesignTimeVisible(true)]
	[Designer(typeof(XPanderPanelListDesigner))]
	public class XPanderPanelList : ScrollableControl
	{
		private bool m_bShowBorder;

		private bool m_bShowGradientBackground;

		private bool m_bShowExpandIcon;

		private bool m_bShowCloseIcon;

		private int m_iCaptionHeight;

		private LinearGradientMode m_linearGradientMode;

		private Color m_colorGradientBackground;

		private CaptionStyle m_captionStyle;

		private PanelStyle m_ePanelStyle;

		private ColorScheme m_eColorScheme;

		private XPanderPanelCollection m_xpanderPanels;

		private PanelColors m_panelColors;

		private IContainer components = null;

		[Editor(typeof(XPanderPanelCollectionEditor), typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Collection containing all the XPanderPanels for the xpanderpanellist.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Browsable(true)]
		[Category("Collections")]
		public XPanderPanelCollection XPanderPanels
		{
			get
			{
				return m_xpanderPanels;
			}
		}

		[Category("Appearance")]
		[Description("Specifies the style of the xpanderpanels in this xpanderpanellist.")]
		[DefaultValue(PanelStyle.Default)]
		public PanelStyle PanelStyle
		{
			get
			{
				return m_ePanelStyle;
			}
			set
			{
				if (value != m_ePanelStyle)
				{
					m_ePanelStyle = value;
					OnPanelStyleChanged(this, new PanelStyleChangeEventArgs(m_ePanelStyle));
				}
			}
		}

		public PanelColors PanelColors
		{
			get
			{
				return m_panelColors;
			}
			set
			{
				m_panelColors = value;
			}
		}

		[Category("Appearance")]
		[Description("The colorscheme of the xpanderpanels in the xpanderpanellist")]
		[DefaultValue(ColorScheme.Professional)]
		public ColorScheme ColorScheme
		{
			get
			{
				return m_eColorScheme;
			}
			set
			{
				if (value != m_eColorScheme)
				{
					m_eColorScheme = value;
					OnColorSchemeChanged(this, new ColorSchemeChangeEventArgs(m_eColorScheme));
				}
			}
		}

		[Category("Appearance")]
		[Description("The style of the captionbar.")]
		public CaptionStyle CaptionStyle
		{
			get
			{
				return m_captionStyle;
			}
			set
			{
				m_captionStyle = value;
				OnCaptionStyleChanged(this, EventArgs.Empty);
			}
		}

		[Category("Appearance")]
		[Description("LinearGradientMode of the background in the xpanderpanellist")]
		[DefaultValue(LinearGradientMode.Vertical)]
		public LinearGradientMode LinearGradientMode
		{
			get
			{
				return m_linearGradientMode;
			}
			set
			{
				if (value != m_linearGradientMode)
				{
					m_linearGradientMode = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Category("Appearance")]
		[DefaultValue(false)]
		[Description("Gets or sets a value indicating whether a xpanderpanellist's gradient background is shown.")]
		public bool ShowGradientBackground
		{
			get
			{
				return m_bShowGradientBackground;
			}
			set
			{
				if (value != m_bShowGradientBackground)
				{
					m_bShowGradientBackground = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Gets or sets a value indicating whether a xpanderpanellist's border is shown")]
		public bool ShowBorder
		{
			get
			{
				return m_bShowBorder;
			}
			set
			{
				if (value != m_bShowBorder)
				{
					m_bShowBorder = value;
					foreach (XPanderPanel xPanderPanel in XPanderPanels)
					{
						xPanderPanel.ShowBorder = m_bShowBorder;
					}
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Description("Gets or sets a value indicating whether the expand icon of the xpanderpanels in this xpanderpanellist are visible.")]
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool ShowExpandIcon
		{
			get
			{
				return m_bShowExpandIcon;
			}
			set
			{
				if (value != m_bShowExpandIcon)
				{
					m_bShowExpandIcon = value;
					foreach (XPanderPanel xPanderPanel in XPanderPanels)
					{
						xPanderPanel.ShowExpandIcon = m_bShowExpandIcon;
					}
				}
			}
		}

		[Category("Appearance")]
		[Description("Gets or sets a value indicating whether the close icon of the xpanderpanels in this xpanderpanellist are visible.")]
		[DefaultValue(false)]
		public bool ShowCloseIcon
		{
			get
			{
				return m_bShowCloseIcon;
			}
			set
			{
				if (value != m_bShowCloseIcon)
				{
					m_bShowCloseIcon = value;
					foreach (XPanderPanel xPanderPanel in XPanderPanels)
					{
						xPanderPanel.ShowCloseIcon = m_bShowCloseIcon;
					}
				}
			}
		}

		[Description("Gradientcolor background in this xpanderpanellist")]
		[Category("Appearance")]
		[DefaultValue(false)]
		public Color GradientBackground
		{
			get
			{
				return m_colorGradientBackground;
			}
			set
			{
				if (value != m_colorGradientBackground)
				{
					m_colorGradientBackground = value;
					Invalidate(invalidateChildren: false);
				}
			}
		}

		[Description("Gets or sets the height of the XpanderPanels in this XPanderPanelList. ")]
		[DefaultValue(25)]
		[Category("Appearance")]
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

		[Description("The PanelStyleChanged event occurs when PanelStyle flags have been changed.")]
		public event EventHandler<PanelStyleChangeEventArgs> PanelStyleChanged;

		[Description("The CaptionStyleChanged event occurs when CaptionStyle flags have been changed.")]
		public event EventHandler<EventArgs> CaptionStyleChanged;

		[Description("The ColorSchemeChanged event occurs when ColorScheme flags have been changed.")]
		public event EventHandler<ColorSchemeChangeEventArgs> ColorSchemeChanged;

		[Description("Occurs when the value of the CaptionHeight property changes.")]
		public event EventHandler<EventArgs> CaptionHeightChanged;

		public XPanderPanelList()
		{
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: false);
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			InitializeComponent();
			m_xpanderPanels = new XPanderPanelCollection(this);
			ShowBorder = true;
			PanelStyle = PanelStyle.Default;
			LinearGradientMode = LinearGradientMode.Vertical;
			CaptionHeight = 25;
		}

		public void Expand(BasePanel panel)
		{
			if (panel == null)
			{
				throw new ArgumentNullException("panel", string.Format(CultureInfo.InvariantCulture, Resources.IDS_ArgumentException, new object[1]
				{
					"panel"
				}));
			}
			XPanderPanel xPanderPanel = panel as XPanderPanel;
			if (xPanderPanel != null)
			{
				foreach (XPanderPanel xpanderPanel in m_xpanderPanels)
				{
					if (!xpanderPanel.Equals(xPanderPanel))
					{
						xpanderPanel.Expand = false;
					}
				}
				TypeDescriptor.GetProperties(xPanderPanel)["Expand"]?.SetValue(xPanderPanel, true);
			}
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			if (m_bShowGradientBackground)
			{
				Rectangle rect = new Rectangle(0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height);
				using (LinearGradientBrush brush = new LinearGradientBrush(rect, BackColor, GradientBackground, LinearGradientMode))
				{
					pevent.Graphics.FillRectangle(brush, rect);
				}
			}
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			XPanderPanel xPanderPanel = e.Control as XPanderPanel;
			if (xPanderPanel == null)
			{
				throw new InvalidOperationException("Can only add CIT.Client.XPanderPanel");
			}
			if (xPanderPanel.Expand)
			{
				foreach (XPanderPanel xPanderPanel2 in XPanderPanels)
				{
					if (xPanderPanel2 != xPanderPanel)
					{
						xPanderPanel2.Expand = false;
						xPanderPanel2.Height = xPanderPanel.CaptionHeight;
					}
				}
			}
			xPanderPanel.Parent = this;
			xPanderPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			xPanderPanel.Left = base.Padding.Left;
			xPanderPanel.Width = base.ClientRectangle.Width - base.Padding.Left - base.Padding.Right;
			xPanderPanel.PanelStyle = PanelStyle;
			xPanderPanel.ColorScheme = ColorScheme;
			if (PanelColors != null)
			{
				xPanderPanel.SetPanelProperties(PanelColors);
			}
			xPanderPanel.ShowBorder = ShowBorder;
			xPanderPanel.ShowCloseIcon = m_bShowCloseIcon;
			xPanderPanel.ShowExpandIcon = m_bShowExpandIcon;
			xPanderPanel.CaptionStyle = m_captionStyle;
			xPanderPanel.Top = GetTopPosition();
			xPanderPanel.PanelStyleChanged += XpanderPanelPanelStyleChanged;
			xPanderPanel.ExpandClick += XPanderPanelExpandClick;
			xPanderPanel.CloseClick += XPanderPanelCloseClick;
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			XPanderPanel xPanderPanel = e.Control as XPanderPanel;
			if (xPanderPanel != null)
			{
				xPanderPanel.PanelStyleChanged -= XpanderPanelPanelStyleChanged;
				xPanderPanel.ExpandClick -= XPanderPanelExpandClick;
				xPanderPanel.CloseClick -= XPanderPanelCloseClick;
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			int num = 0;
			if (m_xpanderPanels != null)
			{
				foreach (XPanderPanel xpanderPanel in m_xpanderPanels)
				{
					xpanderPanel.Width = base.ClientRectangle.Width - base.Padding.Left - base.Padding.Right;
					if (!xpanderPanel.Visible)
					{
						num -= xpanderPanel.CaptionHeight;
					}
					num += xpanderPanel.CaptionHeight;
				}
				foreach (XPanderPanel xpanderPanel2 in m_xpanderPanels)
				{
					if (xpanderPanel2.Expand)
					{
						xpanderPanel2.Height = base.Height - num - base.Padding.Top - base.Padding.Bottom + xpanderPanel2.CaptionHeight;
						break;
					}
				}
			}
		}

		protected virtual void OnPanelStyleChanged(object sender, PanelStyleChangeEventArgs e)
		{
			PanelStyle panelStyle = e.PanelStyle;
			base.Padding = new Padding(0);
			foreach (XPanderPanel xPanderPanel in XPanderPanels)
			{
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(xPanderPanel);
				if (properties.Count > 0)
				{
					properties["PanelStyle"]?.SetValue(xPanderPanel, panelStyle);
					properties["Left"]?.SetValue(xPanderPanel, base.Padding.Left);
					properties["Width"]?.SetValue(xPanderPanel, base.ClientRectangle.Width - base.Padding.Left - base.Padding.Right);
				}
			}
			if (this.PanelStyleChanged != null)
			{
				this.PanelStyleChanged(sender, e);
			}
		}

		protected virtual void OnColorSchemeChanged(object sender, ColorSchemeChangeEventArgs e)
		{
			ColorScheme colorSchema = e.ColorSchema;
			foreach (XPanderPanel xPanderPanel in XPanderPanels)
			{
				TypeDescriptor.GetProperties(xPanderPanel)["ColorScheme"]?.SetValue(xPanderPanel, colorSchema);
			}
			if (this.ColorSchemeChanged != null)
			{
				this.ColorSchemeChanged(sender, e);
			}
		}

		protected virtual void OnCaptionHeightChanged(object sender, EventArgs e)
		{
			foreach (XPanderPanel xPanderPanel in XPanderPanels)
			{
				TypeDescriptor.GetProperties(xPanderPanel)["CaptionHeight"]?.SetValue(xPanderPanel, m_iCaptionHeight);
			}
			if (this.CaptionHeightChanged != null)
			{
				this.CaptionHeightChanged(sender, e);
			}
		}

		protected virtual void OnCaptionStyleChanged(object sender, EventArgs e)
		{
			foreach (XPanderPanel xPanderPanel in XPanderPanels)
			{
				TypeDescriptor.GetProperties(xPanderPanel)["CaptionStyle"]?.SetValue(xPanderPanel, m_captionStyle);
			}
			if (this.CaptionStyleChanged != null)
			{
				this.CaptionStyleChanged(sender, e);
			}
		}

		private void XPanderPanelExpandClick(object sender, EventArgs e)
		{
			XPanderPanel xPanderPanel = sender as XPanderPanel;
			if (xPanderPanel != null)
			{
				Expand(xPanderPanel);
			}
		}

		private void XPanderPanelCloseClick(object sender, EventArgs e)
		{
			XPanderPanel xPanderPanel = sender as XPanderPanel;
			if (xPanderPanel != null)
			{
				base.Controls.Remove(xPanderPanel);
			}
		}

		private void XpanderPanelPanelStyleChanged(object sender, PanelStyleChangeEventArgs e)
		{
			PanelStyle panelStyle = e.PanelStyle;
			if (panelStyle != m_ePanelStyle)
			{
				PanelStyle = panelStyle;
			}
		}

		private int GetTopPosition()
		{
			int num = base.Padding.Top;
			int num2 = 0;
			IEnumerator enumerator = XPanderPanels.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XPanderPanel xPanderPanel = (XPanderPanel)enumerator.Current;
				if (xPanderPanel.Visible)
				{
					num = ((num2 != base.Padding.Top) ? num2 : base.Padding.Top);
					num2 = num + xPanderPanel.Height;
				}
			}
			return num;
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
			base.Name = "XPanderPanelList";
		}
	}
}
