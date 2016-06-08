using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnmerCore.BL;
using EnmerWeb.Models;
using Microsoft.AspNet.Identity;

namespace EnmerWeb.Controllers.Helpers
{
    public class AppModelHelper<T> where T : AppModel, new()
    {
        public static T CreateAppModel()
        {
            var userProfile = new UserProfileManager().GetProfile(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return new T()
                   {
                        UserModel = new UserModel()
                        {
                            FirstName = userProfile.FirstName,
                            LastName = userProfile.LastName,
                            UserID = userProfile.UserID,
                            PictureID = userProfile.PictureID
                        }
            };
        }
    }
}