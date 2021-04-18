using System;

namespace Drawer
{
	/// <summary>
	/// Represents a algorithmic pattern, including repetition of the alive-state-function
	/// Could be used for non fixed patterns
	/// </summary>
	public class EndlessPattern : Pattern
	{
		/// <summary>
		/// Alive-state function - set <see cref="Cell.Alive"/> state by index in a CellMatrix 
		/// </summary>
		public Func<(int i, int j), bool> GetValue { get; protected set; }

		public EndlessPattern() : this((0, 0))
		{
		}

		public EndlessPattern((int X, int Y) anchor)
			: base(anchor)
		{
		}

		public EndlessPattern((int X, int Y) anchor, Func<(int i, int j), bool> getAliveStateByIndex)
			: this(anchor)
		{
			GetValue = getAliveStateByIndex;
		}


		public static EndlessPattern XPattern
		{
			get
			{
				var pattern = new EndlessPattern() { Name = "X" };
				pattern.GetValue = index => index.i - (pattern.Anchor.Y - pattern.Anchor.X) == index.j || index.i + index.j == pattern.Anchor.X + pattern.Anchor.Y;
				return pattern;
			}
		}
	}
}

