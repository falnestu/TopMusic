using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopMusicMVC.BU.Entities;

namespace TopMusicMVC.Models
{
    public class HomeViewModel
    {
        public List<RankAlbum> Top { get; set; }
    }
}