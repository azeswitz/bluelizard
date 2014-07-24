using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueLizard.Site.Startup))]
namespace BlueLizard.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
