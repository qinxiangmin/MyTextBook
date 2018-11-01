using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.Majors.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Majors
{
    public interface IMajorsAppService: IApplicationService
    {
        Task<ListResultDto<MajorDtoOutput>> GetAllAsync();

        Task<ListResultDto<MajorDtoOutput>> GetAllByTDepartmentIdAsync(EntityDto entity);

        Task<MajorDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<MajorDtoOutput> CreateAsync(MajorDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<MajorDtoOutput> UpdateAsync(MajorDtoInput entity);
        Task GetAllByTDepartmentIdAsync(object entityDto);
    }
}
