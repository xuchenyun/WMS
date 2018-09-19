using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(Button))]
	[DefaultEvent("Click")]
	public class TXButton : Button
	{
		private int _CornerRadius = 2;

		private int _Margin = 4;

		private Size _ImageSize = new Size(16, 16);

		private EnumControlState _ControlState;

		[DefaultValue(2)]
		[Description("圆角的半径值")]
		[Category("TXProperties")]
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

		[Browsable(true)]
		[Description("图标大小")]
		[Category("TXProperties")]
		[DefaultValue(typeof(Size), "16,16")]
		public Size ImageSize
		{
			get
			{
				return _ImageSize;
			}
			set
			{
				_ImageSize = value;
				Invalidate();
			}
		}

		[Description("图标")]
		[Category("TXProperties")]
		[Browsable(true)]
		public new Image Image
		{
			get
			{
				return base.Image;
			}
			set
			{
				base.Image = value;
				Invalidate();
			}
		}

		[Category("TXProperties")]
		[DefaultValue(typeof(TextImageRelation), "ImageBeforeText")]
		[Browsable(true)]
		public new TextImageRelation TextImageRelation
		{
			get
			{
				return base.TextImageRelation;
			}
			set
			{
				base.TextImageRelation = value;
			}
		}

		[Browsable(false)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
		}

		[Browsable(false)]
		public new ContentAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
		}

		[Browsable(false)]
		public new ContentAlignment ImageAlign
		{
			get
			{
				return base.ImageAlign;
			}
		}

		public TXButton()
		{
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			_ControlState = EnumControlState.Default;
			base.TextImageRelation = TextImageRelation.ImageBeforeText;
			base.Size = new Size(100, 28);
			ResetRegion();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			_ControlState = EnumControlState.HeightLight;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				_ControlState = EnumControlState.Focused;
				Invalidate();
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			_ControlState = EnumControlState.Default;
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left)
			{
				_ControlState = EnumControlState.HeightLight;
				Invalidate();
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Space)
			{
				_ControlState = EnumControlState.Focused;
				Invalidate();
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (e.KeyCode == Keys.Space)
			{
				_ControlState = EnumControlState.Default;
				Invalidate();
				OnClick(e);
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			_ControlState = EnumControlState.HeightLight;
			Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			_ControlState = EnumControlState.Default;
			Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ResetRegion();
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			ResetRegion();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			base.OnPaintBackground(e);
			ResetRegion();
			Graphics graphics = e.Graphics;
			DrawBackGround(graphics);
			DrawContent(graphics);
		}

		private void DrawBackGround(Graphics g)
		{
			GDIHelper.InitializeGraphics(g);
			Rectangle rect = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
			RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
			switch (_ControlState)
			{
			case EnumControlState.Default:
				if (base.FlatStyle != 0)
				{
					GDIHelper.FillRectangle(g, roundRect, SkinManager.CurrentSkin.DefaultControlColor);
					GDIHelper.DrawPathBorder(g, roundRect);
				}
				break;
			case EnumControlState.HeightLight:
				GDIHelper.FillRectangle(g, roundRect, SkinManager.CurrentSkin.HeightLightControlColor);
				GDIHelper.DrawPathBorder(g, roundRect);
				break;
			case EnumControlState.Focused:
				GDIHelper.FillRectangle(g, roundRect, SkinManager.CurrentSkin.FocusedControlColor);
				GDIHelper.DrawPathBorder(g, roundRect);
				GDIHelper.DrawPathInnerBorder(g, roundRect);
				break;
			}
		}

		private void DrawContent(Graphics g)
		{
            Rectangle imageRect;
            Rectangle textRect;

            CalculateRect(out imageRect, out textRect);
			if (Image != null)
			{
				g.DrawImage(Image, imageRect, 0, 0, _ImageSize.Width, _ImageSize.Height, GraphicsUnit.Pixel);
			}
			Color foreColor = base.Enabled ? ForeColor : SkinManager.CurrentSkin.UselessColor;
			TextRenderer.DrawText(g, Text, Font, textRect, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
		}

		private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
		{
			imageRect = Rectangle.Empty;
			textRect = Rectangle.Empty;
			if (Image == null)
			{
				textRect = new Rectangle(_Margin, _Margin, base.Width - _Margin * 2, base.Height - _Margin * 2);
			}
			else
			{
				Size size = TextRenderer.MeasureText(Text, Font);
				int num = base.Width - _ImageSize.Width - _Margin * 3;
				int num2 = (size.Width >= num) ? num : size.Width;
				int num3 = _Margin + _ImageSize.Width + num2;
				switch (TextImageRelation)
				{
				case TextImageRelation.Overlay:
					imageRect = new Rectangle(_Margin, (base.Height - _ImageSize.Height) / 2, _ImageSize.Width, _ImageSize.Height);
					textRect = new Rectangle(_Margin, _Margin, base.Width - _Margin * 2, base.Height);
					break;
				case TextImageRelation.ImageAboveText:
					imageRect = new Rectangle((base.Width - _ImageSize.Width) / 2, _Margin, _ImageSize.Width, _ImageSize.Height);
					textRect = new Rectangle(_Margin, imageRect.Bottom, base.Width - _Margin * 2, base.Height - imageRect.Bottom - _Margin);
					break;
				case TextImageRelation.ImageBeforeText:
					imageRect = new Rectangle((base.Width - num3) / 2, (base.Height - _ImageSize.Height) / 2, _ImageSize.Width, _ImageSize.Height);
					textRect = new Rectangle(imageRect.Right + _Margin, _Margin, num2, base.Height - _Margin * 2);
					break;
				case TextImageRelation.TextAboveImage:
					imageRect = new Rectangle((base.Width - _ImageSize.Width) / 2, base.Height - _ImageSize.Height - _Margin, _ImageSize.Width, _ImageSize.Height);
					textRect = new Rectangle(_Margin, _Margin, base.Width - _Margin * 2, base.Height - imageRect.Y - _Margin);
					break;
				case TextImageRelation.TextBeforeImage:
					imageRect = new Rectangle((base.Width + num3) / 2 - _ImageSize.Width, (base.Height - _ImageSize.Height) / 2, _ImageSize.Width, _ImageSize.Height);
					textRect = new Rectangle((base.Width - num3) / 2, _Margin, num2, base.Height - _Margin * 2);
					break;
				}
				if (RightToLeft == RightToLeft.Yes)
				{
					imageRect.X = base.Width - imageRect.Right;
					textRect.X = base.Width - textRect.Right;
				}
			}
		}

		private void ResetRegion()
		{
			if (_CornerRadius > 0)
			{
				Rectangle rect = new Rectangle(Point.Empty, base.Size);
				RoundRectangle roundRectangle = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
				if (base.Region != null)
				{
					base.Region.Dispose();
				}
				base.Region = new Region(roundRectangle.ToGraphicsBezierPath());
			}
		}
	}
}
