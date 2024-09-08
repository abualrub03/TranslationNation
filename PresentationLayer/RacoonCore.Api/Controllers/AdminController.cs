using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RacoonProvider;
using ViewModel.AdminViewModels;
using Team = RacoonProvider.Team;
using Contact = RacoonProvider.Contact;
using Microsoft.AspNetCore.Authorization;
using TranslationNation.Api.Identity;

namespace TranslationNation.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : AuthorizedController
    {
        [HttpGet("signOut", Name = "signOut")]
        public async Task<IActionResult> signOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        [HttpGet("deleteNews", Name = "deleteNews")]
        public IActionResult deleteNews(int id) { 
            return Ok(new RacoonProvider.News().deleteNews(id));
        }
        [HttpGet("News", Name = "News")]
        public IActionResult News()
        {
            return Ok(new RacoonProvider.News().getAllNews());
        }
        [HttpPost("editMember", Name = "editMember")]
        public IActionResult editMember(Entities.Team ser)
        {
            return Ok(new Team().getAMember(ser.Id));
        }
        [HttpPost("updateTeamMember", Name = "updateTeamMember")]
        public IActionResult updateTeamMember(Entities.Team ser)
        {
            return Ok(new Team().UpdateNameAndDetails(ser.Id, ser.Name, ser.Details));
        }
        [HttpGet("Teammm", Name = "Teammm")]

        public IActionResult Team()
        {
            return Ok(new Team().getAllTeamMembers());
        }
        [HttpPost("addingNewMember", Name = "addingNewMember")]
        public IActionResult addingNewMember(IFormFile imageFile ,Entities.Team tem)
        {
            return Ok(new RacoonProvider.Team().addTeamMember(imageFile, tem));
        }
        [HttpGet("deleteTask", Name = "deleteTask")]
        public IActionResult deleteTask(int id)
        {
            return Ok(new Contact().deleteContact(id));
        }
        [HttpGet("Services", Name = "Services")]
        public IActionResult Services()
        {
            return  Ok(new RacoonProvider.Services().getAllServices());
        }
        [HttpPost("createNewService", Name = "createNewService")]
        public IActionResult createNewService(Entities.Service ser)
        {
            return Ok(new RacoonProvider.Services().addService(ser));
        }
        [HttpGet("deleteService", Name = "deleteService")]
        public IActionResult deleteService(int id)
        {
            return Ok(new RacoonProvider.Services().deleteService(id));
        }
        [HttpPost("updateService", Name = "updateService")]
        public IActionResult updateService(Entities.Service ser)
        {
            return Ok(new RacoonProvider.Services().UpdateServiceNameAndDetails(ser.Id, ser.Name, ser.Details));
        }
        
        [HttpGet("CountPage", Name = "CountPage")]
        public IActionResult CountPage(string SearchStr, string filter)
        {
            return Ok(new RacoonProvider.Contact().spNewCountSearchByName(SearchStr, filter));
        }
        
         
    }
}
