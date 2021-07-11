using FitHubApplication.Models;
using FitHubApplication.Models.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FitHubApplication.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            object user = context.HttpContext.Items[ApplicationConsts.ContextConsts.User];

            if (user is null)
            {
                context.Result = new JsonResult(new { message =  ApplicationConsts.ConfigConsts.UnauthorizedRequest }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
