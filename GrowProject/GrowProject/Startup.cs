using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrowProject.Startup))]
namespace GrowProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
