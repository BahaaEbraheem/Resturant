using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Resturant.Addresses.Dto.SteteDto;
using Resturant.CrudAppServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Addresses.StatesService
{
    public interface IStatesAppService :IApplicationService
    {
        public Task<ListResultDto<StateListDto>> GetAllAsync(GetAllStatesInput input);
    }
}
