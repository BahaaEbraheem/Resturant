using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Resturant.Controllers;
using Resturant.Admins;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant.Web.Models.Admins;
using System.Threading.Tasks;
using System.Linq;

namespace Resturant.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class CustomersController : ResturantControllerBase
    {
        public CustomersController()
        {
        }
        public async Task<IActionResult> Index()
        {
          
            return View();
        }
    }
}
