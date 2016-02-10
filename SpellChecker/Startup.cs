using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpellChecker.Startup))]
namespace SpellChecker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
