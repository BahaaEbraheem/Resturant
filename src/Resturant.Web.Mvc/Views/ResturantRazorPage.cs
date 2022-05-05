using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Resturant.Web.Views
{
    public abstract class ResturantRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ResturantRazorPage()
        {
            LocalizationSourceName = ResturantConsts.LocalizationSourceName;
        }
    }
}
