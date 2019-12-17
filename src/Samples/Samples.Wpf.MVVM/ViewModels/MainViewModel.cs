using GalaSoft.MvvmLight; /* Or your MVV provider of choice */
using System;

namespace Samples.Wpf.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string imageOrVideoURL;
        public string ImageOrVideoURL
        {
            get { return imageOrVideoURL; }
            set { Set<string>(() => this.ImageOrVideoURL, ref imageOrVideoURL, value); } /* Set is a method in MVVM Light that wires up INotifyPropertyChanged events */
        }

    }
}