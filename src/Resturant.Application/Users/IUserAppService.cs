using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Resturant.CrudAppServiceBase;
using Resturant.Roles.Dto;
using Resturant.Users.Dto;

namespace Resturant.Users
{
    public interface IUserAppService : IResturantAsyncCrudAppService<UserDto, long, ResturantBaseListInputDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
        //Task GetAllAsync(PagedUserResultRequestDto pagedUserResultRequestDto);
    }
}
