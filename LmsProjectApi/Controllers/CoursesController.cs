using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.Models.Api;
using LmsProjectApi.Services.Courses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CourseResponseDto>>> CreateAsync(
            [FromBody] CourseCreateDto dto)
        {
            CourseResponseDto created = await _courseService.AddAsync(dto);

            return Ok(ApiResponse<CourseResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<CourseResponseDto>>> GetAllAsync()
        {
            IEnumerable<CourseResponseDto> courses = _courseService.GetAll();

            return Ok(ApiResponse<IEnumerable<CourseResponseDto>>.Ok(courses));
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<ApiResponse<CourseResponseDto>>> GetByIdAsync(Guid courseId)
        {
            CourseResponseDto course = await _courseService.GetByIdAsync(courseId);

            return Ok(ApiResponse<CourseResponseDto>.Ok(course));
        }

        [HttpPut("{courseId}")]
        public async Task<ActionResult<ApiResponse<CourseResponseDto>>> UpdateAsync(
            Guid courseId,
            [FromBody] CourseUpdateDto dto)
        {
            CourseResponseDto updated = await _courseService.UpdateAsync(courseId, dto);

            return Ok(ApiResponse<CourseResponseDto>.Ok(updated, "Successfully updated."));
        }

        [HttpDelete("{courseId}")]
        public async Task<ActionResult<ApiResponse<object>>> DeleteAsync(Guid courseId)
        {
            await _courseService.DeleteAsync(courseId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));
        }
    }
}