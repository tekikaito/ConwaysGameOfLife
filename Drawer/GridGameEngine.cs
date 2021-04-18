using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Drawer
{
	/// <summary>
	/// Represents a <see cref="Cell"/> table, which can be layered on top of a control
	/// </summary>
	public class GridGameEngine
	{
		#region props
		protected Control Control { get; }
		protected BitArray[] Buffer { get; set; }

		/// <summary>
		/// Draws the Grid on the next update frame
		/// </summary>
		public bool GridEnabled { get; set; }
		/// <summary>
		/// Size of cells (square)
		/// </summary>
		public Size CellSize { get; }
		/// <summary>
		/// Pen for the Presentation of the Grid
		/// </summary>
		public Pen GridPen { get; set; } = new Pen(Brushes.White);
		/// <summary>
		/// Brush for the Presentation of <see cref="true"/> Buffer Values
		/// </summary>
		public Brush CellActiveBrush { get; set; } = Brushes.White;
		/// <summary>
		/// Brush for the Presentation of <see cref="false"/> Buffer Values
		/// </summary>
		public Brush CellInactiveBrush { get; set; } = Brushes.Black;
		/// <summary>
		/// Dimensions of the Buffer
		/// </summary>
		public (int X, int Y) BufferDimensions { get; }
		#endregion


		#region ctor
		public GridGameEngine(Control control, int cellSize)
		{
			CellSize = new Size(cellSize, cellSize);
			Control = control;
			BufferDimensions = (control.Width / cellSize, control.Height / cellSize);
			Buffer = GetBuffer(BufferDimensions.X, BufferDimensions.Y);
			Control.Paint += OnPaint;
		}
		#endregion


		#region pub. methods
		/// <summary>
		/// Write Buffer and display it on the Parent Control
		/// </summary>
		/// <param name="buffer"></param>
		public void Update(BitArray[] buffer)
		{
			if (buffer == null || buffer.Length != BufferDimensions.Y || (buffer.Any(col => col.Length != BufferDimensions.X) == true))
				throw new InvalidOperationException($"expected buffersize to be {BufferDimensions}!");

			Buffer = buffer;
			Control.Invalidate();
		}
		#endregion


		#region priv. methods
		void OnPaint(object sender, PaintEventArgs e) => DrawGameField(e?.Graphics);

		void DrawGameField(Graphics gfx)
		{
			DrawBuffer(gfx);
			if (GridEnabled)
				DrawGrid(gfx);
		}

		void DrawBuffer(Graphics gfx)
		{
			for (int i = 0; i < BufferDimensions.Y; i++)
				for (int j = 0; j < BufferDimensions.X; j++)
				{
					var location = new Point(j * CellSize.Width, i * CellSize.Height);
					var brush = Buffer[i][j] ? CellActiveBrush : CellInactiveBrush;
					gfx.FillRectangle(brush, new Rectangle(location, CellSize));
				}
		}

		void DrawGrid(Graphics gfx)
		{
			var length = CellSize.Width * BufferDimensions.X;
			var height = CellSize.Height * BufferDimensions.Y;

			for (int i = 1; i < BufferDimensions.X; i++)
				gfx?.DrawLine(GridPen, CellSize.Width * i, 0, CellSize.Width* i, height);
			for (int i = 1; i < BufferDimensions.Y; i++)
				gfx?.DrawLine(GridPen, 0, CellSize.Height * i, length, CellSize.Height * i);
		}

		static BitArray[] GetBuffer(int width, int height)
		{
			return Enumerable.Range(0, height)
				.Select(a => new BitArray(width))
				.ToArray();
		} 
		#endregion
	}
}
