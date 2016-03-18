using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace src.Middleware
{
    /// <summary>
    /// A bad implementation of authentication middleware. 
    /// If the request's Authorization header's username and password match, login succeeds.
    /// </summary>
    public sealed class BadAuthenticationMiddleware
    {
        private readonly RequestDelegate _func = null;
        public BadAuthenticationMiddleware(RequestDelegate func)
        {
            _func = func;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Sample Authorization Header
                // Authorization: Basic martin:martin

                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                var pairs = authorizationHeader.Split(' ');
                var credentialPair = pairs[1].Split(':');
                var username = credentialPair[0];
                var password = credentialPair[1];

                if (username != password) 
                    throw new AuthorizationException(401, "Invalid Credentials");

                // Login succeeded. Set the user on the request!
                var identity = new ClaimsIdentity("basic");
                identity.AddClaim(new Claim("name", username));
                context.User = new ClaimsPrincipal(identity);

                // Request Succeeded, continue the pipeline!
                await _func(context);
            } catch (AuthorizationException exception)
            {
                await exception.SetError(context);
            }
        }
    }
}
