using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiCommunity.Startup))]
namespace HiCommunity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
