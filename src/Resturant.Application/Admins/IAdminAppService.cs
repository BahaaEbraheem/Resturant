using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Resturant.Admins.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Admins
{
    public interface IAdminAppService:IApplicationService
    {
        public Task<ListResultDto<AdminListDto>> GetAllAsync(GetAllAdminsInput input);
    }
}
