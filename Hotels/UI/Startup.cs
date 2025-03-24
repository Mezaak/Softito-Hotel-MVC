using Business.Abstract;
using Business.Concreate;
using Data.Abstract;
using Data.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartup(typeof(UI.StartupOwin))]

namespace UI
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
