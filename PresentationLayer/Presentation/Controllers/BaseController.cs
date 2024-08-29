using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.DataProtection;
using Entities;
public class BaseController : Controller
{
    public SqlConnection _connection = new SqlConnection("Data Source=localhost;Initial Catalog=ASP;Integrated Security=True;Application Name=EntityFramework; TrustServerCertificate=True");
    public SqlCommand? cmd;
    public SqlDataReader? sqlReader;
    public List<Contact> listContacts = new List<Contact>();
    

}
