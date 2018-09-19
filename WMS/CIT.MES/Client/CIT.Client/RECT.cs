using System.Drawing;

namespace CIT.Client
{
	internal struct RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;

		public Rectangle Rect => new Rectangle(left, top, right - left, bottom - top);

		public RECT(int left, int top, int right, int bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		public RECT(Rectangle rect)
		{
			left = rect.Left;
			right = rect.Right;
			top = rect.Top;
			bottom = rect.Bottom;
		}

		public static RECT FromXYWH(int x, int y, int width, int height)
		{
			return new RECT(x, y, x + width, y + height);
		}

		public static RECT FromRectangle(Rectangle rect)
		{
			return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
		}
	}
}
