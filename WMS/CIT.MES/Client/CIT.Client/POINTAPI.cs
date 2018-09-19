using System.Drawing;

namespace CIT.Client
{
	internal struct POINTAPI
	{
		public int X;

		public int Y;

		public POINTAPI(Point p)
		{
			X = p.X;
			Y = p.Y;
		}

		public POINTAPI(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
