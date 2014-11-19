using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetLastErrorMessage()
        {
#if !NET20
            return GetInteropDelegate<GetLastErrorMessage>().Invoke().ToStringAnsi();
#else
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetLastErrorMessage>().Invoke());
#endif
        }
    }
}
