using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.TDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.TDepartments
{
    public interface ITDepartmentsAppService : IApplicationService
    {
        Task<ListResultDto<TDepartmentDtoOutput>> GetAllAsync();

        Task<TDepartmentDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<TDepartmentDtoOutput> CreateAsync(TDepartmentDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<TDepartmentDtoOutput> UpdateAsync(TDepartmentDtoInput entity);
    }
}
