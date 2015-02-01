using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamIHOC.Startup))]
namespace TeamIHOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
