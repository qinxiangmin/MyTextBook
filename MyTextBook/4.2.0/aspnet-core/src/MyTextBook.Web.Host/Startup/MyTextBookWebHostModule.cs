using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTextBook.Configuration;

namespace MyTextBook.Web.Host.Startup
{
    [DependsOn(
       typeof(MyTextBookWebCoreModule))]
    public class MyTextBookWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyTextBookWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTextBookWebHostModule).GetAssembly());
        }
    }
}
