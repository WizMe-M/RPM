using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeWebSQL.Models;
using PracticeWebSQL.ViewModels;

namespace PracticeWebSQL.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly ApplicationContext _database;

        public AuthorizationController(ApplicationContext context)
        {
            _database = context;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationAccountModel model)
        {
            if (ModelState.IsValid)
            {
                var existing = await _database.Accounts.FirstOrDefaultAsync(a => a.Email == model.Email);
                if (existing is null)
                {
                    var account = new Account
                    {
                        Email = model.Email,
                        Login = model.Login,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        MiddleName = model.MiddleName,
                        BirthDate = model.BirthDate
                    };

                    _database.Accounts.Add(account);
                    await _database.SaveChangesAsync();
                    await Authenticate(model.Email);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("alreadyExist", "Пользователь с таким email уже создан");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthorizationAccountModel model)
        {
            if (ModelState.IsValid)
            {
                var account = await _database.Accounts.FirstOrDefaultAsync(a =>
                    a.Email == model.Email &&
                    a.Password == model.Password);

                if (account != null)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("notExist", "Некорректные email/логин и (или) пароль");
            }

            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authorization");
        }
    }
}