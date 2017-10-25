namespace Vlc.DotNet.Core.Interops
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// The class that allows easy conversion from and to UTF-8 character array
    /// </summary>
    public class Utf8InteropStringConverter
    {
        /// <summary>
        /// Converts a c-style byte array (const char*) in UTF-8 to a strign
        /// </summary>
        /// <param name="ptr">The c-style string pointer</param>
        /// <returns>The string object</returns>
        public static string Utf8InteropToString(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            var length = 0;

            while (Marshal.ReadByte(ptr, length) != 0)
            {
                length++;
            }

            byte[] buffer = new byte[length];
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        /// <summary>
        /// Allocates an area in memory that stores the Utf-8 bytes representing the input string.
        /// </summary>
        /// <param name="source">The source string to be converted to UTF-8 so that it can be passed to libvlc.</param>
        /// <returns>The safe handle</returns>
        public static Utf8StringHandle ToUtf8StringHandle(string source)
        {
            if (source == null)
            {
                return null;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(source);
            var buffer = Marshal.AllocHGlobal(bytes.Length + 1);
            try
            {
                Marshal.Copy(bytes, 0, buffer, bytes.Length);
                Marshal.WriteByte(buffer, bytes.Length, 0);
            }
            catch (Exception)
            {
                Marshal.FreeHGlobal(buffer);
                throw;
            }

            return new Utf8StringHandle(buffer);
        }
    }
}