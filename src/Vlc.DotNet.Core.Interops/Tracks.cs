using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public class MediaTrack
    {
        public UInt32 CodecFourcc { get; set; }
        public UInt32 OriginalFourcc { get; set; }
        public int Id { get; set; }
        public MediaTrackTypes Type { get; set; }
        public int Profile { get; set; }
        public int Level { get; set; }
        public TrackInfo TrackInfo { get; set; }

        public uint Bitrate { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }

    public abstract class TrackInfo
    {
    }

    public class AudioTrack : TrackInfo
    {
        public uint Channels { get; set; }
        public uint Rate { get; set; }
    }

    public class VideoTrack : TrackInfo
    {
        public uint Height { get; set; }
        public uint Width { get; set; }

        public uint SarNum { get; set; }
        public uint SarDen { get; set; }

        public uint FrameRateNum { get; set; }
        public uint FrameRateDen { get; set; }

        public VideoOrientation Orientation { get; set; }
        public VideoProjection Projection { get; set; }
        public VideoViewpoint Pose { get; set; }
    }

    public class SubtitleTrack : TrackInfo
    {
        public string Encoding { get; set; }
    }
}