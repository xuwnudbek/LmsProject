using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.LessonSessions;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Lessons
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<LessonSession> LessonSessions { get; set; } = new HashSet<LessonSession>();
    }
}
