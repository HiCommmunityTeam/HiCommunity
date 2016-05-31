using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiCommunityBackground.Startup))]
namespace HiCommunityBackground
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
