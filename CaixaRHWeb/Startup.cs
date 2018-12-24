using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaixaRHWeb.Startup))]
namespace CaixaRHWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
