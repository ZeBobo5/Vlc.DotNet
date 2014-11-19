namespace Vlc.DotNet.Forms.Samples
{
    partial class Sample
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
            this.myVlcRincewindControl = new Vlc.DotNet.Forms.VlcControl();
            this.myBtnPlay = new System.Windows.Forms.Button();
            this.myBtnStop = new System.Windows.Forms.Button();
            this.myLblMediaLength = new System.Windows.Forms.Label();
            this.myLblVlcPosition = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.myLblState = new System.Windows.Forms.Label();
            this.myBtnPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myVlcRincewindControl)).BeginInit();
            this.SuspendLayout();
            // 
            // myVlcRincewindControl
            // 
            this.myVlcRincewindControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myVlcRincewindControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.myVlcRincewindControl.Location = new System.Drawing.Point(12, 12);
            this.myVlcRincewindControl.Name = "myVlcRincewindControl";
            this.myVlcRincewindControl.Size = new System.Drawing.Size(679, 338);
            this.myVlcRincewindControl.TabIndex = 0;
            this.myVlcRincewindControl.Text = "vlcRincewindControl1";
            this.myVlcRincewindControl.VlcLibDirectory = null;
            this.myVlcRincewindControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            this.myVlcRincewindControl.LengthChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs>(this.OnVlcMediaLengthChanged);
            this.myVlcRincewindControl.Paused += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs>(this.OnVlcPaused);
            this.myVlcRincewindControl.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.OnVlcPlaying);
            this.myVlcRincewindControl.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs>(this.OnVlcPositionChanged);
            this.myVlcRincewindControl.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.OnVlcStopped);
            // 
            // myBtnPlay
            // 
            this.myBtnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myBtnPlay.Location = new System.Drawing.Point(12, 356);
            this.myBtnPlay.Name = "myBtnPlay";
            this.myBtnPlay.Size = new System.Drawing.Size(75, 23);
            this.myBtnPlay.TabIndex = 1;
            this.myBtnPlay.Text = "Play";
            this.myBtnPlay.UseVisualStyleBackColor = true;
            this.myBtnPlay.Click += new System.EventHandler(this.OnButtonPlayClicked);
            // 
            // myBtnStop
            // 
            this.myBtnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myBtnStop.Location = new System.Drawing.Point(174, 356);
            this.myBtnStop.Name = "myBtnStop";
            this.myBtnStop.Size = new System.Drawing.Size(75, 23);
            this.myBtnStop.TabIndex = 2;
            this.myBtnStop.Text = "Stop";
            this.myBtnStop.UseVisualStyleBackColor = true;
            this.myBtnStop.Click += new System.EventHandler(this.OnButtonStopClicked);
            // 
            // myLblMediaLength
            // 
            this.myLblMediaLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myLblMediaLength.AutoSize = true;
            this.myLblMediaLength.Location = new System.Drawing.Point(328, 361);
            this.myLblMediaLength.Name = "myLblMediaLength";
            this.myLblMediaLength.Size = new System.Drawing.Size(49, 13);
            this.myLblMediaLength.TabIndex = 3;
            this.myLblMediaLength.Text = "00:00:00";
            // 
            // myLblVlcPosition
            // 
            this.myLblVlcPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myLblVlcPosition.AutoSize = true;
            this.myLblVlcPosition.Location = new System.Drawing.Point(255, 361);
            this.myLblVlcPosition.Name = "myLblVlcPosition";
            this.myLblVlcPosition.Size = new System.Drawing.Size(49, 13);
            this.myLblVlcPosition.TabIndex = 4;
            this.myLblVlcPosition.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "/";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "State:";
            // 
            // myLblState
            // 
            this.myLblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myLblState.AutoSize = true;
            this.myLblState.Location = new System.Drawing.Point(437, 361);
            this.myLblState.Name = "myLblState";
            this.myLblState.Size = new System.Drawing.Size(0, 13);
            this.myLblState.TabIndex = 7;
            // 
            // myBtnPause
            // 
            this.myBtnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.myBtnPause.Location = new System.Drawing.Point(93, 356);
            this.myBtnPause.Name = "myBtnPause";
            this.myBtnPause.Size = new System.Drawing.Size(75, 23);
            this.myBtnPause.TabIndex = 8;
            this.myBtnPause.Text = "Pause";
            this.myBtnPause.UseVisualStyleBackColor = true;
            this.myBtnPause.Click += new System.EventHandler(this.OnButtonPauseClicked);
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 391);
            this.Controls.Add(this.myBtnPause);
            this.Controls.Add(this.myLblState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.myLblVlcPosition);
            this.Controls.Add(this.myLblMediaLength);
            this.Controls.Add(this.myBtnStop);
            this.Controls.Add(this.myBtnPlay);
            this.Controls.Add(this.myVlcRincewindControl);
            this.Name = "Sample";
            this.Text = "Vlc.DotNet - Winform Player Sample";
            ((System.ComponentModel.ISupportInitialize)(this.myVlcRincewindControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VlcControl myVlcRincewindControl;
        private System.Windows.Forms.Button myBtnPlay;
        private System.Windows.Forms.Button myBtnStop;
        private System.Windows.Forms.Label myLblMediaLength;
        private System.Windows.Forms.Label myLblVlcPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label myLblState;
        private System.Windows.Forms.Button myBtnPause;
    }
}

