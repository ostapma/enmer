using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnmerCore.BL;
using EnmerWeb.Controllers.Helpers;
using EnmerWeb.Models;
using Microsoft.AspNet.Identity;

namespace EnmerWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
          
            return View(AppModelHelper<AppModel>.CreateAppModel());
        }

    }
}