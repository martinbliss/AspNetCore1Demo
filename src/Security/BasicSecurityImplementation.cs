using Microsoft.AspNet.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Security
{
    public sealed class UserNameMatchRequirement : IAuthorizationRequirement
    {
        public UserNameMatchRequirement(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }

    public sealed class UserNameMatchRequirementHandler : AuthorizationHandler<UserNameMatchRequirement>
    {
        protected override void Handle(AuthorizationContext context, UserNameMatchRequirement requirement)
        {
            var userName = context.User.FindFirst("name")?.Value ?? null;

            if (string.Equals(requirement.Name, userName))
            {
                context.Succeed(requirement);
            }
        }
    }
}
