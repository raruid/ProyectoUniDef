using Abp.Application.Services;
using UniDef.MultiTenancy.Dto;

namespace UniDef.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

