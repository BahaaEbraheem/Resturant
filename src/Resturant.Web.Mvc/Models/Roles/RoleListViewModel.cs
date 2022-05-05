using System.Collections.Generic;
using Resturant.Roles.Dto;

namespace Resturant.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
