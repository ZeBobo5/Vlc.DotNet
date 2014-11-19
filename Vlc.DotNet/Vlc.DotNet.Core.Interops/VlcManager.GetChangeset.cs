using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetChangeset()
        {
#if !NET20
            return GetInteropDelegate<GetChangeset>().Invoke().ToStringAnsi();
#else
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetChangeset>().Invoke());
#endif
        }
    }
}
