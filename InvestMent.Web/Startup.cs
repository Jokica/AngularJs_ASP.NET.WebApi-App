using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvestMent.Web.Startup))]
namespace InvestMent.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
