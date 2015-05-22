using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AiDiDesign.Web.Startup))]
namespace AiDiDesign.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
