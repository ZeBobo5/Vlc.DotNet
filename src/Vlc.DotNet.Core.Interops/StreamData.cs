using System;
using System.IO;

namespace Vlc.DotNet.Core.Interops
{
    internal class StreamData
    {
        public IntPtr Handle { get; set; }
        public Stream Stream { get; set; }
        public byte[] Buffer { get; set; }
    }
}
