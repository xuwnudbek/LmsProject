using System;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Courses
{
    public class CourseCreateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PaymentValue { get; set; }
        public int DurationInDays { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid SubjectId { get; set; }
    }
}
