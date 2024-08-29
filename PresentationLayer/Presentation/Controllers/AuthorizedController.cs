using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;
using Entities;
namespace TranslationNation.Controllers    
{
    [TranslationNation.Controllers.Filter.Authorize("Admin"), TranslationNation.Controllers.Filter.Authorize("superAdmin")]
    public class AuthorizedController : BaseController
    {
        public Entities.Team CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }
        public Entities.Team GetCurrentUser()
        {
            Entities.Team team = new Team();
            var props =  typeof(Entities.Team).GetProperties();
            foreach (var item in props)
            {
                var value = User.FindFirstValue(item.Name);
                if (value != null)
                {
                    item.SetValue(team, value);
                }
            }
            return team;
        }
    }
}
