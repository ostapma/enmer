using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnmerWeb.Controllers
{
    public class AngularViewsController : Controller
    {
        // GET: AngularViews
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AccountSettings()
        {
            return View();
        }
    }
}