namespace Drawer
{
	public abstract class Pattern
	{
		/// <summary>
		/// Anchor-Position of the Drawable
		/// </summary>
		public (int X, int Y) Anchor { get; set; }

		/// <summary>
		/// Name of the preset
		/// </summary>
		public string Name { get; set; }

		public Pattern((int X, int Y) anchor)
		{
			Anchor = anchor;
		}
	}
}
