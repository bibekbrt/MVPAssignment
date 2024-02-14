using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVPAssignmentProject.UI.Startup))]
namespace MVPAssignmentProject.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
