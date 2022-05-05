using System.Threading.Tasks;
using Abp.Application.Services;
using Resturant.Authorization.Accounts.Dto;

namespace Resturant.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
