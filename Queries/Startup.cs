using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Queries.Startup))]
namespace Queries
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}