using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAYUFOOD.Startup))]
namespace SAYUFOOD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
