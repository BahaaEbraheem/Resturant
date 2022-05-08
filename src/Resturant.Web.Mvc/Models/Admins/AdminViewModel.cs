using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant.Admins.Dto;
using Resturant.Models;
using System;
using System.Collections.Generic;
using Resturant.Localization.SourceFiles;
using System.ComponentModel.DataAnnotations;
namespace Resturant.Web.Models.Admins
{
    [AutoMap(typeof(CreateAdminDto))]
    public class AdminViewModel
    { 
        public SelectList Admins { get; set; }
    }
}