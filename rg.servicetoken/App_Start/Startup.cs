using Owin;
using System;
using Microsoft.Owin;
using rg.service.Providers;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace rg.service
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseOAuthBearerTokens(OAuthOptions);
            
        }
    }
}