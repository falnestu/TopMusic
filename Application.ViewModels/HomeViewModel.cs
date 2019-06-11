using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Populaires = new List<CategoryCardViewModel>();
            Nouvelles = new List<CategoryCardViewModel>();
        }
        public List<CategoryCardViewModel> Populaires { get; set; }
        public List<CategoryCardViewModel> Nouvelles { get; set; }
    }
}
