
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
                var usuario = new Usuario();

                    using (DBContext db = new DBContext())
                    {
                        usuario = (from u in db.Usuario
                                      where u.idUsuario == Convert.ToInt32(context.ClientId)
                                      select u) as Usuario;
                    }
                
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim("sub", usuario.idUsuario.ToString()));
                    identity.AddClaim(new Claim("role", usuario.roleUsuario));

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