using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VoteViewModel
    {
        public List<VoteAlbumViewModel> Albums { get; set; }
        public Category Category { get; set; }
    }
}
