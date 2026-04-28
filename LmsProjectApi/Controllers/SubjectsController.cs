using LmsProjectApi.DTOs.Subject;
using LmsProjectApi.Services.Subjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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
        public async Task<ActionResult<SubjectResponseDto>> PostAsync(SubjectCreateDto dto)
        {
            SubjectResponseDto newSubject = 
                await _subjectService.AddAsync(dto);

            return Ok(newSubject);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubjectSimpleDto>> GetAllAsync(
            [FromQuery] bool withLevels)
        {
            IEnumerable<SubjectSimpleDto> subjects = 
                _subjectService.GetAll(withLevels);

            return Ok(subjects);
        }
        
        [HttpGet("with-levels")]
        public ActionResult<IEnumerable<SubjectResponseDto>> GetAllWithLevelsAsync()
        {
            IEnumerable<SubjectResponseDto> subjects = 
                _subjectService.GetAllWithLevels();

            return Ok(subjects);
        }

        [HttpPut("{subjectId}")]
        public async Task<ActionResult<SubjectResponseDto>> PutAsync(
            Guid subjectId,
            [FromBody] SubjectUpdateDto dto)
        {
            SubjectResponseDto updatedSubject = 
                await _subjectService.UpdateAsync(subjectId, dto);

            return Ok(updatedSubject);
        }
    }
}
