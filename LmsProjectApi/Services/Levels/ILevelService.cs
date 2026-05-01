using LmsProjectApi.DTOs.Levels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Levels
{
    public interface ILevelService
    {
        Task<LevelResponseDto> AddAsync(LevelCreateDto dto);
        ICollection<LevelResponseDto> GetAll();
        Task<LevelResponseDto> GetByIdAsync(Guid levelId);
        Task<LevelResponseDto> UpdateAsync(Guid levelId, LevelUpdateDto dto);
        Task DeleteAsync(Guid levelId);
    }
}
