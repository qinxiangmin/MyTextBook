using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Applications.Courses.Dto;
using MyTextBook.Entitys.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Courses
{
    public class CoursesAppService : MyTextBookAppServiceBase, ICoursesAppService
    {
        private readonly IRepository<Course> _courseRepository;//仓储
        public CoursesAppService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<CourseDtoOutput> CreateAsync(CourseDtoInput entity)
        {
            Course course = new Course()
            {
                CourseName = entity.CourseName,
                CourseNumber = entity.CourseNumber,
                CourseTypeId = entity.CourseTypeId
            };
            var newCourse = await _courseRepository.InsertAsync(course);
            return new CourseDtoOutput();
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var course = await _courseRepository.GetAsync(entity.Id);
            await _courseRepository.DeleteAsync(course);
        }

        public async Task<PagedResultDto<CourseDtoOutput>> GetAllAsync(CoursePageInput coursePageInput, CourseSeachInput courseSeachInput, CourseOrderInput courseOrderInput)
        {
            var courseList = await _courseRepository.GetAll().Include(p => p.CourseType).ToListAsync();

            if (!string.IsNullOrEmpty(courseSeachInput.SeachBookName))
            {
                courseList = courseList.Where(p => p.CourseName.Contains(courseSeachInput.SeachBookName)).ToList();
            }
            if (courseOrderInput.OrderName == "Desc")
            {
                courseList = courseList.OrderByDescending(p => p.CourseName).ToList();
            }
            else
            {
                courseList = courseList.OrderBy(p => p.CourseName).ToList();
            }
            var coursesCount = courseList.Count();
            var taskList = courseList.Skip((coursePageInput.pageIndex - 1) * coursePageInput.pageMax).Take(coursePageInput.pageMax).ToList();
            return new PagedResultDto<CourseDtoOutput>(coursesCount, taskList.MapTo<List<CourseDtoOutput>>()
                    );
        }

        public async Task<ListResultDto<CourseDtoOutput>> GetAllAsync()
        {
            var course = await _courseRepository.GetAllListAsync();
            
            return new ListResultDto<CourseDtoOutput>(
                 ObjectMapper.Map<List<CourseDtoOutput>>(course)
                 );
        }

        public async Task<CourseDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var course = await _courseRepository.FirstOrDefaultAsync(entity.Id);

            var courseDtoOutput = Mapper.Map<CourseDtoOutput>(course);
            return courseDtoOutput;
        }

        public async Task<CourseDtoOutput> UpdateAsync(CourseDtoInput entity)
        {
            Course course = new Course()
            {
                Id = entity.Id,
                CourseNumber = entity.CourseNumber,
                CourseName = entity.CourseName,
                CourseTypeId = entity.CourseTypeId
            };
            var updateCourses = await _courseRepository.UpdateAsync(course);

            var courseDtoOutput = Mapper.Map<CourseDtoOutput>(updateCourses);
            return courseDtoOutput;
        }
    }
}
