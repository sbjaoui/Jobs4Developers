using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jobs4Developers.Startup))]
namespace Jobs4Developers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
