using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CategoryCardViewModel
    {
        public Category Category { get; set; }
        public List<Domain.Entities.RankAlbum> Top { get; set; }
    }
}
