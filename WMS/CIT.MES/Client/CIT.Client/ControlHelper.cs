using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	public class ControlHelper
	{
		public const string NA = "0.0";

		public static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
		{
			TextFormatFlags textFormatFlags = TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;
			if (rightToleft)
			{
				textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.RightToLeft);
			}
			switch (alignment)
			{
			case ContentAlignment.BottomCenter:
				textFormatFlags |= (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
				break;
			case ContentAlignment.BottomLeft:
				textFormatFlags |= TextFormatFlags.Bottom;
				break;
			case ContentAlignment.BottomRight:
				textFormatFlags |= (TextFormatFlags.Bottom | TextFormatFlags.Right);
				break;
			case ContentAlignment.MiddleCenter:
				textFormatFlags |= (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
				break;
			case ContentAlignment.MiddleLeft:
				textFormatFlags |= TextFormatFlags.VerticalCenter;
				break;
			case ContentAlignment.MiddleRight:
				textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
				break;
			case ContentAlignment.TopCenter:
				textFormatFlags |= TextFormatFlags.HorizontalCenter;
				break;
			case ContentAlignment.TopLeft:
				textFormatFlags = textFormatFlags;
				break;
			case ContentAlignment.TopRight:
				textFormatFlags |= TextFormatFlags.Right;
				break;
			}
			return textFormatFlags;
		}

		public static void BindMouseMoveEvent(Control control)
		{
			if (control != null)
			{
				control.MouseDown += delegate
				{
					Win32.ReleaseCapture();
					BaseForm baseForm = control.FindForm() as BaseForm;
					if (baseForm != null && baseForm.CaptionHeight > 0 && baseForm.WindowState != FormWindowState.Maximized)
					{
						Win32.SendMessage(control.FindForm().Handle, 274, 61458, 0);
					}
				};
			}
		}
	}
}
