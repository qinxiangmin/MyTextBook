using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.MultiTenancy.Dto;

namespace MyTextBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
