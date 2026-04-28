using LmsProjectApi.DTOs.Level;
using LmsProjectApi.DTOs.Subject;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Services.Levels;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<LevelResponseDto>> PostAsync(LevelCreateDto dto)
        {
            var level = await _levelService.AddAsync(dto);

            return Ok(level);
        }

        [HttpGet]
        public ActionResult<IEnumerable<LevelResponseDto>> GetAllAsync()
        {
            IEnumerable<LevelResponseDto> levels = 
                _levelService.GetAll();

            return Ok(levels);
        }
    }
}
