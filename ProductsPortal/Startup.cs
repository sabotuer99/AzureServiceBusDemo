using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductsPortal.Startup))]
namespace ProductsPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
