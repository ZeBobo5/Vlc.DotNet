using System;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    public struct ModuleDescription
    {
        public IntPtr Name;
        public IntPtr ShortName;
        public IntPtr LongName;
        public IntPtr Help;
        public IntPtr NextModule;
    }
}
