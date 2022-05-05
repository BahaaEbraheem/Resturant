using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Resturant.Controllers
{
    public abstract class ResturantControllerBase: AbpController
    {
        protected ResturantControllerBase()
        {
            LocalizationSourceName = ResturantConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
