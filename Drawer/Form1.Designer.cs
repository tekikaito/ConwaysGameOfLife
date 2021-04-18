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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.UpdateRateLabel = new System.Windows.Forms.Label();
			this.ToolsComboBox = new System.Windows.Forms.ComboBox();
			this.SpeedRateTrackBar = new System.Windows.Forms.TrackBar();
			this.EnableGridCheckbox = new System.Windows.Forms.CheckBox();
			this.SpawnRateTrackBar = new System.Windows.Forms.TrackBar();
			this.SpawnRateLabel = new System.Windows.Forms.Label();
			this.newGameButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpeedRateTrackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SpawnRateTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// DrawPanel
			// 
			this.DrawPanel.BackColor = System.Drawing.Color.Transparent;
			this.DrawPanel.Location = new System.Drawing.Point(149, 0);
			this.DrawPanel.Margin = new System.Windows.Forms.Padding(0);
			this.DrawPanel.Name = "DrawPanel";
			this.DrawPanel.Size = new System.Drawing.Size(1415, 914);
			this.DrawPanel.TabIndex = 0;
			// 
			// pauseButton
			// 
			this.pauseButton.BackColor = System.Drawing.Color.LightGray;
			this.pauseButton.FlatAppearance.BorderSize = 0;
			this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pauseButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pauseButton.ForeColor = System.Drawing.Color.Black;
			this.pauseButton.Location = new System.Drawing.Point(13, 8);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(144, 42);
			this.pauseButton.TabIndex = 1;
			this.pauseButton.Text = "Play";
			this.pauseButton.UseVisualStyleBackColor = false;
			this.pauseButton.Click += new System.EventHandler(this.OnPauseToggle);
			// 
			// clearButton
			// 
			this.clearButton.BackColor = System.Drawing.Color.LightGray;
			this.clearButton.FlatAppearance.BorderSize = 0;
			this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.clearButton.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.clearButton.ForeColor = System.Drawing.Color.Black;
			this.clearButton.Location = new System.Drawing.Point(13, 56);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(144, 42);
			this.clearButton.TabIndex = 2;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = false;
			this.clearButton.Click += new System.EventHandler(this.OnClear);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.newGameButton);
			this.panel1.Controls.Add(this.pauseButton);
			this.panel1.Controls.Add(this.clearButton);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(170, 914);
			this.panel1.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.UpdateRateLabel);
			this.groupBox1.Controls.Add(this.ToolsComboBox);
			this.groupBox1.Controls.Add(this.SpeedRateTrackBar);
			this.groupBox1.Controls.Add(this.EnableGridCheckbox);
			this.groupBox1.Controls.Add(this.SpawnRateTrackBar);
			this.groupBox1.Controls.Add(this.SpawnRateLabel);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox1.Location = new System.Drawing.Point(13, 152);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 476);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.label1.Location = new System.Drawing.Point(2, 425);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 15);
			this.label1.TabIndex = 11;
			this.label1.Text = "Tool";
			// 
			// UpdateRateLabel
			// 
			this.UpdateRateLabel.AutoSize = true;
			this.UpdateRateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.UpdateRateLabel.Location = new System.Drawing.Point(2, 95);
			this.UpdateRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.UpdateRateLabel.Name = "UpdateRateLabel";
			this.UpdateRateLabel.Size = new System.Drawing.Size(96, 15);
			this.UpdateRateLabel.TabIndex = 9;
			this.UpdateRateLabel.Text = "UpdateRateLabel";
			// 
			// ToolsComboBox
			// 
			this.ToolsComboBox.DisplayMember = "Name";
			this.ToolsComboBox.FormattingEnabled = true;
			this.ToolsComboBox.Location = new System.Drawing.Point(5, 442);
			this.ToolsComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.ToolsComboBox.Name = "ToolsComboBox";
			this.ToolsComboBox.Size = new System.Drawing.Size(133, 29);
			this.ToolsComboBox.TabIndex = 10;
			this.ToolsComboBox.SelectedValueChanged += new System.EventHandler(this.OnSelectedPatternChanged);
			// 
			// SpeedRateTrackBar
			// 
			this.SpeedRateTrackBar.Location = new System.Drawing.Point(6, 113);
			this.SpeedRateTrackBar.Maximum = 500;
			this.SpeedRateTrackBar.Minimum = 1;
			this.SpeedRateTrackBar.Name = "SpeedRateTrackBar";
			this.SpeedRateTrackBar.RightToLeftLayout = true;
			this.SpeedRateTrackBar.Size = new System.Drawing.Size(132, 45);
			this.SpeedRateTrackBar.TabIndex = 6;
			this.SpeedRateTrackBar.Value = 60;
			this.SpeedRateTrackBar.ValueChanged += new System.EventHandler(this.OnSpeedRateChanged);
			// 
			// EnableGridCheckbox
			// 
			this.EnableGridCheckbox.AutoSize = true;
			this.EnableGridCheckbox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.EnableGridCheckbox.Location = new System.Drawing.Point(6, 163);
			this.EnableGridCheckbox.Margin = new System.Windows.Forms.Padding(2);
			this.EnableGridCheckbox.Name = "EnableGridCheckbox";
			this.EnableGridCheckbox.Size = new System.Drawing.Size(98, 19);
			this.EnableGridCheckbox.TabIndex = 8;
			this.EnableGridCheckbox.Text = "Grid anzeigen";
			this.EnableGridCheckbox.UseVisualStyleBackColor = true;
			this.EnableGridCheckbox.CheckedChanged += new System.EventHandler(this.OnGridEnableCheck);
			// 
			// SpawnRateTrackBar
			// 
			this.SpawnRateTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.SpawnRateTrackBar.Location = new System.Drawing.Point(6, 45);
			this.SpawnRateTrackBar.Maximum = 100;
			this.SpawnRateTrackBar.Name = "SpawnRateTrackBar";
			this.SpawnRateTrackBar.Size = new System.Drawing.Size(132, 45);
			this.SpawnRateTrackBar.TabIndex = 4;
			this.SpawnRateTrackBar.Value = 1;
			this.SpawnRateTrackBar.ValueChanged += new System.EventHandler(this.OnSpawnPercentChanged);
			// 
			// SpawnRateLabel
			// 
			this.SpawnRateLabel.AutoSize = true;
			this.SpawnRateLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.SpawnRateLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.SpawnRateLabel.Location = new System.Drawing.Point(3, 27);
			this.SpawnRateLabel.Name = "SpawnRateLabel";
			this.SpawnRateLabel.Size = new System.Drawing.Size(31, 15);
			this.SpawnRateLabel.TabIndex = 5;
			this.SpawnRateLabel.Text = "aaaa";
			// 
			// newGameButton
			// 
			this.newGameButton.BackColor = System.Drawing.Color.LightGray;
			this.newGameButton.FlatAppearance.BorderSize = 0;
			this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.newGameButton.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.newGameButton.ForeColor = System.Drawing.Color.Black;
			this.newGameButton.Location = new System.Drawing.Point(13, 104);
			this.newGameButton.Name = "newGameButton";
			this.newGameButton.Size = new System.Drawing.Size(144, 42);
			this.newGameButton.TabIndex = 3;
			this.newGameButton.Text = "New Game";
			this.newGameButton.UseVisualStyleBackColor = false;
			this.newGameButton.Click += new System.EventHandler(this.OnNewGame);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1443, 857);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.DrawPanel);
			this.Name = "MainForm";
			this.Text = "Drawer";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpeedRateTrackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SpawnRateTrackBar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel DrawPanel;
		private System.Windows.Forms.Button pauseButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button newGameButton;
		private System.Windows.Forms.TrackBar SpawnRateTrackBar;
		private System.Windows.Forms.Label SpawnRateLabel;
		private System.Windows.Forms.TrackBar SpeedRateTrackBar;
		private System.Windows.Forms.CheckBox EnableGridCheckbox;
		private System.Windows.Forms.Label UpdateRateLabel;
		private System.Windows.Forms.ComboBox ToolsComboBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
	}
}

