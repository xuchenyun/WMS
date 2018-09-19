namespace CIT.Client
{
	public interface IPanel
	{
		PanelStyle PanelStyle
		{
			get;
			set;
		}

		ColorScheme ColorScheme
		{
			get;
			set;
		}

		bool ShowBorder
		{
			get;
			set;
		}

		bool ShowExpandIcon
		{
			get;
			set;
		}

		bool ShowCloseIcon
		{
			get;
			set;
		}

		bool Expand
		{
			get;
			set;
		}
	}
}
