using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace TranslationNation.Controllers.Filter
{
    public class AuthorizeAttribute : ActionFilterAttribute, IActionFilter
    {
        public string Role { get; set; }

        public AuthorizeAttribute(string role)
        {
            Role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User != null)
            {
                // Get the user's role claim.
                Claim roleClaim = context.HttpContext.User.FindFirst(ClaimTypes.Role);

                // If the user does not have a role claim, redirect them to the login page.
                if (roleClaim == null)
                {
                    context.Result = new RedirectToActionResult("Login", "Customer", null);
                    return;
                }

                // Check if the user is in the required role.
                if (!IsInRole(roleClaim.Value))
                {
                    context.Result = new RedirectToActionResult("Unauthorized", "Account", null);
                    return;
                }
            }

            // If the user is not logged in, redirect them to the login page.
            else
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            // The user is logged in and in the required role, so allow them to access the action.
        }
        public bool IsInRole(string UserRole)
        { string[] allowedRoles = Role.Split(',');  
        
            return allowedRoles.Contains(Role);
        }
    }
}
