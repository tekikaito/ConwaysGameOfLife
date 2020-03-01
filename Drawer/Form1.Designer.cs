namespace Drawer
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DrawPanel = new System.Windows.Forms.Panel();
			this.pauseButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.EnableGridCheckbox = new System.Windows.Forms.CheckBox();
			this.SpeedRateTrackBar = new System.Windows.Forms.TrackBar();
			this.SpawnRateLabel = new System.Windows.Forms.Label();
			this.SpawnRateTrackBar = new System.Windows.Forms.TrackBar();
			this.button1 = new System.Windows.Forms.Button();
			this.UpdateRateLabel = new System.Windows.Forms.Label();
			this.CellPatternsComboBox = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpeedRateTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpawnRateTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// DrawPanel
			// 
			this.DrawPanel.BackColor = System.Drawing.Color.Transparent;
			this.DrawPanel.Location = new System.Drawing.Point(199, 0);
			this.DrawPanel.Margin = new System.Windows.Forms.Padding(0);
			this.DrawPanel.Name = "DrawPanel";
			this.DrawPanel.Size = new System.Drawing.Size(1913, 1125);
			this.DrawPanel.TabIndex = 0;
			// 
			// pauseButton
			// 
			this.pauseButton.BackColor = System.Drawing.Color.LightGray;
			this.pauseButton.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pauseButton.ForeColor = System.Drawing.Color.Black;
			this.pauseButton.Location = new System.Drawing.Point(4, 4);
			this.pauseButton.Margin = new System.Windows.Forms.Padding(4);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(92, 52);
			this.pauseButton.TabIndex = 1;
			this.pauseButton.Text = "Play";
			this.pauseButton.UseVisualStyleBackColor = false;
			this.pauseButton.Click += new System.EventHandler(this.OnPauseToggle);
			// 
			// clearButton
			// 
			this.clearButton.BackColor = System.Drawing.Color.LightGray;
			this.clearButton.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearButton.ForeColor = System.Drawing.Color.Black;
			this.clearButton.Location = new System.Drawing.Point(104, 4);
			this.clearButton.Margin = new System.Windows.Forms.Padding(4);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(92, 52);
			this.clearButton.TabIndex = 2;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = false;
			this.clearButton.Click += new System.EventHandler(this.OnClear);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.panel1.Controls.Add(this.CellPatternsComboBox);
			this.panel1.Controls.Add(this.UpdateRateLabel);
			this.panel1.Controls.Add(this.EnableGridCheckbox);
			this.panel1.Controls.Add(this.SpeedRateTrackBar);
			this.panel1.Controls.Add(this.SpawnRateLabel);
			this.panel1.Controls.Add(this.SpawnRateTrackBar);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.pauseButton);
			this.panel1.Controls.Add(this.clearButton);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 1125);
			this.panel1.TabIndex = 3;
			// 
			// EnableGridCheckbox
			// 
			this.EnableGridCheckbox.AutoSize = true;
			this.EnableGridCheckbox.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EnableGridCheckbox.Location = new System.Drawing.Point(8, 312);
			this.EnableGridCheckbox.Name = "EnableGridCheckbox";
			this.EnableGridCheckbox.Size = new System.Drawing.Size(127, 24);
			this.EnableGridCheckbox.TabIndex = 8;
			this.EnableGridCheckbox.Text = "Grid anzeigen";
			this.EnableGridCheckbox.UseVisualStyleBackColor = true;
			this.EnableGridCheckbox.CheckedChanged += new System.EventHandler(this.OnGridEnableCheck);
			// 
			// SpeedRateTrackBar
			// 
			this.SpeedRateTrackBar.Location = new System.Drawing.Point(4, 231);
			this.SpeedRateTrackBar.Margin = new System.Windows.Forms.Padding(4);
			this.SpeedRateTrackBar.Maximum = 1000;
			this.SpeedRateTrackBar.Minimum = 1;
			this.SpeedRateTrackBar.Name = "SpeedRateTrackBar";
			this.SpeedRateTrackBar.RightToLeftLayout = true;
			this.SpeedRateTrackBar.Size = new System.Drawing.Size(192, 56);
			this.SpeedRateTrackBar.TabIndex = 6;
			this.SpeedRateTrackBar.Value = 17;
			this.SpeedRateTrackBar.ValueChanged += new System.EventHandler(this.OnSpeedRateChanged);
			// 
			// SpawnRateLabel
			// 
			this.SpawnRateLabel.AutoSize = true;
			this.SpawnRateLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SpawnRateLabel.Location = new System.Drawing.Point(4, 160);
			this.SpawnRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SpawnRateLabel.Name = "SpawnRateLabel";
			this.SpawnRateLabel.Size = new System.Drawing.Size(41, 20);
			this.SpawnRateLabel.TabIndex = 5;
			this.SpawnRateLabel.Text = "aaaa";
			// 
			// SpawnRateTrackBar
			// 
			this.SpawnRateTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.SpawnRateTrackBar.Location = new System.Drawing.Point(4, 124);
			this.SpawnRateTrackBar.Margin = new System.Windows.Forms.Padding(4);
			this.SpawnRateTrackBar.Maximum = 100;
			this.SpawnRateTrackBar.Name = "SpawnRateTrackBar";
			this.SpawnRateTrackBar.Size = new System.Drawing.Size(192, 56);
			this.SpawnRateTrackBar.TabIndex = 4;
			this.SpawnRateTrackBar.Value = 1;
			this.SpawnRateTrackBar.ValueChanged += new System.EventHandler(this.OnSpawnPercentChanged);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightGray;
			this.button1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(4, 64);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(192, 52);
			this.button1.TabIndex = 3;
			this.button1.Text = "New Game";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.OnNewGame);
			// 
			// UpdateRateLabel
			// 
			this.UpdateRateLabel.AutoSize = true;
			this.UpdateRateLabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.UpdateRateLabel.Location = new System.Drawing.Point(8, 269);
			this.UpdateRateLabel.Name = "UpdateRateLabel";
			this.UpdateRateLabel.Size = new System.Drawing.Size(125, 20);
			this.UpdateRateLabel.TabIndex = 9;
			this.UpdateRateLabel.Text = "UpdateRateLabel";
			// 
			// CellPatternsComboBox
			// 
			this.CellPatternsComboBox.DisplayMember = "Name";
			this.CellPatternsComboBox.FormattingEnabled = true;
			this.CellPatternsComboBox.Location = new System.Drawing.Point(8, 361);
			this.CellPatternsComboBox.Name = "CellPatternsComboBox";
			this.CellPatternsComboBox.Size = new System.Drawing.Size(188, 24);
			this.CellPatternsComboBox.TabIndex = 10;
			this.CellPatternsComboBox.SelectedValueChanged += new System.EventHandler(this.OnSelectedPatternChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1924, 1055);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.DrawPanel);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Drawer";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpeedRateTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpawnRateTrackBar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel DrawPanel;
		private System.Windows.Forms.Button pauseButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TrackBar SpawnRateTrackBar;
		private System.Windows.Forms.Label SpawnRateLabel;
		private System.Windows.Forms.TrackBar SpeedRateTrackBar;
		private System.Windows.Forms.CheckBox EnableGridCheckbox;
		private System.Windows.Forms.Label UpdateRateLabel;
		private System.Windows.Forms.ComboBox CellPatternsComboBox;
	}
}

