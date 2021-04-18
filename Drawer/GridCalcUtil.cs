using System;
using System.Collections.Generic;

namespace Drawer
{
	public static class GridCalcUtil
	{
		/// <summary>
		/// Calculate Points between two points P1 and P2
		/// </summary>
		/// <param name="P1">Point P1</param>
		/// <param name="P2">Point P2</param>
		/// <returns>points between</returns>
		public static IEnumerable<(int X, int Y)> GetLineCoords((int X, int Y) P1, (int X, int Y) P2)
		{
			// calculate deltas
			var dx = P2.X - P1.X;
			var dy = P2.Y - P1.Y;

			// calculate which delta is responsible for the amount of steps
			var steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

			// calculate increment values
			var xInc = dx / (float)steps;
			var yInc = dy / (float)steps;

			float X = P1.X, Y = P1.Y;
			for (int i = 0; i <= steps; i++)
			{
				yield return ((int)X, (int)Y);
				X += xInc;
				Y += yInc;
			}
		}

		/// <summary>
		/// Gets the cell index in a grid
		/// </summary>
		/// <param name="mouseX">X Position of the control</param>
		/// <param name="mouseY">Y Position of the control</param>
		/// <param name="xResolution">x Resloution of the grid (cellwidth)</param>
		/// <param name="yResolution">y Resolution of the grid (cellheight)</param>
		/// <returns>Index in the grid</returns>
		public static (int X, int Y) GetIndexByPixelPosition(int controlX, int controlY, int xResolution, int yResolution)
		{
			return (controlX / xResolution, controlY / yResolution);
		}
	}
}
