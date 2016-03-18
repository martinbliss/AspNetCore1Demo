using Microsoft.AspNet.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Security
{
    public sealed class SecurityBadgeRequirement : IAuthorizationRequirement
    {

    }
    public sealed class ContractorAuthorizationHandler : AuthorizationHandler<SecurityBadgeRequirement>
    {
        protected override void Handle(AuthorizationContext context, SecurityBadgeRequirement requirement)
        {
            if (context.User.FindFirst("name")?.Value == "contractor")
            {
                context.Succeed(requirement);
            }
        }
    }
    public sealed class EmployeeAuthorizationHandler : AuthorizationHandler<SecurityBadgeRequirement>
    {
        protected override void Handle(AuthorizationContext context, SecurityBadgeRequirement requirement)
        {
            if (context.User.FindFirst("name")?.Value == "martin")
            {
                context.Succeed(requirement);
            }
        }
    }
}
