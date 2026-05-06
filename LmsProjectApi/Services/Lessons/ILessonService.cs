using LmsProjectApi.DTOs.Lessons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Lessons
{
    public interface ILessonService
    {
        Task<LessonResponseDto> AddAsync(LessonCreateDto dto);
        Task<IEnumerable<LessonResponseDto>> AddRangeAsync(IEnumerable<LessonCreateDto> dtos);
        ICollection<LessonResponseDto> GetAll();
        Task<LessonResponseDto> GetByIdAsync(Guid lessonId);
        Task<LessonResponseDto> UpdateAsync(Guid lessonId, LessonUpdateDto dto);
        Task DeleteAsync(Guid lessonId);
    }
}
