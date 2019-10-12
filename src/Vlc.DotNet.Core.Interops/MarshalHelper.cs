using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    /// <summary>
    /// The helper class that helps to call Marshal.XXX methods in a multi-framework way
    /// </summary>
    public static class MarshalHelper
    {
        /// <summary>
        /// Converts a pointer to a C structure into a C# structure
        /// </summary>
        /// <typeparam name="T">The type of structure to convert</typeparam>
        /// <param name="ptr">The pointer</param>
        /// <returns>The converted structure</returns>
        public static T PtrToStructure<T>(IntPtr ptr) where T: struct
        {
#if NET35 || NET40 || NET45
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
#else
            return Marshal.PtrToStructure<T>(ptr);
#endif
        }

        /// <summary>
        /// Gets the size in bytes of a structure
        /// </summary>
        /// <typeparam name="T">The structure type</typeparam>
        /// <returns>The number of bytes in the structure</returns>
        public static int SizeOf<T>()
        {
#if NET35 || NET40 || NET45
            return Marshal.SizeOf(typeof(T));
#else
            return Marshal.SizeOf<T>();
#endif
        }

        /// <summary>
        /// Gets the delegate of the function at the given address
        /// </summary>
        /// <typeparam name="T">The delegate type</typeparam>
        /// <param name="ptr">The pointer to the C function</param>
        /// <returns>The delegate</returns>
        public static T GetDelegateForFunctionPointer<T>(IntPtr ptr)
        {
#if NET35 || NET40 || NET45
            return (T)(object)Marshal.GetDelegateForFunctionPointer(ptr, typeof(T));
#else
            // The GetDelegateForFunctionPointer with two parameters is now deprecated.
            return Marshal.GetDelegateForFunctionPointer<T>(ptr);
#endif
        }
    }
}