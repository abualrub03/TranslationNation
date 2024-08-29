using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TranslationNation.Api.Identity;
using System.Security.Claims;
namespace TranslationNation.Api.Controllers    
{
    [Authorize]
    [RequiresClaim(IdentityData.AdminUserClaimName, "Admin")]
    public class AuthorizedController : BaseController
    {
        public Entities.Team CurrentUser
        {
            get
            {
                var userIdClaim = User.FindFirst("CustomerID");
                var userEncryptedIdClaim = User.FindFirst("CustomerEncryptedId");
                var userEmailClaim = User.FindFirst("CustomerEmail");
                var userRoleClaim = User.FindFirst(ClaimTypes.Role);
                var account = new Entities.Team
                {
                    Id = Int32.Parse(userIdClaim.Value),
                    EncryptedId = userEncryptedIdClaim.ToString(),
                    Email = userEmailClaim.ToString(),
                    Role = userRoleClaim.ToString(),
                };
                return account;
            }
        } 
    }
}
