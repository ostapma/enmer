using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using log4net;

namespace EnmerWeb
{
    public class Global : HttpApplication
    {

        private static ILog logger = LogManager.GetLogger("default");
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastError = Server.GetLastError();
            logger.Error("Unhandled exception occured", lastError);
            if (lastError is DbEntityValidationException)
            {
                foreach (var entityValidationError in ((DbEntityValidationException)lastError).EntityValidationErrors)
                {
                    foreach (var error in entityValidationError.ValidationErrors)
                    {
                        logger.Error(string.Format("{0}: {1}", error.PropertyName, error.ErrorMessage));
                    }

                }
            }
        }
    }


}