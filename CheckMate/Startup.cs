using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckMate.Startup))]
namespace CheckMate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
