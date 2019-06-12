using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopMusicMVCAuth.Controllers
{
    public class VoteController : Base.AppControllerBase
    {
        private readonly VoteControllerService _controllerService;

        public VoteController()
        {
            _controllerService = new VoteControllerService();
        }

        // GET: Category/{id}
        public ActionResult Index(int id)
        {
            var viewModel = _controllerService.GetVoteViewModel(id);
            return View(viewModel);
        }

        // GET: Category/{AlbumId}
        public ActionResult Vote(int id, int categoryID, bool actual)
        {
            string message;
            if (_controllerService.ToggleVote(id, categoryID, "2d45d901-1776-4a5f-987c-4dd5bf460185", actual, out message))
            {
                SetSuccessFlash(message);
            }
            else
            {
                SetErrorFlash(message);
            }
            
            return RedirectToAction("Index", new { id = categoryID });
        }
    }
}