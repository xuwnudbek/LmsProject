using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.Subjects;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.Models.Courses
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int PaymentValue { get; set; }
        public int DurationInDays { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
