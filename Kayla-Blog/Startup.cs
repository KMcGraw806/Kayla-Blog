using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kayla_Blog.Startup))]
namespace Kayla_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
