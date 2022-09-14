using Microsoft.AspNetCore.Mvc;
using StepChange.Blogger.DAL.Models;

namespace StepChange.Blogger.Web.Attributes
{
    public class RoleAuthorizationAttribute : TypeFilterAttribute
    {
        public RoleAuthorizationAttribute(params Role[] roles) :
            base(typeof(RoleAuthorizationFilter))
        {
            Arguments = new object[] { roles };
        }
    }
}
