using System.Threading.Tasks;
using Abp.Application.Services;
using Resturant.Sessions.Dto;

namespace Resturant.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
