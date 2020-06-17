using Abp.Authorization;
using UniDef.Authorization.Roles;
using UniDef.Authorization.Users;

namespace UniDef.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
