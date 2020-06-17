using System.Threading.Tasks;
using Abp.Application.Services;
using UniDef.Authorization.Accounts.Dto;

namespace UniDef.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
