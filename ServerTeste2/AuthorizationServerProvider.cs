
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ServerTeste2.Models;

namespace ServerTeste2
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });   
            try
            {
                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                
                    identity.AddClaim(new Claim("sub", "elSilveira"));
                    identity.AddClaim(new Claim("role", "user"));

                    context.Validated(identity);
                //}
                context.Validated(identity);
            }
            catch (Exception err)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
        }
    }
}