using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(CheckBox))]
	public class TXCheckBox : CheckBox
	{
		private EnumControlState _ControlState;

		private Size _BoxSize = new Size(14, 14);

		private int _CornerRadius = 1;

		private int _Margin = 2;

		private IContainer components = null;

		[Category("TXProperties")]
		[Description("圆角的半径值")]
		[DefaultValue(1)]
		public int CornerRadius
		{
			get
			{
				return _CornerRadius;
			}
			set
			{
				_CornerRadius = value;
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[Description("复选框的大小")]
		[DefaultValue(typeof(Size), "14,14")]
		public Size BoxSize
		{
			get
			{
				return _BoxSize;
			}
			set
			{
				_BoxSize = value;
				Invalidate();
			}
		}

		[Browsable(false)]
		public new RightToLeft RightToLeft
		{
			get
			{
				return RightToLeft.No;
			}
			set
			{
				base.RightToLeft = RightToLeft.No;
			}
		}

		[Browsable(false)]
		public new ContentAlignment TextAlign
		{
			get
			{
				return ContentAlignment.MiddleLeft;
			}
			set
			{
				base.TextAlign = ContentAlignment.MiddleLeft;
			}
		}

		[Browsable(false)]
		public new Size MinimumSize
		{
			get
			{
				return new Size(20, 20);
			}
			set
			{
				base.MinimumSize = new Size(20, 20);
			}
		}

		public TXCheckBox()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, value: true);
			UpdateStyles();
			MinimumSize = new Size(20, 20);
			_ControlState = EnumControlState.Default;
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			_ControlState = EnumControlState.HeightLight;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			_ControlState = EnumControlState.Default;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				_ControlState = EnumControlState.Focused;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				_ControlState = EnumControlState.Default;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			base.OnPaintBackground(e);
			DrawContent(e.Graphics);
		}

		private void DrawContent(Graphics g)
		{
			GDIHelper.InitializeGraphics(g);
			int width = base.Width;
			int height = base.Height;
			Rectangle rectangle = new Rectangle(_Margin, height / 2 - _BoxSize.Height / 2, _BoxSize.Width, _BoxSize.Height);
			Size size = g.MeasureString(Text, Font).ToSize();
			Rectangle rect = default(Rectangle);
			rect.X = rectangle.Right + _Margin;
			rect.Y = _Margin;
			rect.Height = base.Height - _Margin * 2;
			rect.Width = size.Width;
			RoundRectangle roundRect = new RoundRectangle(rectangle, _CornerRadius);
			EnumControlState controlState = _ControlState;
			if (controlState == EnumControlState.HeightLight)
			{
				GDIHelper.DrawPathBorder(g, roundRect, SkinManager.CurrentSkin.OuterBorderColor);
				GDIHelper.DrawPathInnerBorder(g, roundRect, SkinManager.CurrentSkin.HeightLightControlColor.First);
			}
			else
			{
				GDIHelper.DrawCheckBox(g, roundRect);
			}
			Color forceColor = base.Enabled ? ForeColor : SkinManager.CurrentSkin.UselessColor;
			GDIHelper.DrawImageAndString(g, rect, null, Size.Empty, Text, Font, forceColor);
			switch (base.CheckState)
			{
			case CheckState.Checked:
				GDIHelper.DrawCheckedStateByImage(g, rectangle);
				break;
			case CheckState.Indeterminate:
			{
				Rectangle rect2 = rectangle;
				rect2.Inflate(-3, -3);
				Color color = Color.FromArgb(46, 117, 35);
				GDIHelper.FillRectangle(g, new RoundRectangle(rect2, _CornerRadius), color);
				break;
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
