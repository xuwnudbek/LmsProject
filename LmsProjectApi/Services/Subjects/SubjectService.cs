using AutoMapper;
using LmsProjectApi.DTOs.Subject;
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

namespace LmsProjectApi.Services.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(
            ISubjectRepository subjectRepository,
            IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<SubjectResponseDto> AddAsync(SubjectCreateDto dto)
        {
            Subject subject =
                await _subjectRepository.InsertAsync(_mapper.Map<Subject>(dto));

            Subject newSubject =
                await _subjectRepository.SelectByIdAsync(subject.Id);

            return _mapper.Map<SubjectResponseDto>(subject);
        }

        public ICollection<SubjectSimpleDto> GetAll(bool withLevels = false)
        {
            var query = _subjectRepository.SelectAllAsync();

            if (withLevels)
            {
                query = query.Include(s => s.SubjectLevels)
                    .ThenInclude(sl => sl.Level);
            }

            ICollection<Subject> subjects = query.ToList();

            return _mapper.Map<ICollection<SubjectSimpleDto>>(subjects);
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
                throw new NotFoundException($"Subject with id ({subjectId}) not found");

            existingSubject.Name = dto.Name;
            existingSubject.HasLevel = dto.HasLevel;

            var levels = dto.Levels ?? new List<SubjectLevelUpdateDto>();

            if (!dto.HasLevel && levels.Any())
                throw new BadRequestException("Levels cannot be provided when HasLevel is false");

            existingSubject.SubjectLevels = dto.HasLevel
                ? levels.Select(lvl => new SubjectLevel
                {
                    LevelId = lvl.LevelId,
                    OrderIndex = lvl.OrderIndex,
                }).ToList()
                : [];

            await _subjectRepository.UpdateAsync();

            Subject updatedSubject =
                await _subjectRepository.SelectByIdAsync(subjectId);

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
