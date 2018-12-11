namespace Samples.WinForms.Advanced
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
            this.myCbxAspectRatio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.myGrpMouseInformations = new System.Windows.Forms.GroupBox();
            this.myLblMouseOnCtl = new System.Windows.Forms.Label();
            this.myLblMouseState = new System.Windows.Forms.Label();
            this.myLblKeyCode = new System.Windows.Forms.Label();
            this.myLblKeyDown = new System.Windows.Forms.Label();
            this.myBtnEnableMouseEvents = new System.Windows.Forms.Button();
            this.myBtnDisableMouseEvents = new System.Windows.Forms.Button();
            this.myVlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.label4 = new System.Windows.Forms.Label();
            this.myCbxAudioOutputs = new System.Windows.Forms.ComboBox();
            this.myGrpAudioInformations.SuspendLayout();
            this.myGrpVideoInformations.SuspendLayout();
            this.myGrpMouseInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myVlcControl)).BeginInit();
            this.SuspendLayout();
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
            // myCbxAspectRatio
            // 
            this.myCbxAspectRatio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myCbxAspectRatio.Enabled = false;
            this.myCbxAspectRatio.FormattingEnabled = true;
            this.myCbxAspectRatio.Items.AddRange(new object[] {
            "16:9",
            "16:10",
            "4:3"});
            this.myCbxAspectRatio.Location = new System.Drawing.Point(680, 170);
            this.myCbxAspectRatio.Name = "myCbxAspectRatio";
            this.myCbxAspectRatio.Size = new System.Drawing.Size(121, 21);
            this.myCbxAspectRatio.TabIndex = 11;
            this.myCbxAspectRatio.TextChanged += new System.EventHandler(this.myCbxAspectRatio_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Video Aspect Ratio:";
            // 
            // myGrpMouseInformations
            // 
            this.myGrpMouseInformations.Controls.Add(this.myLblMouseOnCtl);
            this.myGrpMouseInformations.Controls.Add(this.myLblMouseState);
            this.myGrpMouseInformations.Controls.Add(this.myLblKeyCode);
            this.myGrpMouseInformations.Controls.Add(this.myLblKeyDown);
            this.myGrpMouseInformations.Location = new System.Drawing.Point(583, 197);
            this.myGrpMouseInformations.Name = "myGrpMouseInformations";
            this.myGrpMouseInformations.Size = new System.Drawing.Size(218, 77);
            this.myGrpMouseInformations.TabIndex = 14;
            this.myGrpMouseInformations.TabStop = false;
            this.myGrpMouseInformations.Text = "Input Informations";
            // 
            // myLblMouseOnCtl
            // 
            this.myLblMouseOnCtl.AutoSize = true;
            this.myLblMouseOnCtl.Location = new System.Drawing.Point(6, 55);
            this.myLblMouseOnCtl.Name = "myLblMouseOnCtl";
            this.myLblMouseOnCtl.Size = new System.Drawing.Size(110, 13);
            this.myLblMouseOnCtl.TabIndex = 3;
            this.myLblMouseOnCtl.Text = "Mouse On VlcControl:";
            // 
            // myLblMouseState
            // 
            this.myLblMouseState.AutoSize = true;
            this.myLblMouseState.Location = new System.Drawing.Point(6, 42);
            this.myLblMouseState.Name = "myLblMouseState";
            this.myLblMouseState.Size = new System.Drawing.Size(70, 13);
            this.myLblMouseState.TabIndex = 2;
            this.myLblMouseState.Text = "Mouse State:";
            // 
            // myLblKeyCode
            // 
            this.myLblKeyCode.AutoSize = true;
            this.myLblKeyCode.Location = new System.Drawing.Point(6, 16);
            this.myLblKeyCode.Name = "myLblKeyCode";
            this.myLblKeyCode.Size = new System.Drawing.Size(55, 13);
            this.myLblKeyCode.TabIndex = 1;
            this.myLblKeyCode.Text = "Key: none";
            // 
            // myLblKeyDown
            // 
            this.myLblKeyDown.AutoSize = true;
            this.myLblKeyDown.Location = new System.Drawing.Point(6, 29);
            this.myLblKeyDown.Name = "myLblKeyDown";
            this.myLblKeyDown.Size = new System.Drawing.Size(84, 13);
            this.myLblKeyDown.TabIndex = 0;
            this.myLblKeyDown.Text = "Key Down: false";
            // 
            // myBtnEnableMouseEvents
            // 
            this.myBtnEnableMouseEvents.Location = new System.Drawing.Point(583, 309);
            this.myBtnEnableMouseEvents.Name = "myBtnEnableMouseEvents";
            this.myBtnEnableMouseEvents.Size = new System.Drawing.Size(159, 23);
            this.myBtnEnableMouseEvents.TabIndex = 15;
            this.myBtnEnableMouseEvents.Text = "Enable Player Input Events";
            this.myBtnEnableMouseEvents.UseVisualStyleBackColor = true;
            this.myBtnEnableMouseEvents.Click += new System.EventHandler(this.myBtnEnableMouseEvents_Click);
            // 
            // myBtnDisableMouseEvents
            // 
            this.myBtnDisableMouseEvents.Location = new System.Drawing.Point(583, 280);
            this.myBtnDisableMouseEvents.Name = "myBtnDisableMouseEvents";
            this.myBtnDisableMouseEvents.Size = new System.Drawing.Size(159, 23);
            this.myBtnDisableMouseEvents.TabIndex = 16;
            this.myBtnDisableMouseEvents.Text = "Disable Player Input Events";
            this.myBtnDisableMouseEvents.UseVisualStyleBackColor = true;
            this.myBtnDisableMouseEvents.Click += new System.EventHandler(this.myBtnDisableMouseEvents_Click);
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
            this.myVlcControl.Spu = -1;
            this.myVlcControl.TabIndex = 0;
            this.myVlcControl.Text = "vlcRincewindControl1";
            this.myVlcControl.VlcLibDirectory = null;
            this.myVlcControl.VlcMediaplayerOptions = null;
            this.myVlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            this.myVlcControl.LengthChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs>(this.OnVlcMediaLengthChanged);
            this.myVlcControl.Log += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLogEventArgs>(this.OnVlcMediaPlayerLog);
            this.myVlcControl.Paused += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPausedEventArgs>(this.OnVlcPaused);
            this.myVlcControl.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.OnVlcPlaying);
            this.myVlcControl.TimeChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs>(this.OnVlcTimeChanged);
            this.myVlcControl.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.OnVlcStopped);
            this.myVlcControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myVlcControl_KeyDown);
            this.myVlcControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myVlcControl_KeyPress);
            this.myVlcControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.myVlcControl_KeyUp);
            this.myVlcControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myVlcControl_MouseClick);
            this.myVlcControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myVlcControl_MouseDown);
            this.myVlcControl.MouseEnter += new System.EventHandler(this.myVlcControl_MouseEnter);
            this.myVlcControl.MouseLeave += new System.EventHandler(this.myVlcControl_MouseLeave);
            this.myVlcControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.myVlcControl_MouseUp);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Audio Output:";
            // 
            // myCbxAudioOutputs
            // 
            this.myCbxAudioOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myCbxAudioOutputs.FormattingEnabled = true;
            this.myCbxAudioOutputs.Location = new System.Drawing.Point(658, 338);
            this.myCbxAudioOutputs.Name = "myCbxAudioOutputs";
            this.myCbxAudioOutputs.Size = new System.Drawing.Size(143, 21);
            this.myCbxAudioOutputs.TabIndex = 17;
            // 
            // Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 391);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.myCbxAudioOutputs);
            this.Controls.Add(this.myBtnDisableMouseEvents);
            this.Controls.Add(this.myBtnEnableMouseEvents);
            this.Controls.Add(this.myGrpMouseInformations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.myCbxAspectRatio);
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
            this.SizeChanged += new System.EventHandler(this.Sample_SizeChanged);
            this.myGrpAudioInformations.ResumeLayout(false);
            this.myGrpAudioInformations.PerformLayout();
            this.myGrpVideoInformations.ResumeLayout(false);
            this.myGrpVideoInformations.PerformLayout();
            this.myGrpMouseInformations.ResumeLayout(false);
            this.myGrpMouseInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myVlcControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl myVlcControl;
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
        private System.Windows.Forms.ComboBox myCbxAspectRatio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox myGrpMouseInformations;
        private System.Windows.Forms.Label myLblMouseOnCtl;
        private System.Windows.Forms.Label myLblMouseState;
        private System.Windows.Forms.Label myLblKeyCode;
        private System.Windows.Forms.Label myLblKeyDown;
        private System.Windows.Forms.Button myBtnEnableMouseEvents;
        private System.Windows.Forms.Button myBtnDisableMouseEvents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox myCbxAudioOutputs;
    }
}

