using Abp.AutoMapper;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Resturant.Enums;

namespace Resturant.Customers.Dto
{
    [AutoMapFrom(typeof(Customer))]

    public class CreateCustomerDto
    {
        [Required]
        public long UserId { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public PersonType? PersonType { get; set; }
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
