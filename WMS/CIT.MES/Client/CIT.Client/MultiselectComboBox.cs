using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CIT.Client
{
	[ToolboxBitmap(typeof(ComboBox))]
	[ToolboxItem(true)]
	public class MultiselectComboBox : TXPopupComboBox
	{
		private MultiselectComboBoxListControl _CheckBoxComboBoxListControl;

		private string _DisplayMemberSingleItem = null;

		private CheckBoxProperties _CheckBoxProperties;

		private IContainer components = null;

		[Description("The properties that will be assigned to the checkboxes as default values.")]
		[Browsable(true)]
		public CheckBoxProperties CheckBoxProperties
		{
			get
			{
				return _CheckBoxProperties;
			}
			set
			{
				_CheckBoxProperties = value;
				_CheckBoxProperties_PropertyChanged(this, EventArgs.Empty);
			}
		}

		[Browsable(false)]
		public MultiselectComboBoxItemList CheckBoxItems
		{
			get
			{
				return _CheckBoxComboBoxListControl.Items;
			}
		}

		public new object DataSource
		{
			get
			{
				return base.DataSource;
			}
			set
			{
				base.DataSource = value;
				if (!string.IsNullOrEmpty(ValueMember))
				{
					_CheckBoxComboBoxListControl.SynchroniseControlsWithComboBoxItems();
				}
			}
		}

		public new string ValueMember
		{
			get
			{
				return base.ValueMember;
			}
			set
			{
				base.ValueMember = value;
				if (!string.IsNullOrEmpty(ValueMember))
				{
					_CheckBoxComboBoxListControl.SynchroniseControlsWithComboBoxItems();
				}
			}
		}

		public string DisplayMemberSingleItem
		{
			get
			{
				if (string.IsNullOrEmpty(_DisplayMemberSingleItem))
				{
					return base.DisplayMember;
				}
				return _DisplayMemberSingleItem;
			}
			set
			{
				_DisplayMemberSingleItem = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(true)]
		public new ObjectCollection Items
		{
			get
			{
				return base.Items;
			}
		}

		public event EventHandler CheckBoxCheckedChanged;

		public MultiselectComboBox()
		{
			InitializeComponent();
			_CheckBoxProperties = new CheckBoxProperties();
			_CheckBoxProperties.PropertyChanged += _CheckBoxProperties_PropertyChanged;
			_CheckBoxComboBoxListControl = new MultiselectComboBoxListControl(this);
			_CheckBoxComboBoxListControl.Items.CheckBoxCheckedChanged += Items_CheckBoxCheckedChanged;
			_CheckBoxComboBoxListControl.Dock = DockStyle.Fill;
			base.DropDownControl = new MultiselectComboBoxListControlContainer
			{
				Padding = new Padding(4, 0, 0, 14),
				Controls = 
				{
					(Control)_CheckBoxComboBoxListControl
				}
			};
			PopupDropDown.Resizable = true;
			base.Click += MultiselectComboBox_Click;
		}

		private void MultiselectComboBox_Click(object sender, EventArgs e)
		{
			ShowDropDown();
		}

		private void Items_CheckBoxCheckedChanged(object sender, EventArgs e)
		{
			OnCheckBoxCheckedChanged(sender, e);
		}

		protected void OnCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (base.DropDownStyle != ComboBoxStyle.DropDownList)
			{
				string text = string.Empty;
				foreach (MultiselectComboBoxItem item in _CheckBoxComboBoxListControl.Items)
				{
					if (item.Checked)
					{
						text += (string.IsNullOrEmpty(text) ? item.Text : $", {item.Text}");
					}
				}
				Text = text;
			}
			this.CheckBoxCheckedChanged?.Invoke(sender, e);
		}

		protected override void OnResize(EventArgs e)
		{
			if (base.DropDownControl != null)
			{
				Size size = new Size(base.Width, base.DropDownControl.Height);
				PopupDropDown.Size = size;
			}
			base.OnResize(e);
		}

		public void ClearSelection()
		{
			foreach (MultiselectComboBoxItem checkBoxItem in CheckBoxItems)
			{
				if (checkBoxItem.Checked)
				{
					checkBoxItem.Checked = false;
				}
			}
		}

		public void UpdateText()
		{
			string text = string.Empty;
			foreach (MultiselectComboBoxItem item in _CheckBoxComboBoxListControl.Items)
			{
				if (item.Checked)
				{
					text += (string.IsNullOrEmpty(text) ? item.Text : $", {item.Text}");
				}
			}
			Text = text;
		}

		private void _CheckBoxProperties_PropertyChanged(object sender, EventArgs e)
		{
			foreach (MultiselectComboBoxItem checkBoxItem in CheckBoxItems)
			{
				checkBoxItem.ApplyProperties(CheckBoxProperties);
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
