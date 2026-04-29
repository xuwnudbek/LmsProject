using System;

namespace LmsProjectApi.Models.Courses
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid LevelId { get; set; }
        public int PaymentValue  { get; set; }
        public int DurationInDays { get; set; }
    }
}
