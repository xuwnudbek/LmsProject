using LmsProjectApi.DTOs.Lessons;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.Models.Api;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Services.Levels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelsController(ILevelService levelService)
        {
            _levelService = levelService;
        }

        [HttpPost]
        public async Task<ActionResult<LevelResponseDto>> CreateAsync(LevelCreateDto dto)
        {
            LevelResponseDto created = 
                await _levelService.AddAsync(dto);

            return Ok(ApiResponse<LevelResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpGet]
        public ActionResult<IEnumerable<LevelResponseDto>> GetAllAsync()
        {
            IEnumerable<LevelResponseDto> levels = 
                _levelService.GetAll();

            return Ok(ApiResponse<IEnumerable<LevelResponseDto>>.Ok(levels));
        }

        [HttpGet("{levelId}")]
        public async Task<ActionResult<LevelResponseDto>> GetByIdAsync(Guid levelId)
        {
            LevelResponseDto level =
                await _levelService.GetByIdAsync(levelId);

            return Ok(ApiResponse<LevelResponseDto>.Ok(level));

        }

        [HttpPut("{levelId}")]
        public async Task<ActionResult<LevelResponseDto>> UpdateAsync(
            Guid levelId,
            [FromBody] LevelUpdateDto dto)
        {
            LevelResponseDto updated =
                await _levelService.UpdateAsync(levelId, dto);

            return Ok(ApiResponse<LevelResponseDto>.Ok(updated, "Successfully updated."));
        }

        [HttpDelete("{levelId}")]
        public async Task<ActionResult<LevelResponseDto>> DeleteAsync(Guid levelId)
        {
            await _levelService.DeleteAsync(levelId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));
        }
    }
}
