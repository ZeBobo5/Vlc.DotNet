using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{

    [StructLayout(LayoutKind.Explicit)]
    public struct MediaTrackInfosStructure
    {
        /// <summary>
        /// Codec Value
        /// </summary>
        [FieldOffset(0)]
        public int CodecFourcc;

        /// <summary>
        /// Codec Id
        /// </summary>
#if X86
        [FieldOffset(4)]
#else
        [FieldOffset(4)]
#endif
        public int Id;

        /// <summary>
        /// Type of Track
        /// </summary>
#if X86
        [FieldOffset(8)]
#else
        [FieldOffset(8)]
#endif
        public MediaTrackTypes Type;

        /// <summary>
        /// Codec Profile
        /// </summary>
#if X86
        [FieldOffset(12)]
#else
        [FieldOffset(12)]
#endif
        public int Profile;

        /// <summary>
        /// Codec Level
        /// </summary>
#if X86
        [FieldOffset(16)]
#else
        [FieldOffset(16)]
#endif
        public int Level;

        /// <summary>
        /// Audio Track Info
        /// </summary>
#if X86
        [FieldOffset(20)]
#else
        [FieldOffset(20)]
#endif
        public AudioStructure Audio;

        /// <summary>
        /// Video Track Info
        /// </summary>
#if X86
        [FieldOffset(20)]
#else
        [FieldOffset(20)]
#endif
        public VideoStructure Video;

        /// <summary>
        /// Codec Abbreviation
        /// </summary>
        public string CodecName
        {
            get
            {
#if NET20
                return string.Format(
                            "{0}{1}{2}{3}",
                            (char)(CodecFourcc & 0xff),
                            (char)(CodecFourcc >> 8 & 0xff),
                            (char)(CodecFourcc >> 16 & 0xff),
                            (char)(CodecFourcc >> 24 & 0xff));
#else
                return string.Format(
                            "{0}{1}{2}{3}",
                            (char)(CodecFourcc & 0xff),
                            (char)(CodecFourcc >> 8 & 0xff),
                            (char)(CodecFourcc >> 16 & 0xff),
                            (char)(CodecFourcc >> 24 & 0xff));
#endif
            }
        }


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
