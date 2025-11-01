using System;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using rg.service.Manager;
using rg.service.Models;

namespace rg.service.Providers
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        #region[GrantResourceOwnerCredentials]
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var userName = context.UserName;
                var password = context.Password;
                var userService = new AdminLoginManager(); // our created one
                var det = new AdminLogin() { Bemail = userName, Bpass = password };
                var user = userService.LoginDetails(det);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Sid, Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.Bemail),
                        new Claim(ClaimTypes.Name, user.Bname)

                    };
                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                                Startup.OAuthOptions.AuthenticationType);

                    var properties = CreateProperties(user.Bemail, Convert.ToString(user.Id),user.Bpass, user.Bname,user.Paymentmode,user.Bcontact);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);

                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect");
                }
            });
        }
        #endregion

        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
        #endregion

        #region[CreateProperties]
        public static AuthenticationProperties CreateProperties(string loginUserName, string loginId, string loginPassword, string branchName,string paymentMode, string bcontact)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "username", loginUserName },
                { "id", loginId },
                { "password", loginPassword },
                { "bname", branchName },
                { "paymentMode", paymentMode },
                { "branchContact", bcontact }
            };
            return new AuthenticationProperties(data);
        }
        #endregion
    }
}