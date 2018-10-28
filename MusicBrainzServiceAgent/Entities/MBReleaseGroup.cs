using System.Collections.Generic;
using System.Text;

namespace MusicBrainzServiceAgent.Entities
{
    /// <summary>
    /// Entité ReleaseGroup de MusicBrainz
    /// </summary>
    public class MBReleaseGroup : BaseMBEntity
    {
        public string Title { get; set; }
        public string PrimaryType { get; set; }
        public List<MBArtistCredit> ArtistCredit { get; set; }

        public string ToEntityString()
        {
            return $"{Id} : {Title} (type : {PrimaryType});";
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(Title);

            if (ArtistCredit?.Count > 0)
            {
                output.Append($" - {ArtistCredit[0].Artist.Name}");
            }

            if (Score > 0)
            {
                output.Append($" (Score : {Score} %)");
            }

            return output.ToString();
        }
    }
}