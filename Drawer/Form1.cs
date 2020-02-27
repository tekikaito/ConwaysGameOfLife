using System;
using System.Reflection;
using System.Windows.Forms;

namespace Drawer
{
	public partial class MainForm : Form
	{
		#region fields
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
			_game?.Initialize(2);
			_game?.DrawX(_game.XCellAmount / 2, _game.YCellAmount / 2);
		}

		private void OnPauseToggle(object sender, EventArgs e)
		{
			_game?.TogglePauseState();
			(sender as Button).Text = _game?.IsPaused == true ? "Play" : "Pause";
		}

		private void OnClear(object sender, EventArgs e) => _game?.Clear();
		#endregion
	}
}
