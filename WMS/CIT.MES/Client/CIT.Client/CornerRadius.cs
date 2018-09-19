namespace CIT.Client
{
	public struct CornerRadius
	{
		public int TopLeft;

		public int TopRight;

		public int BottomLeft;

		public int BottomRigth;

		public CornerRadius(int radius)
		{
			this = new CornerRadius(radius, radius, radius, radius);
		}

		public CornerRadius(int topLeft, int topRight, int bottomLeft, int bottomRight)
		{
			TopLeft = topLeft;
			TopRight = topRight;
			BottomLeft = bottomLeft;
			BottomRigth = bottomRight;
		}
	}
}
