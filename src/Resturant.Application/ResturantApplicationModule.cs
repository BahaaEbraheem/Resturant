using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Resturant.Authorization;

namespace Resturant
{
    [DependsOn(
        typeof(ResturantCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ResturantApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ResturantAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ResturantApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
