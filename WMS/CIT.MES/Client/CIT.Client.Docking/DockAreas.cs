using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CIT.Client.Docking
{
	[Serializable]
	[Flags]
	[Editor(typeof(DockAreasEditor), typeof(UITypeEditor))]
	public enum DockAreas
	{
		Float = 0x1,
		DockLeft = 0x2,
		DockRight = 0x4,
		DockTop = 0x8,
		DockBottom = 0x10,
		Document = 0x20
	}
}
