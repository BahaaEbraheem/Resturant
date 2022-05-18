using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Resturant.Controllers;
using System.Threading.Tasks;

namespace Resturant.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class HomeController : ResturantControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return  View();
        }
        public IActionResult Reserve()
        {
            return View();
        }
    }
}
