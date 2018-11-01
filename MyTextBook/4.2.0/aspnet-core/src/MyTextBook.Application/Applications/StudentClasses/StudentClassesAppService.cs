using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Applications.StudentClasses.Dto;
using MyTextBook.Entitys.StudentClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.StudentClasses
{
    public class StudentClassesAppService : MyTextBookAppServiceBase, IStudentClassesAppService
    {
        private readonly IRepository<StudentClass> _studentClassRepository;//仓储
        public StudentClassesAppService(IRepository<StudentClass> studentClassRepository)
        {
            _studentClassRepository = studentClassRepository;
        }

        public async Task<StudentClassDtoOutput> CreateAsync(StudentClassDtoInput entity)
        {
            StudentClass studentClass = new StudentClass()
            {
                 GradeName = entity.GradeName,
                 MajorId = entity.MajorId,
                 StudentClassName = entity.GradeName + entity.StudentClassName
            };
            var newStudentClass = await _studentClassRepository.InsertAsync(studentClass);
            return new StudentClassDtoOutput();
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var studentClass = await _studentClassRepository.GetAsync(entity.Id);
            await _studentClassRepository.DeleteAsync(studentClass);
        }

        public async Task<PagedResultDto<StudentClassDtoOutput>> GetAllAsync(StudentClassPageInput studentClassPageInput, StudentClassSeach studentClassSeach, StudentClassOrderInput studentClassOrderInput)
        {
            var studentClassList = await _studentClassRepository.GetAll().Include(p => p.Major).ToListAsync();

            if (!string.IsNullOrEmpty(studentClassSeach.SeachBookName))
            {
                studentClassList = studentClassList.Where(p => p.StudentClassName.Contains(studentClassSeach.SeachBookName)).ToList();
            }
            if (studentClassOrderInput.OrderName == "Desc")
            {
                studentClassList = studentClassList.OrderByDescending(p => p.StudentClassName).ToList();
            }
            else
            {
                studentClassList = studentClassList.OrderBy(p => p.StudentClassName).ToList();
            }
            var studentClassesCount = studentClassList.Count();
            var taskList = studentClassList.Skip((studentClassPageInput.pageIndex - 1) * studentClassPageInput.pageMax).Take(studentClassPageInput.pageMax).ToList();
            return new PagedResultDto<StudentClassDtoOutput>(studentClassesCount, taskList.MapTo<List<StudentClassDtoOutput>>()
                    );
        }

        public async Task<ListResultDto<StudentClassDtoOutput>> GetAllAsync()
        {
            var studentClass = await _studentClassRepository.GetAll().Include(p => p.Major).ToListAsync();

            return new ListResultDto<StudentClassDtoOutput>(
                 ObjectMapper.Map<List<StudentClassDtoOutput>>(studentClass)
                 );
        }

        public async Task<StudentClassDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var studentClass = await _studentClassRepository.FirstOrDefaultAsync(entity.Id);

            var studentClassDtoOutput = Mapper.Map<StudentClassDtoOutput>(studentClass);
            return studentClassDtoOutput;
        }

        public async Task<StudentClassDtoOutput> UpdateAsync(StudentClassDtoInput entity)
        {
            StudentClass studentClass = new StudentClass()
            {
                 Id = entity.Id,
                 GradeName = entity.GradeName,
                 MajorId = entity.MajorId,
                 StudentClassName = entity.StudentClassName
            };
            var updateStudentClasses = await _studentClassRepository.UpdateAsync(studentClass);

            var StudentClassesDtoOutput = Mapper.Map<StudentClassDtoOutput>(updateStudentClasses);
            return StudentClassesDtoOutput;
        }
    }
}
