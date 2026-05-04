using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.Services.Courses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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
        public async Task<ActionResult<CourseResponseDto>> CreateAsync(
            [FromBody] CourseCreateDto dto)
        {
            CourseResponseDto created = 
                await _courseService.AddAsync(dto);

            return Ok(created);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseResponseDto>> GetAllAsync()
        {
            IEnumerable<CourseResponseDto> courses = 
                _courseService.GetAll();

            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseResponseDto>> GetByIdAsync(Guid courseId)
        {
            CourseResponseDto course =
                await _courseService.GetByIdAsync(courseId);

            return Ok(course);
        }

        [HttpPut("{courseId}")]
        public async Task<ActionResult<CourseResponseDto>> UpdateAsync(
            Guid courseId,
            [FromBody] CourseUpdateDto dto)
        {
            CourseResponseDto updated =
                await _courseService.UpdateAsync(courseId, dto);

            return Ok(updated);
        }

        [HttpDelete("{courseId}")]
        public async Task<ActionResult<CourseResponseDto>> DeleteAsync(Guid courseId)
        {
            await _courseService.DeleteAsync(courseId);
            
            return Ok();
        }

    }
}
