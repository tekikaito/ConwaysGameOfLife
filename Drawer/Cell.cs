﻿using System;
using System.Drawing;

namespace Drawer
{
	public class Cell
	{
		#region fields
		private bool _alive;
		#endregion


		#region properties
		public Rectangle Rectangle { get; set; }
		public Brush Color { get; set; }
		public bool Alive { get => _alive; set => SetAlive(value); } 
		public bool DrawFlag { get; set; }
		#endregion



		#region methods
		public Cell(int xPos, int yPos, int cellWidth, bool alive)
		{
			Rectangle = new Rectangle(xPos, yPos, cellWidth, cellWidth);
			SetAlive(alive);
		}
		
		private void SetAlive(bool val)
		{
			_alive = val;
			Color = val ? Brushes.White : Brushes.Black;
		}

		public void Draw(Graphics gfx)
		{
			gfx?.FillRectangle(Color, Rectangle);
		}
		#endregion
	}
}
