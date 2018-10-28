using System;

namespace MusicBrainzServiceAgent.Result
{
    public abstract class BaseMBSearchResult
    {
        public DateTime Created { get; set; }
        public int Count { get; set; }
        public int Offset { get; set; }
    }
}
