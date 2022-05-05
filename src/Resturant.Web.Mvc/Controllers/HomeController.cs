using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Resturant.Controllers;

namespace Resturant.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ResturantControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
