using Abp.AutoMapper;
using Resturant.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Roles.Dto
{

    [AutoMapFrom(typeof(Role))]
    public class RoleListResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int UsersCount { get; set; }

        public bool IsDefault { get; set; }

        public long? CreatorUserId { get; set; }
        public bool IsActive { get; set; }

        public string CreatorUserName { get; set; }

        public DateTime CreationTime { get; set; }

        public List<string> GrantedPermissions { get; set; }

        public bool CanDelete { get; set; }
    }

}
