using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Resturant.CrudAppServiceBase;
using Resturant.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Customers
{
    public interface ICustomerAppService : IResturantAsyncCrudAppService<CustomerDto, int, ResturantBaseListInputDto, CreateCustomerDto, EditCustomerDto>
    {
        //    Task CreateCustomer(CreateCustomerDto input);
        Task<PagedResultDto<CustomerListDto>> GetAllCustomersAsync(ResturantBaseListInputDto input);

       // public Task<ListResultDto<CustomerListDto>> GetAllAsync(GetAllCustomersInput input);
    }
}
