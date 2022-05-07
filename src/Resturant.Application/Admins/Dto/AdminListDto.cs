﻿using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Resturant.Authorization.Users;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Resturant.Enums;

namespace Resturant.Admins.Dto
{
    [AutoMapFrom(typeof(Admin))]

   public class AdminListDto : EntityDto<int>
    {
        [Required]
        public long UserId { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public int? DepartmentId { get; set; }
        public string Code { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }
        public long? CreatorUserId { get; set; }
        public string CreatorUserName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
