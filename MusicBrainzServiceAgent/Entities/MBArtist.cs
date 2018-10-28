namespace MusicBrainzServiceAgent.Entities
{
    /// <summary>
    /// Entité Artist de Musicbrainz
    /// </summary>
    public class MBArtist : BaseMBEntity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Id} : {Name} (type : {Type});";
        }
    }
}
