using System;
using Vlc.DotNet.Core.Interops.Signatures.TheLuggage;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcTheLuggageManager
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
