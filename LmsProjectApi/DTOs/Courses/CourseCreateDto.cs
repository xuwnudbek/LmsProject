using System;

namespace LmsProjectApi.DTOs.Courses
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
