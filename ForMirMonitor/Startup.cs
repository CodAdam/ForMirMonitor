using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForMirMonitor.Startup))]
namespace ForMirMonitor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
