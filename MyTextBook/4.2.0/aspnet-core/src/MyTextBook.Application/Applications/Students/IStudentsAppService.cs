using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.Students.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Students
{
    public interface IStudentsAppService : IApplicationService
    {
        Task<PagedResultDto<StudentDtoOutput>> GetAllAsync(StudentPageInput studentPageInput, StudentSeachInput studentSeachInput, StudentOrderInput studentOrderInput);

        Task<ListResultDto<StudentDtoOutput>> GetAllAsync(EntityDto entity);

        Task<StudentDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<StudentDtoOutput> CreateAsync(StudentDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<StudentDtoOutput> UpdateAsync(StudentDtoInput entity);
    }
}
