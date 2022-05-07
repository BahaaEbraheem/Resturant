using Resturant.Admins.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Admins
{
    public interface IAdminAppService
    {
        Task<AdminListDto> GetAllAdminsAsync();
    }
}
