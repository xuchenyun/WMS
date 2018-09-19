using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TX.Framework;
using TX.Framework.Helper;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(ComboBox))]
	public class TXComboBox : ComboBox
	{
		private EnumControlState _ControlState;

		private IntPtr _EditHandle = IntPtr.Zero;

		private int _Margin = 2;

		private bool _BeginPainting = false;

		private int _CornerRadius = 0;

		private Color _BackColor = Color.White;

		private IContainer components = null;

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

		private object Value
		{
			get
			{
				ComboBoxItem comboBoxItem = base.SelectedItem as ComboBoxItem;
				if (comboBoxItem == null)
				{
					return string.Empty;
				}
				return comboBoxItem.Value;
			}
		}

		public TXComboBox()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			UpdateStyles();
			base.Size = new Size(150, 20);
			_ControlState = EnumControlState.Default;
		}

		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 15)
			{
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
			}
			else
			{
				base.WndProc(ref m);
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
			RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
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
			Rectangle rect = new Rectangle(ButtonRect.X - 2, ButtonRect.Y - 1, ButtonRect.Width + 1 + _Margin, ButtonRect.Height + 2);
			RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(0, _CornerRadius, 0, _CornerRadius));
			Blend blend = new Blend(3);
			blend.Positions = new float[3]
			{
				0f,
				0.5f,
				1f
			};
			blend.Factors = new float[3]
			{
				0f,
				1f,
				0f
			};
			GDIHelper.FillRectangle(g, roundRect, SkinManager.CurrentSkin.DefaultControlColor);
			Size arrowSize = new Size(12, 7);
			System.Windows.Forms.ArrowDirection direction = System.Windows.Forms.ArrowDirection.Down;
			GDIHelper.DrawArrow(g, direction, rect, arrowSize, 0f, Color.FromArgb(30, 178, 239));
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

		public DateTime ToDateTime()
		{
			return TX.Framework.Convert.ToDateTime(Value);
		}

		public DateTime? ToDateTimeOrNull()
		{
			return TX.Framework.Convert.ToDateTimeOrNull(Value);
		}

		public Guid ToGuid()
		{
			return TX.Framework.Convert.ToGuid(Value);
		}

		public int ToInt()
		{
			return TX.Framework.Convert.ToInt(Value);
		}

		public long ToLong()
		{
			return TX.Framework.Convert.ToLong(Value);
		}

		public override string ToString()
		{
			return TX.Framework.Convert.ToString(Value);
		}

		public bool ToBool()
		{
			return TX.Framework.Convert.ToBool(Value);
		}

		public float ToFloat()
		{
			return TX.Framework.Convert.ToFloat(Value);
		}

		public double ToDouble()
		{
			return TX.Framework.Convert.ToDouble(Value);
		}

		public double ToDouble(int decimals)
		{
			return TX.Framework.Convert.ToDouble(Value, decimals);
		}

		public decimal ToDecimal()
		{
			return TX.Framework.Convert.ToDecimal(Value);
		}

		public decimal ToDecimal(int decimals)
		{
			return TX.Framework.Convert.ToDecimal(Value, decimals);
		}

		public T ConvertTo<T>()
		{
			return TX.Framework.Convert.ConvertTo<T>(Value);
		}

		public T ToEnum<T>()
		{
			return TX.Framework.Helper.Enum.GetInstance<T>(Value);
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
