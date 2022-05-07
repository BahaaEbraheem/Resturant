using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using AutoMapper;
using Resturant.Authorization.Users;
using Resturant.Models;
using Resturant.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Admins.Dto
{
    public class AdminMapProfile : Profile
    {
        public AdminMapProfile()
        {

            CreateMap<CreateAdminDto, User>();
            CreateMap<User, CreateAdminDto>();
            CreateMap<CreateAdminDto, Admin>();
            CreateMap<Admin, CreateAdminDto>();
        }
}
}
