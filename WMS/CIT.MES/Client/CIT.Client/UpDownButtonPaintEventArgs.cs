using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	public class UpDownButtonPaintEventArgs : PaintEventArgs
	{
		private bool _mouseOver;

		private bool _mousePress;

		private bool _mouseInUpButton;

		public bool MouseOver => _mouseOver;

		public bool MousePress => _mousePress;

		public bool MouseInUpButton => _mouseInUpButton;

		public UpDownButtonPaintEventArgs(Graphics graphics, Rectangle clipRect, bool mouseOver, bool mousePress, bool mouseInUpButton)
			: base(graphics, clipRect)
		{
			_mouseOver = mouseOver;
			_mousePress = mousePress;
			_mouseInUpButton = mouseInUpButton;
		}
	}
}
