using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(InvestMent.Api.Startup))]

namespace InvestMent.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

