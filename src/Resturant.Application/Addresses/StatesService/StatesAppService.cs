using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Resturant.Addresses.Dto.SteteDto;
using Resturant.CrudAppServiceBase;
using Resturant.Domain.Address;
using Resturant.Models;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Addresses.StatesService
{
    public class StatesAppService: ResturantAppServiceBase, IStatesAppService
    {
        private readonly IRepository<State> _statesRepository;
        private readonly IAddressManager _addressManager;
        public StatesAppService(IRepository<State> stetesRepository, IAddressManager addressManager)
        {
            _statesRepository = stetesRepository;
            _addressManager = addressManager;
        }

        public async Task<ListResultDto<StateListDto>> GetAllAsync(GetAllStatesInput input)
        {
            var states = await _statesRepository.GetAllListAsync(s=> !input.CountryId.HasValue ||s.CountryId== input.CountryId.Value);
            return new ListResultDto<StateListDto>(
                ObjectMapper.Map<List<StateListDto>>(states)
                );
            
        }
    }
}
