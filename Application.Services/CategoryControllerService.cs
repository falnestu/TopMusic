using Application.ViewModels;
using Common.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoryControllerService
    {
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            foreach (var category in CategoryService.GetAll())
            {
                yield return new CategoryViewModel() { Category = category };
            }
        }

        public CategoryViewModel GetViewModel(int id)
        {
            var category = CategoryService.Get(id);
            return new CategoryViewModel
            {
                Category = category
            };
        }

        public bool Delete(int id)
        {
            return CategoryService.Delete(id);
        }

        public int Create(CreateCategoryViewModel viewModel)
        {
            return CategoryService.Create(viewModel.Name, viewModel.Description);
        }

        public EditCategoryViewModel getEditViewModel(int id)
        {
            var category = CategoryService.Get(id);
            return new EditCategoryViewModel()
            {
                CategoryID = category.CategoryID,
                Name = category.Name,
                Description = category.Description,
                Status = (CategoryStatus)category.Statut
            };
        }

        public int Save(EditCategoryViewModel viewModel)
        {
            return CategoryService.Save(viewModel.CategoryID, viewModel.Name, viewModel.Description, viewModel.Status);
        }
    }
}
