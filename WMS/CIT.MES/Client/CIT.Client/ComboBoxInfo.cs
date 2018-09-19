using System;

namespace CIT.Client
{
	internal struct ComboBoxInfo
	{
		public int cbSize;

		public RECT rcItem;

		public RECT rcButton;

		public ComboBoxButtonState stateButton;

		public IntPtr hwndCombo;

		public IntPtr hwndEdit;

		public IntPtr hwndList;
	}
}
