using RestSharp;
using System;

namespace MusicBrainzServiceAgent
{
    //Classe pour executer les requetes basé sur l'url de MusicBrainz
    class MusicBrainzAPI
    {
        private const string BaseUrl = "https://musicbrainz.org/ws/2/";

        internal static T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(BaseUrl);

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var musicBrainzException = new ApplicationException(message, response.ErrorException);
                throw musicBrainzException;
            }

            return response.Data;
        }
    }
}
