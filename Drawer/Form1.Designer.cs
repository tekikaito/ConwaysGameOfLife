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
			this.SpawnRateLabel = new System.Windows.Forms.Label();
			this.SpawnRateTrackBar = new System.Windows.Forms.TrackBar();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpawnRateTrackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// DrawPanel
			// 
			this.DrawPanel.BackColor = System.Drawing.Color.Transparent;
			this.DrawPanel.Location = new System.Drawing.Point(210, 0);
			this.DrawPanel.Margin = new System.Windows.Forms.Padding(0);
			this.DrawPanel.Name = "DrawPanel";
			this.DrawPanel.Size = new System.Drawing.Size(1374, 914);
			this.DrawPanel.TabIndex = 0;
			// 
			// pauseButton
			// 
			this.pauseButton.BackColor = System.Drawing.Color.LightGray;
			this.pauseButton.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pauseButton.ForeColor = System.Drawing.Color.Black;
			this.pauseButton.Location = new System.Drawing.Point(3, 3);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(205, 42);
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
			this.clearButton.Location = new System.Drawing.Point(3, 51);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(205, 42);
			this.clearButton.TabIndex = 2;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = false;
			this.clearButton.Click += new System.EventHandler(this.OnClear);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.panel1.Controls.Add(this.SpawnRateLabel);
			this.panel1.Controls.Add(this.SpawnRateTrackBar);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.pauseButton);
			this.panel1.Controls.Add(this.clearButton);
			this.panel1.Location = new System.Drawing.Point(-1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(211, 914);
			this.panel1.TabIndex = 3;
			// 
			// SpawnRateLabel
			// 
			this.SpawnRateLabel.AutoSize = true;
			this.SpawnRateLabel.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SpawnRateLabel.Location = new System.Drawing.Point(13, 195);
			this.SpawnRateLabel.Name = "SpawnRateLabel";
			this.SpawnRateLabel.Size = new System.Drawing.Size(41, 20);
			this.SpawnRateLabel.TabIndex = 5;
			this.SpawnRateLabel.Text = "aaaa";
			// 
			// SpawnRateTrackBar
			// 
			this.SpawnRateTrackBar.Location = new System.Drawing.Point(13, 147);
			this.SpawnRateTrackBar.Maximum = 100;
			this.SpawnRateTrackBar.Name = "SpawnRateTrackBar";
			this.SpawnRateTrackBar.Size = new System.Drawing.Size(183, 45);
			this.SpawnRateTrackBar.TabIndex = 4;
			this.SpawnRateTrackBar.ValueChanged += new System.EventHandler(this.OnSpawnPercentChanged);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LightGray;
			this.button1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(3, 99);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(205, 42);
			this.button1.TabIndex = 3;
			this.button1.Text = "New Game";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.OnNewGame);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1584, 914);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.DrawPanel);
			this.Name = "MainForm";
			this.Text = "Drawer";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
	}
}

