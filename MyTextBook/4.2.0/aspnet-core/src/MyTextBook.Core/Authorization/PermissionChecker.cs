using Abp.Authorization;
using MyTextBook.Authorization.Roles;
using MyTextBook.Authorization.Users;

namespace MyTextBook.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
