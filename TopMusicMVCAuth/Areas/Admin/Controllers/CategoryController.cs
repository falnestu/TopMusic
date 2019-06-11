using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopMusicMVCAuth.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : TopMusicMVCAuth.Controllers.Base.AppControllerBase
    {
        private readonly CategoryControllerService _controllerService;

        public CategoryController()
        {
            _controllerService = new CategoryControllerService();
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var viewModel = _controllerService.GetCategories();
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: MG/Sensibilite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application.ViewModels.CreateCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _controllerService.Create(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _controllerService.getEditViewModel(id);
            return View("Edit", viewModel);
        }

        // POST: MG/Sensibilite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Application.ViewModels.EditCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _controllerService.Save(viewModel);
                SetSuccessFlash("La catégorie a bien été sauvée !");
            }

            return View("Edit", viewModel);
        }


        public ActionResult Delete(int id)
        {
            var viewModel = _controllerService.GetViewModel(id);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_controllerService.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id });
        }
    }
}