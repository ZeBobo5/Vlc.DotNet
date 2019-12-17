using System;
using System.Windows;

namespace Samples.Wpf.MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModels.MainViewModel  viewModel = new ViewModels.MainViewModel();
            this.DataContext = viewModel;
            viewModel.ImageOrVideoURL = "http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi";
            
        }
    }
}
