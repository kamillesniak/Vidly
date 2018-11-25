using Microsoft.Owin;
using Owin;
using Vidly.App_Start;

[assembly: OwinStartup(typeof(Vidly.Startup))]
namespace Vidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
