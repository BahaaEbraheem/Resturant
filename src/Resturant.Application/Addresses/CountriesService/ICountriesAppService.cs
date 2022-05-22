using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Resturant.Addresses.Dto.CountryDto;
using Resturant.Addresses.Dto.CountryDto;
using Resturant.CrudAppServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Addresses.CountriesService
{
    public interface ICountriesAppService: IApplicationService
    {
        public Task<ListResultDto<CountryListDto>> GetAllAsync(GetAllCountriesInput input);
    }
}
