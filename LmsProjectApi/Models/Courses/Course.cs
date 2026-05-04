using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.Subjects;
using LmsProjectApi.Models.Users;
using System;

namespace LmsProjectApi.Models.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public int PaymentValue { get; set; }
        public int DurationInDays { get; set; }
        
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
