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
            List<DAL.Model.Category> categories = CategoryService.GetPopulaires();
            foreach (var category in categories.Take(3))
            {
                viewModel.Populaires.Add(new CategoryCardViewModel
                {
                    Category = category,
                    Top = RankingService.GetTop3ByCategoryID(category.CategoryID)
                });
            }

            List<DAL.Model.Category> newCategories = CategoryService.GetNewest();
            foreach (var category in newCategories.Take(3))
            {
                viewModel.Nouvelles.Add(new CategoryCardViewModel
                {
                    Category = category,
                    Top = RankingService.GetTop3ByCategoryID(category.CategoryID)
                });
            }
            return viewModel;
        }

        public ClassementViewModel GetClassementViewModel()
        {
            var viewModel = new ClassementViewModel();

            foreach (var category in CategoryService.GetPopulaires())
            {
                viewModel.AllPopulaires.Add(new CategoryCardViewModel
                {
                    Category = category,
                    Top = RankingService.GetTop3ByCategoryID(category.CategoryID)
                });
            }

            return viewModel;
        }
    }
}
