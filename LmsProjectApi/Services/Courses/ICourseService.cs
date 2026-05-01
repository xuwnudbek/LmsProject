using LmsProjectApi.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Courses
{
    public interface ICourseService
    {
        Task<CourseResponseDto> AddAsync(CourseCreateDto dto);
        ICollection<CourseResponseDto> GetAll();
        Task<CourseResponseDto> GetByIdAsync(Guid courseId);
        Task<CourseResponseDto> UpdateAsync(Guid courseId, CourseUpdateDto dto);
        Task DeleteAsync(Guid courseId);
    }
}
