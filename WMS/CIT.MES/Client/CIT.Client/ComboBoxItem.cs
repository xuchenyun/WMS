namespace CIT.Client
{
	public class ComboBoxItem
	{
		public string Text
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}

		public ComboBoxItem(string text, string value)
		{
			Text = text;
			Value = value;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
