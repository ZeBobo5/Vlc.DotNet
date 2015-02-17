using System;
using System.Collections.Generic;
using System.Text;

namespace Vlc.DotNet.Core
{
    public interface IChapterManagement
    {
        int Count { get; }
        void Previous();
        void Next();
        int Current { get; set; }
    }
}
