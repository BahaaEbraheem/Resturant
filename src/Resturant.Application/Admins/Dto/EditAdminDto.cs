using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Admins.Dto
{
    [AutoMapFrom(typeof(Admin))]

   public class EditAdminDto : CreateAdminDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
