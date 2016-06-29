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

        internal static List<TrackDescription> GetSubTrackDescription(IntPtr moduleRef)
        {
            var result = new List<TrackDescription>();
            if (moduleRef != IntPtr.Zero)
            {
                var module = (TrackDescriptionStructure)Marshal.PtrToStructure(moduleRef, typeof(TrackDescriptionStructure));
                result.Add(new TrackDescription(module.Id, module.Name));
                var data = GetSubTrackDescription(module.NextTrackDescription);
                result.AddRange(data);
            }
            return result;
        }

    }
}
