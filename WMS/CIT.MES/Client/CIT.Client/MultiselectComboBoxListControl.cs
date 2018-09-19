using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxItem(false)]
	public class MultiselectComboBoxListControl : ScrollableControl
	{
		private MultiselectComboBox _CheckBoxComboBox;

		private MultiselectComboBoxItemList _Items = new MultiselectComboBoxItemList();

		public MultiselectComboBoxItemList Items => _Items;

		public MultiselectComboBoxListControl(MultiselectComboBox owner)
		{
			DoubleBuffered = true;
			_CheckBoxComboBox = owner;
			BackColor = SystemColors.Window;
			AutoScroll = true;
			base.ResizeRedraw = true;
			MinimumSize = new Size(1, 1);
			MaximumSize = new Size(500, 500);
		}

		protected override void WndProc(ref Message m)
		{
			if (!(base.Parent.Parent as Popup).ProcessResizing(ref m))
			{
				base.WndProc(ref m);
			}
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			SynchroniseControlsWithComboBoxItems();
			base.OnVisibleChanged(e);
		}

		public void SynchroniseControlsWithComboBoxItems()
		{
			SuspendLayout();
			base.Controls.Clear();
			for (int num = _Items.Count - 1; num >= 0; num--)
			{
				MultiselectComboBoxItem multiselectComboBoxItem = _Items[num];
				if (!_CheckBoxComboBox.Items.Contains(multiselectComboBoxItem.ComboBoxItem))
				{
					_Items.Remove(multiselectComboBoxItem);
					multiselectComboBoxItem.Dispose();
				}
			}
			MultiselectComboBoxItemList multiselectComboBoxItemList = new MultiselectComboBoxItemList();
			foreach (object item in _CheckBoxComboBox.Items)
			{
				MultiselectComboBoxItemList items = _Items;
				Predicate<MultiselectComboBoxItem> match = (MultiselectComboBoxItem t) => t.ComboBoxItem == item;
				MultiselectComboBoxItem multiselectComboBoxItem = items.Find(match);
				if (multiselectComboBoxItem == null)
				{
					multiselectComboBoxItem = new MultiselectComboBoxItem(_CheckBoxComboBox, item);
					multiselectComboBoxItem.ApplyProperties(_CheckBoxComboBox.CheckBoxProperties);
				}
				multiselectComboBoxItemList.Add(multiselectComboBoxItem);
				multiselectComboBoxItem.Dock = DockStyle.Top;
			}
			_Items.Clear();
			_Items.AddRange(multiselectComboBoxItemList);
			if (multiselectComboBoxItemList.Count > 0)
			{
				multiselectComboBoxItemList.Reverse();
				base.Controls.AddRange(multiselectComboBoxItemList.ToArray());
			}
			ResumeLayout();
		}
	}
}
