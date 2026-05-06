

using LmsProjectApi.DTOs.Attendances;
using LmsProjectApi.Models.Api;
using LmsProjectApi.Models.UserTokens;
using LmsProjectApi.Services.Attendances;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceResponseDto>> CreateAsync(
            [FromBody] AttendanceCreateDto dto)
        {
            AttendanceResponseDto created =
                await _attendanceService.AddAsync(dto);

            return Ok(ApiResponse<AttendanceResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceResponseDto>> GetAllAsync()
        {
            IEnumerable<AttendanceResponseDto> attendances =
                _attendanceService.GetAll();

            return Ok(ApiResponse<IEnumerable<AttendanceResponseDto>>.Ok(attendances));
        }

        [HttpGet("{attendanceId}")]
        public async Task<ActionResult<IEnumerable<AttendanceResponseDto>>> GetByIdAsync(Guid attendanceId)
        {
            AttendanceResponseDto attendance =
                await _attendanceService.GetByIdAsync(attendanceId);

            return Ok(attendance);
        }

        [HttpPut("{attendanceId}")]
        public async Task<ActionResult<AttendanceResponseDto>> UpdateAsync(
            Guid attendanceId,
            [FromBody] AttendanceUpdateDto dto)
        {
            AttendanceResponseDto updated =
                await _attendanceService.UpdateAsync(attendanceId, dto);

            return Ok(ApiResponse<AttendanceResponseDto>.Ok(updated, "Successfully updated."));
        }

        [HttpDelete("{attendanceId}")]
        public async Task<IActionResult> DeleteAsync(Guid attendanceId)
        {
            await _attendanceService.DeleteAsync(attendanceId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));
        }

    }
}
