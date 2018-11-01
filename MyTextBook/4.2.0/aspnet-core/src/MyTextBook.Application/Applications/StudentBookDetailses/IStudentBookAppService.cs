using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.StudentBookDetailses.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.StudentBookDetailses
{
    public interface IStudentBookAppService : IApplicationService
    {
        Task<PagedResultDto<StudentBookDtoOutput>> GetAllAsync(StudentBookPageInput bookPageInput, StudentBookSeachInput bookSeachInput, StudentBookOrderInput bookOrderInput);

        Task<ListResultDto<StudentBookDtoOutput>> GetAllAsync();

        Task<StudentBookDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<StudentBookDtoOutput> CreateAsync(StudentBookDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<StudentBookDtoOutput> UpdateAsync(StudentBookDtoInput entity);
    }
}
