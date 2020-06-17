using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace UniDef.Controllers
{
    public abstract class UniDefControllerBase: AbpController
    {
        protected UniDefControllerBase()
        {
            LocalizationSourceName = UniDefConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
