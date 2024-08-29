using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Entities;
using ViewModel.UserViewModels;
using Microsoft.EntityFrameworkCore;
using RacoonProvider;
using ViewModel.AdminViewModels;

namespace TranslationNation.Controllers
{
    public class CustomerController : BaseController
    {
        // <<< sendContactRequest  
        [HttpPost]
        public IActionResult sendContactRequest(Entities.Contact con)
        {
            new RacoonProvider.Contact().newContactRequest(con);
            return contact();
        }
        // sendContactRequest >>>
        // <<< newsNewSubscribtion
        [HttpPost]
        public IActionResult newsNewSubscribtion(Entities.News news)
        {
            new RacoonProvider.News().newSubscribtion(news);
            return index();
        }
        // newsNewSubscribtion >>>
        // <<< loginValidation First step
        [HttpPost]
        public async Task<IActionResult> loginValidation(ViewModel.UserViewModels.loginViewModel acc)
        {
            if (ModelState.IsValid)
            {
                var data = new RacoonProvider.Team().getTeamMemberByInfo(acc.Email, acc.Password);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return View("login", acc);
                }
                var claims = new List<Claim>
                     {
                         new Claim("CustomerID", data.Id.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("CustomerEmail", data.Email,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.Role,ClaimValueTypes.String ),
                         new Claim(ClaimTypes.Role, data.Name,ClaimValueTypes.String )
                     };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
                return View("login", acc);


            var v = new ViewMoreViewModel() { };
            v.Contacts = new RacoonProvider.Contact().spNewSearchIntblContact("", "%%", 0, 10);
            v.NumberOfItemsSearchedFor = new RacoonProvider.Contact().spNewCountSearchByName("%%", "%%");
            v.Services = new RacoonProvider.Services().getAllServices();
           

            return RedirectToAction("dashboard", "Admin", v);
        }
        // loginValidation >>>
        // <<< login View 
        public ActionResult login()
        {
            return View("login");
        }
        // login view >>>
        // <<< index 
        
        public IActionResult index()
        {
            if (User.FindFirst("CustomerID") != null)
                return RedirectToAction("dashboard", "Admin");
            else
            {
                
                return View("index");
            }
        }
        // index >>>

        public IActionResult SignUp()
        {
            return View("SignUp");
        }public IActionResult SignIn()
        {
            return View("SignIn");
        }
        public IActionResult Services()
        {
            return View("Services");
        }
        // <<< service
        public ActionResult service()
        {
            var obj = new RacoonProvider.Services();
            List<Entities.Service> entityList = obj.getAllServices();
            return View(entityList);
        }
        // service >>>
        // <<< team 
        public IActionResult team()
        {

            var obj = new RacoonProvider.Team();
            List<Entities.Team> entityList = obj.getAllTeamMembers();
            return View(entityList);
        }
        // team >>>
        // <<< about
        public IActionResult about()
        {
            return View();
        }
        // about >>
        // << contact
        [HttpPost]
        [HttpGet]
        public IActionResult contact()
        {
            var obj = new RacoonProvider.Services();
            List<Entities.Service> entityList = obj.getAllServices();
            return View("_contact", entityList);
        }
        // contact >>
        [HttpGet]
        public IActionResult GetImage(int id)
        {
            using (var con = new RacoonProvider.Team())
            {
                Entities.Team tem = new Entities.Team();
                tem = con.getAMember(id).FirstOrDefault();
                HttpContext.Response.Headers.Add("Content-Type", tem.ImageContentType);
                return File(tem.ImageData, tem.ImageContentType);
            }
        }

    }
}
