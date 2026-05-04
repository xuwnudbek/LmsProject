using System;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Courses
{
    public class CourseUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
