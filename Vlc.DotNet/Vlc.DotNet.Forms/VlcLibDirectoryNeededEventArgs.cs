using System;
using System.IO;

namespace Vlc.DotNet.Forms
{
    public sealed class VlcLibDirectoryNeededEventArgs : EventArgs
    {
        public DirectoryInfo VlcLibDirectory { get; set; }

        public VlcLibDirectoryNeededEventArgs()
        {
            
        }
    }
}