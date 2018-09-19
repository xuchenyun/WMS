using System.Drawing;

namespace CIT.Client
{
	public struct GradientColor
	{
		public Color First;

		public Color Second;

		public float[] Factors;

		public float[] Positions;

		public GradientColor(Color color1, Color color2, float[] factors, float[] positions)
		{
			First = color1;
			Second = color2;
			Factors = ((factors == null) ? new float[0] : factors);
			Positions = ((positions == null) ? new float[0] : positions);
		}
	}
}
