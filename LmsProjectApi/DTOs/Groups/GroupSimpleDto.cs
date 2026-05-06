using System;

namespace LmsProjectApi.DTOs.Groups
{
    public class GroupSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PaymentValue { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public Guid LevelId { get; set; }
        public Guid CourseId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
