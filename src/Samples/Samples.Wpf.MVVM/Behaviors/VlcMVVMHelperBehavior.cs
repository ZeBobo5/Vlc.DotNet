using System;
using System.Reflection;
using System.Windows;
using Vlc.DotNet.Wpf;
using System.IO;


namespace Samples.Wpf.MVVM.Behaviors
{
    public class VlcMVVMHelperBehavior
    {   

        private static readonly DependencyProperty VlcMVVMHelperSourceProperty =
        DependencyProperty.RegisterAttached(
          "Source", typeof(string), typeof(VlcMVVMHelperBehavior),
          new PropertyMetadata(new PropertyChangedCallback(HandleSourcePropertyChanged))
        );

        public static string GetSource(DependencyObject obj)
        {
            return (string)obj.GetValue(VlcMVVMHelperSourceProperty);
        }

        public static void SetSource(DependencyObject obj, bool value)
        {
            obj.SetValue(VlcMVVMHelperSourceProperty, value);
        }

        private static void HandleSourcePropertyChanged(
         DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is VlcControl control)
            {
                var currentAssembly = Assembly.GetEntryAssembly();
                var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
                // Default installation path of VideoLAN.LibVLC.Windows
                var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

                if (control.SourceProvider.MediaPlayer == null)
                {
                    control.SourceProvider.CreatePlayer(libDirectory);
                }
                else
                {
                    control.SourceProvider.MediaPlayer.ResetMedia();
                }
                
                //control.SourceProvider.MediaPlayer.Play(new Uri(content.ToString()));
                control.SourceProvider.MediaPlayer.Play(new Uri(args.NewValue.ToString()));
            }
        }

    }
}
