using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Drawer
{
	public partial class MainForm : Form
	{
		#region const
		private const int CELL_WIDTH = 16;
		#endregion

		#region fields
		private int _spawnRate = 0;
		private ConwayGameOfLife _game;
		#endregion

		#region ctor
		public MainForm()
		{
			InitializeComponent();
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			Load += OnLoad;
		}
		#endregion

		#region EventHandler
		private void OnLoad(object sender, EventArgs e)
		{
			typeof(Panel).InvokeMember("DoubleBuffered",
				BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
				null, DrawPanel, new object[] { true });


			_game = new ConwayGameOfLife(DrawPanel);
			_game?.Initialize(CELL_WIDTH);
			_game?.DrawX(_game.XCellAmount / 2, _game.YCellAmount / 2);
			_game?.DrawX(_game.XCellAmount / 4, _game.YCellAmount / 2);
			_game?.DrawX(_game.XCellAmount / 2, _game.YCellAmount / 4);
			UpdateSpeedRateLabel();
			UpdatePercentLabel();
			InitializePatterns();
		}

		private void InitializePatterns()
		{
			CellPatternsComboBox.Items.Add(
				new CellPattern("Glider", new Point(1, 0), new Point(2, 0), new Point(2, 1), new Point(1, 2)));

			CellPatternsComboBox.Items.Add(
				new CellPattern("Orion", 
					new Point(0, 1), 
					new Point(0, 2), 
					new Point(2, 2),
					new Point(3, 2),
					new Point(7, 2),
					new Point(1, 2)));
		}

		private void OnPauseToggle(object sender, EventArgs e)
		{
			_game?.TogglePauseState();
			(sender as Button).Text = _game?.IsPaused == true ? "Play" : "Pause";
		}

		private void OnClear(object sender, EventArgs e) => _game?.Clear();
		#endregion

		private void OnNewGame(object sender, EventArgs e)
		{
			_game.Initialize(CELL_WIDTH, _spawnRate);
		}

		private void UpdatePercentLabel() => SpawnRateLabel.Text = string.Format("Initial Livechance: {0}%", _spawnRate);
		private void UpdateSpeedRateLabel() => UpdateRateLabel.Text = string.Format("Updaterate = {0}ms", _game.UpdateRateInMilliseconds);

		private void OnSpawnPercentChanged(object sender, EventArgs e)
		{
			_spawnRate = SpawnRateTrackBar.Value;
			UpdatePercentLabel();
		}

		private void OnSpeedRateChanged(object sender, EventArgs e)
		{
			_game.UpdateRateInMilliseconds = (sender as TrackBar).Value;
			UpdateSpeedRateLabel();
		}

		private void OnGridEnableCheck(object sender, EventArgs e)
		{
			_game.GridEnabled = EnableGridCheckbox.Checked;
			DrawPanel?.Invalidate();
		}

		private void OnSelectedPatternChanged(object sender, EventArgs e)
		{
			_game.CurrentCellPattern = CellPatternsComboBox.SelectedItem as CellPattern;
		}
	}
}
