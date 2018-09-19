using System.Drawing;

namespace CIT.Client
{
	public class LinearColor
	{
		public Color First;

		public Color Second;

		public LinearColor(Color color1, Color color2)
		{
			First = color1;
			Second = color2;
		}
	}
}
