using Abp.Application.Services;
using Resturant.MultiTenancy.Dto;

namespace Resturant.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

