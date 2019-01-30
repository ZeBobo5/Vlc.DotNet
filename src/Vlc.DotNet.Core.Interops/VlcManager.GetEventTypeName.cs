using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetEventTypeName(EventTypes eventType)
        {
            return Utf8InteropStringConverter.Utf8InteropToString(myLibraryLoader.GetInteropDelegate<GetEventTypeName>().Invoke(eventType));
        }
    }
}
