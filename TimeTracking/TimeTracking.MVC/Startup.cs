using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeTracking.MVC.Startup))]
namespace TimeTracking.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
