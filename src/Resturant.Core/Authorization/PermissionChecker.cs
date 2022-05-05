using Abp.Authorization;
using Resturant.Authorization.Roles;
using Resturant.Authorization.Users;

namespace Resturant.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
