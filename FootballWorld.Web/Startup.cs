using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballWorld.Startup))]
namespace FootballWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
