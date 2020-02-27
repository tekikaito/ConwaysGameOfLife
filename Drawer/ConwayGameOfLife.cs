﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Drawer
{
	public class ConwayGameOfLife
	{
		#region fields
		private Control _displayControl;
		private bool _update;
		private bool _mouseDown;
		private int _mouseX;
		private int _mouseY;
		private int _cellWidth;
		#endregion


		#region properties
		public Cell[,] Cells { get; private set; }
		public int XCellAmount { get; private set; }
		public int YCellAmount { get; private set; }
		public bool IsPaused => !_update;
		#endregion


		#region ctor
		public ConwayGameOfLife(Control displayControl)
		{
			_displayControl = displayControl;
			_displayControl.Paint += OnPaint;
			_displayControl.MouseDown += OnMouseDown;
			_displayControl.MouseUp += OnMouseUp;
			_displayControl.MouseMove += OnMouseMove;
		}
		#endregion


		#region methods
		/// <summary>
		/// Initialize the gamefield
		/// </summary>
		/// <param name="cellWidth">edgelength for the square cells</param>
		/// <param name="randomCells">should a random pattern of living cells be generated</param>
		/// <param name="spawnChancePercent">spawnchance for living cells</param>
		public void Initialize(int cellWidth, int spawnChancePercent = 0)
		{
			if (cellWidth <= 0) return;

			_cellWidth = cellWidth;
			XCellAmount = _displayControl.Width / cellWidth;
			YCellAmount = _displayControl.Height / cellWidth;

			Cells = new Cell[XCellAmount, YCellAmount];
			var rnd = new Random();

			for (int i = 0; i < XCellAmount; i++)
				for (int j = 0; j < YCellAmount; j++)
					Cells[i, j] = new Cell(i * cellWidth, j * cellWidth, cellWidth, spawnChancePercent != 0 ? rnd?.Next(100) <= spawnChancePercent - 1 : false);

			InitializeLoopTimer();
			_displayControl?.Invalidate();
		}

		/// <summary>
		/// Draws an X with its center at the given position
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void DrawX(int x, int y)
		{
			for (int i = 0; i < XCellAmount; i++)
				for (int j = 0; j < YCellAmount; j++)
					Cells[i, j].Alive = i - (x - y) == j || i + j == x + y ? true : Cells[i, j].Alive;
			_displayControl?.Invalidate();
		}

		/// <summary>
		/// Clears the gamefield
		/// </summary>
		public void Clear()
		{
			for (int i = 0; i < XCellAmount; i++)
				for (int j = 0; j < YCellAmount; j++)
					Cells[i, j].Alive = false;
			_displayControl?.Invalidate();
		}

		/// <summary>
		/// Toggles the Pause state
		/// </summary>
		public void TogglePauseState() => _update = !_update;

		private void InitializeLoopTimer()
		{
			var timer = new Timer();
			timer.Interval = 50; // 60fps = 17
			timer.Enabled = true;
			timer.Tick -= OnUpdate;
			timer.Tick += OnUpdate;
		}

		private void OnUpdate(object sender, EventArgs e)
		{
			if (_update)
			{
				ApplyRules();
				_displayControl?.Invalidate();
			}
		}

		private void OnMouseUp(object sender, MouseEventArgs e)
		{
			_mouseDown = false;
			if (Cells.Length > 0)
				for (int i = 0; i < XCellAmount; i++)
					for (int j = 0; j < YCellAmount; j++)
						Cells[i, j].DrawFlag = false;
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseDown)
				PaintCell(e.X, e.Y);
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			_mouseDown = true;
			PaintCell(e.X, e.Y);
		}

		private void OnPaint(object sender, PaintEventArgs e) => DrawGameField(e?.Graphics);

		private void DrawGameField(Graphics gfx)
		{
			if (Cells.Length > 0)
				for (int i = 0; i < XCellAmount; i++)
					for (int j = 0; j < YCellAmount; j++)
						gfx?.FillRectangle(Cells[i, j].Color, Cells[i, j].Rectangle);
		}

		private void PaintCell(int x, int y)
		{
			if (x >= 0 && y >= 0 && x < _displayControl.Width - _cellWidth && y < _displayControl.Height - _cellWidth)
			{
				var selectedCell = Cells[x / _cellWidth, y / _cellWidth];
				if (!selectedCell.DrawFlag)
				{
					selectedCell.Alive = !selectedCell.Alive;
					selectedCell.DrawFlag = true;
					_displayControl?.Invalidate();
				}
			}
		}

		IEnumerable<Cell> GetNeighbours(int i, int j)
		{
			bool ArrayIndexExists(int x, int y) => x >= 0 && x < XCellAmount && y >= 0 && y < YCellAmount;
			var cells = new List<Cell>();
			if (ArrayIndexExists(i - 1, j - 1)) cells.Add(Cells[i - 1, j - 1]);
			if (ArrayIndexExists(i - 1, j)) cells.Add(Cells[i - 1, j]);
			if (ArrayIndexExists(i - 1, j + 1)) cells.Add(Cells[i - 1, j + 1]);
			if (ArrayIndexExists(i, j + 1)) cells.Add(Cells[i, j + 1]);
			if (ArrayIndexExists(i + 1, j + 1)) cells.Add(Cells[i + 1, j + 1]);
			if (ArrayIndexExists(i + 1, j)) cells.Add(Cells[i + 1, j]);
			if (ArrayIndexExists(i + 1, j - 1)) cells.Add(Cells[i + 1, j - 1]);
			if (ArrayIndexExists(i, j - 1)) cells.Add(Cells[i, j - 1]);
			return cells;
		}

		//Any live cell with fewer than two live neighbours dies, as if by underpopulation.
		//Any live cell with two or three live neighbours lives on to the next generation.
		//Any live cell with more than three live neighbours dies, as if by overpopulation.
		//Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
		private void ApplyRules()
		{
			bool[,] boolMatrix = new bool[XCellAmount, YCellAmount];

			for (int i = 0; i < XCellAmount; i++)
				for (int j = 0; j < YCellAmount; j++)
				{
					var aliveNeighbourCount = GetNeighbours(i, j)?.Where(n => n.Alive)?.Count();
					if (Cells[i, j].Alive)
					{
						if (aliveNeighbourCount < 2)
							boolMatrix[i, j] = false;
						if (aliveNeighbourCount == 2 || aliveNeighbourCount == 3)
							boolMatrix[i, j] = true;
						if (aliveNeighbourCount > 3)
							boolMatrix[i, j] = false;
					}
					else if (aliveNeighbourCount == 3)
						boolMatrix[i, j] = true;
				}
			for (int i = 0; i < XCellAmount; i++)
				for (int j = 0; j < YCellAmount; j++)
					Cells[i, j].Alive = boolMatrix[i, j];
		}
		#endregion

	}
}
