using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Models
{
    public class Admin : FullAuditedEntity
    {
        [Required]
        public long UserId { get; set; }
        public bool? IsSuperAdmin { get; set; }

    }
}
