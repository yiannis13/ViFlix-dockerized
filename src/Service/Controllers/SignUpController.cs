using System;
using System.Threading.Tasks;
using Common.Models.Identity;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [AllowAnonymous]
    public class SignUpController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SignUpController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager ?? throw new NullReferenceException();
            _signInManager = signInManager ?? throw new NullReferenceException();
        }

        [Route("signup")]
        public ActionResult SignUpForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SignUpUser(SignUpViewModel user)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                };

                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    // **Uncomment this line of code when you want to generate an new claim(type Role) to a user. Then, run the Application and SignUp.**
                    //await _userManager.AddClaimAsync(appUser, new Claim(ClaimTypes.Role, RoleName.Admin));

                    await _signInManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("IndexWhenAuthenticated", "Home");
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }
            }

            return View(user);
        }

    }
}