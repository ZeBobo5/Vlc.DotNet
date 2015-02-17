using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetEventTypeName(EventTypes eventType)
        {
#if !NET20
            return GetInteropDelegate<GetEventTypeName>().Invoke(eventType).ToStringAnsi();
#else
            return IntPtrExtensions.ToStringAnsi(GetInteropDelegate<GetEventTypeName>().Invoke(eventType));
#endif
        }
    }
}
