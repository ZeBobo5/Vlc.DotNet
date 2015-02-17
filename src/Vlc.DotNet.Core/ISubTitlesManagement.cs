using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public interface ISubTitlesManagement : IEnumerableManagement<TrackDescription>
    {
        long Delay { get; set; }
    }

}
