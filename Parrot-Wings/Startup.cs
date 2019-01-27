using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Parrot_Wings.Startup))]

namespace Parrot_Wings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
