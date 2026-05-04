using LmsProjectApi.Enums;
using System;

namespace LmsProjectApi.DTOs.LessonSessions
{
    public class LessonSessionCreateDto
    {
        public LessonSessionStatus Status { get; set; }
        public AttendanceStatus TeacherAttendanceStatus { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }

        public Guid LessonId { get; set; }
        public Guid GroupId { get; set; }
    }
}
