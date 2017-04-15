using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Vlc.DotNet.Core.Interops;
using System.Windows.Forms.Integration;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Vlc.DotNet.Core;
using System.IO;

using Vlc.DotNet;

namespace Vlc.DotNet.Wpf
{
    public class VlcControl : WindowsFormsHost, INotifyPropertyChanged
    {
        public Forms.VlcControl MediaPlayer { get; private set; }

        public VlcControl()
        {
            MediaPlayer = new Forms.VlcControl();
            this.Child = MediaPlayer;

            RegistCallback();
        }

        #region interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region vlc callback

        void RegistCallback()
        {

            MediaPlayer.PositionChanged += PlayerPositionChanged;

            MediaPlayer.TimeChanged += TimeChanged;

            MediaPlayer.LengthChanged += LengthChanged;

            MediaPlayer.EndReached += MediaPlayer_EndReached;



        }


        void MediaPlayer_EndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                // set to start
                this.position = 0;
                RaisePropertyChanged("Position");

                this.isPlay = false;
            }));
        }



        void TimeChanged(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                time = e.NewTime;
                RaisePropertyChanged("Time");
            }));

        }

        void PlayerPositionChanged(object sender, VlcMediaPlayerPositionChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                position = e.NewPosition;

                RaisePropertyChanged("Position");

            }));

        }

        void LengthChanged(object sender, VlcMediaPlayerLengthChangedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                length = MediaPlayer.Length;
                RaisePropertyChanged("Length");

            }));
        }

        #endregion

        #region property

        #region time
        private Wpf.Time length = 0;
        public Wpf.Time Length
        {
            get { return length; }
        }

        private  Wpf.Time time = 0;
        public  Wpf.Time Time
        {
            get { return time; }
            set
            {
                if (!MediaPlayer.IsPlaying)
                    return;
                if (value == time) return;
                time = value;
                MediaPlayer.Time = value;
            }
        }


        private double position;
        public double Position
        {
            get { return position; }
            set
            {
                if (value < 0) return;
                if (value == position) return;
                position = value;
                MediaPlayer.Position = (float)value;
            }
        }

        #endregion


        private string source;
        public string Source
        {
            get { return source; }
            set
            {
                if (value == null) return;
                source = value;
                this.Open(source);
                RaisePropertyChanged("Source");
            }
        }



        #region vidoe or audio control

        private int volume;
        public int Volume
        {
            get { return volume; }
            set
            {
                if (volume < 0) return;

                volume = value;


                MediaPlayer.Audio.Volume = value;

                RaisePropertyChanged("Volume");
            }
        }

        private float rate;
        public float Rate
        {
            get { return rate; }
            set
            {
                if (rate < 0) return;
                rate = value;
                MediaPlayer.Rate = value;
                RaisePropertyChanged("Rate");
            }
        }

  
        private bool isPlay;
        public bool IsPlay
        {
            get { return isPlay; }
            set
            {
                if (!is_open)
                {
                    isPlay = false; return;
                }

                isPlay = value;
                if (value)
                    MediaPlayer.Play();
                else
                    MediaPlayer.Pause();

                RaisePropertyChanged("IsPlay");
            }

        }

        #endregion

        #endregion

        #region function

        bool is_open = false;
        public void Open(string path)
        {
            this.source = path;
            is_open = true;

            //timer.Stop();
            MediaPlayer.Pause();

            //detect path format
            if(path.Contains("http") || path.Contains("https"))
                MediaPlayer.SetMedia(new Uri(source));
            else
                MediaPlayer.SetMedia(new FileInfo(source), null);

            // is already open or play a media
            IsPlay = false;
            // go to start
            position = 0;
            RaisePropertyChanged("Position");

        }
        #endregion
    }
}
