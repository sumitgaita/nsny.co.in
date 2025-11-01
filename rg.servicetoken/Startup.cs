using Microsoft.Owin.Cors;
using Owin;
namespace rg.service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}