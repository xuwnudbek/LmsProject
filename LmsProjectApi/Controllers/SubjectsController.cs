using LmsProjectApi.DTOs.Subjects;
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
        public ActionResult<IEnumerable<SubjectResponseDto>> GetAllAsync(
            [FromQuery] bool withLevels)
        {
            IEnumerable<SubjectResponseDto> subjects = 
                _subjectService.GetAll(withLevels);

            return Ok(subjects);
        }

        [HttpGet("{subjectId}")]
        public async Task<ActionResult<SubjectResponseDto>> GetById(Guid subjectId)
        {
            SubjectResponseDto subject = 
                await _subjectService.GetByIdAsync(subjectId);

            return Ok(subject);
        }
    }
}
