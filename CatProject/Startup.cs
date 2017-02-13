using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatProject.Startup))]
namespace CatProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
