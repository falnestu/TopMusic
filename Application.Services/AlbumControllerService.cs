using Application.ViewModels;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AlbumControllerService
    {
        public AlbumsViewModel GetAlbumsViewModel(int categoryID)
        {
            return GetBaseAlbumsViewModel(categoryID);
        }

        public AlbumsViewModel SearchAlbumsAndGetViewModel(int categoryID, AlbumSearchModel searchModel)
        {
            var viewModel = GetBaseAlbumsViewModel(categoryID);
            viewModel.SearchResult = AlbumService.MBSearch(searchModel.SearchText, searchModel.SearchType);
            viewModel.SearchModel = searchModel;
            return viewModel;
        }

        private AlbumsViewModel GetBaseAlbumsViewModel(int categoryID)
        {
            var viewModel = new AlbumsViewModel
            {
                Albums = AlbumService.GetAlbumsByCategoryID(categoryID),
                CategoryID = categoryID
            };

            return viewModel;
        }

        public bool AddAlbumInCategory(int id, string mBID, string title, string artistName)
        {
            return AlbumService.AddAlbumInCategory(id, mBID, title, artistName);
        }

        public bool Delete(int id)
        {
            return AlbumService.Delete(id);
        }
    }
}
