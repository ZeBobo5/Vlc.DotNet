using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ModuleDescriptionStructure
    {
        public IntPtr Name;
        public IntPtr ShortName;
        public IntPtr LongName;
        public IntPtr Help;
        public IntPtr NextModule;
    }
}
