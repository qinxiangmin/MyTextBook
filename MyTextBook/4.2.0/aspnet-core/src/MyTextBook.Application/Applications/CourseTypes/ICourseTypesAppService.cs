using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.CourseTypes.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.CourseTypes
{
    public interface ICourseTypesAppService: IApplicationService
    {
        Task<ListResultDto<CourseTypeDtoOutput>> GetAllAsync();      

        Task<CourseTypeDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<CourseTypeDtoOutput> CreateAsync(CourseTypeDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<CourseTypeDtoOutput> UpdateAsync(CourseTypeDtoInput entity);
    }
}
