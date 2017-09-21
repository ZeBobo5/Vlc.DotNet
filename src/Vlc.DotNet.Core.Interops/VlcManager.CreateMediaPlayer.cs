using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public VlcMediaPlayerInstance CreateMediaPlayer()
        {
            EnsureVlcInstance();

            return new VlcMediaPlayerInstance(this, GetInteropDelegate<CreateMediaPlayer>().Invoke(myVlcInstance));
        }
    }
}
