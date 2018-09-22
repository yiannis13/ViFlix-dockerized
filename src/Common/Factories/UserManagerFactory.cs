using Common.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

//using Microsoft.AspNet.Identity;

namespace Common.Factories
{
    public abstract class UserManagerFactory
    {
        public abstract UserManager<AppUser> Create(HttpContext httpContext);
    }
}