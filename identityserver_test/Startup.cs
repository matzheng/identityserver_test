using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;

[assembly: OwinStartup(typeof(identityserver_test.Startup))]

namespace identityserver_test
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseIdentityServerBearerTokenAuthentication(
                    new IdentityServerBearerTokenAuthenticationOptions
                    {
                        Authority = "http://localhost:5000",
                        ValidationMode = ValidationMode.ValidationEndpoint,
                        RequiredScopes = new[] { "api1"}
                    }
                );
            //var config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();

            //// require authentication for all controllers
            //config.Filters.Add(new AuthorizeAttribute());

            //app.UseWebApi(config);
        }
    }
}
