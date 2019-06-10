using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TopMusicMVCAuth.Startup))]
namespace TopMusicMVCAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
