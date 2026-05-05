using LmsProjectApi.DTOs.LessonSessions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.LessonSessions
{
    public interface ILessonSessionService
    {
        Task<LessonSessionResponseDto> AddAsync(LessonSessionCreateDto dto);
        ICollection<LessonSessionResponseDto> GetAll();
        Task<LessonSessionResponseDto> GetByIdAsync(Guid lessonSessionId);
        Task<LessonSessionResponseDto> UpdateAsync(Guid lessonSessionId, LessonSessionUpdateDto dto);
        Task DeleteAsync(Guid lessonSessionId);
    }
}
