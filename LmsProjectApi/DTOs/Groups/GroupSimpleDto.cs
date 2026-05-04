using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.DTOs.UserGroups;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.DTOs.Groups
{
    public class GroupSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid LevelId { get; set; }
        public Guid CourseId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
