using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Addresses.Dto.CountryDto
{
    [AutoMap(typeof(Country))]
    public class CountryDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
