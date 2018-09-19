using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(GroupBox))]
	public class TXGroupBox : GroupBox
	{
		private int _CornerRadius = 6;

		private int _BorderWidth = 1;

		private Color _BorderColor = SkinManager.CurrentSkin.BorderColor;

		private int _TextMargin = 6;

		private EnumBorderStyle _BorderStyle = EnumBorderStyle.Default;

		private Font _CaptionFont = new Font("宋体", 9f, FontStyle.Bold);

		private Color _CaptionColor = Color.Black;

		private IContainer components = null;

		[DefaultValue(6)]
		[Description("圆角值")]
		[Category("TXProperties")]
		public int CornerRadius
		{
			get
			{
				return _CornerRadius;
			}
			set
			{
				_CornerRadius = ((value > 0) ? value : 0);
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Description("标题字体")]
		public Font CaptionFont
		{
			get
			{
				return _CaptionFont;
			}
			set
			{
				_CaptionFont = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[Description("标题颜色")]
		[Category("TXProperties")]
		public Color CaptionColor
		{
			get
			{
				return _CaptionColor;
			}
			set
			{
				_CaptionColor = value;
				Invalidate(invalidateChildren: true);
			}
		}

		[DefaultValue(1)]
		[Category("TXProperties")]
		[Description("边框宽度")]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = ((value <= 1) ? 1 : value);
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Description("边框颜色")]
		public Color BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
				Invalidate();
			}
		}

		[Description("文本的边距")]
		[Category("TXProperties")]
		[DefaultValue(3)]
		public int TextMargin
		{
			get
			{
				return _TextMargin;
			}
			set
			{
				_TextMargin = ((value > _CornerRadius) ? value : _CornerRadius);
				Invalidate();
			}
		}

		[Description("边框样式")]
		[DefaultValue(typeof(EnumBorderStyle), "Default")]
		[Category("TXProperties")]
		public EnumBorderStyle BorderStyle
		{
			get
			{
				return _BorderStyle;
			}
			set
			{
				_BorderStyle = value;
				Invalidate();
			}
		}

		public TXGroupBox()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, value: true);
			UpdateStyles();
			base.BackColor = Color.Transparent;
			ControlHelper.BindMouseMoveEvent(this);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			base.OnPaintBackground(e);
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			Rectangle textRect = GetTextRect(graphics);
			Color foreColor = base.Enabled ? _CaptionColor : SkinManager.CurrentSkin.UselessColor;
			switch (_BorderStyle)
			{
			case EnumBorderStyle.QQStyle:
				DrawQQStyleBorder(graphics, textRect);
				break;
			case EnumBorderStyle.Default:
				DrawDefaultBorder(graphics, textRect);
				break;
			}
			TextRenderer.DrawText(graphics, Text, _CaptionFont, textRect, foreColor, TextFormatFlags.Default);
		}

		private Rectangle GetTextRect(Graphics g)
		{
			Rectangle result = default(Rectangle);
			Size size = g.MeasureString(Text, _CaptionFont).ToSize();
			switch (_BorderStyle)
			{
			case EnumBorderStyle.None:
			case EnumBorderStyle.Default:
				result.X = base.ClientRectangle.X + _TextMargin;
				result.Y = 0;
				result.Height = size.Height;
				result.Width = size.Width + 1;
				break;
			case EnumBorderStyle.QQStyle:
				result.X = 0;
				result.Y = 0;
				result.Width = size.Width + 1;
				result.Height = size.Height;
				break;
			}
			return result;
		}

		private void DrawDefaultBorder(Graphics g, Rectangle textRect)
		{
			Rectangle rect = default(Rectangle);
			rect.X = 0;
			rect.Y = textRect.Height / 2;
			rect.Height = base.Height - textRect.Height / 2 - 1;
			rect.Width = base.Width - 1;
			RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
			g.SetClip(textRect, CombineMode.Exclude);
			GDIHelper.DrawPathBorder(g, roundRect, _BorderColor, _BorderWidth);
			g.ResetClip();
		}

		private void DrawQQStyleBorder(Graphics g, Rectangle textRect)
		{
			Color borderColor = _BorderColor;
			Color color = Color.FromArgb(20, borderColor);
			Rectangle rect = new Rectangle(textRect.Right + _TextMargin, textRect.Height / 2, base.Width - textRect.Right - _TextMargin, _BorderWidth);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, borderColor, color, 180f))
			{
				Blend blend = new Blend();
				blend.Positions = new float[3]
				{
					0f,
					0.2f,
					1f
				};
				blend.Factors = new float[3]
				{
					1f,
					0.6f,
					0.2f
				};
				linearGradientBrush.Blend = blend;
				using (Pen pen = new Pen(linearGradientBrush, (float)_BorderWidth))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
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
		}
	}
}
