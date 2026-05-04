using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.UserGroups;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.DTOs.Groups
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int PaymentValue { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public Guid LevelId { get; set; }
        public Guid CourseId { get; set; }
    }
}
