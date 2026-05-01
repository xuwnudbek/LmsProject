using LmsProjectApi.DTOs.Subjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Subjects
{
    public interface ISubjectService
    {
        Task<SubjectResponseDto> AddAsync(SubjectCreateDto dto);
        ICollection<SubjectResponseDto> GetAll(bool withLevels);
        Task<SubjectResponseDto> GetByIdAsync(Guid subjectId);
        Task<SubjectResponseDto> UpdateAsync(Guid subjectId, SubjectUpdateDto dto);
        Task DeleteAsync(Guid subjectId);
    }
}