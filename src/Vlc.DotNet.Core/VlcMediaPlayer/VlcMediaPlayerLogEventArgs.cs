using System;

namespace Vlc.DotNet.Core
{
    using Vlc.DotNet.Core.Interops.Signatures;

    public sealed class VlcMediaPlayerLogEventArgs : EventArgs
    {
        public VlcMediaPlayerLogEventArgs(VlcLogLevel level, string message)
        {
            this.Level = level;
            this.Message = message;
        }

        /// <summary>
        /// The severity of the log message.
        /// By default, you will only get error messages, but you can get all messages by specifying "-vv" in the options.
        /// </summary>
        public VlcLogLevel Level { get; }

        /// <summary>
        /// The log message
        /// </summary>
        public string Message { get; }
    }
}