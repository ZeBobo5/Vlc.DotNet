using System;
using System.IO;

namespace Vlc.DotNet.Wpf
{
    public sealed class VlcLibDirectoryNeededEventArgs : EventArgs
    {
        public DirectoryInfo VlcLibDirectory { get; set; }

        public VlcLibDirectoryNeededEventArgs()
        {
            
        }
    }
}