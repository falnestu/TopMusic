using MusicBrainzServiceAgent.Entities;
using MusicBrainzServiceAgent.Request;
using MusicBrainzServiceAgent.Result;
using System.Collections.Generic;

namespace MusicBrainzServiceAgent
{
    //
    public class ServiceAgent
    {
        public static List<MBArtist> SearchArtists(string artistName)
        {
            var result = MusicBrainzAPI.Execute<MBResultArtists>(new ArtistRequest(artistName));
            return result.Artists;
        }

        public static List<MBReleaseGroup> SearchAlbumsByArtistName(string artistName)
        {
            var result = MusicBrainzAPI.Execute<MBResultReleaseGroup>(new ReleaseGroupRequest("artist:"+artistName));
            return result.ReleaseGroups;
        }

        public static List<MBReleaseGroup> SearchAlbums(string albumName)
        {
            var result = MusicBrainzAPI.Execute<MBResultReleaseGroup>(new ReleaseGroupRequest("releasegroup:"+albumName));
            return result.ReleaseGroups;
        }
    }
}
