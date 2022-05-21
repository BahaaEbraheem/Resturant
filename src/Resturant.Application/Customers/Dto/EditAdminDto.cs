using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Customers.Dto
{
    [AutoMapFrom(typeof(Customer))]

   public class EditCustomerDto : CreateCustomerDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
