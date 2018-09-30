using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Models.Identity;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [Route("login")]
        public ActionResult LoginForm()
        {
            return View();
        }

        public async Task<ActionResult> LoginUser(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByEmailAsync(user.Email);
                if (appUser != null && await _userManager.CheckPasswordAsync(appUser, user.Password))
                {
                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", @"Invalid username or password");

            return View(user);
        }

        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}