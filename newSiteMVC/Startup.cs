using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(newSiteMVC.Startup))]
namespace newSiteMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
