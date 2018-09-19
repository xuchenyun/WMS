using System;

namespace CIT.Client
{
	internal struct WINDOWPOS
	{
		public IntPtr hwnd;

		public IntPtr hWndInsertAfter;

		public int x;

		public int y;

		public int cx;

		public int cy;

		public uint flags;
	}
}
