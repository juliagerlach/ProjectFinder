using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectFinderApp.Startup))]
namespace ProjectFinderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
