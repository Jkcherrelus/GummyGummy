using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GummyGummy.Startup))]
namespace GummyGummy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
