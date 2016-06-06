using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnmerCore.DataObjects;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EnmerCore
{
    public class EnmerIdentityDbContext: IdentityDbContext<EnmerUser>
    {
        public EnmerIdentityDbContext() : base("EnmerConnection")
        {
           
        }

        public static EnmerIdentityDbContext Create()
        {
            return new EnmerIdentityDbContext();
        }
    }
}
