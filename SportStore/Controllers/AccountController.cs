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
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if ((await _signInManager.PasswordSignInAsync(loginModel.Login, loginModel.Password, false, false)).Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
               
            }
            return View("Index",loginModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }
    }
}
