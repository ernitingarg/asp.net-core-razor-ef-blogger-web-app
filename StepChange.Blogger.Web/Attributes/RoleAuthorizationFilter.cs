using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.Web.Attributes
{
    public class RoleAuthorizationFilter : IAuthorizationFilter
    {
        readonly Role[] _roles;

        public RoleAuthorizationFilter(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = false;

            var user = context.HttpContext.User;
            if (user.Identity is { IsAuthenticated: true })
            {
                foreach (var role in _roles)
                {
                    if (user.IsInRole(role.ToString()))
                    {
                        isAuthorized = true;
                    }
                }

                if (!isAuthorized)
                {
                    context.Result = new RedirectResult("../Forbidden");
                }
            }
            else
            {
                context.HttpContext.SetCallbackUrl(context.HttpContext.Request.Path);
                context.HttpContext.Request.Query.TryGetValue("id", out var id);
                context.HttpContext.SetCallbackId(id.FirstOrDefault());

                context.Result = new RedirectResult("./Login");
            }
        }
    }
}
