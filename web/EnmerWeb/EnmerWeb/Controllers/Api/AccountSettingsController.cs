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
using Microsoft.Owin.Security;


namespace EnmerWeb.Controllers.Api
{
    public class PasswordSettingsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> Post(PasswordSettings passwordSettings)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = await userManager.ChangePasswordAsync(User.Identity.GetUserId(),passwordSettings.CurrentPassword,
                passwordSettings.NewPassword);
            if (result.Succeeded) return this.Ok();
            else
            {
                return this.BadRequest(string.Join("; ",result.Errors));
            }
        }
    }

    public class LoginSettingsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return this.BadRequest("Empty email address");
            }
            try
            {
                new System.Net.Mail.MailAddress(email);
            }
            catch (ArgumentException)
            {
                return this.BadRequest("Incorrect email address");
            }

            catch (FormatException)
            {
                return this.BadRequest("Incorrect email address");
            }

            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            await userManager.ChangeEmail(User.Identity.GetUserId(), email);
            await userManager.ChangeUserName(User.Identity.GetUserId(), email);
            return this.Ok();
        }
    }


    public class ProfileSettingsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public IHttpActionResult Post(ProfileSettingsModel profileSettings)
        {
            new UserProfileManager().UpdateUserProfile(User.Identity.GetUserId(),
                profileSettings.FirstName, profileSettings.LastName,
                profileSettings.PictureID);
            return this.Ok();
        }
    }
    public class AccountSettingsController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var profile = new UserProfileManager().GetProfile(User.Identity.GetUserId());
            AccountSettingsModel accountSettings = new AccountSettingsModel()
                                                   {
                                                       ProfileSettings = new ProfileSettingsModel()
                                                                         {
                                                                             FirstName = profile.FirstName,
                                                                             LastName = profile.LastName,
                                                                             PictureID = profile.PictureID,
                                                                         },

                                                       Email = User.Identity.Name
                                                   };
            return this.Ok(accountSettings);
        }

    }
}
