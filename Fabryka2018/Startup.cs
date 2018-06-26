using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fabryka2018.Startup))]
namespace Fabryka2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
