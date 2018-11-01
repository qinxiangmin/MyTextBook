using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyTextBook.Controllers
{
    public abstract class MyTextBookControllerBase: AbpController
    {
        protected MyTextBookControllerBase()
        {
            LocalizationSourceName = MyTextBookConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
