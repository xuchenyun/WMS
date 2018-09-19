using System;
using System.ComponentModel;
using System.Globalization;

namespace CIT.Client.Docking
{
	public class AutoHideStripConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(AutoHideStripSkin))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is AutoHideStripSkin)
			{
				return "AutoHideStripSkin";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
