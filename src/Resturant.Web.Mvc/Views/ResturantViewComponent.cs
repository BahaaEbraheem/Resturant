using Abp.AspNetCore.Mvc.ViewComponents;

namespace Resturant.Web.Views
{
    public abstract class ResturantViewComponent : AbpViewComponent
    {
        protected ResturantViewComponent()
        {
            LocalizationSourceName = ResturantConsts.LocalizationSourceName;
        }
    }
}
