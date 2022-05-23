using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Resturant.CrudAppServiceBase;
using Resturant.Roles.Dto;

namespace Resturant.Roles
{
    public interface IRoleAppService : IResturantAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}
