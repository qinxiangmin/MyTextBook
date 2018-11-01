using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyTextBook.Configuration.Dto;

namespace MyTextBook.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyTextBookAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
