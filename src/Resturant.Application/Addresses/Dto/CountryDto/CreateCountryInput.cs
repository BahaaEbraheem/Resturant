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
    public class CreateCountryInput
    {
    }
}
