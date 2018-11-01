using System.Threading.Tasks;
using Abp.Application.Services;
using MyTextBook.Authorization.Accounts.Dto;

namespace MyTextBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
