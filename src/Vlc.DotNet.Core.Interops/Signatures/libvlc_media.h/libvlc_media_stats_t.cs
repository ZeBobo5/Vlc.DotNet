using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MediaStatsStructure
    {
        /* Input */
        public int ReadBytes;
        public float InputBitrate;

        /* Demux */
        public int DemuxReadBytes;
        public float DemuxBitrate;
        public int DemuxCorrupted;
        public int DemuxDiscontinuity;

        /* Decoders */
        public int DecodedVideo;
        public int DecodedAudio;


        /* Video Output */
        public int DisplayedPictures;
        public int LostPictures;

        /* Audio output */
        public int PlayedAudioBuffers;
        public int LostAudioBuffers;

        /* Stream output */
        public int SentPackets;
        public int SentBytes;
        public float SendBitrate;
    }
}
