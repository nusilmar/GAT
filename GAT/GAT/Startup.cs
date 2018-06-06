using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAT.Startup))]
namespace GAT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
