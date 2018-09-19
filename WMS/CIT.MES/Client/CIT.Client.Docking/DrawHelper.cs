using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal static class DrawHelper
	{
		public static Point RtlTransform(Control control, Point point)
		{
			if (control.RightToLeft != RightToLeft.Yes)
			{
				return point;
			}
			return new Point(control.Right - point.X, point.Y);
		}

		public static Rectangle RtlTransform(Control control, Rectangle rectangle)
		{
			if (control.RightToLeft != RightToLeft.Yes)
			{
				return rectangle;
			}
			return new Rectangle(control.ClientRectangle.Right - rectangle.Right, rectangle.Y, rectangle.Width, rectangle.Height);
		}

		public static GraphicsPath GetRoundedCornerTab(GraphicsPath graphicsPath, Rectangle rect, bool upCorner)
		{
			if (graphicsPath == null)
			{
				graphicsPath = new GraphicsPath();
			}
			else
			{
				graphicsPath.Reset();
			}
			int num = 6;
			if (upCorner)
			{
				graphicsPath.AddLine(rect.Left, rect.Bottom, rect.Left, rect.Top + num / 2);
				graphicsPath.AddArc(new Rectangle(rect.Left, rect.Top, num, num), 180f, 90f);
				graphicsPath.AddLine(rect.Left + num / 2, rect.Top, rect.Right - num / 2, rect.Top);
				graphicsPath.AddArc(new Rectangle(rect.Right - num, rect.Top, num, num), -90f, 90f);
				graphicsPath.AddLine(rect.Right, rect.Top + num / 2, rect.Right, rect.Bottom);
			}
			else
			{
				graphicsPath.AddLine(rect.Right, rect.Top, rect.Right, rect.Bottom - num / 2);
				graphicsPath.AddArc(new Rectangle(rect.Right - num, rect.Bottom - num, num, num), 0f, 90f);
				graphicsPath.AddLine(rect.Right - num / 2, rect.Bottom, rect.Left + num / 2, rect.Bottom);
				graphicsPath.AddArc(new Rectangle(rect.Left, rect.Bottom - num, num, num), 90f, 90f);
				graphicsPath.AddLine(rect.Left, rect.Bottom - num / 2, rect.Left, rect.Top);
			}
			return graphicsPath;
		}

		public static GraphicsPath CalculateGraphicsPathFromBitmap(Bitmap bitmap)
		{
			return CalculateGraphicsPathFromBitmap(bitmap, Color.Empty);
		}

		public static GraphicsPath CalculateGraphicsPathFromBitmap(Bitmap bitmap, Color colorTransparent)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (colorTransparent == Color.Empty)
			{
				colorTransparent = bitmap.GetPixel(0, 0);
			}
			for (int i = 0; i < bitmap.Height; i++)
			{
				int num = 0;
				for (int j = 0; j < bitmap.Width; j++)
				{
					if (bitmap.GetPixel(j, i) != colorTransparent)
					{
						num = j;
						int num2 = j;
						for (num2 = num; num2 < bitmap.Width && !(bitmap.GetPixel(num2, i) == colorTransparent); num2++)
						{
						}
						graphicsPath.AddRectangle(new Rectangle(num, i, num2 - num, 1));
						j = num2;
					}
				}
			}
			return graphicsPath;
		}
	}
}
