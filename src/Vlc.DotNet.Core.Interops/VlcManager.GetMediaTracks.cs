using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public MediaTrack[] GetMediaTracks(VlcMediaInstance mediaInstance)
        {
            if (mediaInstance == IntPtr.Zero)
                throw new ArgumentException("Media instance is not initialized.");

            var cpt = myLibraryLoader.GetInteropDelegate<GetMediaTracks>().Invoke(mediaInstance, out var fullBuffer);
            if (cpt <= 0)
                return new MediaTrack[0];
            try
            {
                var result = new MediaTrack[cpt];
                for (int index = 0; index < cpt; index++)
                {
                    var current = MarshalHelper.PtrToStructure<LibvlcMediaTrackT>(Marshal.ReadIntPtr(fullBuffer, index * MarshalHelper.SizeOf<IntPtr>()));

                    TrackInfo trackInfo = null;

                    switch (current.Type)
                    {
                        case MediaTrackTypes.Audio:
                            var audio = MarshalHelper.PtrToStructure<LibvlcAudioTrackT>(current.TypedTrack);
                            trackInfo = new AudioTrack
                            {
                                Channels = audio.Channels,
                                Rate = audio.Rate
                            };
                            break;
                        case MediaTrackTypes.Video:
                            var video = MarshalHelper.PtrToStructure<LibvlcVideoTrackT>(current.TypedTrack);
                            trackInfo = new VideoTrack
                            {
                                Height = video.Height,
                                Width = video.Width,
                                SarNum = video.SarNum,
                                SarDen = video.SarDen,
                                FrameRateNum = video.FrameRateNum,
                                FrameRateDen = video.FrameRateDen,
                                Orientation = video.Orientation,
                                Projection = video.Projection,
                                Pose = video.Pose
                            };
                            break;
                        case MediaTrackTypes.Text:
                            var text = MarshalHelper.PtrToStructure<LibvlcSubtitleTrackT>(current.TypedTrack);
                            trackInfo = new SubtitleTrack
                            {
                                Encoding = Utf8InteropStringConverter.Utf8InteropToString(text.Encoding)
                            };
                            break;
                    }

                    result[index] = new MediaTrack
                    {
                        CodecFourcc = current.Codec,
                        OriginalFourcc = current.OriginalFourCC,
                        Id = current.Id,
                        Type = current.Type,
                        Profile = current.Profile,
                        Level = current.Level,
                        TrackInfo = trackInfo,
                        Bitrate = current.Bitrate,
                        Language = Utf8InteropStringConverter.Utf8InteropToString(current.Language),
                        Description = Utf8InteropStringConverter.Utf8InteropToString(current.Description)
                    };
                }
                return result;
            }
            finally
            {
                myLibraryLoader.GetInteropDelegate<ReleaseMediaTracks>().Invoke(fullBuffer, cpt);
            }
        }
    }
}
