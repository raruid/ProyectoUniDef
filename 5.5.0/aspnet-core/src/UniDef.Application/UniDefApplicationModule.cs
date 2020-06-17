using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UniDef.Authorization;

namespace UniDef
{
    [DependsOn(
        typeof(UniDefCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class UniDefApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<UniDefAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(UniDefApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
