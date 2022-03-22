namespace SpotifyMiniplayer
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Cover = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressBar = new SpotifyMiniplayer.ProgressBar();
            this.LoopButton = new SpotifyMiniplayer.IconToggle();
            this.ShuffleButton = new SpotifyMiniplayer.IconToggle();
            this.NextButton = new SpotifyMiniplayer.IconButton();
            this.PrevButton = new SpotifyMiniplayer.IconButton();
            this.PlayButton = new SpotifyMiniplayer.IconToggle();
            this.UpdateInfoTimer = new System.Windows.Forms.Timer(this.components);
            this.SongTitle = new SpotifyMiniplayer.ScrollingLabel();
            this.ArtistsNames = new SpotifyMiniplayer.ScrollingLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Cover)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoopButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).BeginInit();
            this.SuspendLayout();
            // 
            // Cover
            // 
            this.Cover.Image = global::SpotifyMiniplayer.Properties.Resources.NoTrack;
            this.Cover.Location = new System.Drawing.Point(0, 0);
            this.Cover.Name = "Cover";
            this.Cover.Size = new System.Drawing.Size(170, 170);
            this.Cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Cover.TabIndex = 0;
            this.Cover.TabStop = false;
            this.Cover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Controls.Add(this.LoopButton);
            this.panel1.Controls.Add(this.ShuffleButton);
            this.panel1.Controls.Add(this.NextButton);
            this.panel1.Controls.Add(this.PrevButton);
            this.panel1.Controls.Add(this.PlayButton);
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 130);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProgressBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ProgressBar.ForegroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(162)))));
            this.ProgressBar.Location = new System.Drawing.Point(35, 96);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Percentage = 0.3F;
            this.ProgressBar.Size = new System.Drawing.Size(480, 12);
            this.ProgressBar.TabIndex = 5;
            this.ProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SeekTo);
            // 
            // LoopButton
            // 
            this.LoopButton.ActiveImage = global::SpotifyMiniplayer.Properties.Resources.LoopActive;
            this.LoopButton.ActiveImageHover = global::SpotifyMiniplayer.Properties.Resources.LoopActiveHover;
            this.LoopButton.BackColor = System.Drawing.Color.Transparent;
            this.LoopButton.ForeColor = System.Drawing.Color.Transparent;
            this.LoopButton.Image = global::SpotifyMiniplayer.Properties.Resources.Loop;
            this.LoopButton.Location = new System.Drawing.Point(452, 33);
            this.LoopButton.Name = "LoopButton";
            this.LoopButton.NormalImage = global::SpotifyMiniplayer.Properties.Resources.Loop;
            this.LoopButton.NormalImageHover = global::SpotifyMiniplayer.Properties.Resources.LoopHover;
            this.LoopButton.Size = new System.Drawing.Size(36, 30);
            this.LoopButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoopButton.TabIndex = 4;
            this.LoopButton.TabStop = false;
            this.LoopButton.Click += new System.EventHandler(this.Loop);
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.ActiveImage = global::SpotifyMiniplayer.Properties.Resources.ShuffleActive;
            this.ShuffleButton.ActiveImageHover = global::SpotifyMiniplayer.Properties.Resources.ShuffleActiveHover;
            this.ShuffleButton.BackColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.ForeColor = System.Drawing.Color.Transparent;
            this.ShuffleButton.Image = global::SpotifyMiniplayer.Properties.Resources.Shuffle;
            this.ShuffleButton.Location = new System.Drawing.Point(60, 33);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.NormalImage = global::SpotifyMiniplayer.Properties.Resources.Shuffle;
            this.ShuffleButton.NormalImageHover = global::SpotifyMiniplayer.Properties.Resources.ShuffleHover;
            this.ShuffleButton.Size = new System.Drawing.Size(32, 30);
            this.ShuffleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShuffleButton.TabIndex = 3;
            this.ShuffleButton.TabStop = false;
            this.ShuffleButton.Click += new System.EventHandler(this.Shuffle);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.Transparent;
            this.NextButton.ClickImage = global::SpotifyMiniplayer.Properties.Resources.NextClick;
            this.NextButton.ForeColor = System.Drawing.Color.Transparent;
            this.NextButton.HoverImage = global::SpotifyMiniplayer.Properties.Resources.NextHover;
            this.NextButton.Image = global::SpotifyMiniplayer.Properties.Resources.Next;
            this.NextButton.Location = new System.Drawing.Point(362, 33);
            this.NextButton.Name = "NextButton";
            this.NextButton.NormalImage = global::SpotifyMiniplayer.Properties.Resources.Next;
            this.NextButton.Size = new System.Drawing.Size(30, 30);
            this.NextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NextButton.TabIndex = 2;
            this.NextButton.TabStop = false;
            this.NextButton.Click += new System.EventHandler(this.NextSong);
            // 
            // PrevButton
            // 
            this.PrevButton.BackColor = System.Drawing.Color.Transparent;
            this.PrevButton.ClickImage = global::SpotifyMiniplayer.Properties.Resources.PrevClick;
            this.PrevButton.ForeColor = System.Drawing.Color.Transparent;
            this.PrevButton.HoverImage = global::SpotifyMiniplayer.Properties.Resources.PrevHover;
            this.PrevButton.Image = global::SpotifyMiniplayer.Properties.Resources.Prev;
            this.PrevButton.Location = new System.Drawing.Point(152, 33);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.NormalImage = global::SpotifyMiniplayer.Properties.Resources.Prev;
            this.PrevButton.Size = new System.Drawing.Size(30, 30);
            this.PrevButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PrevButton.TabIndex = 1;
            this.PrevButton.TabStop = false;
            this.PrevButton.Click += new System.EventHandler(this.PrevSong);
            // 
            // PlayButton
            // 
            this.PlayButton.ActiveImage = global::SpotifyMiniplayer.Properties.Resources.Pause;
            this.PlayButton.ActiveImageHover = global::SpotifyMiniplayer.Properties.Resources.PauseHover;
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.ForeColor = System.Drawing.Color.Transparent;
            this.PlayButton.Image = global::SpotifyMiniplayer.Properties.Resources.Play;
            this.PlayButton.Location = new System.Drawing.Point(242, 18);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.NormalImage = global::SpotifyMiniplayer.Properties.Resources.Play;
            this.PlayButton.NormalImageHover = global::SpotifyMiniplayer.Properties.Resources.PlayHover;
            this.PlayButton.Size = new System.Drawing.Size(60, 60);
            this.PlayButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayButton.TabIndex = 6;
            this.PlayButton.TabStop = false;
            this.PlayButton.Click += new System.EventHandler(this.TogglePlay);
            // 
            // SongTitle
            // 
            this.SongTitle.AutoSize = true;
            this.SongTitle.AvailebleWidth = 370;
            this.SongTitle.Delay = 8000;
            this.SongTitle.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SongTitle.ForeColor = System.Drawing.Color.White;
            this.SongTitle.Location = new System.Drawing.Point(178, 19);
            this.SongTitle.Name = "SongTitle";
            this.SongTitle.Size = new System.Drawing.Size(369, 62);
            this.SongTitle.Speed = 10;
            this.SongTitle.TabIndex = 4;
            this.SongTitle.Text = "No playing track";
            this.SongTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // ArtistsNames
            // 
            this.ArtistsNames.AutoSize = true;
            this.ArtistsNames.AvailebleWidth = 370;
            this.ArtistsNames.Delay = 8000;
            this.ArtistsNames.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArtistsNames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(169)))));
            this.ArtistsNames.Location = new System.Drawing.Point(178, 81);
            this.ArtistsNames.Name = "ArtistsNames";
            this.ArtistsNames.Size = new System.Drawing.Size(144, 59);
            this.ArtistsNames.Speed = 10;
            this.ArtistsNames.TabIndex = 5;
            this.ArtistsNames.Text = "Artists";
            this.ArtistsNames.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.Cover);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SongTitle);
            this.Controls.Add(this.ArtistsNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Spotify Miniplayer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OnLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            ((System.ComponentModel.ISupportInitialize)(this.Cover)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoopButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShuffleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Cover;
        private System.Windows.Forms.Panel panel1;
        private IconButton NextButton;
        private IconButton PrevButton;
        private IconToggle LoopButton;
        private IconToggle ShuffleButton;
        private ProgressBar ProgressBar;
        private System.Windows.Forms.Timer UpdateInfoTimer;
        private IconToggle PlayButton;
        private ScrollingLabel SongTitle;
        private ScrollingLabel ArtistsNames;
    }
}