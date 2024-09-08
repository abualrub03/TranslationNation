using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Entities;
using ViewModel.UserViewModels;
using Microsoft.EntityFrameworkCore;
using RacoonProvider;
using ViewModel.AdminViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TranslationNation.Controllers
{
    public class CustomerController : BaseController
    {
        // <<< sendContactRequest  11
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
            return Index();
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
            

            return RedirectToAction("dashboard", "Admin", v);
        }
        // loginValidation >>>
        // <<< login View 
        public ActionResult login()
        {
            return View("login");
        }
         public ActionResult PrivacyPolicy()
            {
                return View("PrivacyPolicy");
            }
         public ActionResult ContactUs()
        {
            return View("ContactUs");
        }
         public ActionResult TermsOfService()
        {
            return View("TermsOfService");
        }
        // login view >>>
        
        [Route("")]
        [Route("/Customer/Index")]
        public ActionResult Index()
        {
            return View("Index");
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
            
        ///////////////TRANSLATION
        

        [HttpPost]
        public async Task<IActionResult> SignUpRequestAsCustomerAsync(string FullName, string Email, string BirthDate, string Password, string ConfirmPassword, bool AcceptTerms)
        {
            if (ModelState.IsValid)
            {

                var data = new RacoonProvider.TN_DB_Accounts().newSignUpClientRequest(FullName, Email, BirthDate, Password, AcceptTerms);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return View("SignIn");
                }
                var claims = new List<Claim>
                     {
                         new Claim("AccountId", data.AccountId.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("EmailAddress", data.EmailAddress,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.TheRole,ClaimValueTypes.String ),
                         new Claim("FirstName", (data.FirstName),ClaimValueTypes.String ),
                         new Claim("LastName", (data.LastName),ClaimValueTypes.String )
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
                return View("SignUp");

            return RedirectToAction("ClientIndex", "Client");
        }

        [HttpPost]
        public async Task<IActionResult> SignInRequest(string Email, string Password)
        {                

            if (ModelState.IsValid)
            {
                var data = new RacoonProvider.TN_DB_Accounts().newSignInRequest(Email, Password);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return View("SignIn");
                }
                var claims = new List<Claim>
                     {
                         new Claim("AccountId", data.AccountId.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("EmailAddress", data.EmailAddress,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.TheRole,ClaimValueTypes.String ),
                         new Claim("FirstName", (data.FirstName),ClaimValueTypes.String ),
                         new Claim("LastName", (data.LastName),ClaimValueTypes.String )
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
                return View("SignIn");
                
            return RedirectToAction("ClientIndex", "Client");
        }




        [HttpPost]
        public async Task<IActionResult> SignUpRequestAsTranslatorAsync(string FullName, string Email, string BirthDate, string Password, string ConfirmPassword, bool AcceptTerms)
        {
            
            if (ModelState.IsValid)
            {

                var data = new RacoonProvider.TN_DB_Accounts().newSignUpTranslatorRequest(FullName, Email, BirthDate, Password, AcceptTerms);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return View("SignIn");
                }
                var claims = new List<Claim>
                     {
                         new Claim("AccountId", data.AccountId.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("EmailAddress", data.EmailAddress,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.TheRole,ClaimValueTypes.String ),
                         new Claim("FirstName", (data.FirstName),ClaimValueTypes.String ),
                         new Claim("LastName", (data.LastName),ClaimValueTypes.String )
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            else
                return View("SignUp");

            return RedirectToAction("ClientIndex", "Client");
        }



        [HttpPost]
        public async Task<IActionResult> SignUpRequestAsSupervisorAsync(string FullName, string Email, string Location, string PhoneNumber, string Username, string University, string Password, string ConfirmPassword, bool AcceptTerms)
        {
       
                // Call the new sign-up request for Supervisor
                var data = new RacoonProvider.TN_DB_Accounts().newSignUpSupervisorRequest(FullName, Email, Location, PhoneNumber, Username, University, Password, AcceptTerms);

                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Sign-up failed. Please check your input.");
                    return View("SignUp");
                }

                var claims = new List<Claim>
                     {
                         new Claim("AccountId", data.AccountId.ToString() ,ClaimValueTypes.Integer32),
                         new Claim("EmailAddress", data.EmailAddress,ClaimValueTypes.Email),
                         new Claim(ClaimTypes.Role, data.TheRole,ClaimValueTypes.String ),
                         new Claim("FirstName", (data.FirstName),ClaimValueTypes.String ),
                         new Claim("LastName", (data.LastName),ClaimValueTypes.String )
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Dashboard", "Supervisor");
          
        }

    }
}
