using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Resturant.EntityFrameworkCore;
using Resturant.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Resturant.Web.Tests
{
    [DependsOn(
        typeof(ResturantWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ResturantWebTestModule : AbpModule
    {
        public ResturantWebTestModule(ResturantEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ResturantWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ResturantWebMvcModule).Assembly);
        }
    }
}