using System.Linq;
using System.Runtime.CompilerServices;

namespace Drawer
{
	/// <summary>
	/// Represents a set of defined anchor and offset-pixels, allowing to create fixed Patterns like Gliders
	/// </summary>
	public class FixedPattern : Pattern
	{	
		/// <summary>
		/// Offset Points
		/// <para>Points reltative to the offset of the preset Anchor (0, 0)</para>
		/// </summary>
		public (int X, int Y)[] Offsets { get; private set; }

		/// <summary>
		/// <see cref="Offsets"/> + <see cref="Pattern.Anchor"/>
		/// </summary>
		public (int X, int Y)[] Indices => Offsets?
			.Select(off => (off.X + Anchor.X, off.Y + Anchor.Y))
			.Concat(new (int X, int Y)[] { Anchor })?
			.ToArray();


		#region ctor
		public FixedPattern(string name, params (int X, int Y)[] offsets)
			:base((0, 0))
		{
			Name = name;
			Offsets = offsets;
		} 
		#endregion


		#region statics
		public static FixedPattern Glider =>
			GetPreset(new (int, int)[] { (1, 0), (2, 0), (2, 1), (1, 2) });


		static FixedPattern GetPreset((int, int)[] offsets, [CallerMemberName] string name = null)
			=> new FixedPattern(name, offsets); 
		#endregion
	}
}
