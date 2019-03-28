using System;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core.Interops
{
    public sealed partial class VlcManager
    {
        public string GetLastErrorMessage()
        {
            return Utf8InteropStringConverter.Utf8InteropToString(myLibraryLoader.GetInteropDelegate<GetLastErrorMessage>().Invoke());
        }
    }
}
