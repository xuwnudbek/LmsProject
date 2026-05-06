using LmsProjectApi.DTOs.LessonSessions;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Enums;

namespace LmsProjectApi.DTOs.Attendances
{
    public class AttendanceResponseDto
    {
        public AttendanceStatus Status { get; set; }

        public UserResponseDto User { get; set; }
        public LessonSessionResponseDto LessonSession { get; set; }
    }
}
