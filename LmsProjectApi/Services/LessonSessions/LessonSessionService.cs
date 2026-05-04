using AutoMapper;
using LmsProjectApi.DTOs.LessonSessions;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Repositories.LessonSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.LessonSessions
{
    public class LessonSessionService
    {
        private readonly ILessonSessionRepository _lessonSessionRepository;
        private readonly IMapper _mapper;

        public LessonSessionService(
            ILessonSessionRepository lessonSessionRepository,
            IMapper mapper)
        {
            _lessonSessionRepository = lessonSessionRepository;
            _mapper = mapper;
        }


        public async Task<LessonSessionResponseDto> AddAsync(LessonSessionCreateDto dto)
        {
            LessonSession lessonSession = _mapper.Map<LessonSession>(dto);

            LessonSession inserted =
                await _lessonSessionRepository.InsertAsync(lessonSession);

            return _mapper.Map<LessonSessionResponseDto>(inserted);
        }

        public ICollection<LessonSessionResponseDto> GetAll()
        {
            ICollection<LessonSession> lessonSessions =
                _lessonSessionRepository.SelectAll().ToList();

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

        public async Task<LessonSessionResponseDto> UpdateAsync(Guid lessonSessionId, LessonSessionUpdateDto dto)
        {
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
