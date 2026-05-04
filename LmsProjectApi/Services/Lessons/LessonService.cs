using AutoMapper;
using LmsProjectApi.DTOs.Lessons;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Lessons;
using LmsProjectApi.Repositories.Lessons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonService(
            ILessonRepository lessonRepository,
            IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<LessonResponseDto> AddAsync(LessonCreateDto dto)
        {
            Lesson lesson = _mapper.Map<Lesson>(dto);

            Lesson inserted =
                await _lessonRepository.InsertAsync(lesson);

            return _mapper.Map<LessonResponseDto>(inserted);
        }

        public async Task<IEnumerable<LessonResponseDto>> AddRangeAsync(
            IEnumerable<LessonCreateDto> dtos)
        {
            var lessons = _mapper.Map<IEnumerable<Lesson>>(dtos);

            var insertedLessons =
                await _lessonRepository.InsertRangeAsync(lessons);

            return _mapper.Map<IEnumerable<LessonResponseDto>>(insertedLessons);
        }

        public ICollection<LessonResponseDto> GetAll()
        {
            ICollection<Lesson> lessons = 
                _lessonRepository.SelectAll().ToList();

            return _mapper.Map<ICollection<LessonResponseDto>>(lessons);
        }


        public async Task<LessonResponseDto> GetByIdAsync(Guid lessonId)
        {
            Lesson existingLesson =
                await _lessonRepository.SelectByIdAsync(lessonId);

            if(existingLesson is null)
                throw new NotFoundException($"Lesson with id ({lessonId}) not found.");

            return _mapper.Map<LessonResponseDto>(existingLesson);
        }

        public async Task<LessonResponseDto> UpdateAsync(Guid lessonId, LessonUpdateDto dto)
        {
            Lesson existingLesson =
                await _lessonRepository.SelectByIdAsync(lessonId);

            if (existingLesson is null)
                throw new NotFoundException($"Lesson with id ({lessonId}) not found.");

            _mapper.Map(dto, existingLesson);

            await _lessonRepository.UpdateAsync();

            return _mapper.Map<LessonResponseDto>(existingLesson);
        }
        
        public async Task DeleteAsync(Guid lessonId)
        {
            Lesson existingLesson =
                await _lessonRepository.SelectByIdAsync(lessonId);

            if (existingLesson is null)
                throw new NotFoundException($"Lesson with id ({lessonId}) not found.");

            await _lessonRepository.DeleteAsync(existingLesson);
        }
    }
}
