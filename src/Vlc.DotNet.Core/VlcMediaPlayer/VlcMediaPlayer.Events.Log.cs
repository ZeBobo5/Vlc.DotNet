using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
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
                // Original source: https://stackoverflow.com/a/37629480/2663813
                var sb = new StringBuilder(Win32Interops._vscprintf(format, args) + 1);
                Win32Interops.vsprintf(sb, format, args);

                var formattedMessage = sb.ToString();

                string module;
                string file;
                uint? line;
                this.Manager.GetLogContext(ctx, out module, out file, out line);

                this._log(this.myMediaPlayerInstance, new VlcMediaPlayerLogEventArgs(level, formattedMessage, module, file, line));
            }
        }
    }
}