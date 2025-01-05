using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Internal;
using SplashTrainer.Data;
using SplashTrainer.Models;

namespace SplashTrainer.Controllers
{

    [AllowAnonymous]

    public class AccountController : Controller // logika rejestracji, logowania i wylogowania
    {
        private readonly UserManager<IdentityUser> _userManager; // zarzadza uzytkownikiem np. dodawanie, sprawdzanie haseł
        private readonly SignInManager<IdentityUser> _signInManager; // zarzadza logowaniem, wylogowaniem

        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View("Register"); 
       

        [HttpPost] 
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email};
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login() => View("Login");

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Nieprawidłowy email lub hasło");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

