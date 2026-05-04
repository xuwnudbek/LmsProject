using LmsProjectApi.Enums;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.DTOs.Attendances
{
    public class AttendanceUpdateDto
    {
        public AttendanceStatus Status { get; set; }

        public Guid UserId { get; set; }
        public Guid LessonSessionId { get; set; }
    }
}
