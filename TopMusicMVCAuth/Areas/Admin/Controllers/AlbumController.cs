using Application.Services;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopMusicMVCAuth.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AlbumController : TopMusicMVCAuth.Controllers.Base.AppControllerBase
    {
        private readonly AlbumControllerService _controllerService;

        public AlbumController()
        {
            _controllerService = new AlbumControllerService();
        }

        // GET: Admin/Album/{categoryID}
        public ActionResult Index(int id)
        {
            var viewModel = _controllerService.GetAlbumsViewModel(id);
            return View(viewModel);
        }

        // POST: Admin/Album/Search/{categoryID}
        [HttpPost]
        public ActionResult Search(int id, AlbumSearchModel searchModel)
        {
            var viewModel = _controllerService.SearchAlbumsAndGetViewModel(id, searchModel);
            return View("Index", viewModel);
        }

        // GET: Admin/Album/Add/{categoryID}
        public ActionResult Add(int id, string MBID, string title, string artistName)
        {
            if (_controllerService.AddAlbumInCategory(id, MBID, title, artistName))
            {
                SetSuccessFlash("Album ajouté à la catégorie");
            }
            else
            {
                SetWarningFlash("Album existe déjà dans la catégorie");
            }
            return RedirectToAction("Index", new { id });
        }

        public ActionResult Delete(int id, int categoryID)
        {
            if (_controllerService.Delete(id))
            {
                SetSuccessFlash("Album supprimé");
            }
            else
            {
                SetErrorFlash("L'album n'a pas pu être supprimé");
            }
            return RedirectToAction("Index", new { id = categoryID });
        }
    }
}