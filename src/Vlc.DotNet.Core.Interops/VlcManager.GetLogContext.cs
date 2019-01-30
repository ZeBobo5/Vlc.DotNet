using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    using System.Runtime.InteropServices;

    public sealed partial class VlcManager
    {
        /// <summary>
        /// Gets log message debug infos.
        ///
        /// This function retrieves self-debug information about a log message:
        /// - the name of the VLC module emitting the message,
        /// - the name of the source code module (i.e.file) and
        /// - the line number within the source code module.
        ///
        /// The returned module name and file name will be NULL if unknown.
        /// The returned line number will similarly be zero if unknown.
        /// </summary>
        /// <param name="logContext">The log message context (as passed to the <see cref="LogCallback"/>)</param>
        /// <param name="module">The module name storage.</param>
        /// <param name="file">The source code file name storage.</param>
        /// <param name="line">The source code file line number storage.</param>
        public void GetLogContext(IntPtr logContext, out string module, out string file, out uint? line)
        {
            UIntPtr line2;
            IntPtr module2;
            IntPtr file2;
            myLibraryLoader.GetInteropDelegate<GetLogContext>().Invoke(logContext, out module2, out file2, out line2);
            if (line2 == UIntPtr.Zero)
            {
                line = null;
            }
            else
            {
                line = line2.ToUInt32();
            }

            module = Utf8InteropStringConverter.Utf8InteropToString(module2);
            file = Utf8InteropStringConverter.Utf8InteropToString(file2);
        }
    }
}
