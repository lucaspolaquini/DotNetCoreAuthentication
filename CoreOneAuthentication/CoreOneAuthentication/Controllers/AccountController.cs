using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreOneAuthentication.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CoreOneAuthentication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if (user.UserName == "lucas" && user.Password == "123Mudar")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);

                await HttpContext.SignInAsync("app", principal);
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("app");

            return RedirectToAction("Index", "Home");
        }

    }
}
