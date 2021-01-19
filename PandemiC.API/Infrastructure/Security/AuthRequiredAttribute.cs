using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using PandemiC.Client.Models;
using System;
using System.Linq;

namespace PandemiC.API.Infrastructure.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {
        }

        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ITokenService tokenService = (ITokenService)context.HttpContext.RequestServices.GetService(typeof(ITokenService));

                context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);
                string token = authorizations.SingleOrDefault(authorization => authorization.StartsWith("Bearer "));

                if (token is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                User user = tokenService.ValidateToken(token);

                if (user is null || (user is not null && user.Id.ToString() != (string)context.RouteData.Values["userId"]))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
        }
    }
}
