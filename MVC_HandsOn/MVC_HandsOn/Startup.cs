using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_HandsOn.Startup))]
namespace MVC_HandsOn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
