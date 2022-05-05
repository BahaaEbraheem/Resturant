using System.Threading.Tasks;
using Resturant.Configuration.Dto;

namespace Resturant.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
