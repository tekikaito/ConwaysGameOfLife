using System.Drawing;

namespace Drawer
{
	public class CellPattern
	{
		public string Name { get; set; }
		public Point[] Offsets { get; private set; }


		public CellPattern(string name, params Point[] offsets)
		{
			Name = name;
			Offsets = offsets;
		}
	}
}
