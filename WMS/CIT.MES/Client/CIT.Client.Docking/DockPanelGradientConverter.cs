using System;
using System.ComponentModel;
using System.Globalization;

namespace CIT.Client.Docking
{
	public class DockPanelGradientConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(DockPanelGradient))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is DockPanelGradient)
			{
				return "DockPanelGradient";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
