using System.Collections.Generic;
using Resturant.Roles.Dto;

namespace Resturant.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
