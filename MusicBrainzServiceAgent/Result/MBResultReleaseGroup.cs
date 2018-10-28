using MusicBrainzServiceAgent.Entities;
using System.Collections.Generic;

namespace MusicBrainzServiceAgent.Result
{
    //Résultat pour un "release Group" 
    public class MBResultReleaseGroup : BaseMBSearchResult
    {
        public List<MBReleaseGroup> ReleaseGroups { get; set; }
    }
}
