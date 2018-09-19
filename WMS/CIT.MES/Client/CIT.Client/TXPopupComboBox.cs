using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxItem(false)]
	public class TXPopupComboBox : PopupComboBox
	{
		private IntPtr _EditHandle = IntPtr.Zero;

		private int _Margin = 2;

		private bool _BeginPainting = false;

		private Color _BackColor = Color.White;

		internal Rectangle ButtonRect => GetDropDownButtonRect();

		internal Rectangle EditRect
		{
			get
			{
				if (base.DropDownStyle == ComboBoxStyle.DropDownList)
				{
					Rectangle result = new Rectangle(_Margin, _Margin, base.Width - ButtonRect.Width - _Margin * 2, base.Height - _Margin * 2);
					if (RightToLeft == RightToLeft.Yes)
					{
						result.X += ButtonRect.Right;
					}
					return result;
				}
				if (base.IsHandleCreated && _EditHandle != IntPtr.Zero)
				{
					RECT lpRect = default(RECT);
					Win32.GetWindowRect(_EditHandle, ref lpRect);
					return RectangleToClient(lpRect.Rect);
				}
				return Rectangle.Empty;
			}
		}

		public TXPopupComboBox()
		{
			base.Size = new Size(150, 20);
			base.DropDownStyle = ComboBoxStyle.DropDown;
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 522:
				break;
			case 15:
				switch (base.DropDownStyle)
				{
				case ComboBoxStyle.DropDown:
					if (!_BeginPainting)
					{
						PAINTSTRUCT ps = default(PAINTSTRUCT);
						_BeginPainting = true;
						Win32.BeginPaint(m.HWnd, ref ps);
						DrawComboBox(ref m);
						Win32.EndPaint(m.HWnd, ref ps);
						_BeginPainting = false;
						m.Result = Win32.TRUE;
					}
					else
					{
						base.WndProc(ref m);
					}
					break;
				case ComboBoxStyle.DropDownList:
					base.WndProc(ref m);
					DrawComboBox(ref m);
					break;
				default:
					base.WndProc(ref m);
					break;
				}
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void DrawComboBox(ref Message msg)
		{
			using (Graphics g = Graphics.FromHwnd(msg.HWnd))
			{
				DrawComboBox(g);
			}
		}

		private void DrawComboBox(Graphics g)
		{
			GDIHelper.InitializeGraphics(g);
			Rectangle rect = new Rectangle(Point.Empty, base.Size);
			rect.Width--;
			rect.Height--;
			RoundRectangle roundRect = new RoundRectangle(rect, 0);
			Color color = base.Enabled ? _BackColor : SystemColors.Control;
			g.SetClip(EditRect, CombineMode.Exclude);
			GDIHelper.FillRectangle(g, roundRect, color);
			g.ResetClip();
			DrawButton(g);
			GDIHelper.DrawPathBorder(g, roundRect);
		}

		private void DrawButton(Graphics g)
		{
			EnumControlState enumControlState = (!GetComboBoxButtonPressed()) ? EnumControlState.Default : EnumControlState.HeightLight;
			Rectangle rect = new Rectangle(ButtonRect.X, ButtonRect.Y - 1, ButtonRect.Width + 1 + _Margin, ButtonRect.Height + 2);
			RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(0));
			GDIHelper.FillRectangle(g, roundRect, SkinManager.CurrentSkin.DefaultControlColor);
			GDIHelper.DrawArrow(arrowSize: new Size(12, 7), g: g, direction: System.Windows.Forms.ArrowDirection.Down, rect: rect, offset: 0f, c: Color.FromArgb(30, 178, 239));
			Color borderColor = SkinManager.CurrentSkin.BorderColor;
			GDIHelper.DrawGradientLine(g, borderColor, 90, rect.X, rect.Y, rect.X, rect.Bottom - 1);
		}

		private ComboBoxInfo GetComboBoxInfo()
		{
			ComboBoxInfo info = default(ComboBoxInfo);
			info.cbSize = Marshal.SizeOf((object)info);
			Win32.GetComboBoxInfo(base.Handle, ref info);
			return info;
		}

		private bool GetComboBoxButtonPressed()
		{
			ComboBoxInfo comboBoxInfo = GetComboBoxInfo();
			return comboBoxInfo.stateButton == ComboBoxButtonState.STATE_SYSTEM_PRESSED;
		}

		private Rectangle GetDropDownButtonRect()
		{
			ComboBoxInfo comboBoxInfo = GetComboBoxInfo();
			return comboBoxInfo.rcButton.Rect;
		}
	}
}
