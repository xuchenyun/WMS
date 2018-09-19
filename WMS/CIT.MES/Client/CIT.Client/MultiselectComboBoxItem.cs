using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxItem(false)]
	public class MultiselectComboBoxItem : TXCheckBox
	{
		private MultiselectComboBox _CheckBoxComboBox;

		private object _ComboBoxItem;

		public object ComboBoxItem => _ComboBoxItem;

		public MultiselectComboBoxItem(MultiselectComboBox owner, object comboBoxItem)
		{
			DoubleBuffered = true;
			_CheckBoxComboBox = owner;
			_ComboBoxItem = comboBoxItem;
			base.CornerRadius = 0;
			if (_CheckBoxComboBox.DataSource != null)
			{
				AddBindings();
			}
			else
			{
				Text = comboBoxItem.ToString();
			}
		}

		public void AddBindings()
		{
			base.DataBindings.Add("Text", _ComboBoxItem, _CheckBoxComboBox.DisplayMemberSingleItem);
			base.DataBindings.Add("Checked", _ComboBoxItem, _CheckBoxComboBox.ValueMember, formattingEnabled: false, DataSourceUpdateMode.OnPropertyChanged, false, null, null);
		}

		protected override void OnCheckedChanged(EventArgs e)
		{
			if (_CheckBoxComboBox.DataSource != null)
			{
				PropertyInfo property = ComboBoxItem.GetType().GetProperty(_CheckBoxComboBox.ValueMember);
				property.SetValue(ComboBoxItem, base.Checked, null);
			}
			base.OnCheckedChanged(e);
			if (_CheckBoxComboBox.DataSource != null)
			{
				string displayMember = _CheckBoxComboBox.DisplayMember;
				_CheckBoxComboBox.DisplayMember = null;
				_CheckBoxComboBox.DisplayMember = displayMember;
			}
		}

		internal void ApplyProperties(CheckBoxProperties properties)
		{
			base.Appearance = properties.Appearance;
			base.AutoCheck = properties.AutoCheck;
			base.AutoEllipsis = properties.AutoEllipsis;
			AutoSize = properties.AutoSize;
			base.CheckAlign = properties.CheckAlign;
			base.FlatAppearance.BorderColor = properties.FlatAppearanceBorderColor;
			base.FlatAppearance.BorderSize = properties.FlatAppearanceBorderSize;
			base.FlatAppearance.CheckedBackColor = properties.FlatAppearanceCheckedBackColor;
			base.FlatAppearance.MouseDownBackColor = properties.FlatAppearanceMouseDownBackColor;
			base.FlatAppearance.MouseOverBackColor = properties.FlatAppearanceMouseOverBackColor;
			base.FlatStyle = properties.FlatStyle;
			ForeColor = properties.ForeColor;
			base.RightToLeft = properties.RightToLeft;
			base.TextAlign = properties.TextAlign;
			base.ThreeState = properties.ThreeState;
		}
	}
}
