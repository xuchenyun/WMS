using System;
using System.ComponentModel;
using System.Globalization;

namespace CIT.Client.Docking
{
	public class DockPaneStripGradientConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(DockPaneStripGradient))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is DockPaneStripGradient)
			{
				return "DockPaneStripGradient";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
