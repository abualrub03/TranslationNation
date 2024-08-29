using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RacoonProvider;
using ViewModel.AdminViewModels;
using Team = RacoonProvider.Team;
using Contact = RacoonProvider.Contact;
namespace TranslationNation.Controllers
{
    public class AdminController : AuthorizedController
    {
        public async Task<IActionResult> signOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Customer");
        }
        [HttpPost]
        public IActionResult deleteNews(Entities.News ns)
        {
             new RacoonProvider.News().deleteNews(ns.Id);
            return News();
        }
        [HttpGet]
        public IActionResult News()
        {
            return View("News", new RacoonProvider.News().getAllNews());
        }
        [HttpPost]
        public IActionResult editMember(Entities.Team ser)
        {
            return View("teamMember", new Team().getAMember(ser.Id));
        }
        [HttpPost]
        public IActionResult updateTeamMember(Entities.Team ser)
        {
            new Team().UpdateNameAndDetails(ser.Id,ser.Name,ser.Details);
            return Team();
        }
        public IActionResult Team()
        {
            return View("Team", new Team().getAllTeamMembers());
        }
        [HttpPost]
        public IActionResult addingNewMember(IFormFile imageFile ,Entities.Team tem)
        {
            new RacoonProvider.Team().addTeamMember(imageFile,tem);
            return Team();
        }               
        [HttpPost]
        public IActionResult deleteTask(Entities.Contact con)
        {
            new Contact().deleteContact(con.Id);
            return Redirect("dashboard");
        }
        [HttpGet]
        public IActionResult Services()
        {
            return View("Services", new Services().getAllServices());
        }
        [HttpPost]
        public IActionResult createNewService(Entities.Service ser)
        {
            new RacoonProvider.Services().addService(ser);
            return Services();
        }
        [HttpPost]
        public IActionResult deleteService(Entities.Service ser)
        {
            new RacoonProvider.Services().deleteService(ser.Id);
            return Services();
        }
        public IActionResult service(Entities.Service ser)
        {
            return View("service",ser);
        }
        [HttpPost]
        public IActionResult updateService(Entities.Service ser)
        {
            new RacoonProvider.Services().UpdateServiceNameAndDetails(ser.Id,ser.Name,ser.Details);
            return Services();
        }
        [HttpGet]
        public IActionResult LoadPartialView(String SearchStr, string filter, int Section)
        {
            List<Entities.Contact> list = new List<Entities.Contact>();
            list = new RacoonProvider.Contact().spNewSearchIntblContact(SearchStr, filter, Section, 10);
            return View("_ViewMore", list);
        }
        [HttpGet]
        public int CountPage(string SearchStr, string filter)
        {
            return new RacoonProvider.Contact().spNewCountSearchByName(SearchStr, filter);
        }
        [HttpGet]
        public IActionResult dashboard()
        {
            var v = new ViewMoreViewModel() { };
            v.Contacts = new Contact().spNewSearchIntblContact("", "%%", 0,10);
            v.NumberOfItemsSearchedFor = new Contact().spNewCountSearchByName("%%", "%%");
            v.Services = new RacoonProvider.Services().getAllServices();
            return View("dashboard", v);
        }
        [HttpPost]
        public IActionResult searchContacts(string SearchString,string Service,int start)
        {
            var v = new ViewMoreViewModel();
            v.Contacts = new Contact().spNewSearchIntblContact(SearchString, Service, start, 10);
            if(start == 0)
            {
                v.NumberOfItemsSearchedFor = new Contact().spNewCountSearchByName(v.Searchstr, v.Filter);
            }
            return View("dashboard", v);
        }        
    }
}
