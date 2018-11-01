using System.Threading.Tasks;
using MyTextBook.Configuration.Dto;

namespace MyTextBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
