using Gleek.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

namespace Gleek.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid && ValidateCredential(model.Username, model.Password))
            {
                var claimsId = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                var claim = new Claim(ClaimTypes.Name, model.Username);
                var claimLocation = new Claim("Location", "Abuja");
                claimsId.AddClaim(claim);
                claimsId.AddClaim(claimLocation);

                var principal = new ClaimsPrincipal(claimsId);
                this.HttpContext.SignInAsync(principal);
                TempData["Name"]= model.Username;
                return RedirectToAction("index", "dashboard", new { area = "Admin" });
            }

            return View(model);
        }

        public bool ValidateCredential(string username, string password)
        {
            return ("admin@admin.com".Equals(username, StringComparison.OrdinalIgnoreCase) & password == "admin") ? true : false;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
