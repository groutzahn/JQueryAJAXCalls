using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQueryAJAXCalls.Startup))]
namespace JQueryAJAXCalls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
