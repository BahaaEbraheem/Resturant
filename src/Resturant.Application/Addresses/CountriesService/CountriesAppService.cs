using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Resturant.Addresses.Dto.CountryDto;
using Resturant.CrudAppServiceBase;
using Resturant.Domain.Address;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Addresses.CountriesService
{
    public class CountriesAppService : ResturantAppServiceBase, ICountriesAppService
    {
        private readonly IRepository<Country> _countriesRepository;
        private readonly IAddressManager _addressManager;
            
        public CountriesAppService(IRepository<Country> countriesRepository, IAddressManager addressManager)
        {
            this._countriesRepository = countriesRepository;
            this._addressManager = addressManager;
        }

        public async Task<ListResultDto<CountryListDto>> GetAllAsync(GetAllCountriesInput input)
        {
            var countries = await _countriesRepository.GetAllListAsync();
            return new ListResultDto<CountryListDto>(
                ObjectMapper.Map<List<CountryListDto>>(countries)
                );
        }
    }
}
