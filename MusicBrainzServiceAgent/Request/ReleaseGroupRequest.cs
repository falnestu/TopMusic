namespace MusicBrainzServiceAgent.Request
{
    /// <summary>
    /// Requete pour rechercher une release-group
    /// Dans ce cas ci on force la recherche actuelle sur un type précis
    /// </summary>
    internal class ReleaseGroupRequest : BaseRequest
    {
        /// <summary>
        /// Constructeur recevant une requete de recherche
        /// </summary>
        /// <param name="query">requete de recherche de type Lucene</param>
        public ReleaseGroupRequest(string query) : base()
        {
            Resource = "{type}";
            AddUrlSegment("type", "release-group");
            AddQueryParameter("query", "type:Album AND "+ query);
        }
    }
}
