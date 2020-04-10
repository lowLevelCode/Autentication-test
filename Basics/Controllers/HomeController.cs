using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }      

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {   
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "jalarcon@aforecoppel.com"),
                new Claim("Grandma.Says", "Hola que prros")
            };         

            var licentClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("DrivingLicenses", "A+")
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims,"Grandma Indentity");
            var licenseIdentity = new ClaimsIdentity(licentClaims, "Government");
            var userPrincipal = new ClaimsPrincipal(new[]{ grandmaIdentity, licenseIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}