using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct LibvlcAudioOutputDeviceT
    {
        public IntPtr Next;
        public IntPtr DeviceIdentifier;
        public IntPtr Description;
    }
}