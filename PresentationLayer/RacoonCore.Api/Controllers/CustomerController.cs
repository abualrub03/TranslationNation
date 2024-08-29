using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.ComponentModel.DataAnnotations;
using JWT;

namespace TranslationNation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
       
        private IConfiguration _configuration;
        public CustomerController(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }
        /*
        [HttpPost("validate-token")]
        public async Task<IActionResult> ValidateToken([FromBody] string token)
        {
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken;
                 var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                
                // Extract claims and other relevant information from the principal

                return Ok(new
                {
                    Valid = true,
                    Claims = principal.Claims.ToArray(),
                    // Add additional information as needed
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        */
        [HttpPost("PostsendContactRequest", Name = "PostsendContactRequest")]
        public IActionResult sendContactRequest(Entities.Contact con)
        {
            new RacoonProvider.Contact().newContactRequest(con);
            return Ok();
        }
        [HttpPost("PostnewsNewSubscribtion", Name = "PostnewsNewSubscribtion")]
        public IActionResult newsNewSubscribtion(Entities.News news)
        {
            new RacoonProvider.News().newSubscribtion(news);
            return Ok();
        }
        [HttpPost("PostloginValidation", Name = "PostloginValidation")]
        public async Task<IActionResult> loginValidation(string Email , string Password)
        {
            if (ModelState.IsValid)
            {
                var data = new RacoonProvider.Team().getTeamMemberByInfo(Email, Password);
                if (data == null)
                {
                    ModelState.AddModelError("FormValidation", "Wrong Username or Password");
                    return BadRequest();
                }
                else
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim("Id", data.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Sub, Email),
                            new Claim(JwtRegisteredClaimNames.Email, Password),
                            new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString()),
                            new Claim("Role" ,data.Role)
                    }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    var stringToken = tokenHandler.WriteToken(token);
                    return Ok(stringToken);
                }
             
            }
            else
                return BadRequest(); 
           
        }

        [HttpGet("service", Name = "service")]
        public IActionResult service()
        {
            return Ok(new RacoonProvider.Services().getAllServices());
        }        
        [HttpGet("team", Name = "team")]
        public IActionResult team()
        {
            return Ok(new RacoonProvider.Team().getAllTeamMembers());
        }
        [HttpGet("contact", Name = "contact")]
        public IActionResult contact()
        {
            return Ok(new RacoonProvider.Services().getAllServices());
        }
        [HttpGet("GetImage", Name = "GetImage")]
        public IActionResult GetImage(int id)
        {
            using (var con = new RacoonProvider.Team())
            {
                Entities.Team tem = new Entities.Team();
                tem = con.getAMember(id).FirstOrDefault();
                HttpContext.Response.Headers.Add("Content-Type", tem.ImageContentType);
                return Ok(File(tem.ImageData, tem.ImageContentType));
            }
        }
    }
}
