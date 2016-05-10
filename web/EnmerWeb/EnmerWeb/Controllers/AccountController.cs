using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EnmerWeb.Models;

namespace EnmerWeb.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            return View(new LoginModel() { IsFailed = true });
        }
    }
}