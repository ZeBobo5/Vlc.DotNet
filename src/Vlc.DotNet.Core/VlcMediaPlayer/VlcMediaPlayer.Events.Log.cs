using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    using System.Runtime.InteropServices;
    using System.Text;
    using Vlc.DotNet.Core.Interops;

    public sealed partial class VlcMediaPlayer
    {
        private object _logLock = new object();

        /// <summary>
        /// The real log event handlers.
        /// </summary>
        private EventHandler<VlcMediaPlayerLogEventArgs> _log;

        /// <summary>
        /// A boolean to make sure that we are calling SetLog only once
        /// </summary>
        private bool _logAttached = false;

        /// <summary>
        /// The event that is triggered when a log is emitted from libVLC.
        /// Listening to this event will discard the default logger in libvlc.
        /// </summary>
        public event EventHandler<VlcMediaPlayerLogEventArgs> Log
        {
            add
            {
                lock (this._logLock)
                {
                    this._log += value;
                    if (!this._logAttached)
                    {
                        this.Manager.SetLog(this.OnLogInternal);
                        this._logAttached = true;
                    }
                }
            }

            remove
            {
                lock (this._logLock)
                {
                    this._log -= value;
                }
            }
        }

        private void OnLogInternal(IntPtr data, VlcLogLevel level, IntPtr ctx, string format, IntPtr args)
        {
            if (this._log != null)
            {
                // Original source for va_list handling: https://stackoverflow.com/a/37629480/2663813
                var byteLength = Win32Interops._vscprintf(format, args) + 1;
                var utf8Buffer = Marshal.AllocHGlobal(byteLength);

                string formattedDecodedMessage;
                try {
                    Win32Interops.vsprintf(utf8Buffer, format, args);

                    //Yeah, ok the message is formatted, but it's an UTF-8 string treated as ASCII inside an UTF-16 string. Do the conversion
                    var sbDecoded = new StringBuilder(Win32Interops.MultiByteToWideChar(Win32Interops.CP_UTF8, 0, utf8Buffer, byteLength, null, 0));
                    Win32Interops.MultiByteToWideChar(Win32Interops.CP_UTF8, 0, utf8Buffer, byteLength, sbDecoded, sbDecoded.Capacity);
                    formattedDecodedMessage = sbDecoded.ToString();
                }
                finally
                {
                    Marshal.FreeHGlobal(utf8Buffer);
                }

                string module;
                string file;
                uint? line;
                this.Manager.GetLogContext(ctx, out module, out file, out line);

                this._log(this.myMediaPlayerInstance, new VlcMediaPlayerLogEventArgs(level, formattedDecodedMessage, module, file, line));
            }
        }
    }
}