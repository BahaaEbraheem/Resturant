using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Resturant.Configuration.Dto;

namespace Resturant.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ResturantAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
