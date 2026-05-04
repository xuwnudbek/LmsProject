using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.DTOs.UserGroups;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.DTOs.Groups
{
    public class GroupResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public LevelResponseDto Level { get; set; }
        public CourseResponseDto Course { get; set; }

        public ICollection<UserGroupResponseDto> Users { get; set; } = new HashSet<UserGroupResponseDto>();

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
