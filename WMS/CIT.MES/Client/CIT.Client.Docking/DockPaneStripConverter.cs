using System;
using System.ComponentModel;
using System.Globalization;

namespace CIT.Client.Docking
{
	public class DockPaneStripConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(DockPaneStripSkin))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is DockPaneStripSkin)
			{
				return "DockPaneStripSkin";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
