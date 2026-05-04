using LmsProjectApi.Enums;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Lessons;
using System;

namespace LmsProjectApi.DTOs.LessonSessions
{
    public class LessonSessionResponseDto
    {
        public LessonSessionStatus Status { get; set; }
        public AttendanceStatus TeacherAttendanceStatus { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }

        public Lesson Lesson { get; set; }
        public Group Group { get; set; }
    }
}
