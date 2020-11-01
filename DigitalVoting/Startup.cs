using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DigitalVoting.Startup))]
namespace DigitalVoting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
