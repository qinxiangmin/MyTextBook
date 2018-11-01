using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTextBook.Authorization;

namespace MyTextBook
{
    [DependsOn(
        typeof(MyTextBookCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyTextBookApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyTextBookAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyTextBookApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
