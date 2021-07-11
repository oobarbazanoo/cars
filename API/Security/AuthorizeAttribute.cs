using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace API.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var login = (string)context.HttpContext.Items["Login"];
            if (login == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
        }
    }
}