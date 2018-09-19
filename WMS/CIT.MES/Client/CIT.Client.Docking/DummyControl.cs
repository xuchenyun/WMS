using System.Windows.Forms;

namespace CIT.Client.Docking
{
	internal class DummyControl : Control
	{
		public DummyControl()
		{
			SetStyle(ControlStyles.Selectable, value: false);
		}
	}
}
