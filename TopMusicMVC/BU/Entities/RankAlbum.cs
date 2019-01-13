using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopMusicMVC.BU.Entities
{
    public class RankAlbum
    {
        public int Rank { get; set; }
        public int NumberVotes { get; set; }
        public string AlbumDescription { get; set; }
    }
}