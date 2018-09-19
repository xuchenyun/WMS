using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CIT.Client
{
	[ToolboxItem(false)]
	public class MultiselectComboBoxItemList : List<MultiselectComboBoxItem>
	{
		public event EventHandler CheckBoxCheckedChanged;

		protected void OnCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			this.CheckBoxCheckedChanged?.Invoke(sender, e);
		}

		private void item_CheckedChanged(object sender, EventArgs e)
		{
			OnCheckBoxCheckedChanged(sender, e);
		}

		[Obsolete("Do not add items to this list directly. Use the ComboBox items instead.", false)]
		public new void Add(MultiselectComboBoxItem item)
		{
			item.CheckedChanged += item_CheckedChanged;
			base.Add(item);
		}

		public new void AddRange(IEnumerable<MultiselectComboBoxItem> collection)
		{
			foreach (MultiselectComboBoxItem item in collection)
			{
				item.CheckedChanged += item_CheckedChanged;
			}
			base.AddRange(collection);
		}

		public new void Clear()
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MultiselectComboBoxItem current = enumerator.Current;
					current.CheckedChanged -= item_CheckedChanged;
				}
			}
			base.Clear();
		}

		[Obsolete("Do not remove items from this list directly. Use the ComboBox items instead.", false)]
		public new bool Remove(MultiselectComboBoxItem item)
		{
			item.CheckedChanged -= item_CheckedChanged;
			return base.Remove(item);
		}
	}
}
