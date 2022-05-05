using System.Collections.Generic;
using Resturant.Roles.Dto;

namespace Resturant.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}