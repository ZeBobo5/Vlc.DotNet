using System;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcMediaPlayerEventManagerInstance : VlcEventManagerInstance
    {
        internal VlcMediaPlayerEventManagerInstance(VlcManager manager, IntPtr pointer)
            : base(manager, pointer)
        {
        }
    }
}