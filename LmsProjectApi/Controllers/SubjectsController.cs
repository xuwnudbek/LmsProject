using LmsProjectApi.DTOs.Subjects;
using LmsProjectApi.Models.Api;
using LmsProjectApi.Services.Subjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        public async Task<ActionResult<SubjectResponseDto>> CreateAsync(SubjectCreateDto dto)
        {
            SubjectResponseDto created =
                await _subjectService.AddAsync(dto);

            return Ok(ApiResponse<SubjectResponseDto>.Ok(created, "Successfully created."));
        }


        [HttpGet]
        public ActionResult<IEnumerable<SubjectResponseDto>> GetAllAsync(
            [FromQuery] bool withLevels)
        {
            IEnumerable<SubjectResponseDto> subjects =
                _subjectService.GetAll(withLevels);

            return Ok(ApiResponse<IEnumerable<SubjectResponseDto>>.Ok(subjects));
        }


        [HttpGet("{subjectId}")]
        public async Task<ActionResult<SubjectResponseDto>> GetById(Guid subjectId)
        {
            SubjectResponseDto subject =
                await _subjectService.GetByIdAsync(subjectId);

            return Ok(ApiResponse<SubjectResponseDto>.Ok(subject));
        }


        [HttpPut("{subjectId}")]
        public async Task<ActionResult<SubjectResponseDto>> UpdateAsync(
            Guid subjectId,
            [FromBody] SubjectUpdateDto dto)
        {
            SubjectResponseDto updated =
                await _subjectService.UpdateAsync(subjectId, dto);

            return Ok(ApiResponse<SubjectResponseDto>.Ok(updated, "Successfully updated."));
        }


        [HttpDelete("{subjectId}")]
        public async Task<ActionResult<SubjectResponseDto>> DeleteAsync(Guid subjectId)
        {
            await _subjectService.DeleteAsync(subjectId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));

        }

    }
}
