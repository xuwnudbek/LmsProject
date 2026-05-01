using LmsProjectApi.Models.Courses;
using System;

namespace LmsProjectApi.Models.Lessons
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
