using System;
using System.Reflection;
using System.Windows.Forms;

namespace Drawer
{
	public partial class MainForm : Form
	{
		#region const
		private const int CELL_WIDTH = 3;
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
			SpawnRateLabel.Text = string.Format("Initial Livechance: {0}%", _spawnRate);
			_game?.DrawX(_game.XCellAmount / 2, _game.YCellAmount / 2);
			_game?.DrawX(_game.XCellAmount / 4, _game.YCellAmount / 2);
			_game?.DrawX(_game.XCellAmount / 2, _game.YCellAmount / 4);
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

		private void OnSpawnPercentChanged(object sender, EventArgs e)
		{
			_spawnRate = SpawnRateTrackBar.Value;
			UpdatePercentLabel();
			_game.Initialize(CELL_WIDTH, _spawnRate);
		}

		private void UpdatePercentLabel() => SpawnRateLabel.Text = string.Format("Initial Livechance: {0}%", _spawnRate);

		private void OnSpeedRateChanged(object sender, EventArgs e)
		{
			_game.UpdateRateInMilliseconds = (sender as TrackBar).Value;
		}
	}
}
