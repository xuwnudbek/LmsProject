using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.LessonSessions;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Repositories.LessonSessions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.LessonSessions
{
    public class LessonSessionService : ILessonSessionService
    {
        private readonly ILessonSessionRepository _lessonSessionRepository;
        private readonly IValidator<LessonSessionCreateDto> _lessonSessionCreateValidator;
        private readonly IValidator<LessonSessionUpdateDto> _lessonSessionUpdateValidator;
        private readonly IMapper _mapper;

        public LessonSessionService(
            ILessonSessionRepository lessonSessionRepository,
            IValidator<LessonSessionCreateDto> lessonSessionCreateValidator,
            IValidator<LessonSessionUpdateDto> lessonSessionUpdateValidator,
            IMapper mapper)
        {
            _lessonSessionRepository = lessonSessionRepository;
            _lessonSessionCreateValidator = lessonSessionCreateValidator;
            _lessonSessionUpdateValidator = lessonSessionUpdateValidator;
            _mapper = mapper;
        }

        public async Task<LessonSessionResponseDto> AddAsync(LessonSessionCreateDto dto)
        {
            var validatorResult = _lessonSessionCreateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

            LessonSession lessonSession = _mapper.Map<LessonSession>(dto);

            LessonSession inserted =
                await _lessonSessionRepository.InsertAsync(lessonSession);

            return _mapper.Map<LessonSessionResponseDto>(inserted);
        }

        public ICollection<LessonSessionResponseDto> GetAll()
        {
            ICollection<LessonSession> lessonSessions =
                _lessonSessionRepository
                    .SelectAll()
                    .Include(ls => ls.Lesson)
                    .ToList();

            return _mapper.Map<ICollection<LessonSessionResponseDto>>(lessonSessions);
        }

        public async Task<LessonSessionResponseDto> GetByIdAsync(Guid lessonSessionId)
        {
            LessonSession existingLessonSession =
                await _lessonSessionRepository.SelectByIdAsync(lessonSessionId);

            if (existingLessonSession is null)
                throw new NotFoundException($"LessonSession with id ({lessonSessionId}) not found.");

            return _mapper.Map<LessonSessionResponseDto>(existingLessonSession);
        }

        public async Task<LessonSessionResponseDto> UpdateAsync(
            Guid lessonSessionId,
            LessonSessionUpdateDto dto)
        {
            var validatorResult = _lessonSessionUpdateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

            LessonSession existingLessonSession =
                await _lessonSessionRepository.SelectByIdAsync(lessonSessionId);

            if (existingLessonSession is null)
                throw new NotFoundException($"LessonSession with id ({lessonSessionId}) not found.");

            _mapper.Map(dto, existingLessonSession);

            await _lessonSessionRepository.UpdateAsync();

            return _mapper.Map<LessonSessionResponseDto>(existingLessonSession);
        }

        public async Task DeleteAsync(Guid lessonSessionId)
        {
            LessonSession existingLessonSession =
                await _lessonSessionRepository.SelectByIdAsync(lessonSessionId);

            if (existingLessonSession is null)
                throw new NotFoundException($"LessonSession with id ({lessonSessionId}) not found.");

            await _lessonSessionRepository.DeleteAsync(existingLessonSession);
        }
    }
}
