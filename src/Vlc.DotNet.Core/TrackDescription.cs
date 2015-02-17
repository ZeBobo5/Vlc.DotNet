using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed class TrackDescription
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        internal TrackDescription(int id, string name)
        {
            ID = id;
            Name = name;
        }

        internal static List<TrackDescription> GetSubTrackDescription(TrackDescriptionStructure module)
        {
            var result = new List<TrackDescription>();
            result.Add(new TrackDescription(module.Id, module.Name));
            if (module.NextTrackDescription != IntPtr.Zero)
            {
                TrackDescriptionStructure nextModule = (TrackDescriptionStructure)Marshal.PtrToStructure(module.NextTrackDescription, typeof(TrackDescriptionStructure));
                var data = GetSubTrackDescription(nextModule);
                result.AddRange(data);
            }
            return result;
        }

    }
}
