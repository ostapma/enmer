﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnmerWeb.Controllers
{
    public class AngularViewsController : Controller
    {
        // GET: AngularViews
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult AccountSettings()
        {
            return View();
        }

        public ActionResult LoggingSources()
        {
            return View();
        }

        public ActionResult LoggingSourcesToolbar()
        {
            return View();
        }


        public ActionResult LoggingSourceEdit()
        {
            return View();
        }

        public ActionResult LoggingSourceEditToolbar()
        {
            return View();
        }
    }
}