using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using UniDef.Configuration.Dto;

namespace UniDef.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : UniDefAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
