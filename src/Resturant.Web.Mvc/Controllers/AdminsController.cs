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
    [AbpMvcAuthorize]
    public class AdminsController : ResturantControllerBase
    {
        private readonly IAdminAppService _AdminAppService;
        public AdminsController(IAdminAppService AdminAppService)
        {
            _AdminAppService = AdminAppService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new AdminViewModel();
            var admins = await _AdminAppService.GetAllAsync(new GetAllAdminsInput());

            model.Admins = new SelectList(admins.Items.ToList(), "Id", "Name");
            return View(model);
        }
    }
}
