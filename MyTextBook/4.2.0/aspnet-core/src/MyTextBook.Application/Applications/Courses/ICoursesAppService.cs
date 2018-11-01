using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.Courses.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Courses
{
    public interface ICoursesAppService: IApplicationService
    {
        Task<PagedResultDto<CourseDtoOutput>> GetAllAsync(CoursePageInput coursePageInput, CourseSeachInput courseSeachInput, CourseOrderInput courseOrderInput);

        Task<ListResultDto<CourseDtoOutput>> GetAllAsync();

        Task<CourseDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<CourseDtoOutput> CreateAsync(CourseDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<CourseDtoOutput> UpdateAsync(CourseDtoInput entity);
    }
}
