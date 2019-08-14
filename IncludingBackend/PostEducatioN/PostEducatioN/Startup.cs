using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PostEducatioN.Startup))]
namespace PostEducatioN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
