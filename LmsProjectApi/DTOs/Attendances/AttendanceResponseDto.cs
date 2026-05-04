using LmsProjectApi.DTOs.LessonSessions;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Enums;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.DTOs.Attendances
{
    public class AttendanceResponseDto
    {
        public AttendanceStatus Status { get; set; }

        public UserResponseDto User { get; set; }
        public LessonSessionResponseDto LessonSession { get; set; }
    }
}
