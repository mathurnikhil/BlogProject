using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(owin_1.Startup))]
namespace owin_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
