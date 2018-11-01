using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Applications.Majors.Dto;
using MyTextBook.Entitys.Majors;

namespace MyTextBook.Applications.Majors
{
    public class MajorsAppService : MyTextBookAppServiceBase, IMajorsAppService
    {
        private readonly IRepository<Major> _majorRepository;//仓储
        public MajorsAppService(IRepository<Major> majorRepository)
        {
            _majorRepository = majorRepository;
        }
        public async Task<MajorDtoOutput> CreateAsync(MajorDtoInput entity)
        {
            Major major = new Major()
            {
                MajorName = entity.MajorName,
                LeaderName = entity.LeaderName,
                TDepartmentId = entity.TDepartmentId
            };
            var newMajor = await _majorRepository.InsertAsync(major);
            return new MajorDtoOutput();
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var major = await _majorRepository.GetAsync(entity.Id);
            await _majorRepository.DeleteAsync(major);
        }

        public async Task<ListResultDto<MajorDtoOutput>> GetAllAsync()
        {
            var major = await _majorRepository.GetAll().Include(p => p.TDepartment).ToListAsync();

            return new ListResultDto<MajorDtoOutput>(
                 ObjectMapper.Map<List<MajorDtoOutput>>(major)
                 );
        }

        public async Task<ListResultDto<MajorDtoOutput>> GetAllByTDepartmentIdAsync(EntityDto entity)
        {
            var major = await _majorRepository.GetAll().Where(p => p.TDepartmentId == entity.Id).ToListAsync();

            return new ListResultDto<MajorDtoOutput>(
                 ObjectMapper.Map<List<MajorDtoOutput>>(major)
                 );
        }


        public Task GetAllByTDepartmentIdAsync(object entityDto)
        {
            throw new NotImplementedException();
        }

        public async Task<MajorDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var major = await _majorRepository.FirstOrDefaultAsync(entity.Id);

            var majorDtoOutput = Mapper.Map<MajorDtoOutput>(major);
            return majorDtoOutput;
        }

        public async Task<MajorDtoOutput> UpdateAsync(MajorDtoInput entity)
        {
            Major major = new Major()
            {
                Id = entity.Id,
                MajorName = entity.MajorName,
                LeaderName = entity.LeaderName,
                TDepartmentId = entity.TDepartmentId
            };
            var updateMajors = await _majorRepository.UpdateAsync(major);

            var courseDtoOutput = Mapper.Map<MajorDtoOutput>(updateMajors);
            return courseDtoOutput;
        }
    }
}
