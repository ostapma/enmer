using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EnmerWeb.Models
{

    public class PasswordSettings
    {
        public string CurrentPassword
        {
            get;
            set;
        }

        public string NewPassword
        {
            get;
            set;
        }
    }

    public class ProfileSettingsModel
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string PictureID
        {
            get;
            set;
        }
    }

    public class AccountSettingsModel
    {
        public ProfileSettingsModel ProfileSettings
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

    }
}
