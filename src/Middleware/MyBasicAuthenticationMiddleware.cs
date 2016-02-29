using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace src.Middleware
{
    public sealed class MyBasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _func = null;
        public MyBasicAuthenticationMiddleware(RequestDelegate func)
        {
            _func = func;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

                if (string.IsNullOrEmpty(authorizationHeader)) throw new AuthorizationException(400, "Malformed Authorization Header");

                var pairs = authorizationHeader.Split(' ');

                if (pairs.Length < 2) throw new AuthorizationException(400, "Malformed Authorization Header");
                if (pairs[0] != "Basic") throw new AuthorizationException(400, $"{pairs[0]} Auth is not supported. Try Basic authentication.");
                if (!pairs[1].Contains(":")) throw new AuthorizationException(400, $"{pairs[1]} does not conform to Basic Auth spec");

                var credentialPair = pairs[1].Split(':');
                var username = credentialPair[0];
                var password = credentialPair[1];

                if (username != password) // TODO: Please don't do this in Production :)
                    throw new AuthorizationException(401, "Invalid Credentials");

                var identity = new ClaimsIdentity("basic"); // User was authenticated using Basic credentials.
                identity.AddClaim(new Claim("name", username));

                context.User = new System.Security.Claims.ClaimsPrincipal(identity); // Notify request pipeline of this user.
                
                
                // Request Succeeded, continue the pipeline!
                await _func(context);
            } catch (AuthorizationException exception)
            {
                await exception.SetError(context);
            }
        }
    }
}
