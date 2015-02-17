using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops
{
    internal static class StringExtensions
    {
#if !NET20
        public static IntPtr ToHGlobalAnsi(this string source)
#else
        public static IntPtr ToHGlobalAnsi(string source)
#endif
        {
            if (source == null)
                return IntPtr.Zero;
            return Marshal.StringToHGlobalAnsi(source);
        }
    }
}
