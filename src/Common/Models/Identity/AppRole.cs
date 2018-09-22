using Microsoft.AspNetCore.Identity;

namespace Common.Models.Identity
{
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
        }

        public AppRole(string roleName)
            : base(roleName)
        {
        }

    }
}