using Abp.Domain.Entities.Auditing;
using Resturant.Authorization.Users;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Resturant.Enums;

namespace Resturant.Models
{
    public class Customer : FullAuditedEntity
    {

        [Required]
        public long UserId { get; set; }
 



    }
}
