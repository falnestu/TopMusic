namespace MusicBrainzServiceAgent.Request
{
    
    // Extension de la Request de RestSharp
    // Chaque requete faite à MusicBrainz doit contenir un User Agent permettant d'identifier la source
    // Dans notre cas on demande le format JSON pour la réponse
    internal abstract class BaseRequest : RestSharp.RestRequest
    {
        private const string UserAgent = "TopMusic/1.0.0 (bastleroy@gmail.com)";
        private const string Format = "json";

        public BaseRequest() :base()
        {
            AddHeader("User-Agent", UserAgent);
            AddQueryParameter("fmt", Format);
        }
    }
}
