using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HANDICRAFTSHOPPING.Startup))]
namespace HANDICRAFTSHOPPING
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
