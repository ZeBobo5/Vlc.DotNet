using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Vlc.DotNet.Wpf
{
    using System.Windows.Controls;

    /// <summary>
    /// The Wpf component that allows to display a video in a Wpf way
    /// </summary>
    public class VlcControl: UserControl, IDisposable
    {
        /// <summary>
        /// The Viewbox that contains the video image
        /// </summary>
        private Viewbox viewBox;

        /// <summary>
        /// The image that displays the video
        /// </summary>
        private readonly Image videoContent = new Image { ClipToBounds = true };

        /// <summary>
        /// The class that provides video source
        /// </summary>
        private readonly VlcVideoSourceProvider sourceProvider;

        public VlcVideoSourceProvider SourceProvider => sourceProvider;

        /// <summary>
        /// Defines if <see cref="VlcVideoSourceProvider.VideoSource"/> pixel format is <see cref="PixelFormats.Bgr32"/> or <see cref="PixelFormats.Bgra32"/>
        /// </summary>
        public bool IsAlphaChannelEnabled
        {
            get
            {
                return sourceProvider.IsAlphaChannelEnabled;
            }

            set
            {
                sourceProvider.IsAlphaChannelEnabled = value;
            }
        }
        
        /// <summary>
        /// The constructor
        /// </summary>
        public VlcControl()
        {
            sourceProvider = new VlcVideoSourceProvider(this.Dispatcher);
            this.viewBox = new Viewbox
            {
                Child = this.videoContent,
                Stretch = Stretch.Uniform
            };

            this.Content = this.viewBox;
            this.Background = Brushes.Black;
            // Binds the VideoSource to the Image.Source property
            this.videoContent.SetBinding(Image.SourceProperty, new Binding(nameof(VlcVideoSourceProvider.VideoSource)) { Source = sourceProvider });
        }

        /// <inheritdoc />
        public void Dispose()
        {
            sourceProvider.Dispose();
        }
    }
}