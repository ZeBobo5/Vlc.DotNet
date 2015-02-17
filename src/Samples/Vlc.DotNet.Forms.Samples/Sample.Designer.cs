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
            this.myVlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.myBtnPlay = new System.Windows.Forms.Button();
            this.myBtnStop = new System.Windows.Forms.Button();
            this.myLblMediaLength = new System.Windows.Forms.Label();
            this.myLblVlcPosition = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.myLblState = new System.Windows.Forms.Label();
            this.myBtnPause = new System.Windows.Forms.Button();
            this.myGrpAudioInformations = new System.Windows.Forms.GroupBox();
            this.myLblAudioRate = new System.Windows.Forms.Label();
            this.myLblAudioChannels = new System.Windows.Forms.Label();
            this.myLblAudioCodec = new System.Windows.Forms.Label();
            this.myGrpVideoInformations = new System.Windows.Forms.GroupBox();
            this.myLblVideoWidth = new System.Windows.Forms.Label();
            this.myLblVideoCodec = new System.Windows.Forms.Label();
            this.myLblVideoHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myVlcControl)).BeginInit();
            this.myGrpAudioInformations.SuspendLayout();
            this.myGrpVideoInformations.SuspendLayout();
            this.SuspendLayout();
            // 
            // myVlcControl
            // 
            this.myVlcControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myVlcControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.myVlcControl.Location = new System.Drawing.Point(12, 12);
            this.myVlcControl.Name = "myVlcControl";
            this.myVlcControl.Size = new System.Drawing.Size(564, 338);
            this.myVlcControl.TabIndex = 0;
            this.myVlcControl.Text = "vlcRincewindControl1";
            this.myVlcControl.VlcLibDirectory = null;
            this.myVlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            this.myVlcControl.LengthChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs>(this.OnVlcMediaLengthChanged);
            this.myVlcControl.Paused += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs>(this.OnVlcPaused);
            this.myVlcControl.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.OnVlcPlaying);
            this.myVlcControl.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs>(this.OnVlcPositionChanged);
            this.myVlcControl.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.OnVlcStopped);
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
            // myGrpAudioInformations
            // 
            this.myGrpAudioInformations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myGrpAudioInformations.Controls.Add(this.myLblAudioRate);
            this.myGrpAudioInformations.Controls.Add(this.myLblAudioChannels);
            this.myGrpAudioInformations.Controls.Add(this.myLblAudioCodec);
            this.myGrpAudioInformations.Location = new System.Drawing.Point(582, 12);
            this.myGrpAudioInformations.Name = "myGrpAudioInformations";
            this.myGrpAudioInformations.Size = new System.Drawing.Size(219, 77);
            this.myGrpAudioInformations.TabIndex = 9;
            this.myGrpAudioInformations.TabStop = false;
            this.myGrpAudioInformations.Text = "Audio informations";
            // 
            // myLblAudioRate
            // 
            this.myLblAudioRate.AutoSize = true;
            this.myLblAudioRate.Location = new System.Drawing.Point(7, 52);
            this.myLblAudioRate.Name = "myLblAudioRate";
            this.myLblAudioRate.Size = new System.Drawing.Size(33, 13);
            this.myLblAudioRate.TabIndex = 2;
            this.myLblAudioRate.Text = "Rate:";
            // 
            // myLblAudioChannels
            // 
            this.myLblAudioChannels.AutoSize = true;
            this.myLblAudioChannels.Location = new System.Drawing.Point(7, 36);
            this.myLblAudioChannels.Name = "myLblAudioChannels";
            this.myLblAudioChannels.Size = new System.Drawing.Size(54, 13);
            this.myLblAudioChannels.TabIndex = 1;
            this.myLblAudioChannels.Text = "Channels:";
            // 
            // myLblAudioCodec
            // 
            this.myLblAudioCodec.AutoSize = true;
            this.myLblAudioCodec.Location = new System.Drawing.Point(7, 20);
            this.myLblAudioCodec.Name = "myLblAudioCodec";
            this.myLblAudioCodec.Size = new System.Drawing.Size(41, 13);
            this.myLblAudioCodec.TabIndex = 0;
            this.myLblAudioCodec.Text = "Codec:";
            // 
            // myGrpVideoInformations
            // 
            this.myGrpVideoInformations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myGrpVideoInformations.Controls.Add(this.myLblVideoWidth);
            this.myGrpVideoInformations.Controls.Add(this.myLblVideoCodec);
            this.myGrpVideoInformations.Controls.Add(this.myLblVideoHeight);
            this.myGrpVideoInformations.Location = new System.Drawing.Point(582, 95);
            this.myGrpVideoInformations.Name = "myGrpVideoInformations";
            this.myGrpVideoInformations.Size = new System.Drawing.Size(219, 74);
            this.myGrpVideoInformations.TabIndex = 10;
            this.myGrpVideoInformations.TabStop = false;
            this.myGrpVideoInformations.Text = "Video informations";
            // 
            // myLblVideoWidth
            // 
            this.myLblVideoWidth.AutoSize = true;
            this.myLblVideoWidth.Location = new System.Drawing.Point(6, 48);
            this.myLblVideoWidth.Name = "myLblVideoWidth";
            this.myLblVideoWidth.Size = new System.Drawing.Size(38, 13);
            this.myLblVideoWidth.TabIndex = 5;
            this.myLblVideoWidth.Text = "Width:";
            // 
            // myLblVideoCodec
            // 
            this.myLblVideoCodec.AutoSize = true;
            this.myLblVideoCodec.Location = new System.Drawing.Point(6, 16);
            this.myLblVideoCodec.Name = "myLblVideoCodec";
            this.myLblVideoCodec.Size = new System.Drawing.Size(41, 13);
            this.myLblVideoCodec.TabIndex = 3;
            this.myLblVideoCodec.Text = "Codec:";
            // 
            // myLblVideoHeight
            // 
            this.myLblVideoHeight.AutoSize = true;
            this.myLblVideoHeight.Location = new System.Drawing.Point(6, 32);
            this.myLblVideoHeight.Name = "myLblVideoHeight";
            this.myLblVideoHeight.Size = new System.Drawing.Size(41, 13);
            this.myLblVideoHeight.TabIndex = 4;
            this.myLblVideoHeight.Text = "Height:";
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 391);
            this.Controls.Add(this.myGrpVideoInformations);
            this.Controls.Add(this.myGrpAudioInformations);
            this.Controls.Add(this.myBtnPause);
            this.Controls.Add(this.myLblState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.myLblVlcPosition);
            this.Controls.Add(this.myLblMediaLength);
            this.Controls.Add(this.myBtnStop);
            this.Controls.Add(this.myBtnPlay);
            this.Controls.Add(this.myVlcControl);
            this.Name = "Sample";
            this.Text = "Vlc.DotNet - Winform Player Sample";
            ((System.ComponentModel.ISupportInitialize)(this.myVlcControl)).EndInit();
            this.myGrpAudioInformations.ResumeLayout(false);
            this.myGrpAudioInformations.PerformLayout();
            this.myGrpVideoInformations.ResumeLayout(false);
            this.myGrpVideoInformations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VlcControl myVlcControl;
        private System.Windows.Forms.Button myBtnPlay;
        private System.Windows.Forms.Button myBtnStop;
        private System.Windows.Forms.Label myLblMediaLength;
        private System.Windows.Forms.Label myLblVlcPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label myLblState;
        private System.Windows.Forms.Button myBtnPause;
        private System.Windows.Forms.GroupBox myGrpAudioInformations;
        private System.Windows.Forms.GroupBox myGrpVideoInformations;
        private System.Windows.Forms.Label myLblAudioRate;
        private System.Windows.Forms.Label myLblAudioChannels;
        private System.Windows.Forms.Label myLblAudioCodec;
        private System.Windows.Forms.Label myLblVideoWidth;
        private System.Windows.Forms.Label myLblVideoCodec;
        private System.Windows.Forms.Label myLblVideoHeight;
    }
}

