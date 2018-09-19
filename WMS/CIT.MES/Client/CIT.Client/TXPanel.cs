using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(Panel))]
	public class TXPanel : Panel
	{
		private int _CornerRadius = 8;

		private int _BorderWidth = 1;

		private Color _BorderColor = SkinManager.CurrentSkin.BorderColor;

		private Color _BackBeginColor = Color.White;

		private Color _BackEndColor = Color.White;

		private IContainer components = null;

		[Description("圆角值")]
		[DefaultValue(8)]
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

		[DefaultValue(typeof(Color), "White")]
		[Category("TXProperties")]
		[Description("背景色1")]
		public Color BackBeginColor
		{
			get
			{
				return _BackBeginColor;
			}
			set
			{
				_BackBeginColor = value;
				Invalidate();
			}
		}

		[Description("背景色2")]
		[Category("TXProperties")]
		[DefaultValue(typeof(Color), "White")]
		public Color BackEndColor
		{
			get
			{
				return _BackEndColor;
			}
			set
			{
				_BackEndColor = value;
				Invalidate();
			}
		}

		[Description("边框宽度，若为0则无边框")]
		[DefaultValue(1)]
		[Category("TXProperties")]
		public int BorderWidth
		{
			get
			{
				return _BorderWidth;
			}
			set
			{
				_BorderWidth = ((value > 0) ? value : 0);
				Invalidate();
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
				Invalidate();
			}
		}

		[Browsable(false)]
		public new BorderStyle BorderStyle
		{
			get;
			set;
		}

		public TXPanel()
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			UpdateStyles();
			base.BackColor = Color.Transparent;
			ControlHelper.BindMouseMoveEvent(this);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			int num = (BorderWidth > 0) ? BorderWidth : 0;
			Graphics graphics = e.Graphics;
			GDIHelper.InitializeGraphics(graphics);
			GradientColor color = new GradientColor(_BackBeginColor, _BackEndColor, null, null);
			Rectangle rect = new Rectangle(0, 0, base.Size.Width - 1, base.Size.Height - 1);
			RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
			GDIHelper.FillRectangle(graphics, roundRect, color);
			if (_BorderWidth > 0)
			{
				rect.X += _BorderWidth - 1;
				rect.Y += _BorderWidth - 1;
				rect.Width -= _BorderWidth - 1;
				rect.Height -= _BorderWidth - 1;
				GDIHelper.DrawPathBorder(graphics, new RoundRectangle(rect, new CornerRadius(_CornerRadius)), _BorderColor, BorderWidth);
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
