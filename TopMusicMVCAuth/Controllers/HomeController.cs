using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopMusicMVCAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeControllerService _controllerService;

        public HomeController()
        {
            _controllerService = new HomeControllerService();
        }

        public ActionResult Index()
        {
            var viewModel = _controllerService.GetHomeViewModel();
            return View(viewModel);
        }

        public ActionResult Classement()
        {
            var viewModel = _controllerService.GetClassementViewModel();
            return View(viewModel);
        }

       
    }
}