using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(RadioButton))]
	public class TXRadioButton : RadioButton
	{
		private EnumControlState _ControlState;

		private int _MaxRadius = 8;

		private int _MinRadius = 4;

		private int _Margin = 2;

		private IContainer components = null;

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
				return new Size(22, 22);
			}
			set
			{
				base.MinimumSize = new Size(22, 22);
			}
		}

		[DefaultValue("8")]
		[Category("TXProperties")]
		[Description("外圆半径值")]
		public int MaxRadius
		{
			get
			{
				return _MaxRadius;
			}
			set
			{
				_MaxRadius = ((value >= 3) ? value : 3);
				Invalidate();
			}
		}

		[Description("内圆半径值")]
		[DefaultValue("4")]
		[Category("TXProperties")]
		public int MinRadius
		{
			get
			{
				return _MinRadius;
			}
			set
			{
				_MinRadius = ((value < 1) ? 1 : value);
				Invalidate();
			}
		}

		public TXRadioButton()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, value: true);
			UpdateStyles();
			base.MinimumSize = new Size(22, 22);
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
				if (base.ClientRectangle.Contains(e.Location))
				{
					_ControlState = EnumControlState.HeightLight;
				}
				else
				{
					_ControlState = EnumControlState.Default;
				}
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
			Rectangle rect = new Rectangle(_Margin, height / 2 - _MaxRadius, _MaxRadius * 2, _MaxRadius * 2);
			Rectangle rect2 = new Rectangle(_Margin + _MaxRadius - _MinRadius, height / 2 - _MinRadius, _MinRadius * 2, _MinRadius * 2);
			Size size = g.MeasureString(Text, Font).ToSize();
			Rectangle bounds = default(Rectangle);
			bounds.X = rect.Right + _Margin;
			bounds.Y = height / 2 - size.Height / 2 + 1;
			bounds.Height = size.Height;
			bounds.Width = base.Width - bounds.Left;
			GDIHelper.DrawEllipseBorder(g, rect, SkinManager.CurrentSkin.BorderColor, 2);
			GDIHelper.FillEllipse(g, rect2, SkinManager.CurrentSkin.DefaultControlColor.First);
			GDIHelper.DrawEllipseBorder(g, rect2, SkinManager.CurrentSkin.BorderColor, 1);
			switch (_ControlState)
			{
			case EnumControlState.HeightLight:
			case EnumControlState.Focused:
				rect.Inflate(1, 1);
				GDIHelper.DrawEllipseBorder(g, rect, SkinManager.CurrentSkin.OuterBorderColor, 1);
				rect.Inflate(-2, -2);
				GDIHelper.DrawEllipseBorder(g, rect, SkinManager.CurrentSkin.InnerBorderColor, 1);
				break;
			}
			Color foreColor = base.Enabled ? ForeColor : SkinManager.CurrentSkin.UselessColor;
			TextRenderer.DrawText(g, Text, Font, bounds, foreColor, TextFormatFlags.Default);
			if (base.Checked)
			{
				GDIHelper.FillEllipse(g, rect2, Color.FromArgb(15, 216, 32), Color.Green);
				foreColor = SkinManager.CurrentSkin.BorderColor;
				GDIHelper.DrawEllipseBorder(g, rect2, foreColor, 1);
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
