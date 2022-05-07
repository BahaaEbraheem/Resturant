using Abp.Domain.Repositories;
using Resturant.Admins.Dto;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Admins
{
    public class AdminAppService : IAdminAppService
    {
        private readonly  IRepository<Admin, int> _repository ;
        public AdminAppService(IRepository<Admin, int> repository) 
        {
            _repository = repository;

        }

        public Task<AdminListDto> GetAllAdminsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
