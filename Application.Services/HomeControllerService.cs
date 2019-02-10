using Application.ViewModels;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HomeControllerService
    {
        public HomeViewModel GetHomeViewModel()
        {
            var viewModel = new HomeViewModel();
            viewModel.Top = RankingService.GetTop3ByCategoryID(1);
            return viewModel;
        }
    }
}
