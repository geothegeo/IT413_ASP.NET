using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMU.Startup))]
namespace GMU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
