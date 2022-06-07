using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Resturant.Controllers;
using Resturant.Admins;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant.Web.Models.Admins;
using System.Threading.Tasks;
using System.Linq;
using Resturant.Addresses.CountriesService;
using Resturant.Addresses.Dto.CountryDto;

namespace Resturant.Web.Controllers
{
    //[AbpMvcAuthorize]
    public class CustomersController : ResturantControllerBase
    {
        private readonly ICountriesAppService _countriesAppService;
        public CustomersController(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;
        }
        public async Task<IActionResult> Index(int? stateId)
        {
            var countries = await _countriesAppService.GetAllAsync(new GetAllCountriesInput());
      
            ViewBag.countries = _countriesAppService.GetAllAsync(new GetAllCountriesInput()
            {
            
            }).Result.Items.Select(i => Json(new
            {
                Value = i.Id,
                Text = i.Name
            })).ToList();
            return View();
        }
    }
}
