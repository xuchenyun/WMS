using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CIT.Client
{
	internal class Win32
	{
		public static readonly IntPtr TRUE = new IntPtr(1);

		public static readonly IntPtr FALSE = IntPtr.Zero;

		[DllImport("user32")]
		public static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetWindowDC(IntPtr handle);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll", EntryPoint = "SendMessageA")]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref RECT lParam);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hwnd, int msg, int wParam, ref HDITEM lParam);

		[DllImport("user32.dll")]
		public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref ComboBoxInfo info);

		[DllImport("user32.dll")]
		public static extern int SetWindowRgn(IntPtr hwnd, int hRgn, bool bRedraw);

		[DllImport("user32.dll")]
		public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

		[DllImport("gdi32.dll")]
		public static extern int CreateRoundRectRgn(int x1, int y1, int x2, int y2, int x3, int y3);

		[DllImport("user32.dll")]
		public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

		[DllImport("user32.dll")]
		public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT ps);

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

		[DllImport("user32.dll")]
		public static extern short GetKeyState(int nVirtKey);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(ref Point lpPoint);

		[DllImport("user32.dll")]
		public static extern int OffsetRect(ref RECT lpRect, int x, int y);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PtInRect([In] ref RECT lprc, Point pt);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool IsWindowVisible(IntPtr hwnd);

		[DllImport("user32.dll")]
		public static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr handle);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
		public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLongPtr")]
		public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr GetActiveWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool GetWindowRect(HandleRef hWnd, [In] [Out] ref RECT rect);

		[DllImport("user32.dll")]
		public static extern int ShowScrollBar(IntPtr hWnd, int iBar, int bShow);

		public static int LOWORD(int value)
		{
			return value & 0xFFFF;
		}

		public static int HIWORD(int value)
		{
			return value >> 16;
		}

		public static IntPtr GetWindowLong(HandleRef hWnd, int nIndex)
		{
			if (IntPtr.Size == 4)
			{
				return GetWindowLong32(hWnd, nIndex);
			}
			return GetWindowLongPtr64(hWnd, nIndex);
		}
	}
}
