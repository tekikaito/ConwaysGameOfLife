using System;
using System.Reflection;
using System.Windows.Forms;

namespace Drawer
{
	public partial class MainForm : Form
	{
		#region const
		const int CELL_WIDTH = 4;
		const string PEN_TOOL = "Pen";
		#endregion

		#region props
		protected int SpawnRate { get; set; } = 0;
		protected ConwayGameOfLife Game { get; set; }
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
		void OnLoad(object sender, EventArgs e)
		{
			// DoubleBuffer member needs to be set by using Reflection, because its a private member
			typeof(Panel).InvokeMember("DoubleBuffered",
				BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
				null, DrawPanel, new object[] { true });


			Game = new ConwayGameOfLife(DrawPanel);
			DrawPanel.MouseClick += OnDrawPanelClicked;
			Game.Initialize(CELL_WIDTH);
			UpdateSpeedRateLabel();
			UpdateSpawnRateLabel();
			UpdatePauseButtonText();
			InitializeTools();
			ToolsComboBox.SelectedItem = ToolsComboBox.Items[0];
		}


		void OnDrawPanelClicked(object sender, MouseEventArgs e)
		{
			if (!Game.DrawMode && ToolsComboBox.SelectedItem is Pattern pattern)
				Game.DrawPattern(e.X, e.Y, pattern);
		}

		void InitializeTools()
		{
			ToolsComboBox.Items.Add(PEN_TOOL);
			ToolsComboBox.Items.Add(FixedPattern.Glider);
			ToolsComboBox.Items.Add(EndlessPattern.XPattern);
		}

		void OnPauseToggle(object sender, EventArgs e)
		{
			Game.TogglePauseState();			
		}

		void OnClear(object sender, EventArgs e)
		{
			Game.Clear();
			if (!Game.IsPaused)
			{
				Game.TogglePauseState();
				UpdatePauseButtonText();
			}
		}

		void OnNewGame(object sender, EventArgs e)
		{
			Game.Initialize(CELL_WIDTH, SpawnRate);
		}

		void OnSpawnPercentChanged(object sender, EventArgs e)
		{
			SpawnRate = SpawnRateTrackBar.Value;
			UpdateSpawnRateLabel();
		}

		void OnSpeedRateChanged(object sender, EventArgs e)
		{
			Game.FPS = (sender as TrackBar).Value;
			UpdateSpeedRateLabel();
		}

		void OnGridEnableCheck(object sender, EventArgs e)
		{
			Game.GridEnabled = EnableGridCheckbox.Checked;
			DrawPanel?.Invalidate();
		}

		void OnSelectedPatternChanged(object sender, EventArgs e)
		{
			Game.DrawMode = ToolsComboBox.SelectedItem.Equals(PEN_TOOL);
		}

		void UpdateSpawnRateLabel() => SpawnRateLabel.Text = $"Initial Livechance: {SpawnRate}%";
		void UpdateSpeedRateLabel() => UpdateRateLabel.Text = $"Updaterate = {Game.FPS} FPS";
		void UpdatePauseButtonText() => pauseButton.Text = Game?.IsPaused == true ? "Play" : "Pause";
		#endregion
	}
}
