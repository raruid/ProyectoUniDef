using System.Threading.Tasks;
using UniDef.Configuration.Dto;

namespace UniDef.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
