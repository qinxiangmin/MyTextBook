using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.StudentClasses.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.StudentClasses
{
    public interface IStudentClassesAppService: IApplicationService
    {
        Task<PagedResultDto<StudentClassDtoOutput>> GetAllAsync(StudentClassPageInput studentClassPageInput, StudentClassSeach studentClassSeach, StudentClassOrderInput studentClassOrderInput);

        Task<StudentClassDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<StudentClassDtoOutput> CreateAsync(StudentClassDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<StudentClassDtoOutput> UpdateAsync(StudentClassDtoInput entity);

        Task<ListResultDto<StudentClassDtoOutput>> GetAllAsync();
    }
}
