using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof($rootnamespace$.StartupOwin))]

namespace $rootnamespace$
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
