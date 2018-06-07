using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class AccountController:Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        public AccountController(SignInManager<IdentityUser> signInManager) => _signInManager = signInManager;
        
        public ViewResult Index() => View();

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if ((await _signInManager.PasswordSignInAsync(login.Login, login.Password, false, false)).Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
               
            }
            return View("Index",login);
        }
    }
}
