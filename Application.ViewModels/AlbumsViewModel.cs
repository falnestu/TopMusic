using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AlbumsViewModel
    {
        public List<DAL.Model.Album> Albums { get; set; }
        public AlbumSearchModel SearchModel { get; set; }
        public List<AlbumResult> SearchResult { get; set; }
        public int CategoryID { get; set; }
    }
}
