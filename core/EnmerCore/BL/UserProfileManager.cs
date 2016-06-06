using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnmerCore.DataObjects;

namespace EnmerCore.BL
{
    public class UserProfileManager
    {
        public UserProfile GetProfile(string userID)
        {
            using (var context = new EnmerDbContext())
            {
                return GetProfile(userID, context);
            }
        }

        internal UserProfile GetProfile(string userID, EnmerDbContext context)
        {
            return context.UserProfiles.FirstOrDefault(u => u.UserID == userID);
        }

        public void CreateUserProfile(string userID, string firstName,
            string lastName)
        {
            using (var context = new EnmerDbContext())
            {
                context.UserProfiles.Add(new UserProfile()
                                         {
                                             FirstName = firstName,
                                             LastName = lastName,
                                             UserID = userID
                                         });
                context.SaveChanges();
            }
        }

        public void UpdateUserProfile(string userID, string firstName,
            string lastName, string pictureID)
        {
            using (var context = new EnmerDbContext())
            {
                var userProfile = GetProfile(userID);
                if (userProfile != null)
                {
                    userProfile.FirstName = firstName;
                    userProfile.LastName = lastName;
                    userProfile.PictureID = pictureID;
                    context.SaveChanges();
                }
            }
        }

    }
}
