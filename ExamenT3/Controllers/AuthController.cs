using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamenT3.Models;
using ExamenT3.Repository;
using ExamenT3.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2Tests.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository user;
        private readonly ICookieAuthService cookie;

        public AuthController(IUsuarioRepository user, ICookieAuthService cookie)
        {
            this.user = user;
            this.cookie = cookie;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = user.FindUser(username, password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                cookie.Login(claimsPrincipal);

                return RedirectToAction("Index", "Nota");
            }
            
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string username, string password)
        {
            user.Registrar(username, password);
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
