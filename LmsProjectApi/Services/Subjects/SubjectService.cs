using AutoMapper;
using LmsProjectApi.DTOs.Subjects;
using LmsProjectApi.DTOs.SubjectLevel;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.SubjectLevels;
using LmsProjectApi.Models.Subjects;
using LmsProjectApi.Repositories.Subjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LmsProjectApi.Repositories.SubjectLevels;

namespace LmsProjectApi.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISubjectLevelRepository _subjectLevelRepository;
        private readonly IMapper _mapper;

        public SubjectService(
            ISubjectRepository subjectRepository,
            ISubjectLevelRepository subjectLevelRepository,
            IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _subjectLevelRepository = subjectLevelRepository;
            _mapper = mapper;
        }

        public async Task<SubjectResponseDto> AddAsync(SubjectCreateDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);

            if(!dto.HasLevel && dto.Levels.Any())
                throw new BadRequestException("Levels cannot be provided when HasLevel is false.");

            var incomingLevelIds = dto.Levels;
            int orderIndex = 0;

            foreach (var levelId in incomingLevelIds)
            {
                (subject.SubjectLevels ??= [])
                    .Add(new SubjectLevel
                    {
                        LevelId = levelId,
                        OrderIndex = orderIndex
                    });

                orderIndex++;
            }

            var insertedSubject =
                await _subjectRepository.InsertAsync(subject);

            return _mapper.Map<SubjectResponseDto>(insertedSubject);
        }

        public ICollection<SubjectResponseDto> GetAll(bool withLevels = false)
        {
            var query = _subjectRepository.SelectAll();

            if (withLevels)
            {
                query = query
                    .Include(s => s.SubjectLevels.OrderBy(sl => sl.OrderIndex))
                    .ThenInclude(sl => sl.Level);
            }

            return _mapper.Map<ICollection<SubjectResponseDto>>(query.ToList());
        }

        public async Task<SubjectResponseDto> GetByIdAsync(Guid subjectId)
        {
            Subject existingSubject =
                await _subjectRepository.SelectByIdAsync(subjectId);

            if (existingSubject is null)
                throw new NotFoundException($"Subject with id ({subjectId}) not found");

            return _mapper.Map<SubjectResponseDto>(existingSubject);
        }

        public async Task<SubjectResponseDto> UpdateAsync(
            Guid subjectId,
            SubjectUpdateDto dto)
        {
            Subject existingSubject =
                await _subjectRepository.SelectByIdAsync(subjectId);
            
            if (existingSubject is null)
                throw new NotFoundException($"Subject with id ({subjectId}) not found.");

            if (!dto.HasLevel && (dto.Levels ??= []).Any())
                throw new BadRequestException("Levels cannot be provided when HasLevel is false.");

            ICollection<Guid> levelIds = dto.Levels;

            existingSubject.Name = dto.Name;
            existingSubject.HasLevel = dto.HasLevel;

            await _subjectLevelRepository
                .DeleteRangeAsync(existingSubject.SubjectLevels ?? []);

            var incomingLevelIds = dto.Levels;
            int orderIndex = 0;

            foreach (var levelId in incomingLevelIds)
            {
                existingSubject.SubjectLevels
                    .Add(new SubjectLevel
                    {
                        SubjectId = existingSubject.Id,
                        LevelId = levelId,
                        OrderIndex = orderIndex
                    });

                orderIndex++;
            }

            await _subjectRepository.UpdateAsync();

            Subject updatedSubject =
                await _subjectRepository.SelectByIdAsync(subjectId);

            updatedSubject.SubjectLevels = 
                updatedSubject.SubjectLevels
                    .OrderBy(sl => sl.OrderIndex)
                    .ToList();

            return _mapper.Map<SubjectResponseDto>(updatedSubject);
        }

        public async Task DeleteAsync(Guid subjectId)
        {
            Subject existingSubject =
                await _subjectRepository.SelectByIdAsync(subjectId);

            if (existingSubject is null)
                throw new NotFoundException($"Subject with id ({subjectId}) not found");

            await _subjectRepository.DeleteAsync(existingSubject);
        }
    }
}
