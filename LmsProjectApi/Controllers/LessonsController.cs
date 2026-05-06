using LmsProjectApi.DTOs.Lessons;
using LmsProjectApi.Models.Api;
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

            return Ok(ApiResponse<LessonResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpPost("some")]
        public async Task<ActionResult<IEnumerable<LessonResponseDto>>> CreateSomeAsync(
            [FromBody] IEnumerable<LessonCreateDto> dto)
        {
            IEnumerable<LessonResponseDto> createdLessons =
                await _lessonService.AddRangeAsync(dto);

            return Ok(ApiResponse<IEnumerable<LessonResponseDto>>.Ok(createdLessons, "Successfully created."));

        }

        [HttpGet]
        public ActionResult<ICollection<LessonResponseDto>> GetAll()
        {
            ICollection<LessonResponseDto> lessons =
                _lessonService.GetAll();

            return Ok(ApiResponse<ICollection<LessonResponseDto>>.Ok(lessons));

        }

        [HttpGet("{lessonId}")]
        public async Task<ActionResult<LessonResponseDto>> GetByIdAsync(Guid lessonId)
        {
            LessonResponseDto lesson =
                await _lessonService.GetByIdAsync(lessonId);

            return Ok(ApiResponse<LessonResponseDto>.Ok(lesson));
        }

        [HttpPut("{lessonId}")]
        public async Task<ActionResult<LessonResponseDto>> UpdateAsync(
            Guid lessonId,
            LessonUpdateDto dto)
        {
            LessonResponseDto updated =
                await _lessonService.UpdateAsync(lessonId, dto);

            return Ok(ApiResponse<LessonResponseDto>.Ok(updated, "Successfully updated."));

        }

        [HttpDelete("{lessonId}")]
        public async Task<IActionResult> DeleteAsync(Guid lessonId)
        {
            await _lessonService.DeleteAsync(lessonId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));
        }
    }
}
