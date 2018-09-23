using System;
using System.Collections.Generic;
using Common.Models.Identity;
//using Common.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence.DbContextContainer;

//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using ViFlix.DataAccess.DbContextContainer;

namespace Persistence.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        //public AppUserManager(IUserStore<AppUser> store)
        //    : base(store)
        //{
        //}

        // this method is called by Owin. Thus, it's the best place to configure your UserManager
        //public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        //{
        //    var manager = new AppUserManager(new UserStore<AppUser>(new ViFlixContext()));
        //    // optionally configure your manager

        //    return manager;
        //}
        public AppUserManager(IUserStore<AppUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<AppUser> passwordHasher, IEnumerable<IUserValidator<AppUser>> userValidators, IEnumerable<IPasswordValidator<AppUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}