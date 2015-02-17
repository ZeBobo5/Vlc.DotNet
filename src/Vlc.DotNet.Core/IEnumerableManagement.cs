using System.Collections.Generic;

namespace Vlc.DotNet.Core
{
    public interface IEnumerableManagement<T>
    {
        int Count { get; }
        T Current { get; set; }
        IEnumerable<T> All { get; }
    }
}
