using System;
using System.Drawing;

namespace CIT.Client
{
	public class BtnEventArgs : EventArgs
	{
		private Rectangle _Bounds;

		public Rectangle Bounds => _Bounds;

		public BtnEventArgs(Rectangle bounds)
		{
			_Bounds = bounds;
		}
	}
}
