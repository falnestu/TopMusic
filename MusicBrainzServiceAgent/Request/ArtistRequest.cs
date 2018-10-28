namespace MusicBrainzServiceAgent.Request
{
    /// <summary>
    /// Pour rechercher un artiste nous créons cette requete
    /// Elle n'est pas nécessaire mais c'est la première requete qui a été créé
    /// </summary>
    internal class ArtistRequest : BaseRequest
    {
        public ArtistRequest(string artistName) : base()
        {
            Resource = "{type}";
            AddUrlSegment("type", "artist");
            AddQueryParameter("query", "artist:"+ artistName);
        }
    }
}