using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UniDef.EntityFrameworkCore;
using UniDef.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace UniDef.Web.Tests
{
    [DependsOn(
        typeof(UniDefWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class UniDefWebTestModule : AbpModule
    {
        public UniDefWebTestModule(UniDefEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UniDefWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(UniDefWebMvcModule).Assembly);
        }
    }
}