using System;
using System.IO;
using System.Reflection;

namespace Samples.Core.Streaming
{
    class Program
    {
        static void Main()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory =
                new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            using (var mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory))
            {

                var mediaOptions = new[]
                {
                    ":sout=#rtp{sdp=rtsp://127.0.0.1:554/}",
                    ":sout-keep"
                };

                mediaPlayer.SetMedia(new Uri("http://hls1.addictradio.net/addictrock_aac_hls/playlist.m3u8"),
                    mediaOptions);

                mediaPlayer.Play();

                Console.WriteLine("Streaming on rtsp://127.0.0.1:554/");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
