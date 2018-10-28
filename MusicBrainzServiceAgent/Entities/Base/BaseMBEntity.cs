namespace MusicBrainzServiceAgent.Entities
{
    /// <summary>
    /// Toutes entités de Musicbrainz contient un ID et un TypeID
    /// Lors d'une recherche le score est ajouté à l'entité
    /// </summary>
    public abstract class BaseMBEntity
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public int Score { get; set; }
    }
}