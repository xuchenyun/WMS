using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CIT.Client
{
	public class ucButton : Button
	{
		private enum MouseActionType
		{
			None,
			Hover,
			Click
		}

		private MouseActionType mouseAction;

		private ImageAttributes imgAttr = new ImageAttributes();

		private Bitmap buttonBitmap;

		private Rectangle buttonBitmapRectangle;

		private IContainer components = null;

		public ucButton()
		{
			InitializeComponent();
			mouseAction = MouseActionType.None;
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			Font = new Font("宋体", 12f);
			BackColor = Color.DarkTurquoise;
			base.Size = new Size(112, 48);
		}

		private GraphicsPath GetGraphicsPath(Rectangle rc, int r)
		{
			int x = rc.X;
			int y = rc.Y;
			int width = rc.Width;
			int height = rc.Height;
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(x, y, r, r, 180f, 90f);
			graphicsPath.AddArc(x + width - r, y, r, r, 270f, 90f);
			graphicsPath.AddArc(x + width - r, y + height - r, r, r, 0f, 90f);
			graphicsPath.AddArc(x, y + height - r, r, r, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.Clear(SystemColors.ButtonFace);
			Color color = BackColor;
			int num = 8;
			int num2 = 0;
			switch (mouseAction)
			{
			case MouseActionType.Click:
				num = 4;
				color = Color.LightGray;
				num2 = 4;
				break;
			case MouseActionType.Hover:
				color = Color.LightGray;
				break;
			}
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Rectangle rectangle = new Rectangle(num2, num2, base.ClientSize.Width - 8 - num2, base.ClientSize.Height - 8 - num2);
			GraphicsPath graphicsPath = GetGraphicsPath(rectangle, 20);
			LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, rectangle.Height + 6), color, Color.White);
			Rectangle rc = rectangle;
			rc.Offset(num, num);
			GraphicsPath graphicsPath2 = GetGraphicsPath(rc, 20);
			PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath2);
			pathGradientBrush.CenterColor = Color.Black;
			pathGradientBrush.SurroundColors = new Color[1]
			{
				SystemColors.ButtonFace
			};
			Rectangle rectangle2 = rectangle;
			rectangle2.Inflate(-5, -5);
			rectangle2.Height = 15;
			GraphicsPath graphicsPath3 = GetGraphicsPath(rectangle2, 20);
			LinearGradientBrush brush2 = new LinearGradientBrush(rectangle2, Color.FromArgb(255, Color.White), Color.FromArgb(0, Color.White), LinearGradientMode.Vertical);
			graphics.FillPath(pathGradientBrush, graphicsPath2);
			graphics.FillPath(brush, graphicsPath);
			graphics.FillPath(brush2, graphicsPath3);
			buttonBitmapRectangle = new Rectangle(rectangle.Location, rectangle.Size);
			buttonBitmap = new Bitmap(buttonBitmapRectangle.Width, buttonBitmapRectangle.Height);
			Graphics graphics2 = Graphics.FromImage(buttonBitmap);
			graphics2.SmoothingMode = SmoothingMode.AntiAlias;
			graphics2.FillPath(brush, graphicsPath);
			graphics2.FillPath(brush2, graphicsPath3);
			Region region = new Region(graphicsPath);
			region.Union(graphicsPath2);
			base.Region = region;
			GraphicsPath graphicsPath4 = new GraphicsPath();
			RectangleF bounds = graphicsPath.GetBounds();
			Rectangle layoutRect = new Rectangle((int)bounds.X + num2, (int)bounds.Y + num2, (int)bounds.Width, (int)bounds.Height);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			graphicsPath4.AddString(Text, Font.FontFamily, (int)Font.Style, Font.Size, layoutRect, stringFormat);
			Pen pen = new Pen(ForeColor, 1f);
			graphics.DrawPath(pen, graphicsPath4);
			graphics2.DrawPath(pen, graphicsPath4);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mouseAction = MouseActionType.Click;
				Invalidate();
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			mouseAction = MouseActionType.Hover;
			Invalidate();
			base.OnMouseUp(e);
		}

		protected override void OnMouseHover(EventArgs e)
		{
			mouseAction = MouseActionType.Hover;
			Invalidate();
			base.OnMouseHover(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			mouseAction = MouseActionType.Hover;
			Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			mouseAction = MouseActionType.None;
			Invalidate();
			base.OnMouseLeave(e);
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
