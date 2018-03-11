namespace Vlc.DotNet.Core.Interops
{
    using System;
    using System.Text;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Converters for manipulating 4CC (4 char codes), used in libvlc to identify codecs
    /// </summary>
    public static class FourCCConverter
    {
        /// <summary>
        /// Converts a 4CC integer to a string
        /// </summary>
        /// <param name="fourCC">The fourcc code</param>
        /// <returns>The string representation of this 4CC</returns>
        public static string FromFourCC(UInt32 fourCC)
        {
            return string.Format(
                "{0}{1}{2}{3}",
                (char)(fourCC & 0xff),
                (char)(fourCC >> 8 & 0xff),
                (char)(fourCC >> 16 & 0xff),
                (char)(fourCC >> 24 & 0xff));
        }

        /// <summary>
        /// Converts a 4CC string representation to its UInt32 equivalent
        /// </summary>
        /// <param name="fourCCString">The 4CC string</param>
        /// <returns>The UInt32 representation of the 4cc</returns>
        public static UInt32 ToFourCC(string fourCCString)
        {
            if (fourCCString.Length != 4)
            {
                throw new ArgumentException("4CC codes must be 4 characters long", nameof(fourCCString));
            }

            var bytes = Encoding.ASCII.GetBytes(fourCCString);
            return (UInt32)bytes[0] &
                   (UInt32)bytes[1] << 8 &
                   (UInt32)bytes[2] << 16 &
                   (UInt32)bytes[3] << 24;
        }
        
        /// <summary>
        /// Converts a 4CC string representation to its UInt32 equivalent, and write it to the memory
        /// </summary>
        /// <param name="fourCCString">The 4CC string</param>
        /// <param name="destination">The pointer to where to write the bytes</param>
        public static void ToFourCC(string fourCCString, IntPtr destination)
        {
            if (fourCCString.Length != 4)
            {
                throw new ArgumentException("4CC codes must be 4 characters long", nameof(fourCCString));
            }

            var bytes = Encoding.ASCII.GetBytes(fourCCString);

            for (var i = 0; i < 4; i++)
            {
                Marshal.WriteByte(destination, i, bytes[i]);
            }
        }
    }
}