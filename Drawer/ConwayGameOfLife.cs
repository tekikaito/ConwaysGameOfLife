using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Drawer
{
	public class ConwayGameOfLife
	{
		#region properties
		// saves previous Pause State
		protected bool PrevUpdateState { get; set; } = false;
		// update game field when timer elapses?
		protected bool Update { get; set; }
		// parentcontrol
		protected Control DisplayControl { get; }
		// Engine which hosts the game
		protected GridGameEngine Engine { get; set; }

		// buffer which holds info for the next frame
		// bitarrays ordered in rows
		// 1 0 0 1 0 1 0 0 0 <- Buffer[0]
		// -----------------
		// 1 0 0 1 0 1 0 0 0 <- Buffer[1]
		// -----------------
		// 1 0 0 1 0 1 0 0 0 <- Buffer[2]
		// -----------------
		// 1 0 0 1 0 1 0 0 0 <- Buffer[3]
		// -----------------
		// 1 0 0 1 0 1 0 0 0 <- Buffer[4]
		//	⬁ Buffer[4][0]
		protected BitArray[] Buffer { get; set; }

		// frame update timer 
		protected Timer Timer { get; } = new Timer();
		// last buffer index, where the mouse was detected
		protected (int X, int Y) PrevMousePosition { get; set; }
		// height of a cell
		protected int CellHeight => Engine.CellSize.Height;
		// width of a cell
		protected int CellWidth => Engine.CellSize.Width;

		/// <summary>
		/// Is the Game paused?
		/// </summary>
		public bool IsPaused => !Update;
		/// <summary>
		/// Draw Game Grid
		/// </summary>
		public bool GridEnabled { get => Engine.GridEnabled; set => Engine.GridEnabled = value; }
		/// <summary>
		/// Allow painting Cells on Mouse Click
		/// </summary>
		public bool DrawMode { get; set; }
		/// <summary>
		/// Amount of horizontal Cells
		/// </summary>
		public int HorizontalCellsCount => Engine.BufferDimensions.X;
		/// <summary>
		/// Amount of vertical Cells
		/// </summary>
		public int VerticalCellsCount => Engine.BufferDimensions.Y;

		/// <summary>
		/// Updaterate for Gameframes in Milliseconds (17 ms for 60fps)
		/// </summary>
		public int FPS { get => (int)(1000 / (double)Timer.Interval); set => Timer.Interval = (int)(1000 / (double)value); }
		#endregion


		#region ctor
		public ConwayGameOfLife(Control displayControl, int fps = 60)
		{
			FPS = fps;
			DisplayControl = displayControl;
			DisplayControl.MouseDown += OnMouseDown;
			DisplayControl.MouseUp += OnMouseUp;
			DisplayControl.MouseMove += OnMouseMove;
			Timer.Tick += OnUpdate;
		}
		#endregion


		#region methods
		/// <summary>
		/// Initialize the gamefield
		/// </summary>
		/// <param name="cellSize">edgelength for the square cells</param>
		/// <param name="randomCells">should a random pattern of living cells be generated</param>
		/// <param name="initialLivePercentage">spawnchance for living cells</param>
		public void Initialize(int cellSize, int initialLivePercentage = 0)
		{
			if (cellSize <= 0 || DisplayControl == null) return;

			Engine = new GridGameEngine(DisplayControl, cellSize);
			Buffer = GetInitialBuffer(Engine.BufferDimensions, initialLivePercentage);
			Timer.Enabled = true;

			Engine.Update(Buffer);
		}

		/// <summary>
		/// Draws an X with its center at the given position
		/// </summary>
		/// <param name="mouseX">X-Coordinate of the center position</param>
		/// <param name="mouseY">Y-Coordinate of the center position</param>
		public void DrawPattern(int mouseX, int mouseY, Pattern pattern)
		{
			pattern.Anchor = GridCalcUtil.GetIndexByPixelPosition(mouseX, mouseY, CellWidth, CellHeight);

			if (pattern is EndlessPattern endlessPattern)
				ApplyToBuffer(index => endlessPattern.GetValue(index));
			else if (pattern is FixedPattern fixedPattern)
				ApplyToBuffer(index => fixedPattern.Indices.Contains((index.X, index.Y)));

			Engine.Update(Buffer);
		}

		/// <summary>
		/// Clears the gamefield
		/// </summary>
		public void Clear()
		{
			ApplyToBuffer(index => false, false);
			Engine.Update(Buffer);
		}

		/// <summary>
		/// Toggles the Pause state
		/// </summary>
		public void TogglePauseState() => Update = !Update;


		void ApplyToBuffer(Func<(int Y, int X), bool> aliveFunc, bool overwriteTrueVals = true)
		{
			for (int i = 0; i < Engine.BufferDimensions.Y; i++)
				for (int j = 0; j < Engine.BufferDimensions.X; j++)
					Buffer[i][j] = (Buffer[i][j] && overwriteTrueVals) || aliveFunc?.Invoke((i, j)) == true;
		}

		BitArray[] GetInitialBuffer((int X, int Y) dimensions, int initialLivePercentage, Random random = null)
		{
			random = random ?? new Random();
			var buffer = Enumerable.Range(0, dimensions.Y)
				.Select(a => new BitArray(dimensions.X, false))
				.ToArray();
			for (int i = 0; i < dimensions.Y; i++)
				for (int j = 0; j < dimensions.X; j++)
					buffer[i][j] = random.Next(1, 101) <= initialLivePercentage;
			return buffer;
		}

		void OnUpdate(object sender, EventArgs e)
		{
			if (Update)
			{
				ApplyRules();
				Engine.Update(Buffer);
			}
		}

		void OnMouseUp(object sender, MouseEventArgs e)
		{
			Update = PrevUpdateState;
		}

		void OnMouseDown(object sender, MouseEventArgs e)
		{
			PrevUpdateState = Update;
			Update = false;
			PrevMousePosition = GridCalcUtil.GetIndexByPixelPosition(e.X, e.Y, CellWidth, CellHeight);
		}

		void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (DrawMode && e.Button == MouseButtons.Left && CheckMouseBounds(e.X, e.Y))
			{
				var newPos = GridCalcUtil.GetIndexByPixelPosition(e.X, e.Y, CellWidth, CellHeight);
				foreach (var (X, Y) in GridCalcUtil.GetLineCoords(newPos, PrevMousePosition))
					Buffer[Y][X] = true;

				PrevMousePosition = newPos;
				Engine.Update(Buffer);
			}
		}

		bool CheckMouseBounds(int x, int y)
		{
			return x >= 0 && y >= 0 && x < DisplayControl.Width - CellWidth && y < DisplayControl.Height - CellHeight;
		}

		bool GetBufferValueSafe(int indexX, int indexY)
		{
			if (indexX > 0) indexX %= Engine.BufferDimensions.X;
			if(indexX < 0) indexX = (Engine.BufferDimensions.X - (indexX + 2)) % Engine.BufferDimensions.X;
			if (indexY > 0) indexY %= Engine.BufferDimensions.Y;
			if(indexY < 0) indexY = (Engine.BufferDimensions.Y - (indexY + 2)) % Engine.BufferDimensions.Y;
			return Buffer[indexY][indexX];
		}

		//Any live cell with fewer than two live neighbours dies, as if by underpopulation.
		//Any live cell with two or three live neighbours lives on to the next generation.
		//Any live cell with more than three live neighbours dies, as if by overpopulation.
		//Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
		void ApplyRules()
		{
			BitArray[] newBuffer = new BitArray[Engine.BufferDimensions.Y];

			for (int y = 0; y < Engine.BufferDimensions.Y; y++)
			{
				newBuffer[y] = new BitArray(Engine.BufferDimensions.X, false);
				for (int x = 0; x < Engine.BufferDimensions.X; x++)
				{
					var aliveNeighbourCount = GetAliveNeighboursCount(x, y);
					newBuffer[y][x] = (Buffer[y][x] && aliveNeighbourCount == 2) || aliveNeighbourCount == 3;
				}
			}

			Buffer = newBuffer;
		}

		int GetAliveNeighboursCount(int i, int j)
		{
			IEnumerable<bool> getNeighbourVals()
			{
				yield return GetBufferValueSafe(i - 1, j - 1);
				yield return GetBufferValueSafe(i - 1, j);
				yield return GetBufferValueSafe(i - 1, j + 1);
				yield return GetBufferValueSafe(i, j + 1);
				yield return GetBufferValueSafe(i + 1, j + 1);
				yield return GetBufferValueSafe(i + 1, j);
				yield return GetBufferValueSafe(i + 1, j - 1);
				yield return GetBufferValueSafe(i, j - 1);
			}
			return getNeighbourVals()?.Count(a => a) ?? 0;
		}		
		#endregion
	}
}