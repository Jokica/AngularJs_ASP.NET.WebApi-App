using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvestMent.WebApi.Startup))]
namespace InvestMent.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
