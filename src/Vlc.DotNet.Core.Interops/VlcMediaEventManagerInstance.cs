using System;

namespace Vlc.DotNet.Core.Interops
{
    public sealed class VlcMediaEventManagerInstance : VlcEventManagerInstance
    {
        internal VlcMediaEventManagerInstance(VlcManager manager, IntPtr pointer)
            : base(manager, pointer)
        {
        }
    }
}