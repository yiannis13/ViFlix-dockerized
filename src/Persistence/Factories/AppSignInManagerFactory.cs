using Common.Factories;
using Common.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

//using Common.Models.Identity;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;

namespace Persistence.Factories
{
    public class AppSignInManagerFactory : SignInManagerFactory
    {
        public override SignInManager<AppUser> Create(HttpContext httpContext, UserManager<AppUser> userManager)
        {
            //IAuthenticationManager authenticationManager = httpContext.GetOwinContext().Authentication;
            //return new SignInManager<AppUser>(userManager, authenticationManager);
            return null;
        }
    }
}