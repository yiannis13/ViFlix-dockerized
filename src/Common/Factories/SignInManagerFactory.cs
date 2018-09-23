using Common.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;

namespace Common.Factories
{
    public abstract class SignInManagerFactory
    {
        public abstract SignInManager<AppUser> Create(HttpContext httpContext, UserManager<AppUser> userManager);
    }
}