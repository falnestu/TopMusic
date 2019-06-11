using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ClassementViewModel
    {
        public ClassementViewModel()
        {
            AllPopulaires = new List<CategoryCardViewModel>();
        }

        public List<CategoryCardViewModel> AllPopulaires { get; set; }
    }
}
