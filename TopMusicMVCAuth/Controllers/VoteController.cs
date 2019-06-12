using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace TopMusicMVCAuth.Controllers
{
    [Authorize]
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
            var viewModel = _controllerService.GetVoteViewModel(id, User.Identity.GetUserId());
            return View(viewModel);
        }

        // GET: Category/{AlbumId}
        public ActionResult Vote(int id, int categoryID, bool actual)
        {
            string message;
            if (_controllerService.ToggleVote(id, categoryID, User.Identity.GetUserId(), actual, out message))
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