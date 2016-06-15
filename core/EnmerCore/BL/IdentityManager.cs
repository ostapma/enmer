using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using EnmerCore.DataObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EnmerCore.BL
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class EnmerUserManager : UserManager<EnmerUser>
    {
        public EnmerUserManager(IUserStore<EnmerUser> store)
            : base(store)
        {
        }


        public async Task ChangeEmail(string userId, string email)
        {
            var user = await FindByIdAsync(userId);

            user.Email = email;

            // Persiste the changes
            await UpdateAsync(user);
        }

        public async Task ChangeUserName(string userId, string userName)
        {
            var user = await FindByIdAsync(userId);

            user.UserName = userName;

            // Persiste the changes
            await UpdateAsync(user);
        }

    }

    
}
