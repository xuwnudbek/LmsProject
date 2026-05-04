using LmsProjectApi.Enums;
using System;

namespace LmsProjectApi.DTOs.Attendances
{
    public class AttendanceCreateDto
    {
        public AttendanceStatus Status { get; set; }

        public Guid UserId { get; set; }
        public Guid LessonSessionId { get; set; }
    }
}
