using LmsProjectApi.DTOs.Attendances;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Attendances
{
    public interface IAttendanceService
    {
        Task<AttendanceResponseDto> AddAsync(AttendanceCreateDto dto);
        ICollection<AttendanceResponseDto> GetAll();
        Task<AttendanceResponseDto> GetByIdAsync(Guid attendanceId);
        Task<AttendanceResponseDto> UpdateAsync(Guid attendanceId, AttendanceUpdateDto dto);
        Task DeleteAsync(Guid attendanceId);
    }
}
