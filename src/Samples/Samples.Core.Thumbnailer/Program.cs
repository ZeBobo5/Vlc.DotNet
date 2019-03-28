using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.Core.Thumbnailer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            // Default installation path of VideoLAN.LibVLC.Windows
            var libDirectory =
                new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            var destinationFolder = Path.Combine(currentDirectory, "thumbnails");

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            var options = new[]
            {
                "--intf", "dummy", /* no interface                   */
                "--vout", "dummy", /* we don't want video output     */
                "--no-audio", /* we don't want audio decoding   */
                "--no-video-title-show", /* nor the filename displayed     */
                "--no-stats", /* no stats */
                "--no-sub-autodetect-file", /* we don't want subtitles        */
                "--no-snapshot-preview", /* no blending in dummy vout      */
            };

            using (var mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory, options))
            {
                mediaPlayer.SetMedia(
                    new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_h264.mov"));


                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

                var lastSnapshot = 0L;
                mediaPlayer.TimeChanged += (sender, e) =>
                {
                    // Maps the time to a 5-seconds interval to take a snapshot every 5 seconds
                    var snapshotInterval = e.NewTime / 5000;

                    // Take a snapshot every 5 seconds
                    if (snapshotInterval > lastSnapshot)
                    {
                        lastSnapshot = snapshotInterval;
                        ThreadPool.QueueUserWorkItem(_ =>
                        {
                            mediaPlayer.TakeSnapshot(0, Path.Combine(destinationFolder, $"{snapshotInterval}.png"), 1024, 0);
                        });
                    }
                };

                mediaPlayer.EncounteredError += (sender, e) =>
                {
                    Console.Error.Write("An error occurred");
                    tcs.TrySetCanceled();
                };

                mediaPlayer.EndReached += (sender, e) => { ThreadPool.QueueUserWorkItem(_ => tcs.TrySetResult(true)); };

                mediaPlayer.Play();

                await tcs.Task;
            }
        }
    }
}
