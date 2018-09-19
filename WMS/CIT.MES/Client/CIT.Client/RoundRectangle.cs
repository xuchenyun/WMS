using System.Drawing;
using System.Drawing.Drawing2D;

namespace CIT.Client
{
	public class RoundRectangle
	{
		public Rectangle Rect
		{
			get;
			set;
		}

		public CornerRadius CornerRadius
		{
			get;
			set;
		}

		public RoundRectangle(Rectangle rect, int radius)
			: this(rect, new CornerRadius(radius))
		{
		}

		public RoundRectangle(Rectangle rect, CornerRadius cornerRadius)
		{
			Rect = rect;
			CornerRadius = cornerRadius;
		}

		public GraphicsPath ToGraphicsBezierPath()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int x = Rect.X;
			int y = Rect.Y;
			int width = Rect.Width;
			int height = Rect.Height;
			graphicsPath.AddBezier(x, y + CornerRadius.TopLeft, x, y, x + CornerRadius.TopLeft, y, x + CornerRadius.TopLeft, y);
			graphicsPath.AddLine(x + CornerRadius.TopLeft, y, x + width - CornerRadius.TopRight, y);
			graphicsPath.AddBezier(x + width - CornerRadius.TopRight, y, x + width, y, x + width, y + CornerRadius.TopRight, x + width, y + CornerRadius.TopRight);
			graphicsPath.AddLine(x + width, y + CornerRadius.TopRight, x + width, y + height - CornerRadius.BottomRigth);
			graphicsPath.AddBezier(x + width, y + height - CornerRadius.BottomRigth, x + width, y + height, x + width - CornerRadius.BottomRigth, y + height, x + width - CornerRadius.BottomRigth, y + height);
			graphicsPath.AddLine(x + width - CornerRadius.BottomRigth, y + height, x + CornerRadius.BottomLeft, y + height);
			graphicsPath.AddBezier(x + CornerRadius.BottomLeft, y + height, x, y + height, x, y + height - CornerRadius.BottomLeft, x, y + height - CornerRadius.BottomLeft);
			graphicsPath.AddLine(x, y + height - CornerRadius.BottomLeft, x, y + CornerRadius.TopLeft);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		public GraphicsPath ToGraphicsArcPath()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int x = Rect.X;
			int y = Rect.Y;
			int width = Rect.Width;
			int height = Rect.Height;
			graphicsPath.AddArc(x, y, CornerRadius.TopLeft, CornerRadius.TopLeft, 180f, 90f);
			graphicsPath.AddArc(x + width - CornerRadius.TopRight, y, CornerRadius.TopRight, CornerRadius.TopRight, 270f, 90f);
			graphicsPath.AddArc(x + width - CornerRadius.BottomRigth, y + height - CornerRadius.BottomRigth, CornerRadius.BottomRigth, CornerRadius.BottomRigth, 0f, 90f);
			graphicsPath.AddArc(x, y + height - CornerRadius.BottomLeft, CornerRadius.BottomLeft, CornerRadius.BottomLeft, 90f, 90f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}

		public GraphicsPath ToGraphicsAnglesWingPath()
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int x = Rect.X;
			int y = Rect.Y;
			int width = Rect.Width;
			int height = Rect.Height;
			graphicsPath.AddBezier(x, y + CornerRadius.TopLeft, x, y, x + CornerRadius.TopLeft, y, x + CornerRadius.TopLeft, y);
			graphicsPath.AddLine(x + CornerRadius.TopLeft, y, x + width - CornerRadius.TopRight, y);
			graphicsPath.AddBezier(x + width - CornerRadius.TopRight, y, x + width, y, x + width, y + CornerRadius.TopRight, x + width, y + CornerRadius.TopRight);
			graphicsPath.AddLine(x + width, y + CornerRadius.TopRight, x + width, y + height - CornerRadius.BottomRigth);
			graphicsPath.AddBezier(x + width, y + height - CornerRadius.BottomRigth, x + width, y + height, x + width + CornerRadius.BottomRigth, y + height, x + width + CornerRadius.BottomRigth, y + height);
			graphicsPath.AddLine(x + width + CornerRadius.BottomRigth, y + height, x - CornerRadius.BottomLeft, y + height);
			graphicsPath.AddBezier(x - CornerRadius.BottomLeft, y + height, x, y + height, x, y + height - CornerRadius.BottomLeft, x, y + height - CornerRadius.BottomLeft);
			graphicsPath.AddLine(x, y + height - CornerRadius.BottomLeft, x, y + CornerRadius.TopLeft);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
	}
}
