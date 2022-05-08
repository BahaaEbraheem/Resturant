using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant.Admins.Dto;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Runtime.Validation;
using Abp.Runtime.Security;
namespace Resturant.Admins
{
    public class AdminAppService : ResturantAppServiceBase, IAdminAppService
    {
        private readonly  IRepository<Admin> _repository ;
        public AdminAppService(IRepository<Admin> repository) 
        {
            _repository = repository;

        }



        public async Task<ListResultDto<AdminListDto>> GetAllAsync(GetAllAdminsInput input)
        {
            var admins = await _repository.GetAllListAsync();
            return new ListResultDto<AdminListDto>(
                ObjectMapper.Map<List<AdminListDto>>(admins)
                );
        }
    }
}
