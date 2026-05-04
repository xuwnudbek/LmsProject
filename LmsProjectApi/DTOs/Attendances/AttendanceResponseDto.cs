using LmsProjectApi.Enums;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.DTOs.Attendances
{
    public class AttendanceResponseDto
    {
        public AttendanceStatus Status { get; set; }

        public User User { get; set; }
        public LessonSession LessonSession { get; set; }

    }
}
