using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(DateTimePicker))]
	public class TXDateTimePicker : DateTimePicker
	{
		private int _Margin = 2;

		private int _CornerRadius = 0;

		private Color _BackColor = Color.White;

		private bool DroppedDown = false;

		private int InvalidateSince = 0;

		private IContainer components = null;

		[Browsable(true)]
		[Description("获取或者设置控件的事件日期时间值")]
		[Category("TXProperties")]
		public new DateTime? Value
		{
			get
			{
				if (base.Checked)
				{
					return base.Value;
				}
				return null;
			}
			set
			{
				if (!value.HasValue || value == DateTime.MinValue || value == DateTime.MaxValue)
				{
					base.ShowCheckBox = true;
					base.Checked = false;
					base.Value = DateTime.Now;
				}
				else
				{
					base.Value = value.Value;
				}
			}
		}

		internal Rectangle ButtonRect => GetDropDownButtonRect();

		[Browsable(false)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
		}

		[Browsable(false)]
		public new RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
		}

		public TXDateTimePicker()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			UpdateStyles();
			base.Size = new Size(150, 20);
			base.CalendarForeColor = Color.Blue;
			base.CalendarTrailingForeColor = Color.CadetBlue;
			base.CalendarMonthBackground = SkinManager.CurrentSkin.DefaultControlColor.First;
			base.CalendarTitleBackColor = SkinManager.CurrentSkin.CaptionColor.First;
			base.ShowCheckBox = true;
			base.Checked = true;
		}

		protected override void OnDropDown(EventArgs eventargs)
		{
			InvalidateSince = 0;
			DroppedDown = true;
			base.OnDropDown(eventargs);
		}

		protected override void OnCloseUp(EventArgs eventargs)
		{
			DroppedDown = false;
			base.OnCloseUp(eventargs);
			Invalidate(ButtonRect);
		}

		protected override void WndProc(ref Message m)
		{
			IntPtr zero = IntPtr.Zero;
			Graphics graphics = null;
			switch (m.Msg)
			{
			case 133:
				zero = Win32.GetWindowDC(m.HWnd);
				Win32.SendMessage(base.Handle, 20, zero, 0);
				SendPrintClientMsg();
				m.Result = Win32.TRUE;
				Win32.ReleaseDC(m.HWnd, zero);
				break;
			case 15:
				base.WndProc(ref m);
				zero = Win32.GetWindowDC(m.HWnd);
				graphics = Graphics.FromHdc(zero);
				DrawButton(graphics);
				DrawComboBoxBorder(graphics);
				Win32.ReleaseDC(m.HWnd, zero);
				graphics.Dispose();
				break;
			case 32:
				base.WndProc(ref m);
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		private void SendPrintClientMsg()
		{
			Graphics graphics = CreateGraphics();
			IntPtr hdc = graphics.GetHdc();
			Win32.SendMessage(base.Handle, 792, hdc, 0);
			graphics.ReleaseHdc(hdc);
			graphics.Dispose();
		}

		private void DrawComboBoxBorder(Graphics g)
		{
			GDIHelper.InitializeGraphics(g);
			Rectangle rect = new Rectangle(Point.Empty, base.Size);
			rect.Width--;
			rect.Height--;
			using (Pen pen = new Pen(SkinManager.CurrentSkin.BorderColor, 1f))
			{
				g.DrawRectangle(pen, rect);
			}
		}

		private void DrawButton(Graphics g)
		{
			GDIHelper.InitializeGraphics(g);
			RoundRectangle roundRectangle = new RoundRectangle(ButtonRect, 0);
			Color color = base.Enabled ? _BackColor : SystemColors.Control;
		}

		private Rectangle GetDropDownButtonRect()
		{
			ComboBox comboBox = new ComboBox();
			ComboBoxInfo info = default(ComboBoxInfo);
			info.cbSize = Marshal.SizeOf((object)info);
			Win32.GetComboBoxInfo(comboBox.Handle, ref info);
			comboBox.Dispose();
			int width = info.rcButton.Rect.Width;
			return new Rectangle(base.Width - width - _Margin * 2, _Margin, base.Height - _Margin, base.Height - _Margin * 2);
		}

		private void ResetRegion()
		{
			if (_CornerRadius > 0)
			{
				Rectangle rect = new Rectangle(Point.Empty, base.Size);
				RoundRectangle roundRectangle = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
				if (base.Region != null)
				{
					base.Region.Dispose();
				}
				base.Region = new Region(roundRectangle.ToGraphicsBezierPath());
			}
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
