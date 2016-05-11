using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnmerWeb.Startup))]
    namespace EnmerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}