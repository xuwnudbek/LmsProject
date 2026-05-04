using LmsProjectApi.DTOs.Subjects;
using LmsProjectApi.DTOs.Users;
using System;

namespace LmsProjectApi.DTOs.Courses
{
    public class CourseResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }


        public UserResponseDto User { get; set; }
        public SubjectResponseDto Subject { get; set; }
    }
}
