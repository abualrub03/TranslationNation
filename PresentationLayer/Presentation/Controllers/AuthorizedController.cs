using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;
using Entities;
using Microsoft.Extensions.Primitives;
namespace TranslationNation.Controllers    
{
    [TranslationNation.Controllers.Filter.Authorize("Client")]
    public class AuthorizedController : BaseController
    {
        public Entities.Accounts CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }
        public Entities.Accounts GetCurrentUser()
        {
            Entities.Accounts team = new Entities.Accounts();
            var props = typeof(Entities.Accounts).GetProperties();

            foreach (var item in props)
            {
                var value = User.FindFirstValue(item.Name);
                if (value != null)
                {
                    try
                    {
                        if (item.PropertyType == typeof(int) || item.PropertyType == typeof(int?))
                        {
                            int intValue = int.Parse(value);
                            item.SetValue(team, intValue);
                        }
                        else if (item.PropertyType == typeof(string))
                        {
                            item.SetValue(team, value);
                        }
                        // Add more conditions if there are other types (e.g., DateTime, bool, etc.)
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        Console.WriteLine($"Error setting value for property {item.Name}: {ex.Message}");
                    }
                }
            }
            return team;
        }

    }
}
