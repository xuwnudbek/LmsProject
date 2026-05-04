using System;

namespace LmsProjectApi.DTOs.Lessons
{
    public class LessonUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid CourseId { get; set; }
    }
}
