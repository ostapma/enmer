using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnmerCore.BL;
using EnmerCore.DataObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnmerCore.Test.BL
{ 
    [TestClass]
    public class UserProfileManagerTest
    {
        [TestInitialize]
        public void Initialize()
        {
            
        }

        private void CreateTestUser()
        {
            using (EnmerIdentityDbContext enmerIdentityDbContext = new EnmerIdentityDbContext())
            {
                EnmerUserManager enmerUserManager = new EnmerUserManager(new UserStore<EnmerUser>(enmerIdentityDbContext));
                {
                    enmerUserManager.Create(new EnmerUser());
                }
            }

        }

        [TestMethod]
        public void TestGet()
        {
            
        }
    }
}
