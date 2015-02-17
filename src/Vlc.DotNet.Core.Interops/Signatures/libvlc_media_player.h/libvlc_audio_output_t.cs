using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioOutputDescriptionStructure
    {
        public string Name;
        public string Description;
        public IntPtr NextAudioOutputDescription;
    }
}
