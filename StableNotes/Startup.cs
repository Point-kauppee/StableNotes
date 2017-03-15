using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StableNotes.Startup))]
namespace StableNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
