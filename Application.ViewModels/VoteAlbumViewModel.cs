using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VoteAlbumViewModel
    {
        public RankAlbum Album { get; set; }
        public bool IsUserVote { get; set; }
    }
}
