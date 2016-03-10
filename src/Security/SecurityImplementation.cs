using Microsoft.AspNet.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Security
{
    /// <summary>
    /// He (or she) who controls the spice controls the universe!
    /// Provides users with the name requiredName access to melange.
    /// </summary>
    public sealed class AccessToMelangeRequirement : IAuthorizationRequirement
    {
        public AccessToMelangeRequirement(string requiredName)
        {
            RequiredName = requiredName;
        }
        
        public string RequiredName { get; } 
    }
    public sealed class NameMatchAuthorizationHandler : AuthorizationHandler<AccessToMelangeRequirement>
    {
        protected override void Handle(AuthorizationContext context, AccessToMelangeRequirement requirement)
        {
            var nameClaim = context.User.FindFirst("name");
            
            if (nameClaim?.Value == requirement.RequiredName)
            {
                context.Succeed(requirement);
            }
        }
    }
}
