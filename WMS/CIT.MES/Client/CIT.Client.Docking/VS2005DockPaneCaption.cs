using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal class VS2005DockPaneCaption : DockPaneCaptionBase
	{
		private sealed class InertButton : InertButtonBase
		{
			private Bitmap m_image;

			private Bitmap m_imageAutoHide;

			private VS2005DockPaneCaption m_dockPaneCaption;

			private VS2005DockPaneCaption DockPaneCaption => m_dockPaneCaption;

			public bool IsAutoHide => DockPaneCaption.DockPane.IsAutoHide;

			public override Bitmap Image => IsAutoHide ? m_imageAutoHide : m_image;

			public InertButton(VS2005DockPaneCaption dockPaneCaption, Bitmap image, Bitmap imageAutoHide)
			{
				m_dockPaneCaption = dockPaneCaption;
				m_image = image;
				m_imageAutoHide = imageAutoHide;
				RefreshChanges();
			}

			protected override void OnRefreshChanges()
			{
				if (DockPaneCaption.DockPane.DockPanel != null && DockPaneCaption.TextColor != ForeColor)
				{
					ForeColor = DockPaneCaption.TextColor;
					Invalidate();
				}
			}
		}

		private const int _TextGapTop = 2;

		private const int _TextGapBottom = 0;

		private const int _TextGapLeft = 3;

		private const int _TextGapRight = 3;

		private const int _ButtonGapTop = 2;

		private const int _ButtonGapBottom = 1;

		private const int _ButtonGapBetween = 1;

		private const int _ButtonGapLeft = 1;

		private const int _ButtonGapRight = 2;

		private static Bitmap _imageButtonClose;

		private InertButton m_buttonClose;

		private static Bitmap _imageButtonAutoHide;

		private static Bitmap _imageButtonDock;

		private InertButton m_buttonAutoHide;

		private static Bitmap _imageButtonOptions;

		private InertButton m_buttonOptions;

		private IContainer m_components;

		private ToolTip m_toolTip;

		private static string _toolTipClose;

		private static string _toolTipOptions;

		private static string _toolTipAutoHide;

		private static Blend _activeBackColorGradientBlend;

		private static TextFormatFlags _textFormat = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;

		private static Bitmap ImageButtonClose
		{
			get
			{
				if (_imageButtonClose == null)
				{
					_imageButtonClose = Resources.DockPane_Close;
				}
				return _imageButtonClose;
			}
		}

		private InertButton ButtonClose
		{
			get
			{
				if (m_buttonClose == null)
				{
					m_buttonClose = new InertButton(this, ImageButtonClose, ImageButtonClose);
					m_toolTip.SetToolTip(m_buttonClose, ToolTipClose);
					m_buttonClose.Click += Close_Click;
					base.Controls.Add(m_buttonClose);
				}
				return m_buttonClose;
			}
		}

		private static Bitmap ImageButtonAutoHide
		{
			get
			{
				if (_imageButtonAutoHide == null)
				{
					_imageButtonAutoHide = Resources.DockPane_AutoHide;
				}
				return _imageButtonAutoHide;
			}
		}

		private static Bitmap ImageButtonDock
		{
			get
			{
				if (_imageButtonDock == null)
				{
					_imageButtonDock = Resources.DockPane_Dock;
				}
				return _imageButtonDock;
			}
		}

		private InertButton ButtonAutoHide
		{
			get
			{
				if (m_buttonAutoHide == null)
				{
					m_buttonAutoHide = new InertButton(this, ImageButtonDock, ImageButtonAutoHide);
					m_toolTip.SetToolTip(m_buttonAutoHide, ToolTipAutoHide);
					m_buttonAutoHide.Click += AutoHide_Click;
					base.Controls.Add(m_buttonAutoHide);
				}
				return m_buttonAutoHide;
			}
		}

		private static Bitmap ImageButtonOptions
		{
			get
			{
				if (_imageButtonOptions == null)
				{
					_imageButtonOptions = Resources.DockPane_Option;
				}
				return _imageButtonOptions;
			}
		}

		private InertButton ButtonOptions
		{
			get
			{
				if (m_buttonOptions == null)
				{
					m_buttonOptions = new InertButton(this, ImageButtonOptions, ImageButtonOptions);
					m_toolTip.SetToolTip(m_buttonOptions, ToolTipOptions);
					m_buttonOptions.Click += Options_Click;
					base.Controls.Add(m_buttonOptions);
				}
				return m_buttonOptions;
			}
		}

		private IContainer Components => m_components;

		private static int TextGapTop => 2;

		private static Font TextFont => SystemInformation.MenuFont;

		private static int TextGapBottom => 0;

		private static int TextGapLeft => 3;

		private static int TextGapRight => 3;

		private static int ButtonGapTop => 2;

		private static int ButtonGapBottom => 1;

		private static int ButtonGapLeft => 1;

		private static int ButtonGapRight => 2;

		private static int ButtonGapBetween => 1;

		private static string ToolTipClose
		{
			get
			{
				if (_toolTipClose == null)
				{
					_toolTipClose = Strings.DockPaneCaption_ToolTipClose;
				}
				return _toolTipClose;
			}
		}

		private static string ToolTipOptions
		{
			get
			{
				if (_toolTipOptions == null)
				{
					_toolTipOptions = Strings.DockPaneCaption_ToolTipOptions;
				}
				return _toolTipOptions;
			}
		}

		private static string ToolTipAutoHide
		{
			get
			{
				if (_toolTipAutoHide == null)
				{
					_toolTipAutoHide = Strings.DockPaneCaption_ToolTipAutoHide;
				}
				return _toolTipAutoHide;
			}
		}

		private static Blend ActiveBackColorGradientBlend
		{
			get
			{
				if (_activeBackColorGradientBlend == null)
				{
					Blend blend = new Blend(2);
					blend.Factors = new float[2]
					{
						0.5f,
						1f
					};
					blend.Positions = new float[2]
					{
						0f,
						1f
					};
					_activeBackColorGradientBlend = blend;
				}
				return _activeBackColorGradientBlend;
			}
		}

		private Color TextColor
		{
			get
			{
				if (base.DockPane.IsActivated)
				{
					return base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor;
				}
				return base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.TextColor;
			}
		}

		private TextFormatFlags TextFormat
		{
			get
			{
				if (RightToLeft == RightToLeft.No)
				{
					return _textFormat;
				}
				return _textFormat | TextFormatFlags.RightToLeft | TextFormatFlags.Right;
			}
		}

		private bool CloseButtonEnabled => base.DockPane.ActiveContent != null && base.DockPane.ActiveContent.DockHandler.CloseButton;

		private bool CloseButtonVisible => base.DockPane.ActiveContent != null && base.DockPane.ActiveContent.DockHandler.CloseButtonVisible;

		private bool ShouldShowAutoHideButton => !base.DockPane.IsFloat;

		public VS2005DockPaneCaption(DockPane pane)
			: base(pane)
		{
			SuspendLayout();
			m_components = new Container();
			m_toolTip = new ToolTip(Components);
			ResumeLayout();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Components.Dispose();
			}
			base.Dispose(disposing);
		}

		protected internal override int MeasureHeight()
		{
			int num = TextFont.Height + TextGapTop + TextGapBottom;
			if (num < ButtonClose.Image.Height + ButtonGapTop + ButtonGapBottom)
			{
				num = ButtonClose.Image.Height + ButtonGapTop + ButtonGapBottom;
			}
			return num;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			DrawCaption(e.Graphics);
		}

		private void DrawCaption(Graphics g)
		{
			if (base.ClientRectangle.Width != 0 && base.ClientRectangle.Height != 0)
			{
				if (base.DockPane.IsActivated)
				{
					Color startColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.StartColor;
					Color endColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.EndColor;
					LinearGradientMode linearGradientMode = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.LinearGradientMode;
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, startColor, endColor, linearGradientMode))
					{
						linearGradientBrush.Blend = ActiveBackColorGradientBlend;
						g.FillRectangle(linearGradientBrush, base.ClientRectangle);
					}
				}
				else
				{
					Color startColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.StartColor;
					Color endColor = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.EndColor;
					LinearGradientMode linearGradientMode = base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.LinearGradientMode;
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, startColor, endColor, linearGradientMode))
					{
						g.FillRectangle(linearGradientBrush, base.ClientRectangle);
					}
				}
				Rectangle clientRectangle = base.ClientRectangle;
				Rectangle rectangle = clientRectangle;
				rectangle.X += TextGapLeft;
				rectangle.Width -= TextGapLeft + TextGapRight;
				rectangle.Width -= ButtonGapLeft + ButtonClose.Width + ButtonGapRight;
				if (ShouldShowAutoHideButton)
				{
					rectangle.Width -= ButtonAutoHide.Width + ButtonGapBetween;
				}
				if (base.HasTabPageContextMenu)
				{
					rectangle.Width -= ButtonOptions.Width + ButtonGapBetween;
				}
				rectangle.Y += TextGapTop;
				rectangle.Height -= TextGapTop + TextGapBottom;
				TextRenderer.DrawText(foreColor: (!base.DockPane.IsActivated) ? base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.TextColor : base.DockPane.DockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor, dc: g, text: base.DockPane.CaptionText, font: TextFont, bounds: DrawHelper.RtlTransform(this, rectangle), flags: TextFormat);
			}
		}

		protected override void OnLayout(LayoutEventArgs levent)
		{
			SetButtonsPosition();
			base.OnLayout(levent);
		}

		protected override void OnRefreshChanges()
		{
			SetButtons();
			Invalidate();
		}

		private void SetButtons()
		{
			ButtonClose.Enabled = CloseButtonEnabled;
			ButtonClose.Visible = CloseButtonVisible;
			ButtonAutoHide.Visible = ShouldShowAutoHideButton;
			ButtonOptions.Visible = base.HasTabPageContextMenu;
			ButtonClose.RefreshChanges();
			ButtonAutoHide.RefreshChanges();
			ButtonOptions.RefreshChanges();
			SetButtonsPosition();
		}

		private void SetButtonsPosition()
		{
			Rectangle clientRectangle = base.ClientRectangle;
			int num = ButtonClose.Image.Width;
			int num2 = ButtonClose.Image.Height;
			int num3 = clientRectangle.Height - ButtonGapTop - ButtonGapBottom;
			if (num2 < num3)
			{
				num *= num3 / num2;
				num2 = num3;
			}
			Size size = new Size(num, num2);
			int x = clientRectangle.X + clientRectangle.Width - 1 - ButtonGapRight - m_buttonClose.Width;
			int y = clientRectangle.Y + ButtonGapTop;
			Point location = new Point(x, y);
			ButtonClose.Bounds = DrawHelper.RtlTransform(this, new Rectangle(location, size));
			if (CloseButtonVisible)
			{
				location.Offset(-(num + ButtonGapBetween), 0);
			}
			ButtonAutoHide.Bounds = DrawHelper.RtlTransform(this, new Rectangle(location, size));
			if (ShouldShowAutoHideButton)
			{
				location.Offset(-(num + ButtonGapBetween), 0);
			}
			ButtonOptions.Bounds = DrawHelper.RtlTransform(this, new Rectangle(location, size));
		}

		private void Close_Click(object sender, EventArgs e)
		{
			base.DockPane.CloseActiveContent();
		}

		private void AutoHide_Click(object sender, EventArgs e)
		{
			base.DockPane.DockState = DockHelper.ToggleAutoHideState(base.DockPane.DockState);
			if (DockHelper.IsDockStateAutoHide(base.DockPane.DockState))
			{
				base.DockPane.DockPanel.ActiveAutoHideContent = null;
			}
		}

		private void Options_Click(object sender, EventArgs e)
		{
			ShowTabPageContextMenu(PointToClient(Control.MousePosition));
		}

		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			PerformLayout();
		}
	}
}
