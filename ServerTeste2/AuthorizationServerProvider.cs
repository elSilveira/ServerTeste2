
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
                    var query = from u in db.Usuario
                                join c in db.Cliente on context.UserName equals c.emailCliente
                                where u.senhaUsuario == context.Password
                                select u;
                    foreach (Usuario u in query)
                    {
                        usuario = u;
                    }
                }
                if (usuario.idUsuario > 0)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                    identity.AddClaim(new Claim("sub", context.UserName));
                    identity.AddClaim(new Claim("role", usuario.roleUsuario));

                    context.Validated(identity);
                }
            }
            catch (Exception)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
        }
    }
}