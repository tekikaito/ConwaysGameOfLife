using System;
using System.Drawing;

namespace Drawer
{
	public class Cell
	{
		#region fields
		private bool _alive; 
		#endregion

		public Rectangle Rectangle { get; set; }
		public Brush Color { get; set; }

		public bool Alive { get => _alive; set => SetAlive(value); }

		private void SetAlive(bool val)
		{
			_alive = val;
			Color = val ? Brushes.White : Brushes.Black;
		}

		public Cell(int xPos, int yPos, int cellWidth, bool alive)
		{
			Rectangle = new Rectangle(xPos, yPos, cellWidth, cellWidth);
			SetAlive(alive);
		}
	}
}
