using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EnmerCore.BL;
using EnmerWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace EnmerWeb.Controllers.Api
{
    public class AccountSettingsController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var profile = new UserProfileManager().GetProfile(User.Identity.GetUserId());
            AccountSettings accountSettings = new AccountSettings()
                                              {
                                                  FirstName = profile.FirstName,
                                                  LastName = profile.LastName,
                                                  PictureID = profile.PictureID,
                                                  Email = User.Identity.Name
            };
            return this.Ok(accountSettings);
        }

        [HttpPost]
        public IHttpActionResult Post(AccountSettings accountSettings)
        {
            new UserProfileManager().UpdateUserProfile(User.Identity.GetUserId(),
                accountSettings.FirstName,accountSettings.LastName,accountSettings.PictureID);
            return this.Ok();
        }
    }
}
