using System;

namespace CIT.Client.Docking
{
	public interface IDockContent
	{
		DockContentHandler DockHandler
		{
			get;
		}

		void OnActivated(EventArgs e);

		void OnDeactivate(EventArgs e);
	}
}
