using LmsProjectApi.Enums;
using LmsProjectApi.Models.LessonSessions;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.Models.Attendances
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public AttendanceStatus Status { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid LessonSessionId { get; set; }
        public LessonSession LessonSession { get; set; }
    }
}
