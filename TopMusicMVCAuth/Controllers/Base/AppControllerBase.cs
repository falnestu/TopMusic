using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopMusicMVCAuth.Controllers.Base
{
    public abstract class AppControllerBase : Controller
    {
        private void SetFlash(string type, string text)
        {
            TempData["FlashMessageType"] = type;
            TempData["FlashMessageText"] = text;
        }

        public void SetSuccessFlash(string text)
        {
            SetFlash("success", text);
        }

        public void SetErrorFlash(string text)
        {
            SetFlash("danger", text);
        }

        public void SetWarningFlash(string text)
        {
            SetFlash("warning", text);
        }
    }
}