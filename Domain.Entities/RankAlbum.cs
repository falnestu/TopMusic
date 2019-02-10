using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RankAlbum
    {
        public int Rank { get; set; }
        public int NumberVotes { get; set; }
        public string AlbumDescription { get; set; }
    }
}
