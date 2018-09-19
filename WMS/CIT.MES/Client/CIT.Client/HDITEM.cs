using System;

namespace CIT.Client
{
	internal struct HDITEM
	{
		internal int mask;

		internal int cxy;

		internal IntPtr pszText;

		internal IntPtr hbm;

		internal int cchTextMax;

		internal int fmt;

		internal IntPtr lParam;

		internal int iImage;

		internal int iOrder;

		internal uint type;

		internal IntPtr pvFilter;
	}
}
