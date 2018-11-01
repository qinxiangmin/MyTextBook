using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using MyTextBook.Applications.CourseTypes.Dto;
using MyTextBook.Entitys.CourseTypes;

namespace MyTextBook.Applications.CourseTypes
{
    public class CourseTypesAppService : MyTextBookAppServiceBase, ICourseTypesAppService
    {
        private readonly IRepository<CourseType> _courseTypeRepository;//仓储
        public CourseTypesAppService(IRepository<CourseType> courseTypeRepository)
        {
            _courseTypeRepository = courseTypeRepository;

        }
        public async Task<CourseTypeDtoOutput> CreateAsync(CourseTypeDtoInput entity)
        {
            CourseType courseType = new CourseType()
            {
                CourseTypeName = entity.CourseTypeName,
                Description = entity.Description
            };
            var newCourseType = await _courseTypeRepository.InsertAsync(courseType);

            var courseTypeDtoOutput = Mapper.Map<CourseTypeDtoOutput>(newCourseType);
            return courseTypeDtoOutput;
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var courseType = await _courseTypeRepository.GetAsync(entity.Id);
            await _courseTypeRepository.DeleteAsync(courseType);
        }

        public async Task<ListResultDto<CourseTypeDtoOutput>> GetAllAsync()
        {
            var courseType = await _courseTypeRepository.GetAllListAsync();

            return new ListResultDto<CourseTypeDtoOutput>(
                 ObjectMapper.Map<List<CourseTypeDtoOutput>>(courseType)
                 );
        }

        public async Task<CourseTypeDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var courseType = await _courseTypeRepository.FirstOrDefaultAsync(entity.Id);

            var courseTypeDtoOutput = Mapper.Map<CourseTypeDtoOutput>(courseType);
            return courseTypeDtoOutput;
        }

        public async Task<CourseTypeDtoOutput> UpdateAsync(CourseTypeDtoInput entity)
        {
            CourseType courseType = new CourseType()
            {
                Id = entity.Id,
                CourseTypeName = entity.CourseTypeName,
                Description = entity.Description
            };

            var updateCourseType = await _courseTypeRepository.UpdateAsync(courseType);
            var courseTypeDtoOutput = Mapper.Map<CourseTypeDtoOutput>(updateCourseType);
            return courseTypeDtoOutput;
        }
    }
}
