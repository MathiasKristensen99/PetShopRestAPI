﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EASV.PetShop.Security.Authorization
{
    public class UserResourceOwnerAuthorizationService : AuthorizationHandler<ResourceOwnerRequirement, IAuthorizableOwnerIdentity>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOwnerRequirement requirement,
            IAuthorizableOwnerIdentity resource)
        {
            string userName = context.User.Identity.Name;
            string resourceOwnerName = resource.GetAuthorizedOwnerName();
            if (userName != null && userName.Equals(resourceOwnerName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
    
    public class ResourceOwnerRequirement : IAuthorizationRequirement {}
}