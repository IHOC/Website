using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamIHOC.Forums.Startup))]
namespace TeamIHOC.Forums
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
