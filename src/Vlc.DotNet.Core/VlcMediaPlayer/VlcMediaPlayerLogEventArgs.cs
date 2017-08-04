using System;

namespace Vlc.DotNet.Core
{
    using Vlc.DotNet.Core.Interops.Signatures;

    public sealed class VlcMediaPlayerLogEventArgs : EventArgs
    {
        public VlcMediaPlayerLogEventArgs(VlcLogLevel level, string message, string module, string sourceFile, uint? sourceLine)
        {
            this.Level = level;
            this.Message = message;
            this.Module = module;
            this.SourceFile = sourceFile;
            this.SourceLine = sourceLine;
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

        /// <summary>
        /// The name of the module that emitted the message
        /// </summary>
        public string Module { get; }

        /// <summary>
        /// The source file that emitted the message
        /// </summary>
        public string SourceFile { get; }

        /// <summary>
        /// The line in the <see cref="SourceFile"/> at which the message was emitted.
        /// </summary>
        public uint? SourceLine { get; }
    }
}