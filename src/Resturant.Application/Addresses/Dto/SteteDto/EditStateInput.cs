using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Resturant.Models;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Addresses.Dto.SteteDto
{
    [AutoMap(typeof(State))]
    class EditStateInput : EntityDto<int>
    {
    }
}
