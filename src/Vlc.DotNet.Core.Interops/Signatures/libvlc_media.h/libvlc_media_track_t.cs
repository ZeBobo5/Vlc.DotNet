using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct LibvlcMediaTrackT
    {
        public UInt32 Codec;
        public UInt32 OriginalFourCC;
        public int Id;
        public MediaTrackTypes Type;
        public int Profile;
        public int Level;
        public IntPtr TypedTrack;

        public uint Bitrate;
        public IntPtr Language;
        public IntPtr Description;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct LibvlcAudioTrackT
    {
        public uint Channels;
        public uint Rate;
    }

    public enum VideoOrientation
    {
        /// <summary>
        /// Normal. Top line represents top, left column left.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Flipped horizontally
        /// </summary>
        TopRight,

        /// <summary>
        /// Flipped vertically
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Rotated 180 degrees
        /// </summary>
        BottomRight,

        /// <summary>
        /// Transposed
        /// </summary>
        LeftTop,

        /// <summary>
        /// Rotated 90 degrees clockwise (or 270 anti-clockwise)
        /// </summary>
        LeftBottom,

        /// <summary>
        /// Rotated 90 degrees anti-clockwise
        /// </summary>
        RightTop,

        /// <summary>
        /// Anti-transposed
        /// </summary>
        RightBottom
    }

    public enum VideoProjection
    {
        Rectangular,
        Equirectangular,

        CubemapLayoutStandard = 0x100
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VideoViewpoint
    {
        /// <summary>
        /// view point yaw in degrees  ]-180;180]
        /// </summary>
        public float Yaw;

        /// <summary>
        /// view point pitch in degrees  ]-90;90]
        /// </summary>
        public float Pitch;

        /// <summary>
        /// view point roll in degrees ]-180;180]
        /// </summary>
        public float Roll;

        /// <summary>
        /// field of view in degrees ]0;180[ (default 80.)
        /// </summary>
        public float FieldOfView;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct LibvlcVideoTrackT
    {
        public uint Height;
        public uint Width;

        public uint SarNum;
        public uint SarDen;

        public uint FrameRateNum;
        public uint FrameRateDen;

        public VideoOrientation Orientation;
        public VideoProjection Projection;
        public VideoViewpoint Pose;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct LibvlcSubtitleTrackT
    {
        public IntPtr Encoding;
    }
}