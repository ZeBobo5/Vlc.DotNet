using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [Obsolete("Use GetMediaTracks instead")]
    [StructLayout(LayoutKind.Explicit)]
    public struct MediaTrackInfosStructure
    {
        /// <summary>
        /// Codec Value
        /// </summary>
        [FieldOffset(0)]
        public UInt32 CodecFourcc;

        /// <summary>
        /// Codec Id
        /// </summary>
        [FieldOffset(4)]
        public int Id;

        /// <summary>
        /// Type of Track
        /// </summary>
        [FieldOffset(8)]
        public MediaTrackTypes Type;

        /// <summary>
        /// Codec Profile
        /// </summary>
        [FieldOffset(12)]
        public int Profile;

        /// <summary>
        /// Codec Level
        /// </summary>
        [FieldOffset(16)]
        public int Level;

        /// <summary>
        /// Audio Track Info
        /// </summary>
        [FieldOffset(20)]
        public AudioStructure Audio;

        /// <summary>
        /// Video Track Info
        /// </summary>
        [FieldOffset(20)]
        public VideoStructure Video;

        /// <summary>
        /// Codec Abbreviation
        /// </summary>
        public string CodecName => FourCCConverter.FromFourCC(this.CodecFourcc);
    }

    /// <summary>
    /// Audio information of Media Track
    /// </summary>
    public struct AudioStructure
    {
        /// <summary>
        /// Number of Channels
        /// </summary>
        public uint Channels;

        /// <summary>
        /// Audio Sampling Rate
        /// </summary>
        public uint Rate;
    }

    /// <summary>
    /// Video information of Media Track
    /// </summary>
    public struct VideoStructure
    {
        /// <summary>
        /// Height of Video
        /// </summary>
        public uint Height;

        /// <summary>
        /// Width of Video
        /// </summary>
        public uint Width;
    }

}
