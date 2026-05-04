using LmsProjectApi.DTOs.Lessons;
using LmsProjectApi.Services.Lessons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<ActionResult<LessonResponseDto>> CreateAsync(
            [FromBody] LessonCreateDto dto)
        {
            LessonResponseDto created =
                await _lessonService.AddAsync(dto);

            return Ok(created);
        }

        [HttpPost("some")]
        public async Task<ActionResult<IEnumerable<LessonResponseDto>>> CreateSomeAsync(
            [FromBody] IEnumerable<LessonCreateDto> dto)
        {
            var createdLessons =
                await _lessonService.AddRangeAsync(dto);

            return Ok(createdLessons);
        }

        [HttpGet]
        public ActionResult<ICollection<LessonResponseDto>> GetAll()
        {
            ICollection<LessonResponseDto> lessons =
                _lessonService.GetAll();

            return Ok(lessons);
        }

        [HttpGet("{lessonId}")]
        public async Task<ActionResult<LessonResponseDto>> GetByIdAsync(Guid lessonId)
        {
            LessonResponseDto lesson =
                await _lessonService.GetByIdAsync(lessonId);

            return Ok(lesson);
        }

        [HttpPut("{lessonId}")]
        public async Task<ActionResult<LessonResponseDto>> GetByIdAsync(
            Guid lessonId,
            LessonUpdateDto dto)
        {
            LessonResponseDto updated =
                await _lessonService.UpdateAsync(lessonId, dto);

            return Ok(updated);
        }

        [HttpDelete("{lessonId}")]
        public async Task<IActionResult> DeleteAsync(Guid lessonId)
        {
            await _lessonService.DeleteAsync(lessonId);

            return Ok();
        }
    }
}
