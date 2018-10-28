using MusicBrainzServiceAgent.Entities;
using System.Collections.Generic;
using System.Text;

namespace MusicBrainzServiceAgent.Result
{
    //Pas utilisé dans notre cas, mais premier résultat créé
    public class MBResultArtists : BaseMBSearchResult
    {
        public List<MBArtist> Artists { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in Artists)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString();
        }
    }
}
