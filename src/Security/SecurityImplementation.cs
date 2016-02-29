using Microsoft.AspNet.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Security
{
    public sealed class NameMatchRequirement : IAuthorizationRequirement
    {
        public NameMatchRequirement(string name)
        {
            Name = name;
        }
        
        public string Name { get; } 
    }

    public sealed class NameMatchAuthorizationHandler : AuthorizationHandler<NameMatchRequirement>
    {
        protected override void Handle(AuthorizationContext context, NameMatchRequirement requirement)
        {
            var nameClaim = context.User.FindFirst("name");
            
            if (nameClaim?.Value == requirement.Name)
            {
                context.Succeed(requirement);
            } else
            {
                context.Fail();
            }
        }
    }
}
