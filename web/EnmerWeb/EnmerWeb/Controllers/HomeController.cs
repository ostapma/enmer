using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnmerCore.BL;
using EnmerWeb.Models;
using Microsoft.AspNet.Identity;

namespace EnmerWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var userProfile = new UserProfileManager().GetProfile(User.Identity.GetUserId());
            return View(new AppModel()
                        {
                            UserModel = new UserModel()
                                        {
                                            FirstName = userProfile.FirstName,
                                            LastName = userProfile.LastName,
                                            UserID = userProfile.UserID,
                                            PictureID = userProfile.PictureID
                                        }
                                
                        });
        }

    }
}