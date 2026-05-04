using LmsProjectApi.Enums;
using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Lessons;
using System;

namespace LmsProjectApi.Models.LessonSessions
{
    public class LessonSession : BaseEntity
    {
        public LessonSessionStatus Status { get; set; }
        public AttendanceStatus TeacherAttendanceStatus { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }

        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }

    }
}
