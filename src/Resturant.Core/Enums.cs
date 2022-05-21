using Resturant.Localization.SourceFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Resturant
{
    public class Enums
    {

       
        public enum Status:byte        {
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Accepted))]
            Accepted = 0,
           [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Rejected))]
            Rejected = 1,
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Suspended))]

            Suspended = 2,
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.InProcess))]

            InProcess = 3,
        }


        public enum Gender
        {
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Male))]
            Male = 1,
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Female))]
            Female = 0
        }
        public enum PersonType
        {
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Admin))]
            Admin = 1,
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Customer))]
            Customer = 2,
            [Display(ResourceType = typeof(Tokens), Name = nameof(Tokens.Employee))]
            Employee = 3,
            
        }


    }
}
