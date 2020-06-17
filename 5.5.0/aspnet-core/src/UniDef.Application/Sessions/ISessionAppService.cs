using System.Threading.Tasks;
using Abp.Application.Services;
using UniDef.Sessions.Dto;

namespace UniDef.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
