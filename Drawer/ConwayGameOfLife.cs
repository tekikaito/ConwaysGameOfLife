using System;
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
		private bool _wasPaused;
		private int _updateRate = 17;
		private int _cellWidth;
		private Timer _timer = new Timer();
		private Pen _pen = new Pen(Brushes.DarkGray, 0.5f);
		#endregion


		#region properties
		public Cell[,] Cells { get; private set; }
		public CellPattern CurrentCellPattern { get; set; }
		public int XCellAmount { get; private set; }
		public int YCellAmount { get; private set; }
		public bool IsPaused => !_update;
		public bool GridEnabled { get; set; }
		public int UpdateRateInMilliseconds
		{
			get
			{
				return _updateRate;
			}
			set
			{
				_updateRate = value;
				_timer.Interval = _updateRate;
			}
		}
		#endregion


		#region ctor
		public ConwayGameOfLife(Control displayControl)
		{
			_timer.Interval = _updateRate;
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
			_timer.Enabled = true;
			_timer.Tick -= OnUpdate;
			_timer.Tick += OnUpdate;
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
			if (!_wasPaused)
				_update = true;
			_mouseDown = false;
			if (Cells.Length > 0)
				for (int i = 0; i < XCellAmount; i++)
					for (int j = 0; j < YCellAmount; j++)
						Cells[i, j].DrawFlag = false;
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseDown)
				if(CurrentCellPattern == null)
				PaintCell(e.X, e.Y);
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (!_update)
				_wasPaused = true;

			_update = false;
			_mouseDown = true;
			if (CurrentCellPattern == null)
				PaintCell(e.X, e.Y);
			else
				DrawPattern(e.X, e.Y);
		}

		private void DrawPattern(int x, int y)
		{
			var xCell = x / _cellWidth;
			var yCell = y / _cellWidth;
			Cells[xCell, yCell].Alive = true;
			for (int i = 0; i < CurrentCellPattern.Offsets.Length; i++)
			{
				if (ArrayIndexExists(xCell + CurrentCellPattern.Offsets[i].X, yCell + CurrentCellPattern.Offsets[i].Y))
					Cells[xCell + CurrentCellPattern.Offsets[i].X, yCell + CurrentCellPattern.Offsets[i].Y].Alive = true;
			}
			_displayControl.Invalidate();
		}

		private void OnPaint(object sender, PaintEventArgs e) => DrawGameField(e?.Graphics);

		private void DrawGameField(Graphics gfx)
		{
			DrawCells(gfx);
			if (GridEnabled)
				DrawGrid(gfx);
		}

		private void DrawCells(Graphics gfx)
		{
			if (Cells.Length > 0)
				for (int i = 0; i < XCellAmount; i++)
					for (int j = 0; j < YCellAmount; j++)
						Cells[i, j]?.Draw(gfx);
		}

		private void DrawGrid(Graphics gfx)
		{
			for (int i = 1; i < XCellAmount; i++)
				gfx?.DrawLine(_pen, _cellWidth * i, 0, _cellWidth * i, _cellWidth * YCellAmount);
			for (int i = 1; i < YCellAmount; i++)
				gfx?.DrawLine(_pen, 0, _cellWidth * i, _cellWidth * XCellAmount, _cellWidth * i);
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

		bool ArrayIndexExists(int x, int y) => x >= 0 && x < XCellAmount && y >= 0 && y < YCellAmount;

		IEnumerable<Cell> GetNeighbours(int i, int j)
		{
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
