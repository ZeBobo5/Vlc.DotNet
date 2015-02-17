using System;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops
{
    internal static class IntPtrExtensions
    {
#if !NET20
        public static string ToStringAnsi(this IntPtr ptr)
#else
        public static string ToStringAnsi(IntPtr ptr)
#endif
        {
            return ptr != IntPtr.Zero ? Marshal.PtrToStringAnsi(ptr) : null;
        }
    }
}
