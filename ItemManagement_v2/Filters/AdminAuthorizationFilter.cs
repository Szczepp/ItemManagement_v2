using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ItemManagement_v2.Filters
{
    public class AdminAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.User.IsInRole("Admin") == false)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
