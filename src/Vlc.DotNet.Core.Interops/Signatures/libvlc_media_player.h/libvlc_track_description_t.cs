using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TrackDescriptionStructure
    {
        public int Id;
        public string Name;
        public IntPtr NextTrackDescription;
    }
}
