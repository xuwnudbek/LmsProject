using LmsProjectApi.DTOs.Lessons;
using LmsProjectApi.DTOs.LessonSessions;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Services.LessonSessions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonSessionsController : ControllerBase
    {
        private readonly ILessonSessionService _lessonSessionService;
        public LessonSessionsController(
            ILessonSessionService lessonSessionService)
        {
            _lessonSessionService = lessonSessionService;
        }

        [HttpPost]
        public async Task<ActionResult<LessonSessionResponseDto>> CreateAsync(
            [FromBody] LessonSessionCreateDto dto)
        {
            LessonSessionResponseDto created =
                await _lessonSessionService.AddAsync(dto);

            return Ok(created);
        }

        [HttpGet]
        public ActionResult<ICollection<LessonSessionResponseDto>> GetAll()
        {
            ICollection<LessonSessionResponseDto> lessonSessions =
                _lessonSessionService.GetAll();

            return Ok(lessonSessions);
        }

        [HttpGet("{lessonId}")]
        public async Task<ActionResult<LessonSessionResponseDto>> GetByIdAsync(Guid lessonSessionId)
        {
            LessonSessionResponseDto lessonSessions =
                await _lessonSessionService.GetByIdAsync(lessonSessionId);

            return Ok(lessonSessions);
        }

        [HttpPut("{lessonId}")]
        public async Task<ActionResult<LessonSessionResponseDto>> GetByIdAsync(
            Guid lessonSessionId,
            LessonSessionUpdateDto dto)
        {
            LessonSessionResponseDto updated =
                await _lessonSessionService.UpdateAsync(lessonSessionId, dto);

            return Ok(updated);
        }

        [HttpDelete("{lessonSessionId}")]
        public async Task<IActionResult> DeleteAsync(Guid lessonSessionId)
        {
            await _lessonSessionService.DeleteAsync(lessonSessionId);

            return Ok();
        }
    }
}
